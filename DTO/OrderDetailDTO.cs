namespace OHIOCF.DTO
{
    public class OrderDetailDTO
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public string ProductSizeId { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAtTime { get; set; }
        public string Note { get; set; }
    }
}
