using System.Drawing;
using System.Windows.Forms;

namespace LTWIN.Utils
{
    public static class ThemeHelper
    {
        public static readonly Color PrimaryDark = Color.FromArgb(30, 34, 45);         // #1E222D
        public static readonly Color PrimaryAccent = Color.FromArgb(79, 70, 229);       // #4F46E5 Indigo
        public static readonly Color SecondaryAccent = Color.FromArgb(59, 130, 246);   // #3B82F6 Blue
        public static readonly Color SuccessGreen = Color.FromArgb(16, 185, 129);       // #10B981 Green
        public static readonly Color DangerRed = Color.FromArgb(239, 68, 68);          // #EF4444 Red
        public static readonly Color BackgroundLight = Color.FromArgb(248, 250, 252);   // #F8FAFC Light Slate
        public static readonly Color TableHeaderBg = Color.FromArgb(30, 41, 59);        // #1E293B Dark Header
        public static readonly Color TableAltRow = Color.FromArgb(248, 250, 252);       // #F8FAFC

        public static void StyleDataGridView(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.EnableHeadersVisualStyles = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(226, 232, 240);

            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = TableHeaderBg;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersHeight = 38;

            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 231, 255);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 41, 59);

            dgv.AlternatingRowsDefaultCellStyle.BackColor = TableAltRow;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 231, 255);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 41, 59);

            dgv.RowTemplate.Height = 36;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public static void StylePrimaryButton(Button btn, Color bg)
        {
            if (btn == null) return;
            btn.BackColor = bg;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btn.UseMnemonic = false;
        }

        public static void AddHoverEffect(Button btn, Color normalBg, Color hoverBg)
        {
            if (btn == null) return;
            btn.MouseEnter += (s, e) => btn.BackColor = hoverBg;
            btn.MouseLeave += (s, e) => btn.BackColor = normalBg;
        }

        public static System.Drawing.Drawing2D.GraphicsPath CreateRoundedRectanglePath(RectangleF rect, float cornerRadius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            float diameter = cornerRadius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
