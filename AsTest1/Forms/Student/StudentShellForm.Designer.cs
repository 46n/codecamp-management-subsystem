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
            // homebtn
            // 
            homebtn.FlatAppearance.BorderSize = 0;
            homebtn.Text = "Main";
            // 
            // iconButton2
            // 
            iconButton2.FlatAppearance.BorderSize = 0;
            // 
            // iconButton3
            // 
            iconButton3.FlatAppearance.BorderSize = 0;
            // 
            // iconButton4
            // 
            iconButton4.FlatAppearance.BorderSize = 0;
            // 
            // Profile
            // 
            Profile.FlatAppearance.BorderSize = 0;
            // 
            // StudentShellForm
            // 
            AutoScaleMode = AutoScaleMode.Font;
            StartPosition = FormStartPosition.CenterScreen;
            Name = "StudentShellForm";
            Load += StudentShellForm_Load;
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }
    }
}