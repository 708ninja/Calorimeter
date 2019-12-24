using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ulee.Controls;

namespace Hnc.Calorimeter.Server
{
    public partial class CtrlViewValue : UlUserControlEng
    {
        public CtrlViewValue()
        {
            InitializeComponent();
            Initialize();
        }

        private void CtrlViewValue_Enter(object sender, EventArgs e)
        {
            InvalidControl(sender, e);
        }

        private void recorderTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Resource.Server.Devices.RecorderValueType = (EValueType)recorderTypeCombo.SelectedIndex;
        }

        private void Initialize()
        {
            Color evenColor = Color.FromArgb(244, 244, 236);

            powerMeterGrid.DataSource = Resource.Server.Devices.PowerMeterValues;
            powerMeterGridView.Appearance.EvenRow.BackColor = evenColor;
            powerMeterGridView.OptionsView.EnableAppearanceEvenRow = true;

            recorderGrid.DataSource = Resource.Server.Devices.RecorderValues;
            recorderGridView.Appearance.EvenRow.BackColor = evenColor;
            recorderGridView.OptionsView.EnableAppearanceEvenRow = true;

            controllerGrid.DataSource = Resource.Server.Devices.ControllerValues;
            controllerGridView.Appearance.EvenRow.BackColor = evenColor;
            controllerGridView.OptionsView.EnableAppearanceEvenRow = true;

            plcGrid.DataSource = Resource.Server.Devices.PlcValues;
            plcGridView.Appearance.EvenRow.BackColor = evenColor;
            plcGridView.OptionsView.EnableAppearanceEvenRow = true;

            recorderTypeCombo.SelectedIndex = (int)Resource.Server.Devices.RecorderValueType;
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
                powerMeterGridView.RefreshData();
                recorderGridView.RefreshData();
                controllerGridView.RefreshData();
                plcGridView.RefreshData();
            }
        }
    }
}
