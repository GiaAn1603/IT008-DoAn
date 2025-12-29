using System;
using System.Collections.Generic;
using OHIOCF.DAO;
using OHIOCF.DTO;

namespace OHIOCF.BUS
{
    public class InventoryBUS
    {
        private static InventoryBUS instance;
        public static InventoryBUS Instance => instance ?? (instance = new InventoryBUS());
        private InventoryBUS() { }

        public List<InventoryDTO> GetInventoryStatus() => InventoryDAO.Instance.GetList();

        public bool ImportStock(string ingredientId, double quantity, double? minThreshold = null)
        {
            if (quantity < 0) return false;
            return InventoryDAO.Instance.UpdateStock(ingredientId, quantity, minThreshold);
        }

        public bool DeductStock(string ingredientId, double quantity, double? minThreshold = null)
        {
            if (quantity <= 0) return false;
            return InventoryDAO.Instance.UpdateStock(ingredientId, -quantity, minThreshold);
        }

        public bool InitStock(IngredientDTO ingredient, double quantity, double minThreshold)
        {
            if (string.IsNullOrEmpty(ingredient.Id))
            {
                ingredient.Id = Guid.NewGuid().ToString();
            }

            if (IngredientDAO.Instance.Insert(ingredient))
            {
                InventoryDTO newInv = new InventoryDTO
                {
                    IngredientId = ingredient.Id,
                    StockQuantity = quantity,
                    MinThreshold = minThreshold,
                    LastUpdated = DateTime.Now
                };

                return InventoryDAO.Instance.Insert(newInv);
            }

            return false;
        }
    }
}
