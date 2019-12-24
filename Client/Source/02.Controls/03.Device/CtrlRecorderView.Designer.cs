namespace Hnc.Calorimeter.Client
{
    partial class CtrlRecorderView
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
            this.titleEdit = new Ulee.Controls.UlPanel();
            this.recorderGrid = new DevExpress.XtraGrid.GridControl();
            this.recorderGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.rgNameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rgValueColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rgUnitColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bgPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recorderGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recorderGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // bgPanel
            // 
            this.bgPanel.BevelInner = Ulee.Controls.EUlBevelStyle.Raised;
            this.bgPanel.Controls.Add(this.recorderGrid);
            this.bgPanel.Controls.Add(this.titleEdit);
            this.bgPanel.Dock = System.Windows.Forms.DockStyle.None;
            this.bgPanel.Size = new System.Drawing.Size(450, 915);
            // 
            // titleEdit
            // 
            this.titleEdit.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.titleEdit.BevelInner = Ulee.Controls.EUlBevelStyle.None;
            this.titleEdit.BevelOuter = Ulee.Controls.EUlBevelStyle.Lowered;
            this.titleEdit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleEdit.ForeColor = System.Drawing.Color.White;
            this.titleEdit.InnerColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.titleEdit.InnerColor2 = System.Drawing.Color.White;
            this.titleEdit.Location = new System.Drawing.Point(6, 6);
            this.titleEdit.Name = "titleEdit";
            this.titleEdit.OuterColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.titleEdit.OuterColor2 = System.Drawing.Color.White;
            this.titleEdit.Size = new System.Drawing.Size(438, 28);
            this.titleEdit.Spacing = 0;
            this.titleEdit.TabIndex = 8;
            this.titleEdit.Text = "RECORDER";
            this.titleEdit.TextHAlign = Ulee.Controls.EUlHoriAlign.Center;
            this.titleEdit.TextVAlign = Ulee.Controls.EUlVertAlign.Middle;
            // 
            // recorderGrid
            // 
            this.recorderGrid.Cursor = System.Windows.Forms.Cursors.Default;
            this.recorderGrid.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recorderGrid.Location = new System.Drawing.Point(6, 40);
            this.recorderGrid.MainView = this.recorderGridView;
            this.recorderGrid.Name = "recorderGrid";
            this.recorderGrid.Size = new System.Drawing.Size(438, 868);
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
            this.rgValueColumn,
            this.rgUnitColumn});
            this.recorderGridView.CustomizationFormBounds = new System.Drawing.Rectangle(2884, 580, 210, 186);
            this.recorderGridView.GridControl = this.recorderGrid;
            this.recorderGridView.Name = "recorderGridView";
            this.recorderGridView.OptionsView.ColumnAutoWidth = false;
            this.recorderGridView.OptionsView.ShowGroupPanel = false;
            this.recorderGridView.OptionsView.ShowIndicator = false;
            this.recorderGridView.Tag = 0;
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
            this.rgNameColumn.Width = 290;
            // 
            // rgValueColumn
            // 
            this.rgValueColumn.AppearanceCell.Font = new System.Drawing.Font("Arial", 9F);
            this.rgValueColumn.AppearanceCell.Options.UseFont = true;
            this.rgValueColumn.AppearanceHeader.Font = new System.Drawing.Font("Arial", 9F);
            this.rgValueColumn.AppearanceHeader.Options.UseFont = true;
            this.rgValueColumn.Caption = "Value";
            this.rgValueColumn.DisplayFormat.FormatString = "{0:F2}";
            this.rgValueColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.rgValueColumn.FieldName = "Value";
            this.rgValueColumn.Name = "rgValueColumn";
            this.rgValueColumn.OptionsColumn.AllowEdit = false;
            this.rgValueColumn.OptionsColumn.AllowFocus = false;
            this.rgValueColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.rgValueColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.rgValueColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.rgValueColumn.OptionsColumn.AllowMove = false;
            this.rgValueColumn.OptionsColumn.AllowShowHide = false;
            this.rgValueColumn.OptionsColumn.AllowSize = false;
            this.rgValueColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.rgValueColumn.OptionsColumn.FixedWidth = true;
            this.rgValueColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.rgValueColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.rgValueColumn.OptionsColumn.ReadOnly = true;
            this.rgValueColumn.OptionsColumn.TabStop = false;
            this.rgValueColumn.OptionsFilter.AllowAutoFilter = false;
            this.rgValueColumn.OptionsFilter.AllowFilter = false;
            this.rgValueColumn.Visible = true;
            this.rgValueColumn.VisibleIndex = 1;
            this.rgValueColumn.Width = 60;
            // 
            // rgUnitColumn
            // 
            this.rgUnitColumn.Caption = "Unit";
            this.rgUnitColumn.FieldName = "Unit";
            this.rgUnitColumn.Name = "rgUnitColumn";
            this.rgUnitColumn.OptionsColumn.AllowEdit = false;
            this.rgUnitColumn.OptionsColumn.AllowFocus = false;
            this.rgUnitColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.rgUnitColumn.OptionsColumn.AllowIncrementalSearch = false;
            this.rgUnitColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.rgUnitColumn.OptionsColumn.AllowMove = false;
            this.rgUnitColumn.OptionsColumn.AllowShowHide = false;
            this.rgUnitColumn.OptionsColumn.AllowSize = false;
            this.rgUnitColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.rgUnitColumn.OptionsColumn.FixedWidth = true;
            this.rgUnitColumn.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.False;
            this.rgUnitColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.rgUnitColumn.OptionsColumn.ReadOnly = true;
            this.rgUnitColumn.OptionsFilter.AllowAutoFilter = false;
            this.rgUnitColumn.OptionsFilter.AllowFilter = false;
            this.rgUnitColumn.Visible = true;
            this.rgUnitColumn.VisibleIndex = 2;
            this.rgUnitColumn.Width = 60;
            // 
            // CtrlRecorderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CtrlRecorderView";
            this.Size = new System.Drawing.Size(450, 915);
            this.Load += new System.EventHandler(this.CtrlRecorderView_Load);
            this.bgPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recorderGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recorderGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ulee.Controls.UlPanel titleEdit;
        private DevExpress.XtraGrid.GridControl recorderGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView recorderGridView;
        private DevExpress.XtraGrid.Columns.GridColumn rgNameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn rgValueColumn;
        private DevExpress.XtraGrid.Columns.GridColumn rgUnitColumn;
    }
}
