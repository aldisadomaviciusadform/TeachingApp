using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingApp.Models
{
    internal class ItemTag
    {
        public int ID { get; }
        public string Name { get; }

        public ItemTag(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public bool MatchedTag(ItemBasket allItems)
        {
            bool found = false;
            foreach (ShopItem item in allItems.Items)
            {
                found = false;
                foreach (ItemTag itemTag in item.Tags)
                {
                    if (itemTag.Name == Name)
                    {
                        found = true;
                        break;
                    }
                }
                // did not find in this element
                if (!found)
                    return false;
            }
            return found;
        }
    }
}