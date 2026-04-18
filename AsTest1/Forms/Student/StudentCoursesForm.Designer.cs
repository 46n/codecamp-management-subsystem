namespace APUCC_Project.Forms.Student
{
    partial class StudentCoursesForm
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            FillPanelCourses = new Panel();
            groupBox1 = new GroupBox();
            dataGridView2 = new DataGridView();
            PendingRequestIdColumn = new DataGridViewTextBoxColumn();
            PendingTrainerColumn = new DataGridViewTextBoxColumn();
            PendingCourseNameColumn = new DataGridViewTextBoxColumn();
            PendingLevelColumn = new DataGridViewTextBoxColumn();
            PendingRequestDateColumn = new DataGridViewTextBoxColumn();
            PendingStatusColumn = new DataGridViewTextBoxColumn();
            PendingActionColumn = new DataGridViewButtonColumn();
            groupBox2 = new GroupBox();
            button3 = new Button();
            comboBox1 = new ComboBox();
            label2 = new Label();
            CurrentCourses = new GroupBox();
            dataGridView1 = new DataGridView();
            TrainerColumn = new DataGridViewTextBoxColumn();
            ScheduleColumn = new DataGridViewTextBoxColumn();
            StatusColumn = new DataGridViewTextBoxColumn();
            CourseNameColumn = new DataGridViewTextBoxColumn();
            FillPanelCourses.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            groupBox2.SuspendLayout();
            CurrentCourses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // FillPanelCourses
            // 
            FillPanelCourses.AutoScroll = true;
            FillPanelCourses.BackColor = Color.White;
            FillPanelCourses.BackgroundImageLayout = ImageLayout.Center;
            FillPanelCourses.Controls.Add(groupBox1);
            FillPanelCourses.Controls.Add(groupBox2);
            FillPanelCourses.Controls.Add(CurrentCourses);
            FillPanelCourses.Dock = DockStyle.Fill;
            FillPanelCourses.Location = new Point(0, 0);
            FillPanelCourses.Margin = new Padding(5);
            FillPanelCourses.Name = "FillPanelCourses";
            FillPanelCourses.Padding = new Padding(10);
            FillPanelCourses.Size = new Size(1266, 1040);
            FillPanelCourses.TabIndex = 0;
            FillPanelCourses.Paint += FillPanelCourses_Paint;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(dataGridView2);
            groupBox1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            groupBox1.ForeColor = Color.Black;
            groupBox1.Location = new Point(13, 637);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1084, 314);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Pending Requests";
            // 
            // dataGridView2
            // 
            dataGridViewCellStyle1.Font = new Font("Segoe Fluent Icons", 7.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView2.BackgroundColor = Color.White;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { PendingRequestIdColumn, PendingTrainerColumn, PendingCourseNameColumn, PendingLevelColumn, PendingRequestDateColumn, PendingStatusColumn, PendingActionColumn });
            dataGridView2.Location = new Point(37, 60);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.RowHeadersWidth = 82;
            dataGridView2.Size = new Size(1013, 234);
            dataGridView2.TabIndex = 0;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // PendingRequestIdColumn
            // 
            PendingRequestIdColumn.DataPropertyName = "RequestID";
            PendingRequestIdColumn.HeaderText = "Request ID";
            PendingRequestIdColumn.MinimumWidth = 10;
            PendingRequestIdColumn.Name = "PendingRequestIdColumn";
            PendingRequestIdColumn.ReadOnly = true;
            PendingRequestIdColumn.Visible = false;
            PendingRequestIdColumn.Width = 200;
            // 
            // PendingTrainerColumn
            // 
            PendingTrainerColumn.HeaderText = "Trainer";
            PendingTrainerColumn.MinimumWidth = 10;
            PendingTrainerColumn.Name = "PendingTrainerColumn";
            PendingTrainerColumn.ReadOnly = true;
            PendingTrainerColumn.Width = 180;
            // 
            // PendingCourseNameColumn
            // 
            PendingCourseNameColumn.HeaderText = "Course Name";
            PendingCourseNameColumn.MinimumWidth = 10;
            PendingCourseNameColumn.Name = "PendingCourseNameColumn";
            PendingCourseNameColumn.ReadOnly = true;
            PendingCourseNameColumn.Width = 220;
            // 
            // PendingLevelColumn
            // 
            PendingLevelColumn.HeaderText = "Level";
            PendingLevelColumn.MinimumWidth = 10;
            PendingLevelColumn.Name = "PendingLevelColumn";
            PendingLevelColumn.ReadOnly = true;
            PendingLevelColumn.Width = 120;
            // 
            // PendingRequestDateColumn
            // 
            PendingRequestDateColumn.HeaderText = "Request Date";
            PendingRequestDateColumn.MinimumWidth = 10;
            PendingRequestDateColumn.Name = "PendingRequestDateColumn";
            PendingRequestDateColumn.ReadOnly = true;
            PendingRequestDateColumn.Width = 160;
            // 
            // PendingStatusColumn
            // 
            PendingStatusColumn.HeaderText = "Status";
            PendingStatusColumn.MinimumWidth = 10;
            PendingStatusColumn.Name = "PendingStatusColumn";
            PendingStatusColumn.ReadOnly = true;
            PendingStatusColumn.Width = 120;
            // 
            // PendingActionColumn
            // 
            PendingActionColumn.HeaderText = "Action";
            PendingActionColumn.MinimumWidth = 10;
            PendingActionColumn.Name = "PendingActionColumn";
            PendingActionColumn.ReadOnly = true;
            PendingActionColumn.Text = "Cancel";
            PendingActionColumn.UseColumnTextForButtonValue = true;
            PendingActionColumn.Width = 150;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.White;
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Controls.Add(label2);
            groupBox2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            groupBox2.ForeColor = Color.Black;
            groupBox2.Location = new Point(13, 370);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1084, 243);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Request New Course";
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(102, 146, 153);
            button3.BackgroundImageLayout = ImageLayout.None;
            button3.Cursor = Cursors.Hand;
            button3.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(349, 147);
            button3.Name = "button3";
            button3.Size = new Size(292, 60);
            button3.TabIndex = 3;
            button3.Text = "Request";
            button3.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(330, 67);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(662, 45);
            comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(37, 67);
            label2.Name = "label2";
            label2.Size = new Size(184, 31);
            label2.TabIndex = 0;
            label2.Text = "Available Course";
            // 
            // CurrentCourses
            // 
            CurrentCourses.BackColor = Color.White;
            CurrentCourses.Controls.Add(dataGridView1);
            CurrentCourses.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            CurrentCourses.ForeColor = Color.Black;
            CurrentCourses.Location = new Point(13, 24);
            CurrentCourses.Name = "CurrentCourses";
            CurrentCourses.Size = new Size(1084, 314);
            CurrentCourses.TabIndex = 1;
            CurrentCourses.TabStop = false;
            CurrentCourses.Text = "Current Enrolled Courses";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle2.Font = new Font("Segoe Fluent Icons", 7.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.BackgroundColor = Color.White;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { TrainerColumn, ScheduleColumn, StatusColumn, CourseNameColumn });
            dataGridView1.Location = new Point(37, 60);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(1013, 234);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // TrainerColumn
            // 
            TrainerColumn.HeaderText = "Trainer";
            TrainerColumn.MinimumWidth = 10;
            TrainerColumn.Name = "TrainerColumn";
            TrainerColumn.ReadOnly = true;
            TrainerColumn.Width = 250;
            // 
            // ScheduleColumn
            // 
            ScheduleColumn.HeaderText = "Schedule";
            ScheduleColumn.MinimumWidth = 10;
            ScheduleColumn.Name = "ScheduleColumn";
            ScheduleColumn.ReadOnly = true;
            ScheduleColumn.Width = 250;
            // 
            // StatusColumn
            // 
            StatusColumn.HeaderText = "Status";
            StatusColumn.MinimumWidth = 10;
            StatusColumn.Name = "StatusColumn";
            StatusColumn.ReadOnly = true;
            StatusColumn.Width = 150;
            // 
            // CourseNameColumn
            // 
            CourseNameColumn.HeaderText = "Course Name";
            CourseNameColumn.MinimumWidth = 10;
            CourseNameColumn.Name = "CourseNameColumn";
            CourseNameColumn.ReadOnly = true;
            CourseNameColumn.Width = 350;
            // 
            // StudentCoursesForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1266, 1040);
            Controls.Add(FillPanelCourses);
            Name = "StudentCoursesForm";
            Text = "StudentCoursesForm";
            FillPanelCourses.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            CurrentCourses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel FillPanelCourses;
        private GroupBox groupBox2;
        private ComboBox comboBox1;
        private Label label2;
        private GroupBox CurrentCourses;
        private DataGridView dataGridView1;
        private Button button3;
        private DataGridViewTextBoxColumn TrainerColumn;
        private DataGridViewTextBoxColumn ScheduleColumn;
        private DataGridViewTextBoxColumn StatusColumn;
        private DataGridViewTextBoxColumn CourseNameColumn;
        private GroupBox groupBox1;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn PendingRequestIdColumn;
        private DataGridViewTextBoxColumn PendingTrainerColumn;
        private DataGridViewTextBoxColumn PendingCourseNameColumn;
        private DataGridViewTextBoxColumn PendingLevelColumn;
        private DataGridViewTextBoxColumn PendingRequestDateColumn;
        private DataGridViewTextBoxColumn PendingStatusColumn;
        private DataGridViewButtonColumn PendingActionColumn;
    }
}
