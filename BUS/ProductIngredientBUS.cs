using System.Collections.Generic;
using OHIOCF.DAO;
using OHIOCF.DTO;

namespace OHIOCF.BUS
{
    public class ProductIngredientBUS
    {
        private static ProductIngredientBUS instance;
        public static ProductIngredientBUS Instance => instance ?? (instance = new ProductIngredientBUS());
        private ProductIngredientBUS() { }

        public List<ProductIngredientDTO> GetRecipe(string productSizeId)
        {
            return ProductIngredientDAO.Instance.GetRecipeByProductSize(productSizeId);
        }

        public bool AddIngredientToRecipe(ProductIngredientDTO item)
        {
            if (item.RequiredQuantity <= 0) return false;
            return ProductIngredientDAO.Instance.Insert(item);
        }

        public bool RemoveIngredientFromRecipe(string id)
        {
            return ProductIngredientDAO.Instance.Delete(id);
        }
    }
}
