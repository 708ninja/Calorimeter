using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.Utils;

using Ulee.Controls;
using Ulee.Utils;
using Ulee.Device.Connection.Yokogawa;

namespace Hnc.Calorimeter.Client
{
    public enum ETestRatedField
    {
        Capacity,
        Power,
        EER_COP,
        Voltage,
        Current,
        Frequency,
        PM_IDU,
        PM_ODU,
        Phase
    }

    public partial class CtrlTestRated : UlUserControlEng
    {
        public CtrlTestRated(EConditionRated index, Dictionary<string, ValueRow> values)
        {
            InitializeComponent();

            CoolingRecNo = -1;
            HeatingRecNo = -1;
            Index = index;
            Initialize(values);
        }

        public int CoolingRecNo { get; set; }
        public int HeatingRecNo { get; set; }

        public EConditionRated Index { get; private set; }

        private List<Label> unitCoolingLabels;
        private List<Label> unitHeatingLabels;

        private RatedPowerMeterArgs powerArgs;

        public event EventHandler CalcCapacity;
        private void OnCalcTotalCapacity(object sender, EventArgs args)
        {
            CalcCapacity?.Invoke(sender, args);
        }

        public event EventHandler ChangedPowerMeter;
        private void OnChangedPowerMeter(object sender, RatedPowerMeterArgs args)
        {
            ChangedPowerMeter?.Invoke(sender, args);
        }

        public bool ReadOnly
        {
            set
            {
                coolingCapacityEdit.ReadOnly = value;
                coolingCurrentEdit.ReadOnly = value;
                coolingFreqCombo.ReadOnly = value;
                coolingVoltEdit.ReadOnly = value;
                coolingPowerInEdit.ReadOnly = value;
                coolingPowerMeter1Combo.Enabled = !value;
                coolingPowerMeter2Combo.Enabled = !value;
                coolingPhaseCombo.Enabled = !value;

                heatingCapacityEdit.ReadOnly = value;
                heatingCurrentEdit.ReadOnly = value;
                heatingFreqCombo.ReadOnly = value;
                heatingVoltEdit.ReadOnly = value;
                heatingPowerInEdit.ReadOnly = value;
                heatingPowerMeter1Combo.Enabled = !value;
                heatingPowerMeter2Combo.Enabled = !value;
                heatingPhaseCombo.Enabled = !value;
            }
        }

