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
            EnrolledStudentsLebal = new Label();
            EnrolledStuedntsPanel = new Panel();
            dataGridView1 = new DataGridView();
            btnGoBackHome = new Button();
            EnrolledStuedntsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // EnrolledStudentsLebal
            // 
            EnrolledStudentsLebal.AutoSize = true;
            EnrolledStudentsLebal.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EnrolledStudentsLebal.Location = new Point(42, 55);
            EnrolledStudentsLebal.Name = "EnrolledStudentsLebal";
            EnrolledStudentsLebal.Size = new Size(410, 65);
            EnrolledStudentsLebal.TabIndex = 0;
            EnrolledStudentsLebal.Text = "Enrolled Students ";
            // 
            // EnrolledStuedntsPanel
            // 
            EnrolledStuedntsPanel.BackColor = SystemColors.Highlight;
            EnrolledStuedntsPanel.BorderStyle = BorderStyle.Fixed3D;
            EnrolledStuedntsPanel.Controls.Add(EnrolledStudentsLebal);
            EnrolledStuedntsPanel.Location = new Point(-20, -16);
            EnrolledStuedntsPanel.Name = "EnrolledStuedntsPanel";
            EnrolledStuedntsPanel.Size = new Size(1845, 176);
            EnrolledStuedntsPanel.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(40, 180);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(1088, 506);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnGoBackHome
            // 
            btnGoBackHome.BackColor = SystemColors.HotTrack;
            btnGoBackHome.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGoBackHome.Location = new Point(40, 712);
            btnGoBackHome.Name = "btnGoBackHome";
            btnGoBackHome.Size = new Size(358, 86);
            btnGoBackHome.TabIndex = 3;
            btnGoBackHome.Text = "Go Back ";
            btnGoBackHome.UseVisualStyleBackColor = false;
            btnGoBackHome.Click += button1_Click;
            // 
            // TrainerEnrolledStudents
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1830, 896);
            Controls.Add(btnGoBackHome);
            Controls.Add(dataGridView1);
            Controls.Add(EnrolledStuedntsPanel);
            Name = "TrainerEnrolledStudents";
            Text = "TrainerEnrolledStudents";
            Load += TrainerEnrolledStudents_Load;
            EnrolledStuedntsPanel.ResumeLayout(false);
            EnrolledStuedntsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label EnrolledStudentsLebal;
        private Panel EnrolledStuedntsPanel;
        private DataGridView dataGridView1;
        private Button btnGoBackHome;
    }
}