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

        public bool ImportStock(string ingredientId, double quantity)
        {
            if (quantity <= 0) return false;
            return InventoryDAO.Instance.UpdateStock(ingredientId, quantity);
        }

        public bool DeductStock(string ingredientId, double quantity)
        {
            if (quantity <= 0) return false;
            return InventoryDAO.Instance.UpdateStock(ingredientId, -quantity);
        }
    }
}
