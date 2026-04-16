using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace APUCC_Project
{
    public partial class BaseShellForm : Form
    {
        // 🎨 Shared colors (children can access)
        protected readonly Color colorDefault = Color.White;
        protected readonly Color colorTeal = ColorTranslator.FromHtml("#669299");
        protected readonly Color colorActiveBack = Color.FromArgb(25, 25, 25);

        // ✅ shared fields
        protected IconButton? currentBtn;
        protected Panel leftBorderBtn;
        protected Form? currentChildForm;

        protected BaseShellForm()
        {
            InitializeComponent();

            // highlight bar
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 50);
            panelMenu.Controls.Add(leftBorderBtn);
            leftBorderBtn.Visible = false;

            // form settings
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            // hover + ripple once
            SetupHoverEffects(homebtn);
            SetupHoverEffects(iconButton2);
            SetupHoverEffects(iconButton3);
            SetupHoverEffects(iconButton4);
            SetupHoverEffects(Profile);

            AttachRipples();

            this.ClientSize = new Size(1000, 700);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        // ✅ Ripple once (virtual so child can override if needed)
        protected virtual void AttachRipples()
        {
            RippleEffect.Attach(homebtn, Color.FromArgb(120, 170, 190));
            RippleEffect.Attach(iconButton2, Color.FromArgb(120, 170, 190));
            RippleEffect.Attach(iconButton3, Color.FromArgb(120, 170, 190));
            RippleEffect.Attach(iconButton4, Color.FromArgb(120, 170, 190));
            RippleEffect.Attach(Profile, Color.FromArgb(120, 170, 190));
        }

        // ✅ children can call this
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

        // ✅ Base can handle shared button clicks too (optional)
        protected virtual void homebtn_Click(object sender, EventArgs e) => ActivateButton(sender);

        protected virtual void iconButton2_Click(object sender, EventArgs e) => ActivateButton(sender);

        protected virtual void iconButton3_Click(object sender, EventArgs e) => ActivateButton(sender);

        protected virtual void iconButton4_Click(object sender, EventArgs e) => ActivateButton(sender);

        protected virtual void Profile_Click(object sender, EventArgs e) => ActivateButton(sender);

        protected virtual void pictureBox1_Click(object sender, EventArgs e) { }

        protected virtual void Form1_Load(object sender, EventArgs e)
        {
            AttachRipples(); // or leave empty if you don't use it
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}