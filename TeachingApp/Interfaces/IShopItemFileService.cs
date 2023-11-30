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
        public List<T> LoadItems<T>(string fileName);

        public void SaveItems<T>(IEnumerable<T> items, string fileName);
    }
}
