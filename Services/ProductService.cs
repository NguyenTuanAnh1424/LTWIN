using LTWIN.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LTWIN.Services
{
    public class ProductService
    {
        // 1. Lấy danh sách toàn bộ sản phẩm
        public List<Product> GetAllProducts()
        {
            using (var db = new QlyBanGiayContext())
            {
                // Nếu muốn hiển thị tên loại giày, dùng thêm .Include(p => p.Category) nếu có thiết lập quan hệ
                return db.Products.ToList();
            }
        }

        // 2. Thêm sản phẩm mới
        public void AddProduct(Product product)
        {
            using (var db = new QlyBanGiayContext())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
        }

        // 3. Sửa sản phẩm
        public void UpdateProduct(Product product)
        {
            using (var db = new QlyBanGiayContext())
            {
                db.Products.Update(product);
                db.SaveChanges();
            }
        }

        // 4. Xóa sản phẩm theo ID
        public void DeleteProduct(int productId)
        {
            using (var db = new QlyBanGiayContext())
            {
                var product = db.Products.Find(productId);
                if (product != null)
                {
                    db.Products.Remove(product);
                    db.SaveChanges();
                }
            }
        }

        // 5. Tìm kiếm sản phẩm theo tên
        public List<Product> SearchAndFilter(string keyword)
        {
            using (var db = new QlyBanGiayContext())
            {
                var query = db.Products.AsQueryable();

                // Lọc theo từ khóa tên sản phẩm (nếu có nhập)
                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(p => p.Name.Contains(keyword));
                }

                return query.ToList();
            }
        }
    }
}