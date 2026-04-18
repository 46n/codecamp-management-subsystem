namespace APUCC_Project.Forms.Trainer
{
    partial class TrainerEnrolledStudents
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            EnrolledStuedntsPanel = new Panel();
            dgvEnrolledStudents = new DataGridView();
            EnrolledStuedntsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEnrolledStudents).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(42, 55);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(457, 65);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Enrolled Students ";
            // 
            // EnrolledStuedntsPanel
            // 
            EnrolledStuedntsPanel.BackColor = Color.FromArgb(25, 25, 25);
            EnrolledStuedntsPanel.BorderStyle = BorderStyle.Fixed3D;
            EnrolledStuedntsPanel.Controls.Add(lblTitle);
            EnrolledStuedntsPanel.Location = new Point(0, 0);
            EnrolledStuedntsPanel.Name = "EnrolledStuedntsPanel";
            EnrolledStuedntsPanel.Size = new Size(1180, 176);
            EnrolledStuedntsPanel.TabIndex = 1;
            // 
            // dgvEnrolledStudents
            // 
            dgvEnrolledStudents.BorderStyle = BorderStyle.Fixed3D;
            dgvEnrolledStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEnrolledStudents.Location = new Point(40, 180);
            dgvEnrolledStudents.Name = "dgvEnrolledStudents";
            dgvEnrolledStudents.RowHeadersWidth = 82;
            dgvEnrolledStudents.Size = new Size(1080, 506);
            dgvEnrolledStudents.TabIndex = 2;
            // 
            // TrainerEnrolledStudents
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1180, 896);
            Controls.Add(dgvEnrolledStudents);
            Controls.Add(EnrolledStuedntsPanel);
            Name = "TrainerEnrolledStudents";
            Text = "TrainerEnrolledStudents";
            Load += TrainerEnrolledStudents_Load;
            EnrolledStuedntsPanel.ResumeLayout(false);
            EnrolledStuedntsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEnrolledStudents).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Panel EnrolledStuedntsPanel;
        private DataGridView dgvEnrolledStudents;
    }
}
