﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.Spreadsheet;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;

using Ulee.Chart;
using Ulee.Controls;
using Ulee.Device.Connection.Yokogawa;
using Ulee.Utils;

namespace Hnc.Calorimeter.Client
{
    public partial class CtrlTestMeas : UlUserControlEng
    {
        public CtrlTestMeas(TestContext context)
        {
            InitializeComponent();

            this.context = context;
            Initialize();
        }

        private TestContext context;
        private WorksheetTagCollection sheetTags;
        private UlDoubleBufferedSeriesCollection bufferedSeries;

        public CalorimeterTestThread TestThread;

        public IWorkbook Workbook { get { return reportSheet.Document; } }

        public event EventHandler Activated;
        private void OnActivated(object sender, EventArgs args)
        {
            Activated?.Invoke(sender, args);
        }

        private void Initialize()
        {
            InitGrid();
            CreateBufferedSeries();
            CreateGraph();
            reportSheet.LoadDocument(Resource.csExcelOriginReport);
            sheetTags = null;
        }

        private void InitGrid()
        {
            Color evenColor = Color.FromArgb(244, 244, 236);

            totalRatedGrid.DataSource = context.Measure.TotalRateds;
            totalRatedGrid.UseDirectXPaint = DefaultBoolean.False;
            totalRatedGridView.Appearance.EvenRow.BackColor = evenColor;
            totalRatedGridView.OptionsView.EnableAppearanceEvenRow = true;

            runStateGrid.DataSource = context.Measure.RunStates;
            runStateGrid.UseDirectXPaint = DefaultBoolean.False;
            runStateGridView.Appearance.EvenRow.BackColor = evenColor;
            runStateGridView.OptionsView.EnableAppearanceEvenRow = true;

            airSideGrid.DataSource = context.Measure.AirSides;
            airSideGrid.UseDirectXPaint = DefaultBoolean.False;
            airSideGridView.Appearance.EvenRow.BackColor = evenColor;
            airSideGridView.OptionsView.EnableAppearanceEvenRow = true;

            asNozzleGrid.DataSource = context.Measure.Nozzles;
            asNozzleGrid.UseDirectXPaint = DefaultBoolean.False;
            asNozzleGridView.Appearance.EvenRow.BackColor = evenColor;
            asNozzleGridView.OptionsView.EnableAppearanceEvenRow = true;

            outsideGrid.DataSource = context.Measure.Outsides;
            outsideGrid.UseDirectXPaint = DefaultBoolean.False;
            outsideGridView.Appearance.EvenRow.BackColor = evenColor;
            outsideGridView.OptionsView.EnableAppearanceEvenRow = true;

            methodGrid.DataSource = context.Measure.Methods;
            methodGrid.UseDirectXPaint = DefaultBoolean.False;
            methodGridView.Appearance.EvenRow.BackColor = evenColor;
            methodGridView.OptionsView.EnableAppearanceEvenRow = true;

            noteGrid.DataSource = context.Measure.Notes;
            noteGrid.UseDirectXPaint = DefaultBoolean.False;
            noteGridView.Appearance.EvenRow.BackColor = evenColor;
            noteGridView.OptionsView.EnableAppearanceEvenRow = true;

            ratedGrid.DataSource = context.Measure.Rateds;
            ratedGrid.UseDirectXPaint = DefaultBoolean.False;
            ratedGridView.Appearance.EvenRow.BackColor = evenColor;
            ratedGridView.OptionsView.EnableAppearanceEvenRow = true;

            indoor11Grid.DataSource = context.Measure.Indoors11;
            indoor11Grid.UseDirectXPaint = DefaultBoolean.False;
            indoor11GridView.Appearance.EvenRow.BackColor = evenColor;
            indoor11GridView.OptionsView.EnableAppearanceEvenRow = true;

            indoor12Grid.DataSource = context.Measure.Indoors12;
            indoor12Grid.UseDirectXPaint = DefaultBoolean.False;
            indoor12GridView.Appearance.EvenRow.BackColor = evenColor;
            indoor12GridView.OptionsView.EnableAppearanceEvenRow = true;

            indoor21Grid.DataSource = context.Measure.Indoors21;
            indoor21GridView.Appearance.EvenRow.BackColor = evenColor;
            indoor21GridView.OptionsView.EnableAppearanceEvenRow = true;

            indoor22Grid.DataSource = context.Measure.Indoors22;
            indoor22Grid.UseDirectXPaint = DefaultBoolean.False;
            indoor22GridView.Appearance.EvenRow.BackColor = evenColor;
            indoor22GridView.OptionsView.EnableAppearanceEvenRow = true;

            outdoorGrid.DataSource = context.Measure.Outdoors;
            outdoorGrid.UseDirectXPaint = DefaultBoolean.False;
            outdoorGridView.Appearance.EvenRow.BackColor = evenColor;
            outdoorGridView.OptionsView.EnableAppearanceEvenRow = true;

            tc1Grid.DataSource = context.Measure.IndoorTC1;
            tc1Grid.UseDirectXPaint = DefaultBoolean.False;
            tc1GridView.Appearance.EvenRow.BackColor = evenColor;
            tc1GridView.OptionsView.EnableAppearanceEvenRow = true;

            tc2Grid.DataSource = context.Measure.IndoorTC2;
            tc2Grid.UseDirectXPaint = DefaultBoolean.False;
            tc2GridView.Appearance.EvenRow.BackColor = evenColor;
            tc2GridView.OptionsView.EnableAppearanceEvenRow = true;

            tc3Grid.DataSource = context.Measure.OutdoorTC;
            tc3Grid.UseDirectXPaint = DefaultBoolean.False;
            tc3GridView.Appearance.EvenRow.BackColor = evenColor;
            tc3GridView.OptionsView.EnableAppearanceEvenRow = true;

            pressureGrid.DataSource = context.Measure.Pressures;
            pressureGrid.UseDirectXPaint = DefaultBoolean.False;
            pressureGridView.Appearance.EvenRow.BackColor = evenColor;
            pressureGridView.OptionsView.EnableAppearanceEvenRow = true;
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
            CtrlTestGraphPanel ctrl;

            foreach (TabPage page in graphTab.TabPages)
            {
                int index = int.Parse(page.Tag.ToString());

                ctrl = new CtrlTestGraphPanel(index, context, bufferedSeries);

                page.Controls.Add(ctrl);
            }

            graphTab.SelectedIndex = 0;
        }

