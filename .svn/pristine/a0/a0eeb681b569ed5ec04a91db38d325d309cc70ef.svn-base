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
    public partial class CtrlViewTop : UlUserControlEng
    {
        public CtrlViewTop()
        {
            InitializeComponent();
        }

        private void CtrlViewTop_Load(object sender, EventArgs e)
        {
            DefMenu = new UlMenu(viewPanel);
            DefMenu.Add(new CtrlViewClient(), clientButton);
            DefMenu.Add(new CtrlViewDevice(), deviceButton);
            DefMenu.Add(new CtrlViewValue(), valueButton);
            DefMenu.Index = 0;
        }

        private void CtrlViewTop_Enter(object sender, EventArgs e)
        {
        }
    }
}
