using System.Collections.Generic;
using OHIOCF.DAO;
using OHIOCF.DTO;

namespace OHIOCF.BUS
{
    public class IngredientBUS
    {
        private static IngredientBUS instance;
        public static IngredientBUS Instance => instance ?? (instance = new IngredientBUS());
        private IngredientBUS() { }

        public List<IngredientDTO> GetAll() => IngredientDAO.Instance.GetList();

        public bool AddIngredient(IngredientDTO item)
        {
            if (string.IsNullOrEmpty(item.Name) || string.IsNullOrEmpty(item.Unit)) return false;
            return IngredientDAO.Instance.Insert(item);
        }

        public bool EditIngredient(IngredientDTO item)
        {
            if (string.IsNullOrEmpty(item.Name)) return false;
            return IngredientDAO.Instance.Update(item);
        }

        public bool RemoveIngredient(string id)
        {
            return IngredientDAO.Instance.Delete(id);
        }
    }
}
