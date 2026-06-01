using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;
using APUCC_Project.Forms.Common;
using APUCC_Project.UI;

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
        private bool hasCenteredOnFirstShow;
        protected int CurrentUserId { get; private set; }
        protected string CurrentUserRole { get; private set; } = string.Empty;
        protected virtual int ChildContentTopPadding => 30;
        protected virtual int ChildContentLeftPadding => 0;
        protected virtual int ProfileContentLeftPadding => 30;
        protected virtual void CustomizeChildFormAppearance(Form childForm) { }

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
            MainPanel.BackColor = ThemePalette.BaseBackground;
            ApplyStandardShellWindow();
        }

        protected virtual void AttachRipples()
        {
            RippleEffect.Attach(homebtn, Color.FromArgb(120, 170, 190));
            RippleEffect.Attach(iconButton2, Color.FromArgb(120, 170, 190));
            RippleEffect.Attach(iconButton3, Color.FromArgb(120, 170, 190));
            RippleEffect.Attach(Profile, Color.FromArgb(120, 170, 190));
        }

        protected void InitializeUserContext(int userId, string userRole)
        {
            CurrentUserId = userId;
            CurrentUserRole = userRole;
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

        protected void ApplyStandardShellWindow()
        {
            SuspendLayout();
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = ThemeLayout.StandardClientSize;
            Size fixedWindowSize = Size;

            MinimumSize = fixedWindowSize;
            MaximumSize = fixedWindowSize;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = true;
            StartPosition = FormStartPosition.CenterScreen;
            Font = ThemeTypography.Body;

            homebtn.Font = ThemeTypography.Navigation;
            iconButton2.Font = ThemeTypography.Navigation;
            iconButton3.Font = ThemeTypography.Navigation;
            iconButton4.Font = ThemeTypography.Navigation;
            Profile.Font = ThemeTypography.Navigation;
            ResumeLayout(performLayout: true);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (hasCenteredOnFirstShow)
            {
                return;
            }

            hasCenteredOnFirstShow = true;

            Screen currentScreen = Screen.FromPoint(Cursor.Position);
            Rectangle workingArea = currentScreen.WorkingArea;

            MaximizedBounds = workingArea;
            Location = new Point(
                workingArea.Left + Math.Max(0, (workingArea.Width - Width) / 2),
                workingArea.Top + Math.Max(0, (workingArea.Height - Height) / 2));
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
            childForm.WindowState = FormWindowState.Normal;
            childForm.StartPosition = FormStartPosition.Manual;
            childForm.MaximizeBox = false;
            childForm.MinimizeBox = false;

            MainPanel.Controls.Clear();

            Panel contentPanel = new Panel();
            contentPanel.Dock = DockStyle.Fill;
            int leftPadding = childForm is ProfileForm
                ? ProfileContentLeftPadding
                : ChildContentLeftPadding;
            contentPanel.Padding = new Padding(leftPadding, ChildContentTopPadding, 0, 0);
            contentPanel.BackColor = ThemePalette.BaseBackground;
            contentPanel.AutoScroll = childForm is not ProfileForm;

            childForm.Dock = DockStyle.Fill;

            contentPanel.Controls.Add(childForm);
            MainPanel.Controls.Add(contentPanel);

            FormTheme.ApplyToChildForm(childForm);
            CustomizeChildFormAppearance(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        protected virtual void Profile_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenSharedChildForm(new ProfileForm(CurrentUserId, CurrentUserRole, Text, this));
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
