﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ulee.Controls;

namespace Hnc.Calorimeter.Client
{
    public partial class CtrlDevicePowerMeter : UlUserControlEng
    {
        public List<UlPanel> Views { get; private set; }

        public CtrlDevicePowerMeter()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Views = new List<UlPanel>();
            Views.Add(view1Panel);
            Views.Add(view2Panel);
            Views.Add(view3Panel);
            Views.Add(view4Panel);
            Views.Add(view5Panel);
            Views.Add(view6Panel);
            Views.Add(view7Panel);
            Views.Add(view8Panel);

            for (int i=0; i<Resource.Client.Devices.PowerMeter.Rows.Count; i++)
            {
                Views[i].Controls.Add(new CtrlPowerMeterView(
                    Resource.Client.Devices.PowerMeter.Rows[i].Name));
            }
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
                for (int i = 0; i < Resource.Client.Devices.PowerMeter.Rows.Count; i++)
                {
                    (Views[i].Controls[0] as CtrlPowerMeterView).RefreshMeter(
                        Resource.Client.Devices.PowerMeter.Rows[i].Phase, 
                        Resource.Client.Devices.PowerMeter.Rows[i].Values);
                }
            }
        }
    }
}
