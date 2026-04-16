namespace APUCC_Project.Forms.Student
{
    partial class StudentHomeForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblGreeting = new Label();
            lblWelcome = new Label();
            panelScheduleCard = new Panel();
            dgvSchedule = new DataGridView();
            ModuleColumnHome = new DataGridViewTextBoxColumn();
            TrainerColumn = new DataGridViewTextBoxColumn();
            DayColumnHome = new DataGridViewTextBoxColumn();
            TimeColumnHome = new DataGridViewTextBoxColumn();
            RoomColumnHome = new DataGridViewTextBoxColumn();
            StatusColumnHome = new DataGridViewTextBoxColumn();
            btnUpcomingSchedule = new Button();
            btnCurrentSchedule = new Button();
            panelScheduleCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).BeginInit();
            SuspendLayout();
            // 
            // lblGreeting
            // 
            lblGreeting.AutoSize = true;
            lblGreeting.BackColor = Color.Transparent;
            lblGreeting.Font = new Font("Segoe UI Semibold", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGreeting.ForeColor = Color.Black;
            lblGreeting.Location = new Point(22, 16);
            lblGreeting.Margin = new Padding(2, 0, 2, 0);
            lblGreeting.Name = "lblGreeting";
            lblGreeting.Size = new Size(259, 30);
            lblGreeting.TabIndex = 1;
            lblGreeting.Text = "Good Evening, Abdullah ";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.BackColor = Color.Transparent;
            lblWelcome.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.Black;
            lblWelcome.Location = new Point(22, 48);
            lblWelcome.Margin = new Padding(2, 0, 2, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(248, 15);
            lblWelcome.TabIndex = 2;
            lblWelcome.Text = "Welcome back to your CodeCamp dashboard";
            // 
            // panelScheduleCard
            // 
            panelScheduleCard.BackColor = Color.FromArgb(243, 243, 243);
            panelScheduleCard.BackgroundImageLayout = ImageLayout.None;
            panelScheduleCard.BorderStyle = BorderStyle.FixedSingle;
            panelScheduleCard.Controls.Add(dgvSchedule);
            panelScheduleCard.Controls.Add(btnUpcomingSchedule);
            panelScheduleCard.Controls.Add(btnCurrentSchedule);
            panelScheduleCard.Location = new Point(22, 81);
            panelScheduleCard.Margin = new Padding(2, 1, 2, 1);
            panelScheduleCard.Name = "panelScheduleCard";
            panelScheduleCard.Padding = new Padding(11, 9, 11, 9);
            panelScheduleCard.Size = new Size(650, 247);
            panelScheduleCard.TabIndex = 3;
            // 
            // dgvSchedule
            // 
            dgvSchedule.AllowUserToDeleteRows = false;
            dgvSchedule.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(25, 25, 25);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSchedule.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSchedule.Columns.AddRange(new DataGridViewColumn[] { ModuleColumnHome, TrainerColumn, DayColumnHome, TimeColumnHome, RoomColumnHome, StatusColumnHome });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(25, 25, 25);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(1, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = Color.Transparent;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvSchedule.DefaultCellStyle = dataGridViewCellStyle2;
            dgvSchedule.EnableHeadersVisualStyles = false;
            dgvSchedule.Location = new Point(13, 39);
            dgvSchedule.Margin = new Padding(2, 1, 2, 1);
            dgvSchedule.Name = "dgvSchedule";
            dgvSchedule.ReadOnly = true;
            dgvSchedule.RowHeadersVisible = false;
            dgvSchedule.RowHeadersWidth = 82;
            dgvSchedule.Size = new Size(619, 196);
            dgvSchedule.TabIndex = 2;
            // 
            // ModuleColumnHome
            // 
            ModuleColumnHome.HeaderText = "Module";
            ModuleColumnHome.MinimumWidth = 10;
            ModuleColumnHome.Name = "ModuleColumnHome";
            ModuleColumnHome.ReadOnly = true;
            ModuleColumnHome.Width = 170;
            // 
            // TrainerColumn
            // 
            TrainerColumn.HeaderText = "Trainer";
            TrainerColumn.MinimumWidth = 10;
            TrainerColumn.Name = "TrainerColumn";
            TrainerColumn.ReadOnly = true;
            TrainerColumn.Width = 170;
            // 
            // DayColumnHome
            // 
            DayColumnHome.HeaderText = "Day";
            DayColumnHome.MinimumWidth = 10;
            DayColumnHome.Name = "DayColumnHome";
            DayColumnHome.ReadOnly = true;
            DayColumnHome.Width = 150;
            // 
            // TimeColumnHome
            // 
            TimeColumnHome.HeaderText = "Time";
            TimeColumnHome.MinimumWidth = 10;
            TimeColumnHome.Name = "TimeColumnHome";
            TimeColumnHome.ReadOnly = true;
            TimeColumnHome.Width = 200;
            // 
            // RoomColumnHome
            // 
            RoomColumnHome.HeaderText = "Room";
            RoomColumnHome.MinimumWidth = 10;
            RoomColumnHome.Name = "RoomColumnHome";
            RoomColumnHome.ReadOnly = true;
            RoomColumnHome.Width = 120;
            // 
            // StatusColumnHome
            // 
            StatusColumnHome.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            StatusColumnHome.HeaderText = "Status";
            StatusColumnHome.MinimumWidth = 10;
            StatusColumnHome.Name = "StatusColumnHome";
            StatusColumnHome.ReadOnly = true;
            // 
            // btnUpcomingSchedule
            // 
            btnUpcomingSchedule.BackColor = Color.White;
            btnUpcomingSchedule.FlatAppearance.BorderColor = Color.FromArgb(25, 25, 25);
            btnUpcomingSchedule.FlatStyle = FlatStyle.Flat;
            btnUpcomingSchedule.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpcomingSchedule.ForeColor = Color.Black;
            btnUpcomingSchedule.Location = new Point(144, 10);
            btnUpcomingSchedule.Margin = new Padding(2, 1, 2, 1);
            btnUpcomingSchedule.Name = "btnUpcomingSchedule";
            btnUpcomingSchedule.Size = new Size(135, 31);
            btnUpcomingSchedule.TabIndex = 1;
            btnUpcomingSchedule.Text = "Upcoming Schedule";
            btnUpcomingSchedule.UseVisualStyleBackColor = false;
            // 
            // btnCurrentSchedule
            // 
            btnCurrentSchedule.BackColor = Color.White;
            btnCurrentSchedule.FlatAppearance.BorderColor = Color.FromArgb(25, 25, 25);
            btnCurrentSchedule.FlatStyle = FlatStyle.Flat;
            btnCurrentSchedule.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCurrentSchedule.ForeColor = Color.Black;
            btnCurrentSchedule.Location = new Point(13, 10);
            btnCurrentSchedule.Margin = new Padding(2, 1, 2, 1);
            btnCurrentSchedule.Name = "btnCurrentSchedule";
            btnCurrentSchedule.Size = new Size(135, 31);
            btnCurrentSchedule.TabIndex = 0;
            btnCurrentSchedule.Text = "Current Schedule";
            btnCurrentSchedule.UseVisualStyleBackColor = false;
            btnCurrentSchedule.Click += btnCurrentSchedule_Click;
            // 
            // StudentHomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(724, 444);
            Controls.Add(panelScheduleCard);
            Controls.Add(lblWelcome);
            Controls.Add(lblGreeting);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2, 1, 2, 1);
            Name = "StudentHomeForm";
            Text = "StudentHomeForm";
            panelScheduleCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblGreeting;
        private Label lblWelcome;
        private Panel panelScheduleCard;
        private Button btnUpcomingSchedule;
        private Button btnCurrentSchedule;
        private DataGridView dgvSchedule;
        private DataGridViewTextBoxColumn ModuleColumnHome;
        private DataGridViewTextBoxColumn TrainerColumn;
        private DataGridViewTextBoxColumn DayColumnHome;
        private DataGridViewTextBoxColumn TimeColumnHome;
        private DataGridViewTextBoxColumn RoomColumnHome;
        private DataGridViewTextBoxColumn StatusColumnHome;
    }
}