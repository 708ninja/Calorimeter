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
using Ulee.Device.Connection;

namespace Hnc.Calorimeter.Server
{
    public partial class FormDeviceEdit : UlFormEng
    {
        public FormDeviceEdit()
        {
            InitializeComponent();

            linkCombo.Items.Clear();
            linkCombo.Items.Add(EEthernetLink.Disconnect.ToString());
            linkCombo.Items.Add(EEthernetLink.Connect.ToString());

            modeCombo.Items.Clear();
            modeCombo.Items.Add(EEthernetMode.Real.ToString());
            modeCombo.Items.Add(EEthernetMode.Virtual.ToString());
        }

        private void FormDeviceEdit_Load(object sender, EventArgs e)
        {
            ActiveControl = linkCombo;
        }

        private void linkCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((EEthernetLink)linkCombo.SelectedIndex == EEthernetLink.Disconnect)
            {
                modeCombo.SelectedIndex = (int)EEthernetMode.Virtual;
            }
        }

        private void modeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((EEthernetMode)modeCombo.SelectedIndex == EEthernetMode.Real)
            {
                linkCombo.SelectedIndex = (int)EEthernetLink.Connect;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
