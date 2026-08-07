namespace LTWIN.Utils
{
    /// <summary>
    /// PHIÊN LÀM VIỆC NGƯỜI DÙNG (USERSESSION.CS)
    /// Lưu trữ thông tin tài khoản đăng nhập hiện tại và phân quyền ứng dụng (Admin / Nhân Viên).
    /// </summary>
    public static class UserSession
    {
        public static int UserId { get; set; }
        public static string Username { get; set; } = string.Empty;
        public static string Role { get; set; } = string.Empty;
        // Thuộc tính Role được dùng để phân quyền chức năng Admin/Nhân viên
    }
}