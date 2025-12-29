using OHIOCF.DAO;
using OHIOCF.DTO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace OHIOCF.BUS
{
    public class CategoryBUS
    {
        private static CategoryBUS instance;
        public static CategoryBUS Instance => instance ?? (instance = new CategoryBUS());
        private CategoryBUS() { }

        public List<CategoryDTO> GetAllCategories()
        {
            return CategoryDAO.Instance.GetListCategory();
        }

        public bool AddCategory(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;

            CategoryDTO cat = new CategoryDTO { Name = name };
            return CategoryDAO.Instance.InsertCategory(cat);
        }

        public bool EditCategory(string id, string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;

            CategoryDTO cat = new CategoryDTO { Id = id, Name = name };
            return CategoryDAO.Instance.UpdateCategory(cat);
        }

        public string DeleteCategory(string id)
        {
            var products = ProductDAO.Instance.GetProductsByCategoryId(id);

            if (products.Count > 0)
            {
                return "Không thể xóa: Danh mục này vẫn còn sản phẩm. Vui lòng xóa hết sản phẩm trước!";
            }

            if (CategoryDAO.Instance.DeleteCategory(id))
            {
                return "Xóa danh mục thành công!";
            }

            return "Xóa thất bại (Lỗi hệ thống).";
        }
        public string NormalizeAndGetOrCreate(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName)) return null;

            // Normalize: "trà" → "Trà", "cà phê" → "Cà Phê"
            categoryName = categoryName.Trim();
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            categoryName = textInfo.ToTitleCase(categoryName.ToLower());

            // Tìm category (case-insensitive)
            var categories = GetAllCategories();
            var existing = categories.FirstOrDefault(c =>
                string.Equals(c.Name, categoryName, System.StringComparison.OrdinalIgnoreCase)
            );

            if (existing != null)
                return existing.Id;

            // Tạo mới
            AddCategory(categoryName);

            // Lấy lại ID
            categories = GetAllCategories();
            var newCat = categories.FirstOrDefault(c =>
                string.Equals(c.Name, categoryName, System.StringComparison.OrdinalIgnoreCase)
            );

            return newCat?.Id;
        }
    }
}
