namespace APUCC_Project
{
    partial class TrainerShellForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrainerShellForm));
            Profile = new FontAwesome.Sharp.IconButton();
            iconButton4 = new FontAwesome.Sharp.IconButton();
            iconButton3 = new FontAwesome.Sharp.IconButton();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            homebtn = new FontAwesome.Sharp.IconButton();
            panelLogo = new Panel();
            pictureBox1 = new PictureBox();
            iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            panelSidebarContainer = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Profile
            // 
            Profile.Dock = DockStyle.Top;
            Profile.FlatAppearance.BorderSize = 0;
            Profile.FlatStyle = FlatStyle.Flat;
            Profile.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Profile.ForeColor = Color.White;
            Profile.IconChar = FontAwesome.Sharp.IconChar.User;
            Profile.IconColor = Color.White;
            Profile.IconFont = FontAwesome.Sharp.IconFont.Solid;
            Profile.IconSize = 38;
            Profile.ImageAlign = ContentAlignment.MiddleLeft;
            Profile.Location = new Point(0, 429);
            Profile.Name = "Profile";
            Profile.Padding = new Padding(15, 0, 0, 0);
            Profile.Size = new Size(380, 100);
            Profile.TabIndex = 5;
            Profile.Text = "Profile";
            Profile.TextAlign = ContentAlignment.MiddleLeft;
            Profile.TextImageRelation = TextImageRelation.ImageBeforeText;
            Profile.UseVisualStyleBackColor = true;
            Profile.Click += Profile_Click;
            // 
            // iconButton4
            // 
            iconButton4.Dock = DockStyle.Bottom;
            iconButton4.FlatAppearance.BorderSize = 0;
            iconButton4.FlatStyle = FlatStyle.Flat;
            iconButton4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            iconButton4.ForeColor = Color.White;
            iconButton4.IconChar = FontAwesome.Sharp.IconChar.Cog;
            iconButton4.IconColor = Color.White;
            iconButton4.IconFont = FontAwesome.Sharp.IconFont.Solid;
            iconButton4.IconSize = 38;
            iconButton4.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton4.Location = new Point(0, 860);
            iconButton4.Name = "iconButton4";
            iconButton4.Padding = new Padding(15, 0, 0, 0);
            iconButton4.Size = new Size(380, 100);
            iconButton4.TabIndex = 4;
            iconButton4.Text = "Settings";
            iconButton4.TextAlign = ContentAlignment.MiddleLeft;
            iconButton4.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton4.UseVisualStyleBackColor = true;
            iconButton4.Click += iconButton4_Click;
            // 
            // iconButton3
            // 
            iconButton3.Dock = DockStyle.Top;
            iconButton3.FlatAppearance.BorderSize = 0;
            iconButton3.FlatStyle = FlatStyle.Flat;
            iconButton3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            iconButton3.ForeColor = Color.White;
            iconButton3.IconChar = FontAwesome.Sharp.IconChar.Coins;
            iconButton3.IconColor = Color.White;
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Solid;
            iconButton3.IconSize = 38;
            iconButton3.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton3.Location = new Point(0, 329);
            iconButton3.Name = "iconButton3";
            iconButton3.Padding = new Padding(15, 0, 0, 0);
            iconButton3.Size = new Size(380, 100);
            iconButton3.TabIndex = 3;
            iconButton3.Text = "Fees";
            iconButton3.TextAlign = ContentAlignment.MiddleLeft;
            iconButton3.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton3.UseVisualStyleBackColor = true;
            iconButton3.Click += iconButton3_Click;
            // 
            // iconButton2
            // 
            iconButton2.Dock = DockStyle.Top;
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.FlatStyle = FlatStyle.Flat;
            iconButton2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            iconButton2.ForeColor = Color.White;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.Book;
            iconButton2.IconColor = Color.White;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.IconSize = 38;
            iconButton2.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton2.Location = new Point(0, 229);
            iconButton2.Name = "iconButton2";
            iconButton2.Padding = new Padding(15, 0, 0, 0);
            iconButton2.Size = new Size(380, 100);
            iconButton2.TabIndex = 2;
            iconButton2.Text = "My courses";
            iconButton2.TextAlign = ContentAlignment.MiddleLeft;
            iconButton2.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton2.UseVisualStyleBackColor = true;
            iconButton2.Click += iconButton2_Click;
            // 
            // homebtn
            // 
            homebtn.Dock = DockStyle.Top;
            homebtn.FlatAppearance.BorderSize = 0;
            homebtn.FlatStyle = FlatStyle.Flat;
            homebtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            homebtn.ForeColor = Color.White;
            homebtn.IconChar = FontAwesome.Sharp.IconChar.House;
            homebtn.IconColor = Color.White;
            homebtn.IconFont = FontAwesome.Sharp.IconFont.Solid;
            homebtn.IconSize = 38;
            homebtn.ImageAlign = ContentAlignment.MiddleLeft;
            homebtn.Location = new Point(0, 129);
            homebtn.Name = "homebtn";
            homebtn.Padding = new Padding(15, 0, 0, 0);
            homebtn.Size = new Size(380, 100);
            homebtn.TabIndex = 1;
            homebtn.Text = "Home";
            homebtn.TextAlign = ContentAlignment.MiddleLeft;
            homebtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            homebtn.UseVisualStyleBackColor = true;
            homebtn.Click += homebtn_Click;
            // 
            // panelLogo
            // 
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(380, 129);
            panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-25, -40);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(379, 269);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // iconMenuItem1
            // 
            iconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconMenuItem1.IconColor = Color.Black;
            iconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem1.Name = "iconMenuItem1";
            iconMenuItem1.Size = new Size(32, 19);
            iconMenuItem1.Text = "iconMenuItem1";
            // 
            // panelSidebarContainer
            // 
            panelSidebarContainer.BackColor = Color.FromArgb(25, 25, 25);
            panelSidebarContainer.Dock = DockStyle.Left;
            panelSidebarContainer.Location = new Point(379, 0);
            panelSidebarContainer.Margin = new Padding(0);
            panelSidebarContainer.Name = "panelSidebarContainer";
            panelSidebarContainer.Padding = new Padding(10);
            panelSidebarContainer.Size = new Size(10, 1009);
            panelSidebarContainer.TabIndex = 2;
            // 
            // TrainerShellForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1894, 1009);
            Controls.Add(panelSidebarContainer);
            Location = new Point(0, 0);
            Name = "TrainerShellForm";
            Text = "Form1";
            Load += Form1_Load;
            Controls.SetChildIndex(panelSidebarContainer, 0);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

    }
}
