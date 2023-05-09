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
            this.btn_Product = new System.Windows.Forms.RadioButton();
            this.btn_HotColdDrink = new System.Windows.Forms.RadioButton();
            this.VendingMachine = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.VendingMachine.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Product
            // 
            this.btn_Product.Appearance = System.Windows.Forms.Appearance.Button;
            this.btn_Product.AutoSize = true;
            this.btn_Product.Location = new System.Drawing.Point(204, 117);
            this.btn_Product.Name = "btn_Product";
            this.btn_Product.Padding = new System.Windows.Forms.Padding(4);
            this.btn_Product.Size = new System.Drawing.Size(71, 34);
            this.btn_Product.TabIndex = 5;
            this.btn_Product.TabStop = true;
            this.btn_Product.Text = "Product";
            this.btn_Product.UseVisualStyleBackColor = true;
            this.btn_Product.CheckedChanged += new System.EventHandler(this.btn_Product_CheckedChanged);
            // 
            // btn_HotColdDrink
            // 
            this.btn_HotColdDrink.Appearance = System.Windows.Forms.Appearance.Button;
            this.btn_HotColdDrink.AutoSize = true;
            this.btn_HotColdDrink.Location = new System.Drawing.Point(182, 179);
            this.btn_HotColdDrink.Name = "btn_HotColdDrink";
            this.btn_HotColdDrink.Padding = new System.Windows.Forms.Padding(4);
            this.btn_HotColdDrink.Size = new System.Drawing.Size(118, 34);
            this.btn_HotColdDrink.TabIndex = 6;
            this.btn_HotColdDrink.TabStop = true;
            this.btn_HotColdDrink.Text = "Hot \\ Cold Drink";
            this.btn_HotColdDrink.UseVisualStyleBackColor = true;
            // 
            // VendingMachine
            // 
            this.VendingMachine.Controls.Add(this.tabPage1);
            this.VendingMachine.Controls.Add(this.tabPage2);
            this.VendingMachine.Controls.Add(this.tabPage3);
            this.VendingMachine.Controls.Add(this.tabPage4);
            this.VendingMachine.Location = new System.Drawing.Point(320, 25);
            this.VendingMachine.Name = "VendingMachine";
            this.VendingMachine.SelectedIndex = 0;
            this.VendingMachine.Size = new System.Drawing.Size(507, 529);
            this.VendingMachine.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_Product);
            this.tabPage1.Controls.Add(this.btn_HotColdDrink);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(499, 500);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(499, 500);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(499, 500);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(499, 500);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1446, 707);
            this.Controls.Add(this.VendingMachine);
            this.Enabled = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "Form1";
            this.VendingMachine.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton btn_Product;
        private System.Windows.Forms.RadioButton btn_HotColdDrink;
        private System.Windows.Forms.TabControl VendingMachine;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
    }
}

