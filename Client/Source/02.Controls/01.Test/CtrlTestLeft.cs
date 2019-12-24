﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ulee.Controls;

namespace Hnc.Calorimeter.Client
{
    public partial class CtrlTestLeft : UlUserControlEng
    {
        public CtrlTestLeft()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            DefMenu = new UlMenu(viewPanel);
            DefMenu.Add(new CtrlTestRight(0), line1Button);
            DefMenu.Add(new CtrlTestRight(1), line2Button);
            DefMenu.Add(new CtrlTestRight(2), line3Button);
            DefMenu.Add(new CtrlTestRight(3), line4Button);
        }

        private void CtrlTestTop_Load(object sender, EventArgs e)
        {
            DefMenu.Index = 0;
        }
    }
}
