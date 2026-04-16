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
            lblLevel = new Label();
            lblTPNumber = new Label();
            lblModule = new Label();
            lblStudent = new Label();
            txtLevel = new TextBox();
            txtTPNumber = new TextBox();
            txtModule = new TextBox();
            txtStudent = new TextBox();
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
            cboShowRequests.Location = new Point(230, 140);
            cboShowRequests.Margin = new Padding(4, 4, 4, 4);
            cboShowRequests.Name = "cboShowRequests";
            cboShowRequests.Size = new Size(235, 40);
            cboShowRequests.TabIndex = 0;
            // 
            // lblShow
            // 
            lblShow.AutoSize = true;
            lblShow.Location = new Point(95, 143);
            lblShow.Margin = new Padding(4, 0, 4, 0);
            lblShow.Name = "lblShow";
            lblShow.Size = new Size(72, 32);
            lblShow.TabIndex = 1;
            lblShow.Text = "Show";
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(514, 138);
            btnFilter.Margin = new Padding(4, 4, 4, 4);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(146, 44);
            btnFilter.TabIndex = 2;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // dgvRequests
            // 
            dgvRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRequests.Location = new Point(73, 239);
            dgvRequests.Margin = new Padding(4, 4, 4, 4);
            dgvRequests.Name = "dgvRequests";
            dgvRequests.RowHeadersWidth = 62;
            dgvRequests.Size = new Size(914, 193);
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
            grpSelectedRequestDetails.Location = new Point(60, 460);
            grpSelectedRequestDetails.Margin = new Padding(4, 4, 4, 4);
            grpSelectedRequestDetails.Name = "grpSelectedRequestDetails";
            grpSelectedRequestDetails.Padding = new Padding(4, 4, 4, 4);
            grpSelectedRequestDetails.Size = new Size(1048, 196);
            grpSelectedRequestDetails.TabIndex = 4;
            grpSelectedRequestDetails.TabStop = false;
            grpSelectedRequestDetails.Text = "Selected Request Details";
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.Location = new Point(595, 132);
            lblLevel.Margin = new Padding(4, 0, 4, 0);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(69, 32);
            lblLevel.TabIndex = 7;
            lblLevel.Text = "Level";
            // 
            // lblTPNumber
            // 
            lblTPNumber.AutoSize = true;
            lblTPNumber.Location = new Point(595, 46);
            lblTPNumber.Margin = new Padding(4, 0, 4, 0);
            lblTPNumber.Name = "lblTPNumber";
            lblTPNumber.Size = new Size(135, 32);
            lblTPNumber.TabIndex = 6;
            lblTPNumber.Text = "TP Number";
            // 
            // lblModule
            // 
            lblModule.AutoSize = true;
            lblModule.Location = new Point(35, 132);
            lblModule.Margin = new Padding(4, 0, 4, 0);
            lblModule.Name = "lblModule";
            lblModule.Size = new Size(97, 32);
            lblModule.TabIndex = 5;
            lblModule.Text = "Module";
            // 
            // lblStudent
            // 
            lblStudent.AutoSize = true;
            lblStudent.Location = new Point(35, 46);
            lblStudent.Margin = new Padding(4, 0, 4, 0);
            lblStudent.Name = "lblStudent";
            lblStudent.Size = new Size(97, 32);
            lblStudent.TabIndex = 4;
            lblStudent.Text = "Student";
            // 
            // txtLevel
            // 
            txtLevel.Location = new Point(737, 124);
            txtLevel.Margin = new Padding(4, 4, 4, 4);
            txtLevel.Name = "txtLevel";
            txtLevel.Size = new Size(273, 39);
            txtLevel.TabIndex = 3;
            // 
            // txtTPNumber
            // 
            txtTPNumber.Location = new Point(737, 38);
            txtTPNumber.Margin = new Padding(4, 4, 4, 4);
            txtTPNumber.Name = "txtTPNumber";
            txtTPNumber.Size = new Size(273, 39);
            txtTPNumber.TabIndex = 2;
            // 
            // txtModule
            // 
            txtModule.Location = new Point(172, 124);
            txtModule.Margin = new Padding(4, 4, 4, 4);
            txtModule.Name = "txtModule";
            txtModule.Size = new Size(273, 39);
            txtModule.TabIndex = 1;
            // 
            // txtStudent
            // 
            txtStudent.Location = new Point(172, 38);
            txtStudent.Margin = new Padding(4, 4, 4, 4);
            txtStudent.Name = "txtStudent";
            txtStudent.Size = new Size(273, 39);
            txtStudent.TabIndex = 0;
            // 
            // btnApprove
            // 
            btnApprove.Location = new Point(73, 707);
            btnApprove.Margin = new Padding(4, 4, 4, 4);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(146, 44);
            btnApprove.TabIndex = 5;
            btnApprove.Text = "Approve";
            btnApprove.UseVisualStyleBackColor = true;
            btnApprove.Click += btnApprove_Click;
            // 
            // btnReject
            // 
            btnReject.Location = new Point(277, 707);
            btnReject.Margin = new Padding(4, 4, 4, 4);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(146, 44);
            btnReject.TabIndex = 6;
            btnReject.Text = "Reject";
            btnReject.UseVisualStyleBackColor = true;
            btnReject.Click += btnReject_Click;
            // 
            // btnRerfesh
            // 
            btnRerfesh.Location = new Point(472, 707);
            btnRerfesh.Margin = new Padding(4, 4, 4, 4);
            btnRerfesh.Name = "btnRerfesh";
            btnRerfesh.Size = new Size(146, 44);
            btnRerfesh.TabIndex = 7;
            btnRerfesh.Text = "Rerfresh";
            btnRerfesh.UseVisualStyleBackColor = true;
            btnRerfesh.Click += btnRefresh_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(670, 707);
            btnClose.Margin = new Padding(4, 4, 4, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(146, 44);
            btnClose.TabIndex = 8;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(928, 678);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 32);
            lblStatus.TabIndex = 9;
            // 
            // lblFormStatus
            // 
            lblFormStatus.AutoSize = true;
            lblFormStatus.Location = new Point(92, 671);
            lblFormStatus.Margin = new Padding(4, 0, 4, 0);
            lblFormStatus.Name = "lblFormStatus";
            lblFormStatus.Size = new Size(0, 32);
            lblFormStatus.TabIndex = 10;
            // 
            // LecturerApproveRequestsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1176, 765);
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
            Margin = new Padding(4, 4, 4, 4);
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