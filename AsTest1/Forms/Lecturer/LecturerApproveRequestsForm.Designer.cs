namespace APUCC_Project.Forms.Lecturer
{
    partial class LecturerApproveRequestsForm
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
            cboShowRequests = new ComboBox();
            lblShow = new Label();
            btnFilter = new Button();
            dgvRequests = new DataGridView();
            grpSelectedRequestDetails = new GroupBox();
            txtStudent = new TextBox();
            txtModule = new TextBox();
            txtTPNumber = new TextBox();
            txtLevel = new TextBox();
            lblStudent = new Label();
            lblModule = new Label();
            lblTPNumber = new Label();
            lblLevel = new Label();
            btnApprove = new Button();
            btnReject = new Button();
            btnRerfesh = new Button();
            btnClose = new Button();
            lblStatus = new Label();
            lblFormStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).BeginInit();
            grpSelectedRequestDetails.SuspendLayout();
            SuspendLayout();
            // 
            // cboShowRequests
            // 
            cboShowRequests.FormattingEnabled = true;
            cboShowRequests.Location = new Point(159, 12);
            cboShowRequests.Name = "cboShowRequests";
            cboShowRequests.Size = new Size(182, 33);
            cboShowRequests.TabIndex = 0;
            // 
            // lblShow
            // 
            lblShow.AutoSize = true;
            lblShow.Location = new Point(55, 15);
            lblShow.Name = "lblShow";
            lblShow.Size = new Size(56, 25);
            lblShow.TabIndex = 1;
            lblShow.Text = "Show";
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(377, 11);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(112, 34);
            btnFilter.TabIndex = 2;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = true;
            // 
            // dgvRequests
            // 
            dgvRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRequests.Location = new Point(38, 90);
            dgvRequests.Name = "dgvRequests";
            dgvRequests.RowHeadersWidth = 62;
            dgvRequests.Size = new Size(703, 151);
            dgvRequests.TabIndex = 3;
            // 
            // grpSelectedRequestDetails
            // 
            grpSelectedRequestDetails.Controls.Add(lblLevel);
            grpSelectedRequestDetails.Controls.Add(lblTPNumber);
            grpSelectedRequestDetails.Controls.Add(lblModule);
            grpSelectedRequestDetails.Controls.Add(lblStudent);
            grpSelectedRequestDetails.Controls.Add(txtLevel);
            grpSelectedRequestDetails.Controls.Add(txtTPNumber);
            grpSelectedRequestDetails.Controls.Add(txtModule);
            grpSelectedRequestDetails.Controls.Add(txtStudent);
            grpSelectedRequestDetails.Location = new Point(28, 262);
            grpSelectedRequestDetails.Name = "grpSelectedRequestDetails";
            grpSelectedRequestDetails.Size = new Size(806, 153);
            grpSelectedRequestDetails.TabIndex = 4;
            grpSelectedRequestDetails.TabStop = false;
            grpSelectedRequestDetails.Text = "Selected Request Details";
            // 
            // txtStudent
            // 
            txtStudent.Location = new Point(132, 30);
            txtStudent.Name = "txtStudent";
            txtStudent.Size = new Size(211, 31);
            txtStudent.TabIndex = 0;
            // 
            // txtModule
            // 
            txtModule.Location = new Point(132, 97);
            txtModule.Name = "txtModule";
            txtModule.Size = new Size(211, 31);
            txtModule.TabIndex = 1;
            // 
            // txtTPNumber
            // 
            txtTPNumber.Location = new Point(567, 30);
            txtTPNumber.Name = "txtTPNumber";
            txtTPNumber.Size = new Size(211, 31);
            txtTPNumber.TabIndex = 2;
            // 
            // txtLevel
            // 
            txtLevel.Location = new Point(567, 97);
            txtLevel.Name = "txtLevel";
            txtLevel.Size = new Size(211, 31);
            txtLevel.TabIndex = 3;
            // 
            // lblStudent
            // 
            lblStudent.AutoSize = true;
            lblStudent.Location = new Point(27, 36);
            lblStudent.Name = "lblStudent";
            lblStudent.Size = new Size(73, 25);
            lblStudent.TabIndex = 4;
            lblStudent.Text = "Student";
            // 
            // lblModule
            // 
            lblModule.AutoSize = true;
            lblModule.Location = new Point(27, 103);
            lblModule.Name = "lblModule";
            lblModule.Size = new Size(73, 25);
            lblModule.TabIndex = 5;
            lblModule.Text = "Module";
            // 
            // lblTPNumber
            // 
            lblTPNumber.AutoSize = true;
            lblTPNumber.Location = new Point(458, 36);
            lblTPNumber.Name = "lblTPNumber";
            lblTPNumber.Size = new Size(101, 25);
            lblTPNumber.TabIndex = 6;
            lblTPNumber.Text = "TP Number";
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.Location = new Point(458, 103);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(51, 25);
            lblLevel.TabIndex = 7;
            lblLevel.Text = "Level";
            // 
            // btnApprove
            // 
            btnApprove.Location = new Point(38, 455);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(112, 34);
            btnApprove.TabIndex = 5;
            btnApprove.Text = "Approve";
            btnApprove.UseVisualStyleBackColor = true;
            // 
            // btnReject
            // 
            btnReject.Location = new Point(195, 455);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(112, 34);
            btnReject.TabIndex = 6;
            btnReject.Text = "Reject";
            btnReject.UseVisualStyleBackColor = true;
            // 
            // btnRerfesh
            // 
            btnRerfesh.Location = new Point(345, 455);
            btnRerfesh.Name = "btnRerfesh";
            btnRerfesh.Size = new Size(112, 34);
            btnRerfesh.TabIndex = 7;
            btnRerfesh.Text = "Rerfresh";
            btnRerfesh.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(497, 455);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(112, 34);
            btnClose.TabIndex = 8;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(696, 433);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 25);
            lblStatus.TabIndex = 9;
            // 
            // lblFormStatus
            // 
            lblFormStatus.AutoSize = true;
            lblFormStatus.Location = new Point(53, 427);
            lblFormStatus.Name = "lblFormStatus";
            lblFormStatus.Size = new Size(0, 25);
            lblFormStatus.TabIndex = 10;
            // 
            // LecturerApproveRequestsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(905, 521);
            Controls.Add(lblFormStatus);
            Controls.Add(lblStatus);
            Controls.Add(btnClose);
            Controls.Add(btnRerfesh);
            Controls.Add(btnReject);
            Controls.Add(btnApprove);
            Controls.Add(grpSelectedRequestDetails);
            Controls.Add(dgvRequests);
            Controls.Add(btnFilter);
            Controls.Add(lblShow);
            Controls.Add(cboShowRequests);
            Name = "LecturerApproveRequestsForm";
            Text = "LecturerApproveRequestsForm";
            ((System.ComponentModel.ISupportInitialize)dgvRequests).EndInit();
            grpSelectedRequestDetails.ResumeLayout(false);
            grpSelectedRequestDetails.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboShowRequests;
        private Label lblShow;
        private Button btnFilter;
        private DataGridView dgvRequests;
        private GroupBox grpSelectedRequestDetails;
        private Label lblLevel;
        private Label lblTPNumber;
        private Label lblModule;
        private Label lblStudent;
        private TextBox txtLevel;
        private TextBox txtTPNumber;
        private TextBox txtModule;
        private TextBox txtStudent;
        private Button btnApprove;
        private Button btnReject;
        private Button btnRerfesh;
        private Button btnClose;
        private Label lblStatus;
        private Label lblFormStatus;
    }
}