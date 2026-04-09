using System;
using System.Configuration;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace APUCC_Project.Forms.Trainer
{
    public partial class FeedBackForm1 : Form
    {
        private readonly string connStr =
            ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        // Temporary trainer id until you connect it to login
        private int trainerId = 1;

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
        }

        private void btnSendFeedback_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();

                    // 1. Get feedback type
                    string feedbackType = "";

                    if (chkFeedbackType.CheckedItems.Count > 0)
                    {
                        feedbackType = chkFeedbackType.CheckedItems[0].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Please select a feedback type.");
                        return;
                    }

                    // 2. Validate inputs
                    string trainerName = txtTrainerName.Text.Trim();

                    if (trainerName == "")
                    {
                        MessageBox.Show("Enter trainer name.");
                        return;
                    }

                    if (txtFeedback.Text.Trim() == "")
                    {
                        MessageBox.Show("Enter feedback.");
                        return;
                    }

                    // 3. Get TrainerID from DB
                    int trainerId = -1;

                    string query = @"
                SELECT T.TrainerID
                FROM Trainers T
                INNER JOIN Users U ON T.UserID = U.UserID
                WHERE U.Name = @Name";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", trainerName);

                        object result = cmd.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("Trainer not found.");
                            return;
                        }

                        trainerId = Convert.ToInt32(result);
                    }

                    // 🔍 DEBUG (IMPORTANT)
                    MessageBox.Show("TrainerID = " + trainerId);

                    // 4. Insert feedback
                    string insert = @"
                INSERT INTO Feedback (TrainerID, FeedbackType, Message)
                VALUES (@TrainerID, @Type, @Message)";

                    using (SqlCommand cmd = new SqlCommand(insert, con))
                    {
                        cmd.Parameters.AddWithValue("@TrainerID", trainerId);
                        cmd.Parameters.AddWithValue("@Type", feedbackType);
                        cmd.Parameters.AddWithValue("@Message", txtFeedback.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Feedback sent successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkGeneral_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}