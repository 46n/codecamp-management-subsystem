namespace APUCC_Project.Forms.Lecturer
{
    partial class LecturerViewStudentsForm
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
            VeiwStudentpnl = new Panel();
            ViewStudentslbl = new Label();
            grpFilter = new GroupBox();
            lblModule = new Label();
            cboModule = new ComboBox();
            btnShowAll = new Button();
            btnFilter = new Button();
            cboStatus = new ComboBox();
            cboLevel = new ComboBox();
            lblStatus = new Label();
            lblLevel = new Label();
            dgvStudentList = new DataGridView();
            btnDeleteSelected = new Button();
            btnClose = new Button();
            lblCount = new Label();
            lblFormStatus = new Label();
            VeiwStudentpnl.SuspendLayout();
            grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudentList).BeginInit();
            SuspendLayout();
            // 
            // VeiwStudentpnl
            // 
            VeiwStudentpnl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            VeiwStudentpnl.BackColor = Color.FromArgb(25, 25, 25);
            VeiwStudentpnl.Controls.Add(ViewStudentslbl);
            VeiwStudentpnl.Location = new Point(-7, -6);
            VeiwStudentpnl.Name = "VeiwStudentpnl";
            VeiwStudentpnl.Size = new Size(1380, 168);
            VeiwStudentpnl.TabIndex = 0;
            // 
            // ViewStudentslbl
            // 
            ViewStudentslbl.AutoSize = true;
            ViewStudentslbl.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ViewStudentslbl.ForeColor = Color.White;
            ViewStudentslbl.Location = new Point(62, 44);
            ViewStudentslbl.Name = "ViewStudentslbl";
            ViewStudentslbl.Size = new Size(366, 65);
            ViewStudentslbl.TabIndex = 0;
            ViewStudentslbl.Text = "View Students";
            // 
            // grpFilter
            // 
            grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpFilter.Controls.Add(lblModule);
            grpFilter.Controls.Add(cboModule);
            grpFilter.Controls.Add(btnShowAll);
            grpFilter.Controls.Add(btnFilter);
            grpFilter.Controls.Add(cboStatus);
            grpFilter.Controls.Add(cboLevel);
            grpFilter.Controls.Add(lblStatus);
            grpFilter.Controls.Add(lblLevel);
            grpFilter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpFilter.Location = new Point(12, 180);
            grpFilter.Name = "grpFilter";
            grpFilter.Size = new Size(1356, 118);
            grpFilter.TabIndex = 1;
            grpFilter.TabStop = false;
            grpFilter.Text = "Filter";
            // 
            // lblModule
            // 
            lblModule.AutoSize = true;
            lblModule.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblModule.Location = new Point(590, 46);
            lblModule.Name = "lblModule";
            lblModule.Size = new Size(122, 37);
            lblModule.TabIndex = 8;
            lblModule.Text = "Module :";
            // 
            // cboModule
            // 
            cboModule.FormattingEnabled = true;
            cboModule.Location = new Point(794, 37);
            cboModule.Name = "cboModule";
            cboModule.Size = new Size(155, 53);
            cboModule.TabIndex = 7;
            // 
            // btnShowAll
            // 
            btnShowAll.Location = new Point(1086, 40);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(165, 50);
            btnShowAll.TabIndex = 6;
            btnShowAll.Text = "Show All";
            btnShowAll.UseVisualStyleBackColor = true;
            btnShowAll.Click += btnShowAll_Click;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(955, 40);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(125, 50);
            btnFilter.TabIndex = 5;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // cboStatus
            // 
            cboStatus.FormattingEnabled = true;
            cboStatus.Location = new Point(429, 40);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(155, 53);
            cboStatus.TabIndex = 4;
            // 
            // cboLevel
            // 
            cboLevel.FormattingEnabled = true;
            cboLevel.Location = new Point(135, 40);
            cboLevel.Name = "cboLevel";
            cboLevel.Size = new Size(155, 53);
            cboLevel.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(296, 46);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(101, 37);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Status :";
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLevel.Location = new Point(18, 46);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(91, 37);
            lblLevel.TabIndex = 0;
            lblLevel.Text = "Level :";
            // 
            // dgvStudentList
            // 
            dgvStudentList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvStudentList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudentList.Location = new Point(17, 304);
            dgvStudentList.Name = "dgvStudentList";
            dgvStudentList.RowHeadersWidth = 82;
            dgvStudentList.Size = new Size(1246, 274);
            dgvStudentList.TabIndex = 2;
            dgvStudentList.CellClick += dgvStudentList_CellClick;
            // 
            // btnDeleteSelected
            // 
            btnDeleteSelected.Location = new Point(42, 674);
            btnDeleteSelected.Name = "btnDeleteSelected";
            btnDeleteSelected.Size = new Size(265, 65);
            btnDeleteSelected.TabIndex = 3;
            btnDeleteSelected.Text = "Delete Selected";
            btnDeleteSelected.UseVisualStyleBackColor = true;
            btnDeleteSelected.Click += btnDeleteSelected_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(371, 674);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(210, 65);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Location = new Point(53, 600);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(0, 32);
            lblCount.TabIndex = 5;
            lblCount.Visible = false;
            // 
            // lblFormStatus
            // 
            lblFormStatus.AutoSize = true;
            lblFormStatus.Location = new Point(37, 600);
            lblFormStatus.Name = "lblFormStatus";
            lblFormStatus.Size = new Size(0, 32);
            lblFormStatus.TabIndex = 6;
            // 
            // LecturerViewStudentsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1637, 784);
            Controls.Add(lblFormStatus);
            Controls.Add(lblCount);
            Controls.Add(btnClose);
            Controls.Add(btnDeleteSelected);
            Controls.Add(dgvStudentList);
            Controls.Add(grpFilter);
            Controls.Add(VeiwStudentpnl);
            Name = "LecturerViewStudentsForm";
            Text = "LecturerViewStudentsForm";
            Load += LecturerViewStudentsForm_Load;
            VeiwStudentpnl.ResumeLayout(false);
            VeiwStudentpnl.PerformLayout();
            grpFilter.ResumeLayout(false);
            grpFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudentList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel VeiwStudentpnl;
        private Label ViewStudentslbl;
        private GroupBox grpFilter;
        private Label lblLevel;
        private Label lblStatus;
        private Button btnShowAll;
        private Button btnFilter;
        private ComboBox cboStatus;
        private ComboBox cboLevel;
        private DataGridView dgvStudentList;
        private Label lblModule;
        private ComboBox cboModule;
        private Button btnDeleteSelected;
        private Button btnClose;
        private Label lblCount;
        private Label lblFormStatus;
    }
}
