namespace LTWIN.Forms
{
    partial class FormInvoicePreview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelHeader = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            panelBottom = new System.Windows.Forms.Panel();
            btnClose = new System.Windows.Forms.Button();
            btnSaveFile = new System.Windows.Forms.Button();
            btnPrint = new System.Windows.Forms.Button();
            rtbContent = new System.Windows.Forms.RichTextBox();
            panelHeader.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.FromArgb(47, 53, 66);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(560, 50);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(15, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(193, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📄 XEM TRƯỚC VĂN BẢN";
            // 
            // panelBottom
            // 
            panelBottom.BackColor = System.Drawing.Color.FromArgb(241, 242, 246);
            panelBottom.Controls.Add(btnClose);
            panelBottom.Controls.Add(btnSaveFile);
            panelBottom.Controls.Add(btnPrint);
            panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottom.Location = new System.Drawing.Point(0, 540);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new System.Windows.Forms.Padding(12);
            panelBottom.Size = new System.Drawing.Size(560, 60);
            panelBottom.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.BackColor = System.Drawing.Color.FromArgb(116, 125, 140);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClose.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnClose.ForeColor = System.Drawing.Color.White;
            btnClose.Location = new System.Drawing.Point(445, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(100, 36);
            btnClose.TabIndex = 2;
            btnClose.Text = "❌ Đóng";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnSaveFile
            // 
            btnSaveFile.BackColor = System.Drawing.Color.FromArgb(46, 213, 115);
            btnSaveFile.FlatAppearance.BorderSize = 0;
            btnSaveFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSaveFile.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnSaveFile.ForeColor = System.Drawing.Color.White;
            btnSaveFile.Location = new System.Drawing.Point(235, 12);
            btnSaveFile.Name = "btnSaveFile";
            btnSaveFile.Size = new System.Drawing.Size(200, 36);
            btnSaveFile.TabIndex = 1;
            btnSaveFile.Text = "💾 Lưu File (Save As...)";
            btnSaveFile.UseVisualStyleBackColor = false;
            btnSaveFile.Click += btnSaveFile_Click;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = System.Drawing.Color.FromArgb(30, 144, 255);
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnPrint.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnPrint.ForeColor = System.Drawing.Color.White;
            btnPrint.Location = new System.Drawing.Point(15, 12);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new System.Drawing.Size(210, 36);
            btnPrint.TabIndex = 0;
            btnPrint.Text = "🖨️ In Trực Tiếp / PDF";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // rtbContent
            // 
            rtbContent.BackColor = System.Drawing.Color.White;
            rtbContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            rtbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            rtbContent.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular);
            rtbContent.Location = new System.Drawing.Point(0, 50);
            rtbContent.Name = "rtbContent";
            rtbContent.ReadOnly = true;
            rtbContent.Size = new System.Drawing.Size(560, 490);
            rtbContent.TabIndex = 2;
            rtbContent.Text = "";
            // 
            // FormInvoicePreview
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(560, 600);
            Controls.Add(rtbContent);
            Controls.Add(panelBottom);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormInvoicePreview";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Xem Trước & In Văn Bản";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RichTextBox rtbContent;
    }
}
