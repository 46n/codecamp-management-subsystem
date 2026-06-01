using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using APUCC_Project.Services;
using APUCC_Project.UI;

namespace APUCC_Project.Forms.Student
{
    public partial class StudentFeesForm : Form
    {
        private static readonly Color ActionButtonColor = Color.FromArgb(24, 78, 119);
        private static readonly Color PaidButtonColor = Color.FromArgb(52, 120, 246);
        private readonly int _studentId;

        public StudentFeesForm(int studentId)
        {
            InitializeComponent();
            _studentId = studentId;

            Load += StudentFeesForm_Load;
            dgvPaymentHistory.CellContentClick += dataGridView2_CellContentClick;
        }

        private void StudentFeesForm_Load(object? sender, EventArgs e)
        {
            SetupOutstandingGrid();
            SetupPaymentHistoryGrid();
            EnsureInvoicesForStudentEnrollments();
            LoadOutstandingFees();
            LoadPaymentHistory();
        }

        private void EnsureInvoicesForStudentEnrollments()
        {
            const string query = @"
                INSERT INTO Invoices (EnrollmentID, InvoiceDate, Amount, InvoiceStatus, DueDate)
                SELECT
                    se.EnrollmentID,
                    CAST(GETDATE() AS DATE),
                    cs.Charges,
                    CASE
                        WHEN se.EnrollmentStatus = 'Cancelled' THEN 'Cancelled'
                        ELSE 'Unpaid'
                    END,
                    DATEADD(DAY, 14, CAST(GETDATE() AS DATE))
                FROM StudentEnrollments se
                INNER JOIN ClassSchedule cs ON se.ClassScheduleID = cs.Id
                LEFT JOIN Invoices i ON i.EnrollmentID = se.EnrollmentID
                WHERE se.StudentID = @StudentID
                  AND se.EnrollmentStatus IN ('Active', 'Completed')
                  AND i.InvoiceID IS NULL;";

            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                using SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", _studentId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to prepare fee records: " + ex.Message, "Fees", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetupOutstandingGrid()
        {
            ConfigureGrid(dgvOutstandingFees);

            InvoiceIDHiddenColumn.DataPropertyName = "InvoiceID";
            ModuleColumn.DataPropertyName = "Module";
            Column2.DataPropertyName = "Level";
            Column3.DataPropertyName = "Trainer";
            Column4.DataPropertyName = "Fee";
            Column5.DataPropertyName = "Status";

            ActionColumn.UseColumnTextForButtonValue = true;
            ActionColumn.Text = "Pay Now";
            ActionColumn.FlatStyle = FlatStyle.Flat;
            ActionColumn.DefaultCellStyle.BackColor = ActionButtonColor;
            ActionColumn.DefaultCellStyle.ForeColor = Color.White;
            ActionColumn.DefaultCellStyle.SelectionBackColor = ActionButtonColor;
            ActionColumn.DefaultCellStyle.SelectionForeColor = Color.White;
            ActionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ActionColumn.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ActionColumn.Width = 170;
        }

        private void SetupPaymentHistoryGrid()
        {
            ConfigureGrid(dgvPaymentHistory);

            InvoiceIDColumn.DataPropertyName = "InvoiceNo";
            ModuleColumn2.DataPropertyName = "Module";
            AmountColumn.DataPropertyName = "AmountPaid";
            dataGridViewTextBoxColumn4.DataPropertyName = "PaymentMethod";
            DatePaidColumn.DataPropertyName = "PaidDate";

            ReceiptColumn.UseColumnTextForButtonValue = true;
            ReceiptColumn.HeaderText = "Status / Invoice";
            ReceiptColumn.Text = "Paid - View Invoice";
            ReceiptColumn.FlatStyle = FlatStyle.Flat;
            ReceiptColumn.DefaultCellStyle.BackColor = PaidButtonColor;
            ReceiptColumn.DefaultCellStyle.ForeColor = Color.White;
            ReceiptColumn.DefaultCellStyle.SelectionBackColor = PaidButtonColor;
            ReceiptColumn.DefaultCellStyle.SelectionForeColor = Color.White;
            ReceiptColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ReceiptColumn.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ReceiptColumn.Width = 200;
            ReceiptColumn.ToolTipText = "Click to see invoice";
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
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grid.ColumnHeadersDefaultCellStyle.BackColor = ThemePalette.SecondaryBackground;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = ThemePalette.PrimaryText;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grid.RowTemplate.Height = 34;
            grid.ClearSelection();
        }

        private void LoadOutstandingFees()
        {
            const string query = @"
                SELECT
                    InvoiceID,
                    Module,
                    [Level],
                    Trainer,
                    Fee,
                    [Status]
                FROM dbo.vw_StudentOutstandingFees
                WHERE StudentID = @StudentID
                ORDER BY SortDueDate, InvoiceID;";

            LoadGrid(query, dgvOutstandingFees);
        }

        private void LoadPaymentHistory()
        {
            const string query = @"
                SELECT
                    InvoiceNo,
                    Module,
                    AmountPaid,
                    PaymentMethod,
                    PaidDate
                FROM dbo.vw_StudentPaymentHistory
                WHERE StudentID = @StudentID
                ORDER BY SortPaymentDate DESC, PaymentHistoryID DESC;";

            LoadGrid(query, dgvPaymentHistory);
        }

        private void LoadGrid(string query, DataGridView grid)
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
                MessageBox.Show("Failed to load fees: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvOutstandingFees.Columns["ActionColumn"].Index)
            {
                return;
            }

            DataGridViewRow row = dgvOutstandingFees.Rows[e.RowIndex];
            int invoiceId = Convert.ToInt32(row.Cells["InvoiceIDHiddenColumn"].Value);
            string moduleName = row.Cells["ModuleColumn"].Value?.ToString() ?? "this course";

            bool shouldProceed = ActionConfirmationDialog.ShowConfirmation(
                this,
                "Confirm Payment",
                $"Proceed with the payment for {moduleName}? Once completed, the fee will move to Payment History immediately.",
                "Proceed",
                "Cancel");

            if (!shouldProceed)
            {
                return;
            }

            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();
                using SqlTransaction transaction = conn.BeginTransaction();

                const string updateInvoiceQuery = @"
                    UPDATE Invoices
                    SET InvoiceStatus = 'Paid',
                        InvoiceDate = CAST(GETDATE() AS DATE)
                    WHERE InvoiceID = @InvoiceID;";

                int updatedInvoices;
                using (SqlCommand updateCmd = new SqlCommand(updateInvoiceQuery, conn, transaction))
                {
                    updateCmd.Parameters.AddWithValue("@InvoiceID", invoiceId);
                    updatedInvoices = updateCmd.ExecuteNonQuery();
                }

                if (updatedInvoices == 0)
                {
                    transaction.Rollback();
                    MessageBox.Show(
                        "The selected fee could not be updated. Please reload the page and try again.",
                        "Fees",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    LoadOutstandingFees();
                    LoadPaymentHistory();
                    return;
                }

                const string insertPaymentQuery = @"
                    INSERT INTO PaymentHistory
                    (
                        InvoiceID,
                        AmountPaid,
                        PaymentDate,
                        PaymentMethod,
                        ReceiptNo,
                        PaymentStatus
                    )
                    SELECT
                        i.InvoiceID,
                        i.Amount,
                        CAST(GETDATE() AS DATE),
                        'Online Banking',
                        CONCAT('RCPT-', i.InvoiceID, '-', CONVERT(VARCHAR(8), GETDATE(), 112)),
                        'Paid'
                    FROM Invoices i
                    WHERE i.InvoiceID = @InvoiceID
                      AND NOT EXISTS
                      (
                          SELECT 1
                          FROM PaymentHistory ph
                          WHERE ph.InvoiceID = i.InvoiceID
                            AND ph.PaymentStatus = 'Paid'
                      );";

                int insertedPayments;
                using (SqlCommand insertCmd = new SqlCommand(insertPaymentQuery, conn, transaction))
                {
                    insertCmd.Parameters.AddWithValue("@InvoiceID", invoiceId);
                    insertedPayments = insertCmd.ExecuteNonQuery();
                }

                if (insertedPayments == 0)
                {
                    transaction.Rollback();
                    MessageBox.Show(
                        "The payment could not be recorded for the selected fee. Please try again.",
                        "Fees",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    LoadOutstandingFees();
                    LoadPaymentHistory();
                    return;
                }

                transaction.Commit();

                LoadOutstandingFees();
                LoadPaymentHistory();
                dgvOutstandingFees.Refresh();
                dgvPaymentHistory.Refresh();

                MessageBox.Show(
                    "Payment recorded successfully. The fee has been moved to Payment History.",
                    "Fees",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to record payment: " + ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvPaymentHistory.Columns["ReceiptColumn"].Index)
            {
                return;
            }

            string invoiceNo = dgvPaymentHistory.Rows[e.RowIndex].Cells["InvoiceIDColumn"].Value?.ToString() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(invoiceNo))
            {
                MessageBox.Show("Invoice information is not available for this payment.", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                InvoicePrintData invoice = GetInvoicePreviewData(invoiceNo);
                InvoicePreviewDialog.ShowInvoice(this, invoice);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load invoice: " + ex.Message, "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private InvoicePrintData GetInvoicePreviewData(string invoiceNo)
        {
            const string query = @"
                SELECT TOP 1
                    CONCAT('INV-', i.InvoiceID) AS InvoiceNo,
                    cs.ModuleName AS Module,
                    cs.[Level] AS CourseLevel,
                    ISNULL(tu.[Name], 'TBA') AS Trainer,
                    CAST(i.Amount AS DECIMAL(10,2)) AS InvoiceAmount,
                    CAST(ph.AmountPaid AS DECIMAL(10,2)) AS AmountPaid,
                    ISNULL(ph.PaymentMethod, 'Online Banking') AS PaymentMethod,
                    CONVERT(VARCHAR(10), ph.PaymentDate, 23) AS PaidDate,
                    ISNULL(ph.ReceiptNo, 'N/A') AS ReceiptNo,
                    i.InvoiceStatus AS InvoiceStatus,
                    ph.PaymentStatus AS PaymentStatus,
                    CONVERT(VARCHAR(10), i.DueDate, 23) AS DueDate
                FROM PaymentHistory ph
                INNER JOIN Invoices i ON ph.InvoiceID = i.InvoiceID
                INNER JOIN StudentEnrollments se ON i.EnrollmentID = se.EnrollmentID
                INNER JOIN ClassSchedule cs ON se.ClassScheduleID = cs.Id
                LEFT JOIN Trainers t ON cs.TrainerID = t.TrainerID
                LEFT JOIN Users tu ON t.UserID = tu.UserID
                WHERE se.StudentID = @StudentID
                  AND CONCAT('INV-', i.InvoiceID) = @InvoiceNo
                ORDER BY ph.PaymentDate DESC, ph.PaymentHistoryID DESC;";

            using SqlConnection conn = DatabaseHelper.GetConnection();
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@StudentID", _studentId);
            cmd.Parameters.AddWithValue("@InvoiceNo", invoiceNo);

            conn.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                throw new InvalidOperationException("Invoice details could not be found for the selected payment.");
            }

            return new InvoicePrintData
            {
                InvoiceNo = ReadString(reader, "InvoiceNo"),
                Module = ReadString(reader, "Module"),
                Level = ReadString(reader, "CourseLevel"),
                Trainer = ReadString(reader, "Trainer"),
                InvoiceAmount = Convert.ToDecimal(reader["InvoiceAmount"]),
                AmountPaid = Convert.ToDecimal(reader["AmountPaid"]),
                PaymentMethod = ReadString(reader, "PaymentMethod"),
                PaidDate = ReadString(reader, "PaidDate"),
                ReceiptNo = ReadString(reader, "ReceiptNo"),
                InvoiceStatus = ReadString(reader, "InvoiceStatus"),
                PaymentStatus = ReadString(reader, "PaymentStatus"),
                DueDate = ReadString(reader, "DueDate", "Not set")
            };
        }

        private static string ReadString(SqlDataReader reader, string columnName, string fallback = "N/A")
        {
            object value = reader[columnName];
            return value == DBNull.Value ? fallback : value.ToString() ?? fallback;
        }
    }
}
