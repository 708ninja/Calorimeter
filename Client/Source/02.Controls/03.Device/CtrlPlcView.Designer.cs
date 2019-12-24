namespace Hnc.Calorimeter.Client
{
    partial class CtrlPlcView
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
            this.ulPanel6 = new Ulee.Controls.UlPanel();
            this.bgPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgPanel
            // 
            this.bgPanel.BevelInner = Ulee.Controls.EUlBevelStyle.Raised;
            this.bgPanel.Controls.Add(this.ulPanel6);
            this.bgPanel.Size = new System.Drawing.Size(450, 915);
            // 
            // ulPanel6
            // 
            this.ulPanel6.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ulPanel6.BevelInner = Ulee.Controls.EUlBevelStyle.None;
            this.ulPanel6.BevelOuter = Ulee.Controls.EUlBevelStyle.Lowered;
            this.ulPanel6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ulPanel6.ForeColor = System.Drawing.Color.White;
            this.ulPanel6.InnerColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.ulPanel6.InnerColor2 = System.Drawing.Color.White;
            this.ulPanel6.Location = new System.Drawing.Point(6, 6);
            this.ulPanel6.Name = "ulPanel6";
            this.ulPanel6.OuterColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.ulPanel6.OuterColor2 = System.Drawing.Color.White;
            this.ulPanel6.Size = new System.Drawing.Size(438, 28);
            this.ulPanel6.Spacing = 0;
            this.ulPanel6.TabIndex = 7;
            this.ulPanel6.Text = "PLC";
            this.ulPanel6.TextHAlign = Ulee.Controls.EUlHoriAlign.Center;
            this.ulPanel6.TextVAlign = Ulee.Controls.EUlVertAlign.Middle;
            // 
            // CtrlPlcView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CtrlPlcView";
            this.Size = new System.Drawing.Size(450, 915);
            this.bgPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ulee.Controls.UlPanel ulPanel6;
    }
}
