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
            Resize += LecturerViewStudentsForm_Resize;
        }

        private void LecturerViewStudentsForm_Load(object sender, EventArgs e)
        {
            SetupStudentGrid();
            LoadFilterOptions();
            LoadStudents("All", "All", "All");
            AdjustLayout();
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
            dgvStudentList.ScrollBars = ScrollBars.Vertical;
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
                        MIN(se.EnrollmentID) AS EnrollmentID,
                        s.StudentID,
                        s.TPNumber,
                        u.[Name] AS StudentName,
                        u.Email,
                        s.ContactNumber AS Phone,
                        s.StudyLevel AS StudyLevel,
                        MAX(s.MonthOfEnrollment) AS MonthOfEnrollment,
                        CASE
                            WHEN MAX(CASE WHEN approvedRequests.StudentID IS NOT NULL THEN 1 ELSE 0 END) = 1
                            THEN 'Self'
                            ELSE 'Lecturer'
                        END AS EnrolType,
                        CASE
                            WHEN SUM(CASE WHEN se.EnrollmentStatus = 'Active' THEN 1 ELSE 0 END) > 0 THEN 'Active'
                            WHEN SUM(CASE WHEN se.EnrollmentStatus = 'Pending' THEN 1 ELSE 0 END) > 0 THEN 'Pending'
                            WHEN SUM(CASE WHEN se.EnrollmentStatus = 'Completed' THEN 1 ELSE 0 END) > 0 THEN 'Completed'
                            WHEN SUM(CASE WHEN se.EnrollmentStatus = 'Cancelled' THEN 1 ELSE 0 END) > 0 THEN 'Cancelled'
                            ELSE MAX(se.EnrollmentStatus)
                        END AS EnrollmentStatus
                    FROM StudentEnrollments se
                    INNER JOIN Students s ON se.StudentID = s.StudentID
                    INNER JOIN Users u ON s.UserID = u.UserID
                    INNER JOIN ClassSchedule cs ON se.ClassScheduleID = cs.Id
                    LEFT JOIN
                    (
                        SELECT DISTINCT StudentID, ClassScheduleID
                        FROM EnrollmentRequests
                        WHERE RequestStatus = 'Approved'
                    ) approvedRequests
                        ON approvedRequests.StudentID = se.StudentID
                       AND approvedRequests.ClassScheduleID = se.ClassScheduleID
                    WHERE (@Level = 'All' OR s.StudyLevel = @Level)
                      AND (@Status = 'All' OR se.EnrollmentStatus = @Status)
                      AND
                      (
                          @Module = 'All'
                          OR EXISTS
                          (
                              SELECT 1
                              FROM StudentEnrollments seFilter
                              INNER JOIN ClassSchedule csFilter ON seFilter.ClassScheduleID = csFilter.Id
                              WHERE seFilter.StudentID = s.StudentID
                                AND csFilter.ModuleName = @Module
                          )
                      )
                    GROUP BY
                        s.StudentID,
                        s.TPNumber,
                        u.[Name],
                        u.Email,
                        s.ContactNumber,
                        s.StudyLevel
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
            if (lblFormStatus != null)
            {
                lblFormStatus.Text =
                    $"Showing {dgvStudentList.Rows.Count} students | Filtered: Level = {levelFilter}, Module = {moduleFilter}, Status = {statusFilter}";
            }
        }

        private void LecturerViewStudentsForm_Resize(object? sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void AdjustLayout()
        {
            const int sideMargin = 37;
            const int actionTop = 650;
            int availableWidth = Math.Max(980, ClientSize.Width - (sideMargin * 2));

            VeiwStudentpnl.Width = ClientSize.Width + 14;
            grpFilter.Width = availableWidth;
            dgvStudentList.Width = availableWidth;
            lblFormStatus.MaximumSize = new System.Drawing.Size(availableWidth, 0);
            lblFormStatus.Width = availableWidth;

            LayoutFilterControls();

            btnDeleteSelected.Top = actionTop;
            btnClose.Top = actionTop;
        }

        private void LayoutFilterControls()
        {
            const int top = 37;
            const int labelTop = 46;
            const int leftPadding = 18;
            const int rightPadding = 18;
            const int labelSpacing = 8;
            const int groupSpacing = 18;
            const int buttonSpacing = 12;
            const int defaultComboWidth = 155;
            const int minimumComboWidth = 120;
            const int filterButtonWidth = 125;
            const int showAllButtonWidth = 165;

            const int levelLabelWidth = 91;
            const int statusLabelWidth = 101;
            const int moduleLabelWidth = 122;

            int availableWidth = grpFilter.ClientSize.Width - leftPadding - rightPadding;
            int totalStaticWidth =
                levelLabelWidth + statusLabelWidth + moduleLabelWidth +
                filterButtonWidth + showAllButtonWidth +
                (labelSpacing * 3) +
                (groupSpacing * 4) +
                buttonSpacing;

            int comboWidth = Math.Min(
                defaultComboWidth,
                Math.Max(minimumComboWidth, (availableWidth - totalStaticWidth) / 3));

            int contentWidth =
                levelLabelWidth + comboWidth +
                statusLabelWidth + comboWidth +
                moduleLabelWidth + comboWidth +
                filterButtonWidth + showAllButtonWidth +
                (labelSpacing * 3) +
                (groupSpacing * 4) +
                buttonSpacing;

            int startX = Math.Max(leftPadding, (grpFilter.ClientSize.Width - contentWidth) / 2);
            int x = startX;

            cboLevel.Width = comboWidth;
            cboStatus.Width = comboWidth;
            cboModule.Width = comboWidth;

            lblLevel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            cboLevel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            cboStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lblModule.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            cboModule.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnShowAll.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            lblLevel.Location = new System.Drawing.Point(x, labelTop);
            x += levelLabelWidth + labelSpacing;
            cboLevel.Location = new System.Drawing.Point(x, top);
            x += comboWidth + groupSpacing;

            lblStatus.Location = new System.Drawing.Point(x, labelTop);
            x += statusLabelWidth + labelSpacing;
            cboStatus.Location = new System.Drawing.Point(x, top);
            x += comboWidth + groupSpacing;

            lblModule.Location = new System.Drawing.Point(x, labelTop);
            x += moduleLabelWidth + labelSpacing;
            cboModule.Location = new System.Drawing.Point(x, top);
            x += comboWidth + groupSpacing;

            btnFilter.Location = new System.Drawing.Point(x, top);
            x += filterButtonWidth + buttonSpacing;
            btnShowAll.Location = new System.Drawing.Point(x, top);
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
