using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.Spreadsheet;
using DevExpress.XtraEditors;
using DevExpress.XtraSpreadsheet;

using Ulee.Chart;
using Ulee.Controls;
using Ulee.DllImport.Win32;

namespace Hnc.Calorimeter.Client
{
    public partial class FormSaveDataRaw : UlFormEng
    {
        public FormSaveDataRaw()
        {
            InitializeComponent();
            Cancel = false;
        }

        public bool Cancel;


        public ProgressBarControl SavingProgress
        { get { return savingProgress; } }

        private void FormSaveDataRaw_Shown(object sender, EventArgs e)
        {
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Cancel = true;
            Close();
        }
    }
}
