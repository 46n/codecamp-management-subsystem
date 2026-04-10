namespace APUCC_Project
{
    partial class StudentShellForm
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
            leftBorderBtn.Margin = new Padding(2, 1, 2, 1);
            leftBorderBtn.Size = new Size(4, 23);
            // 
            // panelMenu
            // 
            panelMenu.Location = new Point(10, 8);
            panelMenu.Margin = new Padding(5, 3, 5, 3);
            panelMenu.Size = new Size(79, 142);
            // 
            // homebtn
            // 
            homebtn.FlatAppearance.BorderSize = 0;
            homebtn.Location = new Point(0, 28);
            homebtn.Margin = new Padding(1, 0, 1, 0);
            homebtn.Padding = new Padding(5, 0, 0, 0);
            homebtn.Size = new Size(79, 15);
            homebtn.Text = "Main";
            // 
            // panelLogo
            // 
            panelLogo.Margin = new Padding(1, 0, 1, 0);
            panelLogo.Size = new Size(79, 28);
            // 
            // iconButton4
            // 
            iconButton4.FlatAppearance.BorderSize = 0;
            iconButton4.Location = new Point(0, 88);
            iconButton4.Margin = new Padding(1, 0, 1, 0);
            iconButton4.Padding = new Padding(5, 0, 0, 0);
            iconButton4.Size = new Size(79, 15);
            // 
            // iconButton3
            // 
            iconButton3.FlatAppearance.BorderSize = 0;
            iconButton3.Location = new Point(0, 58);
            iconButton3.Margin = new Padding(1, 0, 1, 0);
            iconButton3.Padding = new Padding(5, 0, 0, 0);
            iconButton3.Size = new Size(79, 15);
            // 
            // iconButton2
            // 
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.Location = new Point(0, 43);
            iconButton2.Margin = new Padding(1, 0, 1, 0);
            iconButton2.Padding = new Padding(5, 0, 0, 0);
            iconButton2.Size = new Size(79, 15);
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(-4, -3);
            pictureBox1.Margin = new Padding(1, 0, 1, 0);
            pictureBox1.Size = new Size(77, 34);
            // 
            // Profile
            // 
            Profile.FlatAppearance.BorderSize = 0;
            Profile.Location = new Point(0, 73);
            Profile.Margin = new Padding(1, 0, 1, 0);
            Profile.Padding = new Padding(5, 0, 0, 0);
            Profile.Size = new Size(79, 15);
            // 
            // MainPanel
            // 
            MainPanel.Margin = new Padding(1, 0, 1, 0);
            MainPanel.Size = new Size(210, 198);
            // 
            // StudentShellForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 198);
            Location = new Point(0, 0);
            Margin = new Padding(1, 0, 1, 0);
            MaximumSize = new Size(416, 200);
            MinimumSize = new Size(416, 200);
            Name = "StudentShellForm";
            Load += StudentShellForm_Load;
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }
    }
}