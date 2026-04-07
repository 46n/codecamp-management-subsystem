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
            dataGridView1 = new DataGridView();
            ModuleColumnHome = new DataGridViewTextBoxColumn();
            TrainerColumn = new DataGridViewTextBoxColumn();
            DayColumnHome = new DataGridViewTextBoxColumn();
            TimeColumnHome = new DataGridViewTextBoxColumn();
            RoomColumnHome = new DataGridViewTextBoxColumn();
            StatusColumnHome = new DataGridViewTextBoxColumn();
            button2 = new Button();
            button1 = new Button();
            panelScheduleCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblGreeting
            // 
            lblGreeting.AutoSize = true;
            lblGreeting.BackColor = Color.Transparent;
            lblGreeting.Font = new Font("Segoe UI Semibold", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGreeting.ForeColor = Color.White;
            lblGreeting.Location = new Point(40, 35);
            lblGreeting.Name = "lblGreeting";
            lblGreeting.Size = new Size(508, 59);
            lblGreeting.TabIndex = 1;
            lblGreeting.Text = "Good Evening, Abdullah ";
            lblGreeting.Click += label2_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.BackColor = Color.Transparent;
            lblWelcome.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(40, 103);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(497, 32);
            lblWelcome.TabIndex = 2;
            lblWelcome.Text = "Welcome back to your CodeCamp dashboard";
            // 
            // panelScheduleCard
            // 
            panelScheduleCard.BackColor = Color.FromArgb(35, 35, 39);
            panelScheduleCard.BorderStyle = BorderStyle.FixedSingle;
            panelScheduleCard.Controls.Add(dataGridView1);
            panelScheduleCard.Controls.Add(button2);
            panelScheduleCard.Controls.Add(button1);
            panelScheduleCard.Location = new Point(40, 172);
            panelScheduleCard.Name = "panelScheduleCard";
            panelScheduleCard.Padding = new Padding(20);
            panelScheduleCard.Size = new Size(1051, 320);
            panelScheduleCard.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = Color.FromArgb(35, 35, 39);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(25, 25, 25);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ModuleColumnHome, TrainerColumn, DayColumnHome, TimeColumnHome, RoomColumnHome, StatusColumnHome });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(25, 25, 25);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(1, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = Color.Transparent;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(20, 83);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(1009, 215);
            dataGridView1.TabIndex = 2;
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
            // button2
            // 
            button2.BackColor = Color.FromArgb(42, 42, 42);
            button2.FlatAppearance.BorderColor = Color.FromArgb(25, 25, 25);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(286, 40);
            button2.Name = "button2";
            button2.Size = new Size(250, 46);
            button2.TabIndex = 1;
            button2.Text = "Upcoming Schedule";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(42, 42, 42);
            button1.FlatAppearance.BorderColor = Color.FromArgb(25, 25, 25);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(42, 40);
            button1.Name = "button1";
            button1.Size = new Size(250, 46);
            button1.TabIndex = 0;
            button1.Text = "Current Schedule";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // StudentHomeForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(42, 42, 42);
            ClientSize = new Size(1162, 688);
            Controls.Add(panelScheduleCard);
            Controls.Add(lblWelcome);
            Controls.Add(lblGreeting);
            FormBorderStyle = FormBorderStyle.None;
            Name = "StudentHomeForm";
            Text = "StudentHomeForm";
            panelScheduleCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblGreeting;
        private Label lblWelcome;
        private Panel panelScheduleCard;
        private Button button2;
        private Button button1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ModuleColumnHome;
        private DataGridViewTextBoxColumn TrainerColumn;
        private DataGridViewTextBoxColumn DayColumnHome;
        private DataGridViewTextBoxColumn TimeColumnHome;
        private DataGridViewTextBoxColumn RoomColumnHome;
        private DataGridViewTextBoxColumn StatusColumnHome;
    }
}