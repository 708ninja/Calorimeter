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

namespace Hnc.Calorimeter.Server
{
    public partial class FormUserEdit : UlFormEng
    {
        public string UserName
        {
            get { return userNameEdit.Text; }
            set { userNameEdit.Text = value; }
        }

        public int Authority
        {
            get { return userGradeCombo.SelectedIndex + 1; }
            set { userGradeCombo.SelectedIndex = value - 1; }
        }

        public string Password
        {
            get { return userPasswdEdit.Text; }
            set { userPasswdEdit.Text = value; }
        }

        public string Memo
        {
            get { return userMemoEdit.Text; }
            set { userMemoEdit.Text = value; }
        }

        public FormUserEdit()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (userNameEdit.Text.Trim() == "")
            {
                ActiveControl = userNameEdit;
                return;
            }

            Close();
        }
    }
}
