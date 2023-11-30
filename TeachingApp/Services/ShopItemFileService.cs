using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TeachingApp.Interfaces;
using TeachingApp.Models;

namespace TeachingApp.Services
{
    internal class ShopItemFileService : IShopItemFileService
    {
        public List<ShopItem> LoadItems(string fileName)
        {
            if (!File.Exists(fileName))
                throw new Exception($"File {fileName} does not exists");

            try
            {

                List<ShopItem> items = new List<ShopItem>();
                var data = File.ReadAllLines(fileName);                
                foreach (string jsonString in data)
                {
                    ShopItem item = JsonSerializer.Deserialize<ShopItem>(jsonString)!;
                    if (item == null)
                        throw new Exception($"Corrupted file");
                    items.Add(item);
                }
                return items;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveItems(IEnumerable<ShopItem> items, string fileName)
        {
            List<string> text = new List<string>();
            foreach (ShopItem item in items)
            {
                string jsonString = JsonSerializer.Serialize<ShopItem>(item);
                text.Add(jsonString);
            }
            File.WriteAllLines(fileName, text);            
        }
    }
}
