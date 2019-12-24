﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

using Ulee.Controls;
using Ulee.Utils;

namespace Hnc.Calorimeter.Client
{
    public partial class FormOpenSchedule : UlFormEng
    {
        public FormOpenSchedule(ConditionSchedule sch)
        {
            InitializeComponent();

            defSch = sch;
            Initialize();
        }

        private GridBookmark bookmark;

        private List<TextEdit> viewEdits;
        private List<TextEdit> id1Edits;
        private List<TextEdit> id2Edits;
        private List<TextEdit> odEdits;
        private List<AdvBandedGridView> viewGrids;
        private List<ChamberParams> chamberParams;

        private ConditionSchedule defSch;

        public GridView ScheduleGridView { get { return scheduleGridView; } }
        public List<ChamberParams> Chambers { get { return chamberParams; } }

        private void Initialize()
        {
            bookmark = new GridBookmark(scheduleGridView);

            viewEdits = new List<TextEdit>();
            viewEdits.Add(standardEdit);
            viewEdits.Add(nameEdit);
            viewEdits.Add(noSteadyEdit);
            viewEdits.Add(preparationEdit);
            viewEdits.Add(judgementEdit);
            viewEdits.Add(repeatEdit);

            id1Edits = new List<TextEdit>();
            id1Edits.Add(id1EdbSetupEdit);
            id1Edits.Add(id1EdbAvgEdit);
            id1Edits.Add(id1EdbDevEdit);
            id1Edits.Add(id1EwbSetupEdit);
            id1Edits.Add(id1EwbAvgEdit);
            id1Edits.Add(id1EwbDevEdit);
            id1Edits.Add(id1Ldb1DevEdit);
            id1Edits.Add(id1Lwb1DevEdit);
            id1Edits.Add(id1Airflow1DevEdit);
            id1Edits.Add(id1Ldb2DevEdit);
            id1Edits.Add(id1Lwb2DevEdit);
            id1Edits.Add(id1Airflow2DevEdit);
            id1Edits.Add(id1Cdp1SetupEdit);
            id1Edits.Add(id1Cdp1AvgEdit);
            id1Edits.Add(id1Cdp1DevEdit);
            id1Edits.Add(id1Cdp2SetupEdit);
            id1Edits.Add(id1Cdp2AvgEdit);
            id1Edits.Add(id1Cdp2DevEdit);

            id2Edits = new List<TextEdit>();
            id2Edits.Add(id2EdbSetupEdit);
            id2Edits.Add(id2EdbAvgEdit);
            id2Edits.Add(id2EdbDevEdit);
            id2Edits.Add(id2EwbSetupEdit);
            id2Edits.Add(id2EwbAvgEdit);
            id2Edits.Add(id2EwbDevEdit);
            id2Edits.Add(id2Ldb1DevEdit);
            id2Edits.Add(id2Lwb1DevEdit);
            id2Edits.Add(id2Airflow1DevEdit);
            id2Edits.Add(id2Ldb2DevEdit);
            id2Edits.Add(id2Lwb2DevEdit);
            id2Edits.Add(id2Airflow2DevEdit);
            id2Edits.Add(id2Cdp1SetupEdit);
            id2Edits.Add(id2Cdp1AvgEdit);
            id2Edits.Add(id2Cdp1DevEdit);
            id2Edits.Add(id2Cdp2SetupEdit);
            id2Edits.Add(id2Cdp2AvgEdit);
            id2Edits.Add(id2Cdp2DevEdit);

            odEdits = new List<TextEdit>();
            odEdits.Add(odEdbSetupEdit);
            odEdits.Add(odEdbAvgEdit);
            odEdits.Add(odEdbDevEdit);
            odEdits.Add(odEwbSetupEdit);
            odEdits.Add(odEwbAvgEdit);
            odEdits.Add(odEwbDevEdit);
            odEdits.Add(odEdpSetupEdit);
            odEdits.Add(odEdpAvgEdit);
            odEdits.Add(odEdpDevEdit);
            odEdits.Add(odVolt1SetupEdit);
            odEdits.Add(odVolt1AvgEdit);
            odEdits.Add(odVolt1DevEdit);
            odEdits.Add(odVolt2SetupEdit);
            odEdits.Add(odVolt2AvgEdit);
            odEdits.Add(odVolt2DevEdit);

            viewGrids = new List<AdvBandedGridView>();
            viewGrids.Add(indoor1GridView);
            viewGrids.Add(indoor2GridView);
            viewGrids.Add(outdoorGridView);

            chamberParams = new List<ChamberParams>();
            chamberParams.Add(new ChamberParams());

            indoor1Grid.DataSource = chamberParams;
            indoor2Grid.DataSource = chamberParams;
            outdoorGrid.DataSource = chamberParams;

            NameValue<EIndoorUse>[] inUseItems = EnumHelper.GetNameValues<EIndoorUse>();
            indoor1UseLookUp.DataSource = inUseItems;
            indoor1UseLookUp.DisplayMember = "Name";
            indoor1UseLookUp.ValueMember = "Value";
            indoor1UseLookUp.KeyMember = "Value";
            indoor2UseLookUp.DataSource = inUseItems;
            indoor2UseLookUp.DisplayMember = "Name";
            indoor2UseLookUp.ValueMember = "Value";
            indoor2UseLookUp.KeyMember = "Value";

            NameValue<EIndoorMode>[] modeItems = EnumHelper.GetNameValues<EIndoorMode>();
            indoor1ModeLookUp.DataSource = modeItems;
            indoor1ModeLookUp.DisplayMember = "Name";
            indoor1ModeLookUp.ValueMember = "Value";
            indoor1ModeLookUp.KeyMember = "Value";
            indoor2ModeLookUp.DataSource = modeItems;
            indoor2ModeLookUp.DisplayMember = "Name";
            indoor2ModeLookUp.ValueMember = "Value";
            indoor2ModeLookUp.KeyMember = "Value";

            NameValue<EIndoorDuct>[] ductItems = EnumHelper.GetNameValues<EIndoorDuct>();
            indoor1DuctLookUp.DataSource = ductItems;
            indoor1DuctLookUp.DisplayMember = "Name";
            indoor1DuctLookUp.ValueMember = "Value";
            indoor1DuctLookUp.KeyMember = "Value";
            indoor2DuctLookUp.DataSource = ductItems;
            indoor2DuctLookUp.DisplayMember = "Name";
            indoor2DuctLookUp.ValueMember = "Value";
            indoor2DuctLookUp.KeyMember = "Value";

            NameValue<EOutdoorUse>[] outUseItems = EnumHelper.GetNameValues<EOutdoorUse>();
            outdoorUseLookUp.DataSource = outUseItems;
            outdoorUseLookUp.DisplayMember = "Name";
            outdoorUseLookUp.ValueMember = "Value";
            outdoorUseLookUp.KeyMember = "Value";

            NameValue<EEtcUse>[] etcUseItems = EnumHelper.GetNameValues<EEtcUse>();
            outdoorEtcUseLookUp.DataSource = etcUseItems;
            outdoorEtcUseLookUp.DisplayMember = "Name";
            outdoorEtcUseLookUp.ValueMember = "Value";
            outdoorEtcUseLookUp.KeyMember = "Value";

            string format;
            string devFormat;

            foreach (TextEdit edit in id1Edits)
            {
                switch (int.Parse(((string)edit.Tag).ToString()))
                {
                    // Temperature Edit
                    case 0:
                        format = Resource.Variables.Measured["ID11.Entering.DB"].Format;
                        devFormat = ToDevFormat(format);
                        break;

                    // Air Flow Edit
                    case 1:
                        format = Resource.Variables.Calcurated["ID11.Air.Flow.Lev"].Format;
                        devFormat = ToDevFormat(format);
                        break;

                    // Diff. Pressure Edit
                    case 2:
                        format = Resource.Variables.Measured["ID11.Nozzle.Diff.Pressure"].Format;
                        devFormat = ToDevFormat(format);
                        break;

                    default:
                        format = "0.0";
                        devFormat = "f1";
                        break;
                }

                edit.Text = format;
                edit.Properties.Mask.EditMask = devFormat;
                edit.Properties.DisplayFormat.FormatString = devFormat;
                edit.Properties.EditFormat.FormatString = devFormat;
            }

            foreach (TextEdit edit in id2Edits)
            {
                switch (int.Parse(((string)edit.Tag).ToString()))
                {
                    // Temperature Edit
                    case 0:
                        format = Resource.Variables.Measured["ID21.Entering.DB"].Format;
                        devFormat = ToDevFormat(format);
                        break;

                    // Air Flow Edit
                    case 1:
                        format = Resource.Variables.Calcurated["ID21.Air.Flow.Lev"].Format;
                        devFormat = ToDevFormat(format);
                        break;

                    // Diff. Pressure Edit
                    case 2:
                        format = Resource.Variables.Measured["ID21.Nozzle.Diff.Pressure"].Format;
                        devFormat = ToDevFormat(format);
                        break;

                    default:
                        format = "0.0";
                        devFormat = "f1";
                        break;
                }

                edit.Text = format;
                edit.Properties.Mask.EditMask = devFormat;
                edit.Properties.DisplayFormat.FormatString = devFormat;
                edit.Properties.EditFormat.FormatString = devFormat;
            }

            foreach (TextEdit edit in odEdits)
            {
                switch (int.Parse(((string)edit.Tag).ToString()))
                {
                    // Temperature Edit
                    case 0:
                        format = Resource.Variables.Measured["OD.Entering.DB"].Format;
                        devFormat = ToDevFormat(format);
                        break;

                    // Air Flow Edit
                    case 1:
                        format = Resource.Variables.Measured["PM1.R.V"].Format;
                        devFormat = ToDevFormat(format);
                        break;

                    default:
                        format = "0.0";
                        devFormat = "f1";
                        break;
                }

                edit.Text = format;
                edit.Properties.Mask.EditMask = devFormat;
                edit.Properties.DisplayFormat.FormatString = devFormat;
                edit.Properties.EditFormat.FormatString = devFormat;
            }

            scheduleGridView.Appearance.EvenRow.BackColor = Color.FromArgb(244, 244, 236);
            scheduleGridView.OptionsView.EnableAppearanceEvenRow = true;

            SetEditReadOnly(false);
        }

