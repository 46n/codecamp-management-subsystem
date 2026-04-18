namespace APUCC_Project.Forms.Common
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            pictureBox1 = new PictureBox();
            pnlLogin = new Panel();
            lblWrong = new Label();
            label1 = new Label();
            btnTogglePassword = new Button();
            txtPassword = new TextBox();
            lblUserNameEmail = new Label();
            btnLogin = new Button();
            txtUser = new TextBox();
            lblSignIn = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlLogin.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(344, 86);
            pictureBox1.Margin = new Padding(4, 2, 4, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(767, 287);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pnlLogin
            // 
            pnlLogin.BackColor = Color.FromArgb(25, 25, 25);
            pnlLogin.Controls.Add(lblWrong);
            pnlLogin.Controls.Add(label1);
            pnlLogin.Controls.Add(btnTogglePassword);
            pnlLogin.Controls.Add(txtPassword);
            pnlLogin.Controls.Add(lblUserNameEmail);
            pnlLogin.Controls.Add(btnLogin);
            pnlLogin.Controls.Add(txtUser);
            pnlLogin.Controls.Add(lblSignIn);
            pnlLogin.Controls.Add(pictureBox1);
            pnlLogin.Location = new Point(1, -4);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(1534, 1026);
            pnlLogin.TabIndex = 2;
            // 
            // lblWrong
            // 
            lblWrong.AutoSize = true;
            lblWrong.ForeColor = Color.FromArgb(192, 0, 0);
            lblWrong.Location = new Point(564, 690);
            lblWrong.Name = "lblWrong";
            lblWrong.Size = new Size(0, 32);
            lblWrong.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(268, 615);
            label1.Name = "label1";
            label1.Size = new Size(190, 45);
            label1.TabIndex = 7;
            label1.Text = "Password :";
            // 
            // btnTogglePassword
            // 
            btnTogglePassword.BackColor = Color.FromArgb(102, 146, 153);
            btnTogglePassword.FlatStyle = FlatStyle.Popup;
            btnTogglePassword.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTogglePassword.ForeColor = Color.White;
            btnTogglePassword.Location = new Point(1067, 619);
            btnTogglePassword.Name = "btnTogglePassword";
            btnTogglePassword.Size = new Size(111, 45);
            btnTogglePassword.TabIndex = 9;
            btnTogglePassword.Text = "Show";
            btnTogglePassword.UseVisualStyleBackColor = false;
            btnTogglePassword.Click += btnTogglePassword_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(683, 622);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(370, 39);
            txtPassword.TabIndex = 6;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // lblUserNameEmail
            // 
            lblUserNameEmail.AutoSize = true;
            lblUserNameEmail.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserNameEmail.ForeColor = Color.White;
            lblUserNameEmail.Location = new Point(268, 548);
            lblUserNameEmail.Name = "lblUserNameEmail";
            lblUserNameEmail.Size = new Size(404, 45);
            lblUserNameEmail.TabIndex = 5;
            lblUserNameEmail.Text = "Enter User Name/Email :";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.SlateBlue;
            btnLogin.FlatStyle = FlatStyle.Popup;
            btnLogin.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.Black;
            btnLogin.Location = new Point(582, 728);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(326, 78);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtUser
            // 
            txtUser.Location = new Point(683, 554);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(370, 39);
            txtUser.TabIndex = 3;
            txtUser.TextChanged += txtUser_TextChanged;
            // 
            // lblSignIn
            // 
            lblSignIn.AutoSize = true;
            lblSignIn.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSignIn.ForeColor = Color.White;
            lblSignIn.Location = new Point(632, 424);
            lblSignIn.Name = "lblSignIn";
            lblSignIn.Size = new Size(204, 65);
            lblSignIn.TabIndex = 2;
            lblSignIn.Text = "Sign In ";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1534, 1018);
            Controls.Add(pnlLogin);
            Name = "LoginForm";
            Text = "LoginForm";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        protected PictureBox pictureBox1;
        private Panel pnlLogin;
        private Label lblSignIn;
        private Button btnLogin;
        private TextBox txtUser;
        private Label lblUserNameEmail;
        private Label lblWrong;
        private Label label1;
        private Button btnTogglePassword;
        private TextBox txtPassword;
    }
}
