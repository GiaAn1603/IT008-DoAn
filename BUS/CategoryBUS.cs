using System.Collections.Generic;
using OHIOCF.DAO;
using OHIOCF.DTO;

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

        public bool RemoveCategory(string id)
        {
            return CategoryDAO.Instance.DeleteCategory(id);
        }
    }
}
