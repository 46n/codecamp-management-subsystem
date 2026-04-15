using System;
using System.Configuration;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using APUCC_Project.Forms.Admin;
using APUCC_Project.Forms.Trainer;
using APUCC_Project.Forms.Student;
// using APUCC_Project.Forms.Lecturer;

namespace APUCC_Project.Forms.Common
{
    public partial class LoginForm : Form
    {
        private readonly string connStr =
            ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            lblWrong.Visible = false;
            lblWrong.Text = "Wrong username/email or password.";

            txtPassword.UseSystemPasswordChar = true;

            // Press Enter to login
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblWrong.Visible = false;

            string userInput = txtUser.Text.Trim();
            string password = txtPassword.Text.Trim();

            // ================= VALIDATION =================
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
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();

                    string query = @"
                        SELECT UserID, Role
                        FROM Users
                        WHERE (Username = @UserInput OR Email = @UserInput)
                          AND Password = @Password";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserInput", userInput);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            // ================= ROLE HANDLING =================
                            if (dr.Read())
                            {
                                int userId = Convert.ToInt32(dr["UserID"]);
                                string role = dr["Role"].ToString();

                                Form nextForm = null;

                                if (role == "Admin")
                                {
                                    nextForm = new AdminShellForm();
                                }
                                else if (role == "Trainer")
                                {
                                    nextForm = new TrainerShellForm();
                                }
                                else if (role == "Student")
                                {
                                     nextForm = new StudentShellForm();
                                }
                                else if (role == "Lecturer")
                                {
                                     nextForm = new LecturerShellForm();
                                }
                                else
                                {
                                    lblWrong.Text = "Soory, An Invalid User .";
                                    return;
                                }

                                nextForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                lblWrong.Text = "Wrong username/email or password.";
                                lblWrong.Visible = true;
                                txtPassword.Clear();
                                txtPassword.Focus();
                            }
                        }
                    }
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

        // Hide error when typing again
        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            lblWrong.Visible = false;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            lblWrong.Visible = false;
        }
    }
}