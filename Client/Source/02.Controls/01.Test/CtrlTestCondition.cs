﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.Utils;
using DevExpress.Utils.DragDrop;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

using Ulee.Controls;
using Ulee.Device.Connection.Yokogawa;
using Ulee.Utils;

namespace Hnc.Calorimeter.Client
{
    public partial class CtrlTestCondition : UlUserControlEng
    {
        public CtrlTestCondition(TestContext context)
        {
            initialized = false;

            InitializeComponent();
            this.context = context;

            Initialize();
            initialized = true;
        }

        private TestContext context;

        private bool initialized;

        private bool Busy { get { return Resource.BusySets[context.Handle]; } }

        public AdvBandedGridView ScheduleGridView { get { return scheduleGridView; } }
        public SpinEdit IntegralCountEdit { get { return methodIntegralCountEdit; } }

        public event EventHandler Activated;
        private void OnActivated(object sender, EventArgs args)
        {
            Activated?.Invoke(sender, args);
        }

        public event EventHandler OpenSchedule;
        private void OnOpenSchedule(object sender, EventArgs args)
        {
            if (Busy == true) return;

            ActiveControl = noteCompanyEdit;
            OpenSchedule?.Invoke(sender, args);
        }

        private void Initialize()
        {
            Color evenColor = Color.FromArgb(244, 244, 236);

            NameValue<EIndoorUse>[] inUseItems = EnumHelper.GetNameValues<EIndoorUse>();
            scheduleIDUseLookUp.DataSource = inUseItems;
            scheduleIDUseLookUp.DisplayMember = "Name";
            scheduleIDUseLookUp.ValueMember = "Value";
            scheduleIDUseLookUp.KeyMember = "Value";

            NameValue<EIndoorMode>[] modeItems = EnumHelper.GetNameValues<EIndoorMode>();
            scheduleIDModeLookUp.DataSource = modeItems;
            scheduleIDModeLookUp.DisplayMember = "Name";
            scheduleIDModeLookUp.ValueMember = "Value";
            scheduleIDModeLookUp.KeyMember = "Value";

            NameValue<EIndoorDuct>[] ductItems = EnumHelper.GetNameValues<EIndoorDuct>();
            scheduleIDDuctLookUp.DataSource = ductItems;
            scheduleIDDuctLookUp.DisplayMember = "Name";
            scheduleIDDuctLookUp.ValueMember = "Value";
            scheduleIDDuctLookUp.KeyMember = "Value";

            NameValue<EOutdoorUse>[] outUseItems = EnumHelper.GetNameValues<EOutdoorUse>();
            scheduleODUseLookUp.DataSource = outUseItems;
            scheduleODUseLookUp.DisplayMember = "Name";
            scheduleODUseLookUp.ValueMember = "Value";
            scheduleODUseLookUp.KeyMember = "Value";

            NameValue<EEtcUse>[] etcUseItems = EnumHelper.GetNameValues<EEtcUse>();
            scheduleEtcUseLookUp.DataSource = etcUseItems;
            scheduleEtcUseLookUp.DisplayMember = "Name";
            scheduleEtcUseLookUp.ValueMember = "Value";
            scheduleEtcUseLookUp.KeyMember = "Value";

            scheduleGrid.DataSource = context.Condition.Schedules;
            scheduleGridView.Appearance.EvenRow.BackColor = evenColor;
            scheduleGridView.OptionsView.EnableAppearanceEvenRow = true;

            thermo1Grid.DataSource = context.Condition.TC1;
            thermo1GridView.Appearance.EvenRow.BackColor = evenColor;
            thermo1GridView.OptionsView.EnableAppearanceEvenRow = true;

            thermo2Grid.DataSource = context.Condition.TC2;
            thermo2GridView.Appearance.EvenRow.BackColor = evenColor;
            thermo2GridView.OptionsView.EnableAppearanceEvenRow = true;

            thermo3Grid.DataSource = context.Condition.TC3;
            thermo3GridView.Appearance.EvenRow.BackColor = evenColor;
            thermo3GridView.OptionsView.EnableAppearanceEvenRow = true;

            thermoTagGrid.DataSource = Resource.Tag.Thermos;
            thermoTagGridView.Appearance.EvenRow.BackColor = evenColor;
            thermoTagGridView.OptionsView.EnableAppearanceEvenRow = true;

            pressureGrid.DataSource = context.Condition.Pressures;
            pressureGridView.Appearance.EvenRow.BackColor = evenColor;
            pressureGridView.OptionsView.EnableAppearanceEvenRow = true;

            pressureTagGrid.DataSource = Resource.Tag.Presses;
            pressureTagGridView.Appearance.EvenRow.BackColor = evenColor;
            pressureTagGridView.OptionsView.EnableAppearanceEvenRow = true;

            methodCapaCoolingUnitCombo.DataSource = EnumHelper.GetNameValues<EUnitCapacity>();
            methodCapaCoolingUnitCombo.DisplayMember = "Name";
            methodCapaCoolingUnitCombo.ValueMember = "Value";

            methodCapaHeatingUnitCombo.DataSource = EnumHelper.GetNameValues<EUnitCapacity>();
            methodCapaHeatingUnitCombo.DisplayMember = "Name";
            methodCapaHeatingUnitCombo.ValueMember = "Value";

            methodAirFlowUnitCombo.DataSource = EnumHelper.GetNameValues<EUnitAirFlow>();
            methodAirFlowUnitCombo.DisplayMember = "Name";
            methodAirFlowUnitCombo.ValueMember = "Value";

            methodEnthalpyUnitCombo.DataSource = EnumHelper.GetNameValues<EUnitEnthalpy>();
            methodEnthalpyUnitCombo.DisplayMember = "Name";
            methodEnthalpyUnitCombo.ValueMember = "Value";

            methodPressureUnitCombo.DataSource = EnumHelper.GetNameValues<EUnitPressure>();
            methodPressureUnitCombo.DisplayMember = "Name";
            methodPressureUnitCombo.ValueMember = "Value";

            methodTempUnitCombo.DataSource = EnumHelper.GetNameValues<EUnitTemperature>();
            methodTempUnitCombo.DisplayMember = "Name";
            methodTempUnitCombo.ValueMember = "Value";

            methodDiffPressureUnitCombo.DataSource = EnumHelper.GetNameValues<EUnitDiffPressure>();
            methodDiffPressureUnitCombo.DisplayMember = "Name";
            methodDiffPressureUnitCombo.ValueMember = "Value";

            methodAtmPressureUnitCombo.DataSource = EnumHelper.GetNameValues<EUnitAtmPressure>();
            methodAtmPressureUnitCombo.DisplayMember = "Name";
            methodAtmPressureUnitCombo.ValueMember = "Value";

            foreach (TabPage page in ratedTab.TabPages)
            {
                EConditionRated index = (EConditionRated)int.Parse(page.Tag.ToString());
                CtrlTestRated ctrl = new CtrlTestRated(index, context.Value.Calcurated);
                ctrl.CalcCapacity += DoCalcCapacity;
                ctrl.ChangedPowerMeter += DoChangedPowerMeter;
                page.Controls.Add(ctrl);
            }

            schAddButton_Click(null, null);
        }

