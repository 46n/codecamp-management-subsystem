namespace APUCC_Project.Forms.Admin
{
    partial class AdminManageTrainer
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
            dgvTrainer = new DataGridView();
            colTrainerID = new DataGridViewTextBoxColumn();
            colTrainerName = new DataGridViewTextBoxColumn();
            colModule = new DataGridViewTextBoxColumn();
            colLevel = new DataGridViewTextBoxColumn();
            grpAssignment = new GroupBox();
            lblLevel = new Label();
            lblModule = new Label();
            cboLevel = new ComboBox();
            cboModule = new ComboBox();
            grpTrainerDetails = new GroupBox();
            lblPassword = new Label();
            lblUserName = new Label();
            lblPhone = new Label();
            lblEmail = new Label();
            lblFullName = new Label();
            txtPassword = new TextBox();
            txtUserName = new TextBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            txtFullName = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvTrainer).BeginInit();
            grpAssignment.SuspendLayout();
            grpTrainerDetails.SuspendLayout();
            SuspendLayout();
            // 
            // dgvTrainer
            // 
            dgvTrainer.AllowUserToAddRows = false;
            dgvTrainer.AllowUserToDeleteRows = false;
            dgvTrainer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTrainer.Columns.AddRange(new DataGridViewColumn[] { colTrainerID, colTrainerName, colModule, colLevel });
            dgvTrainer.Location = new Point(-45, 88);
            dgvTrainer.Name = "dgvTrainer";
            dgvTrainer.ReadOnly = true;
            dgvTrainer.RightToLeft = RightToLeft.No;
            dgvTrainer.RowHeadersWidth = 62;
            dgvTrainer.Size = new Size(605, 220);
            dgvTrainer.TabIndex = 5;
            // 
            // colTrainerID
            // 
            colTrainerID.FillWeight = 20F;
            colTrainerID.HeaderText = "ID";
            colTrainerID.MinimumWidth = 8;
            colTrainerID.Name = "colTrainerID";
            colTrainerID.ReadOnly = true;
            colTrainerID.Width = 150;
            // 
            // colTrainerName
            // 
            colTrainerName.FillWeight = 35F;
            colTrainerName.HeaderText = "Name";
            colTrainerName.MinimumWidth = 8;
            colTrainerName.Name = "colTrainerName";
            colTrainerName.ReadOnly = true;
            colTrainerName.Width = 150;
            // 
            // colModule
            // 
            colModule.FillWeight = 35F;
            colModule.HeaderText = "Module";
            colModule.MinimumWidth = 8;
            colModule.Name = "colModule";
            colModule.ReadOnly = true;
            colModule.Width = 150;
            // 
            // colLevel
            // 
            colLevel.FillWeight = 15F;
            colLevel.HeaderText = "Level";
            colLevel.MinimumWidth = 8;
            colLevel.Name = "colLevel";
            colLevel.ReadOnly = true;
            colLevel.Width = 150;
            // 
            // grpAssignment
            // 
            grpAssignment.Controls.Add(lblLevel);
            grpAssignment.Controls.Add(lblModule);
            grpAssignment.Controls.Add(cboLevel);
            grpAssignment.Controls.Add(cboModule);
            grpAssignment.Location = new Point(566, 309);
            grpAssignment.Name = "grpAssignment";
            grpAssignment.Size = new Size(300, 150);
            grpAssignment.TabIndex = 4;
            grpAssignment.TabStop = false;
            grpAssignment.Text = "Assignment";
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.Location = new Point(27, 96);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(51, 25);
            lblLevel.TabIndex = 11;
            lblLevel.Text = "Level";
            // 
            // lblModule
            // 
            lblModule.AutoSize = true;
            lblModule.Location = new Point(27, 43);
            lblModule.Name = "lblModule";
            lblModule.Size = new Size(73, 25);
            lblModule.TabIndex = 10;
            lblModule.Text = "Module";
            // 
            // cboLevel
            // 
            cboLevel.FormattingEnabled = true;
            cboLevel.Location = new Point(97, 93);
            cboLevel.Name = "cboLevel";
            cboLevel.Size = new Size(182, 33);
            cboLevel.TabIndex = 1;
            // 
            // cboModule
            // 
            cboModule.FormattingEnabled = true;
            cboModule.Location = new Point(97, 40);
            cboModule.Name = "cboModule";
            cboModule.Size = new Size(182, 33);
            cboModule.TabIndex = 0;
            // 
            // grpTrainerDetails
            // 
            grpTrainerDetails.Controls.Add(lblPassword);
            grpTrainerDetails.Controls.Add(lblUserName);
            grpTrainerDetails.Controls.Add(lblPhone);
            grpTrainerDetails.Controls.Add(lblEmail);
            grpTrainerDetails.Controls.Add(lblFullName);
            grpTrainerDetails.Controls.Add(txtPassword);
            grpTrainerDetails.Controls.Add(txtUserName);
            grpTrainerDetails.Controls.Add(txtPhone);
            grpTrainerDetails.Controls.Add(txtEmail);
            grpTrainerDetails.Controls.Add(txtFullName);
            grpTrainerDetails.Location = new Point(566, 12);
            grpTrainerDetails.Name = "grpTrainerDetails";
            grpTrainerDetails.Size = new Size(300, 269);
            grpTrainerDetails.TabIndex = 3;
            grpTrainerDetails.TabStop = false;
            grpTrainerDetails.Text = "Trainer Details";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(27, 223);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(87, 25);
            lblPassword.TabIndex = 9;
            lblPassword.Text = "Password";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(27, 183);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(94, 25);
            lblUserName.TabIndex = 8;
            lblUserName.Text = "UserName";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(27, 134);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(62, 25);
            lblPhone.TabIndex = 7;
            lblPhone.Text = "Phone";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(27, 93);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(54, 25);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(27, 46);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(91, 25);
            lblFullName.TabIndex = 5;
            lblFullName.Text = "Full Name";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(129, 223);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(150, 31);
            txtPassword.TabIndex = 4;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(129, 177);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(150, 31);
            txtUserName.TabIndex = 3;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(129, 134);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(150, 31);
            txtPhone.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(129, 90);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(150, 31);
            txtEmail.TabIndex = 1;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(129, 43);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(150, 31);
            txtFullName.TabIndex = 0;
            // 
            // AdminManageTrainer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(897, 471);
            Controls.Add(dgvTrainer);
            Controls.Add(grpAssignment);
            Controls.Add(grpTrainerDetails);
            Name = "AdminManageTrainer";
            Text = "AdminManageTrainer";
            ((System.ComponentModel.ISupportInitialize)dgvTrainer).EndInit();
            grpAssignment.ResumeLayout(false);
            grpAssignment.PerformLayout();
            grpTrainerDetails.ResumeLayout(false);
            grpTrainerDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvTrainer;
        private DataGridViewTextBoxColumn colTrainerID;
        private DataGridViewTextBoxColumn colTrainerName;
        private DataGridViewTextBoxColumn colModule;
        private DataGridViewTextBoxColumn colLevel;
        private GroupBox grpAssignment;
        private Label lblLevel;
        private Label lblModule;
        private ComboBox cboLevel;
        private ComboBox cboModule;
        private GroupBox grpTrainerDetails;
        private Label lblPassword;
        private Label lblUserName;
        private Label lblPhone;
        private Label lblEmail;
        private Label lblFullName;
        private TextBox txtPassword;
        private TextBox txtUserName;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private TextBox txtFullName;
    }
}