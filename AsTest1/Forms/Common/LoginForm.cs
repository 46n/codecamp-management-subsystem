using System;
using System.Configuration;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using APUCC_Project.Forms.Admin;
using APUCC_Project.Forms.Lecturer;
using APUCC_Project.Forms.Student;
using APUCC_Project.Forms.Trainer;

namespace APUCC_Project.Forms.Common
{
    public partial class LoginForm : Form
    {
        private readonly string connStr =
            ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
        private bool isPasswordVisible;

        public LoginForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        public void PrepareForReuse()
        {
            txtUser.Clear();
            txtPassword.Clear();
            lblWrong.Visible = false;
            SetPasswordVisibility(false);
            txtUser.Focus();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            lblWrong.Visible = false;
            lblWrong.Text = "Wrong username/email or password.";

            SetPasswordVisibility(false);
            AcceptButton = btnLogin;
        }

        private void SetPasswordVisibility(bool visible)
        {
            isPasswordVisible = visible;
            txtPassword.UseSystemPasswordChar = !visible;
            btnTogglePassword.Text = visible ? "Hide" : "Show";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblWrong.Visible = false;

            string userInput = txtUser.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                lblWrong.Text = "Please enter username or email.";
                lblWrong.Visible = true;
                txtUser.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                lblWrong.Text = "Please enter password.";
                lblWrong.Visible = true;
                txtPassword.Focus();
                return;
            }

            try
            {
                using SqlConnection con = new SqlConnection(connStr);
                con.Open();

                string query = @"
                    SELECT u.UserID, u.Role, s.StudentID
                    FROM Users u
                    LEFT JOIN Students s ON u.UserID = s.UserID
                    WHERE (u.Username = @UserInput OR u.Email = @UserInput)
                      AND u.[Password] = @Password";

                using SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserInput", userInput);
                cmd.Parameters.AddWithValue("@Password", password);

                using SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    int userId = Convert.ToInt32(dr["UserID"]);
                    string role = dr["Role"].ToString() ?? string.Empty;
                    Form? nextForm = null;

                    if (role == "Admin")
                    {
                        nextForm = new AdminShellForm(userId);
                    }
                    else if (role == "Trainer")
                    {
                        nextForm = new TrainerShellForm(userId);
                    }
                    else if (role == "Student")
                    {
                        if (dr["StudentID"] == DBNull.Value)
                        {
                            lblWrong.Text = "Student profile was not found.";
                            lblWrong.Visible = true;
                            return;
                        }

                        int studentId = Convert.ToInt32(dr["StudentID"]);
                        nextForm = new StudentShellForm(userId, studentId);
                    }
                    else if (role == "Lecturer")
                    {
                        nextForm = new LecturerShellForm(userId);
                    }
                    else
                    {
                        lblWrong.Text = "Soory, An Invalid User .";
                        lblWrong.Visible = true;
                        return;
                    }

                    nextForm.Show();
                    Hide();
                }
                else
                {
                    lblWrong.Text = "Wrong username/email or password.";
                    lblWrong.Visible = true;
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Login error: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            lblWrong.Visible = false;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            lblWrong.Visible = false;
        }

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            SetPasswordVisibility(!isPasswordVisible);
        }
    }
}
