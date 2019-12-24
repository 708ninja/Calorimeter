using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ulee.Controls;

namespace Hnc.Calorimeter.Client
{
    public partial class CtrlRecorderView : UlUserControlEng
    {
        public CtrlRecorderView(string name, List<DeviceValueRow<float>> values)
        {
            InitializeComponent();
            titleEdit.Text = name;

            recorderGrid.DataSource = values;
            recorderGridView.Appearance.EvenRow.BackColor = Color.FromArgb(244, 244, 236);
            recorderGridView.OptionsView.EnableAppearanceEvenRow = true;
        }

        private void CtrlRecorderView_Load(object sender, EventArgs e)
        {
        }

        public void RefreshMeter()
        {
            recorderGridView.RefreshData();
        }
    }
}
