namespace Hnc.Calorimeter.Client
{
    partial class FormPrintingOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrintingOption));
            this.autoExcelCheck = new System.Windows.Forms.CheckBox();
            this.stoppedTestExcelCheck = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.outdoorTCCheck = new System.Windows.Forms.CheckBox();
            this.indoorTC2Check = new System.Windows.Forms.CheckBox();
            this.indoorTC1Check = new System.Windows.Forms.CheckBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.indoor12Check = new System.Windows.Forms.CheckBox();
            this.indoor11Check = new System.Windows.Forms.CheckBox();
            this.indoor22Check = new System.Windows.Forms.CheckBox();
            this.indoor21Check = new System.Windows.Forms.CheckBox();
            this.bgPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgPanel
            // 
            this.bgPanel.Controls.Add(this.groupBox2);
            this.bgPanel.Controls.Add(this.okButton);
            this.bgPanel.Controls.Add(this.cancelButton);
            this.bgPanel.Controls.Add(this.groupBox1);
            this.bgPanel.Controls.Add(this.stoppedTestExcelCheck);
            this.bgPanel.Controls.Add(this.autoExcelCheck);
            this.bgPanel.Size = new System.Drawing.Size(422, 231);
            this.bgPanel.TabIndex = 1;
            // 
            // autoExcelCheck
            // 
            this.autoExcelCheck.AutoSize = true;
            this.autoExcelCheck.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoExcelCheck.Location = new System.Drawing.Point(12, 12);
            this.autoExcelCheck.Name = "autoExcelCheck";
            this.autoExcelCheck.Size = new System.Drawing.Size(362, 19);
            this.autoExcelCheck.TabIndex = 0;
            this.autoExcelCheck.Text = "Automatically create an excel file and print it after test finished.";
            this.autoExcelCheck.UseVisualStyleBackColor = true;
            // 
            // stoppedTestExcelCheck
            // 
            this.stoppedTestExcelCheck.AutoSize = true;
            this.stoppedTestExcelCheck.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stoppedTestExcelCheck.Location = new System.Drawing.Point(12, 37);
            this.stoppedTestExcelCheck.Name = "stoppedTestExcelCheck";
            this.stoppedTestExcelCheck.Size = new System.Drawing.Size(406, 19);
            this.stoppedTestExcelCheck.TabIndex = 1;
            this.stoppedTestExcelCheck.Text = "Automatically create an excel file and print it as manually test stopped.";
            this.stoppedTestExcelCheck.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.outdoorTCCheck);
            this.groupBox1.Controls.Add(this.indoorTC2Check);
            this.groupBox1.Controls.Add(this.indoorTC1Check);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 54);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Choose printing thermocouple sheets ";
            // 
            // outdoorTCCheck
            // 
            this.outdoorTCCheck.AutoSize = true;
            this.outdoorTCCheck.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outdoorTCCheck.Location = new System.Drawing.Point(320, 24);
            this.outdoorTCCheck.Name = "outdoorTCCheck";
            this.outdoorTCCheck.Size = new System.Drawing.Size(70, 19);
            this.outdoorTCCheck.TabIndex = 4;
            this.outdoorTCCheck.Text = "Outdoor";
            this.outdoorTCCheck.UseVisualStyleBackColor = true;
            // 
            // indoorTC2Check
            // 
            this.indoorTC2Check.AutoSize = true;
            this.indoorTC2Check.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.indoorTC2Check.Location = new System.Drawing.Point(159, 24);
            this.indoorTC2Check.Name = "indoorTC2Check";
            this.indoorTC2Check.Size = new System.Drawing.Size(71, 19);
            this.indoorTC2Check.TabIndex = 3;
            this.indoorTC2Check.Text = "Indoor 2";
            this.indoorTC2Check.UseVisualStyleBackColor = true;
            // 
            // indoorTC1Check
            // 
            this.indoorTC1Check.AutoSize = true;
            this.indoorTC1Check.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.indoorTC1Check.Location = new System.Drawing.Point(12, 24);
            this.indoorTC1Check.Name = "indoorTC1Check";
            this.indoorTC1Check.Size = new System.Drawing.Size(71, 19);
            this.indoorTC1Check.TabIndex = 2;
            this.indoorTC1Check.Text = "Indoor 1";
            this.indoorTC1Check.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.Image = ((System.Drawing.Image)(resources.GetObject("okButton.Image")));
            this.okButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.okButton.Location = new System.Drawing.Point(208, 188);
            this.okButton.Name = "okButton";
            this.okButton.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.okButton.Size = new System.Drawing.Size(100, 32);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelButton.Image")));
            this.cancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelButton.Location = new System.Drawing.Point(310, 188);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.cancelButton.Size = new System.Drawing.Size(100, 32);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.indoor22Check);
            this.groupBox2.Controls.Add(this.indoor21Check);
            this.groupBox2.Controls.Add(this.indoor12Check);
            this.groupBox2.Controls.Add(this.indoor11Check);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(398, 54);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Choose printing chamber sheets ";
            // 
            // indoor12Check
            // 
            this.indoor12Check.AutoSize = true;
            this.indoor12Check.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.indoor12Check.Location = new System.Drawing.Point(109, 24);
            this.indoor12Check.Name = "indoor12Check";
            this.indoor12Check.Size = new System.Drawing.Size(88, 19);
            this.indoor12Check.TabIndex = 3;
            this.indoor12Check.Text = "Indoor 1 #2";
            this.indoor12Check.UseVisualStyleBackColor = true;
            // 
            // indoor11Check
            // 
            this.indoor11Check.AutoSize = true;
            this.indoor11Check.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.indoor11Check.Location = new System.Drawing.Point(12, 24);
            this.indoor11Check.Name = "indoor11Check";
            this.indoor11Check.Size = new System.Drawing.Size(91, 19);
            this.indoor11Check.TabIndex = 2;
            this.indoor11Check.Text = "Indoor 1 #1 ";
            this.indoor11Check.UseVisualStyleBackColor = true;
            // 
            // indoor22Check
            // 
            this.indoor22Check.AutoSize = true;
            this.indoor22Check.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.indoor22Check.Location = new System.Drawing.Point(304, 24);
            this.indoor22Check.Name = "indoor22Check";
            this.indoor22Check.Size = new System.Drawing.Size(88, 19);
            this.indoor22Check.TabIndex = 5;
            this.indoor22Check.Text = "Indoor 2 #2";
            this.indoor22Check.UseVisualStyleBackColor = true;
            // 
            // indoor21Check
            // 
            this.indoor21Check.AutoSize = true;
            this.indoor21Check.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.indoor21Check.Location = new System.Drawing.Point(207, 24);
            this.indoor21Check.Name = "indoor21Check";
            this.indoor21Check.Size = new System.Drawing.Size(91, 19);
            this.indoor21Check.TabIndex = 4;
            this.indoor21Check.Text = "Indoor 2 #1 ";
            this.indoor21Check.UseVisualStyleBackColor = true;
            // 
            // FormPrintingOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(422, 231);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPrintingOption";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Printing Option";
            this.Load += new System.EventHandler(this.FormPrintingOption_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormPrintingOption_KeyPress);
            this.bgPanel.ResumeLayout(false);
            this.bgPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox outdoorTCCheck;
        private System.Windows.Forms.CheckBox indoorTC2Check;
        private System.Windows.Forms.CheckBox indoorTC1Check;
        private System.Windows.Forms.CheckBox stoppedTestExcelCheck;
        private System.Windows.Forms.CheckBox autoExcelCheck;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox indoor22Check;
        private System.Windows.Forms.CheckBox indoor21Check;
        private System.Windows.Forms.CheckBox indoor12Check;
        private System.Windows.Forms.CheckBox indoor11Check;
    }
}