        public void DisablePauseGraph()
        {
            foreach (TabPage page in graphTab.TabPages)
            {
                CtrlTestGraphPanel ctrl = page.Controls[0] as CtrlTestGraphPanel;
                ctrl.Pause = false;
            }
        }

        private void RefreshGraphUnit()
        {
            foreach (TabPage page in graphTab.TabPages)
            {
                CtrlTestGraphPanel ctrl = page.Controls[0] as CtrlTestGraphPanel;

                ctrl.Method = context.Condition.Method;
                ctrl.RefreshUnit();
            }
        }

        public void ResetGraph()
        {
            bufferedSeries.ClearPoints();

            foreach (TabPage page in graphTab.TabPages)
            {
                CtrlTestGraphPanel ctrl = page.Controls[0] as CtrlTestGraphPanel;

                ctrl.ResetRangeAxisX();
                ctrl.ViewGraph.MarkLine.Visible = false;
            }
        }

        private void CtrlTestMeas_Load(object sender, EventArgs e)
        {
            SplitContainerControl spControl = reportSheet.Controls.OfType<SplitContainerControl>().FirstOrDefault();

            if (spControl != null)
            {
                spControl.SplitterPosition += 380;
            }
        }

        private void CtrlTestMeas_Enter(object sender, EventArgs e)
        {
            OnActivated(this, null);

            if (sheetTags == null)
            {
                sheetTags = new WorksheetTagCollection(reportSheet.Document);
            }

            context.Initialize();

            if (context.TestThread != null)
            {
                context.TestThread.InvalidContext = true;
            }
        }

