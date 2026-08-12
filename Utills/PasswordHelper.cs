using System.Security.Cryptography;
using System.Text;

namespace LTWIN.Utils
{
    /// <summary>
    /// BỘ HỖ TRỢ MÃ HÓA MẬT KHẨU (PASSWORDHELPER.CS)
    /// Sử dụng thuật toán SHA256 mã hóa mật khẩu bảo mật cho tài khoản người dùng.
    /// </summary>
    public static class PasswordHelper
    {
        /// <summary>
        /// Hàm băm mật khẩu thô thành chuỗi SHA256 Hex
        /// </summary>
        public static string HashPassword(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}