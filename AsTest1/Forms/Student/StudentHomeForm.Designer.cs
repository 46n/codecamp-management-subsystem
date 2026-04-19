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
            lblWelcomeMessage = new Label();
            panelScheduleCard = new Panel();
            dgvSchedule = new DataGridView();
            ModuleColumnHome = new DataGridViewTextBoxColumn();
            TrainerColumn = new DataGridViewTextBoxColumn();
            DateColumnHome = new DataGridViewTextBoxColumn();
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
            lblGreeting.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGreeting.ForeColor = Color.Black;
            lblGreeting.Location = new Point(13, 18);
            lblGreeting.Margin = new Padding(4, 0, 4, 0);
            lblGreeting.Name = "lblGreeting";
            lblGreeting.Size = new Size(354, 51);
            lblGreeting.TabIndex = 1;
            lblGreeting.Text = "Good day, Student!";
            // 
            // lblWelcomeMessage
            // 
            lblWelcomeMessage.AutoSize = true;
            lblWelcomeMessage.BackColor = Color.Transparent;
            lblWelcomeMessage.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWelcomeMessage.ForeColor = Color.Black;
            lblWelcomeMessage.Location = new Point(13, 86);
            lblWelcomeMessage.Margin = new Padding(4, 0, 4, 0);
            lblWelcomeMessage.Name = "lblWelcomeMessage";
            lblWelcomeMessage.Size = new Size(421, 31);
            lblWelcomeMessage.TabIndex = 2;
            lblWelcomeMessage.Text = "Welcome to your CodeCamp dashboard";
            // 
            // panelScheduleCard
            // 
            panelScheduleCard.BackColor = Color.FromArgb(243, 243, 243);
            panelScheduleCard.BackgroundImageLayout = ImageLayout.None;
            panelScheduleCard.BorderStyle = BorderStyle.FixedSingle;
            panelScheduleCard.Controls.Add(dgvSchedule);
            panelScheduleCard.Controls.Add(btnUpcomingSchedule);
            panelScheduleCard.Controls.Add(btnCurrentSchedule);
            panelScheduleCard.Location = new Point(13, 157);
            panelScheduleCard.Margin = new Padding(4, 2, 4, 2);
            panelScheduleCard.Name = "panelScheduleCard";
            panelScheduleCard.Padding = new Padding(20, 19, 20, 19);
            panelScheduleCard.Size = new Size(1139, 525);
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
            dgvSchedule.Columns.AddRange(new DataGridViewColumn[] { ModuleColumnHome, TrainerColumn, DateColumnHome, DayColumnHome, TimeColumnHome, RoomColumnHome, StatusColumnHome });
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
            dgvSchedule.Location = new Point(24, 83);
            dgvSchedule.Margin = new Padding(4, 2, 4, 2);
            dgvSchedule.Name = "dgvSchedule";
            dgvSchedule.ReadOnly = true;
            dgvSchedule.RowHeadersVisible = false;
            dgvSchedule.RowHeadersWidth = 82;
            dgvSchedule.Size = new Size(1082, 418);
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
            // DateColumnHome
            // 
            DateColumnHome.HeaderText = "Date";
            DateColumnHome.MinimumWidth = 10;
            DateColumnHome.Name = "DateColumnHome";
            DateColumnHome.ReadOnly = true;
            DateColumnHome.Width = 120;
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
            btnUpcomingSchedule.Location = new Point(267, 21);
            btnUpcomingSchedule.Margin = new Padding(4, 2, 4, 2);
            btnUpcomingSchedule.Name = "btnUpcomingSchedule";
            btnUpcomingSchedule.Size = new Size(251, 66);
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
            btnCurrentSchedule.Location = new Point(24, 21);
            btnCurrentSchedule.Margin = new Padding(4, 2, 4, 2);
            btnCurrentSchedule.Name = "btnCurrentSchedule";
            btnCurrentSchedule.Size = new Size(251, 66);
            btnCurrentSchedule.TabIndex = 0;
            btnCurrentSchedule.Text = "Current Schedule";
            btnCurrentSchedule.UseVisualStyleBackColor = false;
            btnCurrentSchedule.Click += btnCurrentSchedule_Click;
            // 
            // StudentHomeForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1181, 731);
            Controls.Add(panelScheduleCard);
            Controls.Add(lblWelcomeMessage);
            Controls.Add(lblGreeting);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 2, 4, 2);
            Name = "StudentHomeForm";
            Text = "StudentHomeForm";
            panelScheduleCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblGreeting;
        private Label lblWelcomeMessage;
        private Panel panelScheduleCard;
        private Button btnUpcomingSchedule;
        private Button btnCurrentSchedule;
        private DataGridView dgvSchedule;
        private DataGridViewTextBoxColumn ModuleColumnHome;
        private DataGridViewTextBoxColumn TrainerColumn;
        private DataGridViewTextBoxColumn DateColumnHome;
        private DataGridViewTextBoxColumn DayColumnHome;
        private DataGridViewTextBoxColumn TimeColumnHome;
        private DataGridViewTextBoxColumn RoomColumnHome;
        private DataGridViewTextBoxColumn StatusColumnHome;
    }
}
