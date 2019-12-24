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
    public partial class CtrlDeviceController : UlUserControlEng
    {
        public List<UlPanel> Views { get; private set; }

        public CtrlDeviceController()
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
            Views.Add(view9Panel);
            Views.Add(view10Panel);
            Views.Add(view11Panel);
            Views.Add(view12Panel);
            Views.Add(view13Panel);
            Views.Add(view14Panel);
            Views.Add(view15Panel);
            Views.Add(view16Panel);
            Views.Add(view17Panel);
            Views.Add(view18Panel);
            Views.Add(view19Panel);
            Views.Add(view20Panel);
            Views.Add(view21Panel);
            Views.Add(view22Panel);
            Views.Add(view23Panel);
            Views.Add(view24Panel);
            Views.Add(view25Panel);
            Views.Add(view26Panel);
            Views.Add(view27Panel);
            Views.Add(view28Panel);
            Views.Add(view29Panel);
            Views.Add(view30Panel);
            Views.Add(view31Panel);
            Views.Add(view32Panel);
            Views.Add(view33Panel);

            for (int i = 0; i < Resource.Client.Devices.Controller.Rows.Count; i++)
            {
                ControllerRow<float> row = Resource.Client.Devices.Controller.Rows[i];
                Views[i].Controls.Add(
                    new CtrlControllerView(row.Name, row.NetworkNo, row.Address));
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
                for (int i = 0; i < Resource.Client.Devices.Controller.Rows.Count; i++)
                {
                    (Views[i].Controls[0] as CtrlControllerView).RefreshMeter(
                        Resource.Client.Devices.Controller.Rows[i].Values);
                }
            }
        }
    }
}
