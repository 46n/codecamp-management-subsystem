using APUCC_Project.Forms.Trainer;
using System;
using System.Windows.Forms;

namespace APUCC_Project
{
    public partial class TrainerShellForm : BaseShellForm
    {
        private Form? activeForm = null;
        public TrainerShellForm()
        {
            InitializeComponent();
            this.ControlBox = true;
            OpenChildForm(new TrainerHomeForm());

            // Optional: change labels/icons for student
            homebtn.Text = "Manage Classes";
            iconButton2.Text = "EnrolLed Student";
            iconButton3.Text = "Feedback";
            iconButton4.Text = "Settings";
            Profile.Text = "Profile";
        }
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            MainPanel.Controls.Clear();   // the big panel on the right
            MainPanel.Controls.Add(childForm);

            childForm.BringToFront();
            childForm.Show();
        }
        // Student actions when clicking the SHARED base buttons
        protected override void homebtn_Click(object sender, EventArgs e)
        {
            base.homebtn_Click(sender, e); // keeps highlight + style
            OpenChildForm(new TrainerHomeForm());
        }

        protected override void iconButton2_Click(object sender, EventArgs e)
        {
            base.iconButton2_Click(sender, e);
            OpenChildForm(new TrainerEnrolledStudents());
            // OpenChildForm(new StudentCoursesForm());
        }

        protected override void iconButton3_Click(object sender, EventArgs e)
        {
            base.iconButton3_Click(sender, e);
            OpenChildForm(new FeedBackForm1());
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

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void homebtn_Click_1(object sender, EventArgs e)
        {

        }

        private void TrainerShellForm_Load(object sender, EventArgs e)
        {
            OpenChildForm(new TrainerHomeForm());
        }

        private void iconButton2_Click_1(object sender, EventArgs e)
        {

        }
    }
}