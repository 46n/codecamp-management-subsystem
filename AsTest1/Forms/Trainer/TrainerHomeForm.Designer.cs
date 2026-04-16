namespace APUCC_Project.Forms.Trainer
{
    partial class TrainerHomeForm
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
            dgvClassSchedule = new DataGridView();
            btnAddClass = new Button();
            btnUpdateClass = new Button();
            btnDeleteClass = new Button();
            lblTitle = new Label();
            lblModuleID = new Label();
            txtModuleID = new TextBox();
            lblModuleName = new Label();
            txtModuleName = new TextBox();
            lblClassDate = new Label();
            lblCharges = new Label();
            txtCharges = new TextBox();
            panel1 = new Panel();
            dtpClassDate = new DateTimePicker();
            lblClassTime = new Label();
            txtClassTime = new TextBox();
            lblRoom = new Label();
            txtRoom = new TextBox();
            lblLevel = new Label();
            cboLevel = new ComboBox();
            lblTrainerID = new Label();
            txtTrainerID = new TextBox();
            lblWrong = new Label();
            lblConfirmed = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvClassSchedule).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvClassSchedule
            // 
            dgvClassSchedule.BorderStyle = BorderStyle.Fixed3D;
            dgvClassSchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClassSchedule.Location = new Point(27, 192);
            dgvClassSchedule.Name = "dgvClassSchedule";
            dgvClassSchedule.RowHeadersWidth = 82;
            dgvClassSchedule.Size = new Size(1401, 344);
            dgvClassSchedule.TabIndex = 0;
            dgvClassSchedule.CellClick += dgvClassSchedule_CellClick;
            // 
            // btnAddClass
            // 
            btnAddClass.BackColor = Color.DarkGreen;
            btnAddClass.ForeColor = SystemColors.ButtonHighlight;
            btnAddClass.Location = new Point(59, 771);
            btnAddClass.Name = "btnAddClass";
            btnAddClass.Size = new Size(230, 75);
            btnAddClass.TabIndex = 1;
            btnAddClass.Text = "ADD CLASS";
            btnAddClass.UseVisualStyleBackColor = false;
            btnAddClass.Click += btnAddClass_Click;
            // 
            // btnUpdateClass
            // 
            btnUpdateClass.BackColor = SystemColors.MenuHighlight;
            btnUpdateClass.ForeColor = SystemColors.ButtonHighlight;
            btnUpdateClass.Location = new Point(317, 771);
            btnUpdateClass.Name = "btnUpdateClass";
            btnUpdateClass.Size = new Size(230, 75);
            btnUpdateClass.TabIndex = 2;
            btnUpdateClass.Text = "UPDATE CLASS";
            btnUpdateClass.UseVisualStyleBackColor = false;
            btnUpdateClass.Click += btnUpdateClass_Click;
            // 
            // btnDeleteClass
            // 
            btnDeleteClass.BackColor = Color.FromArgb(192, 0, 0);
            btnDeleteClass.ForeColor = SystemColors.ButtonHighlight;
            btnDeleteClass.Location = new Point(578, 771);
            btnDeleteClass.Name = "btnDeleteClass";
            btnDeleteClass.Size = new Size(230, 75);
            btnDeleteClass.TabIndex = 3;
            btnDeleteClass.Text = "DELETE CLASS";
            btnDeleteClass.UseVisualStyleBackColor = false;
            btnDeleteClass.Click += btnDeleteClass_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(52, 48);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(383, 65);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "Class Schedule ";
            // 
            // lblModuleID
            // 
            lblModuleID.AutoSize = true;
            lblModuleID.BackColor = SystemColors.GradientActiveCaption;
            lblModuleID.BorderStyle = BorderStyle.Fixed3D;
            lblModuleID.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblModuleID.Location = new Point(446, 566);
            lblModuleID.Name = "lblModuleID";
            lblModuleID.Size = new Size(153, 42);
            lblModuleID.TabIndex = 5;
            lblModuleID.Text = "Module ID";
            // 
            // txtModuleID
            // 
            txtModuleID.BackColor = SystemColors.ButtonHighlight;
            txtModuleID.Location = new Point(608, 566);
            txtModuleID.Name = "txtModuleID";
            txtModuleID.Size = new Size(200, 39);
            txtModuleID.TabIndex = 6;
            // 
            // lblModuleName
            // 
            lblModuleName.AutoSize = true;
            lblModuleName.BackColor = SystemColors.GradientActiveCaption;
            lblModuleName.BorderStyle = BorderStyle.FixedSingle;
            lblModuleName.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblModuleName.Location = new Point(823, 563);
            lblModuleName.Name = "lblModuleName";
            lblModuleName.Size = new Size(202, 42);
            lblModuleName.TabIndex = 7;
            lblModuleName.Text = "Module Name";
            // 
            // txtModuleName
            // 
            txtModuleName.Location = new Point(1052, 566);
            txtModuleName.Name = "txtModuleName";
            txtModuleName.Size = new Size(154, 39);
            txtModuleName.TabIndex = 8;
            // 
            // lblClassDate
            // 
            lblClassDate.AutoSize = true;
            lblClassDate.BackColor = SystemColors.GradientActiveCaption;
            lblClassDate.BorderStyle = BorderStyle.Fixed3D;
            lblClassDate.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblClassDate.Location = new Point(64, 701);
            lblClassDate.Name = "lblClassDate";
            lblClassDate.Size = new Size(159, 42);
            lblClassDate.TabIndex = 9;
            lblClassDate.Text = "Class Date ";
            // 
            // lblCharges
            // 
            lblCharges.AutoSize = true;
            lblCharges.BackColor = SystemColors.GradientActiveCaption;
            lblCharges.BorderStyle = BorderStyle.Fixed3D;
            lblCharges.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCharges.Location = new Point(468, 629);
            lblCharges.Name = "lblCharges";
            lblCharges.Size = new Size(122, 42);
            lblCharges.TabIndex = 11;
            lblCharges.Text = "Charges";
            // 
            // txtCharges
            // 
            txtCharges.Location = new Point(608, 629);
            txtCharges.Name = "txtCharges";
            txtCharges.Size = new Size(174, 39);
            txtCharges.TabIndex = 12;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(25, 25, 25);
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(lblTitle);
            panel1.Location = new Point(-27, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1738, 168);
            panel1.TabIndex = 13;
            // 
            // dtpClassDate
            // 
            dtpClassDate.Location = new Point(239, 704);
            dtpClassDate.Name = "dtpClassDate";
            dtpClassDate.Size = new Size(400, 39);
            dtpClassDate.TabIndex = 14;
            // 
            // lblClassTime
            // 
            lblClassTime.AutoSize = true;
            lblClassTime.BackColor = SystemColors.GradientActiveCaption;
            lblClassTime.BorderStyle = BorderStyle.Fixed3D;
            lblClassTime.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblClassTime.Location = new Point(64, 635);
            lblClassTime.Name = "lblClassTime";
            lblClassTime.Size = new Size(153, 42);
            lblClassTime.TabIndex = 15;
            lblClassTime.Text = "Class Time";
            // 
            // txtClassTime
            // 
            txtClassTime.Location = new Point(239, 635);
            txtClassTime.Name = "txtClassTime";
            txtClassTime.Size = new Size(200, 39);
            txtClassTime.TabIndex = 16;
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.BackColor = SystemColors.GradientActiveCaption;
            lblRoom.BorderStyle = BorderStyle.Fixed3D;
            lblRoom.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoom.Location = new Point(671, 701);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(94, 42);
            lblRoom.TabIndex = 17;
            lblRoom.Text = "Room";
            // 
            // txtRoom
            // 
            txtRoom.Location = new Point(771, 701);
            txtRoom.Name = "txtRoom";
            txtRoom.Size = new Size(154, 39);
            txtRoom.TabIndex = 18;
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.BackColor = SystemColors.GradientActiveCaption;
            lblLevel.BorderStyle = BorderStyle.Fixed3D;
            lblLevel.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLevel.Location = new Point(804, 626);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(84, 42);
            lblLevel.TabIndex = 19;
            lblLevel.Text = "Level";
            // 
            // cboLevel
            // 
            cboLevel.FormattingEnabled = true;
            cboLevel.Items.AddRange(new object[] { "Beginner", "Intermediate", "Advance" });
            cboLevel.Location = new Point(914, 626);
            cboLevel.Name = "cboLevel";
            cboLevel.Size = new Size(170, 40);
            cboLevel.TabIndex = 20;
            // 
            // lblTrainerID
            // 
            lblTrainerID.AutoSize = true;
            lblTrainerID.BackColor = SystemColors.GradientActiveCaption;
            lblTrainerID.BorderStyle = BorderStyle.Fixed3D;
            lblTrainerID.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTrainerID.Location = new Point(64, 566);
            lblTrainerID.Name = "lblTrainerID";
            lblTrainerID.Size = new Size(140, 42);
            lblTrainerID.TabIndex = 21;
            lblTrainerID.Text = "Trainer ID";
            // 
            // txtTrainerID
            // 
            txtTrainerID.BackColor = SystemColors.ButtonHighlight;
            txtTrainerID.Location = new Point(223, 569);
            txtTrainerID.Name = "txtTrainerID";
            txtTrainerID.Size = new Size(200, 39);
            txtTrainerID.TabIndex = 22;
            // 
            // lblWrong
            // 
            lblWrong.AutoSize = true;
            lblWrong.ForeColor = Color.Red;
            lblWrong.Location = new Point(847, 792);
            lblWrong.Name = "lblWrong";
            lblWrong.Size = new Size(0, 32);
            lblWrong.TabIndex = 23;
            // 
            // lblConfirmed
            // 
            lblConfirmed.AutoSize = true;
            lblConfirmed.ForeColor = Color.Green;
            lblConfirmed.Location = new Point(962, 709);
            lblConfirmed.Name = "lblConfirmed";
            lblConfirmed.Size = new Size(0, 32);
            lblConfirmed.TabIndex = 24;
            // 
            // TrainerHomeForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1454, 900);
            Controls.Add(lblConfirmed);
            Controls.Add(lblWrong);
            Controls.Add(txtTrainerID);
            Controls.Add(lblTrainerID);
            Controls.Add(cboLevel);
            Controls.Add(lblLevel);
            Controls.Add(txtRoom);
            Controls.Add(lblRoom);
            Controls.Add(txtClassTime);
            Controls.Add(lblClassTime);
            Controls.Add(dtpClassDate);
            Controls.Add(panel1);
            Controls.Add(txtCharges);
            Controls.Add(lblCharges);
            Controls.Add(lblClassDate);
            Controls.Add(txtModuleName);
            Controls.Add(lblModuleName);
            Controls.Add(txtModuleID);
            Controls.Add(lblModuleID);
            Controls.Add(btnDeleteClass);
            Controls.Add(btnUpdateClass);
            Controls.Add(btnAddClass);
            Controls.Add(dgvClassSchedule);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MaximumSize = new Size(2200, 900);
            MinimizeBox = false;
            Name = "TrainerHomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClassText";
            WindowState = FormWindowState.Maximized;
            Load += TrainerHomeForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClassSchedule).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvClassSchedule;
        private Button btnAddClass;
        private Button btnUpdateClass;
        private Button btnDeleteClass;
        private Label lblTitle;
        private Label lblModuleID;
        private TextBox txtModuleID;
        private Label lblModuleName;
        private TextBox txtModuleName;
        private Label lblClassDate;
        private Label lblCharges;
        private TextBox txtCharges;
        private Panel panel1;
        private DateTimePicker dtpClassDate;
        private Label lblClassTime;
        private TextBox txtClassTime;
        private Label lblRoom;
        private TextBox txtRoom;
        private Label lblLevel;
        private ComboBox cboLevel;
        private Label lblTrainerID;
        private TextBox txtTrainerID;
        private Label lblWrong;
        private Label lblConfirmed;
    }
}