        private void Initialize(Dictionary<string, ValueRow> values)
        {
            string format, devFormat;

            powerArgs = new RatedPowerMeterArgs(Index, ETestRatedField.PM_IDU, 0, 0);

            coolingFreqCombo.SelectedIndex = 1;
            heatingFreqCombo.SelectedIndex = 1;

            NameValue<EWT330Wiring>[] coolWiring = EnumHelper.GetNameValues<EWT330Wiring>();

            coolingPhaseCombo.DataSource = coolWiring;
            coolingPhaseCombo.DisplayMember = "Name";
            coolingPhaseCombo.ValueMember = "Value";
            coolingPhaseCombo.SelectedValue = EWT330Wiring.P3W4;

            NameValue<EWT330Wiring>[] heatWiring = EnumHelper.GetNameValues<EWT330Wiring>();

            heatingPhaseCombo.DataSource = heatWiring;
            heatingPhaseCombo.DisplayMember = "Name";
            heatingPhaseCombo.ValueMember = "Value";
            heatingPhaseCombo.SelectedValue = EWT330Wiring.P3W4;

            coolingPowerMeter1Combo.Items.Clear();
            coolingPowerMeter2Combo.Items.Clear();

            heatingPowerMeter1Combo.Items.Clear();
            heatingPowerMeter2Combo.Items.Clear();

            foreach (PowerMeterRow<float> row in Resource.Client.Devices.PowerMeter.Rows)
            {
                if (row.Phase == EWT330Phase.P1)
                {
                    coolingPowerMeter1Combo.Items.Add(row.Name);
                    heatingPowerMeter1Combo.Items.Add(row.Name);
                }
                else
                {
                    coolingPowerMeter2Combo.Items.Add(row.Name);
                    heatingPowerMeter2Combo.Items.Add(row.Name);
                }
            }

            coolingPowerMeter1Combo.SelectedIndex = 0;
            coolingPowerMeter2Combo.SelectedIndex = 0;

            heatingPowerMeter1Combo.SelectedIndex = 0;
            heatingPowerMeter2Combo.SelectedIndex = 0;

            format = values["Total.Capacity"].Format;
            devFormat = ToDevFormat(format);

            coolingCapacityEdit.EditValue = 0;
            coolingCapacityEdit.Properties.Mask.EditMask = devFormat;
            coolingCapacityEdit.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            coolingCapacityEdit.Properties.DisplayFormat.FormatString = devFormat;
            coolingCapacityEdit.Properties.EditFormat.FormatType = FormatType.Numeric;
            coolingCapacityEdit.Properties.EditFormat.FormatString = devFormat;
            heatingCapacityEdit.EditValue = 0;
            heatingCapacityEdit.Properties.Mask.EditMask = devFormat;
            heatingCapacityEdit.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            heatingCapacityEdit.Properties.DisplayFormat.FormatString = devFormat;
            heatingCapacityEdit.Properties.EditFormat.FormatType = FormatType.Numeric;
            heatingCapacityEdit.Properties.EditFormat.FormatString = devFormat;

            format = values["Total.Power"].Format;
            devFormat = ToDevFormat(format);

            coolingPowerInEdit.EditValue = 0;
            coolingPowerInEdit.Properties.Mask.EditMask = devFormat;
            coolingPowerInEdit.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            coolingPowerInEdit.Properties.DisplayFormat.FormatString = devFormat;
            coolingPowerInEdit.Properties.EditFormat.FormatType = FormatType.Numeric;
            coolingPowerInEdit.Properties.EditFormat.FormatString = devFormat;
            heatingPowerInEdit.EditValue = 0;
            heatingPowerInEdit.Properties.Mask.EditMask = devFormat;
            heatingPowerInEdit.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            heatingPowerInEdit.Properties.DisplayFormat.FormatString = devFormat;
            heatingPowerInEdit.Properties.EditFormat.FormatType = FormatType.Numeric;
            heatingPowerInEdit.Properties.EditFormat.FormatString = devFormat;

            format = values["Total.EER_COP"].Format;
            devFormat = ToDevFormat(format);

            coolingEepEdit.EditValue = 0;
            coolingEepEdit.Properties.Mask.EditMask = devFormat;
            coolingEepEdit.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            coolingEepEdit.Properties.DisplayFormat.FormatString = devFormat;
            coolingEepEdit.Properties.EditFormat.FormatType = FormatType.Numeric;
            coolingEepEdit.Properties.EditFormat.FormatString = devFormat;
            coolingEepEdit.Properties.ReadOnly = true;
            heatingEepEdit.EditValue = 0;
            heatingEepEdit.Properties.Mask.EditMask = devFormat;
            heatingEepEdit.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            heatingEepEdit.Properties.DisplayFormat.FormatString = devFormat;
            heatingEepEdit.Properties.EditFormat.FormatType = FormatType.Numeric;
            heatingEepEdit.Properties.EditFormat.FormatString = devFormat;
            heatingEepEdit.Properties.ReadOnly = true;

            format = values["ID1.IDU.Voltage"].Format;
            devFormat = ToDevFormat(format);

            coolingVoltEdit.EditValue = 0;
            coolingVoltEdit.Properties.Mask.EditMask = devFormat;
            coolingVoltEdit.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            coolingVoltEdit.Properties.DisplayFormat.FormatString = devFormat;
            coolingVoltEdit.Properties.EditFormat.FormatType = FormatType.Numeric;
            coolingVoltEdit.Properties.EditFormat.FormatString = devFormat;
            heatingVoltEdit.EditValue = 0;
            heatingVoltEdit.Properties.Mask.EditMask = devFormat;
            heatingVoltEdit.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            heatingVoltEdit.Properties.DisplayFormat.FormatString = devFormat;
            heatingVoltEdit.Properties.EditFormat.FormatType = FormatType.Numeric;
            heatingVoltEdit.Properties.EditFormat.FormatString = devFormat;

            format = values["ID1.IDU.Current"].Format;
            devFormat = ToDevFormat(format);

            coolingCurrentEdit.EditValue = 0;
            coolingCurrentEdit.Properties.Mask.EditMask = devFormat;
            coolingCurrentEdit.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            coolingCurrentEdit.Properties.DisplayFormat.FormatString = devFormat;
            coolingCurrentEdit.Properties.EditFormat.FormatType = FormatType.Numeric;
            coolingCurrentEdit.Properties.EditFormat.FormatString = devFormat;
            heatingCurrentEdit.EditValue = 0;
            heatingCurrentEdit.Properties.Mask.EditMask = devFormat;
            heatingCurrentEdit.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            heatingCurrentEdit.Properties.DisplayFormat.FormatString = devFormat;
            heatingCurrentEdit.Properties.EditFormat.FormatType = FormatType.Numeric;
            heatingCurrentEdit.Properties.EditFormat.FormatString = devFormat;

            unitCoolingLabels = new List<Label>();
            unitCoolingLabels.Add(coolingCapacityUnitLabel);
            unitCoolingLabels.Add(coolingPowerUnitLabel);
            unitCoolingLabels.Add(coolingEER_COPUnitLabel);
            unitCoolingLabels.Add(coolingVoltageUnitLabel);
            unitCoolingLabels.Add(coolingCurrentUnitLabel);

            unitHeatingLabels = new List<Label>();
            unitHeatingLabels.Add(heatingCapacityUnitLabel);
            unitHeatingLabels.Add(heatingPowerUnitLabel);
            unitHeatingLabels.Add(heatingEER_COPUnitLabel);
            unitHeatingLabels.Add(heatingVoltageUnitLabel);
            unitHeatingLabels.Add(heatingCurrentUnitLabel);

            ReadOnly = false;
        }

