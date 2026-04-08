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
            label1 = new Label();
            ModuleIdLabel = new Label();
            txtModuleID = new TextBox();
            ModuleNameLabel = new Label();
            txtModuleName = new TextBox();
            ClassDateLabel = new Label();
            ChargesLabel = new Label();
            txtCharges = new TextBox();
            panel1 = new Panel();
            dtpClassDate = new DateTimePicker();
            ClaasTimeLabel = new Label();
            txtClassTime = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvClassSchedule).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvClassSchedule
            // 
            dgvClassSchedule.BorderStyle = BorderStyle.Fixed3D;
            dgvClassSchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClassSchedule.Location = new Point(64, 182);
            dgvClassSchedule.Name = "dgvClassSchedule";
            dgvClassSchedule.RowHeadersWidth = 82;
            dgvClassSchedule.Size = new Size(1071, 344);
            dgvClassSchedule.TabIndex = 0;
            dgvClassSchedule.CellContentClick += dgvClassSchedule_CellContentClick;
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
            btnDeleteClass.Click += deleteClass_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(52, 48);
            label1.Name = "label1";
            label1.Size = new Size(352, 65);
            label1.TabIndex = 4;
            label1.Text = "Class Schedule ";
            label1.Click += label1_Click;
            // 
            // ModuleIdLabel
            // 
            ModuleIdLabel.AutoSize = true;
            ModuleIdLabel.BackColor = SystemColors.GradientActiveCaption;
            ModuleIdLabel.BorderStyle = BorderStyle.Fixed3D;
            ModuleIdLabel.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModuleIdLabel.Location = new Point(64, 563);
            ModuleIdLabel.Name = "ModuleIdLabel";
            ModuleIdLabel.Size = new Size(153, 42);
            ModuleIdLabel.TabIndex = 5;
            ModuleIdLabel.Text = "Module ID";
            // 
            // txtModuleID
            // 
            txtModuleID.BackColor = SystemColors.ButtonHighlight;
            txtModuleID.Location = new Point(239, 566);
            txtModuleID.Name = "txtModuleID";
            txtModuleID.Size = new Size(200, 39);
            txtModuleID.TabIndex = 6;
            txtModuleID.TextChanged += txtModuleID_TextChanged;
            // 
            // ModuleNameLabel
            // 
            ModuleNameLabel.AutoSize = true;
            ModuleNameLabel.BackColor = SystemColors.GradientActiveCaption;
            ModuleNameLabel.BorderStyle = BorderStyle.FixedSingle;
            ModuleNameLabel.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ModuleNameLabel.Location = new Point(494, 566);
            ModuleNameLabel.Name = "ModuleNameLabel";
            ModuleNameLabel.Size = new Size(202, 42);
            ModuleNameLabel.TabIndex = 7;
            ModuleNameLabel.Text = "Module Name";
            // 
            // txtModuleName
            // 
            txtModuleName.Location = new Point(731, 569);
            txtModuleName.Name = "txtModuleName";
            txtModuleName.Size = new Size(200, 39);
            txtModuleName.TabIndex = 8;
            // 
            // ClassDateLabel
            // 
            ClassDateLabel.AutoSize = true;
            ClassDateLabel.BackColor = SystemColors.GradientActiveCaption;
            ClassDateLabel.BorderStyle = BorderStyle.Fixed3D;
            ClassDateLabel.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ClassDateLabel.Location = new Point(64, 701);
            ClassDateLabel.Name = "ClassDateLabel";
            ClassDateLabel.Size = new Size(159, 42);
            ClassDateLabel.TabIndex = 9;
            ClassDateLabel.Text = "Class Date ";
            // 
            // ChargesLabel
            // 
            ChargesLabel.AutoSize = true;
            ChargesLabel.BackColor = SystemColors.GradientActiveCaption;
            ChargesLabel.BorderStyle = BorderStyle.Fixed3D;
            ChargesLabel.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ChargesLabel.Location = new Point(494, 632);
            ChargesLabel.Name = "ChargesLabel";
            ChargesLabel.Size = new Size(122, 42);
            ChargesLabel.TabIndex = 11;
            ChargesLabel.Text = "Charges";
            // 
            // txtCharges
            // 
            txtCharges.Location = new Point(655, 632);
            txtCharges.Name = "txtCharges";
            txtCharges.Size = new Size(200, 39);
            txtCharges.TabIndex = 12;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.MenuHighlight;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-27, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1800, 168);
            panel1.TabIndex = 13;
            panel1.Paint += panel1_Paint;
            // 
            // dtpClassDate
            // 
            dtpClassDate.Location = new Point(239, 704);
            dtpClassDate.Name = "dtpClassDate";
            dtpClassDate.Size = new Size(400, 39);
            dtpClassDate.TabIndex = 14;
            // 
            // ClaasTimeLabel
            // 
            ClaasTimeLabel.AutoSize = true;
            ClaasTimeLabel.BackColor = SystemColors.GradientActiveCaption;
            ClaasTimeLabel.BorderStyle = BorderStyle.Fixed3D;
            ClaasTimeLabel.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ClaasTimeLabel.Location = new Point(64, 635);
            ClaasTimeLabel.Name = "ClaasTimeLabel";
            ClaasTimeLabel.Size = new Size(153, 42);
            ClaasTimeLabel.TabIndex = 15;
            ClaasTimeLabel.Text = "Class Time";
            // 
            // txtClassTime
            // 
            txtClassTime.Location = new Point(239, 635);
            txtClassTime.Name = "txtClassTime";
            txtClassTime.Size = new Size(200, 39);
            txtClassTime.TabIndex = 16;
            // 
            // TrainerHomeForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1740, 900);
            Controls.Add(txtClassTime);
            Controls.Add(ClaasTimeLabel);
            Controls.Add(dtpClassDate);
            Controls.Add(panel1);
            Controls.Add(txtCharges);
            Controls.Add(ChargesLabel);
            Controls.Add(ClassDateLabel);
            Controls.Add(txtModuleName);
            Controls.Add(ModuleNameLabel);
            Controls.Add(txtModuleID);
            Controls.Add(ModuleIdLabel);
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
        private Label label1;
        private Label ModuleIdLabel;
        private TextBox txtModuleID;
        private Label ModuleNameLabel;
        private TextBox txtModuleName;
        private Label ClassDateLabel;
        private Label ChargesLabel;
        private TextBox txtCharges;
        private Panel panel1;
        private DateTimePicker dtpClassDate;
        private Label ClaasTimeLabel;
        private TextBox txtClassTime;
    }
}