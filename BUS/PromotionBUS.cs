using System;
using System.Collections.Generic;
using OHIOCF.DAO;
using OHIOCF.DTO;

namespace OHIOCF.BUS
{
    public class PromotionBUS
    {
        private static PromotionBUS instance;
        public static PromotionBUS Instance => instance ?? (instance = new PromotionBUS());
        private PromotionBUS() { }

        public List<PromotionDTO> GetAllPromotions() => PromotionDAO.Instance.GetList();

        public PromotionDTO GetPromotionById(string id)
        {
            return PromotionDAO.Instance.GetById(id);
        }

        public PromotionDTO CheckValidCode(string code)
        {
            PromotionDTO promo = PromotionDAO.Instance.GetByCode(code);
            if (promo == null) return null;

            DateTime now = DateTime.Now;
            if (now < promo.StartDate || now > promo.EndDate) return null;

            return promo;
        }

        public bool AddPromotion(PromotionDTO p)
        {
            if (p.EndDate <= p.StartDate) return false;
            return PromotionDAO.Instance.Insert(p);
        }

        public bool RemovePromotion(string id)
        {
            return PromotionDAO.Instance.Delete(id);
        }
    }
}
