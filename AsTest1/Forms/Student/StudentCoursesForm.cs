using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using APUCC_Project.Services;

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
            button3.Click += button3_Click;
        }

        private void StudentCoursesForm_Load(object? sender, EventArgs e)
        {
            SetupCoursesGrid();
            LoadSubscribedCourses();
            LoadAvailableCourses();
        }

        private void SetupCoursesGrid()
        {
            ConfigureGrid(dataGridView1);

            TrainerColumn.DataPropertyName = "Trainer";
            ScheduleColumn.DataPropertyName = "Schedule";
            StatusColumn.DataPropertyName = "Status";
            CourseNameColumn.DataPropertyName = "CourseName";

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.DisplayMember = "CourseName";
            comboBox1.ValueMember = "ClassScheduleID";
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
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.EnableHeadersVisualStyles = false;
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = Color.Black;
            grid.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(25, 25, 25);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grid.RowTemplate.Height = 34;
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

            LoadTable(query, dataGridView1);
        }

        private void LoadAvailableCourses()
        {
            const string query = @"
                SELECT
                    v.ClassScheduleID,
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
                ORDER BY v.SortDate, v.SortTime;";

            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                using SqlCommand cmd = new SqlCommand(query, conn);
                using SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("@StudentID", _studentId);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                comboBox1.DataSource = dt;
                comboBox1.SelectedIndex = dt.Rows.Count > 0 ? 0 : -1;
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
            if (comboBox1.SelectedValue == null || comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "No available course can be requested right now.",
                    "Request Course",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            int classScheduleId = Convert.ToInt32(comboBox1.SelectedValue);

            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();

                string existingStatus = GetExistingRequestStatus(conn, classScheduleId);

                if (existingStatus == "Pending")
                {
                    MessageBox.Show(
                        "You already have a pending request for this course.",
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
    }
}
