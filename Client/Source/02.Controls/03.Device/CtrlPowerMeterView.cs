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
    public partial class CtrlPowerMeterView : UlUserControlEng
    {
        public CtrlPowerMeterView(string name)
        {
            InitializeComponent();

            titleEdit.Text = name;
            Initialize();
        }

        private List<UlPanel> meters;

        private void Initialize()
        {
            meters = new List<UlPanel>();

            meters.Add(powerREdit);
            meters.Add(voltREdit);
            meters.Add(currentREdit);
            meters.Add(hzREdit);
            meters.Add(pfREdit);
            meters.Add(whREdit);

            meters.Add(powerSEdit);
            meters.Add(voltSEdit);
            meters.Add(currentSEdit);
            meters.Add(hzSEdit);
            meters.Add(pfSEdit);
            meters.Add(whSEdit);

            meters.Add(powerTEdit);
            meters.Add(voltTEdit);
            meters.Add(currentTEdit);
            meters.Add(hzTEdit);
            meters.Add(pfTEdit);
            meters.Add(whTEdit);

            meters.Add(powerSigmaEdit);
            meters.Add(voltSigmaEdit);
            meters.Add(currentSigmaEdit);
            meters.Add(hzSigmaEdit);
            meters.Add(pfSigmaEdit);
            meters.Add(whSigmaEdit);

            meters.Add(integTimeEdit);
        }

        public void RefreshMeter(EWT330Phase phase, List<DeviceValueRow<float>> rows)
        {
            for (int i = 0; i < 24; i++)
            {
                meters[i].Text = $"{rows[i].Value:f1}";
            }
            meters[24].Text = $"{rows[24].Value:f0}";

            //if (phase == EWT330Phase.P1)
            //{
            //    for (int i = 0; i < 6; i++)
            //    {
            //        meters[i].Text = $"{rows[i].Value:f1}";
            //    }
            //    meters[24].Text = $"{rows[6].Value:f0}";

            //    for (int i = 0; i < 19; i++)
            //    {
            //        meters[i+6].Text = "0.0";
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < 24; i++)
            //    {
            //        meters[i].Text = $"{rows[i].Value:f1}";
            //    }
            //    meters[24].Text = $"{rows[24].Value:f0}";
            //}
        }
    }
}
