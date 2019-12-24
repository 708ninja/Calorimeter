using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.Spreadsheet;
using DevExpress.XtraSpreadsheet;

using Ulee.Chart;
using Ulee.Controls;
using Ulee.DllImport.Win32;

namespace Hnc.Calorimeter.Client
{
    public partial class CtrlViewGraph : UlUserControlEng
    {
        public CtrlViewGraph(int handle)
        {
            InitializeComponent();

            this.handle = handle;
            Initialize();
        }

        private int handle;
        private Int64 recNo;
        private string fName;
        private int scanTime;
        private ConditionMethod method;
        private CalorimeterViewDatabase db;
        private UlDoubleBufferedSeriesCollection bufferedSeries;

        private void Initialize()
        {
            recNo = -1;
            db = Resource.ViewDB;
            method = new ConditionMethod();

            CreateBufferedSeries();
            CreateGraph();
        }

        private void CtrlViewGraph_Enter(object sender, EventArgs e)
        {
            InvalidateGraphSeries(graphTab.SelectedTab);
        }

        private void graphTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            InvalidateGraphSeries(graphTab.SelectedTab);
        }

        private void InvalidateGraphSeries(TabPage activePage)
        {
            foreach (TabPage page in graphTab.TabPages)
            {
                CtrlViewGraphPanel ctrl = page.Controls[0] as CtrlViewGraphPanel;

                if (page == activePage)
                {
                    ctrl.ViewGraph.InvalidateSeries();
                }
                else
                {
                    ctrl.ViewGraph.Series.BeginUpdate();
                    try
                    {
                        ctrl.ViewGraph.ClearSeriesPoint();
                    }
                    finally
                    {
                        ctrl.ViewGraph.Series.EndUpdate();
                    }
                }

                ctrl.ViewGraph.RefreshData();
            }
        }

        private void CreateBufferedSeries()
        {
            int color = (int)KnownColor.AliceBlue;

            bufferedSeries = new UlDoubleBufferedSeriesCollection();

            foreach (KeyValuePair<string, ValueRow> row in Resource.Variables.Graph)
            {
                if (row.Value.Unit.Type == EUnitType.Time) continue;

                bufferedSeries.Add(new UlDoubleBufferedSeries(row.Value.Name, Color.FromKnownColor((KnownColor)color)));

                if ((KnownColor)color == KnownColor.YellowGreen) color = (int)KnownColor.AliceBlue;
                else color++;
            }
        }

        private void CreateGraph()
        {
            CtrlViewGraphPanel ctrl;

            foreach (TabPage page in graphTab.TabPages)
            {
                int index = int.Parse(page.Tag.ToString());

                ctrl = new CtrlViewGraphPanel(index, method, bufferedSeries);

                page.Controls.Add(ctrl);
            }

            graphTab.SelectedIndex = 0;
        }

