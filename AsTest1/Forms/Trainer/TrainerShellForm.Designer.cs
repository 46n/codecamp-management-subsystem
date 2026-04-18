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
            TrainerShellpnl = new Panel();
            lblTrainerStart = new Label();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            MainPanel.SuspendLayout();
            TrainerShellpnl.SuspendLayout();
            SuspendLayout();
            // 
            // homebtn
            // 
            homebtn.FlatAppearance.BorderSize = 0;
            homebtn.Text = "Manage Classes";
            homebtn.Click += homebtn_Click_1;
            // 
            // iconButton4
            // 
            iconButton4.FlatAppearance.BorderSize = 0;
            // 
            // iconButton3
            // 
            iconButton3.FlatAppearance.BorderSize = 0;
            iconButton3.IconChar = FontAwesome.Sharp.IconChar.File;
            iconButton3.Text = "Feedback";
            // 
            // iconButton2
            // 
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.Male;
            iconButton2.Text = "Enrolled Students";
            iconButton2.Click += iconButton2_Click_1;
            // 
            // Profile
            // 
            Profile.FlatAppearance.BorderSize = 0;
            // 
            // MainPanel
            // 
            MainPanel.Controls.Add(TrainerShellpnl);
            MainPanel.Size = new Size(1244, 1018);
            MainPanel.Paint += MainPanel_Paint;
            // 
            // TrainerShellpnl
            // 
            TrainerShellpnl.BackColor = Color.FromArgb(25, 25, 25);
            TrainerShellpnl.Controls.Add(lblTrainerStart);
            TrainerShellpnl.Location = new Point(0, 0);
            TrainerShellpnl.Name = "TrainerShellpnl";
            TrainerShellpnl.Size = new Size(1244, 140);
            TrainerShellpnl.TabIndex = 0;
            // 
            // lblTrainerStart
            // 
            lblTrainerStart.AutoSize = true;
            lblTrainerStart.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTrainerStart.ForeColor = Color.White;
            lblTrainerStart.Location = new Point(44, 42);
            lblTrainerStart.Name = "lblTrainerStart";
            lblTrainerStart.Size = new Size(391, 65);
            lblTrainerStart.TabIndex = 0;
            lblTrainerStart.Text = "Welcome Back!";
            // 
            // TrainerShellForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1534, 1018);
            Location = new Point(0, 0);
            Name = "TrainerShellForm";
            Load += TrainerShellForm_Load;
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            MainPanel.ResumeLayout(false);
            TrainerShellpnl.ResumeLayout(false);
            TrainerShellpnl.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel TrainerShellpnl;
        private Label lblTrainerStart;
    }
}
