using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace APUCC_Project.Forms.Trainer
{
    public partial class TrainerHomeForm : Form
    {
        private readonly string connStr =
            ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        public TrainerHomeForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void TrainerHomeForm_Load(object sender, EventArgs e)
        {
            LoadClassSchedule();
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out decimal charges, out TimeSpan classTime))
                return;

            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();

                    string checkQuery = @"
                        SELECT COUNT(*)
                        FROM ClassSchedule
                        WHERE ModuleId = @ModuleId
                          AND ClassDate = @ClassDate
                          AND ClassTime = @ClassTime";

                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@ModuleId", txtModuleID.Text.Trim());
                        checkCmd.Parameters.AddWithValue("@ClassDate", dtpClassDate.Value.Date);
                        checkCmd.Parameters.AddWithValue("@ClassTime", classTime);

                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("This class schedule already exists.");
                            return;
                        }
                    }

                    string insertQuery = @"
                        INSERT INTO ClassSchedule (ModuleId, ModuleName, ClassDate, ClassTime, Charges)
                        VALUES (@ModuleId, @ModuleName, @ClassDate, @ClassTime, @Charges)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@ModuleId", txtModuleID.Text.Trim());
                        cmd.Parameters.AddWithValue("@ModuleName", txtModuleName.Text.Trim());
                        cmd.Parameters.AddWithValue("@ClassDate", dtpClassDate.Value.Date);
                        cmd.Parameters.AddWithValue("@ClassTime", classTime);
                        cmd.Parameters.AddWithValue("@Charges", charges);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Class added successfully.");
                LoadClassSchedule();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add Error: " + ex.Message);
            }
        }

        private void updateClass_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out decimal charges, out TimeSpan classTime))
                return;

            if (dgvClassSchedule.CurrentRow == null || dgvClassSchedule.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select a class to update.");
                return;
            }

            try
            {
                int selectedId = Convert.ToInt32(dgvClassSchedule.CurrentRow.Cells["Id"].Value);

                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();

                    string duplicateCheck = @"
                        SELECT COUNT(*)
                        FROM ClassSchedule
                        WHERE ModuleId = @ModuleId
                          AND ClassDate = @ClassDate
                          AND ClassTime = @ClassTime
                          AND Id <> @Id";

                    using (SqlCommand checkCmd = new SqlCommand(duplicateCheck, con))
                    {
                        checkCmd.Parameters.AddWithValue("@ModuleId", txtModuleID.Text.Trim());
                        checkCmd.Parameters.AddWithValue("@ClassDate", dtpClassDate.Value.Date);
                        checkCmd.Parameters.AddWithValue("@ClassTime", classTime);
                        checkCmd.Parameters.AddWithValue("@Id", selectedId);

                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Another class with the same Module ID, date, and time already exists.");
                            return;
                        }
                    }

                    string updateQuery = @"
                        UPDATE ClassSchedule
                        SET ModuleId = @ModuleId,
                            ModuleName = @ModuleName,
                            ClassDate = @ClassDate,
                            ClassTime = @ClassTime,
                            Charges = @Charges
                        WHERE Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@ModuleId", txtModuleID.Text.Trim());
                        cmd.Parameters.AddWithValue("@ModuleName", txtModuleName.Text.Trim());
                        cmd.Parameters.AddWithValue("@ClassDate", dtpClassDate.Value.Date);
                        cmd.Parameters.AddWithValue("@ClassTime", classTime);
                        cmd.Parameters.AddWithValue("@Charges", charges);
                        cmd.Parameters.AddWithValue("@Id", selectedId);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                            MessageBox.Show("Class updated successfully.");
                        else
                            MessageBox.Show("No record found to update.");
                    }
                }

                LoadClassSchedule();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error: " + ex.Message);
            }
        }

        private void deleteClass_Click(object sender, EventArgs e)
        {
            if (dgvClassSchedule.CurrentRow == null || dgvClassSchedule.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select a class to delete.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this class?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                int selectedId = Convert.ToInt32(dgvClassSchedule.CurrentRow.Cells["Id"].Value);

                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();

                    string deleteQuery = "DELETE FROM ClassSchedule WHERE Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", selectedId);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                            MessageBox.Show("Class deleted successfully.");
                        else
                            MessageBox.Show("No record found to delete.");
                    }
                }

                LoadClassSchedule();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Error: " + ex.Message);
            }
        }

        private void dgvClassSchedule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvClassSchedule.Rows[e.RowIndex];

            txtModuleID.Text = row.Cells["ModuleId"].Value?.ToString() ?? "";
            txtModuleName.Text = row.Cells["ModuleName"].Value?.ToString() ?? "";
            txtCharges.Text = row.Cells["Charges"].Value?.ToString() ?? "";

            if (row.Cells["ClassDate"].Value != null && row.Cells["ClassDate"].Value != DBNull.Value)
                dtpClassDate.Value = Convert.ToDateTime(row.Cells["ClassDate"].Value);
            else
                dtpClassDate.Value = DateTime.Today;

            if (row.Cells["ClassTime"].Value != null && row.Cells["ClassTime"].Value != DBNull.Value)
            {
                TimeSpan time = (TimeSpan)row.Cells["ClassTime"].Value;
                txtClassTime.Text = time.ToString(@"hh\:mm");
            }
            else
            {
                txtClassTime.Clear();
            }
        }

        private void LoadClassSchedule()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();

                    string query = @"
                        SELECT Id, ModuleId, ModuleName, ClassDate, ClassTime, Charges
                        FROM ClassSchedule
                        ORDER BY ClassDate, ClassTime";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvClassSchedule.AutoGenerateColumns = true;
                        dgvClassSchedule.DataSource = null;
                        dgvClassSchedule.Columns.Clear();
                        dgvClassSchedule.DataSource = dt;

                        if (dgvClassSchedule.Columns["Id"] != null)
                            dgvClassSchedule.Columns["Id"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Error: " + ex.Message);
            }
        }

        private bool ValidateInputs(out decimal charges, out TimeSpan classTime)
        {
            charges = 0;
            classTime = TimeSpan.Zero;

            if (string.IsNullOrWhiteSpace(txtModuleID.Text) ||
                string.IsNullOrWhiteSpace(txtModuleName.Text) ||
                string.IsNullOrWhiteSpace(txtClassTime.Text) ||
                string.IsNullOrWhiteSpace(txtCharges.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return false;
            }

            if (!decimal.TryParse(txtCharges.Text.Trim(), out charges))
            {
                MessageBox.Show("Charges must be a valid number.");
                return false;
            }

            if (!TimeSpan.TryParse(txtClassTime.Text.Trim(), out classTime))
            {
                MessageBox.Show("Enter valid time in HH:mm format. Example: 04:30 or 16:30");
                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            txtModuleID.Clear();
            txtModuleName.Clear();
            txtClassTime.Clear();
            txtCharges.Clear();
            dtpClassDate.Value = DateTime.Today;
        }

        private void txtModuleID_TextChanged(object sender, EventArgs e)
        {
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}