        private void graphTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            InvalidateGraphSeries(graphTab.SelectedTab);
        }

        private void SetGraphRangeAxisX(long ticks)
        {
            foreach (TabPage page in graphTab.TabPages)
            {
                CtrlTestGraphPanel ctrl = page.Controls[0] as CtrlTestGraphPanel;

                ctrl.SetRangeAxisXTicks(ticks);
            }
        }

        private void InvalidateGraphSeries(TabPage activePage)
        {
            foreach (TabPage page in graphTab.TabPages)
            {
                CtrlTestGraphPanel ctrl = page.Controls[0] as CtrlTestGraphPanel;

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
            }
        }

        public void RefreshGraph()
        {
            bufferedSeries.BaseTime = context.Condition.Method.ScanTime * 1000;
        }

        public void ResetTestTab()
        {
            measTab.SelectedIndex = 0;
            testMeasTab.SelectedIndex = 0;
        }

        public void DoClearGraph(object sender, EventArgs e)
        {
            if (this.InvokeRequired == true)
            {
                EventHandler func = new EventHandler(DoClearGraph);
                this.BeginInvoke(func, new object[] { sender, e });
            }
            else
            {
                ResetGraph();
            }
        }

        public void DoClearSpreadSheet(object sender, EventArgs e)
        {
            if (this.InvokeRequired == true)
            {
                EventHandler func = new EventHandler(DoClearSpreadSheet);
                this.BeginInvoke(func, new object[] { sender, e });
            }
            else
            {
                sheetTags.Clear();
            }
        }

        public void DoSetSpreadSheet(object sender, EventArgs e)
        {
            if (this.InvokeRequired == true)
            {
                EventHandler func = new EventHandler(DoSetSpreadSheet);
                this.BeginInvoke(func, new object[] { sender, e });
            }
            else
            {
                TestSpreadSheetArgs sheet = e as TestSpreadSheetArgs;

                switch (sheet.Index)
                {
                    case EWorkSheet.Current:
                        SetSpreadSheetCurrentValues(sheet);
                        break;

                    case EWorkSheet.Title:
                        SetSpreadSheetTitleItems(sheet);
                        break;

                    default:
                        SetSpreadSheetIntegralValues(sheet);
                        break;
                }
            }
        }

