using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

using FirebirdSql.Data.FirebirdClient;

using Ulee.Chart;
using Ulee.Controls;
using Ulee.Utils;

namespace Hnc.Calorimeter.Client
{
    public partial class CtrlTestGraphPanel : UlUserControlEng
    {
        public CtrlTestGraphPanel(int index, TestContext context, UlDoubleBufferedSeriesCollection series)
        {
            InitializeComponent();

            Index = index;
            this.context = context;
            handle = context.Handle;
            Method = context.Condition.Method;
            Initialize(series);
        }

        private int handle;
        private TestContext context;

        public int Index { get; set; }
        public bool Pause { get { return graphPauseLed.Active; } set { graphPauseLed.Active = value; } }
        public UlDoubleBufferedLineChart ViewGraph { get { return viewGraph; } }
        public ConditionMethod Method { get; set; }
        public XAxisRow xAxis { get; private set; }
        public List<YAxisRow> YAxisRows { get; private set; }
        public List<SeriesRow> PlotSeriesRows { get; private set; }
        public bool InvisibleUnchecked { get; set; }

        private bool seriesChecked { get; set; }

        private void Initialize(UlDoubleBufferedSeriesCollection series)
        {
            zoomAxisCombo.SelectedIndex = 0;

            viewGraph.Series.Clear();
            viewGraph.Mode = EChartMode.Dynamic;
            viewGraph.BackColor = Color.White;
            viewGraph.LegendFont = new Font("Arial", 7, FontStyle.Regular);

            viewGraph.SetBufferedSeries(series);
            viewGraph.SetPrimaryAxisX(AxisAlignment.Near, "Time", StringAlignment.Center, 0, 60000);

            InitializeYAxes();
            LoadYAxes();

            foreach (YAxisRow row in YAxisRows)
            {
                AxisAlignment align = (row.Align == EAxisAlign.Left) ? AxisAlignment.Near : AxisAlignment.Far;

                if (row.AxisNo == 0)
                    viewGraph.SetPrimaryAxisY(align, row.DescriptionUnit, StringAlignment.Far, row.WholeMin, row.WholeMax);
                else
                    viewGraph.AddSecondaryAxisY(align, row.DescriptionUnit, StringAlignment.Far, row.WholeMin, row.WholeMax);
            }

            InitializePlotSeries();
            LoadPlotSeries();

            xAxis = new XAxisRow();
            LoadXAxis();
            ResetRangeAxisX();

            viewGraph.Prepare();
            viewGraph.SetGridLinesAxisX(true);
            viewGraph.SetGridLinesAxisY(true);

            foreach (SeriesRow row in PlotSeriesRows)
            {
                viewGraph.Series[row.Name].View.Color = row.Color;
                viewGraph.Series[row.Name].Visible = row.Checked;
                viewGraph.SetSeriesAxisY(row.Name, GetIndexAxisY(row.UnitType));
            }

            foreach (YAxisRow row in YAxisRows)
            {
                viewGraph.AxesY[row.AxisNo].Visibility =
                    (row.Checked == true) ? DefaultBoolean.True : DefaultBoolean.False;
            }

            viewGraph.MarkLine.ShowValueMarkPoint += DoShowValueMarkPoint;
            viewGraph.MarkLine.Visible = false;

            viewGraph.Zooming.ZoomStackChanged += DoZoomStackChanged;
            viewGraph.Zooming.Clear();

            graphPauseLed.Active = false;

            plotSeriesGrid.DataSource = PlotSeriesRows;
            plotSeriesGrid.UseDirectXPaint = DefaultBoolean.False;
            plotSeriesGridView.Columns["Checked"].ImageOptions.ImageIndex = 1;
            plotSeriesGridView.Appearance.EvenRow.BackColor = Color.FromArgb(244, 244, 236);
            plotSeriesGridView.OptionsView.EnableAppearanceEvenRow = true;

            SetCursorAColumnVisible(false);
            SetCursorBColumnVisible(false);

            plotSeriesGridView.RefreshData();
        }

