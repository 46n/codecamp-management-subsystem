using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace APUCC_Project.UI
{
    internal static class FormTheme
    {
        private static readonly ConditionalWeakTable<Form, object?> ThemedForms = new();

        public static void ApplyToChildForm(Form form)
        {
            if (ThemedForms.TryGetValue(form, out _))
            {
                return;
            }

            form.SuspendLayout();
            form.AutoScaleMode = AutoScaleMode.None;
            form.BackColor = ThemePalette.BaseBackground;
            form.ForeColor = ThemePalette.PrimaryText;
            form.Font = ThemeTypography.Body;
            form.AutoScroll = true;
            StyleControls(form.Controls);
            form.ResumeLayout(true);

            ThemedForms.Add(form, null);
        }

        private static void StyleControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                StyleControl(control);

                if (control.HasChildren)
                {
                    StyleControls(control.Controls);
                }
            }
        }

        private static void StyleControl(Control control)
        {
            switch (control)
            {
                case Panel panel:
                    StylePanel(panel);
                    break;
                case GroupBox groupBox:
                    groupBox.BackColor = ThemePalette.SecondaryBackground;
                    groupBox.ForeColor = ThemePalette.PrimaryText;
                    groupBox.Font = ThemeTypography.SectionTitle;
                    break;
                case Label label:
                    StyleLabel(label);
                    break;
                case Button button:
                    StyleButton(button);
                    break;
                case TextBoxBase textBox:
                    StyleTextBox(textBox);
                    break;
                case ComboBox comboBox:
                    comboBox.BackColor = ThemePalette.BaseBackground;
                    comboBox.ForeColor = ThemePalette.PrimaryText;
                    comboBox.Font = ThemeTypography.Body;
                    break;
                case DateTimePicker dateTimePicker:
                    dateTimePicker.CalendarMonthBackground = ThemePalette.BaseBackground;
                    dateTimePicker.CalendarForeColor = ThemePalette.PrimaryText;
                    dateTimePicker.BackColor = ThemePalette.BaseBackground;
                    dateTimePicker.ForeColor = ThemePalette.PrimaryText;
                    dateTimePicker.Font = ThemeTypography.Body;
                    break;
                case NumericUpDown numericUpDown:
                    numericUpDown.BackColor = ThemePalette.BaseBackground;
                    numericUpDown.ForeColor = ThemePalette.PrimaryText;
                    numericUpDown.Font = ThemeTypography.Body;
                    break;
                case DataGridView dataGridView:
                    StyleDataGridView(dataGridView);
                    break;
            }
        }

        private static void StylePanel(Panel panel)
        {
            panel.BackColor = IsRootContentPanel(panel)
                ? ThemePalette.BaseBackground
                : ThemePalette.SecondaryBackground;
            panel.ForeColor = ThemePalette.PrimaryText;
        }

        private static void StyleLabel(Label label)
        {
            label.BackColor = Color.Transparent;

            if (IsStatusLabel(label.Name))
            {
                label.Font = ThemeTypography.Label;
                return;
            }

            label.ForeColor = ThemePalette.PrimaryText;
            label.Font = IsHeaderLabel(label)
                ? ThemeTypography.Header
                : ThemeTypography.Label;
        }

        private static void StyleButton(Button button)
        {
            bool isDanger = IsDangerAction(button.Name, button.Text);

            button.UseVisualStyleBackColor = false;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = isDanger
                ? ThemePalette.DangerButton
                : ThemePalette.PrimaryButton;
            button.ForeColor = Color.White;
            button.Font = ThemeTypography.Button;
        }

        private static void StyleTextBox(TextBoxBase textBox)
        {
            textBox.BackColor = textBox.ReadOnly
                ? ThemePalette.SecondaryBackground
                : ThemePalette.BaseBackground;
            textBox.ForeColor = ThemePalette.PrimaryText;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Font = ThemeTypography.Body;
        }

        private static void StyleDataGridView(DataGridView grid)
        {
            grid.BackgroundColor = ThemePalette.BaseBackground;
            grid.GridColor = ThemePalette.Border;
            grid.BorderStyle = BorderStyle.None;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.EnableHeadersVisualStyles = false;

            grid.ColumnHeadersDefaultCellStyle.BackColor = ThemePalette.SecondaryBackground;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = ThemePalette.PrimaryText;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = ThemePalette.SecondaryBackground;
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = ThemePalette.PrimaryText;
            grid.ColumnHeadersDefaultCellStyle.Font = ThemeTypography.GridHeader;

            grid.DefaultCellStyle.BackColor = ThemePalette.BaseBackground;
            grid.DefaultCellStyle.ForeColor = ThemePalette.PrimaryText;
            grid.DefaultCellStyle.SelectionBackColor = ThemePalette.SelectionBackground;
            grid.DefaultCellStyle.SelectionForeColor = ThemePalette.PrimaryText;
            grid.DefaultCellStyle.Font = ThemeTypography.GridBody;

            grid.RowsDefaultCellStyle.BackColor = ThemePalette.BaseBackground;
            grid.RowsDefaultCellStyle.ForeColor = ThemePalette.PrimaryText;
            grid.RowsDefaultCellStyle.SelectionBackColor = ThemePalette.SelectionBackground;
            grid.RowsDefaultCellStyle.SelectionForeColor = ThemePalette.PrimaryText;
            grid.RowsDefaultCellStyle.Font = ThemeTypography.GridBody;

            grid.AlternatingRowsDefaultCellStyle.BackColor = ThemePalette.SecondaryBackground;
            grid.AlternatingRowsDefaultCellStyle.ForeColor = ThemePalette.PrimaryText;
            grid.AlternatingRowsDefaultCellStyle.SelectionBackColor = ThemePalette.SelectionBackground;
            grid.AlternatingRowsDefaultCellStyle.SelectionForeColor = ThemePalette.PrimaryText;
            grid.AlternatingRowsDefaultCellStyle.Font = ThemeTypography.GridBody;
            grid.RowTemplate.Height = 28;

            foreach (DataGridViewColumn column in grid.Columns)
            {
                if (column is not DataGridViewButtonColumn buttonColumn)
                {
                    continue;
                }

                bool isDanger = IsDangerAction(buttonColumn.Name, buttonColumn.HeaderText)
                    || IsDangerAction(buttonColumn.Name, buttonColumn.Text);

                buttonColumn.FlatStyle = FlatStyle.Flat;
                buttonColumn.DefaultCellStyle.BackColor = isDanger
                    ? ThemePalette.DangerButton
                    : ThemePalette.PrimaryButton;
                buttonColumn.DefaultCellStyle.ForeColor = Color.White;
                buttonColumn.DefaultCellStyle.SelectionBackColor = buttonColumn.DefaultCellStyle.BackColor;
                buttonColumn.DefaultCellStyle.SelectionForeColor = Color.White;
            }
        }

        private static bool IsRootContentPanel(Control control)
        {
            return control.Parent is Form && control.Dock == DockStyle.Fill;
        }

        private static bool IsDangerAction(string? name, string? text)
        {
            string value = $"{name} {text}".ToLowerInvariant();
            return value.Contains("delete")
                || value.Contains("remove")
                || value.Contains("reject")
                || value.Contains("signout")
                || value.Contains("sign out");
        }

        private static bool IsStatusLabel(string? name)
        {
            string value = name?.ToLowerInvariant() ?? string.Empty;
            return value.Contains("wrong")
                || value.Contains("error")
                || value.Contains("confirm")
                || value.Contains("success");
        }

        private static bool IsHeaderLabel(Label label)
        {
            string value = $"{label.Name} {label.Text}".ToLowerInvariant();

            return label.Font.Size >= 16F
                || value.Contains("title")
                || value.Contains("header")
                || value.Contains("greeting")
                || value.Contains("manage")
                || value.Contains("schedule")
                || value.Contains("feedback")
                || value.Contains("income");
        }
    }
}
