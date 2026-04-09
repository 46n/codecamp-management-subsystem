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
            grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gdvReport).BeginInit();
            SuspendLayout();
            // 
            // grpFilter
            // 
            grpFilter.Controls.Add(lblTrainer);
            grpFilter.Controls.Add(lblMonth);
            grpFilter.Controls.Add(btnGenerate);
            grpFilter.Controls.Add(cboTrainer);
            grpFilter.Controls.Add(cboMonth);
            grpFilter.Location = new Point(31, 52);
            grpFilter.Name = "grpFilter";
            grpFilter.Size = new Size(757, 91);
            grpFilter.TabIndex = 0;
            grpFilter.TabStop = false;
            grpFilter.Text = "Filter";
            // 
            // lblTrainer
            // 
            lblTrainer.AutoSize = true;
            lblTrainer.Location = new Point(364, 38);
            lblTrainer.Name = "lblTrainer";
            lblTrainer.Size = new Size(63, 25);
            lblTrainer.TabIndex = 4;
            lblTrainer.Text = "Trainer";
            // 
            // lblMonth
            // 
            lblMonth.AutoSize = true;
            lblMonth.Location = new Point(41, 37);
            lblMonth.Name = "lblMonth";
            lblMonth.Size = new Size(65, 25);
            lblMonth.TabIndex = 3;
            lblMonth.Text = "Month";
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(650, 34);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(101, 34);
            btnGenerate.TabIndex = 2;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = true;
            // 
            // cboTrainer
            // 
            cboTrainer.FormattingEnabled = true;
            cboTrainer.Location = new Point(458, 34);
            cboTrainer.Name = "cboTrainer";
            cboTrainer.Size = new Size(182, 33);
            cboTrainer.TabIndex = 1;
            // 
            // cboMonth
            // 
            cboMonth.FormattingEnabled = true;
            cboMonth.Location = new Point(124, 34);
            cboMonth.Name = "cboMonth";
            cboMonth.Size = new Size(182, 33);
            cboMonth.TabIndex = 0;
            // 
            // lblPaidCountTitle
            // 
            lblPaidCountTitle.AutoSize = true;
            lblPaidCountTitle.Location = new Point(31, 177);
            lblPaidCountTitle.Name = "lblPaidCountTitle";
            lblPaidCountTitle.Size = new Size(111, 25);
            lblPaidCountTitle.TabIndex = 1;
            lblPaidCountTitle.Text = "Paid Student";
            // 
            // lblTotalIncomeTitle
            // 
            lblTotalIncomeTitle.AutoSize = true;
            lblTotalIncomeTitle.Location = new Point(235, 177);
            lblTotalIncomeTitle.Name = "lblTotalIncomeTitle";
            lblTotalIncomeTitle.Size = new Size(113, 25);
            lblTotalIncomeTitle.TabIndex = 2;
            lblTotalIncomeTitle.Text = "Total Income";
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(56, 534);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(101, 34);
            btnPrint.TabIndex = 5;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(226, 534);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(101, 34);
            btnClose.TabIndex = 6;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // gdvReport
            // 
            gdvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gdvReport.Columns.AddRange(new DataGridViewColumn[] { colTrainerName, colModule, colLevel, colStudentPaid, colFeePerStudent, colTotal });
            gdvReport.Location = new Point(-16, 264);
            gdvReport.Name = "gdvReport";
            gdvReport.RowHeadersWidth = 62;
            gdvReport.Size = new Size(879, 166);
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
            // AdminMonthlyIncome
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 596);
            Controls.Add(gdvReport);
            Controls.Add(btnClose);
            Controls.Add(btnPrint);
            Controls.Add(lblTotalIncomeTitle);
            Controls.Add(lblPaidCountTitle);
            Controls.Add(grpFilter);
            Name = "AdminMonthlyIncome";
            Text = "Admin Monthly Income";
            grpFilter.ResumeLayout(false);
            grpFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gdvReport).EndInit();
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
    }
}