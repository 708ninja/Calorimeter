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
    public partial class CtrlViewGraphPanel : UlUserControlEng
    {
        public CtrlViewGraphPanel(int index, ConditionMethod method, UlDoubleBufferedSeriesCollection series)
        {
            InitializeComponent();

            Index = index;
            Method = method;
            Initialize(series);
        }

        public int Index { get; set; }
        public UlDoubleBufferedLineChart ViewGraph { get { return viewGraph; } }
        public ConditionMethod Method { get; set; }
        public List<YAxisRow> YAxisRows { get; private set; }
        public List<SeriesRow> PlotSeriesRows { get; private set; }
        public double MaxRangeAxisX { get; set; }
        public bool InvisibleUnchecked { get; set; }

        private bool seriesChecked { get; set; }

        private void Initialize(UlDoubleBufferedSeriesCollection series)
        {
            zoomAxisCombo.SelectedIndex = 0;

            viewGraph.Series.Clear();
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

            plotSeriesGrid.DataSource = PlotSeriesRows;
            plotSeriesGrid.UseDirectXPaint = DefaultBoolean.False;
            plotSeriesGridView.Columns["Checked"].ImageOptions.ImageIndex = 1;
            plotSeriesGridView.Appearance.EvenRow.BackColor = Color.FromArgb(244, 244, 236);
            plotSeriesGridView.OptionsView.EnableAppearanceEvenRow = true;

            SetCursorAColumnVisible(false);
            SetCursorBColumnVisible(false);

            plotSeriesGridView.RefreshData();
        }

        private void CtrlViewGraphPanel_Enter(object sender, EventArgs e)
        {
        }

        private void CtrlViewGraphPanel_Leave(object sender, EventArgs e)
        {
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
                viewGraph.BufferedSeries.Lock();

                try
                {
                    foreach (KeyValuePair<string, ValueRow> row in Resource.Variables.Graph)
                    {
                        string format = row.Value.Format;
                        float cursorA = viewGraph.BufferedSeries[row.Key].Points[indexA];

                        SetCursorValue(i++, cursorA.ToString(format), "0", "0", "0", "0", "0");
                    }
                }
                finally
                {
                    viewGraph.BufferedSeries.Unlock();
                }

                SetCursorAColumnVisible(true);
                SetCursorBColumnVisible(false);
                SetCursorColumnVisibleIndex();
                RefreshGrid();
                return;
            }


            if (viewGraph.BufferedSeries.PointsCount < indexA + 1)
            {
                viewGraph.BufferedSeries.Lock();

                try
                {
                    foreach (KeyValuePair<string, ValueRow> row in Resource.Variables.Graph)
                    {
                        string format = row.Value.Format;
                        float cursorB = viewGraph.BufferedSeries[row.Key].Points[indexB];

                        SetCursorValue(i++, "0", cursorB.ToString(format), "0", "0", "0", "0");
                    }
                }
                finally
                {
                    viewGraph.BufferedSeries.Unlock();
                }

                SetCursorAColumnVisible(false);
                SetCursorBColumnVisible(true);
                SetCursorColumnVisibleIndex();
                RefreshGrid();
                return;
            }

            viewGraph.BufferedSeries.Lock();

            try
            {
                foreach (KeyValuePair<string, ValueRow> row in Resource.Variables.Graph)
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

        private void yAxesSettingButton_Click(object sender, EventArgs e)
        {
            if (viewGraph.BufferedSeries.PointsCount == 0) return;

            for (int i = 0; i < viewGraph.AxesY.Count; i++)
            {
                YAxisRows[i].WholeMin = 0;
                YAxisRows[i].WholeMax = 0;
            }

            FormYAxesSetting form = new FormYAxesSetting(YAxisRows);

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

                        Axis2D axis = viewGraph.AxesX[0];
                        double wholeMin = (double)axis.WholeRange.MinValue;
                        double wholeMax = (double)axis.WholeRange.MaxValue;
                        double visualMin = (double)axis.VisualRange.MinValue;
                        double visualMax = (double)axis.VisualRange.MaxValue;

                        if ((wholeMin != visualMin) || (wholeMax != visualMax))
                        {
                            EZoomAxis zoomAxis = viewGraph.Zooming.ZoomAxis;
                            SetMaxRangeAxisX(MaxRangeAxisX);

                            viewGraph.Zooming.ZoomAxis = EZoomAxis.Both;
                            viewGraph.Zooming.Push();
                            viewGraph.Zooming.ZoomAxis = zoomAxis;

                            viewGraph.VisualRangeChanging = true;
                            axis.WholeRange.MinValue = wholeMin;
                            axis.WholeRange.MaxValue = wholeMax;
                            axis.VisualRange.MinValue = visualMin;
                            axis.VisualRange.MaxValue = visualMax;
                            viewGraph.VisualRangeChanging = false;
                        }
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

        private void applyButton_Click(object sender, EventArgs e)
        {
            if (viewGraph.BufferedSeries.PointsCount == 0) return;
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

        private void zoomAxisCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (viewGraph.Zooming == null) return;

            viewGraph.Zooming.ZoomAxis = (EZoomAxis)zoomAxisCombo.SelectedIndex;
        }

        private void cursorButton_Click(object sender, EventArgs e)
        {
            viewGraph.MarkLine.Visible = !viewGraph.MarkLine.Visible;
        }

        private void autosetButton_Click(object sender, EventArgs e)
        {
            if (viewGraph.BufferedSeries.PointsCount == 0) return;

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
            if (viewGraph.BufferedSeries.PointsCount == 0) return;

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
            if (viewGraph.BufferedSeries.PointsCount == 0) return;

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
            if (viewGraph.BufferedSeries.PointsCount == 0) return;

            Cursor = Cursors.WaitCursor;

            try
            {
                viewGraph.Description.Reset();
                viewGraph.VertCursor.Reset();
                viewGraph.Zooming.Reset();
                SetMaxRangeAxisX(MaxRangeAxisX);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void hideUncheckedCheck_CheckedChanged(object sender, EventArgs e)
        {
            plotSeriesGridView.RefreshData();
            plotSeriesGridView.FocusedRowHandle = 0;
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

        private void InitializeYAxes()
        {
            int i = 0;
            string unit = "None";
            string airFlowUnit = UnitQuery.GetUnitDescription(EUnitType.AirFlow, (int)Method.AirFlow);
            string capacityUnit = UnitQuery.GetUnitDescription(EUnitType.Capacity, (int)Method.CoolingCapacity);
            string enthalpyUnit = UnitQuery.GetUnitDescription(EUnitType.Enthalpy, (int)Method.Enthalpy);
            string temperatureUnit = UnitQuery.GetUnitDescription(EUnitType.Temperature, (int)Method.Temperature);
            string pressureUnit = UnitQuery.GetUnitDescription(EUnitType.Pressure, (int)Method.Pressure);
            string diffPressureUnit = UnitQuery.GetUnitDescription(EUnitType.DiffPressure, (int)Method.DiffPressure);
            string atmPressureUnit = UnitQuery.GetUnitDescription(EUnitType.AtmPressure, (int)Method.AtmPressure);
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
                        unit = airFlowUnit;
                        break;

                    case EUnitType.Capacity:
                    case EUnitType.EER_COP:
                        unit = capacityUnit;
                        break;

                    case EUnitType.Enthalpy:
                    case EUnitType.Heat:
                        unit = enthalpyUnit;
                        break;

                    case EUnitType.Temperature:
                        unit = temperatureUnit;
                        break;

                    case EUnitType.Pressure:
                        unit = pressureUnit;
                        break;

                    case EUnitType.DiffPressure:
                        unit = diffPressureUnit;
                        break;

                    case EUnitType.AtmPressure:
                        unit = atmPressureUnit;
                        break;
                }

                YAxisRows.Add(new YAxisRow(-1, i++, false, EAxisAlign.Left,
                    unitType.ToString(), unitType.ToDescription(), unit, -100, 100, -100, 100));
            }

            YAxisRows[0].Checked = true;
            YAxisRows[1].Checked = true;
            YAxisRows[2].Checked = true;
        }

        private void LoadYAxes()
        {
            Resource.ViewDB.Lock();

            try
            {
                YAxisSettingDataSet set = Resource.ViewDB.YAxisSettingSet;

                set.Ip = Resource.Ip;
                set.Mode = 1;
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
                Resource.ViewDB.Unlock();
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
            Resource.ViewDB.Lock();

            try
            {
                SeriesSettingDataSet set = Resource.ViewDB.SeriesSettingSet;

                set.Ip = Resource.Ip;
                set.Mode = 1;
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
                Resource.ViewDB.Unlock();
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

        public void SetMaxRangeAxisX(double max)
        {
            MaxRangeAxisX = max;
            Axis2D axis = viewGraph.AxesX[0];

            viewGraph.VisualRangeChanging = true;
            axis.WholeRange.SetMinMaxValues(0, max);
            axis.VisualRange.SetMinMaxValues(0, max);
            viewGraph.VisualRangeChanging = false;
        }

        public void RefreshYAxesUnit()
        {
            string unit;
            string airFlowUnit = UnitQuery.GetUnitDescription(EUnitType.AirFlow, (int)Method.AirFlow);
            string capacityUnit = UnitQuery.GetUnitDescription(EUnitType.Capacity, (int)Method.CoolingCapacity);
            string enthalpyUnit = UnitQuery.GetUnitDescription(EUnitType.Enthalpy, (int)Method.Enthalpy);
            string temperatureUnit = UnitQuery.GetUnitDescription(EUnitType.Temperature, (int)Method.Temperature);
            string pressureUnit = UnitQuery.GetUnitDescription(EUnitType.Pressure, (int)Method.Pressure);
            string diffPressureUnit = UnitQuery.GetUnitDescription(EUnitType.DiffPressure, (int)Method.DiffPressure);
            string atmPressureUnit = UnitQuery.GetUnitDescription(EUnitType.AtmPressure, (int)Method.AtmPressure);

            foreach (YAxisRow row in YAxisRows)
            {
                unit = "";

                switch (row.Name)
                {
                    case "AirFlow":
                        unit = airFlowUnit;
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

        public void SetPlotSeriesUnit(int index, EUnitType type, int unit)
        {
            PlotSeriesRows[index].UnitFrom = 
                UnitQuery.GetUnitDescription(type, unit);
        }

        public void InsertYAxes()
        {
            Resource.ViewDB.Lock();
            FbTransaction trans = Resource.ViewDB.BeginTrans();

            try
            {
                YAxisSettingDataSet yAxisSet = Resource.ViewDB.YAxisSettingSet;

                for (int i = 0; i < YAxisRows.Count; i++)
                {
                    YAxisRow row = YAxisRows[i];

                    yAxisSet.Ip = Resource.Ip;
                    yAxisSet.Mode = 1;
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
                        row.RecNo = (int)Resource.ViewDB.GetGenNo("GN_YAXISSETTING");
                        yAxisSet.RecNo = row.RecNo;
                        yAxisSet.Insert(trans);
                    }
                    else
                    {
                        yAxisSet.RecNo = row.RecNo;
                        yAxisSet.Update(trans);
                    }
                }

                Resource.ViewDB.CommitTrans();
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                Resource.ViewDB.RollbackTrans();
            }
            finally
            {
                Resource.ViewDB.Unlock();
            }
        }

        private void InsertSeries()
        {
            Resource.ViewDB.Lock();
            FbTransaction trans = Resource.ViewDB.BeginTrans();

            try
            {
                SeriesSettingDataSet seriesSet = Resource.ViewDB.SeriesSettingSet;

                for (int i = 0; i < PlotSeriesRows.Count; i++)
                {
                    SeriesRow row = PlotSeriesRows[i];

                    seriesSet.Ip = Resource.Ip;
                    seriesSet.Mode = 1;
                    seriesSet.GraphNo = Index;
                    seriesSet.Checked = row.Checked;
                    seriesSet.Color = row.Color;
                    seriesSet.Name = row.Name;
                    seriesSet.UnitType = row.UnitType;

                    if (row.RecNo == -1)
                    {
                        row.RecNo = (int)Resource.ViewDB.GetGenNo("GN_SERIESSETTING");
                        seriesSet.RecNo = row.RecNo;
                        seriesSet.Insert(trans);
                    }
                    else
                    {
                        seriesSet.RecNo = row.RecNo;
                        seriesSet.Update(trans);
                    }
                }

                Resource.ViewDB.CommitTrans();
            }
            catch (Exception e)
            {
                Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                Resource.ViewDB.RollbackTrans();
            }
            finally
            {
                Resource.ViewDB.Unlock();
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

        public void RefreshGrid()
        {
            plotSeriesGridView.RefreshData();
        }
    }
}
