using APUCC_Project.Forms.Trainer;
using APUCC_Project.UI;
using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace APUCC_Project
{
    public partial class TrainerShellForm : BaseShellForm
    {
        private readonly string connStr =
            ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
        private readonly int currentTrainerId;
        protected override int ChildContentTopPadding => panelLogo.Height;

        public TrainerShellForm(int userId)
        {
            InitializeComponent();
            InitializeUserContext(userId, "Trainer");
            currentTrainerId = ResolveTrainerId(userId);
            Text = "Trainer Dashboard";
            ControlBox = true;

            homebtn.Text = "Manage Classes";
            iconButton2.Text = "EnrolLed Student";
            iconButton3.Text = "Feedback";
            iconButton4.Text = "Settings";
            Profile.Text = "Profile";
            ApplyStandardShellWindow();
            ActivateButton(homebtn);
            OpenChildForm(new TrainerHomeForm(currentTrainerId));
        }

        private int ResolveTrainerId(int userId)
        {
            try
            {
                using SqlConnection con = new SqlConnection(connStr);
                using SqlCommand cmd = new SqlCommand(
                    "SELECT TrainerID FROM Trainers WHERE UserID = @UserID",
                    con);
                cmd.Parameters.AddWithValue("@UserID", userId);
                con.Open();

                object? result = cmd.ExecuteScalar();
                return result != null && result != DBNull.Value
                    ? Convert.ToInt32(result)
                    : 0;
            }
            catch
            {
                return 0;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            OpenSharedChildForm(childForm);
        }

        protected override void homebtn_Click(object sender, EventArgs e)
        {
            base.homebtn_Click(sender, e);
            OpenChildForm(new TrainerHomeForm(currentTrainerId));
        }

        protected override void iconButton2_Click(object sender, EventArgs e)
        {
            base.iconButton2_Click(sender, e);
            OpenChildForm(new TrainerEnrolledStudents(currentTrainerId));
        }

        protected override void iconButton3_Click(object sender, EventArgs e)
        {
            base.iconButton3_Click(sender, e);
            OpenChildForm(new FeedBackForm1(currentTrainerId));
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
            return label.Font.Size >= ThemeTypography.Header.Size
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
                || normalized.Contains("profile")
                || normalized.Contains("enrolled students");
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
