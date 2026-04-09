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
            grpFilter.Location = new Point(40, 67);
            grpFilter.Margin = new Padding(4, 4, 4, 4);
            grpFilter.Name = "grpFilter";
            grpFilter.Padding = new Padding(4, 4, 4, 4);
            grpFilter.Size = new Size(984, 116);
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
            btnGenerate.Location = new Point(845, 44);
            btnGenerate.Margin = new Padding(4, 4, 4, 4);
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
            cboTrainer.Margin = new Padding(4, 4, 4, 4);
            cboTrainer.Name = "cboTrainer";
            cboTrainer.Size = new Size(235, 40);
            cboTrainer.TabIndex = 1;
            // 
            // cboMonth
            // 
            cboMonth.FormattingEnabled = true;
            cboMonth.Location = new Point(161, 44);
            cboMonth.Margin = new Padding(4, 4, 4, 4);
            cboMonth.Name = "cboMonth";
            cboMonth.Size = new Size(235, 40);
            cboMonth.TabIndex = 0;
            // 
            // lblPaidCountTitle
            // 
            lblPaidCountTitle.AutoSize = true;
            lblPaidCountTitle.Location = new Point(40, 227);
            lblPaidCountTitle.Margin = new Padding(4, 0, 4, 0);
            lblPaidCountTitle.Name = "lblPaidCountTitle";
            lblPaidCountTitle.Size = new Size(148, 32);
            lblPaidCountTitle.TabIndex = 1;
            lblPaidCountTitle.Text = "Paid Student";
            // 
            // lblTotalIncomeTitle
            // 
            lblTotalIncomeTitle.AutoSize = true;
            lblTotalIncomeTitle.Location = new Point(306, 227);
            lblTotalIncomeTitle.Margin = new Padding(4, 0, 4, 0);
            lblTotalIncomeTitle.Name = "lblTotalIncomeTitle";
            lblTotalIncomeTitle.Size = new Size(151, 32);
            lblTotalIncomeTitle.TabIndex = 2;
            lblTotalIncomeTitle.Text = "Total Income";
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(73, 684);
            btnPrint.Margin = new Padding(4, 4, 4, 4);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(131, 44);
            btnPrint.TabIndex = 5;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(294, 684);
            btnClose.Margin = new Padding(4, 4, 4, 4);
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
            gdvReport.Margin = new Padding(4, 4, 4, 4);
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
            // AdminMonthlyIncome
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1138, 763);
            Controls.Add(gdvReport);
            Controls.Add(btnClose);
            Controls.Add(btnPrint);
            Controls.Add(lblTotalIncomeTitle);
            Controls.Add(lblPaidCountTitle);
            Controls.Add(grpFilter);
            Margin = new Padding(4, 4, 4, 4);
            Name = "AdminMonthlyIncome";
            Text = "Admin Monthly Income";
            Load += AdminMonthlyIncome_Load;
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