        public void DoDispState(object sender, EventArgs e)
        {
            if (this.InvokeRequired == true)
            {
                EventHandler func = new EventHandler(DoDispState);
                this.BeginInvoke(func, new object[] { sender, e });
            }
            else
            {
                TestDescriptionArgs desc = e as TestDescriptionArgs;
                List<MeasureRow> runStates = context.Measure.RunStates;

                runStates[(int)EMeasRunState.Condition].Value = desc.Name;
                runStates[(int)EMeasRunState.RunningStep].Value = desc.Step.ToString();
                runStates[(int)EMeasRunState.ElapsedTime].Value = ToDateTimeString(desc.ElapsedTime);
                runStates[(int)EMeasRunState.TotalElapsed].Value = ToDateTimeString(desc.TotalElapsedTime);
                runStates[(int)EMeasRunState.Preparation].Value = $"{ToDateTimeString(desc.PrepareCurTime)} / { ToDateTimeString(desc.PrepareMaxTime)}";
                runStates[(int)EMeasRunState.Judgement].Value = $"{ToDateTimeString(desc.JudgeCurTime)} / {ToDateTimeString(desc.JudgeMaxTime)}";
                runStates[(int)EMeasRunState.Integration].Value = $"{ToDateTimeString(desc.IntegCurTime)} / {ToDateTimeString(desc.IntegMaxTime)}";
                runStates[(int)EMeasRunState.NoOfSteady].Value = $"{desc.JudgeCount} / {desc.JudgeMax}";
                runStates[(int)EMeasRunState.Repeat].Value = $"{desc.RepeatCount} / {desc.RepeatMax}";
                runStates[(int)EMeasRunState.Schedule].Value = $"{desc.ScheduleCount} / {desc.ScheduleMax}";

                switch (desc.Step)
                {
                    case ETestStep.None:
                        runStates[(int)EMeasRunState.Preparation].State = EValueState.None;
                        runStates[(int)EMeasRunState.Judgement].State = EValueState.None;
                        runStates[(int)EMeasRunState.Integration].State = EValueState.None;
                        break;

                    case ETestStep.Preparation:
                        runStates[(int)EMeasRunState.Preparation].State = EValueState.Ok;
                        runStates[(int)EMeasRunState.Judgement].State = EValueState.None;
                        runStates[(int)EMeasRunState.Integration].State = EValueState.None;
                        break;

                    case ETestStep.Judgement:
                        runStates[(int)EMeasRunState.Preparation].State = EValueState.None;
                        runStates[(int)EMeasRunState.Judgement].State = EValueState.Ok;
                        runStates[(int)EMeasRunState.Integration].State = EValueState.None;
                        break;

                    case ETestStep.Integration:
                        runStates[(int)EMeasRunState.Preparation].State = EValueState.None;
                        runStates[(int)EMeasRunState.Judgement].State = EValueState.None;
                        runStates[(int)EMeasRunState.Integration].State = EValueState.Ok;
                        break;
                }

                preparationProgress.Properties.Maximum = (int)desc.PrepareMaxTime;
                preparationProgress.Position = (int)desc.PrepareCurTime;
                judgementProgress.Properties.Maximum = (int)desc.JudgeMaxTime;
                judgementProgress.Position = (int)desc.JudgeCurTime;
                integrationProgress.Properties.Maximum = (int)desc.IntegMaxTime;
                integrationProgress.Position = (int)desc.IntegCurTime;
                noOfSteadyProgress.Properties.Maximum = (int)desc.JudgeMax;
                noOfSteadyProgress.Position = (int)desc.JudgeCount;
                repeatProgress.Properties.Maximum = (int)desc.RepeatMax;
                repeatProgress.Position = (int)desc.RepeatCount;
                scheduleProgress.Properties.Maximum = (int)desc.ScheduleMax;
                scheduleProgress.Position = (int)desc.ScheduleCount;
            }
        }

        public void DoInvalidGraph(object sender, long ticks)
        {
            if (this.InvokeRequired == true)
            {
                EventInt64Handler func = new EventInt64Handler(DoInvalidGraph);
                this.BeginInvoke(func, new object[] { sender, ticks });
            }
            else
            {
                int i = 0;
                CtrlTestGraphPanel ctrl = (graphTab.TabPages[graphTab.SelectedIndex] as TabPage).Controls[0] as CtrlTestGraphPanel;

                ctrl.RefreshUnit();

                context.Value.Lock();
                bufferedSeries.Lock();

                try
                {
                    foreach (KeyValuePair<string, ValueRow> row in context.Value.Graph)
                    {
                        ctrl.SetSeriesValue(i++, row.Value.StringValue);
                        bufferedSeries[row.Key].Points.Add(row.Value.Value);
                    }

                    ctrl.RefreshGrid();
                }
                finally
                {
                    bufferedSeries.Unlock();
                    context.Value.Unlock();
                }

                if (ctrl.Pause == false)
                {
                    SetGraphRangeAxisX(ticks);
                    InvalidateGraphSeries(graphTab.SelectedTab);
                }
            }
        }

