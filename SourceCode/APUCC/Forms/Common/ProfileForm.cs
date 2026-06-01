using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace APUCC_Project.Forms.Common
{
    public partial class ProfileForm : Form
    {
        private readonly string _connStr =
            ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        private readonly int _userId;
        private readonly string _userRole;
        private readonly string _dashboardTitle;
        private readonly Form _shellForm;

        public ProfileForm(int userId, string userRole, string dashboardTitle, Form shellForm)
        {
            InitializeComponent();
            _userId = userId;
            _userRole = string.IsNullOrWhiteSpace(userRole) ? "User" : userRole;
            _dashboardTitle = dashboardTitle;
            _shellForm = shellForm;
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            ApplyReadOnlyState(isEditing: false);
            LoadProfile();
        }

        private void LoadProfile()
        {
            if (_userId <= 0)
            {
                MessageBox.Show(
                    "Unable to load the profile because the current user was not identified.",
                    "Profile",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using SqlConnection con = new SqlConnection(_connStr);
                con.Open();

                const string query = @"
                    SELECT TOP 1
                        UserID,
                        Username,
                        [Role],
                        FullName,
                        Email,
                        CurrentPassword,
                        Phone,
                        [Address],
                        PrimaryCode,
                        SecondaryCode,
                        IdentityNumber,
                        Country,
                        ProgrammeName,
                        MentorName,
                        ProgrammeLeader,
                        PassExpiryDate
                    FROM dbo.vw_UserProfiles
                    WHERE UserID = @UserID;";

                using SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserID", _userId);

                using SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show(
                        "No profile data was found for this account.",
                        "Profile",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                txtUsername.Text = reader["Username"].ToString() ?? string.Empty;
                txtRole.Text = reader["Role"].ToString() ?? _userRole;
                txtEmail.Text = reader["Email"].ToString() ?? string.Empty;
                txtPassword.Text = reader["CurrentPassword"].ToString() ?? string.Empty;
                txtPhone.Text = reader["Phone"].ToString() ?? string.Empty;
                txtAddress.Text = reader["Address"].ToString() ?? string.Empty;

                string fullName = reader["FullName"].ToString() ?? "User Profile";
                string primaryCode = reader["PrimaryCode"].ToString() ?? $"USER-{_userId:0000}";
                string dashboard = string.IsNullOrWhiteSpace(_dashboardTitle) ? _userRole : _dashboardTitle;

                lblAccountTitle.Text = $"{fullName} Profile";
                Text = $"{dashboard} - {primaryCode}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Profile load error: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnEditPassword_Click(object sender, EventArgs e)
        {
            ApplyReadOnlyState(isEditing: true);
            txtPassword.Focus();
            txtPassword.SelectionStart = txtPassword.TextLength;
        }

        private void btnSavePassword_Click(object sender, EventArgs e)
        {
            string newPassword = txtPassword.Text.Trim();
            string newPhone = txtPhone.Text.Trim();
            string newAddress = txtAddress.Text.Trim();

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show(
                    "Password cannot be empty.",
                    "Profile",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (newPassword.Length < 8)
            {
                MessageBox.Show(
                    "Password must be at least 8 characters.",
                    "Profile",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                using SqlConnection con = new SqlConnection(_connStr);
                con.Open();
                using SqlTransaction transaction = con.BeginTransaction();

                using SqlCommand cmd = new SqlCommand(
                    @"UPDATE Users
                      SET [Password] = @Password,
                          Phone = @Phone,
                          [Address] = @Address
                      WHERE UserID = @UserID;",
                    con,
                    transaction);

                cmd.Parameters.AddWithValue("@Password", newPassword);
                cmd.Parameters.AddWithValue("@Phone", newPhone);
                cmd.Parameters.AddWithValue("@Address", newAddress);
                cmd.Parameters.AddWithValue("@UserID", _userId);
                cmd.ExecuteNonQuery();

                if (string.Equals(_userRole, "Student", StringComparison.OrdinalIgnoreCase))
                {
                    using SqlCommand studentCmd = new SqlCommand(
                        @"UPDATE s
                          SET s.ContactNumber = @Phone,
                              s.StudentAddress = @Address
                          FROM Students s
                          WHERE s.UserID = @UserID;",
                        con,
                        transaction);

                    studentCmd.Parameters.AddWithValue("@Phone", newPhone);
                    studentCmd.Parameters.AddWithValue("@Address", newAddress);
                    studentCmd.Parameters.AddWithValue("@UserID", _userId);
                    studentCmd.ExecuteNonQuery();
                }

                transaction.Commit();

                ApplyReadOnlyState(isEditing: false);

                MessageBox.Show(
                    "Profile updated successfully.",
                    "Profile",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to update the password: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ApplyReadOnlyState(bool isEditing)
        {
            txtUsername.ReadOnly = true;
            txtRole.ReadOnly = true;
            txtEmail.ReadOnly = true;

            txtPassword.ReadOnly = !isEditing;
            txtPhone.ReadOnly = !isEditing;
            txtAddress.ReadOnly = !isEditing;

            txtPassword.UseSystemPasswordChar = !isEditing;
            btnSavePassword.Enabled = isEditing;
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            Form? loginForm = Application.OpenForms
                .OfType<LoginForm>()
                .FirstOrDefault();

            if (loginForm is LoginForm reusableLogin)
            {
                reusableLogin.PrepareForReuse();
                reusableLogin.Show();
                reusableLogin.BringToFront();
            }
            else
            {
                loginForm = new LoginForm();
                loginForm.Show();
                loginForm.BringToFront();
            }

            _shellForm.Close();
        }
    }
}
