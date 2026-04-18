namespace APUCC_Project.Forms.Lecturer
{
    partial class LecturerManageStudentsForm
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
            grpRegisterStudent = new GroupBox();
            lblPassword = new Label();
            lblMonth = new Label();
            lblUsername = new Label();
            lblModule = new Label();
            lblLevel = new Label();
            lblAddress = new Label();
            lblPhone = new Label();
            lblEmail = new Label();
            lblFullName = new Label();
            lblTPNumber = new Label();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            cboModule = new ComboBox();
            cboMonth = new ComboBox();
            cboLevel = new ComboBox();
            txtFullName = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            txtAddress = new TextBox();
            txtTPNumber = new TextBox();
            btnRegister = new Button();
            btnClear = new Button();
            btnShowAll = new Button();
            btnDeleteStudent = new Button();
            btnClose = new Button();
            btnFilter = new Button();
            lblFilterModule = new Label();
            lblFilterLevel = new Label();
            cboFilterModule = new ComboBox();
            cboFilterLevel = new ComboBox();
            dgvStudents = new DataGridView();
            lblFormStatus = new Label();
            lblStatus = new Label();
            lblError = new Label();
            grpRegisterStudent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // grpRegisterStudent
            // 
            grpRegisterStudent.Controls.Add(lblPassword);
            grpRegisterStudent.Controls.Add(lblMonth);
            grpRegisterStudent.Controls.Add(lblUsername);
            grpRegisterStudent.Controls.Add(lblModule);
            grpRegisterStudent.Controls.Add(lblLevel);
            grpRegisterStudent.Controls.Add(lblAddress);
            grpRegisterStudent.Controls.Add(lblPhone);
            grpRegisterStudent.Controls.Add(lblEmail);
            grpRegisterStudent.Controls.Add(lblFullName);
            grpRegisterStudent.Controls.Add(lblTPNumber);
            grpRegisterStudent.Controls.Add(txtPassword);
            grpRegisterStudent.Controls.Add(txtUsername);
            grpRegisterStudent.Controls.Add(cboModule);
            grpRegisterStudent.Controls.Add(cboMonth);
            grpRegisterStudent.Controls.Add(cboLevel);
            grpRegisterStudent.Controls.Add(txtFullName);
            grpRegisterStudent.Controls.Add(txtEmail);
            grpRegisterStudent.Controls.Add(txtPhone);
            grpRegisterStudent.Controls.Add(txtAddress);
            grpRegisterStudent.Controls.Add(txtTPNumber);
            grpRegisterStudent.Location = new Point(681, 37);
            grpRegisterStudent.Margin = new Padding(4);
            grpRegisterStudent.Name = "grpRegisterStudent";
            grpRegisterStudent.Padding = new Padding(4);
            grpRegisterStudent.Size = new Size(421, 650);
            grpRegisterStudent.TabIndex = 0;
            grpRegisterStudent.TabStop = false;
            grpRegisterStudent.Text = "Register New  Student";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(8, 587);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(111, 32);
            lblPassword.TabIndex = 19;
            lblPassword.Text = "Password";
            // 
            // lblMonth
            // 
            lblMonth.AutoSize = true;
            lblMonth.Location = new Point(8, 484);
            lblMonth.Margin = new Padding(4, 0, 4, 0);
            lblMonth.Name = "lblMonth";
            lblMonth.Size = new Size(86, 32);
            lblMonth.TabIndex = 17;
            lblMonth.Text = "Month";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(8, 538);
            lblUsername.Margin = new Padding(4, 0, 4, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(132, 32);
            lblUsername.TabIndex = 18;
            lblUsername.Text = "User Name";
            // 
            // lblModule
            // 
            lblModule.AutoSize = true;
            lblModule.Location = new Point(8, 417);
            lblModule.Margin = new Padding(4, 0, 4, 0);
            lblModule.Name = "lblModule";
            lblModule.Size = new Size(97, 32);
            lblModule.TabIndex = 16;
            lblModule.Text = "Module";
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.Location = new Point(8, 359);
            lblLevel.Margin = new Padding(4, 0, 4, 0);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(69, 32);
            lblLevel.TabIndex = 15;
            lblLevel.Text = "Level";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(8, 304);
            lblAddress.Margin = new Padding(4, 0, 4, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(98, 32);
            lblAddress.TabIndex = 14;
            lblAddress.Text = "Address";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(8, 245);
            lblPhone.Margin = new Padding(4, 0, 4, 0);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(82, 32);
            lblPhone.TabIndex = 13;
            lblPhone.Text = "Phone";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(8, 184);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(71, 32);
            lblEmail.TabIndex = 12;
            lblEmail.Text = "Email";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(8, 123);
            lblFullName.Margin = new Padding(4, 0, 4, 0);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(123, 32);
            lblFullName.TabIndex = 11;
            lblFullName.Text = "Full Name";
            // 
            // lblTPNumber
            // 
            lblTPNumber.AutoSize = true;
            lblTPNumber.Location = new Point(8, 65);
            lblTPNumber.Margin = new Padding(4, 0, 4, 0);
            lblTPNumber.Name = "lblTPNumber";
            lblTPNumber.Size = new Size(135, 32);
            lblTPNumber.TabIndex = 10;
            lblTPNumber.Text = "TP Number";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(192, 589);
            txtPassword.Margin = new Padding(4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(221, 39);
            txtPassword.TabIndex = 9;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(192, 540);
            txtUsername.Margin = new Padding(4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(221, 39);
            txtUsername.TabIndex = 8;
            // 
            // cboModule
            // 
            cboModule.FormattingEnabled = true;
            cboModule.Location = new Point(192, 423);
            cboModule.Margin = new Padding(4);
            cboModule.Name = "cboModule";
            cboModule.Size = new Size(221, 40);
            cboModule.TabIndex = 7;
            // 
            // cboMonth
            // 
            cboMonth.FormattingEnabled = true;
            cboMonth.Location = new Point(192, 490);
            cboMonth.Margin = new Padding(4);
            cboMonth.Name = "cboMonth";
            cboMonth.Size = new Size(221, 40);
            cboMonth.TabIndex = 6;
            // 
            // cboLevel
            // 
            cboLevel.FormattingEnabled = true;
            cboLevel.Location = new Point(192, 361);
            cboLevel.Margin = new Padding(4);
            cboLevel.Name = "cboLevel";
            cboLevel.Size = new Size(221, 40);
            cboLevel.TabIndex = 5;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(192, 122);
            txtFullName.Margin = new Padding(4);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(221, 39);
            txtFullName.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(192, 182);
            txtEmail.Margin = new Padding(4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(221, 39);
            txtEmail.TabIndex = 3;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(192, 243);
            txtPhone.Margin = new Padding(4);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(221, 39);
            txtPhone.TabIndex = 2;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(192, 302);
            txtAddress.Margin = new Padding(4);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(221, 39);
            txtAddress.TabIndex = 1;
            // 
            // txtTPNumber
            // 
            txtTPNumber.Location = new Point(192, 62);
            txtTPNumber.Margin = new Padding(4);
            txtTPNumber.Name = "txtTPNumber";
            txtTPNumber.Size = new Size(221, 39);
            txtTPNumber.TabIndex = 0;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(716, 708);
            btnRegister.Margin = new Padding(4);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(146, 44);
            btnRegister.TabIndex = 1;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(918, 708);
            btnClear.Margin = new Padding(4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(146, 44);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnShowAll
            // 
            btnShowAll.Location = new Point(535, 106);
            btnShowAll.Margin = new Padding(4);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(108, 46);
            btnShowAll.TabIndex = 4;
            btnShowAll.Text = "Show All";
            btnShowAll.UseVisualStyleBackColor = true;
            btnShowAll.Click += btnShowAll_Click;
            // 
            // btnDeleteStudent
            // 
            btnDeleteStudent.Location = new Point(162, 567);
            btnDeleteStudent.Margin = new Padding(4);
            btnDeleteStudent.Name = "btnDeleteStudent";
            btnDeleteStudent.Size = new Size(146, 44);
            btnDeleteStudent.TabIndex = 5;
            btnDeleteStudent.Text = "Delete Student";
            btnDeleteStudent.UseVisualStyleBackColor = true;
            btnDeleteStudent.Click += btnDeleteStudent_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(382, 567);
            btnClose.Margin = new Padding(4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(146, 44);
            btnClose.TabIndex = 6;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(420, 106);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(108, 46);
            btnFilter.TabIndex = 7;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // lblFilterModule
            // 
            lblFilterModule.AutoSize = true;
            lblFilterModule.Location = new Point(338, 51);
            lblFilterModule.Margin = new Padding(4, 0, 4, 0);
            lblFilterModule.Name = "lblFilterModule";
            lblFilterModule.Size = new Size(97, 32);
            lblFilterModule.TabIndex = 20;
            lblFilterModule.Text = "Module";
            // 
            // lblFilterLevel
            // 
            lblFilterLevel.AutoSize = true;
            lblFilterLevel.Location = new Point(63, 51);
            lblFilterLevel.Margin = new Padding(4, 0, 4, 0);
            lblFilterLevel.Name = "lblFilterLevel";
            lblFilterLevel.Size = new Size(67, 32);
            lblFilterLevel.TabIndex = 21;
            lblFilterLevel.Text = "Filter";
            // 
            // cboFilterModule
            // 
            cboFilterModule.FormattingEnabled = true;
            cboFilterModule.Location = new Point(479, 46);
            cboFilterModule.Margin = new Padding(4);
            cboFilterModule.Name = "cboFilterModule";
            cboFilterModule.Size = new Size(164, 40);
            cboFilterModule.TabIndex = 20;
            // 
            // cboFilterLevel
            // 
            cboFilterLevel.FormattingEnabled = true;
            cboFilterLevel.Location = new Point(138, 46);
            cboFilterLevel.Margin = new Padding(4);
            cboFilterLevel.Name = "cboFilterLevel";
            cboFilterLevel.Size = new Size(164, 40);
            cboFilterLevel.TabIndex = 22;
            // 
            // dgvStudents
            // 
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(62, 160);
            dgvStudents.Margin = new Padding(4);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.RowHeadersWidth = 62;
            dgvStudents.Size = new Size(581, 351);
            dgvStudents.TabIndex = 23;
            // 
            // lblFormStatus
            // 
            lblFormStatus.AutoSize = true;
            lblFormStatus.Location = new Point(63, 664);
            lblFormStatus.Margin = new Padding(4, 0, 4, 0);
            lblFormStatus.Name = "lblFormStatus";
            lblFormStatus.Size = new Size(0, 32);
            lblFormStatus.TabIndex = 24;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(63, 625);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 32);
            lblStatus.TabIndex = 25;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Location = new Point(728, 769);
            lblError.Margin = new Padding(4, 0, 4, 0);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 32);
            lblError.TabIndex = 26;
            // 
            // LecturerManageStudentsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1217, 860);
            Controls.Add(lblError);
            Controls.Add(lblStatus);
            Controls.Add(lblFormStatus);
            Controls.Add(dgvStudents);
            Controls.Add(cboFilterLevel);
            Controls.Add(cboFilterModule);
            Controls.Add(lblFilterLevel);
            Controls.Add(lblFilterModule);
            Controls.Add(btnFilter);
            Controls.Add(btnClose);
            Controls.Add(btnDeleteStudent);
            Controls.Add(btnShowAll);
            Controls.Add(btnClear);
            Controls.Add(btnRegister);
            Controls.Add(grpRegisterStudent);
            Margin = new Padding(4);
            Name = "LecturerManageStudentsForm";
            Text = "LecturerManageStudentsForm";
            Load += LecturerManageStudentsForm_Load;
            grpRegisterStudent.ResumeLayout(false);
            grpRegisterStudent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpRegisterStudent;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private ComboBox cboModule;
        private ComboBox cboMonth;
        private ComboBox cboLevel;
        private TextBox txtFullName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtAddress;
        private TextBox txtTPNumber;
        private Label lblLevel;
        private Label lblAddress;
        private Label lblPhone;
        private Label lblEmail;
        private Label lblFullName;
        private Label lblTPNumber;
        private Label lblPassword;
        private Label lblMonth;
        private Label lblUsername;
        private Label lblModule;
        private Button btnRegister;
        private Button btnClear;
        private Button btnShowAll;
        private Button btnDeleteStudent;
        private Button btnClose;
        private Button btnFilter;
        private Label lblFilterModule;
        private Label lblFilterLevel;
        private ComboBox cboFilterModule;
        private ComboBox cboFilterLevel;
        private DataGridView dgvStudents;
        private Label lblFormStatus;
        private Label lblStatus;
        private Label lblError;
    }
}