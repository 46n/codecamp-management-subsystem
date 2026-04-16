namespace APUCC_Project
{
    partial class BaseShellForm : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseShellForm));
            panelMenu = new Panel();
            Profile = new FontAwesome.Sharp.IconButton();
            iconButton3 = new FontAwesome.Sharp.IconButton();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            homebtn = new FontAwesome.Sharp.IconButton();
            panelLogo = new Panel();
            pictureBox1 = new PictureBox();
            iconButton4 = new FontAwesome.Sharp.IconButton();
            iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            panelSidebarContainer = new FlowLayoutPanel();
            MainPanel = new Panel();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelSidebarContainer.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(25, 25, 25);
            panelMenu.Controls.Add(Profile);
            panelMenu.Controls.Add(iconButton3);
            panelMenu.Controls.Add(iconButton2);
            panelMenu.Controls.Add(homebtn);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Location = new Point(14, 12);
            panelMenu.Margin = new Padding(9, 7, 9, 7);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(146, 252);
            panelMenu.TabIndex = 0;
            panelMenu.Paint += panelMenu_Paint;
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
            Profile.IconSize = 30;
            Profile.ImageAlign = ContentAlignment.MiddleLeft;
            Profile.Location = new Point(0, 210);
            Profile.Margin = new Padding(2, 1, 2, 1);
            Profile.Name = "Profile";
            Profile.Padding = new Padding(9, 0, 0, 0);
            Profile.Size = new Size(146, 50);
            Profile.TabIndex = 5;
            Profile.Text = "Profile";
            Profile.TextAlign = ContentAlignment.MiddleLeft;
            Profile.TextImageRelation = TextImageRelation.ImageBeforeText;
            Profile.UseVisualStyleBackColor = true;
            Profile.Click += Profile_Click;
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
            iconButton3.IconSize = 30;
            iconButton3.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton3.Location = new Point(0, 160);
            iconButton3.Margin = new Padding(2, 1, 2, 1);
            iconButton3.Name = "iconButton3";
            iconButton3.Padding = new Padding(9, 0, 0, 0);
            iconButton3.Size = new Size(146, 50);
            iconButton3.TabIndex = 3;
            iconButton3.Text = "Button3";
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
            iconButton2.IconSize = 30;
            iconButton2.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton2.Location = new Point(0, 110);
            iconButton2.Margin = new Padding(2, 1, 2, 1);
            iconButton2.Name = "iconButton2";
            iconButton2.Padding = new Padding(9, 0, 0, 0);
            iconButton2.Size = new Size(146, 50);
            iconButton2.TabIndex = 2;
            iconButton2.Text = "Button2";
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
            homebtn.IconSize = 30;
            homebtn.ImageAlign = ContentAlignment.MiddleLeft;
            homebtn.Location = new Point(0, 60);
            homebtn.Margin = new Padding(2, 1, 2, 1);
            homebtn.Name = "homebtn";
            homebtn.Padding = new Padding(9, 0, 0, 0);
            homebtn.Size = new Size(146, 50);
            homebtn.TabIndex = 1;
            homebtn.Text = "Button1";
            homebtn.TextAlign = ContentAlignment.MiddleLeft;
            homebtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            homebtn.UseVisualStyleBackColor = true;
            homebtn.Click += homebtn_Click;
            // 
            // panelLogo
            // 
            panelLogo.Controls.Add(pictureBox1);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Margin = new Padding(2, 1, 2, 1);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(146, 60);
            panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-7, -6);
            pictureBox1.Margin = new Padding(2, 1, 2, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(145, 94);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // iconButton4
            // 
            iconButton4.Enabled = false;
            iconButton4.Visible = false;
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
            panelSidebarContainer.Controls.Add(panelMenu);
            panelSidebarContainer.Dock = DockStyle.Left;
            panelSidebarContainer.Location = new Point(0, 0);
            panelSidebarContainer.Margin = new Padding(0);
            panelSidebarContainer.Name = "panelSidebarContainer";
            panelSidebarContainer.Padding = new Padding(5);
            panelSidebarContainer.Size = new Size(156, 386);
            panelSidebarContainer.TabIndex = 2;
            // 
            // MainPanel
            // 
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(156, 0);
            MainPanel.Margin = new Padding(2, 1, 2, 1);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(598, 386);
            MainPanel.TabIndex = 3;
            MainPanel.Paint += MainPanel_Paint;
            // 
            // BaseShellForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(754, 386);
            Controls.Add(MainPanel);
            Controls.Add(panelSidebarContainer);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2, 1, 2, 1);
            MaximizeBox = false;
            MaximumSize = new Size(770, 425);
            MinimumSize = new Size(770, 425);
            Name = "BaseShellForm";
            Text = "Form1";
            Load += Form1_Load;
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelSidebarContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        protected Panel panelMenu;
        protected FontAwesome.Sharp.IconButton homebtn;
        protected Panel panelLogo;
        protected FontAwesome.Sharp.IconButton iconButton4;
        protected FontAwesome.Sharp.IconButton iconButton3;
        protected FontAwesome.Sharp.IconButton iconButton2;
        protected PictureBox pictureBox1;
        protected FontAwesome.Sharp.IconMenuItem iconMenuItem1;
        protected FlowLayoutPanel panelSidebarContainer;
        protected FontAwesome.Sharp.IconButton Profile;
        protected Panel MainPanel;
    }
}
