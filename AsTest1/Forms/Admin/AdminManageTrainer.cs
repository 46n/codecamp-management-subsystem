using System;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace APUCC_Project.Forms.Admin
{
    public partial class AdminManageTrainer : Form
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        private int selectedTrainerId = -1;
        private int selectedUserId = -1;

        public AdminManageTrainer()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.WindowState = FormWindowState.Maximized;

            dgvTrainer.CellClick += dgvTrainer_CellClick;
            txtPassword.TextChanged += txtPassword_TextChanged;
        }

        private void AdminManageTrainer_Load(object sender, EventArgs e)
        {
            SetupControls();
            ConfigureGrid();
            LoadModules();
            LoadLevels();
            LoadTrainers();
            ClearFields();
        }

        private void SetupControls()
        {
            txtFullName.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtPhone.ReadOnly = false;
            txtUserName.ReadOnly = false;
            txtPassword.ReadOnly = false;

            txtFullName.Enabled = true;
            txtEmail.Enabled = true;
            txtPhone.Enabled = true;
            txtUserName.Enabled = true;
            txtPassword.Enabled = true;

            cboModule.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLevel.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ConfigureGrid()
        {
            dgvTrainer.Rows.Clear();
            dgvTrainer.ReadOnly = true;
            dgvTrainer.AllowUserToAddRows = false;
            dgvTrainer.AllowUserToDeleteRows = false;
            dgvTrainer.MultiSelect = false;
            dgvTrainer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTrainer.RowHeadersVisible = false;
            dgvTrainer.AutoGenerateColumns = false;
        }

        private void LoadLevels()
        {
            cboLevel.Items.Clear();
            cboLevel.Items.Add("Beginner");
            cboLevel.Items.Add("Intermediate");
            cboLevel.Items.Add("Advance");
            cboLevel.SelectedIndex = -1;
        }

        private void LoadModules()
        {
            cboModule.DataSource = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT DISTINCT ModuleId, ModuleName FROM ClassSchedule ORDER BY ModuleName";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboModule.DataSource = dt;
                cboModule.DisplayMember = "ModuleName";
                cboModule.ValueMember = "ModuleId";
                cboModule.SelectedIndex = -1;
            }
        }

        private void LoadTrainers()
        {
            dgvTrainer.Rows.Clear();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        t.TrainerID,
                        u.Name,
                        ISNULL(t.AssignedModuleName, '-') AS Module,
                        ISNULL(t.AssignedLevel, '-') AS Level
                    FROM Trainers t
                    INNER JOIN Users u ON t.UserID = u.UserID
                    ORDER BY t.TrainerID";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dgvTrainer.Rows.Add(
                        dr["TrainerID"].ToString(),
                        dr["Name"].ToString(),
                        dr["Module"].ToString(),
                        dr["Level"].ToString()
                    );
                }

                dr.Close();
            }

            lblStatus.Text = dgvTrainer.Rows.Count + " trainers loaded";
            lblError.Text = "";
        }

        private void LoadTrainerDetails(int trainerId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        t.TrainerID,
                        t.UserID,
                        u.Name,
                        u.Email,
                        u.Phone,
                        u.Username,
                        u.Password,
                        t.AssignedModuleId,
                        t.AssignedModuleName,
                        t.AssignedLevel
                    FROM Trainers t
                    INNER JOIN Users u ON t.UserID = u.UserID
                    WHERE t.TrainerID = @TrainerID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TrainerID", trainerId);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    selectedTrainerId = Convert.ToInt32(dr["TrainerID"]);
                    selectedUserId = Convert.ToInt32(dr["UserID"]);

                    txtFullName.Text = dr["Name"]?.ToString() ?? "";
                    txtEmail.Text = dr["Email"]?.ToString() ?? "";
                    txtPhone.Text = dr["Phone"]?.ToString() ?? "";
                    txtUserName.Text = dr["Username"]?.ToString() ?? "";
                    txtPassword.Text = dr["Password"]?.ToString() ?? "";

                    if (dr["AssignedModuleId"] != DBNull.Value)
                        cboModule.SelectedValue = dr["AssignedModuleId"].ToString();
                    else
                        cboModule.SelectedIndex = -1;

                    if (dr["AssignedLevel"] != DBNull.Value)
                        cboLevel.Text = dr["AssignedLevel"].ToString();
                    else
                        cboLevel.SelectedIndex = -1;
                }

                dr.Close();
            }
        }

        private bool ValidateInputs()
        {
            lblError.Text = "";
            lblStatus.Text = "";

            txtFullName.Text = txtFullName.Text.Trim();
            txtEmail.Text = txtEmail.Text.Trim();
            txtPhone.Text = txtPhone.Text.Trim();
            txtUserName.Text = txtUserName.Text.Trim();
            txtPassword.Text = txtPassword.Text.Trim();

            if (txtFullName.Text == "" ||
                txtEmail.Text == "" ||
                txtPhone.Text == "" ||
                txtUserName.Text == "" ||
                txtPassword.Text == "")
            {
                lblError.Text = "Please fill in all trainer details.";
                return false;
            }

            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                lblError.Text = "Please enter a valid email address.";
                return false;
            }

            if (!Regex.IsMatch(txtPassword.Text, @"^\d{8}$"))
            {
                lblError.Text = "Password must be exactly 8 digits.";
                return false;
            }

            if (UsernameExists(txtUserName.Text, selectedUserId))
            {
                lblError.Text = "Username already exists.";
                return false;
            }

            return true;
        }

        private bool UsernameExists(string username, int excludeUserId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT COUNT(*)
                    FROM Users
                    WHERE Username = @Username
                    AND UserID <> @UserID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@UserID", excludeUserId);

                con.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        private void ClearFields()
        {
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtUserName.Clear();
            txtPassword.Clear();

            cboModule.SelectedIndex = -1;
            cboLevel.SelectedIndex = -1;

            selectedTrainerId = -1;
            selectedUserId = -1;

            dgvTrainer.ClearSelection();

            lblError.Text = "";
            lblStatus.Text = "";
        }

        private void dgvTrainer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int trainerId = Convert.ToInt32(
                    dgvTrainer.Rows[e.RowIndex].Cells["colTrainerID"].Value
                );

                LoadTrainerDetails(trainerId);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction trans = con.BeginTransaction();

                try
                {
                    if (selectedUserId == -1)
                    {
                        // INSERT new trainer
                        string userQuery = @"
                            INSERT INTO Users (Username, Password, Role, Name, Email, Phone, Address)
                            VALUES (@Username, @Password, 'Trainer', @Name, @Email, @Phone, @Address);
                            SELECT SCOPE_IDENTITY();";

                        SqlCommand userCmd = new SqlCommand(userQuery, con, trans);
                        userCmd.Parameters.AddWithValue("@Username", txtUserName.Text);
                        userCmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                        userCmd.Parameters.AddWithValue("@Name", txtFullName.Text);
                        userCmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        userCmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                        userCmd.Parameters.AddWithValue("@Address", DBNull.Value);

                        int newUserId = Convert.ToInt32(userCmd.ExecuteScalar());

                        string trainerQuery = @"
                            INSERT INTO Trainers (UserID, Qualifications, Specialisation, AssignedModuleId, AssignedModuleName, AssignedLevel)
                            VALUES (@UserID, @Qualifications, @Specialisation, NULL, NULL, NULL)";

                        SqlCommand trainerCmd = new SqlCommand(trainerQuery, con, trans);
                        trainerCmd.Parameters.AddWithValue("@UserID", newUserId);
                        trainerCmd.Parameters.AddWithValue("@Qualifications", DBNull.Value);
                        trainerCmd.Parameters.AddWithValue("@Specialisation", DBNull.Value);
                        trainerCmd.ExecuteNonQuery();

                        lblStatus.Text = "Trainer saved successfully.";
                    }
                    else
                    {
                        // UPDATE existing trainer
                        string updateUserQuery = @"
                            UPDATE Users
                            SET Name = @Name,
                                Email = @Email,
                                Phone = @Phone,
                                Username = @Username,
                                Password = @Password
                            WHERE UserID = @UserID";

                        SqlCommand updateCmd = new SqlCommand(updateUserQuery, con, trans);
                        updateCmd.Parameters.AddWithValue("@Name", txtFullName.Text);
                        updateCmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        updateCmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                        updateCmd.Parameters.AddWithValue("@Username", txtUserName.Text);
                        updateCmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                        updateCmd.Parameters.AddWithValue("@UserID", selectedUserId);
                        updateCmd.ExecuteNonQuery();

                        lblStatus.Text = "Trainer updated successfully.";
                    }

                    trans.Commit();

                    LoadTrainers();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    lblError.Text = "Save failed: " + ex.Message;
                }
            }
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (selectedTrainerId == -1)
            {
                lblError.Text = "Please select a trainer first.";
                return;
            }

            if (cboModule.SelectedIndex == -1 || cboLevel.Text.Trim() == "")
            {
                lblError.Text = "Please select module and level.";
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string checkQuery = @"
                    SELECT COUNT(*)
                    FROM Trainers
                    WHERE AssignedModuleId = @ModuleId
                    AND AssignedLevel = @Level
                    AND TrainerID <> @TrainerID";

                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@ModuleId", cboModule.SelectedValue.ToString());
                checkCmd.Parameters.AddWithValue("@Level", cboLevel.Text);
                checkCmd.Parameters.AddWithValue("@TrainerID", selectedTrainerId);

                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count > 0)
                {
                    lblError.Text = "This module and level is already assigned to another trainer.";
                    return;
                }

                string updateQuery = @"
                    UPDATE Trainers
                    SET AssignedModuleId = @ModuleId,
                        AssignedModuleName = @ModuleName,
                        AssignedLevel = @Level
                    WHERE TrainerID = @TrainerID";

                SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                updateCmd.Parameters.AddWithValue("@ModuleId", cboModule.SelectedValue.ToString());
                updateCmd.Parameters.AddWithValue("@ModuleName", cboModule.Text);
                updateCmd.Parameters.AddWithValue("@Level", cboLevel.Text);
                updateCmd.Parameters.AddWithValue("@TrainerID", selectedTrainerId);

                updateCmd.ExecuteNonQuery();
            }

            LoadTrainers();
            lblStatus.Text = "Trainer assignment updated.";
            lblError.Text = "";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (selectedTrainerId == -1)
            {
                lblError.Text = "Please select a trainer first.";
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to remove this trainer?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string classCheckQuery = "SELECT COUNT(*) FROM ClassSchedule WHERE TrainerID = @TrainerID";
                SqlCommand classCheckCmd = new SqlCommand(classCheckQuery, con);
                classCheckCmd.Parameters.AddWithValue("@TrainerID", selectedTrainerId);

                int classCount = Convert.ToInt32(classCheckCmd.ExecuteScalar());

                if (classCount > 0)
                {
                    lblError.Text = "Cannot remove trainer because class schedule records exist.";
                    return;
                }

                SqlTransaction trans = con.BeginTransaction();

                try
                {
                    string deleteFeedbackQuery = "DELETE FROM Feedback WHERE TrainerID = @TrainerID";
                    SqlCommand deleteFeedbackCmd = new SqlCommand(deleteFeedbackQuery, con, trans);
                    deleteFeedbackCmd.Parameters.AddWithValue("@TrainerID", selectedTrainerId);
                    deleteFeedbackCmd.ExecuteNonQuery();

                    string deleteTrainerQuery = "DELETE FROM Trainers WHERE TrainerID = @TrainerID";
                    SqlCommand deleteTrainerCmd = new SqlCommand(deleteTrainerQuery, con, trans);
                    deleteTrainerCmd.Parameters.AddWithValue("@TrainerID", selectedTrainerId);
                    deleteTrainerCmd.ExecuteNonQuery();

                    string deleteUserQuery = "DELETE FROM Users WHERE UserID = @UserID";
                    SqlCommand deleteUserCmd = new SqlCommand(deleteUserQuery, con, trans);
                    deleteUserCmd.Parameters.AddWithValue("@UserID", selectedUserId);
                    deleteUserCmd.ExecuteNonQuery();

                    trans.Commit();

                    LoadTrainers();
                    ClearFields();
                    lblStatus.Text = "Trainer removed successfully.";
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    lblError.Text = "Delete failed: " + ex.Message;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvTrainer.Rows.Clear();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        t.TrainerID,
                        u.Name,
                        ISNULL(t.AssignedModuleName, '-') AS Module,
                        ISNULL(t.AssignedLevel, '-') AS Level
                    FROM Trainers t
                    INNER JOIN Users u ON t.UserID = u.UserID
                    WHERE u.Name LIKE @Search
                    ORDER BY t.TrainerID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Search", "%" + txtSearch.Text.Trim() + "%");

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dgvTrainer.Rows.Add(
                        dr["TrainerID"].ToString(),
                        dr["Name"].ToString(),
                        dr["Module"].ToString(),
                        dr["Level"].ToString()
                    );
                }

                dr.Close();
            }

            lblStatus.Text = "Search completed.";
            lblError.Text = "";
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadTrainers();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvTrainer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // optional
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            string digitsOnly = Regex.Replace(txtPassword.Text, @"\D", "");

            if (txtPassword.Text != digitsOnly)
            {
                int cursor = txtPassword.SelectionStart - 1;
                if (cursor < 0) cursor = 0;

                txtPassword.Text = digitsOnly;
                txtPassword.SelectionStart = cursor > txtPassword.Text.Length
                    ? txtPassword.Text.Length
                    : cursor;
            }
        }
    }
}