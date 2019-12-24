using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;

using Ulee.Controls;

namespace Hnc.Calorimeter.Server
{
    public partial class FormOpenCalibration : UlFormEng
    {
        public int RecNo { get; set; }

        public FormOpenCalibration()
        {
            InitializeComponent();
        }

        private void FormOpenCalibration_Load(object sender, EventArgs e)
        {
            Resource.Db.CalibratorSet.Select();

            calibGrid.DataSource = Resource.Db.CalibratorSet.DataSet.Tables[0];
            calibGridView.Appearance.EvenRow.BackColor = Color.FromArgb(244, 244, 236);
            calibGridView.OptionsView.EnableAppearanceEvenRow = true;
        }

        private void calibGridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedRowHandle > -1)
            {
                DataRow row = view.GetDataRow(view.FocusedRowHandle);
                Resource.Db.CalibratorSet.Fetch(row);
                RecNo = Resource.Db.CalibratorSet.RecNo;
            }
            else
            {
                RecNo = -1;
            }
        }

        private void calibGrid_DoubleClick(object sender, EventArgs e)
        {
            okButton.PerformClick();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (calibGridView.FocusedRowHandle < 1) return;

            if (MessageBox.Show("Do you want to delete selected calibration data?",
                Resource.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                DataRow row = calibGridView.GetDataRow(calibGridView.FocusedRowHandle);
                Resource.Db.CalibratorSet.Fetch(row);

                Resource.Db.Delete(Resource.Db.CalibratorSet.RecNo);
                Resource.Db.CalibratorSet.Select();
            }
        }
    }
}
