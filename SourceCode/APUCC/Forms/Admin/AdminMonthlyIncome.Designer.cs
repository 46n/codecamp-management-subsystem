namespace APUCC_Project.Forms.Admin
{
    partial class AdminMonthlyIncome
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
            grpFilter = new GroupBox();
            lblTrainer = new Label();
            lblMonth = new Label();
            btnGenerate = new Button();
            cboTrainer = new ComboBox();
            cboMonth = new ComboBox();
            lblPaidCountTitle = new Label();
            lblTotalIncomeTitle = new Label();
            btnPrint = new Button();
            btnClose = new Button();
            gdvReport = new DataGridView();
            colTrainerName = new DataGridViewTextBoxColumn();
            colModule = new DataGridViewTextBoxColumn();
            colLevel = new DataGridViewTextBoxColumn();
            colStudentPaid = new DataGridViewTextBoxColumn();
            colFeePerStudent = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            dgvReport = new DataGridView();
            panel1 = new Panel();
            lblAdminMonthlyIncome = new Label();
            grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gdvReport).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // grpFilter
            // 
            grpFilter.Controls.Add(lblTrainer);
            grpFilter.Controls.Add(lblMonth);
            grpFilter.Controls.Add(btnGenerate);
            grpFilter.Controls.Add(cboTrainer);
            grpFilter.Controls.Add(cboMonth);
            grpFilter.Location = new Point(74, 214);
            grpFilter.Margin = new Padding(4);
            grpFilter.Name = "grpFilter";
            grpFilter.Padding = new Padding(4);
            grpFilter.Size = new Size(1030, 116);
            grpFilter.TabIndex = 0;
            grpFilter.TabStop = false;
            grpFilter.Text = "Filter";
            // 
            // lblTrainer
            // 
            lblTrainer.AutoSize = true;
            lblTrainer.Location = new Point(473, 49);
            lblTrainer.Margin = new Padding(4, 0, 4, 0);
            lblTrainer.Name = "lblTrainer";
            lblTrainer.Size = new Size(86, 32);
            lblTrainer.TabIndex = 4;
            lblTrainer.Text = "Trainer";
            // 
            // lblMonth
            // 
            lblMonth.AutoSize = true;
            lblMonth.Location = new Point(53, 47);
            lblMonth.Margin = new Padding(4, 0, 4, 0);
            lblMonth.Name = "lblMonth";
            lblMonth.Size = new Size(86, 32);
            lblMonth.TabIndex = 3;
            lblMonth.Text = "Month";
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(878, 44);
            btnGenerate.Margin = new Padding(4);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(131, 44);
            btnGenerate.TabIndex = 2;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = true;
            // 
            // cboTrainer
            // 
            cboTrainer.FormattingEnabled = true;
            cboTrainer.Location = new Point(595, 44);
            cboTrainer.Margin = new Padding(4);
            cboTrainer.Name = "cboTrainer";
            cboTrainer.Size = new Size(235, 40);
            cboTrainer.TabIndex = 1;
            // 
            // cboMonth
            // 
            cboMonth.FormattingEnabled = true;
            cboMonth.Location = new Point(161, 44);
            cboMonth.Margin = new Padding(4);
            cboMonth.Name = "cboMonth";
            cboMonth.Size = new Size(235, 40);
            cboMonth.TabIndex = 0;
            // 
            // lblPaidCountTitle
            // 
            lblPaidCountTitle.AutoSize = true;
            lblPaidCountTitle.Location = new Point(74, 360);
            lblPaidCountTitle.Margin = new Padding(4, 0, 4, 0);
            lblPaidCountTitle.Name = "lblPaidCountTitle";
            lblPaidCountTitle.Size = new Size(148, 32);
            lblPaidCountTitle.TabIndex = 1;
            lblPaidCountTitle.Text = "Paid Student";
            // 
            // lblTotalIncomeTitle
            // 
            lblTotalIncomeTitle.AutoSize = true;
            lblTotalIncomeTitle.Location = new Point(336, 360);
            lblTotalIncomeTitle.Margin = new Padding(4, 0, 4, 0);
            lblTotalIncomeTitle.Name = "lblTotalIncomeTitle";
            lblTotalIncomeTitle.Size = new Size(151, 32);
            lblTotalIncomeTitle.TabIndex = 2;
            lblTotalIncomeTitle.Text = "Total Income";
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(74, 802);
            btnPrint.Margin = new Padding(4);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(131, 44);
            btnPrint.TabIndex = 5;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(246, 802);
            btnClose.Margin = new Padding(4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(131, 44);
            btnClose.TabIndex = 6;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // gdvReport
            // 
            gdvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gdvReport.Columns.AddRange(new DataGridViewColumn[] { colTrainerName, colModule, colLevel, colStudentPaid, colFeePerStudent, colTotal });
            gdvReport.Location = new Point(-21, 338);
            gdvReport.Margin = new Padding(4);
            gdvReport.Name = "gdvReport";
            gdvReport.RowHeadersWidth = 62;
            gdvReport.Size = new Size(1143, 212);
            gdvReport.TabIndex = 7;
            // 
            // colTrainerName
            // 
            colTrainerName.FillWeight = 30F;
            colTrainerName.HeaderText = "Trainer";
            colTrainerName.MinimumWidth = 8;
            colTrainerName.Name = "colTrainerName";
            colTrainerName.ReadOnly = true;
            colTrainerName.Width = 150;
            // 
            // colModule
            // 
            colModule.FillWeight = 30F;
            colModule.HeaderText = "Module";
            colModule.MinimumWidth = 8;
            colModule.Name = "colModule";
            colModule.ReadOnly = true;
            colModule.Width = 150;
            // 
            // colLevel
            // 
            colLevel.FillWeight = 30F;
            colLevel.HeaderText = "Level";
            colLevel.MinimumWidth = 8;
            colLevel.Name = "colLevel";
            colLevel.ReadOnly = true;
            colLevel.Width = 150;
            // 
            // colStudentPaid
            // 
            colStudentPaid.FillWeight = 15F;
            colStudentPaid.HeaderText = "Student Paid";
            colStudentPaid.MinimumWidth = 8;
            colStudentPaid.Name = "colStudentPaid";
            colStudentPaid.ReadOnly = true;
            colStudentPaid.Width = 150;
            // 
            // colFeePerStudent
            // 
            colFeePerStudent.FillWeight = 30F;
            colFeePerStudent.HeaderText = "Fee/Student";
            colFeePerStudent.MinimumWidth = 8;
            colFeePerStudent.Name = "colFeePerStudent";
            colFeePerStudent.ReadOnly = true;
            colFeePerStudent.Width = 150;
            // 
            // colTotal
            // 
            colTotal.FillWeight = 35F;
            colTotal.HeaderText = "Total";
            colTotal.MinimumWidth = 8;
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            colTotal.Width = 150;
            // 
            // dgvReport
            // 
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReport.Location = new Point(74, 426);
            dgvReport.Name = "dgvReport";
            dgvReport.RowHeadersWidth = 82;
            dgvReport.Size = new Size(1030, 346);
            dgvReport.TabIndex = 7;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(25, 25, 25);
            panel1.Controls.Add(lblAdminMonthlyIncome);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1180, 182);
            panel1.TabIndex = 8;
            // 
            // lblAdminMonthlyIncome
            // 
            lblAdminMonthlyIncome.AutoSize = true;
            lblAdminMonthlyIncome.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAdminMonthlyIncome.ForeColor = Color.White;
            lblAdminMonthlyIncome.Location = new Point(48, 56);
            lblAdminMonthlyIncome.Name = "lblAdminMonthlyIncome";
            lblAdminMonthlyIncome.Size = new Size(415, 65);
            lblAdminMonthlyIncome.TabIndex = 0;
            lblAdminMonthlyIncome.Text = "Monthly Income";
            // 
            // AdminMonthlyIncome
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1180, 861);
            Controls.Add(panel1);
            Controls.Add(dgvReport);
            Controls.Add(btnClose);
            Controls.Add(btnPrint);
            Controls.Add(lblTotalIncomeTitle);
            Controls.Add(lblPaidCountTitle);
            Controls.Add(grpFilter);
            Margin = new Padding(4);
            Name = "AdminMonthlyIncome";
            Text = "Admin Monthly Income";
            Load += AdminMonthlyIncome_Load;
            grpFilter.ResumeLayout(false);
            grpFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gdvReport).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpFilter;
        private Button btnGenerate;
        private ComboBox cboTrainer;
        private ComboBox cboMonth;
        private Label lblTrainer;
        private Label lblMonth;
        private Label lblPaidCountTitle;
        private Label lblTotalIncomeTitle;
        private Button btnPrint;
        private Button btnClose;
        private DataGridView gdvReport;
        private DataGridViewTextBoxColumn colTrainerName;
        private DataGridViewTextBoxColumn colModule;
        private DataGridViewTextBoxColumn colLevel;
        private DataGridViewTextBoxColumn colStudentPaid;
        private DataGridViewTextBoxColumn colFeePerStudent;
        private DataGridViewTextBoxColumn colTotal;
        private DataGridView dgvReport;
        private Panel panel1;
        private Label lblAdminMonthlyIncome;
    }
}
