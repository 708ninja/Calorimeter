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
    public partial class CtrlDevicePlc : UlUserControlEng
    {
        public List<UlPanel> Views { get; private set; }

        public CtrlDevicePlc()
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
    
            foreach (UlPanel panel in Views)
            {
                panel.Controls.Add(new CtrlPlcView());
            }
        }
    }
}
