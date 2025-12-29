using System.Collections.Generic;
using OHIOCF.DAO;
using OHIOCF.DTO;

namespace OHIOCF.BUS
{
    public class ProductSizeBUS
    {
        private static ProductSizeBUS instance;
        public static ProductSizeBUS Instance => instance ?? (instance = new ProductSizeBUS());
        private ProductSizeBUS() { }

        public List<ProductSizeDTO> GetSizesByProduct(string productId)
        {
            return ProductSizeDAO.Instance.GetListSizeByProductId(productId);
        }

        public bool AddSize(ProductSizeDTO size)
        {
            if (string.IsNullOrEmpty(size.SizeName)) return false;
            if (size.PriceAdjustment < 0) return false;

            return ProductSizeDAO.Instance.InsertProductSize(size);
        }

        public bool EditSize(ProductSizeDTO size)
        {
            if (string.IsNullOrEmpty(size.SizeName)) return false;
            if (size.PriceAdjustment < 0) return false;

            return ProductSizeDAO.Instance.UpdateProductSize(size);
        }

        public bool RemoveSize(string id)
        {
            return ProductSizeDAO.Instance.DeleteProductSize(id);
        }
    }
}
