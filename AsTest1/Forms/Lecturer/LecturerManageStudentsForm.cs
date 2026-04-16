using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace APUCC_Project.Forms.Lecturer
{
    public partial class LecturerManageStudentsForm : Form
    {
        private readonly string connectionString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=MyDatabase;Integrated Security=True;TrustServerCertificate=True";

        private int selectedStudentId = -1;
        private int selectedUserId = -1;

        // Change this later when you connect real login/session
        private int currentLecturerId = 1;

        public LecturerManageStudentsForm()
        {
            InitializeComponent();
        }

        private void LecturerManageStudentsForm_Load(object sender, EventArgs e)
        {


            SetupComboBoxes();
            SetupStudentsGrid();
            LoadLevelOptions();
            LoadModuleOptions();
            LoadMonthOptions();
            ClearInputs();
            LoadStudents("All", "All");
        }

        private void SetupComboBoxes()
        {
            cboFilterLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilterModule.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cboModule.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMonth.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void SetupStudentsGrid()
        {
            dgvStudents.Columns.Clear();
            dgvStudents.AutoGenerateColumns = false;

            // Hidden IDs
            DataGridViewTextBoxColumn colStudentID = new DataGridViewTextBoxColumn();
            colStudentID.Name = "colStudentID";
            colStudentID.HeaderText = "StudentID";
            colStudentID.Visible = false;
            dgvStudents.Columns.Add(colStudentID);

            DataGridViewTextBoxColumn colUserID = new DataGridViewTextBoxColumn();
            colUserID.Name = "colUserID";
            colUserID.HeaderText = "UserID";
            colUserID.Visible = false;
            dgvStudents.Columns.Add(colUserID);

            // Visible columns
            dgvStudents.Columns.Add("colTPNo", "TP No.");
            dgvStudents.Columns.Add("colStudentName", "Name");
            dgvStudents.Columns.Add("colLevel", "Level");
            dgvStudents.Columns.Add("colModule", "Module");
            dgvStudents.Columns.Add("colStatus", "Status");

            dgvStudents.ReadOnly = true;
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;
            dgvStudents.MultiSelect = false;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadLevelOptions()
        {
            cboFilterLevel.Items.Clear();
            cboFilterLevel.Items.Add("All");
            cboFilterLevel.Items.Add("Foundation");
            cboFilterLevel.Items.Add("Level 1");
            cboFilterLevel.Items.Add("Level 2");
            cboFilterLevel.Items.Add("Level 3");
            cboFilterLevel.SelectedItem = "All";

            cboLevel.Items.Clear();
            cboLevel.Items.Add("Foundation");
            cboLevel.Items.Add("Level 1");
            cboLevel.Items.Add("Level 2");
            cboLevel.Items.Add("Level 3");
            cboLevel.SelectedIndex = 0;
        }

        private void LoadModuleOptions()
        {
            cboFilterModule.Items.Clear();
            cboFilterModule.Items.Add("All");

            cboModule.Items.Clear();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT DISTINCT ModuleName FROM ClassSchedule ORDER BY ModuleName";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string moduleName = dr["ModuleName"].ToString() ?? "";

                    if (!string.IsNullOrWhiteSpace(moduleName))
                    {
                        cboFilterModule.Items.Add(moduleName);
                        cboModule.Items.Add(moduleName);
                    }
                }

                dr.Close();
            }

            cboFilterModule.SelectedItem = "All";

            if (cboModule.Items.Count > 0)
                cboModule.SelectedIndex = 0;
        }

        private void LoadMonthOptions()
        {
            cboMonth.Items.Clear();

            cboMonth.Items.Add("January 2026");
            cboMonth.Items.Add("February 2026");
            cboMonth.Items.Add("March 2026");
            cboMonth.Items.Add("April 2026");
            cboMonth.Items.Add("May 2026");
            cboMonth.Items.Add("June 2026");
            cboMonth.Items.Add("July 2026");
            cboMonth.Items.Add("August 2026");
            cboMonth.Items.Add("September 2026");
            cboMonth.Items.Add("October 2026");
            cboMonth.Items.Add("November 2026");
            cboMonth.Items.Add("December 2026");

            if (cboMonth.Items.Count > 0)
                cboMonth.SelectedIndex = 0;
        }

        private void LoadStudents(string levelFilter, string moduleFilter)
        {
            dgvStudents.Rows.Clear();
            selectedStudentId = -1;
            selectedUserId = -1;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT
                        s.StudentID,
                        u.UserID,
                        s.TPNumber,
                        u.[Name] AS StudentName,
                        s.StudyLevel,
                        ISNULL(cs.ModuleName, '') AS ModuleName,
                        s.StudentStatus
                    FROM Students s
                    INNER JOIN Users u ON s.UserID = u.UserID
                    OUTER APPLY
                    (
                        SELECT TOP 1 cs.ModuleName
                        FROM StudentEnrollments se
                        INNER JOIN ClassSchedule cs ON se.ClassScheduleID = cs.Id
                        WHERE se.StudentID = s.StudentID
                        ORDER BY se.EnrollmentID DESC
                    ) cs
                    WHERE (@Level = 'All' OR s.StudyLevel = @Level)
                      AND (@Module = 'All' OR ISNULL(cs.ModuleName, '') = @Module)
                    ORDER BY u.[Name]";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Level", levelFilter);
                cmd.Parameters.AddWithValue("@Module", moduleFilter);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dgvStudents.Rows.Add(
                        dr["StudentID"].ToString(),
                        dr["UserID"].ToString(),
                        dr["TPNumber"].ToString(),
                        dr["StudentName"].ToString(),
                        dr["StudyLevel"].ToString(),
                        dr["ModuleName"].ToString(),
                        dr["StudentStatus"].ToString()
                    );
                }

                dr.Close();
            }

            UpdateFooter();
        }

        private void LoadStudentDetails(int studentId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT TOP 1
                        s.StudentID,
                        u.UserID,
                        s.TPNumber,
                        u.[Name],
                        u.Email,
                        u.Phone,
                        u.[Address],
                        s.StudyLevel,
                        s.MonthOfEnrollment,
                        u.Username,
                        u.[Password],
                        ISNULL(cs.ModuleName, '') AS ModuleName
                    FROM Students s
                    INNER JOIN Users u ON s.UserID = u.UserID
                    LEFT JOIN StudentEnrollments se ON s.StudentID = se.StudentID
                    LEFT JOIN ClassSchedule cs ON se.ClassScheduleID = cs.Id
                    WHERE s.StudentID = @StudentID
                    ORDER BY se.EnrollmentID DESC";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StudentID", studentId);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    selectedStudentId = Convert.ToInt32(dr["StudentID"]);
                    selectedUserId = Convert.ToInt32(dr["UserID"]);

                    txtTPNumber.Text = dr["TPNumber"].ToString() ?? "";
                    txtFullName.Text = dr["Name"].ToString() ?? "";
                    txtEmail.Text = dr["Email"].ToString() ?? "";
                    txtPhone.Text = dr["Phone"].ToString() ?? "";
                    txtAddress.Text = dr["Address"].ToString() ?? "";
                    txtUsername.Text = dr["Username"].ToString() ?? "";
                    txtPassword.Text = dr["Password"].ToString() ?? "";

                    SetComboBoxValue(cboLevel, dr["StudyLevel"].ToString());
                    SetComboBoxValue(cboModule, dr["ModuleName"].ToString());
                    SetComboBoxValue(cboMonth, dr["MonthOfEnrollment"].ToString());
                }

                dr.Close();
            }
        }

        private void SetComboBoxValue(ComboBox comboBox, string? value)
        {
            if (!string.IsNullOrWhiteSpace(value) && comboBox.Items.Contains(value))
                comboBox.SelectedItem = value;
        }

        private bool ValidateInputs()
        {
            lblError.Text = "";
            lblStatus.Text = "";

            if (string.IsNullOrWhiteSpace(txtTPNumber.Text))
            {
                lblError.Text = "TP Number is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                lblError.Text = "Full Name is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                lblError.Text = "Email is required.";
                return false;
            }

            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                lblError.Text = "Please enter a valid email address.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                lblError.Text = "Phone is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboLevel.Text))
            {
                lblError.Text = "Please select a level.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboModule.Text))
            {
                lblError.Text = "Please select a module.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboMonth.Text))
            {
                lblError.Text = "Please select a month.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                lblError.Text = "Username is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblError.Text = "Password is required.";
                return false;
            }

            return true;
        }

        private bool UsernameExists(string username)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", username);

                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private bool TPNumberExists(string tpNumber)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Students WHERE TPNumber = @TPNumber";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TPNumber", tpNumber);

                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private bool EmailExists(string email)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", email);

                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private int GetClassScheduleIdByModule(string moduleName, SqlConnection con, SqlTransaction transaction)
        {
            string query = @"
                SELECT TOP 1 Id
                FROM ClassSchedule
                WHERE ModuleName = @ModuleName
                ORDER BY ClassDate, ClassTime";

            SqlCommand cmd = new SqlCommand(query, con, transaction);
            cmd.Parameters.AddWithValue("@ModuleName", moduleName);

            object result = cmd.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : -1;
        }

        private decimal GetClassCharges(int classScheduleId, SqlConnection con, SqlTransaction transaction)
        {
            string query = "SELECT Charges FROM ClassSchedule WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(query, con, transaction);
            cmd.Parameters.AddWithValue("@Id", classScheduleId);

            object result = cmd.ExecuteScalar();
            return result != null ? Convert.ToDecimal(result) : 0m;
        }

        private void RegisterStudent()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    // 1. Insert user
                    string insertUserQuery = @"
                        INSERT INTO Users
                        (Username, [Password], [Role], [Name], Email, Phone, [Address])
                        VALUES
                        (@Username, @Password, 'Student', @Name, @Email, @Phone, @Address);
                        SELECT SCOPE_IDENTITY();";

                    SqlCommand userCmd = new SqlCommand(insertUserQuery, con, transaction);
                    userCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    userCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    userCmd.Parameters.AddWithValue("@Name", txtFullName.Text.Trim());
                    userCmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    userCmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                    userCmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());

                    int userId = Convert.ToInt32(userCmd.ExecuteScalar());

                    // 2. Insert student
                    string insertStudentQuery = @"
                        INSERT INTO Students
                        (UserID, TPNumber, StudyLevel, ContactNumber, StudentAddress, MonthOfEnrollment, StudentStatus)
                        VALUES
                        (@UserID, @TPNumber, @StudyLevel, @ContactNumber, @StudentAddress, @MonthOfEnrollment, 'Active');
                        SELECT SCOPE_IDENTITY();";

                    SqlCommand studentCmd = new SqlCommand(insertStudentQuery, con, transaction);
                    studentCmd.Parameters.AddWithValue("@UserID", userId);
                    studentCmd.Parameters.AddWithValue("@TPNumber", txtTPNumber.Text.Trim());
                    studentCmd.Parameters.AddWithValue("@StudyLevel", cboLevel.Text);
                    studentCmd.Parameters.AddWithValue("@ContactNumber", txtPhone.Text.Trim());
                    studentCmd.Parameters.AddWithValue("@StudentAddress", txtAddress.Text.Trim());
                    studentCmd.Parameters.AddWithValue("@MonthOfEnrollment", cboMonth.Text);

                    int studentId = Convert.ToInt32(studentCmd.ExecuteScalar());

                    // 3. Auto-enroll to selected module if schedule exists
                    int classScheduleId = GetClassScheduleIdByModule(cboModule.Text, con, transaction);

                    if (classScheduleId != -1)
                    {
                        string insertEnrollmentQuery = @"
                            INSERT INTO StudentEnrollments
                            (StudentID, ClassScheduleID, EnrolledDate, EnrollmentStatus, EnrolledByLecturerID)
                            VALUES
                            (@StudentID, @ClassScheduleID, GETDATE(), 'Active', @LecturerID);
                            SELECT SCOPE_IDENTITY();";

                        SqlCommand enrollCmd = new SqlCommand(insertEnrollmentQuery, con, transaction);
                        enrollCmd.Parameters.AddWithValue("@StudentID", studentId);
                        enrollCmd.Parameters.AddWithValue("@ClassScheduleID", classScheduleId);
                        enrollCmd.Parameters.AddWithValue("@LecturerID", currentLecturerId);

                        int enrollmentId = Convert.ToInt32(enrollCmd.ExecuteScalar());

                        // 4. Create invoice
                        decimal amount = GetClassCharges(classScheduleId, con, transaction);

                        string insertInvoiceQuery = @"
                            INSERT INTO Invoices
                            (EnrollmentID, InvoiceDate, Amount, InvoiceStatus, DueDate)
                            VALUES
                            (@EnrollmentID, GETDATE(), @Amount, 'Unpaid', DATEADD(DAY, 7, GETDATE()));";

                        SqlCommand invoiceCmd = new SqlCommand(insertInvoiceQuery, con, transaction);
                        invoiceCmd.Parameters.AddWithValue("@EnrollmentID", enrollmentId);
                        invoiceCmd.Parameters.AddWithValue("@Amount", amount);
                        invoiceCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    lblStatus.Text = "Student registered successfully";
                    lblError.Text = "";

                    ClearInputs();
                    LoadStudents(
                        cboFilterLevel.SelectedItem?.ToString() ?? "All",
                        cboFilterModule.SelectedItem?.ToString() ?? "All"
                    );
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    MessageBox.Show(
                        "Failed to register student.\n\n" + ex.Message,
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }



        private void DeleteSelectedStudent()
        {
            if (selectedStudentId == -1 || selectedUserId == -1)
            {
                MessageBox.Show(
                    "Please select a student first.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete the selected student?",
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
                    string deletePaymentHistoryQuery = @"
                        DELETE ph
                        FROM PaymentHistory ph
                        INNER JOIN Invoices i ON ph.InvoiceID = i.InvoiceID
                        INNER JOIN StudentEnrollments se ON i.EnrollmentID = se.EnrollmentID
                        WHERE se.StudentID = @StudentID";

                    SqlCommand cmd1 = new SqlCommand(deletePaymentHistoryQuery, con, transaction);
                    cmd1.Parameters.AddWithValue("@StudentID", selectedStudentId);
                    cmd1.ExecuteNonQuery();

                    string deleteInvoicesQuery = @"
                        DELETE i
                        FROM Invoices i
                        INNER JOIN StudentEnrollments se ON i.EnrollmentID = se.EnrollmentID
                        WHERE se.StudentID = @StudentID";

                    SqlCommand cmd2 = new SqlCommand(deleteInvoicesQuery, con, transaction);
                    cmd2.Parameters.AddWithValue("@StudentID", selectedStudentId);
                    cmd2.ExecuteNonQuery();

                    string deleteLegacyPaymentsQuery = @"
                        DELETE FROM StudentPayments
                        WHERE StudentName = @StudentName";

                    SqlCommand cmdLegacy = new SqlCommand(deleteLegacyPaymentsQuery, con, transaction);
                    cmdLegacy.Parameters.AddWithValue("@StudentName", txtFullName.Text.Trim());
                    cmdLegacy.ExecuteNonQuery();

                    string deleteEnrollmentsQuery = @"
                        DELETE FROM StudentEnrollments
                        WHERE StudentID = @StudentID";

                    SqlCommand cmd3 = new SqlCommand(deleteEnrollmentsQuery, con, transaction);
                    cmd3.Parameters.AddWithValue("@StudentID", selectedStudentId);
                    cmd3.ExecuteNonQuery();

                    string deleteRequestsQuery = @"
                        DELETE FROM EnrollmentRequests
                        WHERE StudentID = @StudentID";

                    SqlCommand cmd4 = new SqlCommand(deleteRequestsQuery, con, transaction);
                    cmd4.Parameters.AddWithValue("@StudentID", selectedStudentId);
                    cmd4.ExecuteNonQuery();

                    string deleteStudentQuery = @"
                        DELETE FROM Students
                        WHERE StudentID = @StudentID";

                    SqlCommand cmd5 = new SqlCommand(deleteStudentQuery, con, transaction);
                    cmd5.Parameters.AddWithValue("@StudentID", selectedStudentId);
                    cmd5.ExecuteNonQuery();

                    string deleteUserQuery = @"
                        DELETE FROM Users
                        WHERE UserID = @UserID";

                    SqlCommand cmd6 = new SqlCommand(deleteUserQuery, con, transaction);
                    cmd6.Parameters.AddWithValue("@UserID", selectedUserId);
                    cmd6.ExecuteNonQuery();

                    transaction.Commit();

                    lblStatus.Text = "Student deleted successfully";
                    lblError.Text = "";

                    ClearInputs();
                    LoadStudents(
                        cboFilterLevel.SelectedItem?.ToString() ?? "All",
                        cboFilterModule.SelectedItem?.ToString() ?? "All"
                    );
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    MessageBox.Show(
                        "Failed to delete student.\n\n" + ex.Message,
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void ClearInputs()
        {
            selectedStudentId = -1;
            selectedUserId = -1;

            txtTPNumber.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtUsername.Clear();
            txtPassword.Clear();

            if (cboLevel.Items.Count > 0)
                cboLevel.SelectedIndex = 0;

            if (cboModule.Items.Count > 0)
                cboModule.SelectedIndex = 0;

            if (cboMonth.Items.Count > 0)
                cboMonth.SelectedIndex = 0;

            lblError.Text = "";
            dgvStudents.ClearSelection();
            UpdateFooter();
        }

        private void UpdateFooter()
        {
            if (lblFormStatus != null)
            {
                lblFormStatus.Text = $"{dgvStudents.Rows.Count} students loaded | frmManageStudents";
            }
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedStudentId = Convert.ToInt32(
                    dgvStudents.Rows[e.RowIndex].Cells["colStudentID"].Value
                );

                selectedUserId = Convert.ToInt32(
                    dgvStudents.Rows[e.RowIndex].Cells["colUserID"].Value
                );

                LoadStudentDetails(selectedStudentId);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadStudents(
                cboFilterLevel.SelectedItem?.ToString() ?? "All",
                cboFilterModule.SelectedItem?.ToString() ?? "All"
            );
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            cboFilterLevel.SelectedItem = "All";
            cboFilterModule.SelectedItem = "All";
            LoadStudents("All", "All");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            if (UsernameExists(txtUsername.Text.Trim()))
            {
                lblError.Text = "Username already exists.";
                return;
            }

            if (TPNumberExists(txtTPNumber.Text.Trim()))
            {
                lblError.Text = "TP Number already exists.";
                return;
            }

            if (EmailExists(txtEmail.Text.Trim()))
            {
                lblError.Text = "Email already exists.";
                return;
            }

            RegisterStudent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            DeleteSelectedStudent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}