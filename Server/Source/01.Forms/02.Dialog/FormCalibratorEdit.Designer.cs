namespace Hnc.Calorimeter.Server
{
    partial class FormCalibratorEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCalibratorEdit));
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.userEdit = new Ulee.Controls.UlPanel();
            this.dateEdit = new Ulee.Controls.UlPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.memoEdit = new DevExpress.XtraEditors.TextEdit();
            this.bgPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // bgPanel
            // 
            this.bgPanel.Controls.Add(this.label3);
            this.bgPanel.Controls.Add(this.memoEdit);
            this.bgPanel.Controls.Add(this.dateEdit);
            this.bgPanel.Controls.Add(this.label2);
            this.bgPanel.Controls.Add(this.userEdit);
            this.bgPanel.Controls.Add(this.label1);
            this.bgPanel.Controls.Add(this.okButton);
            this.bgPanel.Controls.Add(this.cancelButton);
            this.bgPanel.Size = new System.Drawing.Size(364, 161);
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.Image = ((System.Drawing.Image)(resources.GetObject("okButton.Image")));
            this.okButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.okButton.Location = new System.Drawing.Point(146, 113);
            this.okButton.Name = "okButton";
            this.okButton.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.okButton.Size = new System.Drawing.Size(100, 32);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelButton.Image")));
            this.cancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelButton.Location = new System.Drawing.Point(248, 113);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.cancelButton.Size = new System.Drawing.Size(100, 32);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "User ID";
            // 
            // userEdit
            // 
            this.userEdit.BevelInner = Ulee.Controls.EUlBevelStyle.None;
            this.userEdit.BevelOuter = Ulee.Controls.EUlBevelStyle.Lowered;
            this.userEdit.InnerColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.userEdit.InnerColor2 = System.Drawing.Color.White;
            this.userEdit.Location = new System.Drawing.Point(90, 48);
            this.userEdit.Name = "userEdit";
            this.userEdit.OuterColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.userEdit.OuterColor2 = System.Drawing.Color.White;
            this.userEdit.Size = new System.Drawing.Size(128, 22);
            this.userEdit.Spacing = 0;
            this.userEdit.TabIndex = 8;
            this.userEdit.Text = " Hnc";
            this.userEdit.TextHAlign = Ulee.Controls.EUlHoriAlign.Left;
            this.userEdit.TextVAlign = Ulee.Controls.EUlVertAlign.Middle;
            // 
            // dateEdit
            // 
            this.dateEdit.BevelInner = Ulee.Controls.EUlBevelStyle.None;
            this.dateEdit.BevelOuter = Ulee.Controls.EUlBevelStyle.Lowered;
            this.dateEdit.InnerColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.dateEdit.InnerColor2 = System.Drawing.Color.White;
            this.dateEdit.Location = new System.Drawing.Point(90, 16);
            this.dateEdit.Name = "dateEdit";
            this.dateEdit.OuterColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.dateEdit.OuterColor2 = System.Drawing.Color.White;
            this.dateEdit.Size = new System.Drawing.Size(128, 22);
            this.dateEdit.Spacing = 0;
            this.dateEdit.TabIndex = 10;
            this.dateEdit.Text = " 2018-05-23 10:00:00";
            this.dateEdit.TextHAlign = Ulee.Controls.EUlHoriAlign.Left;
            this.dateEdit.TextVAlign = Ulee.Controls.EUlVertAlign.Middle;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "DateTime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Name";
            // 
            // memoEdit
            // 
            this.memoEdit.EditValue = "";
            this.memoEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.memoEdit.Location = new System.Drawing.Point(90, 80);
            this.memoEdit.Name = "memoEdit";
            this.memoEdit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memoEdit.Properties.Appearance.Options.UseFont = true;
            this.memoEdit.Properties.MaxLength = 80;
            this.memoEdit.Size = new System.Drawing.Size(258, 22);
            this.memoEdit.TabIndex = 0;
            // 
            // FormCalibratorEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(364, 161);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCalibratorEdit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save Calibration";
            this.bgPanel.ResumeLayout(false);
            this.bgPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit memoEdit;
        private Ulee.Controls.UlPanel dateEdit;
        private System.Windows.Forms.Label label2;
        private Ulee.Controls.UlPanel userEdit;
        private System.Windows.Forms.Label label1;
    }
}