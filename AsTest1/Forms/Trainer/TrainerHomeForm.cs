using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace APUCC_Project.Forms.Trainer
{
    public partial class TrainerHomeForm : Form
    {

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

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvClassSchedule.Rows[e.RowIndex];

            txtModuleID.Text = row.Cells[0].Value?.ToString() ?? "";
            txtModuleName.Text = row.Cells[1].Value?.ToString() ?? "";
            txtClassTime.Text = row.Cells[3].Value?.ToString() ?? "";
            txtCharges.Text = row.Cells[4].Value?.ToString() ?? "";

            if (row.Cells[2].Value != null && row.Cells[2].Value != DBNull.Value)
                dtpClassDate.Value = Convert.ToDateTime(row.Cells[2].Value);
            else
                dtpClassDate.Value = DateTime.Today;
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            if (txtModuleID.Text == "" || txtModuleName.Text == "" || txtClassTime.Text == "" || txtCharges.Text == "")
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Add to database here

            MessageBox.Show("Class added successfully.");
            LoadClassSchedule();
            ClearFields();
        }

        private void updateClass_Click(object sender, EventArgs e)
        {
            if (txtModuleID.Text == "")
            {
                MessageBox.Show("Please select a class to update.");
                return;
            }

            MessageBox.Show("Class updated successfully.");
            LoadClassSchedule();
            ClearFields();
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
                MessageBox.Show("Class deleted successfully.");
                LoadClassSchedule();
                ClearFields();
            }
        }

        private void txtModuleID_TextChanged(object sender, EventArgs e)
        {

        }
        private void LoadClassSchedule()
        {
            // For now (no database yet), just leave it empty
            // Later we will load data into dgvClassSchedule
        }
        private void ClearFields()
        {
            txtModuleID.Clear();
            txtModuleName.Clear();
            txtClassTime.Clear();
            txtCharges.Clear();
            dtpClassDate.Value = DateTime.Today;
        }
    }
}