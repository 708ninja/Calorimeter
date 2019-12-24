using System;
using System.Windows.Forms;

using Ulee.Controls;

namespace Hnc.Calorimeter.Server
{
    public partial class FormUserLogin : UlFormEng
    {
        public FormUserLogin()
        {
            InitializeComponent();
        }

        private void FormUserLogin_Load(object sender, EventArgs e)
        {
            Resource.Db.UserSet.Select();

            userCombo.Items.Clear();
            for (int i=0; i<Resource.Db.UserSet.GetRowCount(); i++)
            {
                Resource.Db.UserSet.Fetch(i);
                userCombo.Items.Add(Resource.Db.UserSet.Name);
            }
        }

        private void FormUserLogin_Enter(object sender, EventArgs e)
        {
            userCombo.Focus();
            userCombo.SelectedIndex = 0;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormUserLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    okButton.PerformClick();
                    break;

                case (char)Keys.Escape:
                    cancelButton.PerformClick();
                    break;
            }
        }
    }
}