        private void DoCalcCapacity(object sender, EventArgs e)
        {
            if (((CtrlTestRated)sender).Index == EConditionRated.Total) return;

            RecalcTotalRatedCondition();
        }

        private void DoChangedPowerMeter(object sender, EventArgs e)
        {
            CtrlTestRated ctrl = null;
            RatedPowerMeterArgs args = e as RatedPowerMeterArgs;

            switch (args.Index)
            {
                case EConditionRated.ID11:
                    ctrl = ratedTab.TabPages[(int)EConditionRated.ID12].Controls[0] as CtrlTestRated;
                    break;

                case EConditionRated.ID12:
                    ctrl = ratedTab.TabPages[(int)EConditionRated.ID11].Controls[0] as CtrlTestRated;
                    break;

                case EConditionRated.ID21:
                    ctrl = ratedTab.TabPages[(int)EConditionRated.ID22].Controls[0] as CtrlTestRated;
                    break;

                case EConditionRated.ID22:
                    ctrl = ratedTab.TabPages[(int)EConditionRated.ID21].Controls[0] as CtrlTestRated;
                    break;
            }

            if (ctrl == null) return;

            if (args.Field == ETestRatedField.PM_IDU)
            {
                ctrl.SetIduComboSelectedIndexWithoutEvent(0, args.PowerMeterNo);
                ctrl.SetIduComboSelectedIndexWithoutEvent(1, args.PowerMeterNo);
            }
            else
            {
                ctrl.SetOduComboSelectedIndexWithoutEvent(0, args.PowerMeterNo);
                ctrl.SetOduComboSelectedIndexWithoutEvent(1, args.PowerMeterNo);
            }
        }

