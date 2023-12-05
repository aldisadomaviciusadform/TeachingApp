using System.ComponentModel.DataAnnotations;

namespace ShopAPI.Models
{
    public class AddShopItem
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; init; }
        public string Description { get; init; }
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; init; }
    }
}
