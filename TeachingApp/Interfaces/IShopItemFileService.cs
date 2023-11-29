using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingApp.Models;

namespace TeachingApp.Interfaces
{
    internal interface IShopItemFileService
    {
        public List<ShopItem> LoadItems(string fileName);

        public void SaveItems(IEnumerable<ShopItem> items, string fileName);
    }
}
