    using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace APUCC_Project.Forms.Lecturer
{
    public partial class LecturerApproveRequestsForm : Form
    {
        private readonly string connectionString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=MyDatabase;Integrated Security=True;TrustServerCertificate=True";

        private int selectedRequestId = -1;
        private int selectedStudentId = -1;
        private int selectedClassScheduleId = -1;

        // Change this later when you have real login/session
        private int currentLecturerId = 1;

        public LecturerApproveRequestsForm()
        {
            InitializeComponent();
        }

        private void LecturerApproveRequestsForm_Load(object sender, EventArgs e)
        {
            SetupRequestsGrid();
            LoadFilterOptions();
            SetDetailFieldsReadOnly();
            ClearDetails();
            LoadRequests("Pending");
        }

        private void SetDetailFieldsReadOnly()
        {
            txtStudent.ReadOnly = true;
            txtTPNumber.ReadOnly = true;
            txtModule.ReadOnly = true;
            txtLevel.ReadOnly = true;
        }

        private void LoadFilterOptions()
        {
            cboShowRequests.Items.Clear();
            cboShowRequests.Items.Add("Pending");
            cboShowRequests.Items.Add("Approved");
            cboShowRequests.Items.Add("Rejected");
            cboShowRequests.Items.Add("All");
            cboShowRequests.SelectedItem = "Pending";
        }

        private void SetupRequestsGrid()
        {
            dgvRequests.Columns.Clear();
            dgvRequests.AutoGenerateColumns = false;

            dgvRequests.Columns.Add("colRequestID", "Req ID");
            dgvRequests.Columns.Add("colTPNo", "TP No.");
            dgvRequests.Columns.Add("colStudentName", "Student Name");
            dgvRequests.Columns.Add("colModuleRequested", "Module Requested");
            dgvRequests.Columns.Add("colClassLevel", "Class Level");
            dgvRequests.Columns.Add("colDateSent", "Date Sent");
            dgvRequests.Columns.Add("colStatus", "Status");

            dgvRequests.ReadOnly = true;
            dgvRequests.AllowUserToAddRows = false;
            dgvRequests.AllowUserToDeleteRows = false;
            dgvRequests.MultiSelect = false;
            dgvRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequests.RowHeadersVisible = false;
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadRequests(string filter)
        {
            dgvRequests.Rows.Clear();
            ClearDetails();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT
                        er.RequestID,
                        s.StudentID,
                        cs.Id AS ClassScheduleID,
                        s.TPNumber,
                        u.[Name] AS StudentName,
                        cs.ModuleName,
                        cs.[Level],
                        er.RequestDate,
                        er.RequestStatus
                    FROM EnrollmentRequests er
                    INNER JOIN Students s ON er.StudentID = s.StudentID
                    INNER JOIN Users u ON s.UserID = u.UserID
                    INNER JOIN ClassSchedule cs ON er.ClassScheduleID = cs.Id";

                if (filter == "Pending")
                    query += " WHERE er.RequestStatus = 'Pending'";
                else if (filter == "Approved")
                    query += " WHERE er.RequestStatus = 'Approved'";
                else if (filter == "Rejected")
                    query += " WHERE er.RequestStatus = 'Rejected'";

                query += " ORDER BY er.RequestID";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dgvRequests.Rows.Add(
                        dr["RequestID"].ToString(),
                        dr["TPNumber"].ToString(),
                        dr["StudentName"].ToString(),
                        dr["ModuleName"].ToString(),
                        dr["Level"].ToString(),
                        Convert.ToDateTime(dr["RequestDate"]).ToString("dd/MM/yyyy"),
                        dr["RequestStatus"].ToString()
                    );
                }
                dr.Close();
            }

            UpdateFooter();
        }

        private void LoadSelectedRequestDetails(int requestId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT
                        er.RequestID,
                        s.StudentID,
                        cs.Id AS ClassScheduleID,
                        u.[Name] AS StudentName,
                        s.TPNumber,
                        cs.ModuleName,
                        cs.[Level]
                    FROM EnrollmentRequests er
                    INNER JOIN Students s ON er.StudentID = s.StudentID
                    INNER JOIN Users u ON s.UserID = u.UserID
                    INNER JOIN ClassSchedule cs ON er.ClassScheduleID = cs.Id
                    WHERE er.RequestID = @RequestID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@RequestID", requestId);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    selectedRequestId = requestId;
                    selectedStudentId = Convert.ToInt32(dr["StudentID"]);
                    selectedClassScheduleId = Convert.ToInt32(dr["ClassScheduleID"]);

                    txtStudent.Text = dr["StudentName"].ToString();
                    txtTPNumber.Text = dr["TPNumber"].ToString();
                    txtModule.Text = dr["ModuleName"].ToString();
                    txtLevel.Text = dr["Level"].ToString();
                }

                dr.Close();
            }
        }

        private bool EnrollmentAlreadyExists()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT COUNT(*)
                    FROM StudentEnrollments
                    WHERE StudentID = @StudentID
                      AND ClassScheduleID = @ClassScheduleID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StudentID", selectedStudentId);
                cmd.Parameters.AddWithValue("@ClassScheduleID", selectedClassScheduleId);

                con.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        private void ApproveRequest()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    string updateRequestQuery = @"
                        UPDATE EnrollmentRequests
                        SET RequestStatus = 'Approved',
                            HandledByLecturerID = @LecturerID,
                            HandledDate = GETDATE()
                        WHERE RequestID = @RequestID";

                    SqlCommand updateCmd = new SqlCommand(updateRequestQuery, con, transaction);
                    updateCmd.Parameters.AddWithValue("@LecturerID", currentLecturerId);
                    updateCmd.Parameters.AddWithValue("@RequestID", selectedRequestId);
                    updateCmd.ExecuteNonQuery();

                    if (!EnrollmentAlreadyExistsInTransaction(con, transaction))
                    {
                        string insertEnrollmentQuery = @"
                            INSERT INTO StudentEnrollments
                            (
                                StudentID,
                                ClassScheduleID,
                                EnrolledDate,
                                EnrollmentStatus,
                                EnrolledByLecturerID
                            )
                            VALUES
                            (
                                @StudentID,
                                @ClassScheduleID,
                                GETDATE(),
                                'Active',
                                @LecturerID
                            )";

                        SqlCommand insertCmd = new SqlCommand(insertEnrollmentQuery, con, transaction);
                        insertCmd.Parameters.AddWithValue("@StudentID", selectedStudentId);
                        insertCmd.Parameters.AddWithValue("@ClassScheduleID", selectedClassScheduleId);
                        insertCmd.Parameters.AddWithValue("@LecturerID", currentLecturerId);
                        insertCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    lblStatus.Text = $"Request R{selectedRequestId:000} approved successfully";
                    LoadRequests(cboShowRequests.SelectedItem?.ToString() ?? "Pending");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show(
                        "Failed to approve request.\n\n" + ex.Message,
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private bool EnrollmentAlreadyExistsInTransaction(SqlConnection con, SqlTransaction transaction)
        {
            string query = @"
                SELECT COUNT(*)
                FROM StudentEnrollments
                WHERE StudentID = @StudentID
                  AND ClassScheduleID = @ClassScheduleID";

            SqlCommand cmd = new SqlCommand(query, con, transaction);
            cmd.Parameters.AddWithValue("@StudentID", selectedStudentId);
            cmd.Parameters.AddWithValue("@ClassScheduleID", selectedClassScheduleId);

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }

        private void RejectRequest()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                    UPDATE EnrollmentRequests
                    SET RequestStatus = 'Rejected',
                        HandledByLecturerID = @LecturerID,
                        HandledDate = GETDATE()
                    WHERE RequestID = @RequestID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@LecturerID", currentLecturerId);
                cmd.Parameters.AddWithValue("@RequestID", selectedRequestId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            lblStatus.Text = $"Request R{selectedRequestId:000} rejected successfully";
            LoadRequests(cboShowRequests.SelectedItem?.ToString() ?? "Pending");
        }

        private void ClearDetails()
        {
            selectedRequestId = -1;
            selectedStudentId = -1;
            selectedClassScheduleId = -1;

            txtStudent.Clear();
            txtTPNumber.Clear();
            txtModule.Clear();
            txtLevel.Clear();
        }

        private void UpdateFooter()
        {
            int total = dgvRequests.Rows.Count;
            int pendingCount = 0;

            foreach (DataGridViewRow row in dgvRequests.Rows)
            {
                if (row.Cells["colStatus"].Value != null &&
                    row.Cells["colStatus"].Value.ToString() == "Pending")
                {
                    pendingCount++;
                }
            }

            if (lblFormStatus != null)
            {
                lblFormStatus.Text = $"{total} requests — {pendingCount} pending | frmApproveRequests";
            }
        }

        private void dgvRequests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int requestId = Convert.ToInt32(
                    dgvRequests.Rows[e.RowIndex].Cells["colRequestID"].Value
                );

                LoadSelectedRequestDetails(requestId);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadRequests(cboShowRequests.SelectedItem?.ToString() ?? "Pending");
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (selectedRequestId == -1)
            {
                MessageBox.Show(
                    "Please select a request first.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string currentStatus = GetCurrentRequestStatus(selectedRequestId);

            if (currentStatus == "Approved")
            {
                MessageBox.Show(
                    "This request is already approved.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            if (currentStatus == "Rejected")
            {
                MessageBox.Show(
                    "Rejected requests cannot be approved directly.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            ApproveRequest();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (selectedRequestId == -1)
            {
                MessageBox.Show(
                    "Please select a request first.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string currentStatus = GetCurrentRequestStatus(selectedRequestId);

            if (currentStatus == "Rejected")
            {
                MessageBox.Show(
                    "This request is already rejected.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            if (currentStatus == "Approved")
            {
                MessageBox.Show(
                    "Approved requests cannot be rejected directly.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            RejectRequest();
        }

        private string GetCurrentRequestStatus(int requestId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT RequestStatus FROM EnrollmentRequests WHERE RequestID = @RequestID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@RequestID", requestId);

                con.Open();
                object result = cmd.ExecuteScalar();
                return result?.ToString() ?? "";
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearDetails();
            LoadRequests(cboShowRequests.SelectedItem?.ToString() ?? "Pending");
            lblStatus.Text = "Requests refreshed";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}