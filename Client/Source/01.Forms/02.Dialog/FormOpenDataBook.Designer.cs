namespace Hnc.Calorimeter.Client
{
    partial class FormOpenDataBook
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOpenDataBook));
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.toDateEdit = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateCheck = new System.Windows.Forms.CheckBox();
            this.fromDateEdit = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.lineCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.stateCombo = new System.Windows.Forms.ComboBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.dataBookGrid = new DevExpress.XtraGrid.GridControl();
            this.dataBookGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dbTestLineColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dbUserColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dbBeginTimeColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dbEndTimeColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dbElpasedTimeColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dbCapacityColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dbPowerColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dbEerCopColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dbCompanyColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dbTestNameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dbTestNoColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dbObserverColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dbMakerColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dbModel1Column = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dbSerial1Column = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dbMemoColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dbStateColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bgPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBookGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBookGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // bgPanel
            // 
            this.bgPanel.Controls.Add(this.dataBookGrid);
            this.bgPanel.Controls.Add(this.resetButton);
            this.bgPanel.Controls.Add(this.searchButton);
            this.bgPanel.Controls.Add(this.label4);
            this.bgPanel.Controls.Add(this.stateCombo);
            this.bgPanel.Controls.Add(this.label11);
            this.bgPanel.Controls.Add(this.lineCombo);
            this.bgPanel.Controls.Add(this.toDateEdit);
            this.bgPanel.Controls.Add(this.label3);
            this.bgPanel.Controls.Add(this.dateCheck);
            this.bgPanel.Controls.Add(this.fromDateEdit);
            this.bgPanel.Controls.Add(this.okButton);
            this.bgPanel.Controls.Add(this.cancelButton);
            this.bgPanel.Size = new System.Drawing.Size(984, 561);
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.Image = ((System.Drawing.Image)(resources.GetObject("okButton.Image")));
            this.okButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.okButton.Location = new System.Drawing.Point(776, 523);
            this.okButton.Name = "okButton";
            this.okButton.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.okButton.Size = new System.Drawing.Size(100, 32);
            this.okButton.TabIndex = 8;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelButton.Image")));
            this.cancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelButton.Location = new System.Drawing.Point(878, 523);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.cancelButton.Size = new System.Drawing.Size(100, 32);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // toDateEdit
            // 
            this.toDateEdit.CustomFormat = "yyyy-MM-dd";
            this.toDateEdit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toDateEdit.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.toDateEdit.Location = new System.Drawing.Point(210, 8);
            this.toDateEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.toDateEdit.Name = "toDateEdit";
            this.toDateEdit.Size = new System.Drawing.Size(102, 21);
            this.toDateEdit.TabIndex = 2;
            this.toDateEdit.ValueChanged += new System.EventHandler(this.toDateEdit_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(191, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 15);
            this.label3.TabIndex = 44;
            this.label3.Text = "~";
            // 
            // dateCheck
            // 
            this.dateCheck.AutoSize = true;
            this.dateCheck.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateCheck.Location = new System.Drawing.Point(6, 10);
            this.dateCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateCheck.Name = "dateCheck";
            this.dateCheck.Size = new System.Drawing.Size(78, 19);
            this.dateCheck.TabIndex = 0;
            this.dateCheck.Tag = "";
            this.dateCheck.Text = "Test Date";
            this.dateCheck.UseVisualStyleBackColor = true;
            // 
            // fromDateEdit
            // 
            this.fromDateEdit.CustomFormat = "yyyy-MM-dd";
            this.fromDateEdit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromDateEdit.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromDateEdit.Location = new System.Drawing.Point(85, 8);
            this.fromDateEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fromDateEdit.Name = "fromDateEdit";
            this.fromDateEdit.Size = new System.Drawing.Size(102, 21);
            this.fromDateEdit.TabIndex = 1;
            this.fromDateEdit.ValueChanged += new System.EventHandler(this.fromDateEdit_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(325, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 15);
            this.label11.TabIndex = 47;
            this.label11.Text = "Line";
            // 
            // lineCombo
            // 
            this.lineCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lineCombo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineCombo.FormattingEnabled = true;
            this.lineCombo.Items.AddRange(new object[] {
            "None",
            "L1",
            "L2",
            "L3",
            "L4"});
            this.lineCombo.Location = new System.Drawing.Point(360, 8);
            this.lineCombo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lineCombo.Name = "lineCombo";
            this.lineCombo.Size = new System.Drawing.Size(64, 23);
            this.lineCombo.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(438, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 49;
            this.label4.Text = "State";
            // 
            // stateCombo
            // 
            this.stateCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stateCombo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stateCombo.FormattingEnabled = true;
            this.stateCombo.Items.AddRange(new object[] {
            "None",
            "OK",
            "NG"});
            this.stateCombo.Location = new System.Drawing.Point(476, 8);
            this.stateCombo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.stateCombo.Name = "stateCombo";
            this.stateCombo.Size = new System.Drawing.Size(64, 23);
            this.stateCombo.TabIndex = 4;
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Image = ((System.Drawing.Image)(resources.GetObject("searchButton.Image")));
            this.searchButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.searchButton.Location = new System.Drawing.Point(814, 8);
            this.searchButton.Name = "searchButton";
            this.searchButton.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.searchButton.Size = new System.Drawing.Size(80, 24);
            this.searchButton.TabIndex = 5;
            this.searchButton.Text = "Find";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.Image = ((System.Drawing.Image)(resources.GetObject("resetButton.Image")));
            this.resetButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.resetButton.Location = new System.Drawing.Point(898, 8);
            this.resetButton.Name = "resetButton";
            this.resetButton.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.resetButton.Size = new System.Drawing.Size(80, 24);
            this.resetButton.TabIndex = 6;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // dataBookGrid
            // 
            this.dataBookGrid.Location = new System.Drawing.Point(6, 37);
            this.dataBookGrid.MainView = this.dataBookGridView;
            this.dataBookGrid.Name = "dataBookGrid";
            this.dataBookGrid.Size = new System.Drawing.Size(972, 481);
            this.dataBookGrid.TabIndex = 7;
            this.dataBookGrid.TabStop = false;
            this.dataBookGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dataBookGridView});
            this.dataBookGrid.DoubleClick += new System.EventHandler(this.dataBookGrid_DoubleClick);
            // 
            // dataBookGridView
            // 
            this.dataBookGridView.ActiveFilterEnabled = false;
            this.dataBookGridView.Appearance.FixedLine.Font = new System.Drawing.Font("Arial", 9F);
            this.dataBookGridView.Appearance.FixedLine.Options.UseFont = true;
            this.dataBookGridView.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F);
            this.dataBookGridView.Appearance.FocusedCell.Options.UseFont = true;
            this.dataBookGridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.dataBookGridView.Appearance.FocusedRow.Options.UseFont = true;
            this.dataBookGridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F);
            this.dataBookGridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.dataBookGridView.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.dataBookGridView.Appearance.HideSelectionRow.Options.UseFont = true;
            this.dataBookGridView.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.dataBookGridView.Appearance.OddRow.Options.UseFont = true;
            this.dataBookGridView.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F);
            this.dataBookGridView.Appearance.Preview.Options.UseFont = true;
            this.dataBookGridView.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F);
            this.dataBookGridView.Appearance.Row.Options.UseFont = true;
            this.dataBookGridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.dataBookGridView.Appearance.SelectedRow.Options.UseFont = true;
            this.dataBookGridView.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F);
            this.dataBookGridView.Appearance.ViewCaption.Options.UseFont = true;
            this.dataBookGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.dbTestLineColumn,
            this.dbUserColumn,
            this.dbBeginTimeColumn,
            this.dbEndTimeColumn,
            this.dbElpasedTimeColumn,
            this.dbCapacityColumn,
            this.dbPowerColumn,
            this.dbEerCopColumn,
            this.dbCompanyColumn,
            this.dbTestNameColumn,
            this.dbTestNoColumn,
            this.dbObserverColumn,
            this.dbMakerColumn,
            this.dbModel1Column,
            this.dbSerial1Column,
            this.dbMemoColumn,
            this.dbStateColumn});
            this.dataBookGridView.CustomizationFormBounds = new System.Drawing.Rectangle(2884, 580, 210, 186);
            this.dataBookGridView.GridControl = this.dataBookGrid;
            this.dataBookGridView.Name = "dataBookGridView";
            this.dataBookGridView.OptionsBehavior.Editable = false;
            this.dataBookGridView.OptionsBehavior.ReadOnly = true;
            this.dataBookGridView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.dataBookGridView.OptionsFilter.AllowFilterEditor = false;
            this.dataBookGridView.OptionsView.ColumnAutoWidth = false;
            this.dataBookGridView.OptionsView.ShowGroupPanel = false;
            this.dataBookGridView.OptionsView.ShowIndicator = false;
            this.dataBookGridView.Tag = 1;
            this.dataBookGridView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.dataBookGridView_CustomDrawCell);
            this.dataBookGridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.dataBookGridView_FocusedRowChanged);
            // 
            // dbTestLineColumn
            // 
            this.dbTestLineColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F);
            this.dbTestLineColumn.AppearanceCell.Options.UseFont = true;
            this.dbTestLineColumn.AppearanceCell.Options.UseTextOptions = true;
            this.dbTestLineColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dbTestLineColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F);
            this.dbTestLineColumn.AppearanceHeader.Options.UseFont = true;
            this.dbTestLineColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.dbTestLineColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dbTestLineColumn.Caption = "Line";
            this.dbTestLineColumn.FieldName = "TESTLINE";
            this.dbTestLineColumn.Name = "dbTestLineColumn";
            this.dbTestLineColumn.OptionsColumn.AllowEdit = false;
            this.dbTestLineColumn.OptionsColumn.AllowFocus = false;
            this.dbTestLineColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.dbTestLineColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.dbTestLineColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.dbTestLineColumn.OptionsColumn.AllowMove = false;
            this.dbTestLineColumn.OptionsColumn.AllowShowHide = false;
            this.dbTestLineColumn.OptionsColumn.AllowSize = false;
            this.dbTestLineColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.dbTestLineColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.dbTestLineColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.dbTestLineColumn.OptionsColumn.ReadOnly = true;
            this.dbTestLineColumn.OptionsFilter.AllowAutoFilter = false;
            this.dbTestLineColumn.OptionsFilter.AllowFilter = false;
            this.dbTestLineColumn.Visible = true;
            this.dbTestLineColumn.VisibleIndex = 0;
            this.dbTestLineColumn.Width = 50;
            // 
            // dbUserColumn
            // 
            this.dbUserColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F);
            this.dbUserColumn.AppearanceCell.Options.UseFont = true;
            this.dbUserColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F);
            this.dbUserColumn.AppearanceHeader.Options.UseFont = true;
            this.dbUserColumn.Caption = "User Name";
            this.dbUserColumn.FieldName = "USERNAME";
            this.dbUserColumn.MaxWidth = 150;
            this.dbUserColumn.MinWidth = 40;
            this.dbUserColumn.Name = "dbUserColumn";
            this.dbUserColumn.OptionsColumn.AllowEdit = false;
            this.dbUserColumn.OptionsColumn.AllowFocus = false;
            this.dbUserColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.dbUserColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.dbUserColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.dbUserColumn.OptionsColumn.AllowMove = false;
            this.dbUserColumn.OptionsColumn.AllowShowHide = false;
            this.dbUserColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.dbUserColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.dbUserColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.dbUserColumn.OptionsColumn.ReadOnly = true;
            this.dbUserColumn.OptionsFilter.AllowAutoFilter = false;
            this.dbUserColumn.OptionsFilter.AllowFilter = false;
            this.dbUserColumn.Visible = true;
            this.dbUserColumn.VisibleIndex = 8;
            this.dbUserColumn.Width = 80;
            // 
            // dbBeginTimeColumn
            // 
            this.dbBeginTimeColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F);
            this.dbBeginTimeColumn.AppearanceCell.Options.UseFont = true;
            this.dbBeginTimeColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F);
            this.dbBeginTimeColumn.AppearanceHeader.Options.UseFont = true;
            this.dbBeginTimeColumn.Caption = "Begin Time";
            this.dbBeginTimeColumn.FieldName = "BEGINTIME";
            this.dbBeginTimeColumn.MaxWidth = 128;
            this.dbBeginTimeColumn.MinWidth = 40;
            this.dbBeginTimeColumn.Name = "dbBeginTimeColumn";
            this.dbBeginTimeColumn.OptionsColumn.AllowEdit = false;
            this.dbBeginTimeColumn.OptionsColumn.AllowFocus = false;
            this.dbBeginTimeColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.dbBeginTimeColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.dbBeginTimeColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.dbBeginTimeColumn.OptionsColumn.AllowMove = false;
            this.dbBeginTimeColumn.OptionsColumn.AllowShowHide = false;
            this.dbBeginTimeColumn.OptionsColumn.AllowSize = false;
            this.dbBeginTimeColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.dbBeginTimeColumn.OptionsColumn.FixedWidth = true;
            this.dbBeginTimeColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.dbBeginTimeColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.dbBeginTimeColumn.OptionsColumn.ReadOnly = true;
            this.dbBeginTimeColumn.OptionsFilter.AllowAutoFilter = false;
            this.dbBeginTimeColumn.OptionsFilter.AllowFilter = false;
            this.dbBeginTimeColumn.Visible = true;
            this.dbBeginTimeColumn.VisibleIndex = 2;
            this.dbBeginTimeColumn.Width = 128;
            // 
            // dbEndTimeColumn
            // 
            this.dbEndTimeColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F);
            this.dbEndTimeColumn.AppearanceCell.Options.UseFont = true;
            this.dbEndTimeColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F);
            this.dbEndTimeColumn.AppearanceHeader.Options.UseFont = true;
            this.dbEndTimeColumn.Caption = "End Time";
            this.dbEndTimeColumn.FieldName = "ENDTIME";
            this.dbEndTimeColumn.MaxWidth = 128;
            this.dbEndTimeColumn.MinWidth = 40;
            this.dbEndTimeColumn.Name = "dbEndTimeColumn";
            this.dbEndTimeColumn.OptionsColumn.AllowEdit = false;
            this.dbEndTimeColumn.OptionsColumn.AllowFocus = false;
            this.dbEndTimeColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.dbEndTimeColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.dbEndTimeColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.dbEndTimeColumn.OptionsColumn.AllowMove = false;
            this.dbEndTimeColumn.OptionsColumn.AllowShowHide = false;
            this.dbEndTimeColumn.OptionsColumn.AllowSize = false;
            this.dbEndTimeColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.dbEndTimeColumn.OptionsColumn.FixedWidth = true;
            this.dbEndTimeColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.dbEndTimeColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.dbEndTimeColumn.OptionsColumn.ReadOnly = true;
            this.dbEndTimeColumn.OptionsFilter.AllowAutoFilter = false;
            this.dbEndTimeColumn.OptionsFilter.AllowFilter = false;
            this.dbEndTimeColumn.Visible = true;
            this.dbEndTimeColumn.VisibleIndex = 3;
            this.dbEndTimeColumn.Width = 128;
            // 
            // dbElpasedTimeColumn
            // 
            this.dbElpasedTimeColumn.Caption = "Elapsed Time";
            this.dbElpasedTimeColumn.FieldName = "ELAPSEDTIME";
            this.dbElpasedTimeColumn.Name = "dbElpasedTimeColumn";
            this.dbElpasedTimeColumn.OptionsColumn.AllowEdit = false;
            this.dbElpasedTimeColumn.OptionsColumn.AllowFocus = false;
            this.dbElpasedTimeColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.dbElpasedTimeColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.dbElpasedTimeColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.dbElpasedTimeColumn.OptionsColumn.AllowMove = false;
            this.dbElpasedTimeColumn.OptionsColumn.AllowShowHide = false;
            this.dbElpasedTimeColumn.OptionsColumn.AllowSize = false;
            this.dbElpasedTimeColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.dbElpasedTimeColumn.OptionsColumn.FixedWidth = true;
            this.dbElpasedTimeColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.dbElpasedTimeColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.dbElpasedTimeColumn.OptionsColumn.ReadOnly = true;
            this.dbElpasedTimeColumn.OptionsColumn.TabStop = false;
            this.dbElpasedTimeColumn.OptionsFilter.AllowAutoFilter = false;
            this.dbElpasedTimeColumn.OptionsFilter.AllowFilter = false;
            this.dbElpasedTimeColumn.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.dbElpasedTimeColumn.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.dbElpasedTimeColumn.Visible = true;
            this.dbElpasedTimeColumn.VisibleIndex = 4;
            this.dbElpasedTimeColumn.Width = 100;
            // 
            // dbCapacityColumn
            // 
            this.dbCapacityColumn.Caption = "Capacity";
            this.dbCapacityColumn.FieldName = "TOTALCAPACITY";
            this.dbCapacityColumn.Name = "dbCapacityColumn";
            this.dbCapacityColumn.OptionsColumn.AllowEdit = false;
            this.dbCapacityColumn.OptionsColumn.AllowFocus = false;
            this.dbCapacityColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.dbCapacityColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.dbCapacityColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.dbCapacityColumn.OptionsColumn.AllowMove = false;
            this.dbCapacityColumn.OptionsColumn.AllowShowHide = false;
            this.dbCapacityColumn.OptionsColumn.AllowSize = false;
            this.dbCapacityColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.dbCapacityColumn.OptionsColumn.FixedWidth = true;
            this.dbCapacityColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.dbCapacityColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.dbCapacityColumn.OptionsColumn.ReadOnly = true;
            this.dbCapacityColumn.OptionsColumn.TabStop = false;
            this.dbCapacityColumn.OptionsFilter.AllowAutoFilter = false;
            this.dbCapacityColumn.OptionsFilter.AllowFilter = false;
            this.dbCapacityColumn.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.dbCapacityColumn.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.dbCapacityColumn.Visible = true;
            this.dbCapacityColumn.VisibleIndex = 5;
            this.dbCapacityColumn.Width = 90;
            // 
            // dbPowerColumn
            // 
            this.dbPowerColumn.Caption = "Power";
            this.dbPowerColumn.FieldName = "TOTALPOWER";
            this.dbPowerColumn.Name = "dbPowerColumn";
            this.dbPowerColumn.OptionsColumn.AllowEdit = false;
            this.dbPowerColumn.OptionsColumn.AllowFocus = false;
            this.dbPowerColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.dbPowerColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.dbPowerColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.dbPowerColumn.OptionsColumn.AllowMove = false;
            this.dbPowerColumn.OptionsColumn.AllowShowHide = false;
            this.dbPowerColumn.OptionsColumn.AllowSize = false;
            this.dbPowerColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.dbPowerColumn.OptionsColumn.FixedWidth = true;
            this.dbPowerColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.dbPowerColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.dbPowerColumn.OptionsColumn.ReadOnly = true;
            this.dbPowerColumn.OptionsColumn.TabStop = false;
            this.dbPowerColumn.OptionsFilter.AllowAutoFilter = false;
            this.dbPowerColumn.OptionsFilter.AllowFilter = false;
            this.dbPowerColumn.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.dbPowerColumn.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.dbPowerColumn.Visible = true;
            this.dbPowerColumn.VisibleIndex = 6;
            this.dbPowerColumn.Width = 90;
            // 
            // dbEerCopColumn
            // 
            this.dbEerCopColumn.Caption = "EER/COP";
            this.dbEerCopColumn.FieldName = "TOTALEER_COP";
            this.dbEerCopColumn.Name = "dbEerCopColumn";
            this.dbEerCopColumn.OptionsColumn.AllowEdit = false;
            this.dbEerCopColumn.OptionsColumn.AllowFocus = false;
            this.dbEerCopColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.dbEerCopColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.dbEerCopColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.dbEerCopColumn.OptionsColumn.AllowMove = false;
            this.dbEerCopColumn.OptionsColumn.AllowShowHide = false;
            this.dbEerCopColumn.OptionsColumn.AllowSize = false;
            this.dbEerCopColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.dbEerCopColumn.OptionsColumn.FixedWidth = true;
            this.dbEerCopColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.dbEerCopColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.dbEerCopColumn.OptionsColumn.ReadOnly = true;
            this.dbEerCopColumn.OptionsColumn.TabStop = false;
            this.dbEerCopColumn.OptionsFilter.AllowAutoFilter = false;
            this.dbEerCopColumn.OptionsFilter.AllowFilter = false;
            this.dbEerCopColumn.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.dbEerCopColumn.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.dbEerCopColumn.Visible = true;
            this.dbEerCopColumn.VisibleIndex = 7;
            this.dbEerCopColumn.Width = 110;
            // 
            // dbCompanyColumn
            // 
            this.dbCompanyColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F);
            this.dbCompanyColumn.AppearanceCell.Options.UseFont = true;
            this.dbCompanyColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F);
            this.dbCompanyColumn.AppearanceHeader.Options.UseFont = true;
            this.dbCompanyColumn.Caption = "Company";
            this.dbCompanyColumn.FieldName = "COMPANY";
            this.dbCompanyColumn.MaxWidth = 150;
            this.dbCompanyColumn.MinWidth = 40;
            this.dbCompanyColumn.Name = "dbCompanyColumn";
            this.dbCompanyColumn.OptionsColumn.AllowEdit = false;
            this.dbCompanyColumn.OptionsColumn.AllowFocus = false;
            this.dbCompanyColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.dbCompanyColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.dbCompanyColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.dbCompanyColumn.OptionsColumn.AllowMove = false;
            this.dbCompanyColumn.OptionsColumn.AllowShowHide = false;
            this.dbCompanyColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.dbCompanyColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.dbCompanyColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.dbCompanyColumn.OptionsColumn.ReadOnly = true;
            this.dbCompanyColumn.OptionsFilter.AllowAutoFilter = false;
            this.dbCompanyColumn.OptionsFilter.AllowFilter = false;
            this.dbCompanyColumn.Visible = true;
            this.dbCompanyColumn.VisibleIndex = 9;
            this.dbCompanyColumn.Width = 80;
            // 
            // dbTestNameColumn
            // 
            this.dbTestNameColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F);
            this.dbTestNameColumn.AppearanceCell.Options.UseFont = true;
            this.dbTestNameColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F);
            this.dbTestNameColumn.AppearanceHeader.Options.UseFont = true;
            this.dbTestNameColumn.Caption = "Test Name";
            this.dbTestNameColumn.FieldName = "TESTNAME";
            this.dbTestNameColumn.MaxWidth = 150;
            this.dbTestNameColumn.MinWidth = 40;
            this.dbTestNameColumn.Name = "dbTestNameColumn";
            this.dbTestNameColumn.OptionsColumn.AllowEdit = false;
            this.dbTestNameColumn.OptionsColumn.AllowFocus = false;
            this.dbTestNameColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.dbTestNameColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.dbTestNameColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.dbTestNameColumn.OptionsColumn.AllowMove = false;
            this.dbTestNameColumn.OptionsColumn.AllowShowHide = false;
            this.dbTestNameColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.dbTestNameColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.dbTestNameColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.dbTestNameColumn.OptionsColumn.ReadOnly = true;
            this.dbTestNameColumn.OptionsFilter.AllowAutoFilter = false;
            this.dbTestNameColumn.OptionsFilter.AllowFilter = false;
            this.dbTestNameColumn.Visible = true;
            this.dbTestNameColumn.VisibleIndex = 10;
            this.dbTestNameColumn.Width = 80;
            // 
            // dbTestNoColumn
            // 
            this.dbTestNoColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F);
            this.dbTestNoColumn.AppearanceCell.Options.UseFont = true;
            this.dbTestNoColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F);
            this.dbTestNoColumn.AppearanceHeader.Options.UseFont = true;
            this.dbTestNoColumn.Caption = "Test No";
            this.dbTestNoColumn.FieldName = "TESTNO";
            this.dbTestNoColumn.MaxWidth = 150;
            this.dbTestNoColumn.MinWidth = 40;
            this.dbTestNoColumn.Name = "dbTestNoColumn";
            this.dbTestNoColumn.OptionsColumn.AllowEdit = false;
            this.dbTestNoColumn.OptionsColumn.AllowFocus = false;
            this.dbTestNoColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.dbTestNoColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.dbTestNoColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.dbTestNoColumn.OptionsColumn.AllowMove = false;
            this.dbTestNoColumn.OptionsColumn.AllowShowHide = false;
            this.dbTestNoColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.dbTestNoColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.dbTestNoColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.dbTestNoColumn.OptionsColumn.ReadOnly = true;
            this.dbTestNoColumn.OptionsFilter.AllowAutoFilter = false;
            this.dbTestNoColumn.OptionsFilter.AllowFilter = false;
            this.dbTestNoColumn.Visible = true;
            this.dbTestNoColumn.VisibleIndex = 11;
            this.dbTestNoColumn.Width = 80;
            // 
            // dbObserverColumn
            // 
            this.dbObserverColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F);
            this.dbObserverColumn.AppearanceCell.Options.UseFont = true;
            this.dbObserverColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F);
            this.dbObserverColumn.AppearanceHeader.Options.UseFont = true;
            this.dbObserverColumn.Caption = "Observer";
            this.dbObserverColumn.FieldName = "OBSERVER";
            this.dbObserverColumn.MaxWidth = 150;
            this.dbObserverColumn.MinWidth = 40;
            this.dbObserverColumn.Name = "dbObserverColumn";
            this.dbObserverColumn.OptionsColumn.AllowEdit = false;
            this.dbObserverColumn.OptionsColumn.AllowFocus = false;
            this.dbObserverColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.dbObserverColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.dbObserverColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.dbObserverColumn.OptionsColumn.AllowMove = false;
            this.dbObserverColumn.OptionsColumn.AllowShowHide = false;
            this.dbObserverColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.dbObserverColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.dbObserverColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.dbObserverColumn.OptionsColumn.ReadOnly = true;
            this.dbObserverColumn.OptionsFilter.AllowAutoFilter = false;
            this.dbObserverColumn.OptionsFilter.AllowFilter = false;
            this.dbObserverColumn.Visible = true;
            this.dbObserverColumn.VisibleIndex = 12;
            this.dbObserverColumn.Width = 80;
            // 
            // dbMakerColumn
            // 
            this.dbMakerColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F);
            this.dbMakerColumn.AppearanceCell.Options.UseFont = true;
            this.dbMakerColumn.AppearanceCell.Options.UseTextOptions = true;
            this.dbMakerColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.dbMakerColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F);
            this.dbMakerColumn.AppearanceHeader.Options.UseFont = true;
            this.dbMakerColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.dbMakerColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.dbMakerColumn.Caption = "Maker";
            this.dbMakerColumn.FieldName = "MAKER";
            this.dbMakerColumn.MaxWidth = 150;
            this.dbMakerColumn.MinWidth = 40;
            this.dbMakerColumn.Name = "dbMakerColumn";
            this.dbMakerColumn.OptionsColumn.AllowEdit = false;
            this.dbMakerColumn.OptionsColumn.AllowFocus = false;
            this.dbMakerColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.dbMakerColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.dbMakerColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.dbMakerColumn.OptionsColumn.AllowMove = false;
            this.dbMakerColumn.OptionsColumn.AllowShowHide = false;
            this.dbMakerColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.dbMakerColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.dbMakerColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.dbMakerColumn.OptionsColumn.ReadOnly = true;
            this.dbMakerColumn.OptionsColumn.TabStop = false;
            this.dbMakerColumn.OptionsFilter.AllowAutoFilter = false;
            this.dbMakerColumn.OptionsFilter.AllowFilter = false;
            this.dbMakerColumn.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.dbMakerColumn.OptionsFilter.ShowEmptyDateFilter = false;
            this.dbMakerColumn.Visible = true;
            this.dbMakerColumn.VisibleIndex = 13;
            this.dbMakerColumn.Width = 80;
            // 
            // dbModel1Column
            // 
            this.dbModel1Column.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F);
            this.dbModel1Column.AppearanceCell.Options.UseFont = true;
            this.dbModel1Column.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F);
            this.dbModel1Column.AppearanceHeader.Options.UseFont = true;
            this.dbModel1Column.Caption = "Model(1)";
            this.dbModel1Column.FieldName = "MODEL1";
            this.dbModel1Column.MaxWidth = 150;
            this.dbModel1Column.MinWidth = 40;
            this.dbModel1Column.Name = "dbModel1Column";
            this.dbModel1Column.OptionsColumn.AllowEdit = false;
            this.dbModel1Column.OptionsColumn.AllowFocus = false;
            this.dbModel1Column.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.dbModel1Column.OptionsColumn.AllowIncrementalSearch = false;
            this.dbModel1Column.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.dbModel1Column.OptionsColumn.AllowMove = false;
            this.dbModel1Column.OptionsColumn.AllowShowHide = false;
            this.dbModel1Column.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.dbModel1Column.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.dbModel1Column.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.dbModel1Column.OptionsColumn.ReadOnly = true;
            this.dbModel1Column.OptionsFilter.AllowAutoFilter = false;
            this.dbModel1Column.OptionsFilter.AllowFilter = false;
            this.dbModel1Column.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.dbModel1Column.OptionsFilter.ShowEmptyDateFilter = false;
            this.dbModel1Column.Visible = true;
            this.dbModel1Column.VisibleIndex = 14;
            this.dbModel1Column.Width = 80;
            // 
            // dbSerial1Column
            // 
            this.dbSerial1Column.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F);
            this.dbSerial1Column.AppearanceCell.Options.UseFont = true;
            this.dbSerial1Column.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F);
            this.dbSerial1Column.AppearanceHeader.Options.UseFont = true;
            this.dbSerial1Column.Caption = "Serial No(1)";
            this.dbSerial1Column.FieldName = "SERIAL1";
            this.dbSerial1Column.MaxWidth = 150;
            this.dbSerial1Column.MinWidth = 40;
            this.dbSerial1Column.Name = "dbSerial1Column";
            this.dbSerial1Column.OptionsColumn.AllowEdit = false;
            this.dbSerial1Column.OptionsColumn.AllowFocus = false;
            this.dbSerial1Column.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.dbSerial1Column.OptionsColumn.AllowIncrementalSearch = false;
            this.dbSerial1Column.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.dbSerial1Column.OptionsColumn.AllowMove = false;
            this.dbSerial1Column.OptionsColumn.AllowShowHide = false;
            this.dbSerial1Column.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.dbSerial1Column.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.dbSerial1Column.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.dbSerial1Column.OptionsColumn.ReadOnly = true;
            this.dbSerial1Column.OptionsFilter.AllowAutoFilter = false;
            this.dbSerial1Column.OptionsFilter.AllowFilter = false;
            this.dbSerial1Column.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.dbSerial1Column.OptionsFilter.ShowEmptyDateFilter = false;
            this.dbSerial1Column.Visible = true;
            this.dbSerial1Column.VisibleIndex = 15;
            this.dbSerial1Column.Width = 80;
            // 
            // dbMemoColumn
            // 
            this.dbMemoColumn.Caption = "Memo";
            this.dbMemoColumn.FieldName = "MEMO";
            this.dbMemoColumn.Name = "dbMemoColumn";
            this.dbMemoColumn.OptionsColumn.AllowEdit = false;
            this.dbMemoColumn.OptionsColumn.AllowFocus = false;
            this.dbMemoColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.dbMemoColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.dbMemoColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.dbMemoColumn.OptionsColumn.AllowMove = false;
            this.dbMemoColumn.OptionsColumn.AllowShowHide = false;
            this.dbMemoColumn.OptionsColumn.AllowSize = false;
            this.dbMemoColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.dbMemoColumn.OptionsColumn.FixedWidth = true;
            this.dbMemoColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.dbMemoColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.dbMemoColumn.OptionsColumn.ReadOnly = true;
            this.dbMemoColumn.OptionsColumn.TabStop = false;
            this.dbMemoColumn.OptionsFilter.AllowAutoFilter = false;
            this.dbMemoColumn.OptionsFilter.AllowFilter = false;
            this.dbMemoColumn.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.dbMemoColumn.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.dbMemoColumn.Visible = true;
            this.dbMemoColumn.VisibleIndex = 16;
            this.dbMemoColumn.Width = 128;
            // 
            // dbStateColumn
            // 
            this.dbStateColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F);
            this.dbStateColumn.AppearanceCell.Options.UseFont = true;
            this.dbStateColumn.AppearanceCell.Options.UseTextOptions = true;
            this.dbStateColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dbStateColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F);
            this.dbStateColumn.AppearanceHeader.Options.UseFont = true;
            this.dbStateColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.dbStateColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dbStateColumn.Caption = "State";
            this.dbStateColumn.FieldName = "STATE";
            this.dbStateColumn.Name = "dbStateColumn";
            this.dbStateColumn.OptionsColumn.AllowEdit = false;
            this.dbStateColumn.OptionsColumn.AllowFocus = false;
            this.dbStateColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.dbStateColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.dbStateColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.dbStateColumn.OptionsColumn.AllowMove = false;
            this.dbStateColumn.OptionsColumn.AllowShowHide = false;
            this.dbStateColumn.OptionsColumn.AllowSize = false;
            this.dbStateColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.dbStateColumn.OptionsColumn.FixedWidth = true;
            this.dbStateColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.dbStateColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.dbStateColumn.OptionsColumn.ReadOnly = true;
            this.dbStateColumn.OptionsFilter.AllowAutoFilter = false;
            this.dbStateColumn.OptionsFilter.AllowFilter = false;
            this.dbStateColumn.Visible = true;
            this.dbStateColumn.VisibleIndex = 1;
            this.dbStateColumn.Width = 50;
            // 
            // FormOpenDataBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOpenDataBook";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Open Report";
            this.Load += new System.EventHandler(this.FormOpenDataBook_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormOpenDataBook_KeyPress);
            this.bgPanel.ResumeLayout(false);
            this.bgPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBookGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBookGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox stateCombo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox lineCombo;
        private System.Windows.Forms.DateTimePicker toDateEdit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox dateCheck;
        private System.Windows.Forms.DateTimePicker fromDateEdit;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button searchButton;
        private DevExpress.XtraGrid.GridControl dataBookGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView dataBookGridView;
        private DevExpress.XtraGrid.Columns.GridColumn dbUserColumn;
        private DevExpress.XtraGrid.Columns.GridColumn dbBeginTimeColumn;
        private DevExpress.XtraGrid.Columns.GridColumn dbEndTimeColumn;
        private DevExpress.XtraGrid.Columns.GridColumn dbTestLineColumn;
        private DevExpress.XtraGrid.Columns.GridColumn dbCompanyColumn;
        private DevExpress.XtraGrid.Columns.GridColumn dbTestNameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn dbTestNoColumn;
        private DevExpress.XtraGrid.Columns.GridColumn dbObserverColumn;
        private DevExpress.XtraGrid.Columns.GridColumn dbMakerColumn;
        private DevExpress.XtraGrid.Columns.GridColumn dbModel1Column;
        private DevExpress.XtraGrid.Columns.GridColumn dbSerial1Column;
        private DevExpress.XtraGrid.Columns.GridColumn dbStateColumn;
        private DevExpress.XtraGrid.Columns.GridColumn dbElpasedTimeColumn;
        private DevExpress.XtraGrid.Columns.GridColumn dbCapacityColumn;
        private DevExpress.XtraGrid.Columns.GridColumn dbPowerColumn;
        private DevExpress.XtraGrid.Columns.GridColumn dbEerCopColumn;
        private DevExpress.XtraGrid.Columns.GridColumn dbMemoColumn;
    }
}
