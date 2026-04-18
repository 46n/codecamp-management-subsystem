using System;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace APUCC_Project.Forms.Admin
{
    public partial class AdminMonthlyIncome : Form
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        private readonly PrintDocument printDocument = new PrintDocument();
        private readonly string[] printHeaders = { "Trainer", "Module", "Level", "Students Paid", "Fee/Student", "Total" };
        private DataTable reportTable = new DataTable();
        private int printRowIndex = 0;

        public AdminMonthlyIncome()
        {
            InitializeComponent();

            this.Load += AdminMonthlyIncome_Load;
            btnGenerate.Click += btnGenerate_Click;
            btnPrint.Click += btnPrint_Click;
            btnClose.Click += btnClose_Click;

            printDocument.BeginPrint += printDocument_BeginPrint;
            printDocument.PrintPage += printDocument_PrintPage;
        }

        private void AdminMonthlyIncome_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadMonths();
            LoadTrainers();
            ResetSummary();
        }

        private void SetupGrid()
        {
            dgvReport.ReadOnly = true;
            dgvReport.AllowUserToAddRows = false;
            dgvReport.AllowUserToDeleteRows = false;
            dgvReport.AllowUserToResizeRows = false;
            dgvReport.AllowUserToResizeColumns = false;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReport.MultiSelect = false;
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvReport.RowHeadersVisible = false;
            dgvReport.RowTemplate.Height = 34;
            dgvReport.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvReport.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvReport.AlternatingRowsDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvReport.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvReport.ColumnHeadersHeight = 42;

            if (dgvReport.Columns.Count > 0)
            {
                dgvReport.AutoGenerateColumns = false;

                if (dgvReport.Columns.Contains("colTrainerName"))
                    dgvReport.Columns["colTrainerName"].DataPropertyName = "Trainer";

                if (dgvReport.Columns.Contains("colModule"))
                    dgvReport.Columns["colModule"].DataPropertyName = "Module";

                if (dgvReport.Columns.Contains("colLevel"))
                    dgvReport.Columns["colLevel"].DataPropertyName = "Level";

                if (dgvReport.Columns.Contains("colStudentPaid"))
                    dgvReport.Columns["colStudentPaid"].DataPropertyName = "StudentsPaid";

                if (dgvReport.Columns.Contains("colFeePerStudent"))
                    dgvReport.Columns["colFeePerStudent"].DataPropertyName = "FeePerStudent";

                if (dgvReport.Columns.Contains("colTotal"))
                    dgvReport.Columns["colTotal"].DataPropertyName = "Total";
            }
            else
            {
                dgvReport.AutoGenerateColumns = true;
            }

            ConfigureReportColumns();
        }

        private void LoadMonths()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MonthValue", typeof(int));
            dt.Columns.Add("MonthText", typeof(string));

            dt.Rows.Add(0, "All Months");
            dt.Rows.Add(1, "January");
            dt.Rows.Add(2, "February");
            dt.Rows.Add(3, "March");
            dt.Rows.Add(4, "April");
            dt.Rows.Add(5, "May");
            dt.Rows.Add(6, "June");
            dt.Rows.Add(7, "July");
            dt.Rows.Add(8, "August");
            dt.Rows.Add(9, "September");
            dt.Rows.Add(10, "October");
            dt.Rows.Add(11, "November");
            dt.Rows.Add(12, "December");

            cboMonth.DataSource = dt;
            cboMonth.DisplayMember = "MonthText";
            cboMonth.ValueMember = "MonthValue";
            cboMonth.SelectedValue = DateTime.Now.Month;
        }

        private void LoadTrainers()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"
