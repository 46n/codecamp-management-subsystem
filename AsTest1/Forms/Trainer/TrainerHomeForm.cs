using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace APUCC_Project.Forms.Trainer
{
    public partial class TrainerHomeForm : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        public TrainerHomeForm()
        {
            InitializeComponent();
        }

        private void TrainerHomeForm_Load(object sender, EventArgs e)
        {
            LoadClassSchedule();
        }

        // ========================= LOAD DATA =========================
        private void LoadClassSchedule()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                        SELECT
                            Id,
                            ModuleId,
                            ModuleName,
                            ClassDate,
                            ClassTime,
                            Charges
                        FROM ClassSchedule";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvClassSchedule.DataSource = dt;
            }
        }

        // ========================= VALIDATION =========================
        private bool ValidateInputs(out int charges)
        {
            charges = 0;

            if (string.IsNullOrWhiteSpace(txtModuleID.Text))
            {
                MessageBox.Show("Module ID is required.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtModuleName.Text))
            {
                MessageBox.Show("Module Name is required.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtClassTime.Text))
            {
                MessageBox.Show("Class Time is required.");
                return false;
            }

            if (!TimeSpan.TryParse(txtClassTime.Text, out _))
            {
                MessageBox.Show("Invalid time format. Use HH:mm");
                return false;
            }

            if (!int.TryParse(txtCharges.Text, out charges))
            {
                MessageBox.Show("Charges must be a number.");
                return false;
            }

            if (charges <= 0)
            {
                MessageBox.Show("Charges must be greater than 0.");
                return false;
            }

            // ✅ NEW VALIDATION (IMPORTANT)
            if (dtpClassDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Class date cannot be in the past.");
                return false;
            }

            return true;
        }

        // ========================= ADD =========================
        private void btnAddClass_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out int charges)) return;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Prevent duplicate
                string checkQuery = @"
                    SELECT COUNT(*) 
                    FROM ClassSchedule 
                    WHERE ModuleID = @ModuleID 
                    AND ClassDate = @Date 
                    AND ClassTime = @Time";

                using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@ModuleID", txtModuleID.Text.Trim());
                    checkCmd.Parameters.AddWithValue("@Date", dtpClassDate.Value.Date);
                    checkCmd.Parameters.AddWithValue("@Time", txtClassTime.Text.Trim());

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("This class already exists!");
                        return;
                    }
                }

                string insertQuery = @"
                    INSERT INTO ClassSchedule 
                    (ModuleID, ModuleName, ClassDate, ClassTime, Charges)
                    VALUES 
                    (@ModuleID, @ModuleName, @Date, @Time, @Charges)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@ModuleID", txtModuleID.Text.Trim());
                    cmd.Parameters.AddWithValue("@ModuleName", txtModuleName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Date", dtpClassDate.Value.Date);
                    cmd.Parameters.AddWithValue("@Time", txtClassTime.Text.Trim());
                    cmd.Parameters.AddWithValue("@Charges", charges);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Class added successfully!");
            LoadClassSchedule();
        }

        // ========================= UPDATE =========================
        private void btnUpdateClass_Click(object sender, EventArgs e)
        {
            if (dgvClassSchedule.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to update.");
                return;
            }

            if (!ValidateInputs(out int charges)) return;

            int id = Convert.ToInt32(dgvClassSchedule.SelectedRows[0].Cells["Id"].Value);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string updateQuery = @"
                    UPDATE ClassSchedule
                    SET ModuleID = @ModuleID,
                        ModuleName = @ModuleName,
                        ClassDate = @Date,
                        ClassTime = @Time,
                        Charges = @Charges
                    WHERE ClassScheduleID = @ID";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@ModuleID", txtModuleID.Text.Trim());
                    cmd.Parameters.AddWithValue("@ModuleName", txtModuleName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Date", dtpClassDate.Value.Date);
                    cmd.Parameters.AddWithValue("@Time", txtClassTime.Text.Trim());
                    cmd.Parameters.AddWithValue("@Charges", charges);
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Class updated successfully!");
            LoadClassSchedule();
        }

        // ========================= DELETE =========================
        private void btnDeleteClass_Click(object sender, EventArgs e)
        {
            if (dgvClassSchedule.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row to delete.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this class?",
                "Confirm",
                MessageBoxButtons.YesNo
            );

            if (result != DialogResult.Yes) return;

            int id = Convert.ToInt32(dgvClassSchedule.SelectedRows[0].Cells["Id"].Value);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string deleteQuery = "DELETE FROM ClassSchedule WHERE ClassScheduleID = @ID";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Class deleted successfully!");
            LoadClassSchedule();
        }

        // ========================= GRID CLICK =========================
        private void dgvClassSchedule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvClassSchedule.Rows[e.RowIndex];

                txtModuleID.Text = row.Cells["ModuleID"].Value.ToString();
                txtModuleName.Text = row.Cells["ModuleName"].Value.ToString();
                txtClassTime.Text = row.Cells["ClassTime"].Value.ToString();
                txtCharges.Text = row.Cells["Charges"].Value.ToString();

                dtpClassDate.Value = Convert.ToDateTime(row.Cells["ClassDate"].Value);
            }
        }
    }
}