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
    public partial class CtrlDeviceRecorder : UlUserControlEng
    {
        public List<UlPanel> Views { get; private set; }

        public CtrlDeviceRecorder()
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

            for (int i = 0; i < Resource.Client.Devices.Recorder.Rows.Count; i++)
            {
                Views[i].Controls.Add(new CtrlRecorderView(
                    Resource.Client.Devices.Recorder.Rows[i].Name,
                    Resource.Client.Devices.Recorder.Rows[i].Values));
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
                for (int i = 0; i < Resource.Client.Devices.Recorder.Rows.Count; i++)
                {
                    (Views[i].Controls[0] as CtrlRecorderView).RefreshMeter();
                }
            }
        }
    }
}
