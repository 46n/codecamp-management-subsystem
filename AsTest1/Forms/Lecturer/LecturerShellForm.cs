using System;
using System.Drawing;
using System.Windows.Forms;
using APUCC_Project.Forms.Lecturer;
using APUCC_Project.UI;

namespace APUCC_Project
{
    public class LecturerShellForm : BaseShellForm
    {
        protected override int ChildContentTopPadding => panelLogo.Height;

        public LecturerShellForm(int userId)
        {
            InitializeUserContext(userId, "Lecturer");
            Text = "Lecturer Dashboard";
            ControlBox = true;

            homebtn.Text = "Manage Students";
            iconButton2.Text = "Student Enrolment Requests";
            iconButton3.Text = "Student List";

            iconButton4.Visible = false;
            Profile.Visible = true;
            ApplyStandardShellWindow();

            ActivateButton(homebtn);
            OpenChildForm(new LecturerManageStudentsForm());
        }

        private void OpenChildForm(Form childForm)
        {
            OpenSharedChildForm(childForm);
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

        protected override void CustomizeChildFormAppearance(Form childForm)
        {
            SoftenLecturerTypography(childForm);
        }

        private void SoftenLecturerTypography(Control root)
        {
            foreach (Control control in root.Controls)
            {
                switch (control)
                {
                    case Label label:
                        ApplyLabelFont(label);
                        break;
                    case Button button:
                        ApplyButtonFont(button);
                        break;
                    case GroupBox groupBox:
                        ApplyGroupBoxFont(groupBox);
                        break;
                    case TextBoxBase textBox:
                        textBox.Font = ThemeTypography.Body;
                        break;
                    case ComboBox comboBox:
                        comboBox.Font = ThemeTypography.Body;
                        break;
                }

                if (control.HasChildren)
                {
                    SoftenLecturerTypography(control);
                }
            }
        }

        private static void ApplyLabelFont(Label label)
        {
            if (ShouldKeepAsHeader(label))
            {
                label.Font = ThemeTypography.Header;
                return;
            }

            if (label.Font.Bold || label.Font.Size >= 12f)
            {
                label.Font = new Font("Segoe UI", 10.5f, FontStyle.Regular);
            }
        }

        private static void ApplyButtonFont(Button button)
        {
            if (button.Font.Bold || button.Font.Size >= 11f)
            {
                button.Font = new Font("Segoe UI", 10.5f, FontStyle.Regular);
            }
        }

        private static void ApplyGroupBoxFont(GroupBox groupBox)
        {
            groupBox.Font = ShouldKeepAsSectionHeader(groupBox.Text)
                ? new Font("Segoe UI", 12f, FontStyle.Bold)
                : new Font("Segoe UI", 10.5f, FontStyle.Regular);
        }

        private static bool ShouldKeepAsHeader(Label label)
        {
            return label.Font.Size >= ThemeTypography.Header.Size
                || ShouldKeepAsSectionHeader(label.Text);
        }

        private static bool ShouldKeepAsSectionHeader(string? text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            string normalized = text.Trim().ToLowerInvariant();
            return normalized.Contains("view students")
                || normalized.Contains("selected request details")
                || normalized.Contains("register new student")
                || normalized.Contains("profile");
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
