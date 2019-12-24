namespace Hnc.Calorimeter.Client
{
    partial class FormSaveDataRaw
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSaveDataRaw));
            this.cancelButton = new System.Windows.Forms.Button();
            this.savingProgress = new DevExpress.XtraEditors.ProgressBarControl();
            this.bgPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.savingProgress.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // bgPanel
            // 
            this.bgPanel.Controls.Add(this.savingProgress);
            this.bgPanel.Controls.Add(this.cancelButton);
            this.bgPanel.Size = new System.Drawing.Size(284, 80);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelButton.Image")));
            this.cancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelButton.Location = new System.Drawing.Point(172, 38);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.cancelButton.Size = new System.Drawing.Size(100, 32);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // savingProgress
            // 
            this.savingProgress.Location = new System.Drawing.Point(12, 12);
            this.savingProgress.Name = "savingProgress";
            this.savingProgress.Properties.AllowFocused = false;
            this.savingProgress.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savingProgress.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.savingProgress.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.savingProgress.Properties.FlowAnimationDuration = 2000;
            this.savingProgress.Properties.FlowAnimationEnabled = true;
            this.savingProgress.Properties.ShowTitle = true;
            this.savingProgress.Properties.TextOrientation = DevExpress.Utils.Drawing.TextOrientation.Horizontal;
            this.savingProgress.Size = new System.Drawing.Size(260, 18);
            this.savingProgress.TabIndex = 146;
            // 
            // FormSaveDataRaw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(284, 80);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSaveDataRaw";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save raw data";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.FormSaveDataRaw_Shown);
            this.bgPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.savingProgress.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private DevExpress.XtraEditors.ProgressBarControl savingProgress;
    }
}