        private void DoShowValueMarkPoint(object sender, ShowValueMarkPointEventArgs e)
        {
            int i = 0;
            Axis2D axis = viewGraph.AxesX[0];

            if ((e.Visible == false) || ((e.ValueA < 0) && (e.ValueB < 0)))
            {
                SetCursorAColumnVisible(false);
                SetCursorBColumnVisible(false);
                RefreshGrid();
                return;
            }

            int indexA = (int)(e.ValueA / viewGraph.BaseTime);
            int indexB = (int)(e.ValueB / viewGraph.BaseTime);

            if ((viewGraph.BufferedSeries.PointsCount < indexA + 1) &&
                (viewGraph.BufferedSeries.PointsCount < indexB + 1))
            {
                SetCursorAColumnVisible(false);
                SetCursorBColumnVisible(false);
                RefreshGrid();
                return;
            }

            if (viewGraph.BufferedSeries.PointsCount < indexB + 1)
            {
                context.Value.Lock();
                viewGraph.BufferedSeries.Lock();

                try
                {
                    foreach (KeyValuePair<string, ValueRow> row in context.Value.Graph)
                    {
                        string format = row.Value.Format;
                        float cursorA = viewGraph.BufferedSeries[row.Key].Points[indexA];

                        SetCursorValue(i++, cursorA.ToString(format), "0", "0", "0", "0", "0");
                    }
                }
                finally
                {
                    viewGraph.BufferedSeries.Unlock();
                    context.Value.Unlock();
                }

                SetCursorAColumnVisible(true);
                SetCursorBColumnVisible(false);
                SetCursorColumnVisibleIndex();
                RefreshGrid();
                return;
            }


            if (viewGraph.BufferedSeries.PointsCount < indexA + 1)
            {
                context.Value.Lock();
                viewGraph.BufferedSeries.Lock();

                try
                {
                    foreach (KeyValuePair<string, ValueRow> row in context.Value.Graph)
                    {
                        string format = row.Value.Format;
                        float cursorB = viewGraph.BufferedSeries[row.Key].Points[indexB];

                        SetCursorValue(i++, "0", cursorB.ToString(format), "0", "0", "0", "0");
                    }
                }
                finally
                {
                    viewGraph.BufferedSeries.Unlock();
                    context.Value.Unlock();
                }

                SetCursorAColumnVisible(false);
                SetCursorBColumnVisible(true);
                SetCursorColumnVisibleIndex();
                RefreshGrid();
                return;
            }

            context.Value.Lock();
            viewGraph.BufferedSeries.Lock();

            try
            {
                foreach (KeyValuePair<string, ValueRow> row in context.Value.Graph)
                {
                    string format = row.Value.Format;
                    float cursorA, cursorB, diff, min, max, avg;

                    cursorA = viewGraph.BufferedSeries[row.Key].Points[indexA];
                    cursorB = viewGraph.BufferedSeries[row.Key].Points[indexB];
                    diff = Math.Abs(cursorA - cursorB);

                    CalcMinMaxAvg(viewGraph.BufferedSeries[row.Key].Points, indexA, indexB, out min, out max, out avg);

                    SetCursorValue(i++, cursorA.ToString(format), cursorB.ToString(format), 
                        diff.ToString(format), min.ToString(format), max.ToString(format), avg.ToString(format));
                }

                SetCursorAColumnVisible(true);
                SetCursorBColumnVisible(true);
                SetCursorColumnVisibleIndex();
                RefreshGrid();
            }
            finally
            {
                viewGraph.BufferedSeries.Unlock();
                context.Value.Unlock();
            }
        }

        private void DoZoomStackChanged(object sender, ZoomStackChangedEventArgs e)
        {
            if (this.InvokeRequired == true)
            {
                ZoomStackChangedEventHandler func = new ZoomStackChangedEventHandler(DoZoomStackChanged);
                this.BeginInvoke(func, new object[] { sender, e });
            }
            else
            {
                undoButton.Enabled = (e.Value > 0) ? true : false;
                resetButton.Enabled = (e.Value > 0) ? true : false;
            }
        }

        private void zoomAxisCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (viewGraph.Zooming == null) return;

            viewGraph.Zooming.ZoomAxis = (EZoomAxis)zoomAxisCombo.SelectedIndex;
        }

        private void hideUncheckedCheck_CheckedChanged(object sender, EventArgs e)
        {
            plotSeriesGridView.RefreshData();
            plotSeriesGridView.FocusedRowHandle = 0;
        }

