namespace APUCC_Project
{
    partial class TrainerShellForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
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
            homebtn.Text = "Manage ";
            homebtn.Click += homebtn_Click_1;
            // 
            // iconButton4
            // 
            iconButton4.FlatAppearance.BorderSize = 0;
            // 
            // iconButton3
            // 
            iconButton3.FlatAppearance.BorderSize = 0;
            // 
            // iconButton2
            // 
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.Text = "Enrolled Students";
            iconButton2.Click += iconButton2_Click_1;
            // 
            // Profile
            // 
            Profile.FlatAppearance.BorderSize = 0;
            // 
            // MainPanel
            // 
            MainPanel.Paint += MainPanel_Paint;
            // 
            // TrainerShellForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1894, 1009);
            Location = new Point(0, 0);
            Name = "TrainerShellForm";
            Load += TrainerShellForm_Load;
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}