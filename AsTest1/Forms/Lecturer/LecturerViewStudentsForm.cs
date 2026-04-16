using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace APUCC_Project.Forms.Lecturer
{
    public partial class LecturerViewStudentsForm : Form
    {
        private readonly string connectionString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=MyDatabase;Integrated Security=True;TrustServerCertificate=True";

        private int selectedEnrollmentId = -1;
        private int selectedStudentId = -1;

        public LecturerViewStudentsForm()
        {
            InitializeComponent();
        }

        private void LecturerViewStudentsForm_Load(object sender, EventArgs e)
        {
            SetupStudentGrid();
            LoadFilterOptions();
            LoadStudents("All", "All", "All");
        }

        private void SetupStudentGrid()
        {
            dgvStudentList.Columns.Clear();
            dgvStudentList.AutoGenerateColumns = false;

            // Hidden ID columns
            dgvStudentList.Columns.Add("colEnrollmentID", "EnrollmentID");
            dgvStudentList.Columns["colEnrollmentID"].Visible = false;

            dgvStudentList.Columns.Add("colStudentID", "StudentID");
            dgvStudentList.Columns["colStudentID"].Visible = false;

            // Visible columns
            dgvStudentList.Columns.Add("colTPNo", "TP No.");
            dgvStudentList.Columns.Add("colStudentName", "Name");
            dgvStudentList.Columns.Add("colEmail", "Email");
            dgvStudentList.Columns.Add("colPhone", "Phone");
            dgvStudentList.Columns.Add("colLevel", "Level");
            dgvStudentList.Columns.Add("colModule", "Module");
            dgvStudentList.Columns.Add("colMonth", "Month");
            dgvStudentList.Columns.Add("colEnrolType", "Enrol Type");
            dgvStudentList.Columns.Add("colStatus", "Status");

            dgvStudentList.ReadOnly = true;
            dgvStudentList.AllowUserToAddRows = false;
            dgvStudentList.AllowUserToDeleteRows = false;
            dgvStudentList.AllowUserToResizeRows = false;
            dgvStudentList.MultiSelect = false;
            dgvStudentList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudentList.RowHeadersVisible = false;
            dgvStudentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadFilterOptions()
        {
            LoadLevelOptions();
            LoadModuleOptions();
            LoadStatusOptions();
        }

        private void LoadLevelOptions()
        {
            cboLevel.Items.Clear();
            cboLevel.Items.Add("All");

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT DISTINCT StudyLevel
                    FROM Students
                    WHERE StudyLevel IS NOT NULL
                    ORDER BY StudyLevel";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cboLevel.Items.Add(dr["StudyLevel"].ToString());
                }

                dr.Close();
            }

            cboLevel.SelectedItem = "All";
        }

        private void LoadModuleOptions()
        {
            cboModule.Items.Clear();
            cboModule.Items.Add("All");

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT DISTINCT ModuleName
                    FROM ClassSchedule
                    WHERE ModuleName IS NOT NULL
                    ORDER BY ModuleName";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cboModule.Items.Add(dr["ModuleName"].ToString());
                }

                dr.Close();
            }

            cboModule.SelectedItem = "All";
        }

        private void LoadStatusOptions()
        {
            cboStatus.Items.Clear();
            cboStatus.Items.Add("All");
            cboStatus.Items.Add("Active");
            cboStatus.Items.Add("Completed");
            cboStatus.Items.Add("Pending");
            cboStatus.Items.Add("Cancelled");

            cboStatus.SelectedItem = "All";
        }

        private void LoadStudents(string levelFilter, string moduleFilter, string statusFilter)
        {
            dgvStudentList.Rows.Clear();
            selectedEnrollmentId = -1;
            selectedStudentId = -1;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT
                        se.EnrollmentID,
                        s.StudentID,
                        s.TPNumber,
                        u.[Name] AS StudentName,
                        u.Email,
                        s.ContactNumber AS Phone,
                        s.StudyLevel,
                        cs.ModuleName,
                        s.MonthOfEnrollment,
                        CASE
                            WHEN EXISTS
                            (
                                SELECT 1
                                FROM EnrollmentRequests er
                                WHERE er.StudentID = s.StudentID
                                  AND er.ClassScheduleID = se.ClassScheduleID
                                  AND er.RequestStatus = 'Approved'
                            )
                            THEN 'Self'
                            ELSE 'Lecturer'
                        END AS EnrolType,
                        se.EnrollmentStatus
                    FROM StudentEnrollments se
                    INNER JOIN Students s ON se.StudentID = s.StudentID
                    INNER JOIN Users u ON s.UserID = u.UserID
                    INNER JOIN ClassSchedule cs ON se.ClassScheduleID = cs.Id
                    WHERE (@Level = 'All' OR s.StudyLevel = @Level)
                      AND (@Module = 'All' OR cs.ModuleName = @Module)
                      AND (@Status = 'All' OR se.EnrollmentStatus = @Status)
                    ORDER BY u.[Name]";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Level", levelFilter);
                cmd.Parameters.AddWithValue("@Module", moduleFilter);
                cmd.Parameters.AddWithValue("@Status", statusFilter);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dgvStudentList.Rows.Add(
                        dr["EnrollmentID"].ToString(),
                        dr["StudentID"].ToString(),
                        dr["TPNumber"].ToString(),
                        dr["StudentName"].ToString(),
                        dr["Email"].ToString(),
                        dr["Phone"].ToString(),
                        dr["StudyLevel"].ToString(),
                        dr["ModuleName"].ToString(),
                        dr["MonthOfEnrollment"].ToString(),
                        dr["EnrolType"].ToString(),
                        dr["EnrollmentStatus"].ToString()
                    );
                }

                dr.Close();
            }

            UpdateLabels(levelFilter, moduleFilter, statusFilter);
        }

        private void UpdateLabels(string levelFilter, string moduleFilter, string statusFilter)
        {
            if (lblCount != null)
            {
                lblCount.Text = $"Showing {dgvStudentList.Rows.Count} students";
            }

            if (lblFormStatus != null)
            {
                lblFormStatus.Text =
                    $"Filtered: Level = {levelFilter}, Module = {moduleFilter}, Status = {statusFilter}";
            }
        }

        private void dgvStudentList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                object enrollmentValue = dgvStudentList.Rows[e.RowIndex].Cells["colEnrollmentID"].Value;
                object studentValue = dgvStudentList.Rows[e.RowIndex].Cells["colStudentID"].Value;

                selectedEnrollmentId = enrollmentValue != null ? Convert.ToInt32(enrollmentValue) : -1;
                selectedStudentId = studentValue != null ? Convert.ToInt32(studentValue) : -1;
            }
        }

        private string GetSelectedStatus()
        {
            if (dgvStudentList.CurrentRow == null)
                return string.Empty;

            object value = dgvStudentList.CurrentRow.Cells["colStatus"].Value;
            return value?.ToString() ?? string.Empty;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string level = cboLevel.SelectedItem?.ToString() ?? "All";
            string module = cboModule.SelectedItem?.ToString() ?? "All";
            string status = cboStatus.SelectedItem?.ToString() ?? "All";

            LoadStudents(level, module, status);
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            cboLevel.SelectedItem = "All";
            cboModule.SelectedItem = "All";
            cboStatus.SelectedItem = "All";

            LoadStudents("All", "All", "All");
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            if (selectedEnrollmentId == -1)
            {
                MessageBox.Show(
                    "Please select a student record first.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string currentStatus = GetSelectedStatus();

            if (!currentStatus.Equals("Completed", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "Only students with completed coaching classes can be deleted from this list.",
                    "Invalid Action",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete the selected completed enrollment record?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    // Delete payment history linked to invoices of this enrollment
                    string deletePaymentHistoryQuery = @"
                        DELETE ph
                        FROM PaymentHistory ph
                        INNER JOIN Invoices i ON ph.InvoiceID = i.InvoiceID
                        WHERE i.EnrollmentID = @EnrollmentID";

                    SqlCommand deletePaymentHistoryCmd =
                        new SqlCommand(deletePaymentHistoryQuery, con, transaction);
                    deletePaymentHistoryCmd.Parameters.AddWithValue("@EnrollmentID", selectedEnrollmentId);
                    deletePaymentHistoryCmd.ExecuteNonQuery();

                    // Delete invoices linked to this enrollment
                    string deleteInvoicesQuery = @"
                        DELETE FROM Invoices
                        WHERE EnrollmentID = @EnrollmentID";

                    SqlCommand deleteInvoicesCmd =
                        new SqlCommand(deleteInvoicesQuery, con, transaction);
                    deleteInvoicesCmd.Parameters.AddWithValue("@EnrollmentID", selectedEnrollmentId);
                    deleteInvoicesCmd.ExecuteNonQuery();

                    // Delete the enrollment record
                    string deleteEnrollmentQuery = @"
                        DELETE FROM StudentEnrollments
                        WHERE EnrollmentID = @EnrollmentID";

                    SqlCommand deleteEnrollmentCmd =
                        new SqlCommand(deleteEnrollmentQuery, con, transaction);
                    deleteEnrollmentCmd.Parameters.AddWithValue("@EnrollmentID", selectedEnrollmentId);
                    deleteEnrollmentCmd.ExecuteNonQuery();

                    transaction.Commit();

                    if (lblFormStatus != null)
                    {
                        lblFormStatus.Text = "Selected completed student record deleted successfully.";
                    }

                    selectedEnrollmentId = -1;
                    selectedStudentId = -1;

                    string level = cboLevel.SelectedItem?.ToString() ?? "All";
                    string module = cboModule.SelectedItem?.ToString() ?? "All";
                    string status = cboStatus.SelectedItem?.ToString() ?? "All";

                    LoadStudents(level, module, status);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    MessageBox.Show(
                        "Failed to delete selected record.\n\n" + ex.Message,
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}