﻿namespace Hnc.Calorimeter.Client
{
    partial class CtrlViewRight
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlViewRight));
            this.viewPanel = new Ulee.Controls.UlPanel();
            this.menuPanel = new Ulee.Controls.UlPanel();
            this.excelButton = new DevExpress.XtraEditors.SimpleButton();
            this.printButton = new DevExpress.XtraEditors.SimpleButton();
            this.openButton = new DevExpress.XtraEditors.SimpleButton();
            this.graphButton = new DevExpress.XtraEditors.SimpleButton();
            this.reportButton = new DevExpress.XtraEditors.SimpleButton();
            this.bgPanel.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgPanel
            // 
            this.bgPanel.BevelOuter = Ulee.Controls.EUlBevelStyle.None;
            this.bgPanel.Controls.Add(this.viewPanel);
            this.bgPanel.Controls.Add(this.menuPanel);
            this.bgPanel.Size = new System.Drawing.Size(1816, 915);
            // 
            // viewPanel
            // 
            this.viewPanel.BevelInner = Ulee.Controls.EUlBevelStyle.None;
            this.viewPanel.BevelOuter = Ulee.Controls.EUlBevelStyle.None;
            this.viewPanel.InnerColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.viewPanel.InnerColor2 = System.Drawing.Color.White;
            this.viewPanel.Location = new System.Drawing.Point(0, 0);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.OuterColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.viewPanel.OuterColor2 = System.Drawing.Color.White;
            this.viewPanel.Size = new System.Drawing.Size(1728, 915);
            this.viewPanel.Spacing = 0;
            this.viewPanel.TabIndex = 4;
            this.viewPanel.TextHAlign = Ulee.Controls.EUlHoriAlign.Center;
            this.viewPanel.TextVAlign = Ulee.Controls.EUlVertAlign.Middle;
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.Silver;
            this.menuPanel.BevelInner = Ulee.Controls.EUlBevelStyle.None;
            this.menuPanel.BevelOuter = Ulee.Controls.EUlBevelStyle.Lowered;
            this.menuPanel.Controls.Add(this.excelButton);
            this.menuPanel.Controls.Add(this.printButton);
            this.menuPanel.Controls.Add(this.openButton);
            this.menuPanel.Controls.Add(this.graphButton);
            this.menuPanel.Controls.Add(this.reportButton);
            this.menuPanel.InnerColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.menuPanel.InnerColor2 = System.Drawing.Color.White;
            this.menuPanel.Location = new System.Drawing.Point(1732, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.OuterColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.menuPanel.OuterColor2 = System.Drawing.Color.White;
            this.menuPanel.Size = new System.Drawing.Size(84, 915);
            this.menuPanel.Spacing = 0;
            this.menuPanel.TabIndex = 3;
            this.menuPanel.TextHAlign = Ulee.Controls.EUlHoriAlign.Center;
            this.menuPanel.TextVAlign = Ulee.Controls.EUlVertAlign.Middle;
            // 
            // excelButton
            // 
            this.excelButton.AllowFocus = false;
            this.excelButton.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excelButton.Appearance.Options.UseBorderColor = true;
            this.excelButton.Appearance.Options.UseFont = true;
            this.excelButton.Appearance.Options.UseTextOptions = true;
            this.excelButton.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.excelButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("excelButton.ImageOptions.Image")));
            this.excelButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.excelButton.ImageOptions.ImageToTextIndent = 10;
            this.excelButton.Location = new System.Drawing.Point(2, 795);
            this.excelButton.Name = "excelButton";
            this.excelButton.Size = new System.Drawing.Size(80, 58);
            this.excelButton.TabIndex = 26;
            this.excelButton.TabStop = false;
            this.excelButton.Text = "Excel";
            this.excelButton.Click += new System.EventHandler(this.excelButton_Click);
            // 
            // printButton
            // 
            this.printButton.AllowFocus = false;
            this.printButton.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printButton.Appearance.Options.UseBorderColor = true;
            this.printButton.Appearance.Options.UseFont = true;
            this.printButton.Appearance.Options.UseTextOptions = true;
            this.printButton.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.printButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("printButton.ImageOptions.Image")));
            this.printButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.printButton.ImageOptions.ImageToTextIndent = 2;
            this.printButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.printButton.Location = new System.Drawing.Point(2, 855);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(80, 58);
            this.printButton.TabIndex = 25;
            this.printButton.TabStop = false;
            this.printButton.Text = "Print";
            // 
            // openButton
            // 
            this.openButton.AllowFocus = false;
            this.openButton.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openButton.Appearance.Options.UseBorderColor = true;
            this.openButton.Appearance.Options.UseFont = true;
            this.openButton.Appearance.Options.UseTextOptions = true;
            this.openButton.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.openButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("openButton.ImageOptions.Image")));
            this.openButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.openButton.ImageOptions.ImageToTextIndent = 10;
            this.openButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.openButton.Location = new System.Drawing.Point(2, 735);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(80, 58);
            this.openButton.TabIndex = 24;
            this.openButton.TabStop = false;
            this.openButton.Text = "Open";
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // graphButton
            // 
            this.graphButton.AllowFocus = false;
            this.graphButton.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graphButton.Appearance.Options.UseBorderColor = true;
            this.graphButton.Appearance.Options.UseFont = true;
            this.graphButton.Appearance.Options.UseTextOptions = true;
            this.graphButton.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.graphButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("graphButton.ImageOptions.Image")));
            this.graphButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.graphButton.ImageOptions.ImageToTextIndent = 8;
            this.graphButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.graphButton.Location = new System.Drawing.Point(2, 62);
            this.graphButton.Name = "graphButton";
            this.graphButton.Size = new System.Drawing.Size(80, 58);
            this.graphButton.TabIndex = 13;
            this.graphButton.TabStop = false;
            this.graphButton.Text = "Graph";
            // 
            // reportButton
            // 
            this.reportButton.AllowFocus = false;
            this.reportButton.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportButton.Appearance.Options.UseBorderColor = true;
            this.reportButton.Appearance.Options.UseFont = true;
            this.reportButton.Appearance.Options.UseTextOptions = true;
            this.reportButton.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.reportButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("reportButton.ImageOptions.Image")));
            this.reportButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.reportButton.ImageOptions.ImageToTextIndent = 4;
            this.reportButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.reportButton.Location = new System.Drawing.Point(2, 2);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(80, 58);
            this.reportButton.TabIndex = 11;
            this.reportButton.TabStop = false;
            this.reportButton.Text = "Report";
            // 
            // CtrlViewRight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CtrlViewRight";
            this.Size = new System.Drawing.Size(1816, 915);
            this.Load += new System.EventHandler(this.CtrlViewBottom_Load);
            this.bgPanel.ResumeLayout(false);
            this.menuPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ulee.Controls.UlPanel viewPanel;
        private Ulee.Controls.UlPanel menuPanel;
        private DevExpress.XtraEditors.SimpleButton graphButton;
        private DevExpress.XtraEditors.SimpleButton reportButton;
        private DevExpress.XtraEditors.SimpleButton excelButton;
        private DevExpress.XtraEditors.SimpleButton printButton;
        private DevExpress.XtraEditors.SimpleButton openButton;
    }
}
