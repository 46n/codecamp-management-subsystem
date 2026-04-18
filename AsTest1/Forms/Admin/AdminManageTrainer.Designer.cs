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
            btnSearch = new Button();
            btnShowAll = new Button();
            btnRemove = new Button();
            btnClose = new Button();
            btnAssign = new Button();
            btnSave = new Button();
            btnClear = new Button();
            lblSearch = new Label();
            txtSearch = new TextBox();
            lblError = new Label();
            lblStatus = new Label();
            pnlMain = new Panel();
            lblManageTrainer = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTrainer).BeginInit();
            grpAssignment.SuspendLayout();
            grpTrainerDetails.SuspendLayout();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // dgvTrainer
            // 
            dgvTrainer.AllowUserToAddRows = false;
            dgvTrainer.AllowUserToDeleteRows = false;
            dgvTrainer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTrainer.Columns.AddRange(new DataGridViewColumn[] { colTrainerID, colTrainerName, colModule, colLevel });
            dgvTrainer.Location = new Point(64, 250);
            dgvTrainer.Margin = new Padding(4);
            dgvTrainer.Name = "dgvTrainer";
            dgvTrainer.ReadOnly = true;
            dgvTrainer.RightToLeft = RightToLeft.No;
            dgvTrainer.RowHeadersWidth = 62;
            dgvTrainer.Size = new Size(640, 264);
            dgvTrainer.TabIndex = 5;
            dgvTrainer.CellContentClick += dgvTrainer_CellContentClick;
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
            grpAssignment.Location = new Point(736, 536);
            grpAssignment.Margin = new Padding(4);
            grpAssignment.Name = "grpAssignment";
            grpAssignment.Padding = new Padding(4);
            grpAssignment.Size = new Size(360, 192);
            grpAssignment.TabIndex = 4;
            grpAssignment.TabStop = false;
            grpAssignment.Text = "Assignment";
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.Location = new Point(35, 123);
            lblLevel.Margin = new Padding(4, 0, 4, 0);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(69, 32);
            lblLevel.TabIndex = 11;
            lblLevel.Text = "Level";
            // 
            // lblModule
            // 
            lblModule.AutoSize = true;
            lblModule.Location = new Point(35, 55);
            lblModule.Margin = new Padding(4, 0, 4, 0);
            lblModule.Name = "lblModule";
            lblModule.Size = new Size(97, 32);
            lblModule.TabIndex = 10;
            lblModule.Text = "Module";
            // 
            // cboLevel
            // 
            cboLevel.FormattingEnabled = true;
            cboLevel.Location = new Point(126, 119);
            cboLevel.Margin = new Padding(4);
            cboLevel.Name = "cboLevel";
            cboLevel.Size = new Size(210, 40);
            cboLevel.TabIndex = 1;
            // 
            // cboModule
            // 
            cboModule.FormattingEnabled = true;
            cboModule.Location = new Point(126, 51);
            cboModule.Margin = new Padding(4);
            cboModule.Name = "cboModule";
            cboModule.Size = new Size(210, 40);
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
            grpTrainerDetails.Location = new Point(736, 250);
            grpTrainerDetails.Margin = new Padding(4);
            grpTrainerDetails.Name = "grpTrainerDetails";
            grpTrainerDetails.Padding = new Padding(4);
            grpTrainerDetails.Size = new Size(360, 270);
            grpTrainerDetails.TabIndex = 3;
            grpTrainerDetails.TabStop = false;
            grpTrainerDetails.Text = "Trainer Details";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(24, 220);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(111, 32);
            lblPassword.TabIndex = 9;
            lblPassword.Text = "Password";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(24, 178);
            lblUserName.Margin = new Padding(4, 0, 4, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(125, 32);
            lblUserName.TabIndex = 8;
            lblUserName.Text = "UserName";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(24, 136);
            lblPhone.Margin = new Padding(4, 0, 4, 0);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(82, 32);
            lblPhone.TabIndex = 7;
            lblPhone.Text = "Phone";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(24, 94);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(71, 32);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(24, 52);
            lblFullName.Margin = new Padding(4, 0, 4, 0);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(123, 32);
            lblFullName.TabIndex = 5;
            lblFullName.Text = "Full Name";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(150, 220);
            txtPassword.Margin = new Padding(4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(180, 39);
            txtPassword.TabIndex = 4;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(150, 178);
            txtUserName.Margin = new Padding(4);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(180, 39);
            txtUserName.TabIndex = 3;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(150, 136);
            txtPhone.Margin = new Padding(4);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(180, 39);
            txtPhone.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(150, 94);
            txtEmail.Margin = new Padding(4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(180, 39);
            txtEmail.TabIndex = 1;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(150, 52);
            txtFullName.Margin = new Padding(4);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(180, 39);
            txtFullName.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(471, 193);
            btnSearch.Margin = new Padding(4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(146, 44);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnShowAll
            // 
            btnShowAll.Location = new Point(629, 193);
            btnShowAll.Margin = new Padding(4);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(146, 44);
            btnShowAll.TabIndex = 7;
            btnShowAll.Text = "Show All";
            btnShowAll.UseVisualStyleBackColor = true;
            btnShowAll.Click += btnShowAll_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(64, 548);
            btnRemove.Margin = new Padding(4);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(146, 44);
            btnRemove.TabIndex = 8;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(222, 548);
            btnClose.Margin = new Padding(4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(146, 44);
            btnClose.TabIndex = 9;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnAssign
            // 
            btnAssign.Location = new Point(736, 746);
            btnAssign.Margin = new Padding(4);
            btnAssign.Name = "btnAssign";
            btnAssign.Size = new Size(146, 44);
            btnAssign.TabIndex = 10;
            btnAssign.Text = "Assign";
            btnAssign.UseVisualStyleBackColor = true;
            btnAssign.Click += btnAssign_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(578, 746);
            btnSave.Margin = new Padding(4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(146, 44);
            btnSave.TabIndex = 11;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(894, 746);
            btnClear.Margin = new Padding(4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(146, 44);
            btnClear.TabIndex = 12;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(64, 198);
            lblSearch.Margin = new Padding(4, 0, 4, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(85, 32);
            lblSearch.TabIndex = 13;
            lblSearch.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(166, 193);
            txtSearch.Margin = new Padding(4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(285, 39);
            txtSearch.TabIndex = 14;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Location = new Point(578, 804);
            lblError.Margin = new Padding(4, 0, 4, 0);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 32);
            lblError.TabIndex = 15;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(64, 614);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 32);
            lblStatus.TabIndex = 16;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(25, 25, 25);
            pnlMain.Controls.Add(lblManageTrainer);
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1180, 170);
            pnlMain.TabIndex = 17;
            // 
            // lblManageTrainer
            // 
            lblManageTrainer.AutoSize = true;
            lblManageTrainer.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblManageTrainer.ForeColor = Color.White;
            lblManageTrainer.Location = new Point(48, 52);
            lblManageTrainer.Name = "lblManageTrainer";
            lblManageTrainer.Size = new Size(402, 65);
            lblManageTrainer.TabIndex = 0;
            lblManageTrainer.Text = "Manage Trainer";
            // 
            // AdminManageTrainer
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1180, 860);
            Controls.Add(pnlMain);
            Controls.Add(lblStatus);
            Controls.Add(lblError);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(btnClear);
            Controls.Add(btnSave);
            Controls.Add(btnAssign);
            Controls.Add(btnClose);
            Controls.Add(btnRemove);
            Controls.Add(btnShowAll);
            Controls.Add(btnSearch);
            Controls.Add(dgvTrainer);
            Controls.Add(grpAssignment);
            Controls.Add(grpTrainerDetails);
            Margin = new Padding(4);
            Name = "AdminManageTrainer";
            Text = "AdminManageTrainer";
            Load += AdminManageTrainer_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTrainer).EndInit();
            grpAssignment.ResumeLayout(false);
            grpAssignment.PerformLayout();
            grpTrainerDetails.ResumeLayout(false);
            grpTrainerDetails.PerformLayout();
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private Button btnSearch;
        private Button btnShowAll;
        private Button btnRemove;
        private Button btnClose;
        private Button btnAssign;
        private Button btnSave;
        private Button btnClear;
        private Label lblSearch;
        private TextBox txtSearch;
        private Label lblError;
        private Label lblStatus;
        private Panel pnlMain;
        private Label lblManageTrainer;
    }
}
