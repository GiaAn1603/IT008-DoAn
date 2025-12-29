using System;

namespace OHIOCF.DTO
{
    public class InventoryDTO
    {
        public string Id { get; set; }
        public string IngredientId { get; set; }
        public double StockQuantity { get; set; }
        public DateTime LastUpdated { get; set; }
        public double MinThreshold { get; set; }
    }
}