        public void SetEditFromDataSet()
        {
            NoteParamDataSet set = context.DB.NoteParamSet;

            noteCompanyEdit.Text = set.Company;
            noteTestNameEdit.Text = set.TestName;
            noteTestNoEdit.Text = set.TestNo;
            noteObserverEdit.Text = set.Observer;
            noteMakerCombo.Text = set.Maker;
            noteModel1Combo.Text = set.Model1;
            noteSerial1Combo.Text = set.Serial1;
            noteModel2Edit.Text = set.Model2;
            noteSerial2Edit.Text = set.Serial2;
            noteModel3Edit.Text = set.Model3;
            noteSerial3Edit.Text = set.Serial3;
            noteExpDeviceEdit.Text = set.ExpDevice;
            noteRefrigerantCombo.Text = set.Refrig;
            noteRefChargeEdit.Text = set.RefCharge;
            noteMemoEdit.Text = set.Memo;

            foreach (TabPage page in ratedTab.TabPages)
            {
                CtrlTestRated ctrl = page.Controls[0] as CtrlTestRated;

                RatedParamDataSet ratedSet = context.DB.RatedParamSet;
                ratedSet.Select(set.RecNo, ctrl.Index);

                if (ratedSet.GetRowCount() == 2)
                {
                    ratedSet.Fetch(0);
                    ctrl.CoolingRecNo = ratedSet.RecNo;
                    ctrl.coolingCapacityEdit.EditValue = ratedSet.Capacity;
                    ctrl.coolingPowerInEdit.EditValue = ratedSet.Power;
                    ctrl.coolingEepEdit.EditValue = ratedSet.EER_COP;
                    ctrl.coolingVoltEdit.EditValue = ratedSet.Volt;
                    ctrl.coolingCurrentEdit.EditValue = ratedSet.Amp;
                    ctrl.coolingFreqCombo.Text = ratedSet.Freq;
                    ctrl.coolingPowerMeter1Combo.SelectedIndex = ratedSet.PM_IDU;
                    ctrl.coolingPowerMeter2Combo.SelectedIndex = ratedSet.PM_ODU;
                    ctrl.coolingPhaseCombo.SelectedValue = ratedSet.Phase;

                    ratedSet.Fetch(1);
                    ctrl.HeatingRecNo = ratedSet.RecNo;
                    ctrl.heatingCapacityEdit.EditValue = ratedSet.Capacity;
                    ctrl.heatingPowerInEdit.EditValue = ratedSet.Power;
                    ctrl.heatingEepEdit.EditValue = ratedSet.EER_COP;
                    ctrl.heatingVoltEdit.EditValue = ratedSet.Volt;
                    ctrl.heatingCurrentEdit.EditValue = ratedSet.Amp;
                    ctrl.heatingFreqCombo.Text = ratedSet.Freq;
                    ctrl.heatingPowerMeter1Combo.SelectedIndex = ratedSet.PM_IDU;
                    ctrl.heatingPowerMeter2Combo.SelectedIndex = ratedSet.PM_ODU;
                    ctrl.heatingPhaseCombo.SelectedValue = ratedSet.Phase;
                }
            }

            methodCapaCoolingUnitCombo.SelectedValue = set.CoolUnit;
            methodCapaHeatingUnitCombo.SelectedValue = set.HeatUnit;

            ThermoPressParamDataSet thermoPressSet = context.DB.ThermoPressParamSet;

            thermoPressSet.Select(set.RecNo, 0);
            if (context.Condition.TC1.Count == thermoPressSet.GetRowCount())
            {
                for (int i = 0; i < thermoPressSet.GetRowCount(); i++)
                {
                    thermoPressSet.Fetch(i);
                    context.Condition.TC1[i].RecNo = thermoPressSet.RecNo;
                    context.Condition.TC1[i].Name = thermoPressSet.Name;
                }
            }
            thermo1GridView.RefreshData();

            thermoPressSet.Select(set.RecNo, 1);
            if (context.Condition.TC2.Count == thermoPressSet.GetRowCount())
            {
                for (int i = 0; i < thermoPressSet.GetRowCount(); i++)
                {
                    thermoPressSet.Fetch(i);
                    context.Condition.TC2[i].RecNo = thermoPressSet.RecNo;
                    context.Condition.TC2[i].Name = thermoPressSet.Name;
                }
            }
            thermo2GridView.RefreshData();

            thermoPressSet.Select(set.RecNo, 2);
            if (context.Condition.TC3.Count == thermoPressSet.GetRowCount())
            {
                for (int i = 0; i < thermoPressSet.GetRowCount(); i++)
                {
                    thermoPressSet.Fetch(i);
                    context.Condition.TC3[i].RecNo = thermoPressSet.RecNo;
                    context.Condition.TC3[i].Name = thermoPressSet.Name;
                }
            }
            thermo3GridView.RefreshData();

            thermoPressSet.Select(set.RecNo, 3);
            if (context.Condition.Pressures.Count == thermoPressSet.GetRowCount())
            {
                for (int i = 0; i < thermoPressSet.GetRowCount(); i++)
                {
                    thermoPressSet.Fetch(i);
                    context.Condition.Pressures[i].RecNo = thermoPressSet.RecNo;
                    context.Condition.Pressures[i].Name = thermoPressSet.Name;
                }
            }
            pressureGridView.RefreshData();
        }

        public void ResetAllParam()
        {
            context.Condition.Schedules.Clear();
            schAddButton_Click(null, null);

            methodIntegralCountEdit.Value = 1;
            methodIntegralTimeEdit.Value = 1;
            methodScanTimeCombo.SelectedIndex = 0;
            methodCapaCoolingUnitCombo.SelectedValue = EUnitCapacity.W;
            methodCapaHeatingUnitCombo.SelectedValue = EUnitCapacity.W;
            methodAirFlowUnitCombo.SelectedValue = EUnitAirFlow.CMM;
            methodEnthalpyUnitCombo.SelectedValue = EUnitEnthalpy.W;
            methodTempUnitCombo.SelectedValue = EUnitTemperature.Celsius;
            methodPressureUnitCombo.SelectedValue = EUnitPressure.Bar;
            methodDiffPressureUnitCombo.SelectedValue = EUnitDiffPressure.mmAq;
            methodAtmPressureUnitCombo.SelectedValue = EUnitAtmPressure.mmAq;
            methodAutoCtrlSetCheck.Checked = false;
            methodUsePmIntegCheck.Checked = false;

            // Rated Condition
            foreach (TabPage page in ratedTab.TabPages)
            {
                CtrlTestRated ctrl = (CtrlTestRated)page.Controls[0];

                ctrl.coolingCapacityEdit.EditValue = 0;
                ctrl.coolingPowerInEdit.EditValue = 0;
                ctrl.coolingEepEdit.EditValue = 0;
                ctrl.coolingVoltEdit.EditValue = 0;
                ctrl.coolingCurrentEdit.EditValue = 0;
                
                ctrl.coolingFreqCombo.SelectedIndex = 1;
                ctrl.coolingPowerMeter1Combo.SelectedIndex = 0;
                ctrl.coolingPowerMeter2Combo.SelectedIndex = 0;
                ctrl.coolingPhaseCombo.SelectedValue = EWT330Wiring.P3W4;

                ctrl.heatingCapacityEdit.EditValue = 0;
                ctrl.heatingPowerInEdit.EditValue = 0;
                ctrl.heatingEepEdit.EditValue = 0;
                ctrl.heatingVoltEdit.EditValue = 0;
                ctrl.heatingCurrentEdit.EditValue = 0;

                ctrl.heatingFreqCombo.SelectedIndex = 1;
                ctrl.heatingPowerMeter1Combo.SelectedIndex = 0;
                ctrl.heatingPowerMeter2Combo.SelectedIndex = 0;
                ctrl.heatingPhaseCombo.SelectedValue = EWT330Wiring.P3W4;
            }

            // Note
            noteCompanyEdit.Text = "";
            noteTestNameEdit.Text = "";
            noteTestNoEdit.Text = "";
            noteObserverEdit.Text = "";
            noteMakerCombo.Text = "";
            noteModel1Combo.Text = "";
            noteSerial1Combo.Text = "";
            noteModel2Edit.Text = "";
            noteSerial2Edit.Text = "";
            noteModel3Edit.Text = "";
            noteSerial3Edit.Text = "";
            noteExpDeviceEdit.Text = "";
            noteRefrigerantCombo.Text = "";
            noteRefChargeEdit.Text = "";
            noteMemoEdit.Text = "";

            // Thermocouple
            foreach (MeasureRow row in context.Condition.TC1)
            {
                row.Name = "";
            }
            thermo1GridView.RefreshData();

            foreach (MeasureRow row in context.Condition.TC2)
            {
                row.Name = "";
            }
            thermo2GridView.RefreshData();

            foreach (MeasureRow row in context.Condition.TC3)
            {
                row.Name = "";
            }
            thermo3GridView.RefreshData();

            foreach (MeasureRow row in context.Condition.Pressures)
            {
                row.Name = "";
            }
            pressureGridView.RefreshData();
        }

