using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using APUCC_Project.Services;
using APUCC_Project.UI;

namespace APUCC_Project.Forms.Student
{
    public partial class StudentCoursesForm : Form
    {
        private readonly int _studentId;

        public StudentCoursesForm(int studentId)
        {
            InitializeComponent();
            _studentId = studentId;

            Load += StudentCoursesForm_Load;
            btnRequestCourse.Click += button3_Click;
        }

        private void StudentCoursesForm_Load(object? sender, EventArgs e)
        {
            SetupCoursesGrid();
            LoadSubscribedCourses();
            LoadAvailableCourses();
            LoadPendingRequests();
        }

        private void SetupCoursesGrid()
        {
            ConfigureGrid(dgvCurrentCourses);
            ConfigureGrid(dgvPendingRequest);

            TrainerColumn.DataPropertyName = "Trainer";
            ScheduleColumn.DataPropertyName = "Schedule";
            StatusColumn.DataPropertyName = "Status";
            CourseNameColumn.DataPropertyName = "CourseName";

            PendingRequestIdColumn.DataPropertyName = "RequestID";
            PendingTrainerColumn.DataPropertyName = "Trainer";
            PendingCourseNameColumn.DataPropertyName = "CourseName";
            PendingLevelColumn.DataPropertyName = "Level";
            PendingRequestDateColumn.DataPropertyName = "RequestDate";
            PendingStatusColumn.DataPropertyName = "Status";

            if (dgvPendingRequest.Columns.Contains("PendingActionColumn"))
            {
                DataGridViewButtonColumn cancelColumn = (DataGridViewButtonColumn)dgvPendingRequest.Columns["PendingActionColumn"];
                cancelColumn.FlatStyle = FlatStyle.Flat;
                cancelColumn.DefaultCellStyle.BackColor = Color.FromArgb(178, 55, 45);
                cancelColumn.DefaultCellStyle.ForeColor = Color.White;
                cancelColumn.DefaultCellStyle.SelectionBackColor = Color.FromArgb(147, 39, 31);
                cancelColumn.DefaultCellStyle.SelectionForeColor = Color.White;
            }

            cboAvailableCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAvailableCourse.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboAvailableCourse.DisplayMember = "CourseName";
            cboAvailableCourse.ValueMember = "ClassScheduleID";
        }

        private void ConfigureGrid(DataGridView grid)
        {
            grid.ReadOnly = true;
            grid.AutoGenerateColumns = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.AllowUserToResizeColumns = false;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.RowHeadersVisible = false;
            grid.BackgroundColor = ThemePalette.BaseBackground;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.EnableHeadersVisualStyles = false;
            grid.DefaultCellStyle.BackColor = ThemePalette.BaseBackground;
            grid.DefaultCellStyle.ForeColor = ThemePalette.PrimaryText;
            grid.DefaultCellStyle.SelectionBackColor = ThemePalette.SelectionBackground;
            grid.DefaultCellStyle.SelectionForeColor = ThemePalette.PrimaryText;
            grid.DefaultCellStyle.Font = ThemeTypography.GridBody;
            grid.ColumnHeadersDefaultCellStyle.BackColor = ThemePalette.SecondaryBackground;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = ThemePalette.PrimaryText;
            grid.ColumnHeadersDefaultCellStyle.Font = ThemeTypography.GridHeader;
            grid.RowsDefaultCellStyle.Font = ThemeTypography.GridBody;
            grid.AlternatingRowsDefaultCellStyle.Font = ThemeTypography.GridBody;
            grid.RowTemplate.Height = 28;
            grid.ClearSelection();
        }

        private void LoadSubscribedCourses()
        {
            const string query = @"
                SELECT
                    Trainer,
                    Schedule,
                    [Status],
                    CourseName
                FROM dbo.vw_StudentSubscribedCourses
                WHERE StudentID = @StudentID
                ORDER BY SortDate, SortTime;";

            LoadTable(query, dgvCurrentCourses);
        }

        private void LoadPendingRequests()
        {
            const string query = @"
                SELECT
                    er.RequestID,
                    u.[Name] AS Trainer,
                    cs.ModuleName AS CourseName,
                    cs.[Level] AS [Level],
                    CONVERT(varchar(10), er.RequestDate, 23) AS RequestDate,
                    er.RequestStatus AS [Status]
                FROM EnrollmentRequests er
                INNER JOIN ClassSchedule cs ON er.ClassScheduleID = cs.Id
                INNER JOIN Trainers t ON cs.TrainerID = t.TrainerID
                INNER JOIN Users u ON t.UserID = u.UserID
                WHERE er.StudentID = @StudentID
                  AND er.RequestStatus = 'Pending'
                ORDER BY er.RequestDate DESC, er.RequestID DESC;";

            LoadTable(query, dgvPendingRequest);
        }

        private void LoadAvailableCourses()
        {
            const string query = @"
        SELECT
            MIN(v.ClassScheduleID) AS ClassScheduleID,
            v.CourseName
        FROM dbo.vw_RequestableCourseOptions v
        WHERE NOT EXISTS
        (
            SELECT 1
            FROM StudentEnrollments se
            WHERE se.StudentID = @StudentID
              AND se.ClassScheduleID = v.ClassScheduleID
              AND se.EnrollmentStatus = 'Active'
        )
        AND NOT EXISTS
        (
            SELECT 1
            FROM EnrollmentRequests er
            WHERE er.StudentID = @StudentID
              AND er.ClassScheduleID = v.ClassScheduleID
              AND er.RequestStatus = 'Pending'
        )
        GROUP BY v.CourseName
        ORDER BY v.CourseName;";

            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                using SqlCommand cmd = new SqlCommand(query, conn);
                using SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("@StudentID", _studentId);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cboAvailableCourse.DataSource = null;
                cboAvailableCourse.DataSource = dt;
                cboAvailableCourse.DisplayMember = "CourseName";
                cboAvailableCourse.ValueMember = "ClassScheduleID";
                cboAvailableCourse.SelectedIndex = dt.Rows.Count > 0 ? 0 : -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load available courses: " + ex.Message);
            }
        }

