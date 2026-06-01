using System;
using System.Drawing;
using System.Windows.Forms;

namespace APUCC_Project.UI
{
    internal sealed class ActionConfirmationDialog : Form
    {
        private ActionConfirmationDialog(string title, string message, string proceedText, string cancelText)
        {
            Text = title;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            BackColor = ThemePalette.BaseBackground;
            ClientSize = new Size(520, 210);
            Font = ThemeTypography.Body;

            Label titleLabel = new Label
            {
                AutoSize = false,
                Dock = DockStyle.Top,
                Height = 54,
                Text = title,
                Font = ThemeTypography.SectionTitle,
                ForeColor = ThemePalette.PrimaryText,
                Padding = new Padding(18, 14, 18, 0)
            };

            Label messageLabel = new Label
            {
                AutoSize = false,
                Left = 18,
                Top = 64,
                Width = ClientSize.Width - 36,
                Height = 68,
                Text = message,
                Font = ThemeTypography.Body,
                ForeColor = ThemePalette.PrimaryText
            };

            Button cancelButton = new Button
            {
                Text = cancelText,
                DialogResult = DialogResult.Cancel,
                BackColor = Color.White,
                ForeColor = ThemePalette.PrimaryText,
                FlatStyle = FlatStyle.Flat,
                Width = 110,
                Height = 38,
                Left = ClientSize.Width - 246,
                Top = 150
            };
            cancelButton.FlatAppearance.BorderColor = ThemePalette.Border;

            Button proceedButton = new Button
            {
                Text = proceedText,
                DialogResult = DialogResult.OK,
                BackColor = ThemePalette.PrimaryButton,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 110,
                Height = 38,
                Left = ClientSize.Width - 126,
                Top = 150
            };
            proceedButton.FlatAppearance.BorderColor = ThemePalette.PrimaryButton;

            Controls.Add(titleLabel);
            Controls.Add(messageLabel);
            Controls.Add(cancelButton);
            Controls.Add(proceedButton);

            AcceptButton = proceedButton;
            CancelButton = cancelButton;
        }

        public static bool ShowConfirmation(
            IWin32Window owner,
            string title,
            string message,
            string proceedText = "Proceed",
            string cancelText = "Cancel")
        {
            using ActionConfirmationDialog dialog = new ActionConfirmationDialog(title, message, proceedText, cancelText);
            return dialog.ShowDialog(owner) == DialogResult.OK;
        }
    }
}
