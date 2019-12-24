using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Ulee.Controls;

namespace Hnc.Calorimeter.Client
{
    public partial class FormEtcOption : UlFormEng
    {
        public FormEtcOption()
        {
            InitializeComponent();
        }

        public bool FixedAtmPressure { get { return fixedAtmPressureCheck.Checked; } }
        public bool ForcedInteg { get { return forcedIntegCheck.Checked; } }
        public string ExcelPath { get { return excelPathEdit.Text; } }

        private void FormEtcOption_Load(object sender, EventArgs e)
        {
            Resource.Settings.Load();

            TestOptions opt = Resource.Settings.Options;
            fixedAtmPressureCheck.Checked = opt.FixedAtmPressure;
            forcedIntegCheck.Checked = opt.ForcedInteg;
            excelPathEdit.Text = opt.ExcelPath;
        }

        private void FormEtcOption_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                cancelButton.PerformClick();
            }
        }

        private void selectFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = excelPathEdit.Text;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                excelPathEdit.Text = dialog.SelectedPath;
            }
        }
    }
}
