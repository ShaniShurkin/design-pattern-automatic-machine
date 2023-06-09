﻿using System.Windows.Forms;

namespace VendingHouse
{
    partial class Form1
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
            this.VendingMachine = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.backBtn = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.VendingMachine.SuspendLayout();
            this.SuspendLayout();
            // 
            // VendingMachine
            // 
            this.VendingMachine.Controls.Add(this.tabPage1);
            this.VendingMachine.Controls.Add(this.tabPage2);
            this.VendingMachine.Controls.Add(this.tabPage3);
            this.VendingMachine.Controls.Add(this.tabPage4);
            this.VendingMachine.Controls.Add(this.tabPage5);
            this.VendingMachine.Controls.Add(this.settingsTab);
            this.VendingMachine.Controls.Add(this.tabPage6);
            this.VendingMachine.Location = new System.Drawing.Point(7, 7);
            this.VendingMachine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.VendingMachine.Name = "VendingMachine";
            this.VendingMachine.SelectedIndex = 0;
            this.VendingMachine.Size = new System.Drawing.Size(1441, 633);
            this.VendingMachine.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1433, 604);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1433, 604);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Size = new System.Drawing.Size(1433, 604);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Size = new System.Drawing.Size(1433, 604);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage5.Size = new System.Drawing.Size(1433, 604);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // settingsTab
            // 
            this.settingsTab.Location = new System.Drawing.Point(4, 25);
            this.settingsTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.settingsTab.Size = new System.Drawing.Size(1433, 604);
            this.settingsTab.TabIndex = 6;
            this.settingsTab.Text = "6";
            this.settingsTab.UseVisualStyleBackColor = true;
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(668, 670);
            this.backBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(133, 43);
            this.backBtn.TabIndex = 8;
            this.backBtn.Text = "<<  back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1433, 604);
            this.tabPage6.TabIndex = 7;
            this.tabPage6.Text = "settings";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1445, 748);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.VendingMachine);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.VendingMachine.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl VendingMachine;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private Button backBtn;
        private TabPage tabPage5;
        private TabPage settingsTab;
        private TabPage tabPage6;
    }
}