        private void FormOpenSchedule_Load(object sender, EventArgs e)
        {
            Resource.ConfigDB.Lock();
            try
            {
                Resource.ConfigDB.ScheduleParamSet.Select();
                scheduleGrid.DataSource = Resource.ConfigDB.ScheduleParamSet.DataSet.Tables[0];
            }
            finally
            {
                Resource.ConfigDB.Unlock();
            }

            defStandardEdit.Text = defSch.Standard;
            defNameEdit.Text = defSch.Name;
            ActiveControl = defStandardEdit;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            bookmark.Get();

            Resource.ConfigDB.Lock();
            try
            {
                if (string.IsNullOrWhiteSpace(searchStandardEdit.Text) == true)
                    Resource.ConfigDB.ScheduleParamSet.Select();
                else
                    Resource.ConfigDB.ScheduleParamSet.Select(searchStandardEdit.Text.Trim());
            }
            finally
            {
                Resource.ConfigDB.Unlock();
            }

            bookmark.Goto();
            scheduleGrid.Focus();
        }

        private void scheduleGrid_Enter(object sender, EventArgs e)
        {
            if (ScheduleGridView.FocusedRowHandle < 0) return;

            DispFocusedRow(ScheduleGridView.FocusedRowHandle);
        }

        private void scheduleGrid_DoubleClick(object sender, EventArgs e)
        {
            okButton.PerformClick();
        }