        private void SetSpreadSheetCurrentValues(TestSpreadSheetArgs sheet)
        {
            reportSheet.BeginUpdate();
            sheet.Report.Lock();

            try
            {
                foreach (KeyValuePair<string, ReportSheet> valueSheet in sheet.Report.ValueSheets)
                {
                    if (valueSheet.Key == "Raw Data") break;
                    if (valueSheet.Value.Use == false) continue;

                    sheetTags.Sheets[valueSheet.Key]["{min-0}"].Value = "Current";

                    bool isAllNaN = true;
                    string cellTag, tag1;
                    foreach (KeyValuePair<string, ReportRow> row in valueSheet.Value.Rows)
                    {
                        cellTag = row.Value.Cells[0].Tag;
                        tag1 = "{" + cellTag.Substring(0, cellTag.Length - 1) + "0}";

                        if (float.IsNaN(row.Value.Cells[0].Raw) == true)
                        {
                            sheetTags.Sheets[valueSheet.Key][tag1].Value = "";
                        }
                        else
                        {
                            if (row.Value.Row == null)
                            {
                                sheetTags.Sheets[valueSheet.Key][tag1].Value = "";
                            }
                            else
                            {
                                if (row.Key.EndsWith("Nozzle") == true)
                                {
                                    sheetTags.Sheets[valueSheet.Key][tag1].Value = GetNozzleState((byte)row.Value.Row.Value);
                                }
                                else
                                {
                                    isAllNaN = false;
                                    sheetTags.Sheets[valueSheet.Key][tag1].NumberFormat = row.Value.Cells[0].Format;
                                    sheetTags.Sheets[valueSheet.Key][tag1].Value = row.Value.Row.Unit.Convert(row.Value.Cells[0].Raw);
                                }
                            }
                        }
                    }

                    if (isAllNaN == true)
                    {
                        sheetTags.Sheets[valueSheet.Key]["{min-0}"].Value = "Average";
                    }
                }
            }
            finally
            {
                sheet.Report.Unlock();
                reportSheet.EndUpdate();
            }
        }

