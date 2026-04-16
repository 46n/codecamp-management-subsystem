using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace APUCC_Project.Forms.Trainer
{
    public partial class TrainerEnrolledStudents : Form
    {
        private readonly string connStr =
            ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        private int trainerId;

        // =========================
        // DEFAULT CONSTRUCTOR
        // =========================
        public TrainerEnrolledStudents()
        {
            InitializeComponent();
            SetupForm();
        }

        // =========================
        // CONSTRUCTOR WITH TRAINER ID (IMPORTANT)
        // =========================
        public TrainerEnrolledStudents(int loggedInTrainerId)
        {
            InitializeComponent();
            trainerId = loggedInTrainerId;
            SetupForm();
        }

        // =========================
        // FORM SETTINGS
        // =========================
        private void SetupForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
        }

        // =========================
        // FORM LOAD
        // =========================
        private void TrainerEnrolledStudents_Load(object sender, EventArgs e)
        {
            LoadEnrolledStudents();
        }

        // =========================
        // LOAD STUDENTS FOR THIS TRAINER ONLY
        // =========================
        private void LoadEnrolledStudents()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    string query = @"
                        SELECT 
                            sp.PaymentID,
                            sp.StudentName,
                            cs.ModuleId,
                            cs.ModuleName,
                            cs.ClassDate,
                            cs.ClassTime,
                            cs.Level,
                            cs.Room,
                            sp.Amount,
                            sp.PaymentDate,
                            sp.Status
                        FROM StudentPayments sp
                        INNER JOIN ClassSchedule cs 
                            ON sp.ClassScheduleID = cs.Id
                        WHERE cs.TrainerID = @TrainerID
                        ORDER BY sp.PaymentDate DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    da.SelectCommand.Parameters.AddWithValue("@TrainerID", trainerId);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvEnrolledStudents.DataSource = dt;

                    // UI SETTINGS
                    dgvEnrolledStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvEnrolledStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvEnrolledStudents.MultiSelect = false;
                    dgvEnrolledStudents.ReadOnly = true;
                    dgvEnrolledStudents.AllowUserToAddRows = false;
                    dgvEnrolledStudents.AllowUserToDeleteRows = false;
                    dgvEnrolledStudents.RowHeadersVisible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message);
            }
        }
        private void dgvEnrolledStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional if you want actions on click
        }
    }
}