        private void scheduleGridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) return;

            DispFocusedRow(e.FocusedRowHandle);
        }

        private void DispFocusedRow(int rowHandle)
        {
            Resource.ConfigDB.Lock();

            try
            {
                DataRow row = scheduleGridView.GetDataRow(rowHandle);
                Resource.ConfigDB.ScheduleParamSet.Fetch(row);
                SetEditFromDataSet();
            }
            finally
            {
                Resource.ConfigDB.Unlock();
            }
        }

        private void SetEditReadOnly(bool active)
        {
            foreach (TextEdit edit in id1Edits)
            {
                edit.Properties.ReadOnly = active;
                edit.EnterMoveNextControl = true;
            }

            foreach (TextEdit edit in id2Edits)
            {
                edit.Properties.ReadOnly = active;
                edit.EnterMoveNextControl = true;
            }

            foreach (TextEdit edit in odEdits)
            {
                edit.Properties.ReadOnly = active;
                edit.EnterMoveNextControl = true;
            }

            foreach (TextEdit edit in viewEdits)
            {
                edit.Properties.ReadOnly = active;
                edit.EnterMoveNextControl = true;
            }

            foreach (AdvBandedGridView gridView in viewGrids)
            {
                gridView.OptionsBehavior.ReadOnly = active;
            }
        }

        private void SetEditFromDataSet()
        {
            ScheduleParamDataSet set = Resource.ConfigDB.ScheduleParamSet;

            standardEdit.Text = set.Standard;
            nameEdit.Text = set.Name;
            noSteadyEdit.EditValue = set.NoOfSteady;
            preparationEdit.EditValue = set.Preparation;
            judgementEdit.EditValue = set.Judgement;
            repeatEdit.EditValue = set.Repeat;

            chamberParams[0].Indoor1Use = set.ID1Use;
            chamberParams[0].Indoor1Mode1 = set.ID1Mode1;
            chamberParams[0].Indoor1Duct1 = set.ID1Duct1;
            chamberParams[0].Indoor1Mode2 = set.ID1Mode2;
            chamberParams[0].Indoor1Duct2 = set.ID1Duct2;

            id1EdbSetupEdit.EditValue = set.ID1EdbSetup;
            id1EdbAvgEdit.EditValue = set.ID1EdbAvg;
            id1EdbDevEdit.EditValue = set.ID1EdbDev;
            id1EwbSetupEdit.EditValue = set.ID1EwbSetup;
            id1EwbAvgEdit.EditValue = set.ID1EwbAvg;
            id1EwbDevEdit.EditValue = set.ID1EwbDev;
            id1Ldb1DevEdit.EditValue = set.ID1Ldb1Dev;
            id1Lwb1DevEdit.EditValue = set.ID1Lwb1Dev;
            id1Airflow1DevEdit.EditValue = set.ID1Af1Dev;
            id1Ldb2DevEdit.EditValue = set.ID1Ldb2Dev;
            id1Lwb2DevEdit.EditValue = set.ID1Lwb2Dev;
            id1Airflow2DevEdit.EditValue = set.ID1Af2Dev;
            id1Cdp1SetupEdit.EditValue = set.ID1Cdp1Setup;
            id1Cdp1AvgEdit.EditValue = set.ID1Cdp1Avg;
            id1Cdp1DevEdit.EditValue = set.ID1Cdp1Dev;
            id1Cdp2SetupEdit.EditValue = set.ID1Cdp2Setup;
            id1Cdp2AvgEdit.EditValue = set.ID1Cdp2Avg;
            id1Cdp2DevEdit.EditValue = set.ID1Cdp2Dev;

            chamberParams[0].Indoor2Use = set.ID2Use;
            chamberParams[0].Indoor2Mode1 = set.ID2Mode1;
            chamberParams[0].Indoor2Duct1 = set.ID2Duct1;
            chamberParams[0].Indoor2Mode2 = set.ID2Mode2;
            chamberParams[0].Indoor2Duct2 = set.ID2Duct2;

            id2EdbSetupEdit.EditValue = set.ID2EdbSetup;
            id2EdbAvgEdit.EditValue = set.ID2EdbAvg;
            id2EdbDevEdit.EditValue = set.ID2EdbDev;
            id2EwbSetupEdit.EditValue = set.ID2EwbSetup;
            id2EwbAvgEdit.EditValue = set.ID2EwbAvg;
            id2EwbDevEdit.EditValue = set.ID2EwbDev;
            id2Ldb1DevEdit.EditValue = set.ID2Ldb1Dev;
            id2Lwb1DevEdit.EditValue = set.ID2Lwb1Dev;
            id2Airflow1DevEdit.EditValue = set.ID2Af1Dev;
            id2Ldb2DevEdit.EditValue = set.ID2Ldb2Dev;
            id2Lwb2DevEdit.EditValue = set.ID2Lwb2Dev;
            id2Airflow2DevEdit.EditValue = set.ID2Af2Dev;
            id2Cdp1SetupEdit.EditValue = set.ID2Cdp1Setup;
            id2Cdp1AvgEdit.EditValue = set.ID2Cdp1Avg;
            id2Cdp1DevEdit.EditValue = set.ID2Cdp1Dev;
            id2Cdp2SetupEdit.EditValue = set.ID2Cdp2Setup;
            id2Cdp2AvgEdit.EditValue = set.ID2Cdp2Avg;
            id2Cdp2DevEdit.EditValue = set.ID2Cdp2Dev;

            chamberParams[0].OutdoorUse = set.ODUse;
            chamberParams[0].OutdoorDpSensor = set.ODDp;
            chamberParams[0].OutdoorAutoVolt = set.ODAutoVolt;

            odEdbSetupEdit.EditValue = set.ODEdbSetup;
            odEdbAvgEdit.EditValue = set.ODEdbAvg;
            odEdbDevEdit.EditValue = set.ODEdbDev;
            odEwbSetupEdit.EditValue = set.ODEwbSetup;
            odEwbAvgEdit.EditValue = set.ODEwbAvg;
            odEwbDevEdit.EditValue = set.ODEwbDev;
            odEdpSetupEdit.EditValue = set.ODEdpSetup;
            odEdpAvgEdit.EditValue = set.ODEdpAvg;
            odEdpDevEdit.EditValue = set.ODEdpDev;
            odVolt1SetupEdit.EditValue = set.ODVolt1Setup;
            odVolt1AvgEdit.EditValue = set.ODVolt1Avg;
            odVolt1DevEdit.EditValue = set.ODVolt1Dev;
            odVolt2SetupEdit.EditValue = set.ODVolt2Setup;
            odVolt2AvgEdit.EditValue = set.ODVolt2Avg;
            odVolt2DevEdit.EditValue = set.ODVolt2Dev;

            indoor1GridView.RefreshData();
            indoor2GridView.RefreshData();
            outdoorGridView.RefreshData();
        }

        private string ToDevFormat(string format)
        {
            string[] strings = format.Split(new[] { '.' }, StringSplitOptions.None);

            if ((strings == null) || (strings.Length != 2)) return "f0";

            return $"f{strings[1].Length}";
        }

        private void indoor1GridView_CustomDrawBandHeader(object sender, BandHeaderCustomDrawEventArgs e)
        {
            if (e.Band == null) return;

            if (e.Band.AppearanceHeader.BackColor != Color.Empty)
            {
                e.Info.AllowColoring = true;
            }
        }

        private void indoor1GridView_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == null) return;

            if (e.Column.AppearanceHeader.BackColor != Color.Empty)
            {
                e.Info.AllowColoring = true;
            }
        }

        private void indoor1GridView_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            AdvBandedGridView view = sender as AdvBandedGridView;

            switch (e.Column.FieldName)
            {
                case "Indoor1Use":
                    if ((EIndoorUse)e.Value == EIndoorUse.NotUsed)
                    {
                        view.SetRowCellValue(e.RowHandle, view.Columns["Indoor1Mode1"], EIndoorMode.NotUsed);
                        view.SetRowCellValue(e.RowHandle, view.Columns["Indoor1Duct1"], EIndoorDuct.NotUsed);
                        view.SetRowCellValue(e.RowHandle, view.Columns["Indoor1Mode2"], EIndoorMode.NotUsed);
                        view.SetRowCellValue(e.RowHandle, view.Columns["Indoor1Duct2"], EIndoorDuct.NotUsed);
                    }
                    break;

                case "Indoor2Use":
                    if ((EIndoorUse)e.Value == EIndoorUse.NotUsed)
                    {
                        view.SetRowCellValue(e.RowHandle, view.Columns["Indoor2Mode1"], EIndoorMode.NotUsed);
                        view.SetRowCellValue(e.RowHandle, view.Columns["Indoor2Duct1"], EIndoorDuct.NotUsed);
                        view.SetRowCellValue(e.RowHandle, view.Columns["Indoor2Mode2"], EIndoorMode.NotUsed);
                        view.SetRowCellValue(e.RowHandle, view.Columns["Indoor2Duct2"], EIndoorDuct.NotUsed);
                    }
                    break;
            }
        }

        private void indoor1UseLookUp_EditValueChanging(object sender, ChangingEventArgs e)
        {
            GridColumn column = indoor1GridView.FocusedColumn;

            switch (column.FieldName)
            {
                case "Indoor1Mode1":
                case "Indoor1Duct1":
                case "Indoor1Mode2":
                case "Indoor1Duct2":
                    if ((EIndoorUse)indoor1GridView.GetRowCellValue(
                        indoor1GridView.FocusedRowHandle,
                        indoor1GridView.Columns["Indoor1Use"])
                        == EIndoorUse.NotUsed)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        e.Cancel = false;
                    }
                    break;

                case "Indoor2Mode1":
                case "Indoor2Duct1":
                case "Indoor2Mode2":
                case "Indoor2Duct2":
                    if ((EIndoorUse)scheduleGridView.GetRowCellValue(
                        scheduleGridView.FocusedRowHandle,
                        scheduleGridView.Columns["Indoor2Use"])
                        == EIndoorUse.NotUsed)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        e.Cancel = false;
                    }
                    break;
            }
        }

        private void indoor2UseLookUp_EditValueChanging(object sender, ChangingEventArgs e)
        {
            GridColumn column = indoor2GridView.FocusedColumn;

            switch (column.FieldName)
            {
                case "Indoor2Mode1":
                case "Indoor2Duct1":
                case "Indoor2Mode2":
                case "Indoor2Duct2":
                    if ((EIndoorUse)indoor2GridView.GetRowCellValue(
                        indoor2GridView.FocusedRowHandle,
                        indoor2GridView.Columns["Indoor2Use"])
                        == EIndoorUse.NotUsed)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        e.Cancel = false;
                    }
                    break;
            }
        }

        private void FormOpenSchedule_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                cancelButton.PerformClick();
            }
        }

        private void defStandardEdit_Enter(object sender, EventArgs e)
        {
            standardEdit.Text = defSch.Standard;
            nameEdit.Text = defSch.Name;
            noSteadyEdit.EditValue = defSch.NoOfSteady;
            preparationEdit.EditValue = defSch.PreRun;
            judgementEdit.EditValue = defSch.Judge;
            repeatEdit.EditValue = defSch.Repeat;

            chamberParams[0].Indoor1Use = defSch.Indoor1Use;
            chamberParams[0].Indoor1Mode1 = defSch.Indoor1Mode1;
            chamberParams[0].Indoor1Duct1 = defSch.Indoor1Duct1;
            chamberParams[0].Indoor1Mode2 = defSch.Indoor1Mode2;
            chamberParams[0].Indoor1Duct2 = defSch.Indoor1Duct2;

            id1EdbSetupEdit.EditValue = defSch.Indoor1DB;
            id1EdbAvgEdit.EditValue = defSch.Indoor1DBAvg;
            id1EdbDevEdit.EditValue = defSch.Indoor1DBDev;
            id1EwbSetupEdit.EditValue = defSch.Indoor1WB;
            id1EwbAvgEdit.EditValue = defSch.Indoor1WBAvg;
            id1EwbDevEdit.EditValue = defSch.Indoor1WBDev;
            id1Ldb1DevEdit.EditValue = defSch.Indoor1LDB1Dev;
            id1Lwb1DevEdit.EditValue = defSch.Indoor1LWB1Dev;
            id1Airflow1DevEdit.EditValue = defSch.Indoor1AirFlow1Dev;
            id1Ldb2DevEdit.EditValue = defSch.Indoor1LDB2Dev;
            id1Lwb2DevEdit.EditValue = defSch.Indoor1LWB2Dev;
            id1Airflow2DevEdit.EditValue = defSch.Indoor1AirFlow2Dev;
            id1Cdp1SetupEdit.EditValue = defSch.Indoor1CP1;
            id1Cdp1AvgEdit.EditValue = defSch.Indoor1CP1Avg;
            id1Cdp1DevEdit.EditValue = defSch.Indoor1CP1Dev;
            id1Cdp2SetupEdit.EditValue = defSch.Indoor1CP2;
            id1Cdp2AvgEdit.EditValue = defSch.Indoor1CP2Avg;
            id1Cdp2DevEdit.EditValue = defSch.Indoor1CP2Dev;

            chamberParams[0].Indoor2Use = defSch.Indoor2Use;
            chamberParams[0].Indoor2Mode1 = defSch.Indoor2Mode1;
            chamberParams[0].Indoor2Duct1 = defSch.Indoor2Duct1;
            chamberParams[0].Indoor2Mode2 = defSch.Indoor2Mode2;
            chamberParams[0].Indoor2Duct2 = defSch.Indoor2Duct2;

            id2EdbSetupEdit.EditValue = defSch.Indoor2DB;
            id2EdbAvgEdit.EditValue = defSch.Indoor2DBAvg;
            id2EdbDevEdit.EditValue = defSch.Indoor2DBDev;
            id2EwbSetupEdit.EditValue = defSch.Indoor2WB;
            id2EwbAvgEdit.EditValue = defSch.Indoor2WBAvg;
            id2EwbDevEdit.EditValue = defSch.Indoor2WBDev;
            id2Ldb1DevEdit.EditValue = defSch.Indoor2LDB1Dev;
            id2Lwb1DevEdit.EditValue = defSch.Indoor2LWB1Dev;
            id2Airflow1DevEdit.EditValue = defSch.Indoor2AirFlow1Dev;
            id2Ldb2DevEdit.EditValue = defSch.Indoor2LDB2Dev;
            id2Lwb2DevEdit.EditValue = defSch.Indoor2LWB2Dev;
            id2Airflow2DevEdit.EditValue = defSch.Indoor2AirFlow2Dev;
            id2Cdp1SetupEdit.EditValue = defSch.Indoor2CP1;
            id2Cdp1AvgEdit.EditValue = defSch.Indoor2CP1Avg;
            id2Cdp1DevEdit.EditValue = defSch.Indoor2CP1Dev;
            id2Cdp2SetupEdit.EditValue = defSch.Indoor2CP2;
            id2Cdp2AvgEdit.EditValue = defSch.Indoor2CP2Avg;
            id2Cdp2DevEdit.EditValue = defSch.Indoor2CP2Dev;

            chamberParams[0].OutdoorUse = defSch.OutdoorUse;
            chamberParams[0].OutdoorDpSensor = defSch.OutdoorDpSensor;
            chamberParams[0].OutdoorAutoVolt = defSch.OutdoorAutoVolt;

            odEdbSetupEdit.EditValue = defSch.OutdoorDB;
            odEdbAvgEdit.EditValue = defSch.OutdoorDBAvg;
            odEdbDevEdit.EditValue = defSch.OutdoorDBDev;
            odEwbSetupEdit.EditValue = defSch.OutdoorWB;
            odEwbAvgEdit.EditValue = defSch.OutdoorWBAvg;
            odEwbDevEdit.EditValue = defSch.OutdoorWBDev;
            odEdpSetupEdit.EditValue = defSch.OutdoorDP;
            odEdpAvgEdit.EditValue = defSch.OutdoorDPAvg;
            odEdpDevEdit.EditValue = defSch.OutdoorDPDev;
            odVolt1SetupEdit.EditValue = defSch.OutdoorVolt1;
            odVolt1AvgEdit.EditValue = defSch.OutdoorVolt1Avg;
            odVolt1DevEdit.EditValue = defSch.OutdoorVolt1Dev;
            odVolt2SetupEdit.EditValue = defSch.OutdoorVolt2;
            odVolt2AvgEdit.EditValue = defSch.OutdoorVolt2Avg;
            odVolt2DevEdit.EditValue = defSch.OutdoorVolt2Dev;

            indoor1GridView.RefreshData();
            indoor2GridView.RefreshData();
            outdoorGridView.RefreshData();
        }
    }
}
