﻿namespace Hnc.Calorimeter.Server
{
    partial class CtrlViewDevice
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
            this.powerMeterGrid = new DevExpress.XtraGrid.GridControl();
            this.powerMeterGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pmNameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pmIpColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pmPortColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pmScanTimeColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pmPhaseColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pmLinkColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pmModeColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.powerMeterPanel = new Ulee.Controls.UlPanel();
            this.pmModifyButton = new System.Windows.Forms.Button();
            this.ulPanel1 = new Ulee.Controls.UlPanel();
            this.cgModifyButton = new System.Windows.Forms.Button();
            this.ulPanel2 = new Ulee.Controls.UlPanel();
            this.pgModifyButton = new System.Windows.Forms.Button();
            this.recorderPanel = new Ulee.Controls.UlPanel();
            this.rgModifyButton = new System.Windows.Forms.Button();
            this.recorderGrid = new DevExpress.XtraGrid.GridControl();
            this.recorderGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.rgNameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rgIpColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rgPortColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rgScanTimeColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rgChannelColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rgLinkColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rgModeColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.controllerGrid = new DevExpress.XtraGrid.GridControl();
            this.controllerGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cgNameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cgIpColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cgPortColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cgScanTimeColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cgSlaveAddressColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cgSlaveCountColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cgLinkColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cgModeColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.plcGrid = new DevExpress.XtraGrid.GridControl();
            this.plcGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pgNameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pgIpColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pgPortColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pgScanTimeColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pgLinkColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pgModeColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bgPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.powerMeterGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.powerMeterGridView)).BeginInit();
            this.powerMeterPanel.SuspendLayout();
            this.ulPanel1.SuspendLayout();
            this.ulPanel2.SuspendLayout();
            this.recorderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recorderGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recorderGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controllerGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controllerGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plcGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // bgPanel
            // 
            this.bgPanel.BevelOuter = Ulee.Controls.EUlBevelStyle.None;
            this.bgPanel.Controls.Add(this.plcGrid);
            this.bgPanel.Controls.Add(this.controllerGrid);
            this.bgPanel.Controls.Add(this.recorderGrid);
            this.bgPanel.Controls.Add(this.ulPanel2);
            this.bgPanel.Controls.Add(this.recorderPanel);
            this.bgPanel.Controls.Add(this.ulPanel1);
            this.bgPanel.Controls.Add(this.powerMeterPanel);
            this.bgPanel.Controls.Add(this.powerMeterGrid);
            this.bgPanel.Size = new System.Drawing.Size(904, 645);
            // 
            // powerMeterGrid
            // 
            this.powerMeterGrid.Cursor = System.Windows.Forms.Cursors.Default;
            this.powerMeterGrid.Location = new System.Drawing.Point(0, 25);
            this.powerMeterGrid.MainView = this.powerMeterGridView;
            this.powerMeterGrid.Name = "powerMeterGrid";
            this.powerMeterGrid.Size = new System.Drawing.Size(450, 297);
            this.powerMeterGrid.TabIndex = 1;
            this.powerMeterGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.powerMeterGridView});
            // 
            // powerMeterGridView
            // 
            this.powerMeterGridView.Appearance.FixedLine.Font = new System.Drawing.Font("Arial", 9F);
            this.powerMeterGridView.Appearance.FixedLine.Options.UseFont = true;
            this.powerMeterGridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.powerMeterGridView.Appearance.FocusedRow.Options.UseFont = true;
            this.powerMeterGridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F);
            this.powerMeterGridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.powerMeterGridView.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.powerMeterGridView.Appearance.HideSelectionRow.Options.UseFont = true;
            this.powerMeterGridView.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.powerMeterGridView.Appearance.OddRow.Options.UseFont = true;
            this.powerMeterGridView.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F);
            this.powerMeterGridView.Appearance.Preview.Options.UseFont = true;
            this.powerMeterGridView.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F);
            this.powerMeterGridView.Appearance.Row.Options.UseFont = true;
            this.powerMeterGridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.powerMeterGridView.Appearance.SelectedRow.Options.UseFont = true;
            this.powerMeterGridView.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F);
            this.powerMeterGridView.Appearance.ViewCaption.Options.UseFont = true;
            this.powerMeterGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.pmNameColumn,
            this.pmIpColumn,
            this.pmPortColumn,
            this.pmScanTimeColumn,
            this.pmPhaseColumn,
            this.pmLinkColumn,
            this.pmModeColumn});
            this.powerMeterGridView.CustomizationFormBounds = new System.Drawing.Rectangle(2884, 580, 210, 186);
            this.powerMeterGridView.GridControl = this.powerMeterGrid;
            this.powerMeterGridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.powerMeterGridView.Name = "powerMeterGridView";
            this.powerMeterGridView.OptionsView.ColumnAutoWidth = false;
            this.powerMeterGridView.OptionsView.ShowGroupPanel = false;
            this.powerMeterGridView.OptionsView.ShowIndicator = false;
            this.powerMeterGridView.Tag = 0;
            // 
            // pmNameColumn
            // 
            this.pmNameColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pmNameColumn.AppearanceCell.Options.UseFont = true;
            this.pmNameColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pmNameColumn.AppearanceHeader.Options.UseFont = true;
            this.pmNameColumn.Caption = "Name";
            this.pmNameColumn.FieldName = "Name";
            this.pmNameColumn.Name = "pmNameColumn";
            this.pmNameColumn.OptionsColumn.AllowEdit = false;
            this.pmNameColumn.OptionsColumn.AllowFocus = false;
            this.pmNameColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.pmNameColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.pmNameColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.pmNameColumn.OptionsColumn.AllowMove = false;
            this.pmNameColumn.OptionsColumn.AllowShowHide = false;
            this.pmNameColumn.OptionsColumn.AllowSize = false;
            this.pmNameColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.pmNameColumn.OptionsColumn.FixedWidth = true;
            this.pmNameColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.pmNameColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.pmNameColumn.OptionsColumn.ReadOnly = true;
            this.pmNameColumn.OptionsColumn.TabStop = false;
            this.pmNameColumn.OptionsFilter.AllowAutoFilter = false;
            this.pmNameColumn.OptionsFilter.AllowFilter = false;
            this.pmNameColumn.Visible = true;
            this.pmNameColumn.VisibleIndex = 0;
            this.pmNameColumn.Width = 102;
            // 
            // pmIpColumn
            // 
            this.pmIpColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pmIpColumn.AppearanceCell.Options.UseFont = true;
            this.pmIpColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pmIpColumn.AppearanceHeader.Options.UseFont = true;
            this.pmIpColumn.Caption = "IP";
            this.pmIpColumn.FieldName = "Ip";
            this.pmIpColumn.Name = "pmIpColumn";
            this.pmIpColumn.OptionsColumn.AllowEdit = false;
            this.pmIpColumn.OptionsColumn.AllowFocus = false;
            this.pmIpColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.pmIpColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.pmIpColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.pmIpColumn.OptionsColumn.AllowMove = false;
            this.pmIpColumn.OptionsColumn.AllowShowHide = false;
            this.pmIpColumn.OptionsColumn.AllowSize = false;
            this.pmIpColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.pmIpColumn.OptionsColumn.FixedWidth = true;
            this.pmIpColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.pmIpColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.pmIpColumn.OptionsColumn.ReadOnly = true;
            this.pmIpColumn.OptionsColumn.TabStop = false;
            this.pmIpColumn.OptionsFilter.AllowAutoFilter = false;
            this.pmIpColumn.OptionsFilter.AllowFilter = false;
            this.pmIpColumn.Visible = true;
            this.pmIpColumn.VisibleIndex = 1;
            this.pmIpColumn.Width = 108;
            // 
            // pmPortColumn
            // 
            this.pmPortColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pmPortColumn.AppearanceCell.Options.UseFont = true;
            this.pmPortColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pmPortColumn.AppearanceHeader.Options.UseFont = true;
            this.pmPortColumn.Caption = "Port";
            this.pmPortColumn.FieldName = "Port";
            this.pmPortColumn.Name = "pmPortColumn";
            this.pmPortColumn.OptionsColumn.AllowEdit = false;
            this.pmPortColumn.OptionsColumn.AllowFocus = false;
            this.pmPortColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.pmPortColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.pmPortColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.pmPortColumn.OptionsColumn.AllowMove = false;
            this.pmPortColumn.OptionsColumn.AllowShowHide = false;
            this.pmPortColumn.OptionsColumn.AllowSize = false;
            this.pmPortColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.pmPortColumn.OptionsColumn.FixedWidth = true;
            this.pmPortColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.pmPortColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.pmPortColumn.OptionsColumn.ReadOnly = true;
            this.pmPortColumn.OptionsColumn.TabStop = false;
            this.pmPortColumn.OptionsFilter.AllowAutoFilter = false;
            this.pmPortColumn.OptionsFilter.AllowFilter = false;
            this.pmPortColumn.Visible = true;
            this.pmPortColumn.VisibleIndex = 2;
            this.pmPortColumn.Width = 44;
            // 
            // pmScanTimeColumn
            // 
            this.pmScanTimeColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pmScanTimeColumn.AppearanceCell.Options.UseFont = true;
            this.pmScanTimeColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pmScanTimeColumn.AppearanceHeader.Options.UseFont = true;
            this.pmScanTimeColumn.Caption = "Scan";
            this.pmScanTimeColumn.FieldName = "ScanTime";
            this.pmScanTimeColumn.Name = "pmScanTimeColumn";
            this.pmScanTimeColumn.OptionsColumn.AllowEdit = false;
            this.pmScanTimeColumn.OptionsColumn.AllowFocus = false;
            this.pmScanTimeColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.pmScanTimeColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.pmScanTimeColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.pmScanTimeColumn.OptionsColumn.AllowMove = false;
            this.pmScanTimeColumn.OptionsColumn.AllowShowHide = false;
            this.pmScanTimeColumn.OptionsColumn.AllowSize = false;
            this.pmScanTimeColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.pmScanTimeColumn.OptionsColumn.FixedWidth = true;
            this.pmScanTimeColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.pmScanTimeColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.pmScanTimeColumn.OptionsColumn.ReadOnly = true;
            this.pmScanTimeColumn.OptionsColumn.TabStop = false;
            this.pmScanTimeColumn.OptionsFilter.AllowAutoFilter = false;
            this.pmScanTimeColumn.OptionsFilter.AllowFilter = false;
            this.pmScanTimeColumn.Visible = true;
            this.pmScanTimeColumn.VisibleIndex = 3;
            this.pmScanTimeColumn.Width = 40;
            // 
            // pmPhaseColumn
            // 
            this.pmPhaseColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pmPhaseColumn.AppearanceCell.Options.UseFont = true;
            this.pmPhaseColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pmPhaseColumn.AppearanceHeader.Options.UseFont = true;
            this.pmPhaseColumn.Caption = "Phase";
            this.pmPhaseColumn.FieldName = "Phase";
            this.pmPhaseColumn.Name = "pmPhaseColumn";
            this.pmPhaseColumn.OptionsColumn.AllowEdit = false;
            this.pmPhaseColumn.OptionsColumn.AllowFocus = false;
            this.pmPhaseColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.pmPhaseColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.pmPhaseColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.pmPhaseColumn.OptionsColumn.AllowMove = false;
            this.pmPhaseColumn.OptionsColumn.AllowShowHide = false;
            this.pmPhaseColumn.OptionsColumn.AllowSize = false;
            this.pmPhaseColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.pmPhaseColumn.OptionsColumn.FixedWidth = true;
            this.pmPhaseColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.pmPhaseColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.pmPhaseColumn.OptionsColumn.ReadOnly = true;
            this.pmPhaseColumn.OptionsFilter.AllowAutoFilter = false;
            this.pmPhaseColumn.OptionsFilter.AllowFilter = false;
            this.pmPhaseColumn.Visible = true;
            this.pmPhaseColumn.VisibleIndex = 4;
            this.pmPhaseColumn.Width = 60;
            // 
            // pmLinkColumn
            // 
            this.pmLinkColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pmLinkColumn.AppearanceCell.Options.UseFont = true;
            this.pmLinkColumn.AppearanceCell.Options.UseTextOptions = true;
            this.pmLinkColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.pmLinkColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pmLinkColumn.AppearanceHeader.Options.UseFont = true;
            this.pmLinkColumn.Caption = "Link";
            this.pmLinkColumn.FieldName = "Connected";
            this.pmLinkColumn.Name = "pmLinkColumn";
            this.pmLinkColumn.OptionsColumn.AllowEdit = false;
            this.pmLinkColumn.OptionsColumn.AllowFocus = false;
            this.pmLinkColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.pmLinkColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.pmLinkColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.pmLinkColumn.OptionsColumn.AllowMove = false;
            this.pmLinkColumn.OptionsColumn.AllowShowHide = false;
            this.pmLinkColumn.OptionsColumn.AllowSize = false;
            this.pmLinkColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.pmLinkColumn.OptionsColumn.FixedWidth = true;
            this.pmLinkColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.pmLinkColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.pmLinkColumn.OptionsColumn.ReadOnly = true;
            this.pmLinkColumn.Visible = true;
            this.pmLinkColumn.VisibleIndex = 5;
            this.pmLinkColumn.Width = 32;
            // 
            // pmModeColumn
            // 
            this.pmModeColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pmModeColumn.AppearanceCell.Options.UseFont = true;
            this.pmModeColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pmModeColumn.AppearanceHeader.Options.UseFont = true;
            this.pmModeColumn.Caption = "Mode";
            this.pmModeColumn.FieldName = "Mode";
            this.pmModeColumn.Name = "pmModeColumn";
            this.pmModeColumn.OptionsColumn.AllowEdit = false;
            this.pmModeColumn.OptionsColumn.AllowFocus = false;
            this.pmModeColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.pmModeColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.pmModeColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.pmModeColumn.OptionsColumn.AllowMove = false;
            this.pmModeColumn.OptionsColumn.AllowShowHide = false;
            this.pmModeColumn.OptionsColumn.AllowSize = false;
            this.pmModeColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.pmModeColumn.OptionsColumn.FixedWidth = true;
            this.pmModeColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.pmModeColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.pmModeColumn.OptionsColumn.ReadOnly = true;
            this.pmModeColumn.OptionsColumn.TabStop = false;
            this.pmModeColumn.OptionsFilter.AllowAutoFilter = false;
            this.pmModeColumn.OptionsFilter.AllowFilter = false;
            this.pmModeColumn.Visible = true;
            this.pmModeColumn.VisibleIndex = 6;
            this.pmModeColumn.Width = 42;
            // 
            // powerMeterPanel
            // 
            this.powerMeterPanel.BackColor = System.Drawing.Color.Navy;
            this.powerMeterPanel.BevelInner = Ulee.Controls.EUlBevelStyle.None;
            this.powerMeterPanel.BevelOuter = Ulee.Controls.EUlBevelStyle.None;
            this.powerMeterPanel.Controls.Add(this.pmModifyButton);
            this.powerMeterPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.powerMeterPanel.ForeColor = System.Drawing.Color.White;
            this.powerMeterPanel.InnerColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.powerMeterPanel.InnerColor2 = System.Drawing.Color.White;
            this.powerMeterPanel.Location = new System.Drawing.Point(0, 0);
            this.powerMeterPanel.Name = "powerMeterPanel";
            this.powerMeterPanel.OuterColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.powerMeterPanel.OuterColor2 = System.Drawing.Color.White;
            this.powerMeterPanel.Size = new System.Drawing.Size(450, 24);
            this.powerMeterPanel.Spacing = 0;
            this.powerMeterPanel.TabIndex = 2;
            this.powerMeterPanel.Text = " Power Meter";
            this.powerMeterPanel.TextHAlign = Ulee.Controls.EUlHoriAlign.Left;
            this.powerMeterPanel.TextVAlign = Ulee.Controls.EUlVertAlign.Middle;
            // 
            // pmModifyButton
            // 
            this.pmModifyButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pmModifyButton.ForeColor = System.Drawing.Color.Black;
            this.pmModifyButton.Location = new System.Drawing.Point(400, 1);
            this.pmModifyButton.Name = "pmModifyButton";
            this.pmModifyButton.Size = new System.Drawing.Size(50, 22);
            this.pmModifyButton.TabIndex = 12;
            this.pmModifyButton.Tag = "0";
            this.pmModifyButton.Text = "Modify";
            this.pmModifyButton.UseVisualStyleBackColor = true;
            this.pmModifyButton.Click += new System.EventHandler(this.modifyButton_Click);
            // 
            // ulPanel1
            // 
            this.ulPanel1.BackColor = System.Drawing.Color.Navy;
            this.ulPanel1.BevelInner = Ulee.Controls.EUlBevelStyle.None;
            this.ulPanel1.BevelOuter = Ulee.Controls.EUlBevelStyle.None;
            this.ulPanel1.Controls.Add(this.cgModifyButton);
            this.ulPanel1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.ulPanel1.ForeColor = System.Drawing.Color.White;
            this.ulPanel1.InnerColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.ulPanel1.InnerColor2 = System.Drawing.Color.White;
            this.ulPanel1.Location = new System.Drawing.Point(0, 326);
            this.ulPanel1.Name = "ulPanel1";
            this.ulPanel1.OuterColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.ulPanel1.OuterColor2 = System.Drawing.Color.White;
            this.ulPanel1.Size = new System.Drawing.Size(450, 24);
            this.ulPanel1.Spacing = 0;
            this.ulPanel1.TabIndex = 4;
            this.ulPanel1.Text = " Controller";
            this.ulPanel1.TextHAlign = Ulee.Controls.EUlHoriAlign.Left;
            this.ulPanel1.TextVAlign = Ulee.Controls.EUlVertAlign.Middle;
            // 
            // cgModifyButton
            // 
            this.cgModifyButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cgModifyButton.ForeColor = System.Drawing.Color.Black;
            this.cgModifyButton.Location = new System.Drawing.Point(400, 1);
            this.cgModifyButton.Name = "cgModifyButton";
            this.cgModifyButton.Size = new System.Drawing.Size(50, 22);
            this.cgModifyButton.TabIndex = 13;
            this.cgModifyButton.Tag = "2";
            this.cgModifyButton.Text = "Modify";
            this.cgModifyButton.UseVisualStyleBackColor = true;
            this.cgModifyButton.Click += new System.EventHandler(this.modifyButton_Click);
            // 
            // ulPanel2
            // 
            this.ulPanel2.BackColor = System.Drawing.Color.Navy;
            this.ulPanel2.BevelInner = Ulee.Controls.EUlBevelStyle.None;
            this.ulPanel2.BevelOuter = Ulee.Controls.EUlBevelStyle.None;
            this.ulPanel2.Controls.Add(this.pgModifyButton);
            this.ulPanel2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.ulPanel2.ForeColor = System.Drawing.Color.White;
            this.ulPanel2.InnerColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.ulPanel2.InnerColor2 = System.Drawing.Color.White;
            this.ulPanel2.Location = new System.Drawing.Point(454, 326);
            this.ulPanel2.Name = "ulPanel2";
            this.ulPanel2.OuterColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.ulPanel2.OuterColor2 = System.Drawing.Color.White;
            this.ulPanel2.Size = new System.Drawing.Size(450, 24);
            this.ulPanel2.Spacing = 0;
            this.ulPanel2.TabIndex = 8;
            this.ulPanel2.Text = " PLC";
            this.ulPanel2.TextHAlign = Ulee.Controls.EUlHoriAlign.Left;
            this.ulPanel2.TextVAlign = Ulee.Controls.EUlVertAlign.Middle;
            // 
            // pgModifyButton
            // 
            this.pgModifyButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pgModifyButton.ForeColor = System.Drawing.Color.Black;
            this.pgModifyButton.Location = new System.Drawing.Point(400, 1);
            this.pgModifyButton.Name = "pgModifyButton";
            this.pgModifyButton.Size = new System.Drawing.Size(50, 22);
            this.pgModifyButton.TabIndex = 13;
            this.pgModifyButton.Tag = "3";
            this.pgModifyButton.Text = "Modify";
            this.pgModifyButton.UseVisualStyleBackColor = true;
            this.pgModifyButton.Click += new System.EventHandler(this.modifyButton_Click);
            // 
            // recorderPanel
            // 
            this.recorderPanel.BackColor = System.Drawing.Color.Navy;
            this.recorderPanel.BevelInner = Ulee.Controls.EUlBevelStyle.None;
            this.recorderPanel.BevelOuter = Ulee.Controls.EUlBevelStyle.None;
            this.recorderPanel.Controls.Add(this.rgModifyButton);
            this.recorderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.recorderPanel.ForeColor = System.Drawing.Color.White;
            this.recorderPanel.InnerColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.recorderPanel.InnerColor2 = System.Drawing.Color.White;
            this.recorderPanel.Location = new System.Drawing.Point(454, 0);
            this.recorderPanel.Name = "recorderPanel";
            this.recorderPanel.OuterColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.recorderPanel.OuterColor2 = System.Drawing.Color.White;
            this.recorderPanel.Size = new System.Drawing.Size(450, 24);
            this.recorderPanel.Spacing = 0;
            this.recorderPanel.TabIndex = 6;
            this.recorderPanel.Text = " Recorder";
            this.recorderPanel.TextHAlign = Ulee.Controls.EUlHoriAlign.Left;
            this.recorderPanel.TextVAlign = Ulee.Controls.EUlVertAlign.Middle;
            // 
            // rgModifyButton
            // 
            this.rgModifyButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgModifyButton.ForeColor = System.Drawing.Color.Black;
            this.rgModifyButton.Location = new System.Drawing.Point(400, 1);
            this.rgModifyButton.Name = "rgModifyButton";
            this.rgModifyButton.Size = new System.Drawing.Size(50, 22);
            this.rgModifyButton.TabIndex = 13;
            this.rgModifyButton.Tag = "1";
            this.rgModifyButton.Text = "Modify";
            this.rgModifyButton.UseVisualStyleBackColor = true;
            this.rgModifyButton.Click += new System.EventHandler(this.modifyButton_Click);
            // 
            // recorderGrid
            // 
            this.recorderGrid.Location = new System.Drawing.Point(454, 25);
            this.recorderGrid.MainView = this.recorderGridView;
            this.recorderGrid.Name = "recorderGrid";
            this.recorderGrid.Size = new System.Drawing.Size(450, 297);
            this.recorderGrid.TabIndex = 9;
            this.recorderGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.recorderGridView});
            // 
            // recorderGridView
            // 
            this.recorderGridView.Appearance.FixedLine.Font = new System.Drawing.Font("Arial", 9F);
            this.recorderGridView.Appearance.FixedLine.Options.UseFont = true;
            this.recorderGridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.recorderGridView.Appearance.FocusedRow.Options.UseFont = true;
            this.recorderGridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F);
            this.recorderGridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.recorderGridView.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.recorderGridView.Appearance.HideSelectionRow.Options.UseFont = true;
            this.recorderGridView.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.recorderGridView.Appearance.OddRow.Options.UseFont = true;
            this.recorderGridView.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F);
            this.recorderGridView.Appearance.Preview.Options.UseFont = true;
            this.recorderGridView.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F);
            this.recorderGridView.Appearance.Row.Options.UseFont = true;
            this.recorderGridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.recorderGridView.Appearance.SelectedRow.Options.UseFont = true;
            this.recorderGridView.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F);
            this.recorderGridView.Appearance.ViewCaption.Options.UseFont = true;
            this.recorderGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.rgNameColumn,
            this.rgIpColumn,
            this.rgPortColumn,
            this.rgScanTimeColumn,
            this.rgChannelColumn,
            this.rgLinkColumn,
            this.rgModeColumn});
            this.recorderGridView.CustomizationFormBounds = new System.Drawing.Rectangle(2884, 580, 210, 186);
            this.recorderGridView.GridControl = this.recorderGrid;
            this.recorderGridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.recorderGridView.Name = "recorderGridView";
            this.recorderGridView.OptionsView.ColumnAutoWidth = false;
            this.recorderGridView.OptionsView.ShowGroupPanel = false;
            this.recorderGridView.OptionsView.ShowIndicator = false;
            this.recorderGridView.Tag = 1;
            // 
            // rgNameColumn
            // 
            this.rgNameColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F);
            this.rgNameColumn.AppearanceCell.Options.UseFont = true;
            this.rgNameColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F);
            this.rgNameColumn.AppearanceHeader.Options.UseFont = true;
            this.rgNameColumn.Caption = "Name";
            this.rgNameColumn.FieldName = "Name";
            this.rgNameColumn.Name = "rgNameColumn";
            this.rgNameColumn.OptionsColumn.AllowEdit = false;
            this.rgNameColumn.OptionsColumn.AllowFocus = false;
            this.rgNameColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.rgNameColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.rgNameColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.rgNameColumn.OptionsColumn.AllowMove = false;
            this.rgNameColumn.OptionsColumn.AllowShowHide = false;
            this.rgNameColumn.OptionsColumn.AllowSize = false;
            this.rgNameColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.rgNameColumn.OptionsColumn.FixedWidth = true;
            this.rgNameColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.rgNameColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.rgNameColumn.OptionsColumn.ReadOnly = true;
            this.rgNameColumn.OptionsColumn.TabStop = false;
            this.rgNameColumn.OptionsFilter.AllowAutoFilter = false;
            this.rgNameColumn.OptionsFilter.AllowFilter = false;
            this.rgNameColumn.Visible = true;
            this.rgNameColumn.VisibleIndex = 0;
            this.rgNameColumn.Width = 102;
            // 
            // rgIpColumn
            // 
            this.rgIpColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F);
            this.rgIpColumn.AppearanceCell.Options.UseFont = true;
            this.rgIpColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F);
            this.rgIpColumn.AppearanceHeader.Options.UseFont = true;
            this.rgIpColumn.Caption = "IP";
            this.rgIpColumn.FieldName = "Ip";
            this.rgIpColumn.Name = "rgIpColumn";
            this.rgIpColumn.OptionsColumn.AllowEdit = false;
            this.rgIpColumn.OptionsColumn.AllowFocus = false;
            this.rgIpColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.rgIpColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.rgIpColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.rgIpColumn.OptionsColumn.AllowMove = false;
            this.rgIpColumn.OptionsColumn.AllowShowHide = false;
            this.rgIpColumn.OptionsColumn.AllowSize = false;
            this.rgIpColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.rgIpColumn.OptionsColumn.FixedWidth = true;
            this.rgIpColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.rgIpColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.rgIpColumn.OptionsColumn.ReadOnly = true;
            this.rgIpColumn.OptionsColumn.TabStop = false;
            this.rgIpColumn.OptionsFilter.AllowAutoFilter = false;
            this.rgIpColumn.OptionsFilter.AllowFilter = false;
            this.rgIpColumn.Visible = true;
            this.rgIpColumn.VisibleIndex = 1;
            this.rgIpColumn.Width = 108;
            // 
            // rgPortColumn
            // 
            this.rgPortColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F);
            this.rgPortColumn.AppearanceCell.Options.UseFont = true;
            this.rgPortColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F);
            this.rgPortColumn.AppearanceHeader.Options.UseFont = true;
            this.rgPortColumn.Caption = "Port";
            this.rgPortColumn.FieldName = "Port";
            this.rgPortColumn.Name = "rgPortColumn";
            this.rgPortColumn.OptionsColumn.AllowEdit = false;
            this.rgPortColumn.OptionsColumn.AllowFocus = false;
            this.rgPortColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.rgPortColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.rgPortColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.rgPortColumn.OptionsColumn.AllowMove = false;
            this.rgPortColumn.OptionsColumn.AllowShowHide = false;
            this.rgPortColumn.OptionsColumn.AllowSize = false;
            this.rgPortColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.rgPortColumn.OptionsColumn.FixedWidth = true;
            this.rgPortColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.rgPortColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.rgPortColumn.OptionsColumn.ReadOnly = true;
            this.rgPortColumn.OptionsColumn.TabStop = false;
            this.rgPortColumn.OptionsFilter.AllowAutoFilter = false;
            this.rgPortColumn.OptionsFilter.AllowFilter = false;
            this.rgPortColumn.Visible = true;
            this.rgPortColumn.VisibleIndex = 2;
            this.rgPortColumn.Width = 44;
            // 
            // rgScanTimeColumn
            // 
            this.rgScanTimeColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F);
            this.rgScanTimeColumn.AppearanceCell.Options.UseFont = true;
            this.rgScanTimeColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F);
            this.rgScanTimeColumn.AppearanceHeader.Options.UseFont = true;
            this.rgScanTimeColumn.Caption = "Scan";
            this.rgScanTimeColumn.FieldName = "ScanTime";
            this.rgScanTimeColumn.Name = "rgScanTimeColumn";
            this.rgScanTimeColumn.OptionsColumn.AllowEdit = false;
            this.rgScanTimeColumn.OptionsColumn.AllowFocus = false;
            this.rgScanTimeColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.rgScanTimeColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.rgScanTimeColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.rgScanTimeColumn.OptionsColumn.AllowMove = false;
            this.rgScanTimeColumn.OptionsColumn.AllowShowHide = false;
            this.rgScanTimeColumn.OptionsColumn.AllowSize = false;
            this.rgScanTimeColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.rgScanTimeColumn.OptionsColumn.FixedWidth = true;
            this.rgScanTimeColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.rgScanTimeColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.rgScanTimeColumn.OptionsColumn.ReadOnly = true;
            this.rgScanTimeColumn.OptionsColumn.TabStop = false;
            this.rgScanTimeColumn.OptionsFilter.AllowAutoFilter = false;
            this.rgScanTimeColumn.OptionsFilter.AllowFilter = false;
            this.rgScanTimeColumn.Visible = true;
            this.rgScanTimeColumn.VisibleIndex = 3;
            this.rgScanTimeColumn.Width = 40;
            // 
            // rgChannelColumn
            // 
            this.rgChannelColumn.Caption = "Channel";
            this.rgChannelColumn.FieldName = "Length";
            this.rgChannelColumn.Name = "rgChannelColumn";
            this.rgChannelColumn.OptionsColumn.AllowEdit = false;
            this.rgChannelColumn.OptionsColumn.AllowFocus = false;
            this.rgChannelColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.rgChannelColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.rgChannelColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.rgChannelColumn.OptionsColumn.AllowMove = false;
            this.rgChannelColumn.OptionsColumn.AllowShowHide = false;
            this.rgChannelColumn.OptionsColumn.AllowSize = false;
            this.rgChannelColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.rgChannelColumn.OptionsColumn.FixedWidth = true;
            this.rgChannelColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.rgChannelColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.rgChannelColumn.OptionsColumn.ReadOnly = true;
            this.rgChannelColumn.OptionsFilter.AllowAutoFilter = false;
            this.rgChannelColumn.OptionsFilter.AllowFilter = false;
            this.rgChannelColumn.Visible = true;
            this.rgChannelColumn.VisibleIndex = 4;
            this.rgChannelColumn.Width = 56;
            // 
            // rgLinkColumn
            // 
            this.rgLinkColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgLinkColumn.AppearanceCell.Options.UseFont = true;
            this.rgLinkColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgLinkColumn.AppearanceHeader.Options.UseFont = true;
            this.rgLinkColumn.Caption = "Link";
            this.rgLinkColumn.FieldName = "Connected";
            this.rgLinkColumn.Name = "rgLinkColumn";
            this.rgLinkColumn.OptionsColumn.AllowEdit = false;
            this.rgLinkColumn.OptionsColumn.AllowFocus = false;
            this.rgLinkColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.rgLinkColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.rgLinkColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.rgLinkColumn.OptionsColumn.AllowMove = false;
            this.rgLinkColumn.OptionsColumn.AllowShowHide = false;
            this.rgLinkColumn.OptionsColumn.AllowSize = false;
            this.rgLinkColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.rgLinkColumn.OptionsColumn.FixedWidth = true;
            this.rgLinkColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.rgLinkColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.rgLinkColumn.OptionsColumn.ReadOnly = true;
            this.rgLinkColumn.OptionsColumn.TabStop = false;
            this.rgLinkColumn.Visible = true;
            this.rgLinkColumn.VisibleIndex = 5;
            this.rgLinkColumn.Width = 32;
            // 
            // rgModeColumn
            // 
            this.rgModeColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F);
            this.rgModeColumn.AppearanceCell.Options.UseFont = true;
            this.rgModeColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F);
            this.rgModeColumn.AppearanceHeader.Options.UseFont = true;
            this.rgModeColumn.Caption = "Mode";
            this.rgModeColumn.FieldName = "Mode";
            this.rgModeColumn.Name = "rgModeColumn";
            this.rgModeColumn.OptionsColumn.AllowEdit = false;
            this.rgModeColumn.OptionsColumn.AllowFocus = false;
            this.rgModeColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.rgModeColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.rgModeColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.rgModeColumn.OptionsColumn.AllowMove = false;
            this.rgModeColumn.OptionsColumn.AllowShowHide = false;
            this.rgModeColumn.OptionsColumn.AllowSize = false;
            this.rgModeColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.rgModeColumn.OptionsColumn.FixedWidth = true;
            this.rgModeColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.rgModeColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.rgModeColumn.OptionsColumn.ReadOnly = true;
            this.rgModeColumn.OptionsColumn.TabStop = false;
            this.rgModeColumn.OptionsFilter.AllowAutoFilter = false;
            this.rgModeColumn.OptionsFilter.AllowFilter = false;
            this.rgModeColumn.Visible = true;
            this.rgModeColumn.VisibleIndex = 6;
            this.rgModeColumn.Width = 42;
            // 
            // controllerGrid
            // 
            this.controllerGrid.Location = new System.Drawing.Point(0, 351);
            this.controllerGrid.MainView = this.controllerGridView;
            this.controllerGrid.Name = "controllerGrid";
            this.controllerGrid.Size = new System.Drawing.Size(450, 294);
            this.controllerGrid.TabIndex = 10;
            this.controllerGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.controllerGridView});
            // 
            // controllerGridView
            // 
            this.controllerGridView.Appearance.FixedLine.Font = new System.Drawing.Font("Arial", 9F);
            this.controllerGridView.Appearance.FixedLine.Options.UseFont = true;
            this.controllerGridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.controllerGridView.Appearance.FocusedRow.Options.UseFont = true;
            this.controllerGridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F);
            this.controllerGridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.controllerGridView.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.controllerGridView.Appearance.HideSelectionRow.Options.UseFont = true;
            this.controllerGridView.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.controllerGridView.Appearance.OddRow.Options.UseFont = true;
            this.controllerGridView.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F);
            this.controllerGridView.Appearance.Preview.Options.UseFont = true;
            this.controllerGridView.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F);
            this.controllerGridView.Appearance.Row.Options.UseFont = true;
            this.controllerGridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.controllerGridView.Appearance.SelectedRow.Options.UseFont = true;
            this.controllerGridView.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F);
            this.controllerGridView.Appearance.ViewCaption.Options.UseFont = true;
            this.controllerGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cgNameColumn,
            this.cgIpColumn,
            this.cgPortColumn,
            this.cgScanTimeColumn,
            this.cgSlaveAddressColumn,
            this.cgSlaveCountColumn,
            this.cgLinkColumn,
            this.cgModeColumn});
            this.controllerGridView.CustomizationFormBounds = new System.Drawing.Rectangle(2884, 580, 210, 186);
            this.controllerGridView.GridControl = this.controllerGrid;
            this.controllerGridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.controllerGridView.Name = "controllerGridView";
            this.controllerGridView.OptionsView.ColumnAutoWidth = false;
            this.controllerGridView.OptionsView.ShowGroupPanel = false;
            this.controllerGridView.OptionsView.ShowIndicator = false;
            this.controllerGridView.Tag = 2;
            // 
            // cgNameColumn
            // 
            this.cgNameColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cgNameColumn.AppearanceCell.Options.UseFont = true;
            this.cgNameColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cgNameColumn.AppearanceHeader.Options.UseFont = true;
            this.cgNameColumn.Caption = "Name";
            this.cgNameColumn.FieldName = "Name";
            this.cgNameColumn.Name = "cgNameColumn";
            this.cgNameColumn.OptionsColumn.AllowEdit = false;
            this.cgNameColumn.OptionsColumn.AllowFocus = false;
            this.cgNameColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.cgNameColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.cgNameColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.cgNameColumn.OptionsColumn.AllowMove = false;
            this.cgNameColumn.OptionsColumn.AllowShowHide = false;
            this.cgNameColumn.OptionsColumn.AllowSize = false;
            this.cgNameColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.cgNameColumn.OptionsColumn.FixedWidth = true;
            this.cgNameColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.cgNameColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.cgNameColumn.OptionsColumn.ReadOnly = true;
            this.cgNameColumn.OptionsColumn.TabStop = false;
            this.cgNameColumn.OptionsFilter.AllowAutoFilter = false;
            this.cgNameColumn.OptionsFilter.AllowFilter = false;
            this.cgNameColumn.Visible = true;
            this.cgNameColumn.VisibleIndex = 0;
            this.cgNameColumn.Width = 80;
            // 
            // cgIpColumn
            // 
            this.cgIpColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cgIpColumn.AppearanceCell.Options.UseFont = true;
            this.cgIpColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cgIpColumn.AppearanceHeader.Options.UseFont = true;
            this.cgIpColumn.Caption = "IP";
            this.cgIpColumn.FieldName = "Ip";
            this.cgIpColumn.Name = "cgIpColumn";
            this.cgIpColumn.OptionsColumn.AllowEdit = false;
            this.cgIpColumn.OptionsColumn.AllowFocus = false;
            this.cgIpColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.cgIpColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.cgIpColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.cgIpColumn.OptionsColumn.AllowMove = false;
            this.cgIpColumn.OptionsColumn.AllowShowHide = false;
            this.cgIpColumn.OptionsColumn.AllowSize = false;
            this.cgIpColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.cgIpColumn.OptionsColumn.FixedWidth = true;
            this.cgIpColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.cgIpColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.cgIpColumn.OptionsColumn.ReadOnly = true;
            this.cgIpColumn.OptionsColumn.TabStop = false;
            this.cgIpColumn.OptionsFilter.AllowAutoFilter = false;
            this.cgIpColumn.OptionsFilter.AllowFilter = false;
            this.cgIpColumn.Visible = true;
            this.cgIpColumn.VisibleIndex = 1;
            this.cgIpColumn.Width = 96;
            // 
            // cgPortColumn
            // 
            this.cgPortColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cgPortColumn.AppearanceCell.Options.UseFont = true;
            this.cgPortColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cgPortColumn.AppearanceHeader.Options.UseFont = true;
            this.cgPortColumn.Caption = "Port";
            this.cgPortColumn.FieldName = "Port";
            this.cgPortColumn.Name = "cgPortColumn";
            this.cgPortColumn.OptionsColumn.AllowEdit = false;
            this.cgPortColumn.OptionsColumn.AllowFocus = false;
            this.cgPortColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.cgPortColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.cgPortColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.cgPortColumn.OptionsColumn.AllowMove = false;
            this.cgPortColumn.OptionsColumn.AllowShowHide = false;
            this.cgPortColumn.OptionsColumn.AllowSize = false;
            this.cgPortColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.cgPortColumn.OptionsColumn.FixedWidth = true;
            this.cgPortColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.cgPortColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.cgPortColumn.OptionsColumn.ReadOnly = true;
            this.cgPortColumn.OptionsColumn.TabStop = false;
            this.cgPortColumn.OptionsFilter.AllowAutoFilter = false;
            this.cgPortColumn.OptionsFilter.AllowFilter = false;
            this.cgPortColumn.Visible = true;
            this.cgPortColumn.VisibleIndex = 2;
            this.cgPortColumn.Width = 44;
            // 
            // cgScanTimeColumn
            // 
            this.cgScanTimeColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cgScanTimeColumn.AppearanceCell.Options.UseFont = true;
            this.cgScanTimeColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cgScanTimeColumn.AppearanceHeader.Options.UseFont = true;
            this.cgScanTimeColumn.Caption = "Scan";
            this.cgScanTimeColumn.FieldName = "ScanTime";
            this.cgScanTimeColumn.Name = "cgScanTimeColumn";
            this.cgScanTimeColumn.OptionsColumn.AllowEdit = false;
            this.cgScanTimeColumn.OptionsColumn.AllowFocus = false;
            this.cgScanTimeColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.cgScanTimeColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.cgScanTimeColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.cgScanTimeColumn.OptionsColumn.AllowMove = false;
            this.cgScanTimeColumn.OptionsColumn.AllowShowHide = false;
            this.cgScanTimeColumn.OptionsColumn.AllowSize = false;
            this.cgScanTimeColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.cgScanTimeColumn.OptionsColumn.FixedWidth = true;
            this.cgScanTimeColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.cgScanTimeColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.cgScanTimeColumn.OptionsColumn.ReadOnly = true;
            this.cgScanTimeColumn.OptionsColumn.TabStop = false;
            this.cgScanTimeColumn.OptionsFilter.AllowAutoFilter = false;
            this.cgScanTimeColumn.OptionsFilter.AllowFilter = false;
            this.cgScanTimeColumn.Visible = true;
            this.cgScanTimeColumn.VisibleIndex = 3;
            this.cgScanTimeColumn.Width = 40;
            // 
            // cgSlaveAddressColumn
            // 
            this.cgSlaveAddressColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cgSlaveAddressColumn.AppearanceCell.Options.UseFont = true;
            this.cgSlaveAddressColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cgSlaveAddressColumn.AppearanceHeader.Options.UseFont = true;
            this.cgSlaveAddressColumn.Caption = "Address";
            this.cgSlaveAddressColumn.FieldName = "SlaveAddr";
            this.cgSlaveAddressColumn.Name = "cgSlaveAddressColumn";
            this.cgSlaveAddressColumn.OptionsColumn.AllowEdit = false;
            this.cgSlaveAddressColumn.OptionsColumn.AllowFocus = false;
            this.cgSlaveAddressColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.cgSlaveAddressColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.cgSlaveAddressColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.cgSlaveAddressColumn.OptionsColumn.AllowMove = false;
            this.cgSlaveAddressColumn.OptionsColumn.AllowShowHide = false;
            this.cgSlaveAddressColumn.OptionsColumn.AllowSize = false;
            this.cgSlaveAddressColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.cgSlaveAddressColumn.OptionsColumn.FixedWidth = true;
            this.cgSlaveAddressColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.cgSlaveAddressColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.cgSlaveAddressColumn.OptionsColumn.ReadOnly = true;
            this.cgSlaveAddressColumn.OptionsFilter.AllowAutoFilter = false;
            this.cgSlaveAddressColumn.OptionsFilter.AllowFilter = false;
            this.cgSlaveAddressColumn.Visible = true;
            this.cgSlaveAddressColumn.VisibleIndex = 4;
            this.cgSlaveAddressColumn.Width = 54;
            // 
            // cgSlaveCountColumn
            // 
            this.cgSlaveCountColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cgSlaveCountColumn.AppearanceCell.Options.UseFont = true;
            this.cgSlaveCountColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cgSlaveCountColumn.AppearanceHeader.Options.UseFont = true;
            this.cgSlaveCountColumn.Caption = "Count";
            this.cgSlaveCountColumn.FieldName = "SlaveCount";
            this.cgSlaveCountColumn.Name = "cgSlaveCountColumn";
            this.cgSlaveCountColumn.OptionsColumn.AllowEdit = false;
            this.cgSlaveCountColumn.OptionsColumn.AllowFocus = false;
            this.cgSlaveCountColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.cgSlaveCountColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.cgSlaveCountColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.cgSlaveCountColumn.OptionsColumn.AllowMove = false;
            this.cgSlaveCountColumn.OptionsColumn.AllowShowHide = false;
            this.cgSlaveCountColumn.OptionsColumn.AllowSize = false;
            this.cgSlaveCountColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.cgSlaveCountColumn.OptionsColumn.FixedWidth = true;
            this.cgSlaveCountColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.cgSlaveCountColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.cgSlaveCountColumn.OptionsColumn.ReadOnly = true;
            this.cgSlaveCountColumn.OptionsFilter.AllowAutoFilter = false;
            this.cgSlaveCountColumn.OptionsFilter.AllowFilter = false;
            this.cgSlaveCountColumn.Visible = true;
            this.cgSlaveCountColumn.VisibleIndex = 5;
            this.cgSlaveCountColumn.Width = 42;
            // 
            // cgLinkColumn
            // 
            this.cgLinkColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cgLinkColumn.AppearanceCell.Options.UseFont = true;
            this.cgLinkColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cgLinkColumn.AppearanceHeader.Options.UseFont = true;
            this.cgLinkColumn.Caption = "Link";
            this.cgLinkColumn.FieldName = "Connected";
            this.cgLinkColumn.Name = "cgLinkColumn";
            this.cgLinkColumn.OptionsColumn.AllowEdit = false;
            this.cgLinkColumn.OptionsColumn.AllowFocus = false;
            this.cgLinkColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.cgLinkColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.cgLinkColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.cgLinkColumn.OptionsColumn.AllowMove = false;
            this.cgLinkColumn.OptionsColumn.AllowShowHide = false;
            this.cgLinkColumn.OptionsColumn.AllowSize = false;
            this.cgLinkColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.cgLinkColumn.OptionsColumn.FixedWidth = true;
            this.cgLinkColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.cgLinkColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.cgLinkColumn.OptionsColumn.ReadOnly = true;
            this.cgLinkColumn.Visible = true;
            this.cgLinkColumn.VisibleIndex = 6;
            this.cgLinkColumn.Width = 32;
            // 
            // cgModeColumn
            // 
            this.cgModeColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cgModeColumn.AppearanceCell.Options.UseFont = true;
            this.cgModeColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cgModeColumn.AppearanceHeader.Options.UseFont = true;
            this.cgModeColumn.Caption = "Mode";
            this.cgModeColumn.FieldName = "Mode";
            this.cgModeColumn.Name = "cgModeColumn";
            this.cgModeColumn.OptionsColumn.AllowEdit = false;
            this.cgModeColumn.OptionsColumn.AllowFocus = false;
            this.cgModeColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.cgModeColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.cgModeColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.cgModeColumn.OptionsColumn.AllowMove = false;
            this.cgModeColumn.OptionsColumn.AllowShowHide = false;
            this.cgModeColumn.OptionsColumn.AllowSize = false;
            this.cgModeColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.cgModeColumn.OptionsColumn.FixedWidth = true;
            this.cgModeColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.cgModeColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.cgModeColumn.OptionsColumn.ReadOnly = true;
            this.cgModeColumn.OptionsColumn.TabStop = false;
            this.cgModeColumn.OptionsFilter.AllowAutoFilter = false;
            this.cgModeColumn.OptionsFilter.AllowFilter = false;
            this.cgModeColumn.Visible = true;
            this.cgModeColumn.VisibleIndex = 7;
            this.cgModeColumn.Width = 42;
            // 
            // plcGrid
            // 
            this.plcGrid.Location = new System.Drawing.Point(454, 351);
            this.plcGrid.MainView = this.plcGridView;
            this.plcGrid.Name = "plcGrid";
            this.plcGrid.Size = new System.Drawing.Size(450, 294);
            this.plcGrid.TabIndex = 11;
            this.plcGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.plcGridView});
            // 
            // plcGridView
            // 
            this.plcGridView.Appearance.FixedLine.Font = new System.Drawing.Font("Arial", 9F);
            this.plcGridView.Appearance.FixedLine.Options.UseFont = true;
            this.plcGridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.plcGridView.Appearance.FocusedRow.Options.UseFont = true;
            this.plcGridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F);
            this.plcGridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.plcGridView.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.plcGridView.Appearance.HideSelectionRow.Options.UseFont = true;
            this.plcGridView.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.plcGridView.Appearance.OddRow.Options.UseFont = true;
            this.plcGridView.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F);
            this.plcGridView.Appearance.Preview.Options.UseFont = true;
            this.plcGridView.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F);
            this.plcGridView.Appearance.Row.Options.UseFont = true;
            this.plcGridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.plcGridView.Appearance.SelectedRow.Options.UseFont = true;
            this.plcGridView.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F);
            this.plcGridView.Appearance.ViewCaption.Options.UseFont = true;
            this.plcGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.pgNameColumn,
            this.pgIpColumn,
            this.pgPortColumn,
            this.pgScanTimeColumn,
            this.pgLinkColumn,
            this.pgModeColumn});
            this.plcGridView.CustomizationFormBounds = new System.Drawing.Rectangle(2884, 580, 210, 186);
            this.plcGridView.GridControl = this.plcGrid;
            this.plcGridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.plcGridView.Name = "plcGridView";
            this.plcGridView.OptionsView.ColumnAutoWidth = false;
            this.plcGridView.OptionsView.ShowGroupPanel = false;
            this.plcGridView.OptionsView.ShowIndicator = false;
            this.plcGridView.Tag = 3;
            // 
            // pgNameColumn
            // 
            this.pgNameColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F);
            this.pgNameColumn.AppearanceCell.Options.UseFont = true;
            this.pgNameColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F);
            this.pgNameColumn.AppearanceHeader.Options.UseFont = true;
            this.pgNameColumn.Caption = "Name";
            this.pgNameColumn.FieldName = "Name";
            this.pgNameColumn.Name = "pgNameColumn";
            this.pgNameColumn.OptionsColumn.AllowEdit = false;
            this.pgNameColumn.OptionsColumn.AllowFocus = false;
            this.pgNameColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.pgNameColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.pgNameColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.pgNameColumn.OptionsColumn.AllowMove = false;
            this.pgNameColumn.OptionsColumn.AllowShowHide = false;
            this.pgNameColumn.OptionsColumn.AllowSize = false;
            this.pgNameColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.pgNameColumn.OptionsColumn.FixedWidth = true;
            this.pgNameColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.pgNameColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.pgNameColumn.OptionsColumn.ReadOnly = true;
            this.pgNameColumn.OptionsColumn.TabStop = false;
            this.pgNameColumn.OptionsFilter.AllowAutoFilter = false;
            this.pgNameColumn.OptionsFilter.AllowFilter = false;
            this.pgNameColumn.Visible = true;
            this.pgNameColumn.VisibleIndex = 0;
            this.pgNameColumn.Width = 102;
            // 
            // pgIpColumn
            // 
            this.pgIpColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F);
            this.pgIpColumn.AppearanceCell.Options.UseFont = true;
            this.pgIpColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F);
            this.pgIpColumn.AppearanceHeader.Options.UseFont = true;
            this.pgIpColumn.Caption = "IP";
            this.pgIpColumn.FieldName = "Ip";
            this.pgIpColumn.Name = "pgIpColumn";
            this.pgIpColumn.OptionsColumn.AllowEdit = false;
            this.pgIpColumn.OptionsColumn.AllowFocus = false;
            this.pgIpColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.pgIpColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.pgIpColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.pgIpColumn.OptionsColumn.AllowMove = false;
            this.pgIpColumn.OptionsColumn.AllowShowHide = false;
            this.pgIpColumn.OptionsColumn.AllowSize = false;
            this.pgIpColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.pgIpColumn.OptionsColumn.FixedWidth = true;
            this.pgIpColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.pgIpColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.pgIpColumn.OptionsColumn.ReadOnly = true;
            this.pgIpColumn.OptionsColumn.TabStop = false;
            this.pgIpColumn.OptionsFilter.AllowAutoFilter = false;
            this.pgIpColumn.OptionsFilter.AllowFilter = false;
            this.pgIpColumn.Visible = true;
            this.pgIpColumn.VisibleIndex = 1;
            this.pgIpColumn.Width = 108;
            // 
            // pgPortColumn
            // 
            this.pgPortColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F);
            this.pgPortColumn.AppearanceCell.Options.UseFont = true;
            this.pgPortColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F);
            this.pgPortColumn.AppearanceHeader.Options.UseFont = true;
            this.pgPortColumn.Caption = "Port";
            this.pgPortColumn.FieldName = "Port";
            this.pgPortColumn.Name = "pgPortColumn";
            this.pgPortColumn.OptionsColumn.AllowEdit = false;
            this.pgPortColumn.OptionsColumn.AllowFocus = false;
            this.pgPortColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.pgPortColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.pgPortColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.pgPortColumn.OptionsColumn.AllowMove = false;
            this.pgPortColumn.OptionsColumn.AllowShowHide = false;
            this.pgPortColumn.OptionsColumn.AllowSize = false;
            this.pgPortColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.pgPortColumn.OptionsColumn.FixedWidth = true;
            this.pgPortColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.pgPortColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.pgPortColumn.OptionsColumn.ReadOnly = true;
            this.pgPortColumn.OptionsColumn.TabStop = false;
            this.pgPortColumn.OptionsFilter.AllowAutoFilter = false;
            this.pgPortColumn.OptionsFilter.AllowFilter = false;
            this.pgPortColumn.Visible = true;
            this.pgPortColumn.VisibleIndex = 2;
            this.pgPortColumn.Width = 44;
            // 
            // pgScanTimeColumn
            // 
            this.pgScanTimeColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F);
            this.pgScanTimeColumn.AppearanceCell.Options.UseFont = true;
            this.pgScanTimeColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F);
            this.pgScanTimeColumn.AppearanceHeader.Options.UseFont = true;
            this.pgScanTimeColumn.Caption = "Scan";
            this.pgScanTimeColumn.FieldName = "ScanTime";
            this.pgScanTimeColumn.Name = "pgScanTimeColumn";
            this.pgScanTimeColumn.OptionsColumn.AllowEdit = false;
            this.pgScanTimeColumn.OptionsColumn.AllowFocus = false;
            this.pgScanTimeColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.pgScanTimeColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.pgScanTimeColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.pgScanTimeColumn.OptionsColumn.AllowMove = false;
            this.pgScanTimeColumn.OptionsColumn.AllowShowHide = false;
            this.pgScanTimeColumn.OptionsColumn.AllowSize = false;
            this.pgScanTimeColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.pgScanTimeColumn.OptionsColumn.FixedWidth = true;
            this.pgScanTimeColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.pgScanTimeColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.pgScanTimeColumn.OptionsColumn.ReadOnly = true;
            this.pgScanTimeColumn.OptionsColumn.TabStop = false;
            this.pgScanTimeColumn.OptionsFilter.AllowAutoFilter = false;
            this.pgScanTimeColumn.OptionsFilter.AllowFilter = false;
            this.pgScanTimeColumn.Visible = true;
            this.pgScanTimeColumn.VisibleIndex = 3;
            this.pgScanTimeColumn.Width = 40;
            // 
            // pgLinkColumn
            // 
            this.pgLinkColumn.Caption = "Link";
            this.pgLinkColumn.FieldName = "Connected";
            this.pgLinkColumn.Name = "pgLinkColumn";
            this.pgLinkColumn.OptionsColumn.AllowEdit = false;
            this.pgLinkColumn.OptionsColumn.AllowFocus = false;
            this.pgLinkColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.pgLinkColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.pgLinkColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.pgLinkColumn.OptionsColumn.AllowMove = false;
            this.pgLinkColumn.OptionsColumn.AllowShowHide = false;
            this.pgLinkColumn.OptionsColumn.AllowSize = false;
            this.pgLinkColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.pgLinkColumn.OptionsColumn.FixedWidth = true;
            this.pgLinkColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.pgLinkColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.pgLinkColumn.OptionsColumn.ReadOnly = true;
            this.pgLinkColumn.OptionsColumn.TabStop = false;
            this.pgLinkColumn.Visible = true;
            this.pgLinkColumn.VisibleIndex = 4;
            this.pgLinkColumn.Width = 32;
            // 
            // pgModeColumn
            // 
            this.pgModeColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F);
            this.pgModeColumn.AppearanceCell.Options.UseFont = true;
            this.pgModeColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F);
            this.pgModeColumn.AppearanceHeader.Options.UseFont = true;
            this.pgModeColumn.Caption = "Mode";
            this.pgModeColumn.FieldName = "Mode";
            this.pgModeColumn.Name = "pgModeColumn";
            this.pgModeColumn.OptionsColumn.AllowEdit = false;
            this.pgModeColumn.OptionsColumn.AllowFocus = false;
            this.pgModeColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.pgModeColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.pgModeColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.pgModeColumn.OptionsColumn.AllowMove = false;
            this.pgModeColumn.OptionsColumn.AllowShowHide = false;
            this.pgModeColumn.OptionsColumn.AllowSize = false;
            this.pgModeColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.pgModeColumn.OptionsColumn.FixedWidth = true;
            this.pgModeColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.pgModeColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.pgModeColumn.OptionsColumn.ReadOnly = true;
            this.pgModeColumn.OptionsColumn.TabStop = false;
            this.pgModeColumn.OptionsFilter.AllowAutoFilter = false;
            this.pgModeColumn.OptionsFilter.AllowFilter = false;
            this.pgModeColumn.Visible = true;
            this.pgModeColumn.VisibleIndex = 5;
            this.pgModeColumn.Width = 42;
            // 
            // CtrlViewDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CtrlViewDevice";
            this.Size = new System.Drawing.Size(904, 645);
            this.Enter += new System.EventHandler(this.CtrlViewDevice_Enter);
            this.bgPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.powerMeterGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.powerMeterGridView)).EndInit();
            this.powerMeterPanel.ResumeLayout(false);
            this.ulPanel1.ResumeLayout(false);
            this.ulPanel2.ResumeLayout(false);
            this.recorderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recorderGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recorderGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controllerGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controllerGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plcGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl powerMeterGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView powerMeterGridView;
        private Ulee.Controls.UlPanel ulPanel2;
        private Ulee.Controls.UlPanel recorderPanel;
        private Ulee.Controls.UlPanel ulPanel1;
        private Ulee.Controls.UlPanel powerMeterPanel;
        private DevExpress.XtraGrid.Columns.GridColumn pmNameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn pmIpColumn;
        private DevExpress.XtraGrid.Columns.GridColumn pmPortColumn;
        private DevExpress.XtraGrid.Columns.GridColumn pmScanTimeColumn;
        private DevExpress.XtraGrid.Columns.GridColumn pmModeColumn;
        private DevExpress.XtraGrid.GridControl recorderGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView recorderGridView;
        private DevExpress.XtraGrid.Columns.GridColumn rgNameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn rgIpColumn;
        private DevExpress.XtraGrid.Columns.GridColumn rgPortColumn;
        private DevExpress.XtraGrid.Columns.GridColumn rgScanTimeColumn;
        private DevExpress.XtraGrid.Columns.GridColumn rgModeColumn;
        private DevExpress.XtraGrid.GridControl plcGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView plcGridView;
        private DevExpress.XtraGrid.Columns.GridColumn pgNameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn pgIpColumn;
        private DevExpress.XtraGrid.Columns.GridColumn pgPortColumn;
        private DevExpress.XtraGrid.Columns.GridColumn pgScanTimeColumn;
        private DevExpress.XtraGrid.Columns.GridColumn pgModeColumn;
        private DevExpress.XtraGrid.GridControl controllerGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView controllerGridView;
        private DevExpress.XtraGrid.Columns.GridColumn cgNameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn cgIpColumn;
        private DevExpress.XtraGrid.Columns.GridColumn cgPortColumn;
        private DevExpress.XtraGrid.Columns.GridColumn cgScanTimeColumn;
        private DevExpress.XtraGrid.Columns.GridColumn cgModeColumn;
        private DevExpress.XtraGrid.Columns.GridColumn cgSlaveAddressColumn;
        private DevExpress.XtraGrid.Columns.GridColumn cgSlaveCountColumn;
        private DevExpress.XtraGrid.Columns.GridColumn pmPhaseColumn;
        private DevExpress.XtraGrid.Columns.GridColumn rgChannelColumn;
        private System.Windows.Forms.Button pmModifyButton;
        private DevExpress.XtraGrid.Columns.GridColumn pmLinkColumn;
        private DevExpress.XtraGrid.Columns.GridColumn pgLinkColumn;
        private DevExpress.XtraGrid.Columns.GridColumn cgLinkColumn;
        private DevExpress.XtraGrid.Columns.GridColumn rgLinkColumn;
        private System.Windows.Forms.Button pgModifyButton;
        private System.Windows.Forms.Button rgModifyButton;
        private System.Windows.Forms.Button cgModifyButton;
    }
}