namespace APUCC_Project.Forms.Common
{
    partial class ProfileForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelCard = new Panel();
            btnSignOut = new Button();
            lblHint = new Label();
            lblRoleValue = new Label();
            lblRoleLabel = new Label();
            lblTitle = new Label();
            panelCard.SuspendLayout();
            SuspendLayout();
            // 
            // panelCard
            // 
            panelCard.BackColor = Color.White;
            panelCard.BorderStyle = BorderStyle.FixedSingle;
            panelCard.Controls.Add(btnSignOut);
            panelCard.Controls.Add(lblHint);
            panelCard.Controls.Add(lblRoleValue);
            panelCard.Controls.Add(lblRoleLabel);
            panelCard.Controls.Add(lblTitle);
            panelCard.Location = new Point(48, 51);
            panelCard.Margin = new Padding(6, 6, 6, 6);
            panelCard.Name = "panelCard";
            panelCard.Size = new Size(808, 518);
            panelCard.TabIndex = 0;
            // 
            // btnSignOut
            // 
            btnSignOut.BackColor = Color.FromArgb(192, 57, 43);
            btnSignOut.FlatAppearance.BorderSize = 0;
            btnSignOut.FlatStyle = FlatStyle.Flat;
            btnSignOut.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSignOut.ForeColor = Color.White;
            btnSignOut.Location = new Point(45, 371);
            btnSignOut.Margin = new Padding(6, 6, 6, 6);
            btnSignOut.Name = "btnSignOut";
            btnSignOut.Size = new Size(721, 90);
            btnSignOut.TabIndex = 4;
            btnSignOut.Text = "Sign Out";
            btnSignOut.UseVisualStyleBackColor = false;
            btnSignOut.Click += btnSignOut_Click;
            // 
            // lblHint
            // 
            lblHint.AutoSize = true;
            lblHint.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHint.ForeColor = Color.DimGray;
            lblHint.Location = new Point(45, 224);
            lblHint.Margin = new Padding(6, 0, 6, 0);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(539, 32);
            lblHint.TabIndex = 3;
            lblHint.Text = "Shared profile page placeholder for all user roles.";
            // 
            // lblRoleValue
            // 
            lblRoleValue.AutoSize = true;
            lblRoleValue.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoleValue.ForeColor = Color.Black;
            lblRoleValue.Location = new Point(45, 158);
            lblRoleValue.Margin = new Padding(6, 0, 6, 0);
            lblRoleValue.Name = "lblRoleValue";
            lblRoleValue.Size = new Size(282, 41);
            lblRoleValue.TabIndex = 2;
            lblRoleValue.Text = "Student Dashboard";
            // 
            // lblRoleLabel
            // 
            lblRoleLabel.AutoSize = true;
            lblRoleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoleLabel.ForeColor = Color.DimGray;
            lblRoleLabel.Location = new Point(45, 117);
            lblRoleLabel.Margin = new Padding(6, 0, 6, 0);
            lblRoleLabel.Name = "lblRoleLabel";
            lblRoleLabel.Size = new Size(213, 32);
            lblRoleLabel.TabIndex = 1;
            lblRoleLabel.Text = "Current dashboard";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(35, 36);
            lblTitle.Margin = new Padding(6, 0, 6, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(151, 59);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Profile";
            // 
            // ProfileForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1186, 621);
            Controls.Add(panelCard);
            Margin = new Padding(6, 6, 6, 6);
            Name = "ProfileForm";
            Text = "Profile";
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelCard;
        private Button btnSignOut;
        private Label lblHint;
        private Label lblRoleValue;
        private Label lblRoleLabel;
        private Label lblTitle;
    }
}
