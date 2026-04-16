using System;
using System.Linq;
using System.Windows.Forms;

namespace APUCC_Project.Forms.Common
{
    public partial class ProfileForm : Form
    {
        private readonly Form _shellForm;

        public ProfileForm(string dashboardTitle, Form shellForm)
        {
            InitializeComponent();
            _shellForm = shellForm;
            lblRoleValue.Text = string.IsNullOrWhiteSpace(dashboardTitle)
                ? "Current Dashboard"
                : dashboardTitle;
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
