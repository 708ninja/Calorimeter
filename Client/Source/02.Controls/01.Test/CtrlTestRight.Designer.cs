﻿namespace Hnc.Calorimeter.Client
{
    partial class CtrlTestRight
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlTestRight));
            this.conditionPanel = new Ulee.Controls.UlPanel();
            this.measPanel = new Ulee.Controls.UlPanel();
            this.viewPanel = new Ulee.Controls.UlPanel();
            this.menuPanel = new Ulee.Controls.UlPanel();
            this.openScheduleButton = new DevExpress.XtraEditors.SimpleButton();
            this.openConditionButton = new DevExpress.XtraEditors.SimpleButton();
            this.openAllParamButton = new DevExpress.XtraEditors.SimpleButton();
            this.saveAllParamButton = new DevExpress.XtraEditors.SimpleButton();
            this.resetAllParamButton = new DevExpress.XtraEditors.SimpleButton();
            this.startButton = new DevExpress.XtraEditors.SimpleButton();
            this.stopButton = new DevExpress.XtraEditors.SimpleButton();
            this.nextButton = new DevExpress.XtraEditors.SimpleButton();
            this.resetButton = new DevExpress.XtraEditors.SimpleButton();
            this.pauseButton = new DevExpress.XtraEditors.SimpleButton();
            this.measuringButton = new DevExpress.XtraEditors.SimpleButton();
            this.conditionButton = new DevExpress.XtraEditors.SimpleButton();
            this.bgPanel.SuspendLayout();
            this.measPanel.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgPanel
            // 
            this.bgPanel.Controls.Add(this.measPanel);
            this.bgPanel.Controls.Add(this.conditionPanel);
            this.bgPanel.Size = new System.Drawing.Size(1816, 915);
            // 
            // conditionPanel
            // 
            this.conditionPanel.BevelInner = Ulee.Controls.EUlBevelStyle.None;
            this.conditionPanel.BevelOuter = Ulee.Controls.EUlBevelStyle.None;
            this.conditionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conditionPanel.InnerColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.conditionPanel.InnerColor2 = System.Drawing.Color.White;
            this.conditionPanel.Location = new System.Drawing.Point(0, 0);
            this.conditionPanel.Name = "conditionPanel";
            this.conditionPanel.OuterColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.conditionPanel.OuterColor2 = System.Drawing.Color.White;
            this.conditionPanel.Size = new System.Drawing.Size(1816, 915);
            this.conditionPanel.Spacing = 0;
            this.conditionPanel.TabIndex = 0;
            this.conditionPanel.TextHAlign = Ulee.Controls.EUlHoriAlign.Center;
            this.conditionPanel.TextVAlign = Ulee.Controls.EUlVertAlign.Middle;
            // 
            // measPanel
            // 
            this.measPanel.BevelInner = Ulee.Controls.EUlBevelStyle.None;
            this.measPanel.BevelOuter = Ulee.Controls.EUlBevelStyle.None;
            this.measPanel.Controls.Add(this.viewPanel);
            this.measPanel.Controls.Add(this.menuPanel);
            this.measPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.measPanel.InnerColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.measPanel.InnerColor2 = System.Drawing.Color.White;
            this.measPanel.Location = new System.Drawing.Point(0, 0);
            this.measPanel.Name = "measPanel";
            this.measPanel.OuterColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.measPanel.OuterColor2 = System.Drawing.Color.White;
            this.measPanel.Size = new System.Drawing.Size(1816, 915);
            this.measPanel.Spacing = 0;
            this.measPanel.TabIndex = 1;
            this.measPanel.TextHAlign = Ulee.Controls.EUlHoriAlign.Center;
            this.measPanel.TextVAlign = Ulee.Controls.EUlVertAlign.Middle;
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
            this.viewPanel.TabIndex = 2;
            this.viewPanel.TextHAlign = Ulee.Controls.EUlHoriAlign.Center;
            this.viewPanel.TextVAlign = Ulee.Controls.EUlVertAlign.Middle;
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.Silver;
            this.menuPanel.BevelInner = Ulee.Controls.EUlBevelStyle.None;
            this.menuPanel.BevelOuter = Ulee.Controls.EUlBevelStyle.Lowered;
            this.menuPanel.Controls.Add(this.openScheduleButton);
            this.menuPanel.Controls.Add(this.openConditionButton);
            this.menuPanel.Controls.Add(this.openAllParamButton);
            this.menuPanel.Controls.Add(this.saveAllParamButton);
            this.menuPanel.Controls.Add(this.resetAllParamButton);
            this.menuPanel.Controls.Add(this.startButton);
            this.menuPanel.Controls.Add(this.stopButton);
            this.menuPanel.Controls.Add(this.nextButton);
            this.menuPanel.Controls.Add(this.resetButton);
            this.menuPanel.Controls.Add(this.pauseButton);
            this.menuPanel.Controls.Add(this.measuringButton);
            this.menuPanel.Controls.Add(this.conditionButton);
            this.menuPanel.InnerColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.menuPanel.InnerColor2 = System.Drawing.Color.White;
            this.menuPanel.Location = new System.Drawing.Point(1732, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.OuterColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.menuPanel.OuterColor2 = System.Drawing.Color.White;
            this.menuPanel.Size = new System.Drawing.Size(84, 915);
            this.menuPanel.Spacing = 0;
            this.menuPanel.TabIndex = 1;
            this.menuPanel.TextHAlign = Ulee.Controls.EUlHoriAlign.Center;
            this.menuPanel.TextVAlign = Ulee.Controls.EUlVertAlign.Middle;
            // 
            // openScheduleButton
            // 
            this.openScheduleButton.AllowFocus = false;
            this.openScheduleButton.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openScheduleButton.Appearance.Options.UseBorderColor = true;
            this.openScheduleButton.Appearance.Options.UseFont = true;
            this.openScheduleButton.Appearance.Options.UseTextOptions = true;
            this.openScheduleButton.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.openScheduleButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("openScheduleButton.ImageOptions.Image")));
            this.openScheduleButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.openScheduleButton.ImageOptions.ImageToTextIndent = 0;
            this.openScheduleButton.Location = new System.Drawing.Point(2, 315);
            this.openScheduleButton.Name = "openScheduleButton";
            this.openScheduleButton.Size = new System.Drawing.Size(80, 58);
            this.openScheduleButton.TabIndex = 24;
            this.openScheduleButton.TabStop = false;
            this.openScheduleButton.Text = "Open\r\nSchedule";
            this.openScheduleButton.Click += new System.EventHandler(this.openScheduleButton_Click);
            // 
            // openConditionButton
            // 
            this.openConditionButton.AllowFocus = false;
            this.openConditionButton.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openConditionButton.Appearance.Options.UseBorderColor = true;
            this.openConditionButton.Appearance.Options.UseFont = true;
            this.openConditionButton.Appearance.Options.UseTextOptions = true;
            this.openConditionButton.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.openConditionButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("openConditionButton.ImageOptions.Image")));
            this.openConditionButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.openConditionButton.ImageOptions.ImageToTextIndent = 0;
            this.openConditionButton.Location = new System.Drawing.Point(2, 375);
            this.openConditionButton.Name = "openConditionButton";
            this.openConditionButton.Size = new System.Drawing.Size(80, 58);
            this.openConditionButton.TabIndex = 23;
            this.openConditionButton.TabStop = false;
            this.openConditionButton.Text = "Open\r\nCondition";
            this.openConditionButton.Click += new System.EventHandler(this.openConditionButton_Click);
            // 
            // openAllParamButton
            // 
            this.openAllParamButton.AllowFocus = false;
            this.openAllParamButton.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openAllParamButton.Appearance.Options.UseBorderColor = true;
            this.openAllParamButton.Appearance.Options.UseFont = true;
            this.openAllParamButton.Appearance.Options.UseTextOptions = true;
            this.openAllParamButton.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.openAllParamButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("openAllParamButton.ImageOptions.Image")));
            this.openAllParamButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.openAllParamButton.ImageOptions.ImageToTextIndent = 2;
            this.openAllParamButton.Location = new System.Drawing.Point(2, 435);
            this.openAllParamButton.Name = "openAllParamButton";
            this.openAllParamButton.Size = new System.Drawing.Size(80, 58);
            this.openAllParamButton.TabIndex = 22;
            this.openAllParamButton.TabStop = false;
            this.openAllParamButton.Text = "Open\r\nAll Param";
            this.openAllParamButton.Click += new System.EventHandler(this.openAllParamButton_Click);
            // 
            // saveAllParamButton
            // 
            this.saveAllParamButton.AllowFocus = false;
            this.saveAllParamButton.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveAllParamButton.Appearance.Options.UseBorderColor = true;
            this.saveAllParamButton.Appearance.Options.UseFont = true;
            this.saveAllParamButton.Appearance.Options.UseTextOptions = true;
            this.saveAllParamButton.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.saveAllParamButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("saveAllParamButton.ImageOptions.Image")));
            this.saveAllParamButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.saveAllParamButton.ImageOptions.ImageToTextIndent = 2;
            this.saveAllParamButton.Location = new System.Drawing.Point(2, 495);
            this.saveAllParamButton.Name = "saveAllParamButton";
            this.saveAllParamButton.Size = new System.Drawing.Size(80, 58);
            this.saveAllParamButton.TabIndex = 21;
            this.saveAllParamButton.TabStop = false;
            this.saveAllParamButton.Text = "Save\r\nAll Param";
            this.saveAllParamButton.Click += new System.EventHandler(this.saveAllParamButton_Click);
            // 
            // resetAllParamButton
            // 
            this.resetAllParamButton.AllowFocus = false;
            this.resetAllParamButton.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetAllParamButton.Appearance.Options.UseBorderColor = true;
            this.resetAllParamButton.Appearance.Options.UseFont = true;
            this.resetAllParamButton.Appearance.Options.UseTextOptions = true;
            this.resetAllParamButton.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.resetAllParamButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resetAllParamButton.ImageOptions.Image")));
            this.resetAllParamButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.resetAllParamButton.ImageOptions.ImageToTextIndent = 2;
            this.resetAllParamButton.Location = new System.Drawing.Point(2, 555);
            this.resetAllParamButton.Name = "resetAllParamButton";
            this.resetAllParamButton.Size = new System.Drawing.Size(80, 58);
            this.resetAllParamButton.TabIndex = 20;
            this.resetAllParamButton.TabStop = false;
            this.resetAllParamButton.Text = "Reset\r\nAll Param";
            this.resetAllParamButton.Click += new System.EventHandler(this.resetConditionButton_Click);
            // 
            // startButton
            // 
            this.startButton.AllowFocus = false;
            this.startButton.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Appearance.Options.UseBorderColor = true;
            this.startButton.Appearance.Options.UseFont = true;
            this.startButton.Appearance.Options.UseTextOptions = true;
            this.startButton.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.startButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("startButton.ImageOptions.Image")));
            this.startButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.startButton.ImageOptions.ImageToTextIndent = 10;
            this.startButton.Location = new System.Drawing.Point(2, 615);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(80, 58);
            this.startButton.TabIndex = 19;
            this.startButton.TabStop = false;
            this.startButton.Text = "Start";
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.AllowFocus = false;
            this.stopButton.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopButton.Appearance.Options.UseBorderColor = true;
            this.stopButton.Appearance.Options.UseFont = true;
            this.stopButton.Appearance.Options.UseTextOptions = true;
            this.stopButton.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.stopButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("stopButton.ImageOptions.Image")));
            this.stopButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.stopButton.ImageOptions.ImageToTextIndent = 10;
            this.stopButton.Location = new System.Drawing.Point(2, 855);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(80, 58);
            this.stopButton.TabIndex = 18;
            this.stopButton.TabStop = false;
            this.stopButton.Text = "Stop";
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.AllowFocus = false;
            this.nextButton.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextButton.Appearance.Options.UseBorderColor = true;
            this.nextButton.Appearance.Options.UseFont = true;
            this.nextButton.Appearance.Options.UseTextOptions = true;
            this.nextButton.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.nextButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nextButton.ImageOptions.Image")));
            this.nextButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.nextButton.ImageOptions.ImageToTextIndent = 10;
            this.nextButton.Location = new System.Drawing.Point(2, 735);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(80, 58);
            this.nextButton.TabIndex = 17;
            this.nextButton.TabStop = false;
            this.nextButton.Text = "Next";
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.AllowFocus = false;
            this.resetButton.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.Appearance.Options.UseBorderColor = true;
            this.resetButton.Appearance.Options.UseFont = true;
            this.resetButton.Appearance.Options.UseTextOptions = true;
            this.resetButton.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.resetButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resetButton.ImageOptions.Image")));
            this.resetButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.resetButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.resetButton.Location = new System.Drawing.Point(2, 795);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(80, 58);
            this.resetButton.TabIndex = 16;
            this.resetButton.TabStop = false;
            this.resetButton.Text = "Phase\r\nReset";
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.AllowFocus = false;
            this.pauseButton.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseButton.Appearance.Options.UseBorderColor = true;
            this.pauseButton.Appearance.Options.UseFont = true;
            this.pauseButton.Appearance.Options.UseTextOptions = true;
            this.pauseButton.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.pauseButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("pauseButton.ImageOptions.Image")));
            this.pauseButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.pauseButton.ImageOptions.ImageToTextIndent = 10;
            this.pauseButton.Location = new System.Drawing.Point(2, 675);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(80, 58);
            this.pauseButton.TabIndex = 15;
            this.pauseButton.TabStop = false;
            this.pauseButton.Text = "Pause";
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // measuringButton
            // 
            this.measuringButton.AllowFocus = false;
            this.measuringButton.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.measuringButton.Appearance.Options.UseBorderColor = true;
            this.measuringButton.Appearance.Options.UseFont = true;
            this.measuringButton.Appearance.Options.UseTextOptions = true;
            this.measuringButton.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.measuringButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("measuringButton.ImageOptions.Image")));
            this.measuringButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.measuringButton.ImageOptions.ImageToTextIndent = 0;
            this.measuringButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.measuringButton.Location = new System.Drawing.Point(2, 62);
            this.measuringButton.Name = "measuringButton";
            this.measuringButton.Size = new System.Drawing.Size(80, 58);
            this.measuringButton.TabIndex = 13;
            this.measuringButton.TabStop = false;
            this.measuringButton.Text = "Measuring";
            // 
            // conditionButton
            // 
            this.conditionButton.AllowFocus = false;
            this.conditionButton.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conditionButton.Appearance.Options.UseBorderColor = true;
            this.conditionButton.Appearance.Options.UseFont = true;
            this.conditionButton.Appearance.Options.UseTextOptions = true;
            this.conditionButton.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.conditionButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("conditionButton.ImageOptions.Image")));
            this.conditionButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.conditionButton.ImageOptions.ImageToTextIndent = 4;
            this.conditionButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.conditionButton.Location = new System.Drawing.Point(2, 2);
            this.conditionButton.Name = "conditionButton";
            this.conditionButton.Size = new System.Drawing.Size(80, 58);
            this.conditionButton.TabIndex = 11;
            this.conditionButton.TabStop = false;
            this.conditionButton.Text = "Condition";
            // 
            // CtrlTestRight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CtrlTestRight";
            this.Size = new System.Drawing.Size(1816, 915);
            this.Load += new System.EventHandler(this.CtrlTestLine1_Load);
            this.bgPanel.ResumeLayout(false);
            this.measPanel.ResumeLayout(false);
            this.menuPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Ulee.Controls.UlPanel measPanel;
        public Ulee.Controls.UlPanel conditionPanel;
        private Ulee.Controls.UlPanel menuPanel;
        private DevExpress.XtraEditors.SimpleButton startButton;
        private DevExpress.XtraEditors.SimpleButton stopButton;
        private DevExpress.XtraEditors.SimpleButton nextButton;
        private DevExpress.XtraEditors.SimpleButton resetButton;
        private DevExpress.XtraEditors.SimpleButton pauseButton;
        private DevExpress.XtraEditors.SimpleButton measuringButton;
        private DevExpress.XtraEditors.SimpleButton conditionButton;
        private Ulee.Controls.UlPanel viewPanel;
        private DevExpress.XtraEditors.SimpleButton saveAllParamButton;
        private DevExpress.XtraEditors.SimpleButton resetAllParamButton;
        private DevExpress.XtraEditors.SimpleButton openAllParamButton;
        private DevExpress.XtraEditors.SimpleButton openScheduleButton;
        private DevExpress.XtraEditors.SimpleButton openConditionButton;
    }
}