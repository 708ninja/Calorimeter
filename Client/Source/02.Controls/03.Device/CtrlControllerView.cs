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
using Ulee.Device.Connection.Yokogawa;

namespace Hnc.Calorimeter.Client
{
    public partial class CtrlControllerView : UlUserControlEng
    {
        public CtrlControllerView(string name, int networkNo, int controllerNo)
        {
            InitializeComponent();

            titleEdit.Text = name;
            NetworkNo = networkNo;
            ControllerNo = controllerNo;
        }

        public int NetworkNo { get; private set; }

        public int ControllerNo { get; private set; }

        private void CtrlControllerView_Load(object sender, EventArgs e)
        {
        }

        public void RefreshMeter(List<DeviceValueRow<float>> rows)
        {
            pvPanel.Text = $"{rows[(int)EUT55ARegisterSeries.PV].Value:f2}";
            svPanel.Text = $"{rows[(int)EUT55ARegisterSeries.SV].Value:f2}";
            outPanel.Text = $"{rows[(int)EUT55ARegisterSeries.MOUT].Value:f1}";
            modePanel.Text = (rows[(int)EUT55ARegisterSeries.Mode].Value == 0.0) ? "AUTO" : "MANUAL";
            pPanel.Text = $"{rows[(int)EUT55ARegisterSeries.P].Value:f1}";
            iPanel.Text = $"{rows[(int)EUT55ARegisterSeries.I].Value:f0}";
            dPanel.Text = $"{rows[(int)EUT55ARegisterSeries.D].Value:f0}";
            flPanel.Text = $"{rows[(int)EUT55ARegisterSeries.FL].Value:f0}";
        }

        private void settingButton_Click(object sender, EventArgs args)
        {
            FormControllerEdit form = new FormControllerEdit();
            form.Text = titleEdit.Text;
            form.svEdit.Text = svPanel.Text;
            form.outEdit.Text = outPanel.Text;
            form.modeCombo.SelectedIndex = (modePanel.Text == "AUTO") ? 0 : 1;
            form.pEdit.Text = pPanel.Text;
            form.iEdit.Text = iPanel.Text;
            form.dEdit.Text = dPanel.Text;
            form.flEdit.Text = flPanel.Text;

            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    settingController(form);
                }
                catch (Exception e)
                {
                    Resource.TLog.Log((int)ELogItem.Exception, e.ToString());
                }
            }
        }

        private void settingController(FormControllerEdit form)
        {
            float value = 0;
            EUT55ARegisterAddress address = EUT55ARegisterAddress.SV;

            foreach (CheckBox chk in form.Checks)
            {
                if (chk.Checked == true)
                {
                    EUT55ARegisterSeries tag = (EUT55ARegisterSeries)int.Parse(chk.Tag.ToString());

                    switch (tag)
                    {
                        case EUT55ARegisterSeries.SV:
                            address = EUT55ARegisterAddress.SV;
                            value = float.Parse(form.svEdit.Text);
                            break;

                        case EUT55ARegisterSeries.OUT:
                            address = EUT55ARegisterAddress.MOUT;
                            value = float.Parse(form.outEdit.Text);
                            break;

                        case EUT55ARegisterSeries.Mode:
                            address = EUT55ARegisterAddress.Mode;
                            value = form.modeCombo.SelectedIndex;
                            break;

                        case EUT55ARegisterSeries.P:
                            address = EUT55ARegisterAddress.P;
                            value = float.Parse(form.pEdit.Text);
                            break;

                        case EUT55ARegisterSeries.I:
                            address = EUT55ARegisterAddress.I;
                            value = float.Parse(form.iEdit.Text);
                            break;

                        case EUT55ARegisterSeries.D:
                            address = EUT55ARegisterAddress.D;
                            value = float.Parse(form.dEdit.Text);
                            break;

                        case EUT55ARegisterSeries.FL:
                            address = EUT55ARegisterAddress.FL;
                            value = float.Parse(form.flEdit.Text);
                            break;
                    }
                    
                    Resource.Client.Sender.SetController(
                        NetworkNo, ControllerNo, (int)address, value);
                }
            }
        }
    }
}
