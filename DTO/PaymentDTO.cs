using System;

namespace OHIOCF.DTO
{
    public class PaymentDTO
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal AmountPaid { get; set; }
    }
}
