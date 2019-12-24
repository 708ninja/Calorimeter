﻿using System;
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
    public partial class FormAllParamEdit : UlFormEng
    {
        public FormAllParamEdit()
        {
            InitializeComponent();
        }

        public DevExpress.XtraEditors.TextEdit UserNameEdit { get { return userNameEdit; } }

        public DevExpress.XtraEditors.TextEdit DateTimeEdit { get { return dateTimeEdit; } }

        public DevExpress.XtraEditors.TextEdit MemoEdit { get { return memoEdit; } }

        private void FormAllParamEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                cancelButton.PerformClick();
            }
        }
    }
}