        private string ToDevFormat(string format)
        {
            string[] strings = format.Split(new[] { '.' }, StringSplitOptions.None);

            if ((strings == null) || (strings.Length != 2)) return "f0";

            return $"f{strings[1].Length}";
        }

        public void SetCoolingUnit(ETestRatedField index, string unit)
        {
            unitCoolingLabels[(int)index].Text = unit;
        }

        public void SetHeatingUnit(ETestRatedField index, string unit)
        {
            unitHeatingLabels[(int)index].Text = unit;
        }

        public void capacityEdit_Leave(object sender, EventArgs e)
        {
            double coolingCapacity = double.Parse(coolingCapacityEdit.Text);
            double coolingPower = double.Parse(coolingPowerInEdit.Text);
            double heatingCapacity = double.Parse(heatingCapacityEdit.Text);
            double heatingPower = double.Parse(heatingPowerInEdit.Text);

            if (coolingPower == 0.0)
                coolingEepEdit.EditValue = 0.0;
            else
                coolingEepEdit.EditValue = coolingCapacity / coolingPower;

            if (heatingPower == 0.0)
                heatingEepEdit.EditValue = 0.0;
            else
                heatingEepEdit.EditValue = heatingCapacity / heatingPower;

            OnCalcTotalCapacity(this, null);
        }

        private void coolingPowerMeter1Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            int tag = int.Parse(combo.Tag.ToString());

            SetIduComboSelectedIndexWithoutEvent(tag, combo.SelectedIndex);

            powerArgs.Field = ETestRatedField.PM_IDU;
            powerArgs.Tag = tag;
            powerArgs.PowerMeterNo = combo.SelectedIndex;

            OnChangedPowerMeter(sender, powerArgs);
        }

        private void coolingPowerMeter2Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            int tag = int.Parse(combo.Tag.ToString());

            SetOduComboSelectedIndexWithoutEvent(tag, combo.SelectedIndex);

            powerArgs.Field = ETestRatedField.PM_ODU;
            powerArgs.Tag = tag;
            powerArgs.PowerMeterNo = combo.SelectedIndex;

            OnChangedPowerMeter(sender, powerArgs);
        }

        public void SetIduComboSelectedIndexWithoutEvent(int tag, int index)
        {
            ComboBox combo;
            EventHandler eventHandler = coolingPowerMeter1Combo_SelectedIndexChanged;

            if (tag == 0)
            {
                combo = heatingPowerMeter1Combo;
            }
            else
            {
                combo = coolingPowerMeter1Combo;
            }

            combo.SelectedIndexChanged -= eventHandler;
            combo.SelectedIndex = index;
            combo.SelectedIndexChanged += eventHandler;
        }

        public void SetOduComboSelectedIndexWithoutEvent(int tag, int index)
        {
            ComboBox combo;
            EventHandler eventHandler = coolingPowerMeter2Combo_SelectedIndexChanged;

            if (tag == 0)
            {
                combo = heatingPowerMeter2Combo;
            }
            else
            {
                combo = coolingPowerMeter2Combo;
            }

            combo.SelectedIndexChanged -= eventHandler;
            combo.SelectedIndex = index;
            combo.SelectedIndexChanged += eventHandler;
        }
    }

    public class RatedPowerMeterArgs : EventArgs
    {
        public RatedPowerMeterArgs(EConditionRated index, ETestRatedField field, int tag, int powerMeterNo)
        {
            Index = index;
            Field = field;
            Tag = tag;
            PowerMeterNo = powerMeterNo;
        }

        public EConditionRated Index { get; set; }
        public ETestRatedField Field { get; set; }
        public int Tag { get; set; }
        public int PowerMeterNo { get; set; }
    }
}
