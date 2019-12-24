﻿namespace Hnc.Calorimeter.Server
{
    partial class FormServerMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServerMain));
            this.menuPanel = new Ulee.Controls.UlPanel();
            this.logoffButton = new DevExpress.XtraEditors.SimpleButton();
            this.calibButton = new DevExpress.XtraEditors.SimpleButton();
            this.loginButton = new DevExpress.XtraEditors.SimpleButton();
            this.configButton = new DevExpress.XtraEditors.SimpleButton();
            this.logButton = new DevExpress.XtraEditors.SimpleButton();
            this.exitButton = new DevExpress.XtraEditors.SimpleButton();
            this.viewButton = new DevExpress.XtraEditors.SimpleButton();
            this.viewPanel = new Ulee.Controls.UlPanel();
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.dateTimeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.companyLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.UserLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.messageLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.powerMeterLedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.recorderLedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.controllerLedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.plcLedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.logoffTimer = new System.Windows.Forms.Timer(this.components);
            this.bgPanel.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.trayMenu.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgPanel
            // 
            this.bgPanel.BevelOuter = Ulee.Controls.EUlBevelStyle.Single;
            this.bgPanel.Controls.Add(this.viewPanel);
            this.bgPanel.Controls.Add(this.menuPanel);
            this.bgPanel.Dock = System.Windows.Forms.DockStyle.None;
            this.bgPanel.Size = new System.Drawing.Size(1008, 729);
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.Silver;
            this.menuPanel.BevelInner = Ulee.Controls.EUlBevelStyle.None;
            this.menuPanel.BevelOuter = Ulee.Controls.EUlBevelStyle.Lowered;
            this.menuPanel.Controls.Add(this.logoffButton);
            this.menuPanel.Controls.Add(this.calibButton);
            this.menuPanel.Controls.Add(this.loginButton);
            this.menuPanel.Controls.Add(this.configButton);
            this.menuPanel.Controls.Add(this.logButton);
            this.menuPanel.Controls.Add(this.exitButton);
            this.menuPanel.Controls.Add(this.viewButton);
            this.menuPanel.InnerColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.menuPanel.InnerColor2 = System.Drawing.Color.White;
            this.menuPanel.Location = new System.Drawing.Point(8, 659);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.OuterColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.menuPanel.OuterColor2 = System.Drawing.Color.White;
            this.menuPanel.Size = new System.Drawing.Size(992, 62);
            this.menuPanel.Spacing = 0;
            this.menuPanel.TabIndex = 1;
            this.menuPanel.TextHAlign = Ulee.Controls.EUlHoriAlign.Center;
            this.menuPanel.TextVAlign = Ulee.Controls.EUlVertAlign.Middle;
            // 
            // logoffButton
            // 
            this.logoffButton.AllowFocus = false;
            this.logoffButton.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoffButton.Appearance.Options.UseBorderColor = true;
            this.logoffButton.Appearance.Options.UseFont = true;
            this.logoffButton.Appearance.Options.UseTextOptions = true;
            this.logoffButton.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.logoffButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("logoffButton.ImageOptions.Image")));
            this.logoffButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.logoffButton.ImageOptions.ImageToTextIndent = 12;
            this.logoffButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.logoffButton.Location = new System.Drawing.Point(828, 2);
            this.logoffButton.Name = "logoffButton";
            this.logoffButton.Size = new System.Drawing.Size(80, 58);
            this.logoffButton.TabIndex = 14;
            this.logoffButton.TabStop = false;
            this.logoffButton.Text = "Logoff";
            this.logoffButton.Click += new System.EventHandler(this.logoffButton_Click);
            // 
            // calibButton
            // 
            this.calibButton.AllowFocus = false;
            this.calibButton.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calibButton.Appearance.Options.UseBorderColor = true;
            this.calibButton.Appearance.Options.UseFont = true;
            this.calibButton.Appearance.Options.UseTextOptions = true;
            this.calibButton.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.calibButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("calibButton.ImageOptions.Image")));
            this.calibButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.calibButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.calibButton.Location = new System.Drawing.Point(166, 2);
            this.calibButton.Name = "calibButton";
            this.calibButton.Size = new System.Drawing.Size(80, 58);
            this.calibButton.TabIndex = 13;
            this.calibButton.TabStop = false;
            this.calibButton.Text = "Calibration";
            // 
            // loginButton
            // 
            this.loginButton.AllowFocus = false;
            this.loginButton.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.Appearance.Options.UseBorderColor = true;
            this.loginButton.Appearance.Options.UseFont = true;
            this.loginButton.Appearance.Options.UseTextOptions = true;
            this.loginButton.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.loginButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("loginButton.ImageOptions.Image")));
            this.loginButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.loginButton.ImageOptions.ImageToTextIndent = 10;
            this.loginButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.loginButton.Location = new System.Drawing.Point(746, 2);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(80, 58);
            this.loginButton.TabIndex = 12;
            this.loginButton.TabStop = false;
            this.loginButton.Text = "Login";
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // configButton
            // 
            this.configButton.AllowFocus = false;
            this.configButton.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configButton.Appearance.Options.UseBorderColor = true;
            this.configButton.Appearance.Options.UseFont = true;
            this.configButton.Appearance.Options.UseTextOptions = true;
            this.configButton.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.configButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("configButton.ImageOptions.Image")));
            this.configButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.configButton.Location = new System.Drawing.Point(248, 2);
            this.configButton.Name = "configButton";
            this.configButton.Size = new System.Drawing.Size(80, 58);
            this.configButton.TabIndex = 9;
            this.configButton.TabStop = false;
            this.configButton.Text = "Config";
            // 
            // logButton
            // 
            this.logButton.AllowFocus = false;
            this.logButton.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logButton.Appearance.Options.UseBorderColor = true;
            this.logButton.Appearance.Options.UseFont = true;
            this.logButton.Appearance.Options.UseTextOptions = true;
            this.logButton.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.logButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("logButton.ImageOptions.Image")));
            this.logButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.logButton.Location = new System.Drawing.Point(84, 2);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(80, 58);
            this.logButton.TabIndex = 11;
            this.logButton.TabStop = false;
            this.logButton.Text = "Log";
            // 
            // exitButton
            // 
            this.exitButton.AllowFocus = false;
            this.exitButton.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Appearance.Options.UseFont = true;
            this.exitButton.Appearance.Options.UseTextOptions = true;
            this.exitButton.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.exitButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("exitButton.ImageOptions.Image")));
            this.exitButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.exitButton.ImageOptions.ImageToTextIndent = 10;
            this.exitButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.exitButton.Location = new System.Drawing.Point(910, 2);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(80, 58);
            this.exitButton.TabIndex = 7;
            this.exitButton.TabStop = false;
            this.exitButton.Text = "Exit";
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // viewButton
            // 
            this.viewButton.AllowFocus = false;
            this.viewButton.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewButton.Appearance.Options.UseFont = true;
            this.viewButton.Appearance.Options.UseTextOptions = true;
            this.viewButton.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.viewButton.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 9F);
            this.viewButton.AppearanceDisabled.Options.UseFont = true;
            this.viewButton.AppearanceHovered.Font = new System.Drawing.Font("Arial", 9F);
            this.viewButton.AppearanceHovered.Options.UseFont = true;
            this.viewButton.AppearancePressed.Font = new System.Drawing.Font("Arial", 9F);
            this.viewButton.AppearancePressed.Options.UseFont = true;
            this.viewButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("viewButton.ImageOptions.Image")));
            this.viewButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.viewButton.Location = new System.Drawing.Point(2, 2);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(80, 58);
            this.viewButton.TabIndex = 6;
            this.viewButton.TabStop = false;
            this.viewButton.Text = "View";
            // 
            // viewPanel
            // 
            this.viewPanel.BevelInner = Ulee.Controls.EUlBevelStyle.None;
            this.viewPanel.BevelOuter = Ulee.Controls.EUlBevelStyle.None;
            this.viewPanel.InnerColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.viewPanel.InnerColor2 = System.Drawing.Color.White;
            this.viewPanel.Location = new System.Drawing.Point(8, 8);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.OuterColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.viewPanel.OuterColor2 = System.Drawing.Color.White;
            this.viewPanel.Size = new System.Drawing.Size(992, 645);
            this.viewPanel.Spacing = 0;
            this.viewPanel.TabIndex = 2;
            this.viewPanel.TextHAlign = Ulee.Controls.EUlHoriAlign.Center;
            this.viewPanel.TextVAlign = Ulee.Controls.EUlVertAlign.Middle;
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.Size = new System.Drawing.Size(105, 48);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showUpMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Calorimeter Server";
            this.notifyIcon.ContextMenuStrip = this.trayMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Calorimeter Server";
            this.notifyIcon.Visible = true;
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateTimeLabel,
            this.companyLabel,
            this.UserLabel,
            this.messageLabel,
            this.powerMeterLedLabel,
            this.recorderLedLabel,
            this.controllerLedLabel,
            this.plcLedLabel});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 727);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(1008, 24);
            this.mainStatusStrip.SizingGrip = false;
            this.mainStatusStrip.TabIndex = 2;
            // 
            // dateTimeLabel
            // 
            this.dateTimeLabel.AutoSize = false;
            this.dateTimeLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.dateTimeLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.dateTimeLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeLabel.Name = "dateTimeLabel";
            this.dateTimeLabel.Size = new System.Drawing.Size(138, 19);
            this.dateTimeLabel.Text = "2018-05-16 18:00:00";
            // 
            // companyLabel
            // 
            this.companyLabel.AutoSize = false;
            this.companyLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.companyLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.companyLabel.Name = "companyLabel";
            this.companyLabel.Size = new System.Drawing.Size(138, 19);
            this.companyLabel.Text = "HnC System Co., Ltd.";
            // 
            // UserLabel
            // 
            this.UserLabel.AutoSize = false;
            this.UserLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.UserLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(100, 19);
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = false;
            this.messageLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.messageLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(551, 19);
            // 
            // powerMeterLedLabel
            // 
            this.powerMeterLedLabel.AutoSize = false;
            this.powerMeterLedLabel.BackColor = System.Drawing.SystemColors.Control;
            this.powerMeterLedLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.powerMeterLedLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.powerMeterLedLabel.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.powerMeterLedLabel.ForeColor = System.Drawing.Color.Black;
            this.powerMeterLedLabel.Name = "powerMeterLedLabel";
            this.powerMeterLedLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.powerMeterLedLabel.Size = new System.Drawing.Size(20, 19);
            this.powerMeterLedLabel.Text = "PM";
            // 
            // recorderLedLabel
            // 
            this.recorderLedLabel.AutoSize = false;
            this.recorderLedLabel.BackColor = System.Drawing.SystemColors.Control;
            this.recorderLedLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.recorderLedLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.recorderLedLabel.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recorderLedLabel.ForeColor = System.Drawing.Color.Black;
            this.recorderLedLabel.Name = "recorderLedLabel";
            this.recorderLedLabel.Size = new System.Drawing.Size(20, 19);
            this.recorderLedLabel.Text = "REC";
            // 
            // controllerLedLabel
            // 
            this.controllerLedLabel.AutoSize = false;
            this.controllerLedLabel.BackColor = System.Drawing.SystemColors.Control;
            this.controllerLedLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.controllerLedLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.controllerLedLabel.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controllerLedLabel.ForeColor = System.Drawing.Color.Black;
            this.controllerLedLabel.Name = "controllerLedLabel";
            this.controllerLedLabel.Size = new System.Drawing.Size(20, 19);
            this.controllerLedLabel.Text = "CTL";
            // 
            // plcLedLabel
            // 
            this.plcLedLabel.AutoSize = false;
            this.plcLedLabel.BackColor = System.Drawing.SystemColors.Control;
            this.plcLedLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.plcLedLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.plcLedLabel.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plcLedLabel.ForeColor = System.Drawing.Color.Black;
            this.plcLedLabel.Name = "plcLedLabel";
            this.plcLedLabel.Size = new System.Drawing.Size(20, 19);
            this.plcLedLabel.Text = "PLC";
            // 
            // logoffTimer
            // 
            this.logoffTimer.Interval = 60000;
            this.logoffTimer.Tick += new System.EventHandler(this.logoffTimer_Tick);
            // 
            // FormServerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 751);
            this.Controls.Add(this.mainStatusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormServerMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "H&C System Calorimeter Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormServerMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormServerMain_FormClosed);
            this.Load += new System.EventHandler(this.FormServerMain_Load);
            this.Shown += new System.EventHandler(this.FormServerMain_Shown);
            this.Controls.SetChildIndex(this.mainStatusStrip, 0);
            this.Controls.SetChildIndex(this.bgPanel, 0);
            this.bgPanel.ResumeLayout(false);
            this.menuPanel.ResumeLayout(false);
            this.trayMenu.ResumeLayout(false);
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ulee.Controls.UlPanel menuPanel;
        private DevExpress.XtraEditors.SimpleButton loginButton;
        private DevExpress.XtraEditors.SimpleButton configButton;
        private DevExpress.XtraEditors.SimpleButton logButton;
        private DevExpress.XtraEditors.SimpleButton exitButton;
        private DevExpress.XtraEditors.SimpleButton viewButton;
        private Ulee.Controls.UlPanel viewPanel;
        private DevExpress.XtraEditors.SimpleButton calibButton;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel dateTimeLabel;
        private System.Windows.Forms.ToolStripStatusLabel companyLabel;
        private System.Windows.Forms.ToolStripStatusLabel powerMeterLedLabel;
        private System.Windows.Forms.ToolStripStatusLabel recorderLedLabel;
        private System.Windows.Forms.ToolStripStatusLabel controllerLedLabel;
        private System.Windows.Forms.ToolStripStatusLabel plcLedLabel;
        private System.Windows.Forms.ToolStripStatusLabel messageLabel;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel UserLabel;
        private DevExpress.XtraEditors.SimpleButton logoffButton;
        private System.Windows.Forms.Timer logoffTimer;
    }
}

