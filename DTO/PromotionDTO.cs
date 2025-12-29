using System;

namespace OHIOCF.DTO
{
    public class PromotionDTO
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public decimal DiscountValue { get; set; }
        public int DiscountType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