        private void CtrlTestCondition_Load(object sender, EventArgs e)
        {
            methodAirFlowUnitCombo.SelectedValue = EUnitAirFlow.CMM;
            methodAirFlowUnitCombo_SelectedValueChanged(null, null);

            methodPressureUnitCombo.SelectedValue = EUnitPressure.Bar;
            methodPressureUnitCombo_SelectedValueChanged(null, null);

            methodAtmPressureUnitCombo.SelectedValue = EUnitAtmPressure.mmHg;
            methodAtmPressureUnitCombo_SelectedValueChanged(null, null);

            methodDiffPressureUnitCombo.SelectedValue = EUnitDiffPressure.mmAq;
            methodDiffPressureUnitCombo_SelectedValueChanged(null, null);

            methodTempUnitCombo.SelectedValue = EUnitTemperature.Celsius;
            methodTempUnitCombo_SelectedValueChanged(null, null);

            methodCapaCoolingUnitCombo.SelectedValue = EUnitCapacity.kcal;
            methodCapaCoolingUnitCombo_SelectedValueChanged(null, null);

            methodCapaHeatingUnitCombo.SelectedValue = EUnitCapacity.Btu;
            methodCapaHeatingUnitCombo_SelectedValueChanged(null, null);

            methodEnthalpyUnitCombo.SelectedValue = EUnitEnthalpy.kcal;
            methodEnthalpyUnitCombo_SelectedValueChanged(null, null);
        }

        private void CtrlTestCondition_Leave(object sender, EventArgs e)
        {
            RefreshContext();
        }

        private void CtrlTestCondition_Enter(object sender, EventArgs e)
        {
            OnActivated(this, null);

            noteSerial1Combo.Properties.Items.Clear();
            noteModel1Combo.Properties.Items.Clear();
            noteMakerCombo.Properties.Items.Clear();

            context.DB.Lock();
            try
            {
                context.DB.NoteParamSet.SelectDistinct();

                for (int i = 0; i < context.DB.NoteParamSet.GetRowCount(); i++)
                {
                    context.DB.NoteParamSet.FetchMaker(i);
                    noteMakerCombo.Properties.Items.Add(context.DB.NoteParamSet.Maker);
                }
            }
            finally
            {
                context.DB.Unlock();
            }
        }

        private void noteMakerCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (initialized == false) return;
            if (noteMakerCombo.Text.Trim() == "") return;

            noteSerial1Combo.Text = "";
            noteSerial1Combo.Properties.Items.Clear();
            noteModel1Combo.Text = "";
            noteModel1Combo.Properties.Items.Clear();

            context.DB.Lock();
            try
            {
                context.DB.NoteParamSet.SelectDistinct(noteMakerCombo.Text.Trim());

                for (int i = 0; i < context.DB.NoteParamSet.GetRowCount(); i++)
                {
                    context.DB.NoteParamSet.FetchModel1(i);
                    noteModel1Combo.Properties.Items.Add(context.DB.NoteParamSet.Model1);
                }
            }
            finally
            {
                context.DB.Unlock();
            }
        }

        private void noteMakerCombo_Properties_BeforePopup(object sender, EventArgs e)
        {
            noteMakerCombo.Text = "";
        }

        private void noteModel1Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (initialized == false) return;
            if (noteModel1Combo.Text.Trim() == "") return;

            noteSerial1Combo.Text = "";
            noteSerial1Combo.Properties.Items.Clear();

