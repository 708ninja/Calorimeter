using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

using Ulee.Utils;
using Ulee.Controls;

namespace Hnc.Calorimeter.Client
{
    public partial class FormOpenCondition : UlFormEng
    {
        public FormOpenCondition()
        {
            Initialized = false;
            InitializeComponent();

            Initialize();
            Initialized = true;
        }

        private bool Initialized;

        private List<MeasureRow> id1TCs;
        private List<MeasureRow> id2TCs;
        private List<MeasureRow> odTCs;
        private List<MeasureRow> presses;

        private List<TextEdit> noteEdits;
        private List<GridView> gridViews;

        public int RecNo { get; private set; }
        public GridView ConditionGridView { get { return conditionGridView; } }

        private void Initialize()
        {
            Color evenColor = Color.FromArgb(244, 244, 236);
            int length = Resource.Tag.ThermoLength / 3;

            RecNo = -1;

            id1TCs = new List<MeasureRow>();
            id2TCs = new List<MeasureRow>();
            odTCs = new List<MeasureRow>();

            for (int i = 0; i < length; i++)
            {
                id1TCs.Add(new MeasureRow(null, "", "", i + 1));
                id2TCs.Add(new MeasureRow(null, "", "", i + length + 1));
                odTCs.Add(new MeasureRow(null, "", "", i + length * 2 + 1));
            }

            presses = new List<MeasureRow>();

            for (int i = 0; i < Resource.Tag.PressLength; i++)
            {
                presses.Add(new MeasureRow(null, "", "", i + 1));
            }

            thermo1Grid.DataSource = id1TCs;
            thermo1Grid.UseDirectXPaint = DefaultBoolean.False;
            thermo1GridView.Appearance.EvenRow.BackColor = evenColor;
            thermo1GridView.OptionsView.EnableAppearanceEvenRow = true;

            thermo2Grid.DataSource = id2TCs;
            thermo2Grid.UseDirectXPaint = DefaultBoolean.False;
            thermo2GridView.Appearance.EvenRow.BackColor = evenColor;
            thermo2GridView.OptionsView.EnableAppearanceEvenRow = true;

            thermo3Grid.DataSource = odTCs;
            thermo3Grid.UseDirectXPaint = DefaultBoolean.False;
            thermo3GridView.Appearance.EvenRow.BackColor = evenColor;
            thermo3GridView.OptionsView.EnableAppearanceEvenRow = true;

            pressureGrid.DataSource = presses;
            pressureGrid.UseDirectXPaint = DefaultBoolean.False;
            pressureGridView.Appearance.EvenRow.BackColor = evenColor;
            pressureGridView.OptionsView.EnableAppearanceEvenRow = true;

            methodCapaCoolingUnitCombo.DisplayMember = "Name";
            methodCapaCoolingUnitCombo.ValueMember = "Value";
            methodCapaCoolingUnitCombo.DataSource = EnumHelper.GetNameValues<EUnitCapacity>();

            methodCapaHeatingUnitCombo.DisplayMember = "Name";
            methodCapaHeatingUnitCombo.ValueMember = "Value";
            methodCapaHeatingUnitCombo.DataSource = EnumHelper.GetNameValues<EUnitCapacity>();

            foreach (TabPage page in ratedTab.TabPages)
            {
                EConditionRated index = (EConditionRated)int.Parse(page.Tag.ToString());
                CtrlTestRated ctrl = new CtrlTestRated(index, Resource.Variables.Calcurated);
                page.Controls.Add(ctrl);
            }

            noteEdits = new List<TextEdit>();
            noteEdits.Add(noteCompanyEdit);
            noteEdits.Add(noteTestNameEdit);
            noteEdits.Add(noteTestNoEdit);
            noteEdits.Add(noteObserverEdit);
            noteEdits.Add(noteMakerEdit);
            noteEdits.Add(noteModel1Edit);
            noteEdits.Add(noteSerial1Edit);
            noteEdits.Add(noteModel2Edit);
            noteEdits.Add(noteSerial2Edit);
            noteEdits.Add(noteModel3Edit);
            noteEdits.Add(noteSerial3Edit);
            noteEdits.Add(noteExpDeviceEdit);
            noteEdits.Add(noteRefChargeEdit);
            noteEdits.Add(noteMemoEdit);

            gridViews = new List<GridView>();
            gridViews.Add(thermo1GridView);
            gridViews.Add(thermo2GridView);
            gridViews.Add(thermo3GridView);
            gridViews.Add(pressureGridView);

            SetEditReadOnly(true);
        }