        private void SetSpreadSheetTitleItems(TestSpreadSheetArgs sheet)
        {
            ValueRow row;
            ConditionNote note = sheet.Report.Note;
            ConditionRated rated = sheet.Report.Rated;

            reportSheet.BeginUpdate();
            sheet.Report.Lock();

            try
            {
                foreach (KeyValuePair<string, Dictionary<string, Cell>> tags in sheetTags.Sheets)
                {
                    if (tags.Key == "Raw Data")
                    {
                        sheetTags.SetWorkSheetVisible(tags.Key, false);
                        continue;
                    }

                    bool sheetUse = sheet.Report.ValueSheets[tags.Key].Use;
                    sheetTags.SetWorkSheetVisible(tags.Key, sheetUse);

                    if (sheetUse == false) continue;

                    tags.Value["{300}"].Value = note.Company;
                    tags.Value["{302}"].Value = note.Name;
                    tags.Value["{304}"].Value = note.No;
                    tags.Value["{306}"].Value = note.Observer;
                    tags.Value["{308}"].Value = note.Maker;
                    tags.Value["{310}"].Value = note.Model1;
                    tags.Value["{312}"].Value = note.Serial1;
                    tags.Value["{314}"].Value = note.Model2;
                    tags.Value["{316}"].Value = note.Serial2;

                    string str = note.Model3 + " / " + note.Serial3;

                    if (str.Trim() == "/")
                        tags.Value["{318}"].Value = "";
                    else
                        tags.Value["{318}"].Value = str;

                    tags.Value["{320}"].Value = $"{sheet.Report.ValueSheets[tags.Key].IndoorDB:f2} / {sheet.Report.ValueSheets[tags.Key].IndoorWB:f2} ℃";

                    if (sheet.Report.ValueSheets[tags.Key].IndoorUse == EIndoorUse.NotUsed)
                        tags.Value["{322}"].Value = sheet.Report.ValueSheets[tags.Key].IndoorUse.ToDescription();
                    else
                        tags.Value["{322}"].Value = $"{sheet.Report.ValueSheets[tags.Key].IndoorUse.ToDescription()}, {sheet.Report.ValueSheets[tags.Key].IndoorMode.ToDescription()}";

                    row = context.Value.Calcurated["Total.Capacity"];
                    tags.Value["{301}"].Value = $"{rated.Capacity.ToString(row.Format)} {row.Unit.ToDescription}";
                    row = context.Value.Calcurated["Total.Power"];
                    tags.Value["{303}"].Value = $"{rated.PowerInput.ToString(row.Format)} {row.Unit.ToDescription}";
                    row = context.Value.Calcurated["Total.EER_COP"];
                    tags.Value["{305}"].Value = $"{rated.EER_COP.ToString(row.Format)} {row.Unit.ToDescription}";
                    tags.Value["{307}"].Value = $"{rated.Voltage}V / {rated.Current}A / {rated.Frequency}Hz / {EnumHelper.GetNames<EWT330Wiring>()[(int)rated.Wiring]}";
                    tags.Value["{309}"].Value = note.ExpDevice;
                    tags.Value["{311}"].Value = note.Refrigerant;
                    tags.Value["{313}"].Value = note.RefCharge;
                    tags.Value["{315}"].Value = sheet.Report.RegTime.ToString(Resource.csDateTimeFormat);
                    tags.Value["{321}"].Value = $"{sheet.Report.ValueSheets[tags.Key].OutdoorDB:f2} / {sheet.Report.ValueSheets[tags.Key].OutdoorWB:f2} ℃"; ;

                    if (sheet.Report.ValueSheets[tags.Key].OutdoorDP == EEtcUse.Use)
                        tags.Value["{323}"].Value = $"{sheet.Report.ValueSheets[tags.Key].OutdoorUse.ToDescription()}, DP Used";
                    else
                        tags.Value["{323}"].Value = $"{sheet.Report.ValueSheets[tags.Key].OutdoorUse.ToDescription()}";

                    tags.Value["{299}"].Value = note.Memo;

                    if (tags.Key.EndsWith("TC") == false)
                    {
                        tags.Value["{365}"].Value = " " + sheet.Report.ValueSheets[tags.Key].NozzleName;
                    }

                    string cellTag;

                    for (int i = 0; i < 7; i++)
                    {
                        cellTag = "{" + $"min-{i + 1}" + "}";
                        tags.Value[cellTag].Value = (i < sheet.Report.Method.IntegralCount) ? $"{(i + 1) * sheet.Report.Method.IntegralTime} min" : "";
                    }

                    foreach (KeyValuePair<string, ReportRow> sheetRow in sheet.Report.ValueSheets[tags.Key].Rows)
                    {
                        cellTag = "{" + sheetRow.Value.Tag + "}";

                        if (sheetRow.Key.EndsWith("Nozzle") == false)
                        {
                            if (sheetRow.Value.Row == null)
                            {
                                tags.Value[cellTag].Value = "";
                            }
                            else
                            {
                                tags.Value[cellTag].Value = sheetRow.Value.Row.Unit.ToDescription;
                            }
                        }

                        if (tags.Key.EndsWith("TC") == true)
                        {
                            if (sheetRow.Value.Row == null)
                            {
                                tags.Value[cellTag].Value = "";
                            }
                            else
                            {
                                cellTag = "{" + sheetRow.Value.Tag + "-N}";
                                tags.Value[cellTag].Value = sheetRow.Value.Alias;
                            }
                        }
                    }
                }
            }
            finally
            {
                sheet.Report.Unlock();
                reportSheet.EndUpdate();
            }
        }

