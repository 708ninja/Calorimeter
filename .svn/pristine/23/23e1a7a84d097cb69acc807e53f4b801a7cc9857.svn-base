using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.Utils;

using Ulee.Controls;

namespace Hnc.Calorimeter.Server
{
    public partial class CtrlViewClient : UlUserControlEng
    {
        public CtrlViewClient()
        {
            InitializeComponent();
            Initialize();            
        }

        private void Initialize()
        {
            clientGrid.DataSource = Resource.Server.ClientList;

            clientGridView.Appearance.EvenRow.BackColor = Color.FromArgb(244, 244, 236);
            clientGridView.OptionsView.EnableAppearanceEvenRow = true;

            Resource.Server.Listener.ChangedClients += InvalidGrid;
        }

        private void CtrlViewClient_Enter(object sender, EventArgs e)
        {
            clientGridView.RefreshData();
        }

        private void InvalidGrid(object sender, EventArgs e)
        {
            if (this.InvokeRequired == true)
            {
                EventHandler func = new EventHandler(InvalidGrid);
                this.BeginInvoke(func, new object[] { sender, e });
            }
            else
            {
                clientGridView.RefreshData();
            }
        }
    }
}
