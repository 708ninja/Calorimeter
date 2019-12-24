namespace Hnc.Calorimeter.Server
{
    partial class CtrlConfigTop
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlConfigTop));
            this.userGridNameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.userGrid = new DevExpress.XtraGrid.GridControl();
            this.userGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.userGridGradeColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.userGridPasswdColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.userGridMemoColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.userDeleteButton = new System.Windows.Forms.Button();
            this.userUpdateButton = new System.Windows.Forms.Button();
            this.userAddButton = new System.Windows.Forms.Button();
            this.bgPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // bgPanel
            // 
            this.bgPanel.BevelOuter = Ulee.Controls.EUlBevelStyle.None;
            this.bgPanel.Controls.Add(this.userGrid);
            this.bgPanel.Controls.Add(this.userDeleteButton);
            this.bgPanel.Controls.Add(this.userUpdateButton);
            this.bgPanel.Controls.Add(this.userAddButton);
            this.bgPanel.Size = new System.Drawing.Size(992, 645);
            // 
            // userGridNameColumn
            // 
            this.userGridNameColumn.AppearanceCell.BorderColor = System.Drawing.Color.Transparent;
            this.userGridNameColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userGridNameColumn.AppearanceCell.ForeColor = System.Drawing.Color.Black;
            this.userGridNameColumn.AppearanceCell.Options.UseBorderColor = true;
            this.userGridNameColumn.AppearanceCell.Options.UseFont = true;
            this.userGridNameColumn.AppearanceCell.Options.UseForeColor = true;
            this.userGridNameColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userGridNameColumn.AppearanceHeader.Options.UseFont = true;
            this.userGridNameColumn.Caption = "User ID";
            this.userGridNameColumn.FieldName = "NAME";
            this.userGridNameColumn.Name = "userGridNameColumn";
            this.userGridNameColumn.OptionsColumn.AllowEdit = false;
            this.userGridNameColumn.OptionsColumn.AllowFocus = false;
            this.userGridNameColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.userGridNameColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.userGridNameColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.userGridNameColumn.OptionsColumn.AllowMove = false;
            this.userGridNameColumn.OptionsColumn.AllowShowHide = false;
            this.userGridNameColumn.OptionsColumn.AllowSize = false;
            this.userGridNameColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.userGridNameColumn.OptionsColumn.FixedWidth = true;
            this.userGridNameColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.userGridNameColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.userGridNameColumn.OptionsColumn.ReadOnly = true;
            this.userGridNameColumn.OptionsColumn.TabStop = false;
            this.userGridNameColumn.Visible = true;
            this.userGridNameColumn.VisibleIndex = 0;
            // 
            // userGrid
            // 
            this.userGrid.Location = new System.Drawing.Point(0, 0);
            this.userGrid.MainView = this.userGridView;
            this.userGrid.Margin = new System.Windows.Forms.Padding(2);
            this.userGrid.Name = "userGrid";
            this.userGrid.Size = new System.Drawing.Size(867, 645);
            this.userGrid.TabIndex = 8;
            this.userGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.userGridView});
            this.userGrid.DoubleClick += new System.EventHandler(this.userGrid_DoubleClick);
            // 
            // userGridView
            // 
            this.userGridView.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userGridView.Appearance.EvenRow.Options.UseFont = true;
            this.userGridView.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userGridView.Appearance.FocusedCell.Options.UseFont = true;
            this.userGridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userGridView.Appearance.FocusedRow.Options.UseFont = true;
            this.userGridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userGridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.userGridView.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userGridView.Appearance.HideSelectionRow.Options.UseFont = true;
            this.userGridView.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userGridView.Appearance.OddRow.Options.UseFont = true;
            this.userGridView.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userGridView.Appearance.Row.Options.UseFont = true;
            this.userGridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userGridView.Appearance.SelectedRow.Options.UseFont = true;
            this.userGridView.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userGridView.Appearance.ViewCaption.Options.UseFont = true;
            this.userGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.userGridNameColumn,
            this.userGridGradeColumn,
            this.userGridPasswdColumn,
            this.userGridMemoColumn});
            gridFormatRule1.Column = this.userGridNameColumn;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = "ghdkd";
            gridFormatRule1.Rule = formatConditionRuleValue1;
            this.userGridView.FormatRules.Add(gridFormatRule1);
            this.userGridView.GridControl = this.userGrid;
            this.userGridView.Name = "userGridView";
            this.userGridView.OptionsBehavior.Editable = false;
            this.userGridView.OptionsBehavior.ReadOnly = true;
            this.userGridView.OptionsCustomization.AllowGroup = false;
            this.userGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.userGridView.OptionsView.ShowGroupPanel = false;
            this.userGridView.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveVertScroll;
            this.userGridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.userGridView_FocusedRowChanged);
            // 
            // userGridGradeColumn
            // 
            this.userGridGradeColumn.AppearanceCell.BorderColor = System.Drawing.Color.Transparent;
            this.userGridGradeColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userGridGradeColumn.AppearanceCell.ForeColor = System.Drawing.Color.Black;
            this.userGridGradeColumn.AppearanceCell.Options.UseBorderColor = true;
            this.userGridGradeColumn.AppearanceCell.Options.UseFont = true;
            this.userGridGradeColumn.AppearanceCell.Options.UseForeColor = true;
            this.userGridGradeColumn.AppearanceCell.Options.UseTextOptions = true;
            this.userGridGradeColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.userGridGradeColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userGridGradeColumn.AppearanceHeader.Options.UseFont = true;
            this.userGridGradeColumn.Caption = "Authority";
            this.userGridGradeColumn.FieldName = "AUTHORITY";
            this.userGridGradeColumn.Name = "userGridGradeColumn";
            this.userGridGradeColumn.OptionsColumn.AllowEdit = false;
            this.userGridGradeColumn.OptionsColumn.AllowFocus = false;
            this.userGridGradeColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.userGridGradeColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.userGridGradeColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.userGridGradeColumn.OptionsColumn.AllowMove = false;
            this.userGridGradeColumn.OptionsColumn.AllowShowHide = false;
            this.userGridGradeColumn.OptionsColumn.AllowSize = false;
            this.userGridGradeColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.userGridGradeColumn.OptionsColumn.FixedWidth = true;
            this.userGridGradeColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.userGridGradeColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.userGridGradeColumn.OptionsColumn.ReadOnly = true;
            this.userGridGradeColumn.OptionsColumn.TabStop = false;
            this.userGridGradeColumn.Visible = true;
            this.userGridGradeColumn.VisibleIndex = 1;
            // 
            // userGridPasswdColumn
            // 
            this.userGridPasswdColumn.AppearanceCell.BorderColor = System.Drawing.Color.Transparent;
            this.userGridPasswdColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userGridPasswdColumn.AppearanceCell.ForeColor = System.Drawing.Color.Black;
            this.userGridPasswdColumn.AppearanceCell.Options.UseBorderColor = true;
            this.userGridPasswdColumn.AppearanceCell.Options.UseFont = true;
            this.userGridPasswdColumn.AppearanceCell.Options.UseForeColor = true;
            this.userGridPasswdColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userGridPasswdColumn.AppearanceHeader.Options.UseFont = true;
            this.userGridPasswdColumn.Caption = "Password";
            this.userGridPasswdColumn.DisplayFormat.FormatString = "*";
            this.userGridPasswdColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.userGridPasswdColumn.FieldName = "PASSWD";
            this.userGridPasswdColumn.Name = "userGridPasswdColumn";
            this.userGridPasswdColumn.OptionsColumn.AllowEdit = false;
            this.userGridPasswdColumn.OptionsColumn.AllowFocus = false;
            this.userGridPasswdColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.userGridPasswdColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.userGridPasswdColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.userGridPasswdColumn.OptionsColumn.AllowMove = false;
            this.userGridPasswdColumn.OptionsColumn.AllowShowHide = false;
            this.userGridPasswdColumn.OptionsColumn.AllowSize = false;
            this.userGridPasswdColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.userGridPasswdColumn.OptionsColumn.FixedWidth = true;
            this.userGridPasswdColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.userGridPasswdColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.userGridPasswdColumn.OptionsColumn.ReadOnly = true;
            this.userGridPasswdColumn.OptionsColumn.TabStop = false;
            this.userGridPasswdColumn.Visible = true;
            this.userGridPasswdColumn.VisibleIndex = 2;
            // 
            // userGridMemoColumn
            // 
            this.userGridMemoColumn.AppearanceCell.BorderColor = System.Drawing.Color.Transparent;
            this.userGridMemoColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userGridMemoColumn.AppearanceCell.ForeColor = System.Drawing.Color.Black;
            this.userGridMemoColumn.AppearanceCell.Options.UseBorderColor = true;
            this.userGridMemoColumn.AppearanceCell.Options.UseFont = true;
            this.userGridMemoColumn.AppearanceCell.Options.UseForeColor = true;
            this.userGridMemoColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userGridMemoColumn.AppearanceHeader.Options.UseFont = true;
            this.userGridMemoColumn.Caption = "Memo";
            this.userGridMemoColumn.FieldName = "MEMO";
            this.userGridMemoColumn.Name = "userGridMemoColumn";
            this.userGridMemoColumn.OptionsColumn.AllowEdit = false;
            this.userGridMemoColumn.OptionsColumn.AllowFocus = false;
            this.userGridMemoColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.userGridMemoColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.userGridMemoColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.userGridMemoColumn.OptionsColumn.AllowMove = false;
            this.userGridMemoColumn.OptionsColumn.AllowShowHide = false;
            this.userGridMemoColumn.OptionsColumn.AllowSize = false;
            this.userGridMemoColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.userGridMemoColumn.OptionsColumn.FixedWidth = true;
            this.userGridMemoColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.userGridMemoColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.userGridMemoColumn.OptionsColumn.ReadOnly = true;
            this.userGridMemoColumn.OptionsColumn.TabStop = false;
            this.userGridMemoColumn.Visible = true;
            this.userGridMemoColumn.VisibleIndex = 3;
            // 
            // userDeleteButton
            // 
            this.userDeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("userDeleteButton.Image")));
            this.userDeleteButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.userDeleteButton.Location = new System.Drawing.Point(872, 76);
            this.userDeleteButton.Name = "userDeleteButton";
            this.userDeleteButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.userDeleteButton.Size = new System.Drawing.Size(120, 36);
            this.userDeleteButton.TabIndex = 7;
            this.userDeleteButton.TabStop = false;
            this.userDeleteButton.Text = "Delete";
            this.userDeleteButton.UseVisualStyleBackColor = true;
            this.userDeleteButton.Click += new System.EventHandler(this.userDeleteButton_Click);
            // 
            // userUpdateButton
            // 
            this.userUpdateButton.Image = ((System.Drawing.Image)(resources.GetObject("userUpdateButton.Image")));
            this.userUpdateButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.userUpdateButton.Location = new System.Drawing.Point(872, 38);
            this.userUpdateButton.Name = "userUpdateButton";
            this.userUpdateButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.userUpdateButton.Size = new System.Drawing.Size(120, 36);
            this.userUpdateButton.TabIndex = 6;
            this.userUpdateButton.TabStop = false;
            this.userUpdateButton.Text = "Modify";
            this.userUpdateButton.UseVisualStyleBackColor = true;
            this.userUpdateButton.Click += new System.EventHandler(this.userUpdateButton_Click);
            // 
            // userAddButton
            // 
            this.userAddButton.Image = ((System.Drawing.Image)(resources.GetObject("userAddButton.Image")));
            this.userAddButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.userAddButton.Location = new System.Drawing.Point(872, 0);
            this.userAddButton.Name = "userAddButton";
            this.userAddButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.userAddButton.Size = new System.Drawing.Size(120, 36);
            this.userAddButton.TabIndex = 5;
            this.userAddButton.TabStop = false;
            this.userAddButton.Text = "New";
            this.userAddButton.UseVisualStyleBackColor = true;
            this.userAddButton.Click += new System.EventHandler(this.userAddButton_Click);
            // 
            // CtrlConfigTop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CtrlConfigTop";
            this.Size = new System.Drawing.Size(992, 645);
            this.Load += new System.EventHandler(this.CtrlConfigTop_Load);
            this.Enter += new System.EventHandler(this.CtrlConfigTop_Enter);
            this.bgPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl userGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView userGridView;
        private DevExpress.XtraGrid.Columns.GridColumn userGridNameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn userGridGradeColumn;
        private DevExpress.XtraGrid.Columns.GridColumn userGridPasswdColumn;
        private DevExpress.XtraGrid.Columns.GridColumn userGridMemoColumn;
        private System.Windows.Forms.Button userDeleteButton;
        private System.Windows.Forms.Button userUpdateButton;
        private System.Windows.Forms.Button userAddButton;
    }
}
