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

namespace Hnc.Calorimeter.Server
{
    public partial class FormCalibratorEdit : UlFormEng
    {
        public string UserID
        { get { return userEdit.Text; } set { userEdit.Text = value; } }

        public string DateTime
        { get { return dateEdit.Text; } set { dateEdit.Text = value; } }

        public string Memo
        { get { return memoEdit.Text; } set { memoEdit.Text = value; } }

        public FormCalibratorEdit()
        {
            InitializeComponent();
        }
    }
}
