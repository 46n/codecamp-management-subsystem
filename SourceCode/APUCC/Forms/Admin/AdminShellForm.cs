using APUCC_Project.Forms.Admin;
using System;
using System.Windows.Forms;

namespace APUCC_Project
{
    public partial class AdminShellForm : BaseShellForm
    {
        public AdminShellForm(int userId)
        {
            InitializeComponent();
            InitializeUserContext(userId, "Admin");

            this.Text = "Admin Dashboard";
            this.ControlBox = true;

            homebtn.Text = "Manage Trainer";
            iconButton2.Text = "Trainer Feedback";
            iconButton3.Text = "Monthly Income Report";

            iconButton4.Visible = false;
            Profile.Visible = true;
            ApplyStandardShellWindow();

            OpenChildForm(new AdminManageTrainer());
        }

        private void OpenChildForm(Form childForm)
        {
            OpenSharedChildForm(childForm);
        }

        // Student actions when clicking the SHARED base buttons
        protected override void homebtn_Click(object sender, EventArgs e)
        {
            base.homebtn_Click(sender, e); // keeps highlight + style
            OpenChildForm(new AdminManageTrainer());
        }

        protected override void iconButton2_Click(object sender, EventArgs e)
        {
            base.iconButton2_Click(sender, e);
            OpenChildForm(new AdminTrainerFeedback());
        }

        protected override void iconButton3_Click(object sender, EventArgs e)
        {
            base.iconButton3_Click(sender, e);
            OpenChildForm(new AdminMonthlyIncome());
            // OpenChildForm(new StudentFeesForm());
        }

        protected override void iconButton4_Click(object sender, EventArgs e)
        {
            base.iconButton4_Click(sender, e);
            // OpenChildForm(new StudentProfileForm());
        }

        protected override void Profile_Click(object sender, EventArgs e)
        {
            base.Profile_Click(sender, e);
            // OpenChildForm(new StudentProfileForm());
        }

        private void homebtn_Click_1(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click_1(object sender, EventArgs e)
        {

        }

        private void iconButton4_Click_1(object sender, EventArgs e)
        {

        }

        private void iconButton3_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
