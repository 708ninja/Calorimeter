﻿namespace Hnc.Calorimeter.Client
{
    partial class FormClientMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClientMain));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.testMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testLine1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testLine2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testLine3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testLine4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testView1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testView2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testView3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testView4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deviceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.powerMeterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conditionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coefficientOptionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.capacityCalculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowCalculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unitConvertorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prtOptionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.etcOptionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPanel = new Ulee.Controls.UlPanel();
            this.loginButton = new DevExpress.XtraEditors.SimpleButton();
            this.logoffButton = new DevExpress.XtraEditors.SimpleButton();
            this.exitButton = new DevExpress.XtraEditors.SimpleButton();
            this.configButton = new DevExpress.XtraEditors.SimpleButton();
            this.logButton = new DevExpress.XtraEditors.SimpleButton();
            this.deviceButton = new DevExpress.XtraEditors.SimpleButton();
            this.viewButton = new DevExpress.XtraEditors.SimpleButton();
            this.testButton = new DevExpress.XtraEditors.SimpleButton();
            this.viewPanel = new Ulee.Controls.UlPanel();
            this.mainStatus = new System.Windows.Forms.StatusStrip();
            this.dateTimeStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.companyStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.userStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.line1TitleLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.line1StateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.line1Progress = new System.Windows.Forms.ToolStripProgressBar();
            this.line2TitleLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.line2StateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.line2Progress = new System.Windows.Forms.ToolStripProgressBar();
            this.line3TitleLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.line3StateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.line3Progress = new System.Windows.Forms.ToolStripProgressBar();
            this.line4TitleLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.line4StateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.line4Progress = new System.Windows.Forms.ToolStripProgressBar();
            this.descLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.powerMeterLedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.recorderLedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.controllerLedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.plcLedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.bgPanel.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.mainStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgPanel
            // 
            this.bgPanel.AutoScroll = true;
            this.bgPanel.AutoSize = false;
            this.bgPanel.BevelOuter = Ulee.Controls.EUlBevelStyle.Single;
            this.bgPanel.Controls.Add(this.viewPanel);
            this.bgPanel.Controls.Add(this.menuPanel);
            this.bgPanel.Controls.Add(this.mainMenu);
            this.bgPanel.Dock = System.Windows.Forms.DockStyle.None;
            this.bgPanel.Size = new System.Drawing.Size(1920, 1003);
            // 
            // mainMenu
            // 
            this.mainMenu.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testMenuItem,
            this.viewMenuItem,
            this.logMenuItem,
            this.deviceMenuItem,
            this.configMenuItem,
            this.toolsMenuItem,
            this.optionMenuItem,
            this.exitMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1920, 24);
            this.mainMenu.TabIndex = 2;
            this.mainMenu.Text = "menuStrip1";
            // 
            // testMenuItem
            // 
            this.testMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testLine1ToolStripMenuItem,
            this.testLine2ToolStripMenuItem,
            this.testLine3ToolStripMenuItem,
            this.testLine4ToolStripMenuItem});
            this.testMenuItem.Name = "testMenuItem";
            this.testMenuItem.Size = new System.Drawing.Size(42, 20);
            this.testMenuItem.Text = "Test";
            // 
            // testLine1ToolStripMenuItem
            // 
            this.testLine1ToolStripMenuItem.Name = "testLine1ToolStripMenuItem";
            this.testLine1ToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.testLine1ToolStripMenuItem.Tag = "0";
            this.testLine1ToolStripMenuItem.Text = "Line 1";
            this.testLine1ToolStripMenuItem.Click += new System.EventHandler(this.testLineToolStripMenuItem_Click);
            // 
            // testLine2ToolStripMenuItem
            // 
            this.testLine2ToolStripMenuItem.Name = "testLine2ToolStripMenuItem";
            this.testLine2ToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.testLine2ToolStripMenuItem.Tag = "1";
            this.testLine2ToolStripMenuItem.Text = "Line 2";
            this.testLine2ToolStripMenuItem.Click += new System.EventHandler(this.testLineToolStripMenuItem_Click);
            // 
            // testLine3ToolStripMenuItem
            // 
            this.testLine3ToolStripMenuItem.Name = "testLine3ToolStripMenuItem";
            this.testLine3ToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.testLine3ToolStripMenuItem.Tag = "2";
            this.testLine3ToolStripMenuItem.Text = "Line 3";
            this.testLine3ToolStripMenuItem.Click += new System.EventHandler(this.testLineToolStripMenuItem_Click);
            // 
            // testLine4ToolStripMenuItem
            // 
            this.testLine4ToolStripMenuItem.Name = "testLine4ToolStripMenuItem";
            this.testLine4ToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.testLine4ToolStripMenuItem.Tag = "3";
            this.testLine4ToolStripMenuItem.Text = "Line 4";
            this.testLine4ToolStripMenuItem.Click += new System.EventHandler(this.testLineToolStripMenuItem_Click);
            // 
            // viewMenuItem
            // 
            this.viewMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testView1ToolStripMenuItem,
            this.testView2ToolStripMenuItem,
            this.testView3ToolStripMenuItem,
            this.testView4ToolStripMenuItem});
            this.viewMenuItem.Name = "viewMenuItem";
            this.viewMenuItem.Size = new System.Drawing.Size(45, 20);
            this.viewMenuItem.Text = "View";
            // 
            // testView1ToolStripMenuItem
            // 
            this.testView1ToolStripMenuItem.Name = "testView1ToolStripMenuItem";
            this.testView1ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.testView1ToolStripMenuItem.Tag = "0";
            this.testView1ToolStripMenuItem.Text = "View 1";
            this.testView1ToolStripMenuItem.Click += new System.EventHandler(this.testViewToolStripMenuItem_Click);
            // 
            // testView2ToolStripMenuItem
            // 
            this.testView2ToolStripMenuItem.Name = "testView2ToolStripMenuItem";
            this.testView2ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.testView2ToolStripMenuItem.Tag = "1";
            this.testView2ToolStripMenuItem.Text = "View 2";
            this.testView2ToolStripMenuItem.Click += new System.EventHandler(this.testViewToolStripMenuItem_Click);
            // 
            // testView3ToolStripMenuItem
            // 
            this.testView3ToolStripMenuItem.Name = "testView3ToolStripMenuItem";
            this.testView3ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.testView3ToolStripMenuItem.Tag = "2";
            this.testView3ToolStripMenuItem.Text = "View 3";
            this.testView3ToolStripMenuItem.Click += new System.EventHandler(this.testViewToolStripMenuItem_Click);
            // 
            // testView4ToolStripMenuItem
            // 
            this.testView4ToolStripMenuItem.Name = "testView4ToolStripMenuItem";
            this.testView4ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.testView4ToolStripMenuItem.Tag = "3";
            this.testView4ToolStripMenuItem.Text = "View 4";
            this.testView4ToolStripMenuItem.Click += new System.EventHandler(this.testViewToolStripMenuItem_Click);
            // 
            // logMenuItem
            // 
            this.logMenuItem.Name = "logMenuItem";
            this.logMenuItem.Size = new System.Drawing.Size(40, 20);
            this.logMenuItem.Text = "Log";
            this.logMenuItem.Click += new System.EventHandler(this.logToolStripMenuItem_Click);
            // 
            // deviceMenuItem
            // 
            this.deviceMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allToolStripMenuItem,
            this.powerMeterToolStripMenuItem,
            this.recorderToolStripMenuItem,
            this.controllerToolStripMenuItem,
            this.plcToolStripMenuItem});
            this.deviceMenuItem.Name = "deviceMenuItem";
            this.deviceMenuItem.Size = new System.Drawing.Size(56, 20);
            this.deviceMenuItem.Text = "Device";
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.allToolStripMenuItem.Tag = "0";
            this.allToolStripMenuItem.Text = "All";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.deviceToolStripMenuItem_Click);
            // 
            // powerMeterToolStripMenuItem
            // 
            this.powerMeterToolStripMenuItem.Name = "powerMeterToolStripMenuItem";
            this.powerMeterToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.powerMeterToolStripMenuItem.Tag = "1";
            this.powerMeterToolStripMenuItem.Text = "Power Meter";
            this.powerMeterToolStripMenuItem.Click += new System.EventHandler(this.deviceToolStripMenuItem_Click);
            // 
            // recorderToolStripMenuItem
            // 
            this.recorderToolStripMenuItem.Name = "recorderToolStripMenuItem";
            this.recorderToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.recorderToolStripMenuItem.Tag = "2";
            this.recorderToolStripMenuItem.Text = "Recorder";
            this.recorderToolStripMenuItem.Click += new System.EventHandler(this.deviceToolStripMenuItem_Click);
            // 
            // controllerToolStripMenuItem
            // 
            this.controllerToolStripMenuItem.Name = "controllerToolStripMenuItem";
            this.controllerToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.controllerToolStripMenuItem.Tag = "3";
            this.controllerToolStripMenuItem.Text = "Controller";
            this.controllerToolStripMenuItem.Click += new System.EventHandler(this.deviceToolStripMenuItem_Click);
            // 
            // plcToolStripMenuItem
            // 
            this.plcToolStripMenuItem.Name = "plcToolStripMenuItem";
            this.plcToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.plcToolStripMenuItem.Tag = "4";
            this.plcToolStripMenuItem.Text = "PLC";
            this.plcToolStripMenuItem.Click += new System.EventHandler(this.deviceToolStripMenuItem_Click);
            // 
            // configMenuItem
            // 
            this.configMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleMenuItem,
            this.conditionMenuItem,
            this.coefficientOptionMenuItem});
            this.configMenuItem.Name = "configMenuItem";
            this.configMenuItem.Size = new System.Drawing.Size(55, 20);
            this.configMenuItem.Text = "Config";
            // 
            // scheduleMenuItem
            // 
            this.scheduleMenuItem.Name = "scheduleMenuItem";
            this.scheduleMenuItem.Size = new System.Drawing.Size(195, 22);
            this.scheduleMenuItem.Tag = "0";
            this.scheduleMenuItem.Text = "Schedule";
            this.scheduleMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // conditionMenuItem
            // 
            this.conditionMenuItem.Name = "conditionMenuItem";
            this.conditionMenuItem.Size = new System.Drawing.Size(195, 22);
            this.conditionMenuItem.Tag = "1";
            this.conditionMenuItem.Text = "Condition";
            this.conditionMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // coefficientOptionMenuItem
            // 
            this.coefficientOptionMenuItem.Name = "coefficientOptionMenuItem";
            this.coefficientOptionMenuItem.Size = new System.Drawing.Size(195, 22);
            this.coefficientOptionMenuItem.Tag = "2";
            this.coefficientOptionMenuItem.Text = "Coefficient and Option";
            this.coefficientOptionMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // toolsMenuItem
            // 
            this.toolsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.capacityCalculatorToolStripMenuItem,
            this.windowCalculatorToolStripMenuItem,
            this.unitConvertorToolStripMenuItem});
            this.toolsMenuItem.Name = "toolsMenuItem";
            this.toolsMenuItem.Size = new System.Drawing.Size(49, 20);
            this.toolsMenuItem.Text = "Tools";
            // 
            // capacityCalculatorToolStripMenuItem
            // 
            this.capacityCalculatorToolStripMenuItem.Name = "capacityCalculatorToolStripMenuItem";
            this.capacityCalculatorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.capacityCalculatorToolStripMenuItem.Text = "Capacity Calculator";
            // 
            // windowCalculatorToolStripMenuItem
            // 
            this.windowCalculatorToolStripMenuItem.Name = "windowCalculatorToolStripMenuItem";
            this.windowCalculatorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.windowCalculatorToolStripMenuItem.Text = "Window Calculator";
            // 
            // unitConvertorToolStripMenuItem
            // 
            this.unitConvertorToolStripMenuItem.Name = "unitConvertorToolStripMenuItem";
            this.unitConvertorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.unitConvertorToolStripMenuItem.Text = "Unit Convertor";
            // 
            // optionMenuItem
            // 
            this.optionMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prtOptionMenuItem,
            this.etcOptionMenuItem});
            this.optionMenuItem.Name = "optionMenuItem";
            this.optionMenuItem.Size = new System.Drawing.Size(55, 20);
            this.optionMenuItem.Text = "Option";
            // 
            // prtOptionMenuItem
            // 
            this.prtOptionMenuItem.Name = "prtOptionMenuItem";
            this.prtOptionMenuItem.Size = new System.Drawing.Size(116, 22);
            this.prtOptionMenuItem.Text = "Printing";
            this.prtOptionMenuItem.Click += new System.EventHandler(this.prtOptionMenuItem_Click);
            // 
            // etcOptionMenuItem
            // 
            this.etcOptionMenuItem.Name = "etcOptionMenuItem";
            this.etcOptionMenuItem.Size = new System.Drawing.Size(116, 22);
            this.etcOptionMenuItem.Text = "Etc";
            this.etcOptionMenuItem.Click += new System.EventHandler(this.etcOptionMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(38, 20);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.SystemColors.Control;
            this.menuPanel.BevelInner = Ulee.Controls.EUlBevelStyle.None;
            this.menuPanel.BevelOuter = Ulee.Controls.EUlBevelStyle.None;
            this.menuPanel.Controls.Add(this.loginButton);
            this.menuPanel.Controls.Add(this.logoffButton);
            this.menuPanel.Controls.Add(this.exitButton);
            this.menuPanel.Controls.Add(this.configButton);
            this.menuPanel.Controls.Add(this.logButton);
            this.menuPanel.Controls.Add(this.deviceButton);
            this.menuPanel.Controls.Add(this.viewButton);
            this.menuPanel.Controls.Add(this.testButton);
            this.menuPanel.InnerColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.menuPanel.InnerColor2 = System.Drawing.Color.White;
            this.menuPanel.Location = new System.Drawing.Point(8, 27);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.OuterColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.menuPanel.OuterColor2 = System.Drawing.Color.White;
            this.menuPanel.Size = new System.Drawing.Size(1904, 48);
            this.menuPanel.Spacing = 0;
            this.menuPanel.TabIndex = 3;
            this.menuPanel.TextHAlign = Ulee.Controls.EUlHoriAlign.Center;
            this.menuPanel.TextVAlign = Ulee.Controls.EUlVertAlign.Middle;
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
            this.loginButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.loginButton.Location = new System.Drawing.Point(1716, 0);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(60, 48);
            this.loginButton.TabIndex = 13;
            this.loginButton.TabStop = false;
            this.loginButton.Text = "Login";
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
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
            this.logoffButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.logoffButton.Location = new System.Drawing.Point(1780, 0);
            this.logoffButton.Name = "logoffButton";
            this.logoffButton.Size = new System.Drawing.Size(60, 48);
            this.logoffButton.TabIndex = 12;
            this.logoffButton.TabStop = false;
            this.logoffButton.Text = "Logoff";
            this.logoffButton.Click += new System.EventHandler(this.logoffButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.AllowFocus = false;
            this.exitButton.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Appearance.Options.UseBorderColor = true;
            this.exitButton.Appearance.Options.UseFont = true;
            this.exitButton.Appearance.Options.UseTextOptions = true;
            this.exitButton.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.exitButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("exitButton.ImageOptions.Image")));
            this.exitButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.exitButton.ImageOptions.ImageToTextIndent = 4;
            this.exitButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.exitButton.Location = new System.Drawing.Point(1844, 0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(60, 48);
            this.exitButton.TabIndex = 11;
            this.exitButton.TabStop = false;
            this.exitButton.Text = "Exit";
            this.exitButton.Click += new System.EventHandler(this.exitMenuItem_Click);
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
            this.configButton.Location = new System.Drawing.Point(256, 0);
            this.configButton.Name = "configButton";
            this.configButton.Size = new System.Drawing.Size(60, 48);
            this.configButton.TabIndex = 10;
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
            this.logButton.Location = new System.Drawing.Point(128, 0);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(60, 48);
            this.logButton.TabIndex = 9;
            this.logButton.TabStop = false;
            this.logButton.Text = "Log";
            // 
            // deviceButton
            // 
            this.deviceButton.AllowFocus = false;
            this.deviceButton.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deviceButton.Appearance.Options.UseBorderColor = true;
            this.deviceButton.Appearance.Options.UseFont = true;
            this.deviceButton.Appearance.Options.UseTextOptions = true;
            this.deviceButton.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.deviceButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("deviceButton.ImageOptions.Image")));
            this.deviceButton.ImageOptions.ImageToTextIndent = 0;
            this.deviceButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.deviceButton.Location = new System.Drawing.Point(192, 0);
            this.deviceButton.Name = "deviceButton";
            this.deviceButton.Size = new System.Drawing.Size(60, 48);
            this.deviceButton.TabIndex = 8;
            this.deviceButton.TabStop = false;
            this.deviceButton.Text = "Device";
            // 
            // viewButton
            // 
            this.viewButton.AllowFocus = false;
            this.viewButton.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewButton.Appearance.Options.UseBorderColor = true;
            this.viewButton.Appearance.Options.UseFont = true;
            this.viewButton.Appearance.Options.UseTextOptions = true;
            this.viewButton.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.viewButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("viewButton.ImageOptions.Image")));
            this.viewButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.viewButton.ImageOptions.ImageToTextIndent = 4;
            this.viewButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.viewButton.Location = new System.Drawing.Point(64, 0);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(60, 48);
            this.viewButton.TabIndex = 7;
            this.viewButton.TabStop = false;
            this.viewButton.Text = "View";
            // 
            // testButton
            // 
            this.testButton.AllowFocus = false;
            this.testButton.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testButton.Appearance.Options.UseBorderColor = true;
            this.testButton.Appearance.Options.UseFont = true;
            this.testButton.Appearance.Options.UseTextOptions = true;
            this.testButton.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.testButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("testButton.ImageOptions.Image")));
            this.testButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.testButton.Location = new System.Drawing.Point(0, 0);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(60, 48);
            this.testButton.TabIndex = 6;
            this.testButton.TabStop = false;
            this.testButton.Text = "Test";
            // 
            // viewPanel
            // 
            this.viewPanel.BevelInner = Ulee.Controls.EUlBevelStyle.None;
            this.viewPanel.BevelOuter = Ulee.Controls.EUlBevelStyle.None;
            this.viewPanel.InnerColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.viewPanel.InnerColor2 = System.Drawing.Color.White;
            this.viewPanel.Location = new System.Drawing.Point(8, 81);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.OuterColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.viewPanel.OuterColor2 = System.Drawing.Color.White;
            this.viewPanel.Size = new System.Drawing.Size(1904, 915);
            this.viewPanel.Spacing = 0;
            this.viewPanel.TabIndex = 4;
            this.viewPanel.TextHAlign = Ulee.Controls.EUlHoriAlign.Center;
            this.viewPanel.TextVAlign = Ulee.Controls.EUlVertAlign.Middle;
            // 
            // mainStatus
            // 
            this.mainStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateTimeStatusLabel,
            this.companyStatusLabel,
            this.userStatusLabel,
            this.line1TitleLabel,
            this.line1StateLabel,
            this.line1Progress,
            this.line2TitleLabel,
            this.line2StateLabel,
            this.line2Progress,
            this.line3TitleLabel,
            this.line3StateLabel,
            this.line3Progress,
            this.line4TitleLabel,
            this.line4StateLabel,
            this.line4Progress,
            this.descLabel,
            this.powerMeterLedLabel,
            this.recorderLedLabel,
            this.controllerLedLabel,
            this.plcLedLabel});
            this.mainStatus.Location = new System.Drawing.Point(0, 1003);
            this.mainStatus.Name = "mainStatus";
            this.mainStatus.Size = new System.Drawing.Size(1920, 24);
            this.mainStatus.SizingGrip = false;
            this.mainStatus.TabIndex = 1;
            // 
            // dateTimeStatusLabel
            // 
            this.dateTimeStatusLabel.AutoSize = false;
            this.dateTimeStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.dateTimeStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.dateTimeStatusLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeStatusLabel.Name = "dateTimeStatusLabel";
            this.dateTimeStatusLabel.Size = new System.Drawing.Size(138, 19);
            this.dateTimeStatusLabel.Text = "2018-05-29 10:50:00";
            // 
            // companyStatusLabel
            // 
            this.companyStatusLabel.AutoSize = false;
            this.companyStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.companyStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.companyStatusLabel.Name = "companyStatusLabel";
            this.companyStatusLabel.Size = new System.Drawing.Size(142, 19);
            this.companyStatusLabel.Text = "HnC Systems Co., Ltd.";
            // 
            // userStatusLabel
            // 
            this.userStatusLabel.AutoSize = false;
            this.userStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.userStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.userStatusLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userStatusLabel.Name = "userStatusLabel";
            this.userStatusLabel.Size = new System.Drawing.Size(100, 19);
            this.userStatusLabel.Text = "admin";
            // 
            // line1TitleLabel
            // 
            this.line1TitleLabel.AutoSize = false;
            this.line1TitleLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.line1TitleLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.line1TitleLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.line1TitleLabel.Name = "line1TitleLabel";
            this.line1TitleLabel.Size = new System.Drawing.Size(60, 19);
            this.line1TitleLabel.Text = "Line 1";
            // 
            // line1StateLabel
            // 
            this.line1StateLabel.AutoSize = false;
            this.line1StateLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.line1StateLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.line1StateLabel.Name = "line1StateLabel";
            this.line1StateLabel.Size = new System.Drawing.Size(80, 19);
            this.line1StateLabel.Text = "None";
            // 
            // line1Progress
            // 
            this.line1Progress.Name = "line1Progress";
            this.line1Progress.Size = new System.Drawing.Size(100, 18);
            // 
            // line2TitleLabel
            // 
            this.line2TitleLabel.AutoSize = false;
            this.line2TitleLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.line2TitleLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.line2TitleLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.line2TitleLabel.Name = "line2TitleLabel";
            this.line2TitleLabel.Size = new System.Drawing.Size(60, 19);
            this.line2TitleLabel.Text = "Line 2";
            // 
            // line2StateLabel
            // 
            this.line2StateLabel.AutoSize = false;
            this.line2StateLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.line2StateLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.line2StateLabel.Name = "line2StateLabel";
            this.line2StateLabel.Size = new System.Drawing.Size(80, 19);
            this.line2StateLabel.Text = "None";
            // 
            // line2Progress
            // 
            this.line2Progress.Name = "line2Progress";
            this.line2Progress.Size = new System.Drawing.Size(100, 18);
            // 
            // line3TitleLabel
            // 
            this.line3TitleLabel.AutoSize = false;
            this.line3TitleLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.line3TitleLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.line3TitleLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.line3TitleLabel.Name = "line3TitleLabel";
            this.line3TitleLabel.Size = new System.Drawing.Size(60, 19);
            this.line3TitleLabel.Text = "Line 3";
            // 
            // line3StateLabel
            // 
            this.line3StateLabel.AutoSize = false;
            this.line3StateLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.line3StateLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.line3StateLabel.Name = "line3StateLabel";
            this.line3StateLabel.Size = new System.Drawing.Size(80, 19);
            this.line3StateLabel.Text = "None";
            // 
            // line3Progress
            // 
            this.line3Progress.Name = "line3Progress";
            this.line3Progress.Size = new System.Drawing.Size(100, 18);
            // 
            // line4TitleLabel
            // 
            this.line4TitleLabel.AutoSize = false;
            this.line4TitleLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.line4TitleLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.line4TitleLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.line4TitleLabel.Name = "line4TitleLabel";
            this.line4TitleLabel.Size = new System.Drawing.Size(60, 19);
            this.line4TitleLabel.Text = "Line 4";
            // 
            // line4StateLabel
            // 
            this.line4StateLabel.AutoSize = false;
            this.line4StateLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.line4StateLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.line4StateLabel.Name = "line4StateLabel";
            this.line4StateLabel.Size = new System.Drawing.Size(80, 19);
            this.line4StateLabel.Text = "None";
            // 
            // line4Progress
            // 
            this.line4Progress.Name = "line4Progress";
            this.line4Progress.Size = new System.Drawing.Size(100, 18);
            // 
            // descLabel
            // 
            this.descLabel.AutoSize = false;
            this.descLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.descLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(490, 19);
            this.descLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // FormClientMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1920, 1027);
            this.Controls.Add(this.mainStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormClientMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "H&C System Calorimeter Client Ver 1.00";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClientMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormClientMain_FormClosed);
            this.Load += new System.EventHandler(this.FormClientMain_Load);
            this.Shown += new System.EventHandler(this.FormClientMain_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormClientMain_KeyPress);
            this.Resize += new System.EventHandler(this.FormClientMain_Resize);
            this.Controls.SetChildIndex(this.bgPanel, 0);
            this.Controls.SetChildIndex(this.mainStatus, 0);
            this.bgPanel.ResumeLayout(false);
            this.bgPanel.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.menuPanel.ResumeLayout(false);
            this.mainStatus.ResumeLayout(false);
            this.mainStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem testMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testLine1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testLine2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testLine3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testLine4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deviceMenuItem;
        private System.Windows.Forms.ToolStripMenuItem powerMeterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recorderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controllerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem capacityCalculatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowCalculatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unitConvertorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private Ulee.Controls.UlPanel menuPanel;
        private Ulee.Controls.UlPanel viewPanel;
        private DevExpress.XtraEditors.SimpleButton exitButton;
        private DevExpress.XtraEditors.SimpleButton configButton;
        private DevExpress.XtraEditors.SimpleButton logButton;
        private DevExpress.XtraEditors.SimpleButton deviceButton;
        private DevExpress.XtraEditors.SimpleButton viewButton;
        private DevExpress.XtraEditors.SimpleButton testButton;
        private DevExpress.XtraEditors.SimpleButton loginButton;
        private DevExpress.XtraEditors.SimpleButton logoffButton;
        private System.Windows.Forms.ToolStripMenuItem logMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testView1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testView2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testView3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testView4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.StatusStrip mainStatus;
        private System.Windows.Forms.ToolStripStatusLabel dateTimeStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel userStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel line1TitleLabel;
        private System.Windows.Forms.ToolStripProgressBar line1Progress;
        private System.Windows.Forms.ToolStripStatusLabel line2TitleLabel;
        private System.Windows.Forms.ToolStripProgressBar line2Progress;
        private System.Windows.Forms.ToolStripStatusLabel line3TitleLabel;
        private System.Windows.Forms.ToolStripProgressBar line3Progress;
        private System.Windows.Forms.ToolStripStatusLabel line4TitleLabel;
        private System.Windows.Forms.ToolStripProgressBar line4Progress;
        private System.Windows.Forms.ToolStripStatusLabel descLabel;
        private System.Windows.Forms.ToolStripStatusLabel powerMeterLedLabel;
        private System.Windows.Forms.ToolStripStatusLabel recorderLedLabel;
        private System.Windows.Forms.ToolStripStatusLabel controllerLedLabel;
        private System.Windows.Forms.ToolStripStatusLabel plcLedLabel;
        private System.Windows.Forms.ToolStripMenuItem scheduleMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conditionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coefficientOptionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prtOptionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem etcOptionMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel companyStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel line1StateLabel;
        private System.Windows.Forms.ToolStripStatusLabel line2StateLabel;
        private System.Windows.Forms.ToolStripStatusLabel line3StateLabel;
        private System.Windows.Forms.ToolStripStatusLabel line4StateLabel;
    }
}

