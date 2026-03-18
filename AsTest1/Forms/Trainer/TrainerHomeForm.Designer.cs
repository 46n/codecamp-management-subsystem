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
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            txtModuleId = new TextBox();
            label3 = new Label();
            txtModuleName = new TextBox();
            label4 = new Label();
            label5 = new Label();
            txtCharges = new TextBox();
            panel1 = new Panel();
            dateTimePicker1 = new DateTimePicker();
            label6 = new Label();
            textBox1 = new TextBox();
            ModuleID = new DataGridViewTextBoxColumn();
            ModuleName = new DataGridViewTextBoxColumn();
            ClassDate = new DataGridViewTextBoxColumn();
            ClassTime = new DataGridViewTextBoxColumn();
            Charges = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ModuleID, ModuleName, ClassDate, ClassTime, Charges });
            dataGridView1.Location = new Point(12, 84);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(1083, 638);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkGreen;
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(1114, 409);
            button1.Name = "button1";
            button1.Size = new Size(230, 75);
            button1.TabIndex = 1;
            button1.Text = "ADD CLASS";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.MenuHighlight;
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(1373, 409);
            button2.Name = "button2";
            button2.Size = new Size(230, 75);
            button2.TabIndex = 2;
            button2.Text = "UPDATE CLASS";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(192, 0, 0);
            button3.ForeColor = SystemColors.ButtonHighlight;
            button3.Location = new Point(1114, 508);
            button3.Name = "button3";
            button3.Size = new Size(230, 75);
            button3.TabIndex = 3;
            button3.Text = "DELETE CLASS";
            button3.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(3, 8);
            label1.Name = "label1";
            label1.Size = new Size(314, 59);
            label1.TabIndex = 4;
            label1.Text = "Class Schedule ";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.GradientActiveCaption;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(1114, 89);
            label2.Name = "label2";
            label2.Size = new Size(153, 42);
            label2.TabIndex = 5;
            label2.Text = "Module ID";
            // 
            // txtModuleId
            // 
            txtModuleId.BackColor = SystemColors.ButtonHighlight;
            txtModuleId.Location = new Point(1303, 92);
            txtModuleId.Name = "txtModuleId";
            txtModuleId.Size = new Size(388, 39);
            txtModuleId.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.GradientActiveCaption;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(1114, 150);
            label3.Name = "label3";
            label3.Size = new Size(202, 42);
            label3.TabIndex = 7;
            label3.Text = "Module Name";
            // 
            // txtModuleName
            // 
            txtModuleName.Location = new Point(1335, 153);
            txtModuleName.Name = "txtModuleName";
            txtModuleName.Size = new Size(356, 39);
            txtModuleName.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.GradientActiveCaption;
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(1114, 215);
            label4.Name = "label4";
            label4.Size = new Size(159, 42);
            label4.TabIndex = 9;
            label4.Text = "Class Date ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.GradientActiveCaption;
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(1114, 340);
            label5.Name = "label5";
            label5.Size = new Size(122, 42);
            label5.TabIndex = 11;
            label5.Text = "Charges";
            // 
            // txtCharges
            // 
            txtCharges.Location = new Point(1259, 343);
            txtCharges.Name = "txtCharges";
            txtCharges.Size = new Size(432, 39);
            txtCharges.TabIndex = 12;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.MenuHighlight;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(9, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1764, 72);
            panel1.TabIndex = 13;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(1291, 216);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(400, 39);
            dateTimePicker1.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.GradientActiveCaption;
            label6.BorderStyle = BorderStyle.Fixed3D;
            label6.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(1114, 285);
            label6.Name = "label6";
            label6.Size = new Size(153, 42);
            label6.TabIndex = 15;
            label6.Text = "Class Time";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1291, 285);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(400, 39);
            textBox1.TabIndex = 16;
            // 
            // ModuleID
            // 
            ModuleID.HeaderText = "Module ID";
            ModuleID.MinimumWidth = 10;
            ModuleID.Name = "ModuleID";
            ModuleID.Width = 200;
            // 
            // ModuleName
            // 
            ModuleName.HeaderText = "Module Name";
            ModuleName.MinimumWidth = 10;
            ModuleName.Name = "ModuleName";
            ModuleName.Width = 200;
            // 
            // ClassDate
            // 
            ClassDate.HeaderText = "Class Date";
            ClassDate.MinimumWidth = 10;
            ClassDate.Name = "ClassDate";
            ClassDate.Width = 200;
            // 
            // ClassTime
            // 
            ClassTime.HeaderText = "Class Time";
            ClassTime.MinimumWidth = 10;
            ClassTime.Name = "ClassTime";
            ClassTime.Width = 200;
            // 
            // Charges
            // 
            Charges.HeaderText = "Charges";
            Charges.MinimumWidth = 10;
            Charges.Name = "Charges";
            Charges.Width = 200;
            // 
            // TrainerHomeForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1766, 829);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(dateTimePicker1);
            Controls.Add(panel1);
            Controls.Add(txtCharges);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtModuleName);
            Controls.Add(label3);
            Controls.Add(txtModuleId);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            MaximumSize = new Size(2200, 900);
            Name = "TrainerHomeForm";
            Text = "s";
            Load += TrainerHomeForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private Label label2;
        private TextBox txtModuleId;
        private Label label3;
        private TextBox txtModuleName;
        private Label label4;
        private Label label5;
        private TextBox txtCharges;
        private Panel panel1;
        private DateTimePicker dateTimePicker1;
        private Label label6;
        private TextBox textBox1;
        private DataGridViewTextBoxColumn ModuleID;
        private DataGridViewTextBoxColumn ModuleName;
        private DataGridViewTextBoxColumn ClassDate;
        private DataGridViewTextBoxColumn ClassTime;
        private DataGridViewTextBoxColumn Charges;
    }
}