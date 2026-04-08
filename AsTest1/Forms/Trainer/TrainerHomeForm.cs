using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace APUCC_Project.Forms.Trainer
{
    public partial class TrainerHomeForm : Form
    {
        string connStr = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvClassSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvClassSchedule.Rows[e.RowIndex];

            txtModuleID.Text = row.Cells[0].Value?.ToString() ?? "";
            txtModuleName.Text = row.Cells[1].Value?.ToString() ?? "";

            if (row.Cells[2].Value != null && row.Cells[2].Value != DBNull.Value)
                dtpClassDate.Value = Convert.ToDateTime(row.Cells[2].Value);
            else
                dtpClassDate.Value = DateTime.Today;

            txtClassTime.Text = row.Cells[3].Value?.ToString() ?? "";
            txtCharges.Text = row.Cells[4].Value?.ToString() ?? "";
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            if (txtModuleID.Text == "" || txtModuleName.Text == "" || txtClassTime.Text == "" || txtCharges.Text == "")
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    string query = @"INSERT INTO ClassSchedule
                                    (ModuleId, ModuleName, ClassDate, ClassTime, Charges)
                                    VALUES
                                    (@ModuleId, @ModuleName, @ClassDate, @ClassTime, @Charges)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ModuleId", txtModuleID.Text);
                        cmd.Parameters.AddWithValue("@ModuleName", txtModuleName.Text);
                        cmd.Parameters.AddWithValue("@ClassDate", dtpClassDate.Value.Date);
                        cmd.Parameters.AddWithValue("@ClassTime", txtClassTime.Text);
                        cmd.Parameters.AddWithValue("@Charges", decimal.Parse(txtCharges.Text));

                        con.Open();
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
            if (txtModuleID.Text == "")
            {
                MessageBox.Show("Please select a class to update.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    string query = @"UPDATE ClassSchedule
                                     SET ModuleName = @ModuleName,
                                         ClassDate = @ClassDate,
                                         ClassTime = @ClassTime,
                                         Charges = @Charges
                                     WHERE ModuleId = @ModuleId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ModuleId", txtModuleID.Text);
                        cmd.Parameters.AddWithValue("@ModuleName", txtModuleName.Text);
                        cmd.Parameters.AddWithValue("@ClassDate", dtpClassDate.Value.Date);
                        cmd.Parameters.AddWithValue("@ClassTime", txtClassTime.Text);
                        cmd.Parameters.AddWithValue("@Charges", decimal.Parse(txtCharges.Text));

                        con.Open();
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
            if (txtModuleID.Text == "")
            {
                MessageBox.Show("Please select a class to delete.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this class?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connStr))
                    {
                        string query = "DELETE FROM ClassSchedule WHERE ModuleId = @ModuleId";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@ModuleId", txtModuleID.Text);

                            con.Open();
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
        }

        private void txtModuleID_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadClassSchedule()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    string query = "SELECT ModuleId, ModuleName, ClassDate, ClassTime, Charges FROM ClassSchedule";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvClassSchedule.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Error: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            txtModuleID.Clear();
            txtModuleName.Clear();
            txtClassTime.Clear();
            txtCharges.Clear();
            dtpClassDate.Value = DateTime.Today;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}