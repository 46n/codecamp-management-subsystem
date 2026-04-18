using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using APUCC_Project.Services;
using APUCC_Project.UI;

namespace APUCC_Project.Forms.Student
{
    public partial class StudentHomeForm : Form
    {
        private enum ScheduleView
        {
            Current,
            Upcoming
        }

        private readonly int _studentId;
        private ScheduleView _activeView = ScheduleView.Current;

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
            ApplyGreetingText();
            SetupGrid();
            ShowSchedule(ScheduleView.Current);
        }

        private void ApplyGreetingText()
        {
            string studentName = GetStudentDisplayName();
            lblGreeting.Text = $"Good day, {studentName}!";
            lblWelcome.Text = "Welcome to your CodeCamp dashboard";
            lblWelcome.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point);
        }

        private string GetStudentDisplayName()
        {
            const string query = @"
                SELECT TOP 1 u.[Name]
                FROM Students s
                INNER JOIN Users u ON s.UserID = u.UserID
                WHERE s.StudentID = @StudentID;";

            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                using SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@StudentID", _studentId);
                conn.Open();

                object? result = cmd.ExecuteScalar();
                string? displayName = result?.ToString()?.Trim();

                return string.IsNullOrWhiteSpace(displayName)
                    ? "Student"
                    : displayName;
            }
            catch
            {
                return "Student";
            }
        }

        private void SetupGrid()
        {
            dgvSchedule.ReadOnly = true;
            dgvSchedule.AutoGenerateColumns = false;
            dgvSchedule.AllowUserToAddRows = false;
            dgvSchedule.AllowUserToDeleteRows = false;
            dgvSchedule.AllowUserToResizeRows = false;
            dgvSchedule.AllowUserToResizeColumns = false;
            dgvSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSchedule.MultiSelect = false;
            dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSchedule.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvSchedule.BorderStyle = BorderStyle.None;
            dgvSchedule.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvSchedule.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvSchedule.RowTemplate.Height = 36;

            ModuleColumnHome.DataPropertyName = "Module";
            TrainerColumn.DataPropertyName = "Trainer";
            DateColumnHome.DataPropertyName = "Date";
            DayColumnHome.DataPropertyName = "Day";
            TimeColumnHome.DataPropertyName = "Time";
            RoomColumnHome.DataPropertyName = "Room";
            StatusColumnHome.DataPropertyName = "Status";

            dgvSchedule.DefaultCellStyle.BackColor = ThemePalette.BaseBackground;
            dgvSchedule.DefaultCellStyle.ForeColor = ThemePalette.PrimaryText;
            dgvSchedule.DefaultCellStyle.SelectionBackColor = ThemePalette.SelectionBackground;
            dgvSchedule.DefaultCellStyle.SelectionForeColor = ThemePalette.PrimaryText;

            dgvSchedule.ColumnHeadersDefaultCellStyle.BackColor = ThemePalette.SecondaryBackground;
            dgvSchedule.ColumnHeadersDefaultCellStyle.ForeColor = ThemePalette.PrimaryText;
            dgvSchedule.EnableHeadersVisualStyles = false;

            dgvSchedule.RowHeadersVisible = false;
            dgvSchedule.ClearSelection();
            ApplyButtonState();
        }

        private void ShowSchedule(ScheduleView scheduleView)
        {
            _activeView = scheduleView;
            ApplyButtonState();
            LoadSchedule(scheduleView);
        }

        private void LoadSchedule(ScheduleView scheduleView)
        {
            string scheduleLabel = scheduleView == ScheduleView.Current
                ? "Current"
                : "Upcoming";

            string query = @"
                SELECT 
                    Module,
                    Trainer,
                    [Date],
                    [Day],
                    [Time],
                    Room,
                    ScheduleType AS [Status]
                FROM vw_StudentHomeSchedule
                WHERE StudentID = @StudentID
                  AND ScheduleType = @ScheduleLabel
                  AND IsVisibleOnHome = 1
                ORDER BY SortDate, SortTime;";

            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                using SqlCommand cmd = new SqlCommand(query, conn);
                using SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("@StudentID", _studentId);
                cmd.Parameters.AddWithValue("@ScheduleLabel", scheduleLabel);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvSchedule.DataSource = null;
                dgvSchedule.DataSource = dt;
                dgvSchedule.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load schedule: " + ex.Message);
            }
        }

        private void ApplyButtonState()
        {
            StyleScheduleButton(btnCurrentSchedule, _activeView == ScheduleView.Current);
            StyleScheduleButton(btnUpcomingSchedule, _activeView == ScheduleView.Upcoming);
        }

        private static void StyleScheduleButton(Button button, bool isActive)
        {
            button.BackColor = isActive
                ? ThemePalette.PrimaryButton
                : ThemePalette.BaseBackground;
            button.ForeColor = isActive
                ? Color.White
                : ThemePalette.PrimaryText;
            button.FlatAppearance.BorderColor = ThemePalette.PrimaryButton;
        }

        private void btnCurrentSchedule_Click(object? sender, EventArgs e)
        {
            ShowSchedule(ScheduleView.Current);
        }

        private void btnUpcomingSchedule_Click(object? sender, EventArgs e)
        {
            ShowSchedule(ScheduleView.Upcoming);
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
        }
    }
}