        private void FormOpenCondition_Load(object sender, EventArgs e)
        {
            Resource.ConfigDB.Lock();

            try
            {
                Resource.ConfigDB.NoteParamConfigSet.Select();

                conditionGrid.DataSource = Resource.ConfigDB.NoteParamConfigSet.DataSet.Tables[0];
                conditionGrid.UseDirectXPaint = DefaultBoolean.False;
                conditionGridView.Appearance.EvenRow.BackColor = Color.FromArgb(244, 244, 236);
                conditionGridView.OptionsView.EnableAppearanceEvenRow = true;
            }
            finally
            {
                Resource.ConfigDB.Unlock();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Resource.ConfigDB.Lock();

            try
            {
                if (string.IsNullOrWhiteSpace(makerEdit.Text) == true)
                    Resource.ConfigDB.NoteParamConfigSet.Select();
                else
                    Resource.ConfigDB.NoteParamConfigSet.Select(makerEdit.Text.Trim());
            }
            finally
            {
                Resource.ConfigDB.Unlock();
            }

            conditionGrid.Focus();
        }

        private void conditionGridView_DoubleClick(object sender, EventArgs e)
        {
            okButton.PerformClick();
        }

        private void conditionGridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
            {
                RecNo = -1;
                return;
            }

            Resource.ConfigDB.Lock();
            try
            {
                DataRow row = conditionGridView.GetDataRow(e.FocusedRowHandle);
                Resource.ConfigDB.NoteParamConfigSet.Fetch(row);
                RecNo = Resource.ConfigDB.NoteParamConfigSet.RecNo;
                SetEditFromDataSet();
            }
            finally
            {
                Resource.ConfigDB.Unlock();
            }
        }

        private void methodCapaCoolingUnitCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Initialized == false) return;

            int nUnit = (int)methodCapaCoolingUnitCombo.SelectedValue;
            string sUnit = methodCapaCoolingUnitCombo.Text;

            SetRatedConditionCoolingUnit(ETestRatedField.Capacity, sUnit);
            SetRatedConditionCoolingUnit(ETestRatedField.EER_COP, EnumHelper.GetNames<EUnitEER_COP>()[nUnit]);
        }

        private void methodCapaHeatingUnitCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Initialized == false) return;

            int nUnit = (int)methodCapaHeatingUnitCombo.SelectedValue;
            string sUnit = methodCapaHeatingUnitCombo.Text;

            SetRatedConditionHeatingUnit(ETestRatedField.Capacity, sUnit);
            SetRatedConditionHeatingUnit(ETestRatedField.EER_COP, EnumHelper.GetNames<EUnitEER_COP>()[nUnit]);
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

        private void SetEditReadOnly(bool active)
        {
            searchPanel.Enabled = active;
            methodCapaCoolingUnitCombo.Enabled = !active;
            methodCapaHeatingUnitCombo.Enabled = !active;

            noteRefrigerantCombo.Properties.ReadOnly = active;

            foreach (TextEdit edit in noteEdits)
            {
                edit.Properties.ReadOnly = active;
                edit.EnterMoveNextControl = true;
            }

            foreach (GridView gridView in gridViews)
            {
                gridView.OptionsBehavior.ReadOnly = active;
            }

            foreach (TabPage page in ratedTab.TabPages)
            {
                (page.Controls[0] as CtrlTestRated).ReadOnly = active;
            }
        }

        private void SetEditFromDataSet()
        {
            NoteParamDataSet set = Resource.ConfigDB.NoteParamConfigSet;

            noteCompanyEdit.Text = set.Company;
            noteTestNameEdit.Text = set.TestName;
            noteTestNoEdit.Text = set.TestNo;
            noteObserverEdit.Text = set.Observer;
            noteMakerEdit.Text = set.Maker;
            noteModel1Edit.Text = set.Model1;
            noteSerial1Edit.Text = set.Serial1;
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

                RatedParamDataSet ratedSet = Resource.ConfigDB.RatedParamSet;
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

            ThermoPressParamDataSet thermoPressSet = Resource.ConfigDB.ThermoPressParamSet;

            thermoPressSet.Select(set.RecNo, 0);
            if (id1TCs.Count == thermoPressSet.GetRowCount())
            {
                for (int i = 0; i < thermoPressSet.GetRowCount(); i++)
                {
                    thermoPressSet.Fetch(i);
                    id1TCs[i].RecNo = thermoPressSet.RecNo;
                    id1TCs[i].Value = thermoPressSet.Name;
                }
            }

            thermoPressSet.Select(set.RecNo, 1);
            if (id2TCs.Count == thermoPressSet.GetRowCount())
            {
                for (int i = 0; i < thermoPressSet.GetRowCount(); i++)
                {
                    thermoPressSet.Fetch(i);
                    id2TCs[i].RecNo = thermoPressSet.RecNo;
                    id2TCs[i].Value = thermoPressSet.Name;
                }
            }

            thermoPressSet.Select(set.RecNo, 2);
            if (odTCs.Count == thermoPressSet.GetRowCount())
            {
                for (int i = 0; i < thermoPressSet.GetRowCount(); i++)
                {
                    thermoPressSet.Fetch(i);
                    odTCs[i].RecNo = thermoPressSet.RecNo;
                    odTCs[i].Value = thermoPressSet.Name;
                }
            }

            thermoPressSet.Select(set.RecNo, 3);
            if (presses.Count == thermoPressSet.GetRowCount())
            {
                for (int i = 0; i < thermoPressSet.GetRowCount(); i++)
                {
                    thermoPressSet.Fetch(i);
                    presses[i].RecNo = thermoPressSet.RecNo;
                    presses[i].Value = thermoPressSet.Name;
                }
            }

            foreach (GridView gridView in gridViews)
            {
                gridView.RefreshData();
            }
        }

        private void FormOpenCondition_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                cancelButton.PerformClick();
            }
        }
    }
}
