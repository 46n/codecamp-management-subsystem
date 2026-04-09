using System;
using System.Windows.Forms;

namespace APUCC_Project
{
    public partial class AdminShellForm : BaseShellForm
    {
        public AdminShellForm()
        {
            InitializeComponent();
            this.Text = "Student Dashboard";
            this.ControlBox = true;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            // Optional: change labels/icons for student
            homebtn.Text = "Home";
            iconButton2.Text = "My courses";
            iconButton3.Text = "Fees";
            iconButton4.Text = "Settings";
            Profile.Text = "Profile";
        }

        // Student actions when clicking the SHARED base buttons
        protected override void homebtn_Click(object sender, EventArgs e)
        {
            base.homebtn_Click(sender, e); // keeps highlight + style
            // OpenChildForm(new StudentHomeForm());
        }

        protected override void iconButton2_Click(object sender, EventArgs e)
        {
            base.iconButton2_Click(sender, e);
            // OpenChildForm(new StudentCoursesForm());
        }

        protected override void iconButton3_Click(object sender, EventArgs e)
        {
            base.iconButton3_Click(sender, e);
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