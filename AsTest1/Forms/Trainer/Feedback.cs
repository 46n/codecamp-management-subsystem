using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace APUCC_Project.Forms.Trainer
{
    public partial class FeedBackForm1 : Form
    {
        private const string MessagePlaceholder = "Type here.....";
        private readonly string connStr =
            ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        private int trainerId = 1; // temporary default until full login is connected

        public FeedBackForm1()
        {
            InitializeComponent();
        }

        public FeedBackForm1(int loggedInTrainerId)
        {
            InitializeComponent();
            trainerId = loggedInTrainerId;
        }

        private void FeedBackForm_Load(object sender, EventArgs e)
        {
            txtTrainerName.ReadOnly = true;
            LoadTrainerName();
            ApplyMessagePlaceholder();
        }

        private void LoadTrainerName()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();

                    string query = @"
                        SELECT U.Name
                        FROM Trainers T
                        INNER JOIN Users U ON T.UserID = U.UserID
                        WHERE T.TrainerID = @TrainerID";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@TrainerID", trainerId);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                            txtTrainerName.Text = result.ToString();
                        else
                            txtTrainerName.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading trainer name: " + ex.Message);
            }
        }

        private void btnSendFeedback_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateFeedbackInput())
                    return;

                string feedbackType = chkFeedbackType.CheckedItems[0].ToString();
                string message = txtMessage.Text.Trim();

                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();

                    string insertQuery = @"
                        INSERT INTO Feedback (TrainerID, FeedbackType, Message)
                        VALUES (@TrainerID, @FeedbackType, @Message)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@TrainerID", trainerId);
                        cmd.Parameters.AddWithValue("@FeedbackType", feedbackType);
                        cmd.Parameters.AddWithValue("@Message", message);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Feedback sent successfully.");

                ClearFields();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private bool ValidateFeedbackInput()
        {
            if (trainerId <= 0)
            {
                MessageBox.Show("Invalid trainer account.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTrainerName.Text))
            {
                MessageBox.Show("Trainer name could not be loaded.");
                return false;
            }

            if (chkFeedbackType.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select a feedback type.");
                return false;
            }

            if (chkFeedbackType.CheckedItems.Count > 1)
            {
                MessageBox.Show("Please select only one feedback type.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMessage.Text) || txtMessage.Text == MessagePlaceholder)
            {
                MessageBox.Show("Please enter feedback.");
                txtMessage.Focus();
                return false;
            }

            if (txtMessage.Text.Trim().Length < 5)
            {
                MessageBox.Show("Feedback is too short.");
                txtMessage.Focus();
                return false;
            }

            if (txtMessage.Text.Trim().Length > 500)
            {
                MessageBox.Show("Feedback must not exceed 500 characters.");
                txtMessage.Focus();
                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            txtMessage.Clear();
            ApplyMessagePlaceholder();

            for (int i = 0; i < chkFeedbackType.Items.Count; i++)
            {
                chkFeedbackType.SetItemChecked(i, false);
            }
        }

        private void txtMessage_Enter(object sender, EventArgs e)
        {
            if (txtMessage.Text == MessagePlaceholder)
            {
                txtMessage.Text = string.Empty;
                txtMessage.ForeColor = SystemColors.WindowText;
            }
        }

        private void txtMessage_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                ApplyMessagePlaceholder();
            }
        }

        private void ApplyMessagePlaceholder()
        {
            txtMessage.Text = MessagePlaceholder;
            txtMessage.ForeColor = SystemColors.GrayText;
        }

        private void lblFeedbackType_Click(object sender, EventArgs e)
        {

        }
    }
}
