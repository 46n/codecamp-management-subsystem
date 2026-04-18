using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace APUCC_Project.Forms.Admin
{
    public partial class AdminTrainerFeedback : Form
    {
        private string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=MyDatabase;Integrated Security=True;TrustServerCertificate=True";
        private int selectedFeedbackId = -1;

        public AdminTrainerFeedback()
        {
            InitializeComponent();
        }

        private void AdminTrainerFeedback_Load(object sender, EventArgs e)
        {
            SetupFeedbackGrid();
            LoadFilterOptions();
            LoadFeedback("All");

            txtMessage.ReadOnly = true;
            txtMessage.Multiline = true;
            txtMessage.ScrollBars = ScrollBars.Vertical;
        }

        private void LoadFilterOptions()
        {
            cboFilter.Items.Clear();
            cboFilter.Items.Add("All");
            cboFilter.Items.Add("Unread");
            cboFilter.Items.Add("Read");
            cboFilter.SelectedIndex = 0;
        }

        private void SetupFeedbackGrid()
        {
            dgvFeedBack.Columns.Clear();
            dgvFeedBack.AutoGenerateColumns = false;

            dgvFeedBack.Columns.Add("colFeedbackID", "ID");
            dgvFeedBack.Columns.Add("colTrainerName", "Trainer");
            dgvFeedBack.Columns.Add("colType", "Type");
            dgvFeedBack.Columns.Add("colDate", "Date");
            dgvFeedBack.Columns.Add("colStatus", "Status");

            dgvFeedBack.ReadOnly = true;
            dgvFeedBack.AllowUserToAddRows = false;
            dgvFeedBack.AllowUserToDeleteRows = false;
            dgvFeedBack.MultiSelect = false;
            dgvFeedBack.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFeedBack.RowHeadersVisible = false;
        }

        private void LoadFeedback(string filter)
        {
            dgvFeedBack.Rows.Clear();
            txtMessage.Clear();
            selectedFeedbackId = -1;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT
                        f.FeedbackID,
                        u.Name AS TrainerName,
                        f.FeedbackType,
                        f.DateSent,
                        f.Status
                    FROM Feedback f
                    INNER JOIN Trainers t ON f.TrainerID = t.TrainerID
                    INNER JOIN Users u ON t.UserID = u.UserID";

                if (filter == "Unread")
                    query += " WHERE f.Status = 'Unread'";
                else if (filter == "Read")
                    query += " WHERE f.Status = 'Read'";

                query += " ORDER BY f.FeedbackID";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dgvFeedBack.Rows.Add(
                        dr["FeedbackID"].ToString(),
                        dr["TrainerName"].ToString(),
                        dr["FeedbackType"].ToString(),
                        Convert.ToDateTime(dr["DateSent"]).ToString("dd/MM/yyyy"),
                        dr["Status"].ToString()
                    );
                }

                dr.Close();
            }
        }

        private void LoadFeedbackMessage(int feedbackId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Message FROM Feedback WHERE FeedbackID = @FeedbackID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FeedbackID", feedbackId);

                con.Open();
                object result = cmd.ExecuteScalar();

                txtMessage.Text = result != null ? result.ToString() : "";
            }
        }

        private void dgvFeedBack_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedFeedbackId = Convert.ToInt32(
                    dgvFeedBack.Rows[e.RowIndex].Cells["colFeedbackID"].Value
                );

                LoadFeedbackMessage(selectedFeedbackId);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadFeedback(cboFilter.SelectedItem?.ToString() ?? "All");
        }

        private void btnMarkRead_Click(object sender, EventArgs e)
        {
            if (selectedFeedbackId == -1)
            {
                MessageBox.Show(
                    "Please select a feedback record first.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Feedback SET Status = 'Read' WHERE FeedbackID = @FeedbackID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FeedbackID", selectedFeedbackId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadFeedback(cboFilter.SelectedItem?.ToString() ?? "All");
            LoadFeedbackMessage(selectedFeedbackId);

            MessageBox.Show(
                "Feedback marked as Read.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblMessage_Click(object sender, EventArgs e)
        {

        }
    }
}