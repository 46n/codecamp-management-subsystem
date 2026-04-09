namespace APUCC_Project.Forms.Admin
{
    partial class AdminTrainerFeedback
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
            lblShow = new Label();
            btnFilter = new Button();
            comboBox1 = new ComboBox();
            btnMarkRead = new Button();
            btnClose = new Button();
            txtMessage = new TextBox();
            lblMessage = new Label();
            dgvFeedBack = new DataGridView();
            colFeedbackID = new DataGridViewTextBoxColumn();
            colTrainerName = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvFeedBack).BeginInit();
            SuspendLayout();
            // 
            // lblShow
            // 
            lblShow.AutoSize = true;
            lblShow.Location = new Point(44, 23);
            lblShow.Name = "lblShow";
            lblShow.Size = new Size(56, 25);
            lblShow.TabIndex = 0;
            lblShow.Text = "Show";
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(307, 21);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(112, 34);
            btnFilter.TabIndex = 1;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(119, 21);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 33);
            comboBox1.TabIndex = 2;
            // 
            // btnMarkRead
            // 
            btnMarkRead.Location = new Point(119, 392);
            btnMarkRead.Name = "btnMarkRead";
            btnMarkRead.Size = new Size(112, 34);
            btnMarkRead.TabIndex = 3;
            btnMarkRead.Text = "Mark as Read";
            btnMarkRead.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(269, 392);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(112, 34);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // txtMessage
            // 
            txtMessage.BackColor = SystemColors.ButtonHighlight;
            txtMessage.Location = new Point(104, 289);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.ReadOnly = true;
            txtMessage.Size = new Size(427, 76);
            txtMessage.TabIndex = 5;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(95, 247);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(166, 25);
            lblMessage.TabIndex = 6;
            lblMessage.Text = "Feedback Message:";
            // 
            // dgvFeedBack
            // 
            dgvFeedBack.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFeedBack.Columns.AddRange(new DataGridViewColumn[] { colFeedbackID, colTrainerName, colType, colDate, colStatus });
            dgvFeedBack.Location = new Point(-2, 78);
            dgvFeedBack.Name = "dgvFeedBack";
            dgvFeedBack.RowHeadersWidth = 62;
            dgvFeedBack.Size = new Size(790, 194);
            dgvFeedBack.TabIndex = 7;
            // 
            // colFeedbackID
            // 
            colFeedbackID.HeaderText = "ID";
            colFeedbackID.MinimumWidth = 8;
            colFeedbackID.Name = "colFeedbackID";
            colFeedbackID.ReadOnly = true;
            colFeedbackID.Resizable = DataGridViewTriState.True;
            colFeedbackID.Width = 150;
            // 
            // colTrainerName
            // 
            colTrainerName.HeaderText = "Trainer";
            colTrainerName.MinimumWidth = 8;
            colTrainerName.Name = "colTrainerName";
            colTrainerName.ReadOnly = true;
            colTrainerName.Width = 150;
            // 
            // colType
            // 
            colType.HeaderText = "Type";
            colType.MinimumWidth = 8;
            colType.Name = "colType";
            colType.ReadOnly = true;
            colType.Width = 150;
            // 
            // colDate
            // 
            colDate.HeaderText = "Date";
            colDate.MinimumWidth = 8;
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            colDate.Resizable = DataGridViewTriState.True;
            colDate.Width = 150;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 8;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            colStatus.Width = 150;
            // 
            // AdminTrainerFeedback
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvFeedBack);
            Controls.Add(lblMessage);
            Controls.Add(txtMessage);
            Controls.Add(btnClose);
            Controls.Add(btnMarkRead);
            Controls.Add(comboBox1);
            Controls.Add(btnFilter);
            Controls.Add(lblShow);
            Name = "AdminTrainerFeedback";
            Text = "Admin Trainer Feedback";
            ((System.ComponentModel.ISupportInitialize)dgvFeedBack).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblShow;
        private Button btnFilter;
        private ComboBox comboBox1;
        private Button btnMarkRead;
        private Button btnClose;
        private TextBox txtMessage;
        private Label lblMessage;
        private DataGridView dgvFeedBack;
        private DataGridViewTextBoxColumn colFeedbackID;
        private DataGridViewTextBoxColumn colTrainerName;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colStatus;
    }
}