        private void yAxesSettingButton_Click(object sender, EventArgs e)
        {
            bool pauseState = graphPauseLed.Active;
            graphPauseLed.Active = true;

            for (int i = 0; i < viewGraph.AxesY.Count; i++)
            {
                YAxisRows[i].WholeMin = 0;
                YAxisRows[i].WholeMax = 0;
            }

            FormYAxesSetting form = new FormYAxesSetting(YAxisRows, xAxis.Minutes);

            try
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.GetYAxesCheckedCount() == 0)
                    {
                        MessageBox.Show("You must check Y-Axis over one!",
                            Resource.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (form.GetYAxesCheckedCount() > 12)
                    {
                        MessageBox.Show("You must check Y-Axis under 12!",
                            Resource.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    bool resetZoom = false;
                    Cursor = Cursors.WaitCursor;

                    try
                    {
                        xAxis.Minutes = form.Time;
                        InsertXAxis();
                        SetRangeAxisXMinutes(form.Time);

                        foreach (YAxisRow row in form.Axes)
                        {
                            YAxisRows[row.AxisNo].Checked = row.Checked;
                            YAxisRows[row.AxisNo].Align = row.Align;

                            Axis2D axis = viewGraph.AxesY[row.AxisNo];
                            axis.Alignment = (row.Align == EAxisAlign.Left) ? AxisAlignment.Near : AxisAlignment.Far;
                            axis.Visibility = (row.Checked == true) ? DefaultBoolean.True : DefaultBoolean.False;

                            YAxisRows[row.AxisNo].VisualMin = (float)((double)axis.WholeRange.MinValue);
                            YAxisRows[row.AxisNo].VisualMax = (float)((double)axis.WholeRange.MaxValue);
                            YAxisRows[row.AxisNo].WholeMin = (float)((double)axis.WholeRange.MinValue);
                            YAxisRows[row.AxisNo].WholeMax = (float)((double)axis.WholeRange.MaxValue);

                            if ((row.WholeMin != 0) || (row.WholeMax != 0))
                            {
                                if (row.WholeMin < row.WholeMax)
                                {
                                    resetZoom = true;

                                    YAxisRows[row.AxisNo].VisualMin = row.WholeMin;
                                    YAxisRows[row.AxisNo].VisualMax = row.WholeMax;
                                    YAxisRows[row.AxisNo].WholeMin = row.WholeMin;
                                    YAxisRows[row.AxisNo].WholeMax = row.WholeMax;

                                    axis.WholeRange.MinValue = row.WholeMin;
                                    axis.WholeRange.MaxValue = row.WholeMax;
                                    axis.VisualRange.MinValue = row.WholeMin;
                                    axis.VisualRange.MaxValue = row.WholeMax;
                                }
                            }
                        }

                        if (resetZoom == true)
                        {
                            ViewGraph.Zooming.Clear();
                        }

                        viewGraph.InvalidateSeries();
                        InsertYAxes();
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                }
            }
            finally
            {
                graphPauseLed.Active = pauseState;
            }
        }

        private void graphPauseButton_Click(object sender, EventArgs e)
        {
            graphPauseLed.Active = !graphPauseLed.Active;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            if (IsAllSeriesInvisibled() == true)
            {
                MessageBox.Show("You must check plot series over one!",
                    Resource.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Cursor = Cursors.WaitCursor;

            try
            {
                foreach (SeriesRow row in PlotSeriesRows)
                {
                    viewGraph.Series[row.Name].View.Color = row.Color;
                    viewGraph.Series[row.Name].Visible = row.Checked;
                }

                viewGraph.InvalidateSeries();
                InsertSeries();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private bool IsAllSeriesInvisibled()
        {
            foreach (SeriesRow row in PlotSeriesRows)
            {
                if (row.Checked == true) return false;
            }

            return true;
        }


        private void cursorButton_Click(object sender, EventArgs e)
        {
            viewGraph.MarkLine.Visible = !viewGraph.MarkLine.Visible;
        }

        private void autosetButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                viewGraph.Description.Reset();
                viewGraph.VertCursor.Reset();

                viewGraph.Zooming.ZoomAxis = EZoomAxis.AxisY;
                viewGraph.Zooming.AutoSet(0, 2);
                viewGraph.Zooming.ZoomAxis = (EZoomAxis)zoomAxisCombo.SelectedIndex;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void stackButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                viewGraph.Description.Reset();
                viewGraph.VertCursor.Reset();

                viewGraph.Zooming.ZoomAxis = EZoomAxis.AxisY;
                viewGraph.Zooming.Stack();
                viewGraph.Zooming.ZoomAxis = (EZoomAxis)zoomAxisCombo.SelectedIndex;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                viewGraph.Description.Reset();
                viewGraph.VertCursor.Reset();

                viewGraph.Zooming.Out();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                viewGraph.Description.Reset();
                viewGraph.VertCursor.Reset();
                viewGraph.Zooming.Reset();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void plotSeriesGridView_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == null) return;

            if (e.Column.FieldName == "Checked")
            {
                Image image = (seriesChecked == true) ? imageList.Images[1] : imageList.Images[0];

                e.DefaultDraw();
                e.Cache.DrawImage(image,
                    new Rectangle(e.Bounds.X + (e.Bounds.Width - image.Size.Width) / 2,
                    e.Bounds.Y + (e.Bounds.Height - image.Size.Height) / 2 - 1,
                    image.Size.Width, image.Size.Height));

                e.Handled = true;
            }
        }

        private void plotSeriesGridView_CustomRowFilter(object sender, RowFilterEventArgs e)
        {
            ColumnView view = sender as ColumnView;

            if (hideUncheckedCheck.Checked == true)
            {
                e.Visible = (bool)view.GetListSourceRowCellValue(e.ListSourceRow, "Checked");
                e.Handled = true;
            }
        }

        private void plotSeriesGridView_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            GridHitInfo hit = view.CalcHitInfo(e.Location);

            if (hit == null) return;

            switch (hit.HitTest)
            {
                case GridHitTest.Column:
                    if (hit.Column.FieldName == "Checked")
                    {
                        seriesChecked = !seriesChecked;
                        SetSeriesCheckColumn(view);
                    }
                    break;
            }
        }

        private void InitializeYAxes()
        {
            int i = 0;
            string unit = "None";
            YAxisRows = new List<YAxisRow>();

            foreach (EUnitType unitType in Enum.GetValues(typeof(EUnitType)))
            {
                if (unitType == EUnitType.None) continue;
                if (unitType == EUnitType.Time) continue;

                switch (unitType)
                {
                    case EUnitType.Current:
                    case EUnitType.Voltage:
                    case EUnitType.Frequency:
                    case EUnitType.Flux:
                    case EUnitType.Ratio:
                    case EUnitType.HumidityRatio:
                    case EUnitType.Power:
                    case EUnitType.PowerComsumption:
                    case EUnitType.Velocity:
                    case EUnitType.Volume:
                        unit = UnitQuery.GetUnitDescription(unitType);
                        break;

                    case EUnitType.AirFlow:
                        unit = UnitQuery.GetUnitDescription(unitType, (int)Method.AirFlow);
                        break;

                    case EUnitType.Capacity:
                    case EUnitType.EER_COP:
                        unit = UnitQuery.GetUnitDescription(unitType, (int)Method.CoolingCapacity);
                        break;

                    case EUnitType.Enthalpy:
                    case EUnitType.Heat:
                        unit = UnitQuery.GetUnitDescription(unitType, (int)Method.Enthalpy);
                        break;

                    case EUnitType.Temperature:
                        unit = UnitQuery.GetUnitDescription(unitType, (int)Method.Temperature);
                        break;

                    case EUnitType.Pressure:
                        unit = UnitQuery.GetUnitDescription(unitType, (int)Method.Pressure);
                        break;

                    case EUnitType.DiffPressure:
                        unit = UnitQuery.GetUnitDescription(unitType, (int)Method.DiffPressure);
                        break;

                    case EUnitType.AtmPressure:
                        unit = UnitQuery.GetUnitDescription(unitType, (int)Method.AtmPressure);
                        break;
                }

                YAxisRows.Add(new YAxisRow(-1, i++, false, EAxisAlign.Left,
                    unitType.ToString(), unitType.ToDescription(), unit, -100, 100, -100, 100));
            }

            YAxisRows[0].Checked = true;
            YAxisRows[1].Checked = true;
            YAxisRows[2].Checked = true;
        }

        private void LoadXAxis()
        {
            Resource.TestDB[handle].Lock();

            try
            {
                XAxisSettingDataSet set = Resource.TestDB[handle].XAxisSettingSet;

                set.Ip = Resource.Ip;
                set.Mode = 0;
                set.GraphNo = Index;
                set.Select();

                if (set.GetRowCount() > 0)
                {
                    set.Fetch(0);
                    xAxis.RecNo = set.RecNo;
                    xAxis.Minutes = set.Minutes;
                }
            }
            finally
            {
                Resource.TestDB[handle].Unlock();
            }
        }

        private void LoadYAxes()
        {
            Resource.TestDB[handle].Lock();

            try
            {
                YAxisSettingDataSet set = Resource.TestDB[handle].YAxisSettingSet;

                set.Ip = Resource.Ip;
                set.Mode = 0;
                set.GraphNo = Index;
                set.Select();

                if (set.GetRowCount() > 0)
                {
                    if (YAxisRows.Count != set.GetRowCount())
                    {
                        Resource.TLog.Log((int)ELogItem.Error, "Y-Axes count is mismatched in CtrlViewGraphPanel.LoadYAxes");
                    }
                    else
                    {
                        for (int i = 0; i < set.GetRowCount(); i++)
                        {
                            set.Fetch(i);

                            YAxisRows[i].RecNo = set.RecNo;
                            YAxisRows[i].Align = set.Align;
                            YAxisRows[i].Checked = set.Checked;
                            YAxisRows[i].VisualMin = set.VisualMin;
                            YAxisRows[i].VisualMax = set.VisualMax;
                            YAxisRows[i].WholeMin = set.WholeMin;
                            YAxisRows[i].WholeMax = set.WholeMax;
                        }
                    }
                }
            }
            finally
            {
                Resource.TestDB[handle].Unlock();
            }
        }

        private void InitializePlotSeries()
        {
            int color = (int)KnownColor.AliceBlue;
            PlotSeriesRows = new List<SeriesRow>();

            foreach (KeyValuePair<string, ValueRow> row in Resource.Variables.Graph)
            {
                if (row.Value.Unit.Type == EUnitType.Time) continue;

                PlotSeriesRows.Add(new SeriesRow(-1, false, row.Key, row.Value.Format, row.Value.Unit.Type.ToString(),
                    row.Value.Unit.ToDescription, Color.FromKnownColor((KnownColor)color)));

                if ((KnownColor)color == KnownColor.YellowGreen) color = (int)KnownColor.AliceBlue;
                else color++;
            }

            PlotSeriesRows[0].Checked = true;
            PlotSeriesRows[1].Checked = true;
            PlotSeriesRows[2].Checked = true;
        }

        private void LoadPlotSeries()
        {
            Resource.TestDB[handle].Lock();

            try
            {
                SeriesSettingDataSet set = Resource.TestDB[handle].SeriesSettingSet;

                set.Ip = Resource.Ip;
                set.Mode = 0;
                set.GraphNo = Index;
                set.Select();

                if (set.GetRowCount() > 0)
                {
                    if (PlotSeriesRows.Count != set.GetRowCount())
                    {
                        Resource.TLog.Log((int)ELogItem.Error, "Plot series count is mismatched in CtrlViewGraphPanel.LoadPlotSeries");
                    }
                    else
                    {
                        for (int i = 0; i < set.GetRowCount(); i++)
                        {
                            set.Fetch(i);

                            PlotSeriesRows[i].RecNo = set.RecNo;
                            PlotSeriesRows[i].Checked = set.Checked;
                            PlotSeriesRows[i].Color = set.Color;
                        }

                        plotSeriesGridView.RefreshData();
                    }
                }
            }
            finally
            {
                Resource.TestDB[handle].Unlock();
            }
        }

        private void SetSeriesCheckColumn(GridView view)
        {
            if (view.RowCount < 1) return;

            view.BeginUpdate();

            try
            {
                view.Columns["Checked"].ImageOptions.ImageIndex = (seriesChecked == false) ? 0 : 1;

                for (int i = 0; i < view.RowCount; i++)
                {
                    (view.GetRow(i) as SeriesRow).Checked = seriesChecked;
                }
            }
            finally
            {
                view.EndUpdate();
            }
        }

        public void RefreshUnit()
        {
            string unit, capacityUnit;
            string airFlowUnit = UnitQuery.GetUnitDescription(EUnitType.AirFlow, (int)Method.AirFlow);
            string enthalpyUnit = UnitQuery.GetUnitDescription(EUnitType.Enthalpy, (int)Method.Enthalpy);
            string temperatureUnit = UnitQuery.GetUnitDescription(EUnitType.Temperature, (int)Method.Temperature);
            string pressureUnit = UnitQuery.GetUnitDescription(EUnitType.Pressure, (int)Method.Pressure);
            string diffPressureUnit = UnitQuery.GetUnitDescription(EUnitType.DiffPressure, (int)Method.DiffPressure);
            string atmPressureUnit = UnitQuery.GetUnitDescription(EUnitType.AtmPressure, (int)Method.AtmPressure);

            if (context.Condition.Schedules[context.Index].IndoorMode == EIndoorMode.Heating)
                capacityUnit = UnitQuery.GetUnitDescription(EUnitType.Capacity, (int)Method.HeatingCapacity);
            else
                capacityUnit = UnitQuery.GetUnitDescription(EUnitType.Capacity, (int)Method.CoolingCapacity);

            foreach (SeriesRow row in PlotSeriesRows)
            {
                switch (row.UnitType)
                {
                    case "AirFlow":
                        row.UnitFrom = airFlowUnit;
                        break;

                    case "Capacity":
                    case "EER_COP":
                        row.UnitFrom = capacityUnit;
                        break;

                    case "Enthalpy":
                    case "Heat":
                        row.UnitFrom = enthalpyUnit;
                        break;

                    case "Temperature":
                        row.UnitFrom = temperatureUnit;
                        break;

                    case "Pressure":
                        row.UnitFrom = pressureUnit;
                        break;

                    case "DiffPressure":
                        row.UnitFrom = diffPressureUnit;
                        break;

                    case "AtmPressure":
                        row.UnitFrom = atmPressureUnit;
                        break;
                }
            }

            plotSeriesGridView.RefreshData();

            foreach (YAxisRow row in YAxisRows)
            {
                unit = "";

                switch (row.Name)
                {
                    case "AirFlow":
                        unit = atmPressureUnit;
                        break;

                    case "Capacity":
                    case "EER_COP":
                        unit = capacityUnit;
                        break;

                    case "Enthalpy":
                    case "Heat":
                        unit = enthalpyUnit;
                        break;

                    case "Temperature":
                        unit = temperatureUnit;
                        break;

                    case "Pressure":
                        unit = pressureUnit;
                        break;

                    case "DiffPressure":
                        unit = diffPressureUnit;
                        break;

                    case "AtmPressure":
                        unit = atmPressureUnit;
                        break;
                }

                row.Unit = (unit == "") ? row.Unit : unit;
            }

            foreach (YAxisRow row in YAxisRows)
            {
                viewGraph.AxesY[row.AxisNo].Title.Text = row.DescriptionUnit;
            }
        }

        public void RefreshGrid()
        {
            plotSeriesGridView.RefreshData();
        }

        public void InsertXAxis()
        {
            Resource.TestDB[handle].Lock();
            FbTransaction trans = Resource.TestDB[handle].BeginTrans();

            try
            {
                XAxisSettingDataSet xAxisSet = Resource.TestDB[handle].XAxisSettingSet;

                xAxisSet.Ip = Resource.Ip;
                xAxisSet.Mode = 0;
                xAxisSet.GraphNo = Index;
                xAxisSet.Minutes = xAxis.Minutes;

                if (xAxis.RecNo == -1)
                {
                    xAxis.RecNo = (int)Resource.TestDB[handle].GetGenNo("GN_XAXISSETTING");
                    xAxisSet.RecNo = xAxis.RecNo;
                    xAxisSet.Insert(trans);
                }
                else
                {
                    xAxisSet.RecNo = xAxis.RecNo;
                    xAxisSet.Update(trans);
                }

                Resource.TestDB[handle].CommitTrans();
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                Resource.TestDB[handle].RollbackTrans();
            }
            finally
            {
                Resource.TestDB[handle].Unlock();
            }
        }

        public void InsertYAxes()
        {
            Resource.TestDB[handle].Lock();
            FbTransaction trans = Resource.TestDB[handle].BeginTrans();

            try
            {
                YAxisSettingDataSet yAxisSet = Resource.TestDB[handle].YAxisSettingSet;

                for (int i = 0; i < YAxisRows.Count; i++)
                {
                    YAxisRow row = YAxisRows[i];

                    yAxisSet.Ip = Resource.Ip;
                    yAxisSet.Mode = 0;
                    yAxisSet.GraphNo = Index;
                    yAxisSet.Checked = row.Checked;
                    yAxisSet.Align = row.Align;
                    yAxisSet.Name = row.Name;
                    yAxisSet.Desc = row.Description;
                    yAxisSet.Unit = row.Unit;
                    yAxisSet.VisualMin = row.VisualMin;
                    yAxisSet.VisualMax = row.VisualMax;
                    yAxisSet.WholeMin = row.WholeMin;
                    yAxisSet.WholeMax = row.WholeMax;

                    if (row.RecNo == -1)
                    {
                        row.RecNo = (int)Resource.TestDB[handle].GetGenNo("GN_YAXISSETTING");
                        yAxisSet.RecNo = row.RecNo;
                        yAxisSet.Insert(trans);
                    }
                    else
                    {
                        yAxisSet.RecNo = row.RecNo;
                        yAxisSet.Update(trans);
                    }
                }

                Resource.TestDB[handle].CommitTrans();
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                Resource.TestDB[handle].RollbackTrans();
            }
            finally
            {
                Resource.TestDB[handle].Unlock();
            }
        }

        private void InsertSeries()
        {
            Resource.TestDB[handle].Lock();
            FbTransaction trans = Resource.TestDB[handle].BeginTrans();

            try
            {
                SeriesSettingDataSet seriesSet = Resource.TestDB[handle].SeriesSettingSet;

                for (int i = 0; i < PlotSeriesRows.Count; i++)
                {
                    SeriesRow row = PlotSeriesRows[i];

                    seriesSet.Ip = Resource.Ip;
                    seriesSet.Mode = 0;
                    seriesSet.GraphNo = Index;
                    seriesSet.Checked = row.Checked;
                    seriesSet.Color = row.Color;
                    seriesSet.Name = row.Name;
                    seriesSet.UnitType = row.UnitType;

                    if (row.RecNo == -1)
                    {
                        row.RecNo = (int)Resource.TestDB[handle].GetGenNo("GN_SERIESSETTING");
                        seriesSet.RecNo = row.RecNo;
                        seriesSet.Insert(trans);
                    }
                    else
                    {
                        seriesSet.RecNo = row.RecNo;
                        seriesSet.Update(trans);
                    }
                }

                Resource.TestDB[handle].CommitTrans();
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                Resource.TestDB[handle].RollbackTrans();
            }
            finally
            {
                Resource.TestDB[handle].Unlock();
            }
        }

        private void CalcMinMaxAvg(UlBlockList<float> blockList, int from, int to, out float min, out float max, out float avg)
        {
            float value, total = 0;

            min = float.MaxValue;
            max = float.MinValue;

            if (from > to)
            {
                int nTemp = to;
                to = from;
                from = nTemp;
            }

            for (int i = from; i <= to; i++)
            {
                value = blockList[i];
                total += value;

                if (value < min) min = value;
                if (value > max) max = value;
            }

            avg = total / (to - from + 1);
        }


        public void SetSeriesValue(int index, string value)
        {
            PlotSeriesRows[index].Value = value;            
        }

        private void SetCursorValue(int index, string valueA, string valueB, string diff, string min, string max, string avg)
        {
            PlotSeriesRows[index].CursorA = valueA;
            PlotSeriesRows[index].CursorB = valueB;
            PlotSeriesRows[index].Diff = diff;
            PlotSeriesRows[index].Min = min;
            PlotSeriesRows[index].Max = max;
            PlotSeriesRows[index].Avg = avg;
        }

        private void SetCursorAColumnVisible(bool visible)
        {
            psCursorAColumn.Visible = visible;

            if ((psCursorAColumn.Visible == true) && (psCursorBColumn.Visible == true))
                visible = true;
            else
                visible = false;

            psDiffColumn.Visible = visible;
            psMinColumn.Visible = visible;
            psMaxColumn.Visible = visible;
            psAvgColumn.Visible = visible;
        }

        private void SetCursorBColumnVisible(bool visible)
        {
            psCursorBColumn.Visible = visible;

            if ((psCursorAColumn.Visible == true) && (psCursorBColumn.Visible == true))
                visible = true;
            else
                visible = false;

            psDiffColumn.Visible = visible;
            psMinColumn.Visible = visible;
            psMaxColumn.Visible = visible;
            psAvgColumn.Visible = visible;
        }

        private void SetCursorColumnVisibleIndex()
        {
            if ((psCursorAColumn.Visible == true) && (psCursorBColumn.Visible == true))
            {
                psCursorAColumn.VisibleIndex = 4;
                psCursorBColumn.VisibleIndex = 5;
                psDiffColumn.VisibleIndex = 6;
                psMinColumn.VisibleIndex = 7;
                psMaxColumn.VisibleIndex = 8;
                psAvgColumn.VisibleIndex = 9;
                psUnitColumn.VisibleIndex = 10;
                return;
            }

            if (psCursorAColumn.Visible == true)
            {
                psCursorAColumn.VisibleIndex = 4;
                return;
            }

            if (psCursorBColumn.Visible == true)
            {
                psCursorBColumn.VisibleIndex = 4;
                return;
            }
        }

        public void SetRangeAxisXMinutes(int min)
        {
            long ticks = min * 60000;
            Axis2D axis = viewGraph.AxesX[0];

            long curTicks = (long)(viewGraph.BufferedSeries.PointsCount * viewGraph.BaseTime);
            viewGraph.Zooming.SetAllAxisXEnabledInStack(false);

            if (ticks > curTicks)
            {
                axis.WholeRange.MaxValue = ticks;
                axis.WholeRange.MinValue = 0;

                axis.VisualRange.MaxValue = (double)axis.WholeRange.MaxValue;
                axis.VisualRange.MinValue = 0;
            }
            else
            {
                axis.WholeRange.MaxValue = curTicks;
                axis.WholeRange.MinValue = 0;

                axis.VisualRange.MaxValue = curTicks;
                axis.VisualRange.MinValue = curTicks - ticks;
            }
        }

        public void SetRangeAxisXTicks(long ticks)
        {
            if (viewGraph.Zooming.PointEnabled == true) return;

            Axis2D axis = viewGraph.AxesX[0];

            double diff = (double)axis.WholeRange.MaxValue - (double)axis.VisualRange.MaxValue;
            double visualWidth = (double)axis.VisualRange.MaxValue - (double)axis.VisualRange.MinValue;

            if (ticks > (double)axis.WholeRange.MaxValue)
            {
                axis.WholeRange.MaxValue = ticks;
                axis.WholeRange.MinValue = 0;

                axis.VisualRange.MaxValue = (double)axis.WholeRange.MaxValue - diff;
                axis.VisualRange.MinValue = (((double)axis.VisualRange.MaxValue - visualWidth) < 0) ? 0 : ((double)axis.VisualRange.MaxValue - visualWidth);
            }
        }

        public void ResetRangeAxisX()
        {
            Axis2D axis = viewGraph.AxesX[0];

            axis.WholeRange.MaxValue = xAxis.Minutes * 60000;
            axis.WholeRange.MinValue = 0;

            axis.VisualRange.MaxValue = xAxis.Minutes * 60000;
            axis.VisualRange.MinValue = 0;
        }

        public int GetIndexAxisY(string name)
        {
            int axisNo = -1;

            foreach (YAxisRow row in YAxisRows)
            {
                if (row.Name == name)
                {
                    axisNo = row.AxisNo;
                    break;
                }
            }

            return axisNo;
        }
    }

    public class XAxisRow
    {
        public XAxisRow()
        {
            RecNo = -1;
            Minutes = 60;
        }

        public int RecNo { get; set; }
        public int Minutes { get; set; }
    }
}
