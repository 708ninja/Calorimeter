namespace Hnc.Calorimeter.Client
{
    partial class FormEtcOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEtcOption));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selectFolderButton = new System.Windows.Forms.Button();
            this.excelPathEdit = new DevExpress.XtraEditors.TextEdit();
            this.forcedIntegCheck = new System.Windows.Forms.CheckBox();
            this.fixedAtmPressureCheck = new System.Windows.Forms.CheckBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.bgPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.excelPathEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // bgPanel
            // 
            this.bgPanel.Controls.Add(this.okButton);
            this.bgPanel.Controls.Add(this.cancelButton);
            this.bgPanel.Controls.Add(this.groupBox1);
            this.bgPanel.Controls.Add(this.forcedIntegCheck);
            this.bgPanel.Controls.Add(this.fixedAtmPressureCheck);
            this.bgPanel.Size = new System.Drawing.Size(344, 161);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.selectFolderButton);
            this.groupBox1.Controls.Add(this.excelPathEdit);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 52);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Excel Path ";
            // 
            // selectFolderButton
            // 
            this.selectFolderButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectFolderButton.Location = new System.Drawing.Point(246, 19);
            this.selectFolderButton.Name = "selectFolderButton";
            this.selectFolderButton.Size = new System.Drawing.Size(68, 23);
            this.selectFolderButton.TabIndex = 1;
            this.selectFolderButton.Text = "Select ...";
            this.selectFolderButton.UseVisualStyleBackColor = true;
            this.selectFolderButton.Click += new System.EventHandler(this.selectFolderButton_Click);
            // 
            // excelPathEdit
            // 
            this.excelPathEdit.EditValue = "";
            this.excelPathEdit.EnterMoveNextControl = true;
            this.excelPathEdit.Location = new System.Drawing.Point(6, 20);
            this.excelPathEdit.Name = "excelPathEdit";
            this.excelPathEdit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excelPathEdit.Properties.Appearance.Options.UseFont = true;
            this.excelPathEdit.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excelPathEdit.Properties.AppearanceDisabled.Options.UseFont = true;
            this.excelPathEdit.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excelPathEdit.Properties.AppearanceFocused.Options.UseFont = true;
            this.excelPathEdit.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excelPathEdit.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.excelPathEdit.Properties.ReadOnly = true;
            this.excelPathEdit.Size = new System.Drawing.Size(234, 22);
            this.excelPathEdit.TabIndex = 0;
            // 
            // forcedIntegCheck
            // 
            this.forcedIntegCheck.AutoSize = true;
            this.forcedIntegCheck.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forcedIntegCheck.Location = new System.Drawing.Point(12, 37);
            this.forcedIntegCheck.Name = "forcedIntegCheck";
            this.forcedIntegCheck.Size = new System.Drawing.Size(125, 19);
            this.forcedIntegCheck.TabIndex = 4;
            this.forcedIntegCheck.Text = "Forced integration";
            this.forcedIntegCheck.UseVisualStyleBackColor = true;
            // 
            // fixedAtmPressureCheck
            // 
            this.fixedAtmPressureCheck.AutoSize = true;
            this.fixedAtmPressureCheck.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fixedAtmPressureCheck.Location = new System.Drawing.Point(12, 12);
            this.fixedAtmPressureCheck.Name = "fixedAtmPressureCheck";
            this.fixedAtmPressureCheck.Size = new System.Drawing.Size(250, 19);
            this.fixedAtmPressureCheck.TabIndex = 3;
            this.fixedAtmPressureCheck.Text = "Fixed atmospheric pressure(760 mmHg)";
            this.fixedAtmPressureCheck.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.Image = ((System.Drawing.Image)(resources.GetObject("okButton.Image")));
            this.okButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.okButton.Location = new System.Drawing.Point(130, 120);
            this.okButton.Name = "okButton";
            this.okButton.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.okButton.Size = new System.Drawing.Size(100, 32);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelButton.Image")));
            this.cancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelButton.Location = new System.Drawing.Point(232, 120);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.cancelButton.Size = new System.Drawing.Size(100, 32);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // FormEtcOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(344, 161);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEtcOption";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Etc Option";
            this.Load += new System.EventHandler(this.FormEtcOption_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormEtcOption_KeyPress);
            this.bgPanel.ResumeLayout(false);
            this.bgPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.excelPathEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button selectFolderButton;
        public DevExpress.XtraEditors.TextEdit excelPathEdit;
        private System.Windows.Forms.CheckBox forcedIntegCheck;
        private System.Windows.Forms.CheckBox fixedAtmPressureCheck;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}
