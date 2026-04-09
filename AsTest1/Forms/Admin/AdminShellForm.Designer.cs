namespace APUCC_Project
{
    partial class AdminShellForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // leftBorderBtn
            // 
            leftBorderBtn.Margin = new Padding(2);
            leftBorderBtn.Size = new Size(5, 39);
            // 
            // panelMenu
            // 
            panelMenu.Paint += panelMenu_Paint;
            // 
            // homebtn
            // 
            homebtn.FlatAppearance.BorderSize = 0;
            homebtn.Text = "Manage Trainer";
            homebtn.Click += homebtn_Click_1;
            // 
            // iconButton4
            // 
            iconButton4.FlatAppearance.BorderSize = 0;
            iconButton4.Click += iconButton4_Click_1;
            // 
            // iconButton3
            // 
            iconButton3.FlatAppearance.BorderSize = 0;
            iconButton3.Text = "Monthly Income Report";
            iconButton3.Click += iconButton3_Click_1;
            // 
            // iconButton2
            // 
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.Text = "Trainer Feedback";
            iconButton2.Click += iconButton2_Click_1;
            // 
            // pictureBox1
            // 
            pictureBox1.Click += pictureBox1_Click_1;
            // 
            // Profile
            // 
            Profile.FlatAppearance.BorderSize = 0;
            // 
            // MainPanel
            // 
            MainPanel.Paint += MainPanel_Paint;
            // 
            // AdminShellForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1078, 644);
            Location = new Point(0, 0);
            Name = "AdminShellForm";
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }
    }
}