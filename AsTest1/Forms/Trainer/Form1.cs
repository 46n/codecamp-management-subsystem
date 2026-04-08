using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace APUCC_Project.Forms.Trainer
{
    public partial class FeedBackForm : Form
    {
        public FeedBackForm()
        {
            InitializeComponent();
                this.StartPosition = FormStartPosition.CenterScreen;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.MaximizeBox = true;
                this.MinimizeBox = true;
                this.WindowState = FormWindowState.Maximized;
        }

        private void FeedBackForm_Load(object sender, EventArgs e)
        {

        }
    }
}
