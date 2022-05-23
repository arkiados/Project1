using System.ComponentModel.DataAnnotations;

namespace Project1.Models
{
    public class InventoryItem
    {
        [Key]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
