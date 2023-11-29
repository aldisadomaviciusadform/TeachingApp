using System.Diagnostics;
using System.Xml;
using System.Xml.Linq;

namespace TeachingApp.Models
{
    internal class ShopItem
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<ItemTag> Tags { get; set; }

        public double Price { get;  set; }

        public ShopItem()
        {
            Name = "";
            Description = "";
            Tags = new List<ItemTag>();
            Price = 0;
        }

        public ShopItem(string name, string description, double price, List<ItemTag> tags)
        {
            Name = name;
            Description = description;
            Tags = tags;
            Price = price;
        }

        public ShopItem(string name, double price)
        {
            Name = name;
            Description = string.Empty;
            Tags = new List<ItemTag>();
            Price = price;
        }

        public void PrintToFile()
        {
            File.AppendAllText("Sarasas.txt", ToString());
        }

        public void PrintToFile(string input )
        {
            File.AppendAllText("Sarasas.txt", ToString());
        }

        public override string ToString()
        {
            string text = "Name: " + Name + ",Description: " + Description + ",Price: " + Price.ToString() + ",Tags: ";
            foreach (ItemTag tag in Tags)
            {
                text += tag.Name + " ";
            }
            return text;
        }

        public void ChangePrice(double newPrice)
        {
            Price = newPrice;
        }

        public List<ItemTag> MatchedTagList(List<ItemTag> tags)
        {
            List<ItemTag> foundTags = new List<ItemTag>();

            foreach (ItemTag tag in tags)
            {
                foreach (ItemTag itemTag in Tags)
                {
                    
                    if (itemTag.Name == tag.Name)
                    {
                        foundTags.Add(tag);
                        break;
                    }
                }
            }
            return foundTags;
        }
    }
}