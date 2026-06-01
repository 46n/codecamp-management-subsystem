namespace APUCC_Project.Forms.Student
{
    partial class StudentFeesForm
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
            OutstandingPaymentGroupBox = new GroupBox();
            dgvOutstandingFees = new DataGridView();
            InvoiceIDHiddenColumn = new DataGridViewTextBoxColumn();
            ModuleColumn = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            ActionColumn = new DataGridViewButtonColumn();
            groupBox2 = new GroupBox();
            dgvPaymentHistory = new DataGridView();
            InvoiceIDColumn = new DataGridViewTextBoxColumn();
            ModuleColumn2 = new DataGridViewTextBoxColumn();
            AmountColumn = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            DatePaidColumn = new DataGridViewTextBoxColumn();
            ReceiptColumn = new DataGridViewButtonColumn();
            OutstandingPaymentGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOutstandingFees).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPaymentHistory).BeginInit();
            SuspendLayout();
            // 
            // OutstandingPaymentGroupBox
            // 
            OutstandingPaymentGroupBox.Controls.Add(dgvOutstandingFees);
            OutstandingPaymentGroupBox.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OutstandingPaymentGroupBox.ForeColor = Color.Black;
            OutstandingPaymentGroupBox.Location = new Point(12, 12);
            OutstandingPaymentGroupBox.Name = "OutstandingPaymentGroupBox";
            OutstandingPaymentGroupBox.Size = new Size(1022, 268);
            OutstandingPaymentGroupBox.TabIndex = 1;
            OutstandingPaymentGroupBox.TabStop = false;
            OutstandingPaymentGroupBox.Text = "Outstanding Fees";
            // 
            // dgvOutstandingFees
            // 
            dgvOutstandingFees.BackgroundColor = Color.White;
            dgvOutstandingFees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOutstandingFees.Columns.AddRange(new DataGridViewColumn[] { InvoiceIDHiddenColumn, ModuleColumn, Column2, Column3, Column4, Column5, ActionColumn });
            dgvOutstandingFees.Location = new Point(8, 50);
            dgvOutstandingFees.Name = "dgvOutstandingFees";
            dgvOutstandingFees.RowHeadersVisible = false;
            dgvOutstandingFees.RowHeadersWidth = 82;
            dgvOutstandingFees.Size = new Size(1004, 186);
            dgvOutstandingFees.TabIndex = 0;
            dgvOutstandingFees.CellContentClick += dataGridView1_CellContentClick;
            // 
            // InvoiceIDHiddenColumn
            // 
            InvoiceIDHiddenColumn.HeaderText = "InvoiceID";
            InvoiceIDHiddenColumn.MinimumWidth = 10;
            InvoiceIDHiddenColumn.Name = "InvoiceIDHiddenColumn";
            InvoiceIDHiddenColumn.Visible = false;
            InvoiceIDHiddenColumn.Width = 200;
            // 
            // ModuleColumn
            // 
            ModuleColumn.HeaderText = "Module";
            ModuleColumn.MinimumWidth = 10;
            ModuleColumn.Name = "ModuleColumn";
            ModuleColumn.Width = 200;
            // 
            // Column2
            // 
            Column2.HeaderText = "Level";
            Column2.MinimumWidth = 10;
            Column2.Name = "Column2";
            Column2.Width = 200;
            // 
            // Column3
            // 
            Column3.HeaderText = "Trainer";
            Column3.MinimumWidth = 10;
            Column3.Name = "Column3";
            Column3.Width = 150;
            // 
            // Column4
            // 
            Column4.HeaderText = "Amount";
            Column4.MinimumWidth = 10;
            Column4.Name = "Column4";
            Column4.Width = 150;
            // 
            // Column5
            // 
            Column5.HeaderText = "Status";
            Column5.MinimumWidth = 10;
            Column5.Name = "Column5";
            Column5.Width = 150;
            // 
            // ActionColumn
            // 
            ActionColumn.HeaderText = "Action";
            ActionColumn.MinimumWidth = 10;
            ActionColumn.Name = "ActionColumn";
            ActionColumn.Resizable = DataGridViewTriState.True;
            ActionColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            ActionColumn.Text = "Pay Now";
            ActionColumn.Width = 150;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvPaymentHistory);
            groupBox2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = Color.Black;
            groupBox2.Location = new Point(12, 302);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1022, 258);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Payment History";
            // 
            // dgvPaymentHistory
            // 
            dgvPaymentHistory.BackgroundColor = Color.White;
            dgvPaymentHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPaymentHistory.Columns.AddRange(new DataGridViewColumn[] { InvoiceIDColumn, ModuleColumn2, AmountColumn, dataGridViewTextBoxColumn4, DatePaidColumn, ReceiptColumn });
            dgvPaymentHistory.Location = new Point(8, 50);
            dgvPaymentHistory.Name = "dgvPaymentHistory";
            dgvPaymentHistory.RowHeadersVisible = false;
            dgvPaymentHistory.RowHeadersWidth = 82;
            dgvPaymentHistory.Size = new Size(1004, 174);
            dgvPaymentHistory.TabIndex = 1;
            // 
            // InvoiceIDColumn
            // 
            InvoiceIDColumn.HeaderText = "Invoice";
            InvoiceIDColumn.MinimumWidth = 10;
            InvoiceIDColumn.Name = "InvoiceIDColumn";
            InvoiceIDColumn.Width = 200;
            // 
            // ModuleColumn2
            // 
            ModuleColumn2.HeaderText = "Module";
            ModuleColumn2.MinimumWidth = 10;
            ModuleColumn2.Name = "ModuleColumn2";
            ModuleColumn2.Width = 200;
            // 
            // AmountColumn
            // 
            AmountColumn.HeaderText = "Amount Paid";
            AmountColumn.MinimumWidth = 10;
            AmountColumn.Name = "AmountColumn";
            AmountColumn.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Method";
            dataGridViewTextBoxColumn4.MinimumWidth = 10;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 150;
            // 
            // DatePaidColumn
            // 
            DatePaidColumn.HeaderText = "Paid Date";
            DatePaidColumn.MinimumWidth = 10;
            DatePaidColumn.Name = "DatePaidColumn";
            DatePaidColumn.Width = 150;
            // 
            // ReceiptColumn
            // 
            ReceiptColumn.HeaderText = "Status";
            ReceiptColumn.MinimumWidth = 10;
            ReceiptColumn.Name = "ReceiptColumn";
            ReceiptColumn.Resizable = DataGridViewTriState.True;
            ReceiptColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            ReceiptColumn.Text = "Paid";
            ReceiptColumn.Width = 150;
            // 
            // StudentFeesForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1302, 706);
            Controls.Add(groupBox2);
            Controls.Add(OutstandingPaymentGroupBox);
            Name = "StudentFeesForm";
            Text = "StudentFeesForm";
            OutstandingPaymentGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOutstandingFees).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPaymentHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox OutstandingPaymentGroupBox;
        private DataGridView dgvOutstandingFees;
        private GroupBox groupBox2;
        private DataGridViewTextBoxColumn InvoiceIDHiddenColumn;
        private DataGridViewTextBoxColumn ModuleColumn;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewButtonColumn ActionColumn;
        private DataGridView dgvPaymentHistory;
        private DataGridViewTextBoxColumn InvoiceIDColumn;
        private DataGridViewTextBoxColumn ModuleColumn2;
        private DataGridViewTextBoxColumn AmountColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn DatePaidColumn;
        private DataGridViewButtonColumn ReceiptColumn;
    }
}
