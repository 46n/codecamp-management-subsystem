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
            button7 = new Button();
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
            grpRegisterStudent.Location = new Point(501, 12);
            grpRegisterStudent.Name = "grpRegisterStudent";
            grpRegisterStudent.Size = new Size(324, 469);
            grpRegisterStudent.TabIndex = 0;
            grpRegisterStudent.TabStop = false;
            grpRegisterStudent.Text = "Register New  Student";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(27, 435);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(87, 25);
            lblPassword.TabIndex = 19;
            lblPassword.Text = "Password";
            // 
            // lblMonth
            // 
            lblMonth.AutoSize = true;
            lblMonth.Location = new Point(27, 355);
            lblMonth.Name = "lblMonth";
            lblMonth.Size = new Size(65, 25);
            lblMonth.TabIndex = 17;
            lblMonth.Text = "Month";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(27, 397);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(99, 25);
            lblUsername.TabIndex = 18;
            lblUsername.Text = "User Name";
            // 
            // lblModule
            // 
            lblModule.AutoSize = true;
            lblModule.Location = new Point(27, 302);
            lblModule.Name = "lblModule";
            lblModule.Size = new Size(73, 25);
            lblModule.TabIndex = 16;
            lblModule.Text = "Module";
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.Location = new Point(27, 257);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(51, 25);
            lblLevel.TabIndex = 15;
            lblLevel.Text = "Level";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(27, 214);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(77, 25);
            lblAddress.TabIndex = 14;
            lblAddress.Text = "Address";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(27, 168);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(62, 25);
            lblPhone.TabIndex = 13;
            lblPhone.Text = "Phone";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(27, 120);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(54, 25);
            lblEmail.TabIndex = 12;
            lblEmail.Text = "Email";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(27, 73);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(91, 25);
            lblFullName.TabIndex = 11;
            lblFullName.Text = "Full Name";
            // 
            // lblTPNumber
            // 
            lblTPNumber.AutoSize = true;
            lblTPNumber.Location = new Point(27, 27);
            lblTPNumber.Name = "lblTPNumber";
            lblTPNumber.Size = new Size(101, 25);
            lblTPNumber.TabIndex = 10;
            lblTPNumber.Text = "TP Number";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(138, 432);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(171, 31);
            txtPassword.TabIndex = 9;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(138, 394);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(171, 31);
            txtUsername.TabIndex = 8;
            // 
            // cboModule
            // 
            cboModule.FormattingEnabled = true;
            cboModule.Location = new Point(138, 302);
            cboModule.Name = "cboModule";
            cboModule.Size = new Size(171, 33);
            cboModule.TabIndex = 7;
            // 
            // cboMonth
            // 
            cboMonth.FormattingEnabled = true;
            cboMonth.Location = new Point(138, 355);
            cboMonth.Name = "cboMonth";
            cboMonth.Size = new Size(171, 33);
            cboMonth.TabIndex = 6;
            // 
            // cboLevel
            // 
            cboLevel.FormattingEnabled = true;
            cboLevel.Location = new Point(138, 254);
            cboLevel.Name = "cboLevel";
            cboLevel.Size = new Size(171, 33);
            cboLevel.TabIndex = 5;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(138, 67);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(171, 31);
            txtFullName.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(138, 114);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(171, 31);
            txtEmail.TabIndex = 3;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(138, 162);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(171, 31);
            txtPhone.TabIndex = 2;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(138, 208);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(171, 31);
            txtAddress.TabIndex = 1;
            // 
            // txtTPNumber
            // 
            txtTPNumber.Location = new Point(138, 20);
            txtTPNumber.Name = "txtTPNumber";
            txtTPNumber.Size = new Size(171, 31);
            txtTPNumber.TabIndex = 0;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(501, 512);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(112, 34);
            btnRegister.TabIndex = 1;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(656, 512);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(112, 34);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnShowAll
            // 
            btnShowAll.Location = new Point(412, 29);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(83, 36);
            btnShowAll.TabIndex = 4;
            btnShowAll.Text = "Show All";
            btnShowAll.UseVisualStyleBackColor = true;
            // 
            // btnDeleteStudent
            // 
            btnDeleteStudent.Location = new Point(86, 309);
            btnDeleteStudent.Name = "btnDeleteStudent";
            btnDeleteStudent.Size = new Size(112, 34);
            btnDeleteStudent.TabIndex = 5;
            btnDeleteStudent.Text = "Delete Student";
            btnDeleteStudent.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(266, 312);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(112, 34);
            btnClose.TabIndex = 6;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(323, 29);
            button7.Name = "button7";
            button7.Size = new Size(83, 36);
            button7.TabIndex = 7;
            button7.Text = "Filter";
            button7.UseVisualStyleBackColor = true;
            // 
            // lblFilterModule
            // 
            lblFilterModule.AutoSize = true;
            lblFilterModule.Location = new Point(167, 35);
            lblFilterModule.Name = "lblFilterModule";
            lblFilterModule.Size = new Size(73, 25);
            lblFilterModule.TabIndex = 20;
            lblFilterModule.Text = "Module";
            // 
            // lblFilterLevel
            // 
            lblFilterLevel.AutoSize = true;
            lblFilterLevel.Location = new Point(11, 39);
            lblFilterLevel.Name = "lblFilterLevel";
            lblFilterLevel.Size = new Size(50, 25);
            lblFilterLevel.TabIndex = 21;
            lblFilterLevel.Text = "Filter";
            // 
            // cboFilterModule
            // 
            cboFilterModule.FormattingEnabled = true;
            cboFilterModule.Location = new Point(242, 32);
            cboFilterModule.Name = "cboFilterModule";
            cboFilterModule.Size = new Size(75, 33);
            cboFilterModule.TabIndex = 20;
            // 
            // cboFilterLevel
            // 
            cboFilterLevel.FormattingEnabled = true;
            cboFilterLevel.Location = new Point(86, 35);
            cboFilterLevel.Name = "cboFilterLevel";
            cboFilterLevel.Size = new Size(75, 33);
            cboFilterLevel.TabIndex = 22;
            // 
            // dgvStudents
            // 
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(28, 85);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.RowHeadersWidth = 62;
            dgvStudents.Size = new Size(447, 197);
            dgvStudents.TabIndex = 23;
            // 
            // lblFormStatus
            // 
            lblFormStatus.AutoSize = true;
            lblFormStatus.Location = new Point(84, 368);
            lblFormStatus.Name = "lblFormStatus";
            lblFormStatus.Size = new Size(0, 25);
            lblFormStatus.TabIndex = 24;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(495, 484);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 25);
            lblStatus.TabIndex = 25;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Location = new Point(656, 484);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 25);
            lblError.TabIndex = 26;
            // 
            // LecturerManageStudentsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(861, 554);
            Controls.Add(lblError);
            Controls.Add(lblStatus);
            Controls.Add(lblFormStatus);
            Controls.Add(dgvStudents);
            Controls.Add(cboFilterLevel);
            Controls.Add(cboFilterModule);
            Controls.Add(lblFilterLevel);
            Controls.Add(lblFilterModule);
            Controls.Add(button7);
            Controls.Add(btnClose);
            Controls.Add(btnDeleteStudent);
            Controls.Add(btnShowAll);
            Controls.Add(btnClear);
            Controls.Add(btnRegister);
            Controls.Add(grpRegisterStudent);
            Name = "LecturerManageStudentsForm";
            Text = "LecturerManageStudentsForm";
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
        private Button button7;
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