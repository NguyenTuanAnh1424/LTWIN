# 👟 LTWIN - PHẦN MỀM QUẢN LÝ CỬA HÀNG BÁN GIÀY (SNEAKER STORE MANAGEMENT SYSTEM)

Dự án Đồ Án Lập Trình Windows (WinForms .NET 8.0 / C#) hỗ trợ quản lý toàn diện cửa hàng bán giày chuyên nghiệp.

---

## 🌟 TÍNH NĂNG NỔI BẬT

### 1. 🖥️ Giao Diện Chính (FormMain - Shell Navigation)
- Thanh menu Sidebar chuẩn thương mại với gam màu sẫm sành điệu (`#1E222D`) & hiệu ứng active Indigo (`#4F46E5`).
- Tích hợp khung nhúng Form con (`Child Form`) mượt mà không bị giật lag.

### 2. 👟 Quản Lý Sản Phẩm Giày & Danh Mục (FormProduct & FormCategory)
- Quản lý thông tin chi tiết: Tên giày, loại giày, giá bán, số lượng tồn kho, mô tả sản phẩm.
- Tích hợp **Chọn & Hiển Thị Ảnh Sản Phẩm (`PictureBox` + `OpenFileDialog`)**.
- Tìm kiếm & Lọc nhanh theo Loại Giày.

### 3. 👥 Quản Lý Khách Hàng & Tích Điểm Thưởng (FormCustomer)
- CRUD thông tin khách hàng (Họ tên, SĐT, Email, Địa chỉ).
- **Tích điểm thưởng tự động**: Mỗi 100.000 VNĐ mua lẻ tại quầy = +1 Điểm thưởng.
- **Phân hạng tự động**: 🥉 Đồng (<100Đ) | 🥈 Bạc (100-299Đ) | 🥇 Vàng (300-499Đ) | 💎 Kim Cương (≥500Đ).

### 4. 🛒 Quầy Bán Hàng Bán Lẻ POS (FormPOS)
- Màn hình chọn nhanh danh mục giày & đưa vào giỏ hàng.
- Tính tổng tiền, chiết khấu giảm giá, tiền khách đưa & tiền thừa trả lại.
- **Tự động trừ số lượng tồn kho (`StockQuantity`) ngay khi thanh toán thành công**.

### 5. 🖨️ In Hóa Đơn & Xuất File PDF / Văn Bản (FormInvoicePreview)
- Tích hợp trình xem trước hóa đơn (`PrintPreviewDialog`) & in ấn trực tiếp (`PrintDocument`).
- **Hỗ trợ in / xuất hóa đơn thành tệp PDF** (qua `Microsoft Print to PDF`).
- Hỗ trợ lưu trữ hóa đơn dạng `.txt`, `.html` (trang web đẹp mắt) và `.csv`.

### 6. 📜 Lịch Sử Hóa Đơn & 📦 Quản Lý Nhập Kho (FormOrderHistory & FormStockImport)
- Theo dõi lịch sử bán hàng, tìm kiếm đơn, hủy đơn (hoàn tồn kho) và in lại hóa đơn.
- Quản lý phiếu nhập kho từ Nhà cung cấp, **tự động cộng dồn số lượng tồn kho sản phẩm**.

### 7. 📊 Thống Kê & Biểu Đồ Tăng Trưởng Doanh Thu (FormReport)
- **Biểu Đồ Doanh Thu GDI+**: Vẽ đồ họa cột trực quan sắc nét với dải màu Gradient Indigo.
- Lọc số liệu linh hoạt (*Hôm nay, 7 ngày qua, Tháng này, Tất cả thời gian*).
- 4 Thẻ KPI tổng quan: Doanh thu, Số đơn bán, Số đôi đã bán, Giá trị trung bình/đơn.

---

## 🛠️ CÔNG NGHỆ SỬ DỤNG
- **Ngôn ngữ**: C# (.NET 8.0 Windows Forms)
- **Kiến trúc**: Layered Architecture (Forms, Models, Services, Utils)
- **CSDL**: SQL Server / Entity Framework Core (EF Core) + In-Memory Fallback
- **Đồ họa & Theme**: GDI+ Drawing, Custom Color Tokens, WinForms Flat Design

---

## 🚀 HƯỚNG DẪN CHẠY ỨNG DỤNG
1. Clone repository:
   ```bash
   git clone https://github.com/NguyenTuanAnh1424/LTWIN.git
   ```
2. Mở file giải pháp `LTWIN.sln` bằng Visual Studio 2022.
3. Bấm **F5** hoặc **Start** để biên dịch & khởi chạy.
4. Tài khoản dùng thử:
   - **Admin**: `admin` / `admin123`
   - **Nhân viên**: `nhanvien` / `123456`
