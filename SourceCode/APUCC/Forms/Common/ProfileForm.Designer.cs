namespace APUCC_Project.Forms.Common
{
    partial class ProfileForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelAccount = new Panel();
            btnSignOut = new Button();
            btnSavePassword = new Button();
            btnEditPassword = new Button();
            txtAddress = new TextBox();
            lblAddress = new Label();
            txtPhone = new TextBox();
            lblPhone = new Label();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtRole = new TextBox();
            lblRole = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            lblAccountTitle = new Label();
            panelAccount.SuspendLayout();
            SuspendLayout();
            // 
            // panelAccount
            // 
            panelAccount.BackColor = Color.White;
            panelAccount.BorderStyle = BorderStyle.FixedSingle;
            panelAccount.Controls.Add(btnSignOut);
            panelAccount.Controls.Add(btnSavePassword);
            panelAccount.Controls.Add(btnEditPassword);
            panelAccount.Controls.Add(txtAddress);
            panelAccount.Controls.Add(lblAddress);
            panelAccount.Controls.Add(txtPhone);
            panelAccount.Controls.Add(lblPhone);
            panelAccount.Controls.Add(txtPassword);
            panelAccount.Controls.Add(lblPassword);
            panelAccount.Controls.Add(txtEmail);
            panelAccount.Controls.Add(lblEmail);
            panelAccount.Controls.Add(txtRole);
            panelAccount.Controls.Add(lblRole);
            panelAccount.Controls.Add(txtUsername);
            panelAccount.Controls.Add(lblUsername);
            panelAccount.Controls.Add(lblAccountTitle);
            panelAccount.Location = new Point(1, 6);
            panelAccount.Margin = new Padding(6);
            panelAccount.Name = "panelAccount";
            panelAccount.Size = new Size(1093, 696);
            panelAccount.TabIndex = 1;
            // 
            // btnSignOut
            // 
            btnSignOut.BackColor = Color.FromArgb(192, 57, 43);
            btnSignOut.FlatAppearance.BorderSize = 0;
            btnSignOut.FlatStyle = FlatStyle.Flat;
            btnSignOut.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSignOut.ForeColor = Color.White;
            btnSignOut.Location = new Point(214, 616);
            btnSignOut.Margin = new Padding(6);
            btnSignOut.Name = "btnSignOut";
            btnSignOut.Size = new Size(648, 61);
            btnSignOut.TabIndex = 3;
            btnSignOut.Text = "Sign Out";
            btnSignOut.UseVisualStyleBackColor = false;
            btnSignOut.Click += btnSignOut_Click;
            // 
            // btnSavePassword
            // 
            btnSavePassword.BackColor = Color.FromArgb(36, 112, 99);
            btnSavePassword.FlatAppearance.BorderSize = 0;
            btnSavePassword.FlatStyle = FlatStyle.Flat;
            btnSavePassword.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSavePassword.ForeColor = Color.White;
            btnSavePassword.Location = new Point(919, 519);
            btnSavePassword.Margin = new Padding(6);
            btnSavePassword.Name = "btnSavePassword";
            btnSavePassword.Size = new Size(112, 51);
            btnSavePassword.TabIndex = 14;
            btnSavePassword.Text = "Save";
            btnSavePassword.UseVisualStyleBackColor = false;
            btnSavePassword.Click += btnSavePassword_Click;
            // 
            // btnEditPassword
            // 
            btnEditPassword.BackColor = Color.FromArgb(124, 196, 214);
            btnEditPassword.FlatAppearance.BorderSize = 0;
            btnEditPassword.FlatStyle = FlatStyle.Flat;
            btnEditPassword.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditPassword.ForeColor = Color.Black;
            btnEditPassword.Location = new Point(781, 519);
            btnEditPassword.Margin = new Padding(6);
            btnEditPassword.Name = "btnEditPassword";
            btnEditPassword.Size = new Size(112, 51);
            btnEditPassword.TabIndex = 13;
            btnEditPassword.Text = "Edit";
            btnEditPassword.UseVisualStyleBackColor = false;
            btnEditPassword.Click += btnEditPassword_Click;
            // 
            // txtAddress
            // 
            txtAddress.BackColor = Color.WhiteSmoke;
            txtAddress.BorderStyle = BorderStyle.FixedSingle;
            txtAddress.ForeColor = Color.Black;
            txtAddress.Location = new Point(741, 356);
            txtAddress.Margin = new Padding(6);
            txtAddress.Name = "txtAddress";
            txtAddress.ReadOnly = true;
            txtAddress.Size = new Size(312, 39);
            txtAddress.TabIndex = 12;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAddress.ForeColor = Color.Black;
            lblAddress.Location = new Point(567, 352);
            lblAddress.Margin = new Padding(6, 0, 6, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(115, 37);
            lblAddress.TabIndex = 11;
            lblAddress.Text = "Address";
            // 
            // txtPhone
            // 
            txtPhone.BackColor = Color.WhiteSmoke;
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.ForeColor = Color.Black;
            txtPhone.Location = new Point(247, 354);
            txtPhone.Margin = new Padding(6);
            txtPhone.Name = "txtPhone";
            txtPhone.ReadOnly = true;
            txtPhone.Size = new Size(250, 39);
            txtPhone.TabIndex = 10;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPhone.ForeColor = Color.Black;
            lblPhone.Location = new Point(33, 352);
            lblPhone.Margin = new Padding(6, 0, 6, 0);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(95, 37);
            lblPhone.TabIndex = 9;
            lblPhone.Text = "Phone";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.WhiteSmoke;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.ForeColor = Color.Black;
            txtPassword.Location = new Point(741, 246);
            txtPassword.Margin = new Padding(6);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(312, 39);
            txtPassword.TabIndex = 8;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.ForeColor = Color.Black;
            lblPassword.Location = new Point(567, 244);
            lblPassword.Margin = new Padding(6, 0, 6, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(132, 37);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "Password";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.WhiteSmoke;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.ForeColor = Color.Black;
            txtEmail.Location = new Point(741, 132);
            txtEmail.Margin = new Padding(6);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(312, 39);
            txtEmail.TabIndex = 6;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.Black;
            lblEmail.Location = new Point(567, 130);
            lblEmail.Margin = new Padding(6, 0, 6, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(83, 37);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "Email";
            // 
            // txtRole
            // 
            txtRole.BackColor = Color.WhiteSmoke;
            txtRole.BorderStyle = BorderStyle.FixedSingle;
            txtRole.ForeColor = Color.Black;
            txtRole.Location = new Point(247, 241);
            txtRole.Margin = new Padding(6);
            txtRole.Name = "txtRole";
            txtRole.ReadOnly = true;
            txtRole.Size = new Size(250, 39);
            txtRole.TabIndex = 4;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRole.ForeColor = Color.Black;
            lblRole.Location = new Point(33, 239);
            lblRole.Margin = new Padding(6, 0, 6, 0);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(70, 37);
            lblRole.TabIndex = 3;
            lblRole.Text = "Role";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.WhiteSmoke;
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.ForeColor = Color.Black;
            txtUsername.Location = new Point(247, 128);
            txtUsername.Margin = new Padding(6);
            txtUsername.Name = "txtUsername";
            txtUsername.ReadOnly = true;
            txtUsername.Size = new Size(250, 39);
            txtUsername.TabIndex = 2;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = Color.Black;
            lblUsername.Location = new Point(33, 126);
            lblUsername.Margin = new Padding(6, 0, 6, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(140, 37);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username";
            // 
            // lblAccountTitle
            // 
            lblAccountTitle.AutoSize = true;
            lblAccountTitle.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAccountTitle.ForeColor = Color.Black;
            lblAccountTitle.Location = new Point(21, 24);
            lblAccountTitle.Margin = new Padding(6, 0, 6, 0);
            lblAccountTitle.Name = "lblAccountTitle";
            lblAccountTitle.Size = new Size(331, 59);
            lblAccountTitle.TabIndex = 0;
            lblAccountTitle.Text = "Account Details";
            // 
            // ProfileForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1142, 761);
            Controls.Add(panelAccount);
            Margin = new Padding(6);
            Name = "ProfileForm";
            Text = "Profile";
            Load += ProfileForm_Load;
            panelAccount.ResumeLayout(false);
            panelAccount.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelAccount;
        private Label lblAccountTitle;
        private TextBox txtUsername;
        private Label lblUsername;
        private TextBox txtRole;
        private Label lblRole;
        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtPassword;
        private Label lblPassword;
        private TextBox txtPhone;
        private Label lblPhone;
        private TextBox txtAddress;
        private Label lblAddress;
        private Button btnSavePassword;
        private Button btnEditPassword;
        private Button btnSignOut;
    }
}
