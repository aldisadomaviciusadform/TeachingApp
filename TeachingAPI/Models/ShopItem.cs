using System.ComponentModel.DataAnnotations;

namespace TeachingAPI.Models
{
    public class ShopItem
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; init; }
        public string Description { get; init; }
        [Range(0, double.MaxValue)]
        public decimal Price { get; init; }
        public DateTime CreatedDate { get; set; }

        public ShopItem()
        {
            Id = 0;
            Name = "";
            Description = "";
            Price = 0;
            CreatedDate = DateTime.Now;
        }

        public ShopItem(int id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CreatedDate = DateTime.Now;
        }

        public override string ToString()
        {
            string text = "Name: " + Name + ",Description: " + Description + ",Price: " + Price.ToString() + ",Tags: ";

            return text;
        }
    }
}