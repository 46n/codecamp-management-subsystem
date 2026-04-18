using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace APUCC_Project.Forms.Trainer
{
    public partial class TrainerHomeForm : Form
    {
        private readonly string connStr =
            ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
        private readonly int trainerId;

        private System.Windows.Forms.Timer successTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer errorTimer = new System.Windows.Forms.Timer();

        public TrainerHomeForm()
            : this(0)
        {
        }

        public TrainerHomeForm(int loggedInTrainerId)
        {
            InitializeComponent();
            trainerId = loggedInTrainerId;
            dgvClassSchedule.RowHeadersVisible = false;
            dgvClassSchedule.AllowUserToAddRows = false;
            dgvClassSchedule.AllowUserToDeleteRows = false;
            dgvClassSchedule.AllowUserToResizeRows = false;
            btnAddClass.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            btnUpdateClass.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            btnDeleteClass.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            lblTrainerID.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            lblModuleID.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            lblModuleName.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            lblClassTime.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            lblCharges.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            lblLevel.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            lblClassDate.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            lblRoom.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);

            successTimer.Interval = 3000;
            successTimer.Tick += SuccessTimer_Tick;

            errorTimer.Interval = 3000;
            errorTimer.Tick += ErrorTimer_Tick;
        }

        private void TrainerHomeForm_Load(object sender, EventArgs e)
        {
            lblWrong.Visible = false;
            lblConfirmed.Visible = false;
            if (trainerId > 0)
            {
                txtTrainerID.Text = trainerId.ToString();
            }
            LoadClassSchedule();
        }

        private void SuccessTimer_Tick(object sender, EventArgs e)
        {
            successTimer.Stop();
            lblConfirmed.Visible = false;
        }

        private void ErrorTimer_Tick(object sender, EventArgs e)
        {
            errorTimer.Stop();
            lblWrong.Visible = false;
        }

        private void ShowError(string message)
        {
            successTimer.Stop();
            lblConfirmed.Visible = false;
            lblConfirmed.Text = "";

            lblWrong.Text = message;
            lblWrong.ForeColor = Color.Red;
            lblWrong.Visible = true;

            errorTimer.Stop();
            errorTimer.Start();
        }

        private void ShowSuccess(string message)
        {
            errorTimer.Stop();
            lblWrong.Visible = false;
            lblWrong.Text = "";

            lblConfirmed.Text = message;
            lblConfirmed.ForeColor = Color.Green;
            lblConfirmed.Visible = true;

            successTimer.Stop();
            successTimer.Start();
        }

        private void ClearMessages()
        {
            successTimer.Stop();
            errorTimer.Stop();

            lblWrong.Visible = false;
            lblWrong.Text = "";

            lblConfirmed.Visible = false;
            lblConfirmed.Text = "";
        }

        private void LoadClassSchedule()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    string query = @"
                        SELECT 
                            Id,
                            TrainerID,
                            ModuleId,
                            ModuleName,
                            ClassDate,
                            ClassTime,
                            Charges,
                            Level,
                            Room
                        FROM ClassSchedule
                        WHERE (@TrainerID = 0 OR TrainerID = @TrainerID)
                        ORDER BY ClassDate, ClassTime";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    da.SelectCommand.Parameters.AddWithValue("@TrainerID", trainerId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvClassSchedule.DataSource = dt;

                    if (dgvClassSchedule.Columns["Id"] != null)
                        dgvClassSchedule.Columns["Id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                ShowError("Load Error: " + ex.Message);
            }
        }

        private bool ValidateInputs(out decimal charges, out TimeSpan classTime, out int trainerId)
        {
            charges = 0;
            classTime = TimeSpan.Zero;
            trainerId = 0;

            ClearMessages();

            if (string.IsNullOrWhiteSpace(txtTrainerID.Text))
            {
                ShowError("Trainer ID is required.");
                txtTrainerID.Focus();
                return false;
            }

            if (!int.TryParse(txtTrainerID.Text.Trim(), out trainerId) || trainerId <= 0)
            {
                ShowError("Trainer ID must be a valid number.");
                txtTrainerID.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtModuleID.Text))
            {
                ShowError("Module ID is required.");
                txtModuleID.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtModuleName.Text))
            {
                ShowError("Module Name is required.");
                txtModuleName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtClassTime.Text))
            {
                ShowError("Class Time is required.");
                txtClassTime.Focus();
                return false;
            }

            if (!TimeSpan.TryParse(txtClassTime.Text.Trim(), out classTime))
            {
                ShowError("Enter valid time in HH:mm format. Example: 04:30");
                txtClassTime.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCharges.Text))
            {
                ShowError("Charges is required.");
                txtCharges.Focus();
                return false;
            }

            if (!decimal.TryParse(txtCharges.Text.Trim(), out charges))
            {
                ShowError("Charges must be a valid number.");
                txtCharges.Focus();
                return false;
            }

            if (charges <= 0)
            {
                ShowError("Charges must be greater than 0.");
                txtCharges.Focus();
                return false;
            }

            if (cboLevel.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cboLevel.Text))
            {
                ShowError("Please select a level.");
                cboLevel.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtRoom.Text))
            {
                ShowError("Room is required.");
                txtRoom.Focus();
                return false;
            }

            if (dtpClassDate.Value.Date < DateTime.Today)
            {
                ShowError("Class date cannot be in the past.");
                dtpClassDate.Focus();
                return false;
            }

            return true;
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out decimal charges, out TimeSpan classTime, out int trainerId))
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

                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            ShowError("This class schedule already exists.");
                            return;
                        }
                    }

                    string insertQuery = @"
                        INSERT INTO ClassSchedule
                        (TrainerID, ModuleId, ModuleName, ClassDate, ClassTime, Charges, Level, Room)
                        VALUES
                        (@TrainerID, @ModuleId, @ModuleName, @ClassDate, @ClassTime, @Charges, @Level, @Room)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@TrainerID", trainerId);
                        cmd.Parameters.AddWithValue("@ModuleId", txtModuleID.Text.Trim());
                        cmd.Parameters.AddWithValue("@ModuleName", txtModuleName.Text.Trim());
                        cmd.Parameters.AddWithValue("@ClassDate", dtpClassDate.Value.Date);
                        cmd.Parameters.AddWithValue("@ClassTime", classTime);
                        cmd.Parameters.AddWithValue("@Charges", charges);
                        cmd.Parameters.AddWithValue("@Level", cboLevel.Text.Trim());
                        cmd.Parameters.AddWithValue("@Room", txtRoom.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }
                }

                ShowSuccess("Class added successfully.");
                LoadClassSchedule();
                ClearFields();
            }
            catch (Exception ex)
            {
                ShowError("Add Error: " + ex.Message);
            }
        }

        private void btnUpdateClass_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out decimal charges, out TimeSpan classTime, out int trainerId))
                return;

            if (dgvClassSchedule.CurrentRow == null || dgvClassSchedule.CurrentRow.Index < 0)
            {
                ShowError("Please select a class to update.");
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

                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            ShowError("Another class with the same module, date, and time already exists.");
                            return;
                        }
                    }

                    string updateQuery = @"
                        UPDATE ClassSchedule
                        SET TrainerID = @TrainerID,
                            ModuleId = @ModuleId,
                            ModuleName = @ModuleName,
                            ClassDate = @ClassDate,
                            ClassTime = @ClassTime,
                            Charges = @Charges,
                            Level = @Level,
                            Room = @Room
                        WHERE Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@TrainerID", trainerId);
                        cmd.Parameters.AddWithValue("@ModuleId", txtModuleID.Text.Trim());
                        cmd.Parameters.AddWithValue("@ModuleName", txtModuleName.Text.Trim());
                        cmd.Parameters.AddWithValue("@ClassDate", dtpClassDate.Value.Date);
                        cmd.Parameters.AddWithValue("@ClassTime", classTime);
                        cmd.Parameters.AddWithValue("@Charges", charges);
                        cmd.Parameters.AddWithValue("@Level", cboLevel.Text.Trim());
                        cmd.Parameters.AddWithValue("@Room", txtRoom.Text.Trim());
                        cmd.Parameters.AddWithValue("@Id", selectedId);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                            ShowSuccess("Class updated successfully.");
                        else
                            ShowError("No record found to update.");
                    }
                }

                LoadClassSchedule();
                ClearFields();
            }
            catch (Exception ex)
            {
                ShowError("Update Error: " + ex.Message);
            }
        }

        private void btnDeleteClass_Click(object sender, EventArgs e)
        {
            ClearMessages();

            if (dgvClassSchedule.CurrentRow == null || dgvClassSchedule.CurrentRow.Index < 0)
            {
                ShowError("Please select a class to delete.");
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
                            ShowSuccess("Class deleted successfully.");
                        else
                            ShowError("No record found to delete.");
                    }
                }

                LoadClassSchedule();
                ClearFields();
            }
            catch (SqlException)
            {
                ShowError("This class cannot be deleted because it is linked to other records.");
            }
            catch (Exception ex)
            {
                ShowError("Delete Error: " + ex.Message);
            }
        }

        private void dgvClassSchedule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvClassSchedule.Rows[e.RowIndex];

            txtTrainerID.Text = row.Cells["TrainerID"].Value?.ToString() ?? "";
            txtModuleID.Text = row.Cells["ModuleId"].Value?.ToString() ?? "";
            txtModuleName.Text = row.Cells["ModuleName"].Value?.ToString() ?? "";
            txtCharges.Text = row.Cells["Charges"].Value?.ToString() ?? "";
            txtRoom.Text = row.Cells["Room"].Value?.ToString() ?? "";
            cboLevel.Text = row.Cells["Level"].Value?.ToString() ?? "";

            if (row.Cells["ClassDate"].Value != null && row.Cells["ClassDate"].Value != DBNull.Value)
                dtpClassDate.Value = Convert.ToDateTime(row.Cells["ClassDate"].Value);
            else
                dtpClassDate.Value = DateTime.Today;

            if (row.Cells["ClassTime"].Value != null && row.Cells["ClassTime"].Value != DBNull.Value)
            {
                if (row.Cells["ClassTime"].Value is TimeSpan time)
                    txtClassTime.Text = time.ToString(@"hh\:mm");
                else
                    txtClassTime.Text = row.Cells["ClassTime"].Value.ToString();
            }
            else
            {
                txtClassTime.Clear();
            }

            ClearMessages();
        }

        private void ClearFields()
        {
            txtTrainerID.Clear();
            txtModuleID.Clear();
            txtModuleName.Clear();
            txtClassTime.Clear();
            txtCharges.Clear();
            txtRoom.Clear();
            cboLevel.SelectedIndex = -1;
            dtpClassDate.Value = DateTime.Today;
        }

        private void txtTrainerID_TextChanged(object sender, EventArgs e)
        {
            ClearMessages();
        }

        private void txtModuleID_TextChanged(object sender, EventArgs e)
        {
            ClearMessages();
        }

        private void txtModuleName_TextChanged(object sender, EventArgs e)
        {
            ClearMessages();
        }

        private void txtClassTime_TextChanged(object sender, EventArgs e)
        {
            ClearMessages();
        }

        private void txtCharges_TextChanged(object sender, EventArgs e)
        {
            ClearMessages();
        }

        private void txtRoom_TextChanged(object sender, EventArgs e)
        {
            ClearMessages();
        }

        private void cboLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearMessages();
        }
    }
}
