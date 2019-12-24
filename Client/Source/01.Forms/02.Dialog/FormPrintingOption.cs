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
    public partial class FormPrintingOption : UlFormEng
    {
        public FormPrintingOption()
        {
            InitializeComponent();
        }

        public bool AutoExcel { get { return autoExcelCheck.Checked; } }
        public bool StoppedTestExcel { get { return stoppedTestExcelCheck.Checked; } }
        public bool Indoor11 { get { return indoor11Check.Checked; } }
        public bool Indoor12 { get { return indoor12Check.Checked; } }
        public bool Indoor21 { get { return indoor21Check.Checked; } }
        public bool Indoor22 { get { return indoor22Check.Checked; } }
        public bool IndoorTC1 { get { return indoorTC1Check.Checked; } }
        public bool IndoorTC2 { get { return indoorTC2Check.Checked; } }
        public bool OutdoorTC { get { return outdoorTCCheck.Checked; } }

        private void FormPrintingOption_Load(object sender, EventArgs e)
        {
            Resource.Settings.Load();

            TestOptions opt = Resource.Settings.Options;
            autoExcelCheck.Checked = opt.AutoExcel;
            stoppedTestExcelCheck.Checked = opt.StoppedTestExcel;
            indoor11Check.Checked = opt.Indoor11;
            indoor12Check.Checked = opt.Indoor12;
            indoor21Check.Checked = opt.Indoor21;
            indoor22Check.Checked = opt.Indoor22;
            indoorTC1Check.Checked = opt.Indoor1TC;
            indoorTC2Check.Checked = opt.Indoor2TC;
            outdoorTCCheck.Checked = opt.OutdoorTC;
        }

        private void FormPrintingOption_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                cancelButton.PerformClick();
            }
        }
    }
}
