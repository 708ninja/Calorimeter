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

namespace Hnc.Calorimeter.Client
{
    public partial class CtrlDeviceLeft : UlUserControlEng
    {
        public CtrlDeviceLeft()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            DefMenu = new UlMenu(viewPanel);
            DefMenu.Add(new CtrlDeviceAll(), allButton);
            DefMenu.Add(new CtrlDevicePowerMeter(), powerMeterButton);
            DefMenu.Add(new CtrlDeviceRecorder(), recorderButton);
            DefMenu.Add(new CtrlDeviceController(), controllerButton);
            DefMenu.Add(new CtrlDevicePlc(), plcButton);
        }

        private void CtrlDeviceTop_Load(object sender, EventArgs e)
        {
            DefMenu.Index = 0;
        }
    }
}
