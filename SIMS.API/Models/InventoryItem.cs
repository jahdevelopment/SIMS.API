namespace SIMS.Models
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Reference { get; set; }
        public string Size { get; set; }
        public string Colour { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}

