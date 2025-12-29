using OHIOCF.DAO;
using OHIOCF.DTO;
using System.Collections.Generic;
using System.Linq;

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
        public decimal GetDisplayPrice(string productId)
        {
            var product = ProductDAO.Instance.GetProductById(productId);
            if (product == null) return 0;

            var sizes = ProductSizeBUS.Instance.GetSizesByProduct(productId);
            if (sizes == null || sizes.Count == 0) return product.BasePrice;

            decimal basePrice = product.BasePrice;

            // Ưu tiên M
            var sizeM = sizes.FirstOrDefault(s => s.SizeName == "M");
            if (sizeM != null)
                return basePrice + sizeM.PriceAdjustment;

            // Nếu không có M → S
            var sizeS = sizes.FirstOrDefault(s => s.SizeName == "S");
            if (sizeS != null)
                return basePrice + sizeS.PriceAdjustment;

            // Cuối cùng → L
            var sizeL = sizes.FirstOrDefault(s => s.SizeName == "L");
            if (sizeL != null)
                return basePrice + sizeL.PriceAdjustment;

            return basePrice;
        }

        public bool DeleteProductComplete(string productId)
        {
            // Lấy tất cả ProductSize
            var sizes = ProductSizeBUS.Instance.GetSizesByProduct(productId);

            // Xóa ProductIngredient của từng size
            foreach (var size in sizes)
            {
                var ingredients = ProductIngredientBUS.Instance.GetRecipe(size.Id);
                foreach (var ing in ingredients)
                {
                    ProductIngredientBUS.Instance.RemoveIngredientFromRecipe(ing.Id);
                }
            }

            // Xóa ProductSize
            foreach (var size in sizes)
            {
                ProductSizeBUS.Instance.RemoveSize(size.Id);
            }

            // Xóa Product
            return RemoveProduct(productId);
        }
        public bool ExistsByName(string productName)
        {
            return ProductDAO.Instance.ExistsByName(productName);
        }

    }
}
