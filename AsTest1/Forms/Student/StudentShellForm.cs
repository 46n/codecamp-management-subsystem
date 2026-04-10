using APUCC_Project.Forms.Student;
using System;
using System.Windows.Forms;

namespace APUCC_Project
{
    public partial class StudentShellForm : BaseShellForm
    {
        private Form? activeForm = null;
        public StudentShellForm()
        {
            InitializeComponent();

            OpenChildForm(new StudentHomeForm());

            this.Text = "Student Dashboard";
            this.ControlBox = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true; // optional
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            homebtn.Text = "Home";
            iconButton2.Text = "My courses";
            iconButton3.Text = "Fees";
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

            MainPanel.Controls.Clear();

            Panel contentPanel = new Panel();
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Padding = new Padding(0, 30, 0, 0); // left, top, right, bottom
            contentPanel.BackColor = MainPanel.BackColor;

            childForm.Dock = DockStyle.Fill;

            contentPanel.Controls.Add(childForm);
            MainPanel.Controls.Add(contentPanel);

            childForm.BringToFront();
            childForm.Show();
        }
        // Student actions when clicking the SHARED base buttons
        protected override void homebtn_Click(object sender, EventArgs e)
        {
            base.homebtn_Click(sender, e); // keeps highlight + style
            OpenChildForm(new StudentHomeForm());
        }

        protected override void iconButton2_Click(object sender, EventArgs e)
        {
            base.iconButton2_Click(sender, e);
            OpenChildForm(new StudentCoursesForm());
        }

        protected override void iconButton3_Click(object sender, EventArgs e)
        {
            base.iconButton3_Click(sender, e);
            OpenChildForm(new StudentFeesForm());
        }

        protected override void iconButton4_Click(object sender, EventArgs e)
        {
            base.iconButton4_Click(sender, e);
            //OpenChildForm(new StudentProfileForm());
        }

        protected override void Profile_Click(object sender, EventArgs e)
        {
            base.Profile_Click(sender, e);
            // OpenChildForm(new StudentProfileForm());
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void StudentShellForm_Load(object sender, EventArgs e)
        {

        }
    }


}