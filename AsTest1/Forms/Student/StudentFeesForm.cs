using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using APUCC_Project.Services;
using APUCC_Project.UI;

namespace APUCC_Project.Forms.Student
{
    public partial class StudentFeesForm : Form
    {
        private static readonly Color PaidButtonColor = Color.FromArgb(52, 120, 246);
        private readonly int _studentId;

        public StudentFeesForm(int studentId)
        {
            InitializeComponent();
            _studentId = studentId;

            Load += StudentFeesForm_Load;
        }

        private void StudentFeesForm_Load(object? sender, EventArgs e)
        {
            SetupOutstandingGrid();
            SetupPaymentHistoryGrid();
            LoadOutstandingFees();
            LoadPaymentHistory();
        }

        private void SetupOutstandingGrid()
        {
            ConfigureGrid(dataGridView1);

            ModuleColumn.DataPropertyName = "Module";
            Column2.DataPropertyName = "Level";
            Column3.DataPropertyName = "Trainer";
            Column4.DataPropertyName = "Fee";
            Column5.DataPropertyName = "Status";

            ActionColumn.UseColumnTextForButtonValue = true;
            ActionColumn.Text = "Pay Now";
            ActionColumn.FlatStyle = FlatStyle.Flat;
            ActionColumn.DefaultCellStyle.BackColor = ThemePalette.DangerButton;
            ActionColumn.DefaultCellStyle.ForeColor = Color.White;
            ActionColumn.DefaultCellStyle.SelectionBackColor = ThemePalette.DangerButton;
            ActionColumn.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void SetupPaymentHistoryGrid()
        {
            ConfigureGrid(dataGridView2);

            InvoiceIDColumn.DataPropertyName = "InvoiceNo";
            ModuleColumn2.DataPropertyName = "Module";
            AmountColumn.DataPropertyName = "AmountPaid";
            dataGridViewTextBoxColumn4.DataPropertyName = "PaymentMethod";
            DatePaidColumn.DataPropertyName = "PaidDate";

            ReceiptColumn.UseColumnTextForButtonValue = true;
            ReceiptColumn.Text = "Paid";
            ReceiptColumn.FlatStyle = FlatStyle.Flat;
            ReceiptColumn.DefaultCellStyle.BackColor = PaidButtonColor;
            ReceiptColumn.DefaultCellStyle.ForeColor = Color.White;
            ReceiptColumn.DefaultCellStyle.SelectionBackColor = PaidButtonColor;
            ReceiptColumn.DefaultCellStyle.SelectionForeColor = Color.White;
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

            LoadGrid(query, dataGridView1);
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

            LoadGrid(query, dataGridView2);
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
            if (e.RowIndex < 0 || e.ColumnIndex != dataGridView1.Columns["ActionColumn"].Index)
            {
                return;
            }

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            int invoiceId = Convert.ToInt32(row.Cells["InvoiceIDHiddenColumn"].Value);
            string moduleName = row.Cells["ModuleColumn"].Value?.ToString() ?? "this course";

            DialogResult confirm = MessageBox.Show(
                $"Mark the fee for {moduleName} as paid?",
                "Confirm Payment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes)
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

                using (SqlCommand updateCmd = new SqlCommand(updateInvoiceQuery, conn, transaction))
                {
                    updateCmd.Parameters.AddWithValue("@InvoiceID", invoiceId);
                    updateCmd.ExecuteNonQuery();
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

                using (SqlCommand insertCmd = new SqlCommand(insertPaymentQuery, conn, transaction))
                {
                    insertCmd.Parameters.AddWithValue("@InvoiceID", invoiceId);
                    insertCmd.ExecuteNonQuery();
                }

                transaction.Commit();

                MessageBox.Show(
                    "Payment recorded successfully.",
                    "Fees",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadOutstandingFees();
                LoadPaymentHistory();
                dataGridView1.Refresh();
                dataGridView2.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to record payment: " + ex.Message);
            }
        }
    }
}
