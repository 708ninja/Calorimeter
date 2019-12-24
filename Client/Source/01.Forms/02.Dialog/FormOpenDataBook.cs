﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;

using Ulee.Controls;

namespace Hnc.Calorimeter.Client
{
    public partial class FormOpenDataBook : UlFormEng
    {
        public FormOpenDataBook(int handle)
        {
            InitializeComponent();

            this.handle = handle;
            Initialize();
        }

        private int handle;
        private DataBookDataSet dataSet;
        public Int64 RecNo { get; private set; }

        private void Initialize()
        {
            RecNo = -1;
            dataSet = Resource.ViewDB.DataBookSet;
        }

        private void FormOpenDataBook_Load(object sender, EventArgs e)
        {
            dataBookGridView.Appearance.EvenRow.BackColor = Color.FromArgb(244, 244, 236);
            dataBookGridView.OptionsView.EnableAppearanceEvenRow = true;

            dbStateColumn.DisplayFormat.FormatType = FormatType.Custom;
            dbStateColumn.DisplayFormat.Format = new DataBookStateTypeFmt();

            dbTestLineColumn.DisplayFormat.FormatType = FormatType.Custom;
            dbTestLineColumn.DisplayFormat.Format = new DataBookLineTypeFmt();

            resetButton.PerformClick();
            dataBookGrid.DataSource = dataSet.DataSet.Tables[0];
        }

        private void FormOpenDataBook_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                cancelButton.PerformClick();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SetCondition();

            Resource.ViewDB.Lock();
            try
            {
                dataSet.Select();
            }
            finally
            {
                Resource.ViewDB.Unlock();
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            ResetCondition();
            searchButton.PerformClick();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (dataBookGridView.FocusedRowHandle < 0) return;

            DataRow row = dataBookGridView.GetDataRow(dataBookGridView.FocusedRowHandle);
            RecNo = Convert.ToInt64(row["pk_recno"]);
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            RecNo = -1;
            Close();
        }

        private void fromDateEdit_ValueChanged(object sender, EventArgs e)
        {
            if (fromDateEdit.Value > toDateEdit.Value)
            {
                toDateEdit.Value = fromDateEdit.Value;
            }
        }

        private void toDateEdit_ValueChanged(object sender, EventArgs e)
        {
            if (toDateEdit.Value < fromDateEdit.Value)
            {
                fromDateEdit.Value = toDateEdit.Value;
            }
        }

        private void dataBookGridView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "State")
            {
                switch ((ETestState)e.CellValue)
                {
                    case ETestState.Stopped:
                        e.Appearance.ForeColor = Color.Red;
                        break;

                    case ETestState.Testing:
                        e.Appearance.ForeColor = Color.Black;
                        break;

                    case ETestState.Done:
                        e.Appearance.ForeColor = Color.Blue;
                        break;
                }

                e.Handled = true;
            }
        }

        private void dataBookGrid_DoubleClick(object sender, EventArgs e)
        {
            //if (dataBookGridView.FocusedRowHandle < 0) return;

            //okButton.PerformClick();
        }

        private void dataBookGridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            //if (e.FocusedRowHandle < 0)
            //{
            //    RecNo = -1;
            //    return;
            //}

            //Resource.Db.Lock();
            //try
            //{
            //    DataRow row = dataBookGridView.GetDataRow(e.FocusedRowHandle);
            //    RecNo = Convert.ToInt64(row["pk_recno"]);
            //}
            //finally
            //{
            //    Resource.Db.Unlock();
            //}
        }

        private void SetCondition()
        {
            dataSet.Condition.TimeUsed = dateCheck.Checked;
            dataSet.Condition.FromTime = fromDateEdit.Value;
            dataSet.Condition.ToTime = toDateEdit.Value;
            dataSet.Condition.Line = lineCombo.SelectedIndex;
            dataSet.Condition.State = stateCombo.SelectedIndex;
        }

        private void ResetCondition()
        {
            dateCheck.Checked = true;
            fromDateEdit.Value = DateTime.Now.AddDays(-30);
            toDateEdit.Value = DateTime.Now;

            lineCombo.SelectedIndex = 0;
            stateCombo.SelectedIndex = 0;
        }
    }
}