        private void SetSpreadSheetIntegralValues(TestSpreadSheetArgs sheet)
        {
            int index = (int)sheet.Index - 1;

            reportSheet.BeginUpdate();
            sheet.Report.Lock();

            try
            {
                foreach (KeyValuePair<string, ReportSheet> valueSheet in sheet.Report.ValueSheets)
                {
                    if (valueSheet.Key == "Raw Data") break;
                    if (valueSheet.Value.Use == false) continue;

                    sheetTags.Sheets[valueSheet.Key]["{min-0}"].Value = "Average";

                    string cellTag, tag1, tag2, state = "";
                    foreach (KeyValuePair<string, ReportRow> row in valueSheet.Value.Rows)
                    {
                        cellTag = row.Value.Cells[index].Tag;
                        tag2 = "{" + cellTag + "}";

                        if (float.IsNaN(row.Value.Cells[index].Raw) == true)
                        {
                            sheetTags.Sheets[valueSheet.Key][tag2].Value = "";
                        }
                        else
                        {
                            if (row.Value.Row == null)
                            {
                                sheetTags.Sheets[valueSheet.Key][tag2].Value = "";
                            }
                            else
                            {
                                if (row.Key.EndsWith("Nozzle") == true)
                                {
                                    state = GetNozzleState((byte)row.Value.Row.Value);
                                    sheetTags.Sheets[valueSheet.Key][tag2].Value = state;
                                }
                                else
                                {
                                    sheetTags.Sheets[valueSheet.Key][tag2].NumberFormat = row.Value.Cells[index].Format;
                                    sheetTags.Sheets[valueSheet.Key][tag2].Value = row.Value.Row.Unit.Convert(row.Value.Cells[index].Raw);
                                }
                            }
                        }

                        if (sheet.SettingAverage == true)
                        {
                            tag1 = "{" + cellTag.Substring(0, cellTag.Length - 1) + "0}";

                            if (float.IsNaN(row.Value.Average) == true)
                            {
                                sheetTags.Sheets[valueSheet.Key][tag1].Value = "";
                            }
                            else
                            {
                                if (row.Value.Row == null)
                                {
                                    sheetTags.Sheets[valueSheet.Key][tag1].Value = "";
                                }
                                else
                                {
                                    if (row.Key.EndsWith("Nozzle") == true)
                                    {
                                        sheetTags.Sheets[valueSheet.Key][tag1].Value = state;
                                    }
                                    else
                                    {
                                        if (string.IsNullOrWhiteSpace(row.Value.Cells[0].Format) == false)
                                        {
                                            sheetTags.Sheets[valueSheet.Key][tag1].NumberFormat = row.Value.Cells[0].Format;
                                        }

                                        sheetTags.Sheets[valueSheet.Key][tag1].Value = row.Value.Row.Unit.Convert(row.Value.Average);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                sheet.Report.Unlock();
                reportSheet.EndUpdate();
            }
        }

        private string GetNozzleState(byte nozzleValue)
        {
            string state = "";

            for (int i = 0; i < 4; i++)
            {
                state += (UlBits.Get(nozzleValue, i) == true) ? "O," : "X,";
            }

            return state.Substring(0, 7);
        }

        private string ToDateTimeString(long msec)
        {
            int day = (int)(msec / 86400000);
            int hour = (int)((msec % 86400000) / 3600000);
            int min = (int)((msec % 86400000 % 3600000) / 60000);
            int sec = (int)((msec % 86400000 % 3600000 % 60000) / 1000);

            return $"{day:d2}:{hour:d2}:{min:d2}:{sec:d2}";
        }

        public override void InvalidControl(object sender, EventArgs e)
        {
            if (this.InvokeRequired == true)
            {
                EventHandler func = new EventHandler(InvalidControl);
                this.BeginInvoke(func, new object[] { sender, e });
            }
            else
            {
                totalRatedGridView.RefreshData();
                runStateGridView.RefreshData();
                airSideGridView.RefreshData();
                asNozzleGridView.RefreshData();
                outsideGridView.RefreshData();
                methodGridView.RefreshData();
                noteGridView.RefreshData();
                ratedGridView.RefreshData();
                indoor11GridView.RefreshData();
                indoor12GridView.RefreshData();
                indoor21GridView.RefreshData();
                indoor22GridView.RefreshData();
                outdoorGridView.RefreshData();
                tc1GridView.RefreshData();
                tc2GridView.RefreshData();
                tc3GridView.RefreshData();
                pressureGridView.RefreshData();
            }
        }

        private void totalRatedGridView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.DisplayText == "") return;
            if (e.Column == null) return;

            Color[] fgColors = { Color.Black, Color.Yellow, Color.White };
            Color[] bgColors = { SystemColors.Control, Color.LimeGreen, Color.DeepPink };

            bgColors[0] = (e.RowHandle % 2 == 1) ? totalRatedGridView.Appearance.EvenRow.BackColor : Color.White;

            int state = 0;

            switch (e.Column.FieldName)
            {
                case "Name":
                case "Unit":
                    state = 0;
                    break;

                case "Value":
                    state = (int)context.Measure.TotalRateds[e.RowHandle].State;
                    break;

            }

            e.Appearance.ForeColor = fgColors[state];
            e.Appearance.BackColor = bgColors[state];
        }

        private void runStateGridView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.DisplayText == "") return;
            if (e.Column == null) return;

            Color[] fgColors = { Color.Black, Color.Yellow, Color.White };
            Color[] bgColors = { SystemColors.Control, Color.LimeGreen, Color.DeepPink };

            bgColors[0] = (e.RowHandle % 2 == 1) ? runStateGridView.Appearance.EvenRow.BackColor : Color.White;

            int state = 0;

            switch (e.Column.FieldName)
            {
                case "Name":
                    state = 0;
                    break;

                case "Value":
                    state = (int)context.Measure.RunStates[e.RowHandle].State;
                    break;

            }

            e.Appearance.ForeColor = fgColors[state];
            e.Appearance.BackColor = bgColors[state];
        }

        private void outsideGridView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.DisplayText == "") return;
            if (e.Column == null) return;

            Color[] fgColors = { Color.Black, Color.Yellow, Color.White };
            Color[] bgColors = { SystemColors.Control, Color.LimeGreen, Color.DeepPink };

            bgColors[0] = (e.RowHandle % 2 == 1) ? outsideGridView.Appearance.EvenRow.BackColor : Color.White;

            int state = 0;

            switch (e.Column.FieldName)
            {
                case "Name":
                case "Unit":
                    state = 0;
                    break;

                case "Value":
                    state = (int)context.Measure.Outsides[e.RowHandle].State;
                    break;

            }

            e.Appearance.ForeColor = fgColors[state];
            e.Appearance.BackColor = bgColors[state];
        }

        private void airSideGridView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.DisplayText == "") return;
            if (e.Column == null) return;

            Color[] fgColors = { Color.Black, Color.Yellow, Color.White };
            Color[] bgColors = { SystemColors.Control, Color.LimeGreen, Color.DeepPink };

            bgColors[0] = (e.RowHandle % 2 == 1) ? airSideGridView.Appearance.EvenRow.BackColor : Color.White;

            int state = 0;

            switch (e.Column.FieldName)
            {
                case "Name":
                case "Unit":
                    state = 0;
                    break;

                case "Indoor11":
                    state = (int)context.Measure.AirSides[e.RowHandle].Indoor11State;
                    break;

                case "Indoor12":
                    state = (int)context.Measure.AirSides[e.RowHandle].Indoor12State;
                    break;

                case "Indoor21":
                    state = (int)context.Measure.AirSides[e.RowHandle].Indoor21State;
                    break;

                case "Indoor22":
                    state = (int)context.Measure.AirSides[e.RowHandle].Indoor22State;
                    break;
            }

            e.Appearance.ForeColor = fgColors[state];
            e.Appearance.BackColor = bgColors[state];
        }
    }
}
