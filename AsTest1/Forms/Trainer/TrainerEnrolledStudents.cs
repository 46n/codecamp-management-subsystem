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
            dgvEnrolledStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEnrolledStudents.MultiSelect = false;
            dgvEnrolledStudents.ReadOnly = true;
            dgvEnrolledStudents.AllowUserToAddRows = false;
            dgvEnrolledStudents.AllowUserToDeleteRows = false;
            dgvEnrolledStudents.AllowUserToResizeRows = false;
            dgvEnrolledStudents.AllowUserToResizeColumns = false;
            dgvEnrolledStudents.RowHeadersVisible = false;
            dgvEnrolledStudents.ScrollBars = ScrollBars.Both;
            dgvEnrolledStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvEnrolledStudents.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvEnrolledStudents.RowTemplate.Height = 34;
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
                            ISNULL(ph.PaymentHistoryID, 0) AS PaymentID,
                            u.[Name] AS StudentName,
                            cs.ModuleId,
                            cs.ModuleName,
                            cs.ClassDate,
                            cs.ClassTime,
                            cs.Level,
                            cs.Room,
                            i.Amount,
                            ph.PaymentDate,
                            CASE
                                WHEN ph.PaymentHistoryID IS NOT NULL THEN ph.PaymentStatus
                                ELSE i.InvoiceStatus
                            END AS [Status]
                        FROM StudentEnrollments se
                        INNER JOIN Students s
                            ON se.StudentID = s.StudentID
                        INNER JOIN Users u
                            ON s.UserID = u.UserID
                        INNER JOIN ClassSchedule cs 
                            ON se.ClassScheduleID = cs.Id
                        LEFT JOIN Invoices i
                            ON i.EnrollmentID = se.EnrollmentID
                        LEFT JOIN PaymentHistory ph
                            ON ph.InvoiceID = i.InvoiceID
                        WHERE cs.TrainerID = @TrainerID
                        ORDER BY 
                            CASE WHEN ph.PaymentDate IS NULL THEN 1 ELSE 0 END,
                            ph.PaymentDate DESC,
                            se.EnrollmentID DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    da.SelectCommand.Parameters.AddWithValue("@TrainerID", trainerId);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvEnrolledStudents.DataSource = dt;

                    ConfigureGridColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message);
            }
        }

        private void ConfigureGridColumns()
        {
            if (dgvEnrolledStudents.Columns.Count == 0)
            {
                return;
            }

            SetColumn("PaymentID", "Payment ID", 110);
            SetColumn("StudentName", "Student Name", 190);
            SetColumn("ModuleId", "Module ID", 110);
            SetColumn("ModuleName", "Module Name", 220);
            SetColumn("ClassDate", "Class Date", 130);
            SetColumn("ClassTime", "Class Time", 120);
            SetColumn("Level", "Level", 120);
            SetColumn("Room", "Room", 100);
            SetColumn("Amount", "Amount", 110);
            SetColumn("PaymentDate", "Payment Date", 140);
            SetColumn("Status", "Status", 120);
        }

        private void SetColumn(string columnName, string headerText, int width)
        {
            if (dgvEnrolledStudents.Columns[columnName] == null)
            {
                return;
            }

            DataGridViewColumn column = dgvEnrolledStudents.Columns[columnName];
            column.HeaderText = headerText;
            column.Width = width;
            column.Resizable = DataGridViewTriState.False;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        private void dgvEnrolledStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional if you want actions on click
        }
    }
}
