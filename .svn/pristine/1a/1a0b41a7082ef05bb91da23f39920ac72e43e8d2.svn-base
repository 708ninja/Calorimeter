using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Ulee.Controls;

namespace Hnc.Calorimeter.Server
{
    public partial class CtrlCalibTop : UlUserControlEng
    {
        public CtrlCalibTop()
        {
            InitializeComponent();
            Initialize();
        }

        private void CtrlCalibTop_Enter(object sender, EventArgs e)
        {
            DispName();
        }

        private void DispName()
        {
            int calibNo = Resource.Ini.GetInteger("Calibrator", "CalibrationNo");

            if (calibNo < 0)
            {
                nameEdit.Text = " None";
            }
            else
            {
                nameEdit.Text = " " + Resource.Db.CalibratorSet.GetMemo(calibNo);
            }
        }

        private void Initialize()
        {
            foreach (KeyValuePair<string, Dictionary<int, CalibratorRow>> row 
                in Resource.Server.Devices.Calibrators.Category)
            {
                CtrlCalibGrid ctrl = new CtrlCalibGrid(row.Value.Values.ToList());
                ctrl.SetEnableColumn(3);
                ctrl.RefreshView += DoRefreshView;

                TabPage page = new TabPage($" {row.Key} ");
                page.Controls.Add(ctrl);
                page.BackColor = Color.White;
                calibTab.TabPages.Add(page);
            }

            totalPointsCombo.SelectedIndex = 1;
        }

        private void DoRefreshView(object sender, EventArgs args)
        {
            foreach (TabPage page in calibTab.TabPages)
            {
                CtrlCalibGrid ctrl = page.Controls[0] as CtrlCalibGrid;

                ctrl.channelGridView.RefreshData();
            }
        }

        private void totalPointsCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (calibTab.SelectedTab == null) return;

            (calibTab.SelectedTab.Controls[0] as CtrlCalibGrid)
                .SetEnableColumn(totalPointsCombo.SelectedIndex + 2);
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            if (calibTab.SelectedTab == null) return;

            (calibTab.SelectedTab.Controls[0] as CtrlCalibGrid)
                .SetValueSV(float.Parse(svEdit.Text));
        }

        private void getPvButton_Click(object sender, EventArgs e)
        {
            if (calibTab.SelectedTab == null) return;

            (calibTab.SelectedTab.Controls[0] as CtrlCalibGrid)
                .SetValuePV();
        }

        private void calibrateButton_Click(object sender, EventArgs e)
        {
            if (calibTab.SelectedTab == null) return;

            (calibTab.SelectedTab.Controls[0] as CtrlCalibGrid)
                .Calibrate();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            FormOpenCalibration form = new FormOpenCalibration();

            if (form.ShowDialog() == DialogResult.OK)
            {
                Resource.Ini.SetInteger("Calibrator", "CalibrationNo", form.RecNo);
                Resource.Db.Load(form.RecNo);
                DispName();
                DoRefreshView(null, null);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            FormCalibratorEdit form = new FormCalibratorEdit();
            form.UserID = " " + Resource.Db.UserSet.GetName(Resource.UserNo);
            form.DateTime = DateTime.Now.ToString(" yyyy-MM-dd HH:mm:ss");
            form.Memo = $"Calibration{form.DateTime.Trim().Substring(0, 10)}";

            if (form.ShowDialog() == DialogResult.OK)
            {
                int recNo = (int)Resource.Db.GetGenNo("GN_CALIBRATOR");
                Resource.Db.Save(recNo, Resource.UserNo, DateTime.Now, form.Memo);
                Resource.Ini.SetInteger("Calibrator", "CalibrationNo", recNo);
                DispName();
            }
        }

        public override void InvalidControl(object sender, EventArgs args)
        {
            if (Visible == false) return;

            List<CalibratorRow> rows = Resource.Server.Devices.Calibrators["All"].Values.ToList();

            foreach (CalibratorRow row in rows)
            {
                row.Raw = Resource.Server.Devices.GetRecorderRawValue(row.No);
                row.Real = Resource.Server.Devices.GetRecorderRealValue(row.No);
            }

            DoRefreshView(null, null);
        }
    }
}
