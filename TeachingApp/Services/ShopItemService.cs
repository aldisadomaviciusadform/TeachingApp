using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingApp.Interfaces;
using TeachingApp.Models;

namespace TeachingApp.Services
{
    /*
    1. "Add <itemname> <price>"
    2. "Remove <Itemname>" (shop items)    
    5. "Buy <itemname>" -> buys an item if the buyer has enough money.
    6. "Display items" -> displays all items that you have bought.
    */
    internal class ShopItemService
    {
        public ShopItem AddItem(string itemName, double price)
        {
            return new ShopItem(itemName,price);
        }

        public int RemoveItem()
        {
            throw new NotImplementedException();
        }
    }
}
