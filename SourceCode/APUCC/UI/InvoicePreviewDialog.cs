using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace APUCC_Project.UI
{
    internal sealed class InvoicePrintData
    {
        public string InvoiceNo { get; init; } = string.Empty;
        public string Module { get; init; } = string.Empty;
        public string Level { get; init; } = string.Empty;
        public string Trainer { get; init; } = string.Empty;
        public decimal InvoiceAmount { get; init; }
        public decimal AmountPaid { get; init; }
        public string PaymentMethod { get; init; } = string.Empty;
        public string PaidDate { get; init; } = string.Empty;
        public string ReceiptNo { get; init; } = string.Empty;
        public string InvoiceStatus { get; init; } = string.Empty;
        public string PaymentStatus { get; init; } = string.Empty;
        public string DueDate { get; init; } = string.Empty;
    }

    internal static class InvoicePreviewDialog
    {
        public static void ShowInvoice(IWin32Window owner, InvoicePrintData invoice)
        {
            using PrintDocument document = new PrintDocument();
            document.DocumentName = $"Invoice {invoice.InvoiceNo}";
            document.PrintPage += (_, e) => DrawInvoicePage(e, invoice);

            using PrintPreviewDialog preview = new PrintPreviewDialog
            {
                Document = document,
                Width = 1000,
                Height = 700
            };

            preview.ShowDialog(owner);
        }

        private static void DrawInvoicePage(PrintPageEventArgs e, InvoicePrintData invoice)
        {
            Graphics g = e.Graphics;
            Rectangle margin = e.MarginBounds;
            int left = margin.Left;
            int top = margin.Top;
            int right = margin.Right;
            int y = top;

            using Font titleFont = new Font("Arial", 18, FontStyle.Bold);
            using Font headingFont = new Font("Arial", 11, FontStyle.Bold);
            using Font bodyFont = new Font("Arial", 10, FontStyle.Regular);
            using Pen borderPen = new Pen(Color.Black, 1.2f);

            g.DrawString("APU CodeCamp Student Invoice", titleFont, Brushes.Black, left, y);
            y += 42;

            g.DrawString($"Invoice No: {invoice.InvoiceNo}", headingFont, Brushes.Black, left, y);
            y += 24;
            g.DrawString($"Paid Date: {invoice.PaidDate}", bodyFont, Brushes.Black, left, y);
            y += 18;
            g.DrawString($"Receipt No: {invoice.ReceiptNo}", bodyFont, Brushes.Black, left, y);
            y += 26;

            Rectangle detailBox = new Rectangle(left, y, margin.Width, 188);
            g.DrawRectangle(borderPen, detailBox);

            int labelX = left + 16;
            int valueX = left + 175;
            int lineY = y + 16;
            int lineGap = 24;

            DrawLine(g, bodyFont, labelX, valueX, lineY, "Module", invoice.Module);
            lineY += lineGap;
            DrawLine(g, bodyFont, labelX, valueX, lineY, "Level", invoice.Level);
            lineY += lineGap;
            DrawLine(g, bodyFont, labelX, valueX, lineY, "Trainer", invoice.Trainer);
            lineY += lineGap;
            DrawLine(g, bodyFont, labelX, valueX, lineY, "Payment Method", invoice.PaymentMethod);
            lineY += lineGap;
            DrawLine(g, bodyFont, labelX, valueX, lineY, "Due Date", invoice.DueDate);
            lineY += lineGap;
            DrawLine(g, bodyFont, labelX, valueX, lineY, "Invoice Status", invoice.InvoiceStatus);
            lineY += lineGap;
            DrawLine(g, bodyFont, labelX, valueX, lineY, "Payment Status", invoice.PaymentStatus);

            y = detailBox.Bottom + 24;

            string[] headers = { "Description", "Amount" };
            int[] widths = { (int)(margin.Width * 0.72), margin.Width - (int)(margin.Width * 0.72) };
            int rowHeight = 30;
            int x = left;

            for (int i = 0; i < headers.Length; i++)
            {
                Rectangle headerCell = new Rectangle(x, y, widths[i], rowHeight);
                g.FillRectangle(Brushes.WhiteSmoke, headerCell);
                g.DrawRectangle(borderPen, headerCell);
                DrawCellText(g, headers[i], headingFont, Rectangle.Inflate(headerCell, -6, -5), StringAlignment.Near);
                x += widths[i];
            }

            y += rowHeight;
            DrawAmountRow(g, bodyFont, borderPen, left, y, widths, "Course Fee", invoice.InvoiceAmount.ToString("RM 0.00"));
            y += rowHeight;
            DrawAmountRow(g, bodyFont, borderPen, left, y, widths, "Amount Paid", invoice.AmountPaid.ToString("RM 0.00"));
            y += rowHeight + 18;

            g.DrawString("This invoice confirms that payment has been received for the course listed above.", bodyFont, Brushes.Black, left, y);
            y += 40;
            g.DrawString("Thank you.", headingFont, Brushes.Black, left, y);

            e.HasMorePages = false;
        }

        private static void DrawLine(Graphics g, Font font, int labelX, int valueX, int y, string label, string value)
        {
            g.DrawString($"{label}:", font, Brushes.Black, labelX, y);
            g.DrawString(value, font, Brushes.Black, valueX, y);
        }

        private static void DrawAmountRow(Graphics g, Font font, Pen pen, int left, int top, int[] widths, string description, string amount)
        {
            Rectangle leftCell = new Rectangle(left, top, widths[0], 30);
            Rectangle rightCell = new Rectangle(left + widths[0], top, widths[1], 30);

            g.DrawRectangle(pen, leftCell);
            g.DrawRectangle(pen, rightCell);

            DrawCellText(g, description, font, Rectangle.Inflate(leftCell, -6, -5), StringAlignment.Near);
            DrawCellText(g, amount, font, Rectangle.Inflate(rightCell, -6, -5), StringAlignment.Far);
        }

        private static void DrawCellText(Graphics graphics, string text, Font font, Rectangle bounds, StringAlignment alignment)
        {
            using StringFormat format = new StringFormat
            {
                Alignment = alignment,
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.EllipsisCharacter,
                FormatFlags = StringFormatFlags.NoWrap
            };

            graphics.DrawString(text, font, Brushes.Black, bounds, format);
        }
    }
}