            context.DB.Lock();
            try
            {
                context.DB.NoteParamSet.SelectDistinct(
                    noteMakerCombo.Text.Trim(), noteModel1Combo.Text.Trim());

                for (int i = 0; i < context.DB.NoteParamSet.GetRowCount(); i++)
                {
                    context.DB.NoteParamSet.FetchSerial1(i);
                    noteSerial1Combo.Properties.Items.Add(context.DB.NoteParamSet.Serial1);
                }
            }
            finally
            {
                context.DB.Unlock();
            }
        }

        private void noteModel1Combo_Properties_BeforePopup(object sender, EventArgs e)
        {
            noteModel1Combo.Text = "";
        }

        private void noteSerial1Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Busy == true) return;
            if (initialized == false) return;
            if (noteSerial1Combo.Text.Trim() == "") return;

            context.DB.Lock();
            try
            {
                context.DB.NoteParamSet.Select(noteMakerCombo.Text, noteModel1Combo.Text, noteSerial1Combo.Text);
                if (context.DB.NoteParamSet.IsEmpty() == false)
                {
                    context.DB.NoteParamSet.Fetch();
                    SetEditFromDataSet();
                }
            }
            finally
            {
                context.DB.Unlock();
            }
        }

        private void noteSerial1Combo_Properties_BeforePopup(object sender, EventArgs e)
        {
            noteSerial1Combo.Text = "";
        }

        public void ActiveControls()
        {
            methodPanel.Enabled = !Busy;

            foreach (TabPage page in ratedTab.TabPages)
            {
                CtrlTestRated ctrl = (CtrlTestRated)page.Controls[0];

                ctrl.coolingPowerMeter1Combo.Enabled = !Busy;
                ctrl.coolingPowerMeter2Combo.Enabled = !Busy;
                ctrl.coolingPhaseCombo.Enabled = !Busy;

                ctrl.heatingPowerMeter1Combo.Enabled = !Busy;
                ctrl.heatingPowerMeter2Combo.Enabled = !Busy;
                ctrl.heatingPhaseCombo.Enabled = !Busy;
            }
        }

        public void RefreshContext()
        {
            TestValue value = context.Value;
            TestCondition cond = context.Condition;

            cond.Method.IntegralCount = (int)methodIntegralCountEdit.Value;
            cond.Method.IntegralTime = (int)methodIntegralTimeEdit.Value;
            cond.Method.ScanTime = int.Parse(methodScanTimeCombo.Text);
            cond.Method.CoolingCapacity = (EUnitCapacity)methodCapaCoolingUnitCombo.SelectedValue;
            cond.Method.HeatingCapacity = (EUnitCapacity)methodCapaHeatingUnitCombo.SelectedValue;
            cond.Method.AirFlow = (EUnitAirFlow)methodAirFlowUnitCombo.SelectedValue;
            cond.Method.Enthalpy = (EUnitEnthalpy)methodEnthalpyUnitCombo.SelectedValue;
            cond.Method.Pressure = (EUnitPressure)methodPressureUnitCombo.SelectedValue;
            cond.Method.Temperature = (EUnitTemperature)methodTempUnitCombo.SelectedValue;
            cond.Method.DiffPressure = (EUnitDiffPressure)methodDiffPressureUnitCombo.SelectedValue;
            cond.Method.AtmPressure = (EUnitAtmPressure)methodAtmPressureUnitCombo.SelectedValue;
            cond.Method.AutoControllerSetting = methodAutoCtrlSetCheck.Checked;
            cond.Method.UsePowerMeterIntegral = methodUsePmIntegCheck.Checked;

            // Rated Condition
            foreach (TabPage page in ratedTab.TabPages)
            {
                CtrlTestRated ctrl = (CtrlTestRated)page.Controls[0];
                List<ConditionRated> rateds = cond.Rateds[ctrl.Index];

                rateds[(int)ETestMode.Cooling].Capacity = float.Parse(ctrl.coolingCapacityEdit.Text);
                rateds[(int)ETestMode.Cooling].PowerInput = float.Parse(ctrl.coolingPowerInEdit.Text);
                rateds[(int)ETestMode.Cooling].EER_COP = float.Parse(ctrl.coolingEepEdit.Text);
                rateds[(int)ETestMode.Cooling].Voltage = float.Parse(ctrl.coolingVoltEdit.Text);
                rateds[(int)ETestMode.Cooling].Current = float.Parse(ctrl.coolingCurrentEdit.Text);
                rateds[(int)ETestMode.Cooling].Frequency = ctrl.coolingFreqCombo.Text;
                 
                rateds[(int)ETestMode.Cooling].PM_IDU = ctrl.coolingPowerMeter1Combo.SelectedIndex;
                rateds[(int)ETestMode.Cooling].PM_ODU = ctrl.coolingPowerMeter2Combo.SelectedIndex;
                rateds[(int)ETestMode.Cooling].Wiring = (EWT330Wiring)ctrl.coolingPhaseCombo.SelectedValue;

                rateds[(int)ETestMode.Heating].Capacity = float.Parse(ctrl.heatingCapacityEdit.Text);
                rateds[(int)ETestMode.Heating].PowerInput = float.Parse(ctrl.heatingPowerInEdit.Text);
                rateds[(int)ETestMode.Heating].EER_COP = float.Parse(ctrl.heatingEepEdit.Text);
                rateds[(int)ETestMode.Heating].Voltage = float.Parse(ctrl.heatingVoltEdit.Text);
                rateds[(int)ETestMode.Heating].Current = float.Parse(ctrl.heatingCurrentEdit.Text);
                rateds[(int)ETestMode.Heating].Frequency = ctrl.heatingFreqCombo.Text;

                rateds[(int)ETestMode.Heating].PM_IDU = ctrl.heatingPowerMeter1Combo.SelectedIndex;
                rateds[(int)ETestMode.Heating].PM_ODU = ctrl.heatingPowerMeter2Combo.SelectedIndex;
                rateds[(int)ETestMode.Heating].Wiring = (EWT330Wiring)ctrl.heatingPhaseCombo.SelectedValue;
            }

            value.Const["Total.Rated.Capacity"].Value = cond.Rateds[EConditionRated.Total][(int)ETestMode.Cooling].Capacity;
            value.Const["Total.Rated.Power"].Value = cond.Rateds[EConditionRated.Total][(int)ETestMode.Cooling].PowerInput;
            value.Const["Total.Rated.EER_COP"].Value = cond.Rateds[EConditionRated.Total][(int)ETestMode.Cooling].EER_COP;
            value.Const["Total.Rated.Voltage"].Value = cond.Rateds[EConditionRated.Total][(int)ETestMode.Cooling].Voltage;
            value.Const["Total.Rated.Current"].Value = cond.Rateds[EConditionRated.Total][(int)ETestMode.Cooling].Current;
            try
            {
                value.Const["Total.Rated.Frequency"].Value = float.Parse(cond.Rateds[EConditionRated.Total][(int)ETestMode.Cooling].Frequency);
            }
            catch
            {
                value.Const["Total.Rated.Frequency"].Value = 0;
            }

            // Note
            cond.Note.Company = noteCompanyEdit.Text;
            cond.Note.Name = noteTestNameEdit.Text;
            cond.Note.No = noteTestNoEdit.Text;
            cond.Note.Observer = noteObserverEdit.Text;
            cond.Note.Maker = noteMakerCombo.Text;
            cond.Note.Model1 = noteModel1Combo.Text;
            cond.Note.Serial1 = noteSerial1Combo.Text;
            cond.Note.Model2 = noteModel2Edit.Text;
            cond.Note.Serial2 = noteSerial2Edit.Text;
            cond.Note.Model3 = noteModel3Edit.Text;
            cond.Note.Serial3 = noteSerial3Edit.Text;
            cond.Note.ExpDevice = noteExpDeviceEdit.Text;
            cond.Note.Refrigerant = noteRefrigerantCombo.Text;
            cond.Note.RefCharge = noteRefChargeEdit.Text;
            cond.Note.Memo = noteMemoEdit.Text;

            // Thermocouple
            cond.ThermocoupleDic.Clear();
            foreach (MeasureRow row in cond.TC1)
            {
                if (row.Name.Trim() != "")
                {
                    try
                    {
                        cond.ThermocoupleDic.Add(row.Name.Trim(), row.Value);
                    }
                    catch
                    {}
                }
            }

            foreach (MeasureRow row in cond.TC2)
            {
                if (row.Name.Trim() != "")
                {
                    try
                    {
                        cond.ThermocoupleDic.Add(row.Name.Trim(), row.Value);
                    }
                    catch
                    {}
                }
            }

            foreach (MeasureRow row in cond.TC3)
            {
                if (row.Name.Trim() != "")
                {
                    try
                    {
                        cond.ThermocoupleDic.Add(row.Name.Trim(), row.Value);
                    }
                    catch
                    {}
                }
            }

            // Pressure
            cond.PressureDic.Clear();
            foreach (MeasureRow row in cond.Pressures)
            {
                if (row.Name.Trim() != "")
                {
                    try
                    {
                        cond.PressureDic.Add(row.Name.Trim(), row.Value);
                    }
                    catch
                    {}
                }
            }
        }

        public void RefreshData()
        {
            scheduleGridView.RefreshData();
            thermo1GridView.RefreshData();
            thermo2GridView.RefreshData();
            thermo3GridView.RefreshData();
            pressureGridView.RefreshData();
        }

        #region scheduleGrid Events
        private void scheduleTTextEdit_DoubleClick(object sender, EventArgs e)
        {
            OnOpenSchedule(sender, e);
        }

        private void scheduleGridView_CustomDrawBandHeader(object sender, BandHeaderCustomDrawEventArgs e)
        {
            if (e.Band == null) return;

            if (e.Band.AppearanceHeader.BackColor != Color.Empty)
            {
                e.Info.AllowColoring = true;
            }
        }

        private void scheduleGridView_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == null) return;

            if (e.Column.AppearanceHeader.BackColor != Color.Empty)
            {
                e.Info.AllowColoring = true;
            }
        }

        private void scheduleGridView_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            AdvBandedGridView view = sender as AdvBandedGridView;

            if (Busy == false)
            {
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
        }

        private void scheduleF2TextEdit_EditValueChanging(object sender, ChangingEventArgs e)
        {
            //if (Busy == true)
            //{
            //    e.Cancel = true;
            //    return;
            //}
        }

        private void scheduleIDUseLookUp_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (Busy == true)
            {
                e.Cancel = true;
                return;
            }
        }

        private void scheduleIDModeLookUp_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (Busy == true)
            {
                e.Cancel = true;
                return;
            }

            GridColumn column = scheduleGridView.FocusedColumn;

            switch (column.FieldName)
            {
                case "Indoor1Mode1":
                case "Indoor1Mode2":
                    if ((EIndoorUse)scheduleGridView.GetRowCellValue(
                        scheduleGridView.FocusedRowHandle, 
                        scheduleGridView.Columns["Indoor1Use"]) 
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
                case "Indoor2Mode2":
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

            if ((e.Cancel == false) && ((EIndoorMode)e.NewValue == EIndoorMode.NotUsed))
            {
                switch (column.FieldName)
                {
                    case "Indoor1Mode1":
                        scheduleGridView.SetRowCellValue(scheduleGridView.FocusedRowHandle,
                            scheduleGridView.Columns["Indoor1Duct1"], EIndoorDuct.NotUsed);
                        break;

                    case "Indoor1Mode2":
                        scheduleGridView.SetRowCellValue(scheduleGridView.FocusedRowHandle,
                            scheduleGridView.Columns["Indoor1Duct2"], EIndoorDuct.NotUsed);
                        break;

                    case "Indoor2Mode1":
                        scheduleGridView.SetRowCellValue(scheduleGridView.FocusedRowHandle,
                            scheduleGridView.Columns["Indoor2Duct1"], EIndoorDuct.NotUsed);
                        break;

                    case "Indoor2Mode2":
                        scheduleGridView.SetRowCellValue(scheduleGridView.FocusedRowHandle,
                            scheduleGridView.Columns["Indoor2Duct2"], EIndoorDuct.NotUsed);
                        break;
                }
            }
        }

        private void scheduleIDDuctLookUp_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (Busy == true)
            {
                e.Cancel = true;
                return;
            }

            GridColumn column = scheduleGridView.FocusedColumn;

            switch (column.FieldName)
            {
                case "Indoor1Duct1":
                    if ((EIndoorMode)scheduleGridView.GetRowCellValue(
                        scheduleGridView.FocusedRowHandle,
                        scheduleGridView.Columns["Indoor1Mode1"])
                        == EIndoorMode.NotUsed)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        e.Cancel = false;
                    }
                    break;

                case "Indoor1Duct2":
                    if ((EIndoorMode)scheduleGridView.GetRowCellValue(
                        scheduleGridView.FocusedRowHandle,
                        scheduleGridView.Columns["Indoor1Mode2"])
                        == EIndoorMode.NotUsed)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        e.Cancel = false;
                    }
                    break;

                case "Indoor2Duct1":
                    if ((EIndoorMode)scheduleGridView.GetRowCellValue(
                        scheduleGridView.FocusedRowHandle,
                        scheduleGridView.Columns["Indoor2Mode1"])
                        == EIndoorMode.NotUsed)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        e.Cancel = false;
                    }
                    break;

                case "Indoor2Duct2":
                    if ((EIndoorMode)scheduleGridView.GetRowCellValue(
                        scheduleGridView.FocusedRowHandle,
                        scheduleGridView.Columns["Indoor2Mode2"])
                        == EIndoorMode.NotUsed)
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

        private void pressureTagGridView_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == null) return;

            if (e.Column.AppearanceHeader.BackColor != Color.Empty)
            {
                e.Info.AllowColoring = true;
            }
        }

        private void thermoTagGridView_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == null) return;

            if (e.Column.AppearanceHeader.BackColor != Color.Empty)
            {
                e.Info.AllowColoring = true;
            }
        }
        #endregion

        #region Buttons event
        private void schAddButton_Click(object sender, EventArgs e)
        {
            if (Busy == true) return;

            context.Condition.Schedules.Add(new ConditionSchedule(context.Condition.Schedules.Count + 1));
            scheduleGridView.RefreshData();
        }

        private void schDeleteButton_Click(object sender, EventArgs e)
        {
            if (Busy == true) return;
            if (scheduleGridView.RowCount < 2) return;

            scheduleGridView.DeleteRow(scheduleGridView.FocusedRowHandle);
            for (int i=0; i< context.Condition.Schedules.Count; i++)
            {
                context.Condition.Schedules[i].No = i + 1;
            }
            scheduleGridView.RefreshData();
        }
        #endregion

        #region Method event
        private void methodCapaCoolingUnitCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (initialized == false) return;

            int nUnit = (int)methodCapaCoolingUnitCombo.SelectedValue;
            string sUnit = methodCapaCoolingUnitCombo.Text;

            SetRatedConditionCoolingUnit(ETestRatedField.Capacity, sUnit);
            SetRatedConditionCoolingUnit(ETestRatedField.EER_COP, EnumHelper.GetNames<EUnitEER_COP>()[nUnit]);
        }

        private void methodCapaHeatingUnitCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (initialized == false) return;

            int nUnit = (int)methodCapaHeatingUnitCombo.SelectedValue;
            string sUnit = methodCapaHeatingUnitCombo.Text;

            SetRatedConditionHeatingUnit(ETestRatedField.Capacity, sUnit);
            SetRatedConditionHeatingUnit(ETestRatedField.EER_COP, EnumHelper.GetNames<EUnitEER_COP>()[nUnit]);
        }

        private void methodAirFlowUnitCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (initialized == false) return;

            int nUnit = (int)methodAirFlowUnitCombo.SelectedValue;

            context.Value.SetUnitTo(EUnitType.AirFlow, nUnit);
        }

        private void methodEnthalpyUnitCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (initialized == false) return;

            int nUnit = (int)methodEnthalpyUnitCombo.SelectedValue;

            context.Value.SetUnitTo(EUnitType.Enthalpy, nUnit);
            context.Value.SetUnitTo(EUnitType.Heat, nUnit);
        }

        private void methodPressureUnitCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (initialized == false) return;

            int nUnit = (int)methodPressureUnitCombo.SelectedValue;

            context.Value.SetUnitTo(EUnitType.Pressure, nUnit);
        }

        private void methodTempUnitCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (initialized == false) return;

            int nUnit = (int)methodTempUnitCombo.SelectedValue;

            context.Value.SetUnitTo(EUnitType.Temperature, nUnit);
        }

        private void methodDiffPressureUnitCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (initialized == false) return;

            int nUnit = (int)methodDiffPressureUnitCombo.SelectedValue;

            context.Value.SetUnitTo(EUnitType.DiffPressure, nUnit);
        }

        private void methodAtmPressureUnitCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (initialized == false) return;

            int nUnit = (int)methodAtmPressureUnitCombo.SelectedValue;

            context.Value.SetUnitTo(EUnitType.AtmPressure, nUnit);
        }
        #endregion

        #region Rated Condition event
        private void RecalcTotalRatedCondition()
        {
            CtrlTestRated totalCtrl = (CtrlTestRated)ratedTab.TabPages[(int)EConditionRated.Total].Controls[0];

            double coolingCapacity = 0;
            double coolingPower = 0;
            double heatingCapacity = 0;
            double heatingPower = 0;

            foreach (TabPage page in ratedTab.TabPages)
            {
                EConditionRated index = (EConditionRated)int.Parse(page.Tag.ToString());

                if (index != EConditionRated.Total)
                {
                    CtrlTestRated ctrl = (CtrlTestRated)page.Controls[0];

                    coolingCapacity += double.Parse(ctrl.coolingCapacityEdit.Text);
                    coolingPower += double.Parse(ctrl.coolingPowerInEdit.Text);

                    heatingCapacity += double.Parse(ctrl.heatingCapacityEdit.Text);
                    heatingPower += double.Parse(ctrl.heatingPowerInEdit.Text);
                }
            }

            totalCtrl.coolingCapacityEdit.EditValue = coolingCapacity;
            totalCtrl.coolingPowerInEdit.EditValue = coolingPower;

            totalCtrl.heatingCapacityEdit.EditValue = heatingCapacity;
            totalCtrl.heatingPowerInEdit.EditValue = heatingPower;

            if (coolingPower == 0.0)
                totalCtrl.coolingEepEdit.EditValue = 0.0;
            else
                totalCtrl.coolingEepEdit.EditValue = coolingCapacity / coolingPower;

            if (heatingPower == 0.0)
                totalCtrl.heatingEepEdit.EditValue = 0.0;
            else
                totalCtrl.heatingEepEdit.EditValue = heatingCapacity / heatingPower;
        }

        private void SetRatedConditionCoolingUnit(ETestRatedField index, string unit)
        {
            foreach (TabPage page in ratedTab.TabPages)
            {
                CtrlTestRated ctrl = (CtrlTestRated)page.Controls[0];
                ctrl.SetCoolingUnit(index, unit);
            }
        }

        private void SetRatedConditionHeatingUnit(ETestRatedField index, string unit)
        {
            foreach (TabPage page in ratedTab.TabPages)
            {
                CtrlTestRated ctrl = (CtrlTestRated)page.Controls[0];
                ctrl.SetHeatingUnit(index, unit);
            }
        }
        #endregion

        #region Drag & Drop Events
        private void thermo1DragDropEvents_DragDrop(object sender, DragDropEventArgs e)
        {
            int sourceRow = ((int[])e.Data)[0];

            GridView sourceView = e.Source as GridView;
            GridView targetView = e.Target as GridView;

            GridHitInfo hit = targetView.CalcHitInfo(
                targetView.GridControl.PointToClient(new Point(e.Location.X, e.Location.Y)));

            if (hit.InRowCell == true)
            {
                if (sourceView.Name == thermoTagGridView.Name)
                {
                    string tagName = sourceView.GetRowCellValue(sourceRow, sourceView.Columns["Value"]).ToString();

                    if (IsTcTagExist(tagName) == false)
                    {
                        targetView.SetRowCellValue(hit.RowHandle, targetView.Columns["Name"], tagName);
                    }
                }
            }

            e.Handled = true;
        }

        private void thermo1DragDropEvents_DragOver(object sender, DragOverEventArgs e)
        {
            int sourceRow = ((int[])e.Data)[0];
            GridView sourceView = e.Source as GridView;

            if (sourceView.Name == thermoTagGridView.Name)
            {
                string tagName = sourceView.GetRowCellValue(sourceRow, sourceView.Columns["Value"]).ToString();

                if (IsTcTagExist(tagName) == false)
                {
                    DragOverGridEventArgs args = DragOverGridEventArgs.GetDragOverGridEventArgs(e);
                    e.Cursor = DragAndDropCursors.CopyEffectCursor;
                    args.Handled = true;
                }
            }
        }

        private void thermo2DragDropEvents_DragDrop(object sender, DragDropEventArgs e)
        {
            thermo1DragDropEvents_DragDrop(sender, e);
        }

        private void thermo2DragDropEvents_DragOver(object sender, DragOverEventArgs e)
        {
            thermo1DragDropEvents_DragOver(sender, e);
        }

        private void thermo3DragDropEvents_DragDrop(object sender, DragDropEventArgs e)
        {
            thermo1DragDropEvents_DragDrop(sender, e);
        }

        private void thermo3DragDropEvents_DragOver(object sender, DragOverEventArgs e)
        {
            thermo1DragDropEvents_DragOver(sender, e);
        }

        private void pressureDragDropEvents_DragDrop(object sender, DragDropEventArgs e)
        {
            int sourceRow = ((int[])e.Data)[0];

            GridView sourceView = e.Source as GridView;
            GridView targetView = e.Target as GridView;

            GridHitInfo hit = targetView.CalcHitInfo(
                targetView.GridControl.PointToClient(new Point(e.Location.X, e.Location.Y)));

            if (hit.InRowCell == true)
            {
                if (sourceView.Name == pressureTagGridView.Name)
                {
                    string tagName = sourceView.GetRowCellValue(sourceRow, sourceView.Columns["Value"]).ToString();

                    if (IsPressureTagExist(tagName) == false)
                    {
                        targetView.SetRowCellValue(hit.RowHandle, targetView.Columns["Name"], tagName);
                    }
                }
            }

            e.Handled = true;
        }

        private void pressureDragDropEvents_DragOver(object sender, DragOverEventArgs e)
        {
            int sourceRow = ((int[])e.Data)[0];
            GridView sourceView = e.Source as GridView;

            if (sourceView.Name == pressureTagGridView.Name)
            {
                string tagName = sourceView.GetRowCellValue(sourceRow, sourceView.Columns["Value"]).ToString();

                if (IsPressureTagExist(tagName) == false)
                {
                    DragOverGridEventArgs args = DragOverGridEventArgs.GetDragOverGridEventArgs(e);
                    e.Cursor = DragAndDropCursors.CopyEffectCursor;
                    args.Handled = true;
                }
            }
        }

        private bool IsTcTagExist(string tag)
        {
            foreach (MeasureRow row in context.Condition.TC1)
            {
                if (tag == row.Name) return true;
            }

            foreach (MeasureRow row in context.Condition.TC2)
            {
                if (tag == row.Name) return true;
            }

            foreach (MeasureRow row in context.Condition.TC3)
            {
                if (tag == row.Name) return true;
            }

            return false;
        }

        private bool IsPressureTagExist(string tag)
        {
            foreach (MeasureRow row in context.Condition.Pressures)
            {
                if (tag == row.Name) return true;
            }

            return false;
        }
        #endregion
    }
}