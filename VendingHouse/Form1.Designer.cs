using System.Windows.Forms;

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
            this.radioProduct = new System.Windows.Forms.RadioButton();
            this.radioHotDrink = new System.Windows.Forms.RadioButton();
            this.VendingMachine = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.radioColdDrink = new System.Windows.Forms.RadioButton();
            this.backBtn = new System.Windows.Forms.Button();
            this.VendingMachine.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioProduct
            // 
            this.radioProduct.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioProduct.AutoSize = true;
            this.radioProduct.Location = new System.Drawing.Point(155, 126);
            this.radioProduct.Name = "radioProduct";
            this.radioProduct.Padding = new System.Windows.Forms.Padding(4);
            this.radioProduct.Size = new System.Drawing.Size(71, 34);
            this.radioProduct.TabIndex = 5;
            this.radioProduct.Text = "Product";
            this.radioProduct.UseVisualStyleBackColor = true;
            this.radioProduct.CheckedChanged += new System.EventHandler(this.radioProduct_CheckedChanged);
            // 
            // radioHotDrink
            // 
            this.radioHotDrink.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioHotDrink.AutoSize = true;
            this.radioHotDrink.Location = new System.Drawing.Point(155, 183);
            this.radioHotDrink.Name = "radioHotDrink";
            this.radioHotDrink.Padding = new System.Windows.Forms.Padding(4);
            this.radioHotDrink.Size = new System.Drawing.Size(80, 34);
            this.radioHotDrink.TabIndex = 6;
            this.radioHotDrink.Text = "Hot Drink";
            this.radioHotDrink.UseVisualStyleBackColor = true;
            this.radioHotDrink.CheckedChanged += new System.EventHandler(this.radioHotDrink_CheckedChanged);
            // 
            // VendingMachine
            // 
            this.VendingMachine.Controls.Add(this.tabPage1);
            this.VendingMachine.Controls.Add(this.tabPage2);
            this.VendingMachine.Controls.Add(this.tabPage3);
            this.VendingMachine.Controls.Add(this.tabPage4);
            this.VendingMachine.Location = new System.Drawing.Point(7, 7);
            this.VendingMachine.Name = "VendingMachine";
            this.VendingMachine.SelectedIndex = 0;
            this.VendingMachine.Size = new System.Drawing.Size(1371, 606);
            this.VendingMachine.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.radioColdDrink);
            this.tabPage1.Controls.Add(this.radioHotDrink);
            this.tabPage1.Controls.Add(this.radioProduct);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1363, 577);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1354, 679);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1354, 679);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1354, 679);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // radioColdDrink
            // 
            this.radioColdDrink.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioColdDrink.AutoSize = true;
            this.radioColdDrink.Location = new System.Drawing.Point(155, 246);
            this.radioColdDrink.Name = "radioColdDrink";
            this.radioColdDrink.Padding = new System.Windows.Forms.Padding(4);
            this.radioColdDrink.Size = new System.Drawing.Size(87, 34);
            this.radioColdDrink.TabIndex = 7;
            this.radioColdDrink.Text = "Cold Drink";
            this.radioColdDrink.UseVisualStyleBackColor = true;
            this.radioColdDrink.CheckedChanged += new System.EventHandler(this.radioColdDrink_CheckedChanged);
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(654, 646);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(75, 23);
            this.backBtn.TabIndex = 8;
            this.backBtn.Text = "<< back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1446, 707);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.VendingMachine);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.VendingMachine.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radioProduct;
        private System.Windows.Forms.RadioButton radioHotDrink;
        private System.Windows.Forms.TabControl VendingMachine;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private RadioButton radioColdDrink;
        private Button backBtn;
    }
}

