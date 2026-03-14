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
            dataGridView1 = new DataGridView();
            ModuleColumn = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            ActionColumn = new DataGridViewButtonColumn();
            groupBox2 = new GroupBox();
            dataGridView2 = new DataGridView();
            InvoiceIDColumn = new DataGridViewTextBoxColumn();
            ModuleColumn2 = new DataGridViewTextBoxColumn();
            AmountColumn = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            DatePaidColumn = new DataGridViewTextBoxColumn();
            ReceiptColumn = new DataGridViewButtonColumn();
            OutstandingPaymentGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // OutstandingPaymentGroupBox
            // 
            OutstandingPaymentGroupBox.Controls.Add(dataGridView1);
            OutstandingPaymentGroupBox.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OutstandingPaymentGroupBox.ForeColor = Color.White;
            OutstandingPaymentGroupBox.Location = new Point(28, 26);
            OutstandingPaymentGroupBox.Name = "OutstandingPaymentGroupBox";
            OutstandingPaymentGroupBox.Size = new Size(1022, 268);
            OutstandingPaymentGroupBox.TabIndex = 1;
            OutstandingPaymentGroupBox.TabStop = false;
            OutstandingPaymentGroupBox.Text = "Outsranding Payment";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.FromArgb(42, 42, 42);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ModuleColumn, Column2, Column3, Column4, Column5, ActionColumn });
            dataGridView1.Location = new Point(8, 50);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(1004, 186);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
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
            Column4.HeaderText = "Fee";
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
            ActionColumn.Text = "Pay Online";
            ActionColumn.Width = 150;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView2);
            groupBox2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(28, 316);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1022, 258);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Payment History";
            // 
            // dataGridView2
            // 
            dataGridView2.BackgroundColor = Color.FromArgb(42, 42, 42);
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { InvoiceIDColumn, ModuleColumn2, AmountColumn, dataGridViewTextBoxColumn4, DatePaidColumn, ReceiptColumn });
            dataGridView2.Location = new Point(8, 50);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.RowHeadersWidth = 82;
            dataGridView2.Size = new Size(1004, 174);
            dataGridView2.TabIndex = 1;
            // 
            // InvoiceIDColumn
            // 
            InvoiceIDColumn.HeaderText = "InvoiceID";
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
            AmountColumn.HeaderText = "Amount ";
            AmountColumn.MinimumWidth = 10;
            AmountColumn.Name = "AmountColumn";
            AmountColumn.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Fee";
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
            ReceiptColumn.HeaderText = "Receipt";
            ReceiptColumn.MinimumWidth = 10;
            ReceiptColumn.Name = "ReceiptColumn";
            ReceiptColumn.Resizable = DataGridViewTriState.True;
            ReceiptColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            ReceiptColumn.Text = "Pay Online";
            ReceiptColumn.Width = 150;
            // 
            // StudentFeesForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(42, 42, 42);
            ClientSize = new Size(1302, 706);
            Controls.Add(groupBox2);
            Controls.Add(OutstandingPaymentGroupBox);
            Name = "StudentFeesForm";
            Text = "StudentFeesForm";
            OutstandingPaymentGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox OutstandingPaymentGroupBox;
        private DataGridView dataGridView1;
        private GroupBox groupBox2;
        private DataGridViewTextBoxColumn ModuleColumn;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewButtonColumn ActionColumn;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn InvoiceIDColumn;
        private DataGridViewTextBoxColumn ModuleColumn2;
        private DataGridViewTextBoxColumn AmountColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn DatePaidColumn;
        private DataGridViewButtonColumn ReceiptColumn;
    }
}