using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;
using APUCC_Project.Forms.Common;

namespace APUCC_Project
{
    public partial class BaseShellForm : Form
    {
        protected readonly Color colorDefault = Color.White;
        protected readonly Color colorTeal = ColorTranslator.FromHtml("#669299");
        protected readonly Color colorActiveBack = Color.FromArgb(25, 25, 25);

        protected IconButton? currentBtn;
        protected Panel leftBorderBtn;
        protected Form? currentChildForm;

        protected BaseShellForm()
        {
            InitializeComponent();

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 50);
            panelMenu.Controls.Add(leftBorderBtn);
            leftBorderBtn.Visible = false;

            Text = string.Empty;
            ControlBox = false;
            DoubleBuffered = true;
            MaximizedBounds = Screen.FromHandle(Handle).WorkingArea;

            SetupHoverEffects(homebtn);
            SetupHoverEffects(iconButton2);
            SetupHoverEffects(iconButton3);
            SetupHoverEffects(Profile);

            HideSharedSettingsButton();
            AttachRipples();

            ClientSize = new Size(770, 425);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
        }

        protected virtual void AttachRipples()
        {
            RippleEffect.Attach(homebtn, Color.FromArgb(120, 170, 190));
            RippleEffect.Attach(iconButton2, Color.FromArgb(120, 170, 190));
            RippleEffect.Attach(iconButton3, Color.FromArgb(120, 170, 190));
            RippleEffect.Attach(Profile, Color.FromArgb(120, 170, 190));
        }

        private void HideSharedSettingsButton()
        {
            iconButton4.Visible = false;
            iconButton4.Enabled = false;

            if (panelMenu.Controls.Contains(iconButton4))
            {
                panelMenu.Controls.Remove(iconButton4);
            }
        }

        protected void ActivateButton(object senderBtn)
        {
            if (senderBtn is not IconButton btn) return;

            DisableButton();
            currentBtn = btn;

            btn.BackColor = colorActiveBack;
            btn.ForeColor = colorTeal;
            btn.IconColor = colorTeal;

            leftBorderBtn.BackColor = colorTeal;
            leftBorderBtn.Location = new Point(0, btn.Location.Y);
            leftBorderBtn.Height = btn.Height;
            leftBorderBtn.Visible = true;
            leftBorderBtn.BringToFront();
        }

        protected void DisableButton()
        {
            if (currentBtn == null) return;

            currentBtn.ForeColor = colorDefault;
            currentBtn.IconColor = colorDefault;
            currentBtn.BackColor = Color.Transparent;
        }

        protected void SetupHoverEffects(IconButton btn)
        {
            btn.MouseEnter += (s, e) =>
            {
                if (btn != currentBtn)
                {
                    btn.ForeColor = colorTeal;
                    btn.IconColor = colorTeal;
                }
            };

            btn.MouseLeave += (s, e) =>
            {
                if (btn != currentBtn)
                {
                    btn.ForeColor = colorDefault;
                    btn.IconColor = colorDefault;
                }
            };
        }

        protected virtual void homebtn_Click(object sender, EventArgs e) => ActivateButton(sender);

        protected virtual void iconButton2_Click(object sender, EventArgs e) => ActivateButton(sender);

        protected virtual void iconButton3_Click(object sender, EventArgs e) => ActivateButton(sender);

        protected virtual void iconButton4_Click(object sender, EventArgs e)
        {
        }

        protected void OpenSharedChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;

            MainPanel.Controls.Clear();

            Panel contentPanel = new Panel();
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Padding = new Padding(0, 30, 0, 0);
            contentPanel.BackColor = MainPanel.BackColor;

            childForm.Dock = DockStyle.Fill;

            contentPanel.Controls.Add(childForm);
            MainPanel.Controls.Add(contentPanel);

            childForm.BringToFront();
            childForm.Show();
        }

        protected virtual void Profile_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenSharedChildForm(new ProfileForm(Text, this));
        }

        protected virtual void pictureBox1_Click(object sender, EventArgs e) { }

        protected virtual void Form1_Load(object sender, EventArgs e)
        {
            AttachRipples();
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
