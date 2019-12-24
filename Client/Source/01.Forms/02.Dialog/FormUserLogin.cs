using System;
using System.Windows.Forms;

using Ulee.Controls;

namespace Hnc.Calorimeter.Client
{
    public partial class FormUserLogin : UlFormEng
    {
        public ComboBox UserCombo { get { return userCombo; } }
        public DevExpress.XtraEditors.TextEdit PasswdEdit { get { return passwdEdit; } }
        public CheckBox SaveCheck { get { return saveCheck; } }

        public FormUserLogin()
        {
            InitializeComponent();
        }

        private void FormUserLogin_Load(object sender, EventArgs e)
        {
            Resource.ConfigDB.Lock();

            try
            {
                Resource.ConfigDB.UserSet.Select();

                userCombo.Items.Clear();
                for (int i = 0; i < Resource.ConfigDB.UserSet.GetRowCount(); i++)
                {
                    Resource.ConfigDB.UserSet.Fetch(i);
                    userCombo.Items.Add(Resource.ConfigDB.UserSet.Name);
                }
            }
            finally
            {
                Resource.ConfigDB.Unlock();
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
