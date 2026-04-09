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
            cboFilter = new ComboBox();
            btnMarkRead = new Button();
            btnClose = new Button();
            txtMessage = new TextBox();
            lblMessage = new Label();
            dgvFeedBack = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvFeedBack).BeginInit();
            SuspendLayout();

            // lblShow
            lblShow.AutoSize = true;
            lblShow.Location = new Point(57, 29);
            lblShow.Margin = new Padding(4, 0, 4, 0);
            lblShow.Name = "lblShow";
            lblShow.Size = new Size(72, 32);
            lblShow.TabIndex = 0;
            lblShow.Text = "Show";

            // btnFilter
            btnFilter.Location = new Point(399, 27);
            btnFilter.Margin = new Padding(4);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(146, 44);
            btnFilter.TabIndex = 1;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;

            // cboFilter
            cboFilter.FormattingEnabled = true;
            cboFilter.Location = new Point(155, 27);
            cboFilter.Margin = new Padding(4);
            cboFilter.Name = "cboFilter";
            cboFilter.Size = new Size(235, 40);
            cboFilter.TabIndex = 2;

            // btnMarkRead
            btnMarkRead.Location = new Point(155, 502);
            btnMarkRead.Margin = new Padding(4);
            btnMarkRead.Name = "btnMarkRead";
            btnMarkRead.Size = new Size(146, 44);
            btnMarkRead.TabIndex = 3;
            btnMarkRead.Text = "Mark as Read";
            btnMarkRead.UseVisualStyleBackColor = true;
            btnMarkRead.Click += btnMarkRead_Click;

            // btnClose
            btnClose.Location = new Point(350, 502);
            btnClose.Margin = new Padding(4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(146, 44);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;

            // txtMessage
            txtMessage.BackColor = SystemColors.ButtonHighlight;
            txtMessage.Location = new Point(135, 370);
            txtMessage.Margin = new Padding(4);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.ReadOnly = true;
            txtMessage.Size = new Size(554, 96);
            txtMessage.TabIndex = 5;

            // lblMessage
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(123, 316);
            lblMessage.Margin = new Padding(4, 0, 4, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(221, 32);
            lblMessage.TabIndex = 6;
            lblMessage.Text = "Feedback Message:";

            // dgvFeedBack
            dgvFeedBack.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFeedBack.Location = new Point(67, 98);
            dgvFeedBack.Name = "dgvFeedBack";
            dgvFeedBack.RowHeadersWidth = 82;
            dgvFeedBack.Size = new Size(938, 212);
            dgvFeedBack.TabIndex = 7;
            dgvFeedBack.CellClick += dgvFeedBack_CellClick;

            // AdminTrainerFeedback
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 576);
            Controls.Add(dgvFeedBack);
            Controls.Add(lblMessage);
            Controls.Add(txtMessage);
            Controls.Add(btnClose);
            Controls.Add(btnMarkRead);
            Controls.Add(cboFilter);
            Controls.Add(btnFilter);
            Controls.Add(lblShow);
            Margin = new Padding(4);
            Name = "AdminTrainerFeedback";
            Text = "Admin Trainer Feedback";
            Load += AdminTrainerFeedback_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFeedBack).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblShow;
        private Button btnFilter;
        private ComboBox cboFilter;
        private Button btnMarkRead;
        private Button btnClose;
        private TextBox txtMessage;
        private Label lblMessage;
        private DataGridView dgvFeedBack;
        private DataGridView dgvFeedback;
    }
}