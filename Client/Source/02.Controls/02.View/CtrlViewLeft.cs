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
    public partial class CtrlViewLeft : UlUserControlEng
    {
        public CtrlViewLeft()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            DefMenu = new UlMenu(viewPanel);
            DefMenu.Add(new CtrlViewRight(0), testView1Button);
            DefMenu.Add(new CtrlViewRight(1), testView2Button);
            DefMenu.Add(new CtrlViewRight(2), testView3Button);
            DefMenu.Add(new CtrlViewRight(3), testView4Button);
        }

        private void CtrlViewTop_Load(object sender, EventArgs e)
        {
            DefMenu.Index = 0;
        }
    }
}
