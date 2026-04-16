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
            pnlMain = new Panel();
            lblTrainerFeedback = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvFeedBack).BeginInit();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // lblShow
            // 
            lblShow.AutoSize = true;
            lblShow.Location = new Point(83, 237);
            lblShow.Margin = new Padding(4, 0, 4, 0);
            lblShow.Name = "lblShow";
            lblShow.Size = new Size(72, 32);
            lblShow.TabIndex = 0;
            lblShow.Text = "Show";
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(425, 235);
            btnFilter.Margin = new Padding(4);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(146, 44);
            btnFilter.TabIndex = 1;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // cboFilter
            // 
            cboFilter.FormattingEnabled = true;
            cboFilter.Location = new Point(181, 235);
            cboFilter.Margin = new Padding(4);
            cboFilter.Name = "cboFilter";
            cboFilter.Size = new Size(235, 40);
            cboFilter.TabIndex = 2;
            // 
            // btnMarkRead
            // 
            btnMarkRead.Location = new Point(133, 764);
            btnMarkRead.Margin = new Padding(4);
            btnMarkRead.Name = "btnMarkRead";
            btnMarkRead.Size = new Size(146, 44);
            btnMarkRead.TabIndex = 3;
            btnMarkRead.Text = "Mark as Read";
            btnMarkRead.UseVisualStyleBackColor = true;
            btnMarkRead.Click += btnMarkRead_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(328, 764);
            btnClose.Margin = new Padding(4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(146, 44);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // txtMessage
            // 
            txtMessage.BackColor = SystemColors.ButtonHighlight;
            txtMessage.Location = new Point(113, 632);
            txtMessage.Margin = new Padding(4);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.ReadOnly = true;
            txtMessage.Size = new Size(554, 96);
            txtMessage.TabIndex = 5;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(101, 578);
            lblMessage.Margin = new Padding(4, 0, 4, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(221, 32);
            lblMessage.TabIndex = 6;
            lblMessage.Text = "Feedback Message:";
            // 
            // dgvFeedBack
            // 
            dgvFeedBack.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFeedBack.Location = new Point(93, 306);
            dgvFeedBack.Name = "dgvFeedBack";
            dgvFeedBack.RowHeadersWidth = 82;
            dgvFeedBack.Size = new Size(1162, 254);
            dgvFeedBack.TabIndex = 7;
            dgvFeedBack.CellClick += dgvFeedBack_CellClick;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(25, 25, 25);
            pnlMain.Controls.Add(lblTrainerFeedback);
            pnlMain.Location = new Point(-13, -6);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1332, 182);
            pnlMain.TabIndex = 8;
            // 
            // lblTrainerFeedback
            // 
            lblTrainerFeedback.AutoSize = true;
            lblTrainerFeedback.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTrainerFeedback.ForeColor = Color.White;
            lblTrainerFeedback.Location = new Point(76, 56);
            lblTrainerFeedback.Name = "lblTrainerFeedback";
            lblTrainerFeedback.Size = new Size(434, 65);
            lblTrainerFeedback.TabIndex = 0;
            lblTrainerFeedback.Text = "Trainer Feedback";
            // 
            // AdminTrainerFeedback
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1316, 828);
            Controls.Add(pnlMain);
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
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
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
        private Panel pnlMain;
        private Label lblTrainerFeedback;
    }
}