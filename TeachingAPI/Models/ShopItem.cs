using ShopAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace TeachingAPI.Models
{
    public class ShopItem
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Name { get; init; }
        public string Description { get; init; }
        [Range(0, double.MaxValue)]
        public decimal Price { get; init; }
        public DateTime CreatedDate { get; set; }

        public ShopItem()
        {
            
        }
        public ShopItem(AddShopItem itemAdd)
        {
            Id = itemAdd.Id;
            Name = itemAdd.Name;
            Description = itemAdd.Description;
            Price = itemAdd.Price;
            CreatedDate = DateTime.Now;
        }
    }
}