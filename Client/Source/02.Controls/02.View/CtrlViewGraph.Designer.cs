﻿namespace Hnc.Calorimeter.Client
{
    partial class CtrlViewGraph
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
            this.graphTab = new System.Windows.Forms.TabControl();
            this.graph1Page = new System.Windows.Forms.TabPage();
            this.graph2Page = new System.Windows.Forms.TabPage();
            this.graph3Page = new System.Windows.Forms.TabPage();
            this.graph4Page = new System.Windows.Forms.TabPage();
            this.graph5Page = new System.Windows.Forms.TabPage();
            this.graph6Page = new System.Windows.Forms.TabPage();
            this.bgPanel.SuspendLayout();
            this.graphTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgPanel
            // 
            this.bgPanel.BevelOuter = Ulee.Controls.EUlBevelStyle.None;
            this.bgPanel.Controls.Add(this.graphTab);
            this.bgPanel.Size = new System.Drawing.Size(1728, 915);
            // 
            // graphTab
            // 
            this.graphTab.Controls.Add(this.graph1Page);
            this.graphTab.Controls.Add(this.graph2Page);
            this.graphTab.Controls.Add(this.graph3Page);
            this.graphTab.Controls.Add(this.graph4Page);
            this.graphTab.Controls.Add(this.graph5Page);
            this.graphTab.Controls.Add(this.graph6Page);
            this.graphTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphTab.Location = new System.Drawing.Point(0, 0);
            this.graphTab.Margin = new System.Windows.Forms.Padding(0);
            this.graphTab.Name = "graphTab";
            this.graphTab.Padding = new System.Drawing.Point(0, 0);
            this.graphTab.SelectedIndex = 0;
            this.graphTab.Size = new System.Drawing.Size(1728, 915);
            this.graphTab.TabIndex = 1;
            this.graphTab.SelectedIndexChanged += new System.EventHandler(this.graphTab_SelectedIndexChanged);
            // 
            // graph1Page
            // 
            this.graph1Page.Location = new System.Drawing.Point(4, 24);
            this.graph1Page.Margin = new System.Windows.Forms.Padding(0);
            this.graph1Page.Name = "graph1Page";
            this.graph1Page.Size = new System.Drawing.Size(1720, 887);
            this.graph1Page.TabIndex = 0;
            this.graph1Page.Tag = "0";
            this.graph1Page.Text = " Graph 1 ";
            this.graph1Page.UseVisualStyleBackColor = true;
            // 
            // graph2Page
            // 
            this.graph2Page.Location = new System.Drawing.Point(4, 24);
            this.graph2Page.Margin = new System.Windows.Forms.Padding(0);
            this.graph2Page.Name = "graph2Page";
            this.graph2Page.Size = new System.Drawing.Size(1720, 887);
            this.graph2Page.TabIndex = 1;
            this.graph2Page.Tag = "1";
            this.graph2Page.Text = " Graph 2 ";
            this.graph2Page.UseVisualStyleBackColor = true;
            // 
            // graph3Page
            // 
            this.graph3Page.Location = new System.Drawing.Point(4, 24);
            this.graph3Page.Margin = new System.Windows.Forms.Padding(0);
            this.graph3Page.Name = "graph3Page";
            this.graph3Page.Size = new System.Drawing.Size(1720, 887);
            this.graph3Page.TabIndex = 2;
            this.graph3Page.Tag = "2";
            this.graph3Page.Text = " Grpah 3 ";
            this.graph3Page.UseVisualStyleBackColor = true;
            // 
            // graph4Page
            // 
            this.graph4Page.Location = new System.Drawing.Point(4, 24);
            this.graph4Page.Margin = new System.Windows.Forms.Padding(0);
            this.graph4Page.Name = "graph4Page";
            this.graph4Page.Size = new System.Drawing.Size(1720, 887);
            this.graph4Page.TabIndex = 3;
            this.graph4Page.Tag = "3";
            this.graph4Page.Text = " Graph 4 ";
            this.graph4Page.UseVisualStyleBackColor = true;
            // 
            // graph5Page
            // 
            this.graph5Page.Location = new System.Drawing.Point(4, 24);
            this.graph5Page.Margin = new System.Windows.Forms.Padding(0);
            this.graph5Page.Name = "graph5Page";
            this.graph5Page.Size = new System.Drawing.Size(1720, 887);
            this.graph5Page.TabIndex = 4;
            this.graph5Page.Tag = "4";
            this.graph5Page.Text = " Graph 5 ";
            this.graph5Page.UseVisualStyleBackColor = true;
            // 
            // graph6Page
            // 
            this.graph6Page.Location = new System.Drawing.Point(4, 24);
            this.graph6Page.Margin = new System.Windows.Forms.Padding(0);
            this.graph6Page.Name = "graph6Page";
            this.graph6Page.Size = new System.Drawing.Size(1720, 887);
            this.graph6Page.TabIndex = 5;
            this.graph6Page.Tag = "5";
            this.graph6Page.Text = " Graph 6 ";
            this.graph6Page.UseVisualStyleBackColor = true;
            // 
            // CtrlViewGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CtrlViewGraph";
            this.Size = new System.Drawing.Size(1728, 915);
            this.Enter += new System.EventHandler(this.CtrlViewGraph_Enter);
            this.bgPanel.ResumeLayout(false);
            this.graphTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl graphTab;
        private System.Windows.Forms.TabPage graph1Page;
        private System.Windows.Forms.TabPage graph2Page;
        private System.Windows.Forms.TabPage graph3Page;
        private System.Windows.Forms.TabPage graph4Page;
        private System.Windows.Forms.TabPage graph5Page;
        private System.Windows.Forms.TabPage graph6Page;
    }
}
