using System;
using System.Windows.Forms;

namespace APUCC_Project
{
    public partial class StudentShellForm : BaseShellForm
    {
        public StudentShellForm()
        {
            InitializeComponent();

            // Optional: change labels/icons for student
            homebtn.Text = "Home";
            iconButton2.Text = "My courses";
            iconButton3.Text = "Fees";
            iconButton4.Text = "Swttings";
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
    }
}