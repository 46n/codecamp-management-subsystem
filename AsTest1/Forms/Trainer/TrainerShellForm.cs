using APUCC_Project.Forms.Trainer;
using APUCC_Project.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace APUCC_Project
{
    public partial class TrainerShellForm : BaseShellForm
    {
        public TrainerShellForm(int userId)
        {
            InitializeComponent();
            InitializeUserContext(userId, "Trainer");
            Text = "Trainer Dashboard";
            ControlBox = true;

            homebtn.Text = "Manage Classes";
            iconButton2.Text = "EnrolLed Student";
            iconButton3.Text = "Feedback";
            iconButton4.Text = "Settings";
            Profile.Text = "Profile";
            ApplyStandardShellWindow();
            ActivateButton(homebtn);
            OpenChildForm(new TrainerHomeForm());
        }

        private void OpenChildForm(Form childForm)
        {
            OpenSharedChildForm(childForm);
        }

        protected override void homebtn_Click(object sender, EventArgs e)
        {
            base.homebtn_Click(sender, e);
            OpenChildForm(new TrainerHomeForm());
        }

        protected override void iconButton2_Click(object sender, EventArgs e)
        {
            base.iconButton2_Click(sender, e);
            OpenChildForm(new TrainerEnrolledStudents());
        }

        protected override void iconButton3_Click(object sender, EventArgs e)
        {
            base.iconButton3_Click(sender, e);
            OpenChildForm(new FeedBackForm1());
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
            SoftenTrainerTypography(childForm);
        }

        private void SoftenTrainerTypography(Control root)
        {
            foreach (Control control in root.Controls)
            {
                switch (control)
                {
                    case Label label:
                        ApplyTrainerLabelFont(label);
                        break;
                    case Button button:
                        button.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
                        break;
                    case GroupBox groupBox:
                        groupBox.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
                        break;
                    case TextBoxBase textBox:
                        textBox.Font = ThemeTypography.Body;
                        break;
                    case ComboBox comboBox:
                        comboBox.Font = ThemeTypography.Body;
                        break;
                    case DateTimePicker dateTimePicker:
                        dateTimePicker.Font = ThemeTypography.Body;
                        break;
                }

                if (control.HasChildren)
                {
                    SoftenTrainerTypography(control);
                }
            }
        }

        private static void ApplyTrainerLabelFont(Label label)
        {
            if (IsStatusLabel(label.Name))
            {
                return;
            }

            if (IsTopHeaderLabel(label))
            {
                label.Font = ThemeTypography.Header;
                return;
            }

            label.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
        }

        private static bool IsTopHeaderLabel(Label label)
        {
            return label.Top <= 220
                || label.Font.Size >= ThemeTypography.Header.Size
                || IsHeaderLike(label.Text)
                || IsHeaderLike(label.Name);
        }

        private static bool IsHeaderLike(string? value)
        {
            string normalized = value?.Trim().ToLowerInvariant() ?? string.Empty;
            return normalized.Contains("title")
                || normalized.Contains("header")
                || normalized.Contains("schedule")
                || normalized.Contains("feedback")
                || normalized.Contains("profile");
        }

        private static bool IsStatusLabel(string? value)
        {
            string normalized = value?.Trim().ToLowerInvariant() ?? string.Empty;
            return normalized.Contains("wrong")
                || normalized.Contains("error")
                || normalized.Contains("confirm")
                || normalized.Contains("success");
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void homebtn_Click_1(object sender, EventArgs e)
        {
        }

        private void TrainerShellForm_Load(object sender, EventArgs e)
        {
        }

        private void iconButton2_Click_1(object sender, EventArgs e)
        {
        }
    }
}