SELECT TrainerID, TrainerName
FROM
(
    SELECT 0 AS TrainerID, 'All Trainers' AS TrainerName
    UNION ALL
    SELECT t.TrainerID, u.[Name] AS TrainerName
    FROM Trainers t
    INNER JOIN Users u ON t.UserID = u.UserID
) x
ORDER BY TrainerID;";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboTrainer.DataSource = dt;
                    cboTrainer.DisplayMember = "TrainerName";
                    cboTrainer.ValueMember = "TrainerID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading trainers:\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedMonth = Convert.ToInt32(cboMonth.SelectedValue);
                int selectedTrainer = Convert.ToInt32(cboTrainer.SelectedValue);
                int selectedYear = DateTime.Now.Year;

                LoadIncomeReport(selectedMonth, selectedYear, selectedTrainer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error generating report:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LoadIncomeReport(int month, int year, int trainerId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"
SELECT
    u.[Name] AS Trainer,
    c.ModuleName AS Module,
    c.[Level] AS [Level],
    COUNT(p.PaymentID) AS StudentsPaid,
    c.Charges AS FeePerStudent,
    COUNT(p.PaymentID) * c.Charges AS Total
FROM ClassSchedule c
INNER JOIN Trainers t ON c.TrainerID = t.TrainerID
INNER JOIN Users u ON t.UserID = u.UserID
LEFT JOIN StudentPayments p
    ON c.Id = p.ClassScheduleID
    AND p.[Status] = 'Paid'
    AND (@Month = 0 OR MONTH(p.PaymentDate) = @Month)
    AND YEAR(p.PaymentDate) = @Year
WHERE (@TrainerID = 0 OR t.TrainerID = @TrainerID)
GROUP BY
    u.[Name],
    c.ModuleName,
    c.[Level],
    c.Charges
ORDER BY
    u.[Name],
    c.ModuleName;";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    da.SelectCommand.Parameters.AddWithValue("@Month", month);
                    da.SelectCommand.Parameters.AddWithValue("@Year", year);
                    da.SelectCommand.Parameters.AddWithValue("@TrainerID", trainerId);

                    reportTable = new DataTable();
                    da.Fill(reportTable);

                    dgvReport.DataSource = null;
                    dgvReport.DataSource = reportTable;

                    FormatGrid();
                    UpdateSummary();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading monthly income report:\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void FormatGrid()
        {
            ConfigureReportColumns();

            if (dgvReport.Columns.Contains("FeePerStudent"))
            {
                dgvReport.Columns["FeePerStudent"].DefaultCellStyle.Format = "N2";
                dgvReport.Columns["FeePerStudent"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvReport.Columns.Contains("Total"))
            {
                dgvReport.Columns["Total"].DefaultCellStyle.Format = "N2";
                dgvReport.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvReport.Columns.Contains("StudentsPaid"))
            {
                dgvReport.Columns["StudentsPaid"].HeaderText = "Students Paid";
                dgvReport.Columns["StudentsPaid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void UpdateSummary()
        {
            int totalPaidStudents = 0;
            decimal totalIncome = 0;

            foreach (DataRow row in reportTable.Rows)
            {
                if (row["StudentsPaid"] != DBNull.Value)
                    totalPaidStudents += Convert.ToInt32(row["StudentsPaid"]);

                if (row["Total"] != DBNull.Value)
                    totalIncome += Convert.ToDecimal(row["Total"]);
            }

            lblPaidCountTitle.Text = "Paid Students: " + totalPaidStudents;
            lblTotalIncomeTitle.Text = "Total Income: RM " + totalIncome.ToString("N2");
        }

        private void ResetSummary()
        {
            lblPaidCountTitle.Text = "Paid Students: 0";
            lblTotalIncomeTitle.Text = "Total Income: RM 0.00";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (reportTable.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No report data to print.",
                    "Print",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            using (PrintPreviewDialog preview = new PrintPreviewDialog())
            {
                preview.Document = printDocument;
                preview.Width = 1000;
                preview.Height = 700;
                preview.ShowDialog();
            }
        }

        private void printDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            printRowIndex = 0;
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font headerFont = new Font("Arial", 10, FontStyle.Bold);
            Font bodyFont = new Font("Arial", 10);

            int left = e.MarginBounds.Left;
            int top = e.MarginBounds.Top;
            int y = top;
            int printableWidth = e.MarginBounds.Width;
            int headerHeight = 32;
            int rowHeight = 34;
            int[] widths = CalculatePrintColumnWidths(printableWidth);

            e.Graphics.DrawString("Monthly Income Report", titleFont, Brushes.Black, left, y);
            y += 35;

            e.Graphics.DrawString("Month: " + cboMonth.Text, bodyFont, Brushes.Black, left, y);
            y += 20;
            e.Graphics.DrawString("Trainer: " + cboTrainer.Text, bodyFont, Brushes.Black, left, y);
            y += 20;
            e.Graphics.DrawString(lblPaidCountTitle.Text, bodyFont, Brushes.Black, left, y);
            y += 20;
            e.Graphics.DrawString(lblTotalIncomeTitle.Text, bodyFont, Brushes.Black, left, y);
            y += 30;

            DrawPrintHeader(e.Graphics, headerFont, left, y, widths, headerHeight);
            y += headerHeight;

            while (printRowIndex < reportTable.Rows.Count)
            {
                if (y + rowHeight > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }

                DataRow row = reportTable.Rows[printRowIndex];

                string[] values =
                {
                    row["Trainer"].ToString(),
                    row["Module"].ToString(),
                    row["Level"].ToString(),
                    row["StudentsPaid"].ToString(),
                    Convert.ToDecimal(row["FeePerStudent"]).ToString("N2"),
                    Convert.ToDecimal(row["Total"]).ToString("N2")
                };

                DrawPrintRow(e.Graphics, bodyFont, left, y, widths, rowHeight, values);

                y += rowHeight;
                printRowIndex++;
            }

            e.HasMorePages = false;
        }

        private void ConfigureReportColumns()
        {
            ConfigureColumn("colTrainerName", 22F, 150, DataGridViewContentAlignment.MiddleLeft);
            ConfigureColumn("colModule", 32F, 260, DataGridViewContentAlignment.MiddleLeft);
            ConfigureColumn("colLevel", 16F, 130, DataGridViewContentAlignment.MiddleLeft);
            ConfigureColumn("colStudentPaid", 14F, 130, DataGridViewContentAlignment.MiddleCenter);
            ConfigureColumn("colFeePerStudent", 16F, 140, DataGridViewContentAlignment.MiddleRight);
            ConfigureColumn("colTotal", 16F, 140, DataGridViewContentAlignment.MiddleRight);
        }

        private void ConfigureColumn(string columnName, float fillWeight, int minimumWidth, DataGridViewContentAlignment alignment)
        {
            if (!dgvReport.Columns.Contains(columnName))
            {
                return;
            }

            DataGridViewColumn column = dgvReport.Columns[columnName];
            column.FillWeight = fillWeight;
            column.MinimumWidth = minimumWidth;
            column.DefaultCellStyle.Alignment = alignment;
            column.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private int[] CalculatePrintColumnWidths(int totalWidth)
        {
            double[] ratios = { 0.20, 0.30, 0.13, 0.14, 0.11, 0.12 };
            int[] widths = new int[ratios.Length];
            int usedWidth = 0;

            for (int i = 0; i < ratios.Length; i++)
            {
                widths[i] = (int)Math.Floor(totalWidth * ratios[i]);
                usedWidth += widths[i];
            }

            widths[^1] += totalWidth - usedWidth;
            return widths;
        }

        private void DrawPrintHeader(Graphics graphics, Font font, int left, int top, int[] widths, int rowHeight)
        {
            int x = left;
            for (int i = 0; i < printHeaders.Length; i++)
            {
                Rectangle bounds = new Rectangle(x, top, widths[i], rowHeight);
                graphics.FillRectangle(Brushes.WhiteSmoke, bounds);
                graphics.DrawRectangle(Pens.Black, bounds);
                DrawCellText(graphics, printHeaders[i], font, bounds, i >= 3 ? StringAlignment.Center : StringAlignment.Near);
                x += widths[i];
            }
        }

        private void DrawPrintRow(Graphics graphics, Font font, int left, int top, int[] widths, int rowHeight, string[] values)
        {
            int x = left;
            for (int i = 0; i < values.Length; i++)
            {
                Rectangle bounds = new Rectangle(x, top, widths[i], rowHeight);
                graphics.DrawRectangle(Pens.Black, bounds);

                StringAlignment alignment = i >= 3 ? StringAlignment.Far : StringAlignment.Near;
                DrawCellText(graphics, values[i], font, bounds, alignment);
                x += widths[i];
            }
        }

        private void DrawCellText(Graphics graphics, string text, Font font, Rectangle bounds, StringAlignment alignment)
        {
            Rectangle paddedBounds = Rectangle.Inflate(bounds, -6, -4);
            using StringFormat format = new StringFormat
            {
                Alignment = alignment,
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.EllipsisCharacter,
                FormatFlags = StringFormatFlags.NoWrap
            };

            graphics.DrawString(text, font, Brushes.Black, paddedBounds, format);
        }
    }
}
