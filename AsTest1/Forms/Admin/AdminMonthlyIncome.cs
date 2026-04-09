using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace APUCC_Project.Forms.Admin
{
    public partial class AdminMonthlyIncome : Form
    {
        public AdminMonthlyIncome()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void AdminMonthlyIncome_Load(object sender, EventArgs e)
        {

        }
    }
}
