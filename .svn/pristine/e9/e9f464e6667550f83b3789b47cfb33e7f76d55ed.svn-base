using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ulee.Controls;

namespace Hnc.Calorimeter.Client
{
    public partial class FormControllerEdit : UlFormEng
    {
        public FormControllerEdit()
        {
            InitializeComponent();
            Initialize();
        }

        public List<CheckBox> Checks;

        private void Initialize()
        {
            Checks = new List<CheckBox>();
            Checks.Add(svCheck);
            Checks.Add(outCheck);
            Checks.Add(modeCheck);
            Checks.Add(pCheck);
            Checks.Add(iCheck);
            Checks.Add(dCheck);
            Checks.Add(flCheck);
        }

        private void FormControllerEdit_Load(object sender, EventArgs e)
        {
            foreach (CheckBox chk in Checks)
            {
                chk.Checked = false;
            }

            modeCombo.SelectedIndex = 0;
        }

        private void FormControllerEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                cancelButton.PerformClick();
            }
        }
    }
}
