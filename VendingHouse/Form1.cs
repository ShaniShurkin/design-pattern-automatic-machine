using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendingHouse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Product_CheckedChanged(object sender, EventArgs e)
        {
            VendingMachine.SelectedTab += 1;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
