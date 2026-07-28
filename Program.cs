using System;
using System.Windows.Forms;
using LTWIN.Forms;
using LTWIN.Models;

namespace LTWIN
{
    /// <summary>
    /// ĐIỂM KHỞI CHẠY CHÍNH CỦA ỨNG DỤNG WINDOWS FORMS (PROGRAM.CS)
    /// Hỗ trợ luồng Đăng nhập, Đăng xuất tài khoản liên tục mà không làm crash ứng dụng.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Hàm Main - Vòng lặp quản lý Đăng Nhập & Đăng Xuất (Logout Loop).
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            bool keepRunning = true;
            while (keepRunning)
            {
                using (var loginForm = new LTWIN.Forms.FormLogin())
                {
                    // Mở FormLogin. Nếu đăng nhập thành công thì vào FormMain
                    if (loginForm.ShowDialog() == DialogResult.OK && loginForm.LoggedInUser != null)
                    {
                        using (var mainForm = new LTWIN.Forms.FormMain(loginForm.LoggedInUser))
                        {
                            Application.Run(mainForm);
                            
                            // Nếu người dùng chọn "Đăng Xuất", vòng lặp tiếp tục mở lại FormLogin
                            // Nếu người dùng chọn "Thoát Ứng Dụng", keepRunning = false và đóng chương trình.
                            keepRunning = mainForm.IsLoggingOut;
                        }
                    }
                    else
                    {
                        keepRunning = false;
                    }
                }
            }
        }
    }
}
