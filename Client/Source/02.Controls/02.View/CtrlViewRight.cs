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
    public partial class CtrlViewRight : UlUserControlEng
    {
        public CtrlViewRight(int handle)
        {
            InitializeComponent();

            this.handle = handle;
            Initialize();
        }

        private int handle;
        private Int64 recNo;

        private void Initialize()
        {
            recNo = -1;

            DefMenu = new UlMenu(viewPanel);
            DefMenu.Add(new CtrlViewReport(handle), reportButton);
            DefMenu.Add(new CtrlViewGraph(handle), graphButton);
        }

        private void CtrlViewBottom_Load(object sender, EventArgs e)
        {
            DefMenu.Index = 0;
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            OpenDataBookDialog();
        }

        private void excelButton_Click(object sender, EventArgs e)
        {
            if (recNo < 0)
            {
                MessageBox.Show("You must open test data before running this function!",
                    Resource.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show("Do you want saving test data to excel file?",
                Resource.Caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                == DialogResult.Cancel) return;

            (DefMenu.Controls(0) as CtrlViewReport).SaveExcel();
            (DefMenu.Controls(1) as CtrlViewGraph).SaveExcel();
        }

        private void OpenDataBookDialog()
        {
            FormOpenDataBook form = new FormOpenDataBook(handle);

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.RecNo >= 0)
                {
                    recNo = form.RecNo;

                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        (DefMenu.Controls(0) as CtrlViewReport).Open(recNo);
                        (DefMenu.Controls(1) as CtrlViewGraph).Open(recNo);
                    }
                    finally
                    {
                        Cursor = Cursors.Arrow;
                    }
                }
            }
        }
    }
}
