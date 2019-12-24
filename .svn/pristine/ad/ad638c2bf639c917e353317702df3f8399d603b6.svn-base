using System;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

using Ulee.Controls;

namespace Hnc.Calorimeter.Server
{
    public partial class CtrlConfigTop : UlUserControlEng
    {
        public CtrlConfigTop()
        {
            InitializeComponent();
        }

        private void CtrlConfigTop_Load(object sender, EventArgs e)
        {
            Resource.Db.UserSet.Select();
            userGrid.DataSource = Resource.Db.UserSet.DataSet.Tables[0];

            userGridView.Appearance.EvenRow.BackColor = Color.FromArgb(244, 244, 236);
            userGridView.OptionsView.EnableAppearanceEvenRow = true;

            userGridGradeColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            userGridGradeColumn.DisplayFormat.Format = new AuthorityTypeFmt();
        }

        private void CtrlConfigTop_Enter(object sender, EventArgs e)
        {
            Resource.Db.UserSet.Select();
            userGrid.Refresh();
        }

        private void userAddButton_Click(object sender, EventArgs e)
        {
            FormUserEdit form = new FormUserEdit();
            form.Text = "New";
            form.Authority = 3;

            lbUserAddRetry:
            form.ShowDialog();

            if (form.DialogResult == DialogResult.Cancel) return;

            if (form.UserName.Trim() == "")
            {
                MessageBox.Show("You must keyin User ID!",
                    Resource.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                goto lbUserAddRetry;
            }

            if (form.Password.Length < 4)
            {
                MessageBox.Show("Password's length must be larger than 3bytes!",
                    Resource.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                goto lbUserAddRetry;
            }

            UserDataSet set = Resource.Db.UserSet;
            set.RecNo = (int)Resource.Db.GetGenNo("GN_USER");
            set.Name = form.UserName;
            set.Authority = form.Authority;
            set.Passwd = Convert.ToBase64String(Encoding.ASCII.GetBytes(form.Password));
            set.Memo = form.Memo;

            try
            {
                set.Insert();
            }
            catch (Exception ex)
            {
                Resource.TLog.Log((int)ELogItem.Exception, ex.ToString());
            }
            finally
            {
                Resource.Db.UserSet.Select();
                userGrid.Refresh();
            }
        }

        private void userUpdateButton_Click(object sender, EventArgs e)
        {
            if (userGridView.FocusedRowHandle < 0) return;

            UserDataSet set = Resource.Db.UserSet;
            FormUserEdit form = new FormUserEdit();
            form.Text = "Modify";
            form.UserName = set.Name;
            form.Authority = set.Authority;
            form.Password = Encoding.ASCII.GetString(Convert.FromBase64String(set.Passwd));
            form.Memo = set.Memo;

            lbUserModifyRetry:
            form.ShowDialog();

            if (form.DialogResult == DialogResult.Cancel) return;

            if (form.UserName.Trim() == "")
            {
                MessageBox.Show("You must keyin User ID!",
                    Resource.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                goto lbUserModifyRetry;
            }

            if (form.Password.Length < 4)
            {
                MessageBox.Show("Password's length must be larger than 3bytes!",
                    Resource.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                goto lbUserModifyRetry;
            }

            set.Name = form.UserName;
            set.Authority = form.Authority;
            set.Passwd = Convert.ToBase64String(Encoding.ASCII.GetBytes(form.Password));
            set.Memo = form.Memo;

            try
            {
                set.Update();
            }
            catch (Exception ex)
            {
                Resource.TLog.Log((int)ELogItem.Exception, ex.ToString());
            }
            finally
            {
                Resource.Db.UserSet.Select();
                userGrid.Refresh();
            }
        }

        private void userDeleteButton_Click(object sender, EventArgs e)
        {
            if (userGridView.FocusedRowHandle < 0) return;

            if (MessageBox.Show("Do you want to delete selected user?",
                Resource.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                try
                {
                    Resource.Db.UserSet.Delete();
                }
                catch (Exception ex)
                {
                    Resource.TLog.Log((int)ELogItem.Exception, ex.ToString());
                }
                finally
                {
                    Resource.Db.UserSet.Select();
                    userGrid.Refresh();
                }
            }
        }

        private void userGrid_DoubleClick(object sender, EventArgs e)
        {
            if (userGridView.FocusedRowHandle < 0) return;

            userUpdateButton.PerformClick();
        }

        private void userGridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedRowHandle > -1)
            {
                DataRow row = view.GetDataRow(view.FocusedRowHandle);
                Resource.Db.UserSet.Fetch(row);
            }
        }
    }
}
