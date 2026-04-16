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
            FillPanelCourses = new Panel();
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
            groupBox2.SuspendLayout();
            CurrentCourses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // FillPanelCourses
            // 
            FillPanelCourses.BackColor = Color.White;
            FillPanelCourses.BackgroundImageLayout = ImageLayout.Center;
            FillPanelCourses.Controls.Add(groupBox2);
            FillPanelCourses.Controls.Add(CurrentCourses);
            FillPanelCourses.Dock = DockStyle.Fill;
            FillPanelCourses.Location = new Point(0, 0);
            FillPanelCourses.Margin = new Padding(5);
            FillPanelCourses.Name = "FillPanelCourses";
            FillPanelCourses.Padding = new Padding(10);
            FillPanelCourses.Size = new Size(1266, 716);
            FillPanelCourses.TabIndex = 0;
            FillPanelCourses.Paint += FillPanelCourses_Paint;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.White;
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Controls.Add(label2);
            groupBox2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            groupBox2.ForeColor = Color.Black;
            groupBox2.Location = new Point(74, 371);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(890, 200);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Request New Course";
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(102, 146, 153);
            button3.BackgroundImageLayout = ImageLayout.None;
            button3.Cursor = Cursors.Hand;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(292, 137);
            button3.Name = "button3";
            button3.Size = new Size(292, 46);
            button3.TabIndex = 3;
            button3.Text = "Request";
            button3.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(256, 67);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(587, 45);
            comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(37, 67);
            label2.Name = "label2";
            label2.Size = new Size(191, 32);
            label2.TabIndex = 0;
            label2.Text = "Available Course";
            // 
            // CurrentCourses
            // 
            CurrentCourses.BackColor = Color.White;
            CurrentCourses.Controls.Add(dataGridView1);
            CurrentCourses.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            CurrentCourses.ForeColor = Color.Black;
            CurrentCourses.Location = new Point(74, 25);
            CurrentCourses.Name = "CurrentCourses";
            CurrentCourses.Size = new Size(890, 314);
            CurrentCourses.TabIndex = 1;
            CurrentCourses.TabStop = false;
            CurrentCourses.Text = "Current Enrolled Courses";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Font = new Font("Segoe Fluent Icons", 7.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.BackgroundColor = Color.White;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { TrainerColumn, ScheduleColumn, StatusColumn, CourseNameColumn });
            dataGridView1.Location = new Point(37, 60);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(806, 234);
            dataGridView1.TabIndex = 0;
            // 
            // TrainerColumn
            // 
            TrainerColumn.HeaderText = "Trainer";
            TrainerColumn.MinimumWidth = 10;
            TrainerColumn.Name = "TrainerColumn";
            TrainerColumn.ReadOnly = true;
            TrainerColumn.Width = 200;
            // 
            // ScheduleColumn
            // 
            ScheduleColumn.HeaderText = "Schedule";
            ScheduleColumn.MinimumWidth = 10;
            ScheduleColumn.Name = "ScheduleColumn";
            ScheduleColumn.ReadOnly = true;
            ScheduleColumn.Width = 200;
            // 
            // StatusColumn
            // 
            StatusColumn.HeaderText = "Status";
            StatusColumn.MinimumWidth = 10;
            StatusColumn.Name = "StatusColumn";
            StatusColumn.ReadOnly = true;
            StatusColumn.Width = 200;
            // 
            // CourseNameColumn
            // 
            CourseNameColumn.HeaderText = "Course Name";
            CourseNameColumn.MinimumWidth = 10;
            CourseNameColumn.Name = "CourseNameColumn";
            CourseNameColumn.ReadOnly = true;
            CourseNameColumn.Width = 200;
            // 
            // StudentCoursesForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1266, 716);
            Controls.Add(FillPanelCourses);
            Name = "StudentCoursesForm";
            Text = "StudentCoursesForm";
            FillPanelCourses.ResumeLayout(false);
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
    }
}