        private void LoadTable(string query, DataGridView grid)
        {
            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                using SqlCommand cmd = new SqlCommand(query, conn);
                using SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("@StudentID", _studentId);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                grid.DataSource = null;
                grid.DataSource = dt;
                grid.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load courses: " + ex.Message);
            }
        }

        private void button3_Click(object? sender, EventArgs e)
        {
            if (cboAvailableCourse.SelectedValue == null || cboAvailableCourse.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "No available course can be requested right now.",
                    "Request Course",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            int classScheduleId = Convert.ToInt32(cboAvailableCourse.SelectedValue);
            string courseName = cboAvailableCourse.Text.Trim();

            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();

                string existingStatus = GetExistingRequestStatus(conn, classScheduleId);

                if (existingStatus == "Pending")
                {
                    MessageBox.Show(
                        "The course request is already pending with the lecturer.",
                        "Request Course",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                if (existingStatus == "Approved")
                {
                    MessageBox.Show(
                        "This course request was already approved.",
                        "Request Course",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                bool shouldProceed = ActionConfirmationDialog.ShowConfirmation(
                    this,
                    "Request Course",
                    $"The course request for {courseName} will be marked as pending and sent to the lecturer. Do you want to proceed?",
                    "Proceed",
                    "Cancel");

                if (!shouldProceed)
                {
                    return;
                }

                if (existingStatus == "Rejected")
                {
                    const string retryRejectedQuery = @"
                        UPDATE EnrollmentRequests
                        SET RequestDate = CAST(GETDATE() AS DATE),
                            RequestStatus = 'Pending',
                            Remarks = 'Requested from Student Courses form',
                            HandledByLecturerID = NULL,
                            HandledDate = NULL
                        WHERE StudentID = @StudentID
                          AND ClassScheduleID = @ClassScheduleID;";

                    using SqlCommand updateCmd = new SqlCommand(retryRejectedQuery, conn);
                    updateCmd.Parameters.AddWithValue("@StudentID", _studentId);
                    updateCmd.Parameters.AddWithValue("@ClassScheduleID", classScheduleId);
                    updateCmd.ExecuteNonQuery();
                }
                else
                {
                    const string insertQuery = @"
                        INSERT INTO EnrollmentRequests
                        (
                            StudentID,
                            ClassScheduleID,
                            RequestDate,
                            RequestStatus,
                            Remarks
                        )
                        VALUES
                        (
                            @StudentID,
                            @ClassScheduleID,
                            CAST(GETDATE() AS DATE),
                            'Pending',
                            'Requested from Student Courses form'
                        );";

                    using SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@StudentID", _studentId);
                    insertCmd.Parameters.AddWithValue("@ClassScheduleID", classScheduleId);
                    insertCmd.ExecuteNonQuery();
                }

                MessageBox.Show(
                    "Course request sent to the lecturer successfully.",
                    "Request Course",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadSubscribedCourses();
                LoadAvailableCourses();
                LoadPendingRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to request course: " + ex.Message);
            }
        }

        private string GetExistingRequestStatus(SqlConnection conn, int classScheduleId)
        {
            const string query = @"
                SELECT RequestStatus
                FROM EnrollmentRequests
                WHERE StudentID = @StudentID
                  AND ClassScheduleID = @ClassScheduleID;";

            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@StudentID", _studentId);
            cmd.Parameters.AddWithValue("@ClassScheduleID", classScheduleId);

            object? result = cmd.ExecuteScalar();
            return result?.ToString() ?? string.Empty;
        }

        private void FillPanelCourses_Paint(object sender, PaintEventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            if (dgvPendingRequest.Columns[e.ColumnIndex].Name != "PendingActionColumn")
            {
                return;
            }

            object? requestIdValue = dgvPendingRequest.Rows[e.RowIndex].Cells["PendingRequestIdColumn"].Value;
            object? courseNameValue = dgvPendingRequest.Rows[e.RowIndex].Cells["PendingCourseNameColumn"].Value;

            if (requestIdValue == null || !int.TryParse(requestIdValue.ToString(), out int requestId))
            {
                MessageBox.Show("Unable to identify the pending request to cancel.", "Pending Requests", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string courseName = courseNameValue?.ToString() ?? "this course";

            bool shouldCancel = ActionConfirmationDialog.ShowConfirmation(
                this,
                "Cancel Request",
                $"The pending request for {courseName} will be cancelled. Do you want to proceed?",
                "Proceed",
                "Cancel");

            if (!shouldCancel)
            {
                return;
            }

            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();

                const string deleteQuery = @"
                    DELETE FROM EnrollmentRequests
                    WHERE RequestID = @RequestID
                      AND StudentID = @StudentID
                      AND RequestStatus = 'Pending';";

                using SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                cmd.Parameters.AddWithValue("@RequestID", requestId);
                cmd.Parameters.AddWithValue("@StudentID", _studentId);

                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows == 0)
                {
                    MessageBox.Show("This request could not be cancelled because it is no longer pending.", "Pending Requests", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The pending request was cancelled successfully.", "Pending Requests", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadPendingRequests();
                LoadAvailableCourses();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to cancel request: " + ex.Message, "Pending Requests", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
