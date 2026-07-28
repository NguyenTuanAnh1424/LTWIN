using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LTWIN.Forms
{
    public partial class FormInvoicePreview : Form
    {
        private string documentTitle;
        private string documentContent;
        private string defaultFileName;

        public FormInvoicePreview(string title, string content, string defaultFileName = "HoaDon.txt")
        {
            InitializeComponent();
            this.documentTitle = title;
            this.documentContent = content;
            this.defaultFileName = defaultFileName;

            lblTitle.Text = "📄 " + title.ToUpper();
            this.Text = title;
            rtbContent.Text = content;
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Chọn nơi lưu tệp " + documentTitle;
                saveFileDialog.FileName = defaultFileName;
                saveFileDialog.Filter = "Tệp Văn Bản Text (*.txt)|*.txt|Trang Web HTML (*.html)|*.html|Tệp CSV (*.csv)|*.csv|Tất cả tệp (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string ext = Path.GetExtension(saveFileDialog.FileName).ToLower();
                        string finalContent = documentContent;

                        if (ext == ".html")
                        {
                            finalContent = ConvertToHtml(documentTitle, documentContent);
                        }
                        else if (ext == ".csv")
                        {
                            finalContent = ConvertToCsv(documentContent);
                        }

                        File.WriteAllText(saveFileDialog.FileName, finalContent, Encoding.UTF8);
                        MessageBox.Show($"✅ Đã lưu tệp thành công tại:\n{saveFileDialog.FileName}", 
                                        "Lưu Tệp Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"⚠️ Không thể lưu tệp: {ex.Message}", "Lỗi Lưu Tệp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.DocumentName = documentTitle;

                int linesPrinted = 0;
                string[] lines = documentContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                printDoc.PrintPage += (s, ev) =>
                {
                    if (ev.Graphics == null) return;

                    Font printFont = new Font("Consolas", 10F, FontStyle.Regular);
                    float fontHeight = printFont.GetHeight(ev.Graphics);
                    float linesPerPage = ev.MarginBounds.Height / fontHeight;
                    float yPos = 0;
                    int count = 0;
                    float leftMargin = ev.MarginBounds.Left;
                    float topMargin = ev.MarginBounds.Top;

                    while (count < linesPerPage && linesPrinted < lines.Length)
                    {
                        string line = lines[linesPrinted];
                        yPos = topMargin + (count * fontHeight);
                        ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                        count++;
                        linesPrinted++;
                    }

                    if (linesPrinted < lines.Length)
                        ev.HasMorePages = true;
                    else
                    {
                        ev.HasMorePages = false;
                        linesPrinted = 0;
                    }
                };

                PrintPreviewDialog previewDialog = new PrintPreviewDialog();
                previewDialog.Document = printDoc;
                previewDialog.Width = 800;
                previewDialog.Height = 600;
                previewDialog.StartPosition = FormStartPosition.CenterScreen;

                previewDialog.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"⚠️ Lỗi khi mở bản in: {ex.Message}", "Lỗi In Ấn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string ConvertToHtml(string title, string content)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html><head><meta charset='UTF-8'><title>" + title + "</title>");
            sb.AppendLine("<style>");
            sb.AppendLine("body { font-family: 'Courier New', monospace; background-color: #f5f5f5; padding: 20px; }");
            sb.AppendLine(".ticket { background: #fff; width: 450px; margin: 0 auto; padding: 20px; border: 1px solid #ccc; box-shadow: 0 0 10px rgba(0,0,0,0.1); }");
            sb.AppendLine("pre { white-space: pre-wrap; font-size: 13px; line-height: 1.4; }");
            sb.AppendLine("</style></head><body>");
            sb.AppendLine("<div class='ticket'><pre>");
            sb.AppendLine(System.Net.WebUtility.HtmlEncode(content));
            sb.AppendLine("</pre></div></body></html>");
            return sb.ToString();
        }

        private string ConvertToCsv(string content)
        {
            StringBuilder sb = new StringBuilder();
            string[] lines = content.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                string cleanLine = line.Replace("\"", "\"\"");
                sb.AppendLine($"\"{cleanLine}\"");
            }
            return sb.ToString();
        }
    }
}
