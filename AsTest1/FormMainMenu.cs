using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace AsTest1
{
    public partial class Form1 : Form
    {
        //shortcuts
        private readonly Color colorDefault = Color.White;
        private readonly Color colorTeal = ColorTranslator.FromHtml("#669299");
        private readonly Color colorActiveBack = Color.FromArgb(25, 25, 25);
        // highlight bar background


        //Fields
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        private void Form1_Load(object sender, EventArgs e)
        {
            // Attach ripple effect to buttons
            RippleEffect.Attach(homebtn, Color.FromArgb(120, 170, 190));
            RippleEffect.Attach(iconButton2, Color.FromArgb(120, 170, 190));
            RippleEffect.Attach(iconButton3, Color.FromArgb(120, 170, 190));
            RippleEffect.Attach(iconButton4, Color.FromArgb(120, 170, 190));
        }
        //constructors
        public Form1()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 50);
            panelMenu.Controls.Add(leftBorderBtn);
            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            //hover
            SetupHoverEffects(homebtn);
            SetupHoverEffects(iconButton2);
            SetupHoverEffects(iconButton3);
            SetupHoverEffects(iconButton4);
        }
        //Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(37, 36, 81);

        }
        //Methods
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;

                // active button look
                currentBtn.BackColor = colorActiveBack;
                currentBtn.ForeColor = colorTeal;
                currentBtn.IconColor = colorTeal;

                // ⭐ MOVE highlight bar (THIS is what you wanted)
                leftBorderBtn.BackColor = colorTeal;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Height = currentBtn.Height;
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Left border button

                //Current Child Form Icon
                //iconCurrentChildForm.IconChar = currentBtn.IconChar;
                //iconCurrentChildForm.IconColor = color;
            }
        }
        private void SetupHoverEffects(IconButton btn)
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
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.ForeColor = Color.White;
                currentBtn.IconColor = Color.White;
            }
        }

        //Menu Button_Clicks
        private void homebtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            RippleEffect.Attach(homebtn, Color.FromArgb(120, 170, 190));
            RippleEffect.Attach(iconButton2, Color.FromArgb(120, 170, 190));
            RippleEffect.Attach(iconButton3, Color.FromArgb(120, 170, 190));
            RippleEffect.Attach(iconButton4, Color.FromArgb(120, 170, 190));
            RippleEffect.Attach(Profile, Color.FromArgb(120, 170, 190));
            //OpenChildForm(new FormDashboard());
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            //OpenChildForm(new FormOrders());
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            //OpenChildForm(new FormProducts());
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            //OpenChildForm(new FormCustomers());
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Profile_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
        }
    }


}
