using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using APUCC_Project.Services;

namespace APUCC_Project.Forms.Student
{
    public partial class StudentHomeForm : Form
    {
        private readonly int _studentId;

        public StudentHomeForm(int studentId)
        {
            InitializeComponent();
            _studentId = studentId;

            Load += StudentHomeForm_Load;
            btnCurrentSchedule.Click += btnCurrentSchedule_Click;
            btnUpcomingSchedule.Click += btnUpcomingSchedule_Click;
        }

        private void StudentHomeForm_Load(object? sender, EventArgs e)
        {
            SetupGrid();
            LoadCurrentSchedule();
        }

        private void SetupGrid()
        {
            dgvSchedule.ReadOnly = true;
            dgvSchedule.AutoGenerateColumns = false;
            dgvSchedule.AllowUserToAddRows = false;
            dgvSchedule.AllowUserToDeleteRows = false;
            dgvSchedule.AllowUserToResizeRows = false;
            dgvSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSchedule.MultiSelect = false;
            dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ModuleColumnHome.DataPropertyName = "Module";
            TrainerColumn.DataPropertyName = "Trainer";
            DayColumnHome.DataPropertyName = "Day";
            TimeColumnHome.DataPropertyName = "Time";
            RoomColumnHome.DataPropertyName = "Room";
            StatusColumnHome.DataPropertyName = "Status";

            dgvSchedule.DefaultCellStyle.BackColor = Color.White;
            dgvSchedule.DefaultCellStyle.ForeColor = Color.Black;
            dgvSchedule.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            dgvSchedule.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvSchedule.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(25, 25, 25);
            dgvSchedule.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSchedule.EnableHeadersVisualStyles = false;

            dgvSchedule.RowHeadersVisible = false;
            dgvSchedule.ClearSelection();
        }

        private void LoadCurrentSchedule()
        {
            string query = @"
                SELECT 
                    cs.ModuleName AS Module,
                    tu.[Name] AS Trainer,
                    FORMAT(cs.ClassDate, 'dddd') AS [Day],
                    CONVERT(VARCHAR(5), cs.ClassTime, 108) AS [Time],
                    cs.Room,
                    se.EnrollmentStatus AS [Status]
                FROM StudentEnrollments se
                INNER JOIN ClassSchedule cs ON se.ClassScheduleID = cs.Id
                INNER JOIN Students s ON se.StudentID = s.StudentID
                LEFT JOIN Trainers t ON cs.TrainerID = t.TrainerID
                LEFT JOIN Users tu ON t.UserID = tu.UserID
                WHERE se.StudentID = @StudentID
                  AND se.EnrollmentStatus = 'Active'
                  AND cs.ClassDate = CAST(GETDATE() AS DATE)
                ORDER BY cs.ClassTime;";

            LoadSchedule(query);
        }

        private void LoadUpcomingSchedule()
        {
            string query = @"
                SELECT 
                    cs.ModuleName AS Module,
                    tu.[Name] AS Trainer,
                    FORMAT(cs.ClassDate, 'dddd') AS [Day],
                    CONVERT(VARCHAR(5), cs.ClassTime, 108) AS [Time],
                    cs.Room,
                    se.EnrollmentStatus AS [Status]
                FROM StudentEnrollments se
                INNER JOIN ClassSchedule cs ON se.ClassScheduleID = cs.Id
                INNER JOIN Students s ON se.StudentID = s.StudentID
                LEFT JOIN Trainers t ON cs.TrainerID = t.TrainerID
                LEFT JOIN Users tu ON t.UserID = tu.UserID
                WHERE se.StudentID = @StudentID
                  AND se.EnrollmentStatus = 'Active'
                  AND cs.ClassDate > CAST(GETDATE() AS DATE)
                ORDER BY cs.ClassDate, cs.ClassTime;";

            LoadSchedule(query);
        }

        private void LoadSchedule(string query)
        {
            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                using SqlCommand cmd = new SqlCommand(query, conn);
                using SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("@StudentID", _studentId);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvSchedule.DataSource = null;
                dgvSchedule.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load schedule: " + ex.Message);
            }
        }

        private void btnCurrentSchedule_Click(object? sender, EventArgs e)
        {
            LoadCurrentSchedule();
        }

        private void btnUpcomingSchedule_Click(object? sender, EventArgs e)
        {
            LoadUpcomingSchedule();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}