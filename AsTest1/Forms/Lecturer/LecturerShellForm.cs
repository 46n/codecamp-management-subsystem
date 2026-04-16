using System;
using System.Windows.Forms;
using APUCC_Project.Forms.Lecturer;

namespace APUCC_Project
{
    public class LecturerShellForm : BaseShellForm
    {
        private Form? activeForm = null;

        public LecturerShellForm()
        {
            this.Text = "Lecturer Dashboard";
            this.ControlBox = true;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            homebtn.Text = "Manage Students";
            iconButton2.Text = "Student Enrolment Requests";
            iconButton3.Text = "Student List";

            iconButton4.Visible = false;
            Profile.Visible = false;

            OpenChildForm(new LecturerManageStudentsForm());
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(childForm);
            MainPanel.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }

        protected override void homebtn_Click(object sender, EventArgs e)
        {
            base.homebtn_Click(sender, e);
            OpenChildForm(new LecturerManageStudentsForm());
        }

        protected override void iconButton2_Click(object sender, EventArgs e)
        {
            base.iconButton2_Click(sender, e);
            OpenChildForm(new LecturerApproveRequestsForm());
        }

        protected override void iconButton3_Click(object sender, EventArgs e)
        {
            base.iconButton3_Click(sender, e);
            OpenChildForm(new LecturerViewStudentsForm());
        }

        protected override void iconButton4_Click(object sender, EventArgs e)
        {
            base.iconButton4_Click(sender, e);
        }

        protected override void Profile_Click(object sender, EventArgs e)
        {
            base.Profile_Click(sender, e);
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
            homebtn.Text = "  Manage Students";
            // 
            // iconButton4
            // 
            iconButton4.FlatAppearance.BorderSize = 0;
            // 
            // iconButton3
            // 
            iconButton3.FlatAppearance.BorderSize = 0;
            iconButton3.Text = "Student List";
            // 
            // iconButton2
            // 
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.Text = "Student Enrolment Requests";
            // 
            // Profile
            // 
            Profile.FlatAppearance.BorderSize = 0;
            // 
            // MainPanel
            // 
            MainPanel.Size = new Size(866, 669);
            // 
            // LecturerShellForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            ClientSize = new Size(1089, 669);
            Location = new Point(0, 0);
            Name = "LecturerShellForm";
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);

        }
    }
}