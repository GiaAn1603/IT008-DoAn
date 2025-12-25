namespace OHIOCF.DTO
{
    public class ProductDTO
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public string Image { get; set; }
        public bool IsAvailable { get; set; }
    }
}
