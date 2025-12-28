using System.Collections.Generic;
using OHIOCF.DAO;
using OHIOCF.DTO;

namespace OHIOCF.BUS
{
    public class ProductBUS
    {
        private static ProductBUS instance;
        public static ProductBUS Instance => instance ?? (instance = new ProductBUS());
        private ProductBUS() { }

        public ProductDTO GetProductById(string id)
        {
            return ProductDAO.Instance.GetProductById(id);
        }

        public List<ProductDTO> GetProductsByCategory(string categoryId)
        {
            return ProductDAO.Instance.GetProductsByCategoryId(categoryId);
        }

        public List<ProductDTO> SearchProduct(string name)
        {
            return ProductDAO.Instance.SearchProductByName(name);
        }

        public bool AddProduct(ProductDTO p)
        {
            if (string.IsNullOrWhiteSpace(p.Name)) return false;
            if (p.BasePrice < 0) return false;
            if (string.IsNullOrEmpty(p.CategoryId)) return false;

            return ProductDAO.Instance.InsertProduct(p);
        }

        public bool EditProduct(ProductDTO p)
        {
            if (string.IsNullOrWhiteSpace(p.Name)) return false;
            if (p.BasePrice < 0) return false;

            return ProductDAO.Instance.UpdateProduct(p);
        }

        public bool RemoveProduct(string id)
        {
            return ProductDAO.Instance.DeleteProduct(id);
        }
    }
}
