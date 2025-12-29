using System;

namespace OHIOCF.DTO
{
    public class OrderDTO
    {
        public string Id { get; set; }
        public string TableId { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string PromotionId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int Status { get; set; }
    }
}
