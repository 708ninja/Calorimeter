using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

using Ulee.Controls;

namespace Hnc.Calorimeter.Client
{
    public partial class FormOpenAllParam : UlFormEng
    {
        public FormOpenAllParam()
        {
            InitializeComponent();
            Initialize();
        }

        public int RecNo { get; private set; }
        public GridView ParamGridView { get { return paramGridView; } }

        private void Initialize()
        {
            RecNo = -1;
            paramGridView.Appearance.EvenRow.BackColor = Color.FromArgb(244, 244, 236);
            paramGridView.OptionsView.EnableAppearanceEvenRow = true;
        }

        private void FormOpenAllParam_Load(object sender, EventArgs e)
        {
            Resource.ConfigDB.Lock();

            try
            {
                Resource.ConfigDB.AllParamSet.Select();
                paramGrid.DataSource = Resource.ConfigDB.AllParamSet.DataSet.Tables[0];
            }
            finally
            {
                Resource.ConfigDB.Unlock();
            }
        }

        private void schDeleteButton_Click(object sender, EventArgs e)
        {
            if (paramGridView.FocusedRowHandle < 0) return;

            if (MessageBox.Show("Would you like to delete a parameter focused?",
                Resource.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.No)
            {
                return;
            }

            Resource.ConfigDB.Lock();
            try
            {
                Resource.ConfigDB.DeleteAllParam(Resource.ConfigDB.AllParamSet.RecNo);
                Resource.ConfigDB.AllParamSet.Select();
            }
            finally
            {
                Resource.ConfigDB.Unlock();
            }
        }

        private void paramGridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
            {
                RecNo = -1;
                return;
            }

            DataRow row = paramGridView.GetDataRow(e.FocusedRowHandle);

            Resource.ConfigDB.Lock();
            try
            {
                Resource.ConfigDB.AllParamSet.Fetch(row);
                RecNo = Resource.ConfigDB.AllParamSet.RecNo;
            }
            finally
            {
                Resource.ConfigDB.Unlock();
            }
        }

        private void paramGrid_DoubleClick(object sender, EventArgs e)
        {
            if (paramGridView.FocusedRowHandle < 0) return;

            okButton.PerformClick();
        }

        private void FormOpenAllParam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                cancelButton.PerformClick();
            }
        }
    }
}
