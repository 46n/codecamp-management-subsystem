using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace APUCC_Project.Forms.Trainer
{
    public partial class TrainerEnrolledStudents : Form
    {
        private int trainerId;

        // Default constructor (if no login yet)
        public TrainerEnrolledStudents()
        {
            InitializeComponent();
            SetupForm();
        }

        // Constructor with TrainerID (recommended)
        public TrainerEnrolledStudents(int id)
        {
            InitializeComponent();
            trainerId = id;
            SetupForm();
        }

        private void SetupForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void TrainerEnrolledStudents_Load(object sender, EventArgs e)
        {
            // Later: Load students here
            // LoadEnrolledStudents();
        }

        // ✅ GO BACK BUTTON
        private void btnBack_Click(object sender, EventArgs e)
        {
            TrainerHomeForm home = new TrainerHomeForm();
            home.Show();
            this.Close();
        }

        private void dgvEnrolledStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: handle cell clicks
        }
    }
}