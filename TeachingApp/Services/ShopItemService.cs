using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingApp.Interfaces;
using TeachingApp.Models;

namespace TeachingApp.Services
{
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