        public void Open(Int64 recNo)
        {
            db.Lock();

            try
            {
                this.recNo = recNo;
                bufferedSeries.ClearPoints();

                double totalTime = 0;
                DataBookDataSet bookSet = db.DataBookSet;
                DataRawUnitDataSet rawUnitSet = db.DataRawUnitSet;
                DataRawDataSet rawSet = db.DataRawSet;
                UnitConvert unit = new UnitConvert(EUnitType.None, 0, 0);

                bookSet.Select(recNo);

                if (bookSet.IsEmpty() == false)
                {
                    bookSet.Fetch();

                    scanTime = bookSet.ScanTime;
                    bufferedSeries.BaseTime = scanTime * 1000;

                    if (string.IsNullOrWhiteSpace(bookSet.TestName) == true)
                        fName = $"None_Line{bookSet.TestLine + 1}";
                    else
                        fName = $"{bookSet.TestName}_Line{bookSet.TestLine + 1}";

                    rawUnitSet.Select(bookSet.RecNo);

                    try
                    {
                        for (int i = 0; i < rawUnitSet.GetRowCount(); i++)
                        {
                            rawUnitSet.Fetch(i);

                            unit.Type = (EUnitType)rawUnitSet.UnitType;
                            unit.From = rawUnitSet.UnitFrom;
                            unit.To = rawUnitSet.UnitTo;

                            SetMethodUnit((EUnitType)rawUnitSet.UnitType, rawUnitSet.UnitTo);
                            SetPlotSeriesUnit(i, (EUnitType)rawUnitSet.UnitType, rawUnitSet.UnitTo);

                            rawSet.Select(rawUnitSet.RecNo);
                            for (int j = 0; j < rawSet.GetRowCount(); j++)
                            {
                                rawSet.Fetch(j);
                                if (rawSet.DataRaw == null) break;

                                if (i == 0)
                                {
                                    totalTime += (rawSet.DataRaw.Length - 1) * bufferedSeries.BaseTime;
                                }

                                ConvertUnit(unit, rawSet.DataRaw);
                                bufferedSeries[i].Points.AddRange(rawSet.DataRaw);
                            }

                            Win32.SwitchToThread();
                        }
                    }
                    finally
                    {
                        foreach (TabPage page in graphTab.TabPages)
                        {
                            CtrlViewGraphPanel ctrl = page.Controls[0] as CtrlViewGraphPanel;

                            ctrl.Method = method;
                            ctrl.RefreshYAxesUnit();
                            ctrl.SetMaxRangeAxisX(totalTime);
                        }

                        InvalidateGraphSeries(graphTab.SelectedTab);
                    }
                }
            }
            finally
            {
                db.Unlock();
            }
        }

        private void ConvertUnit(UnitConvert unit, float[] values)
        {
            for (int i=0; i<values.Length; i++)
            {
                values[i] = (float)unit.Convert(values[i]);
            }
        }

        public void SaveExcel()
        {
            SpreadsheetControl spread = new SpreadsheetControl();
            Worksheet sheet = spread.Document.Worksheets[0]; ;
            string excelName = Resource.Settings.Options.ExcelPath + "\\" 
                + fName + "_Raw_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

            FormSaveDataRaw form = new FormSaveDataRaw();
            form.SavingProgress.Properties.Maximum = bufferedSeries.PointsCount;
            form.SavingProgress.Position = 0;
            form.Show();

            spread.BeginUpdate();

            try
            {
                for (int i = 0; i < bufferedSeries.Count; i++)
                {
                    sheet[0, i].Value = bufferedSeries[i].Name;
                }

                for (int i = 0; i < bufferedSeries.PointsCount; i++)
                {
                    for (int j = 0; j < bufferedSeries.Count; j++)
                    {
                        sheet[i + 1, j].Value = bufferedSeries[j].Points[i];

                        if (form.Cancel == true) break;

                        Application.DoEvents();
                        Win32.SwitchToThread();
                    }

                    form.SavingProgress.Position = i + 1;
                }
            }
            finally
            {
                spread.EndUpdate();
                spread.SaveDocument(excelName);
                form.Hide();
            }
        }

        private void SetMethodUnit(EUnitType unitType, int unitTo)
        {
            switch (unitType)
            {
                case EUnitType.AirFlow:
                    method.AirFlow = (EUnitAirFlow)unitTo;
                    break;

                case EUnitType.Capacity:
                case EUnitType.EER_COP:
                    method.CoolingCapacity = (EUnitCapacity)unitTo;
                    break;

                case EUnitType.Enthalpy:
                case EUnitType.Heat:
                    method.Enthalpy = (EUnitEnthalpy)unitTo;
                    break;

                case EUnitType.Temperature:
                    method.Temperature = (EUnitTemperature)unitTo;
                    break;

                case EUnitType.Pressure:
                    method.Pressure = (EUnitPressure)unitTo;
                    break;

                case EUnitType.DiffPressure:
                    method.DiffPressure = (EUnitDiffPressure)unitTo;
                    break;

                case EUnitType.AtmPressure:
                    method.AtmPressure = (EUnitAtmPressure)unitTo;
                    break;
            }
        }

        private void SetPlotSeriesUnit(int index, EUnitType unitType, int unitTo)
        {
            foreach (TabPage page in graphTab.TabPages)
            {
                (page.Controls[0] as CtrlViewGraphPanel)
                    .SetPlotSeriesUnit(index, unitType, unitTo);
            }
        }
    }
}
