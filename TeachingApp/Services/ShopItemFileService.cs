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
        public List<T> LoadItems<T>(string fileName)
        {
            if (!File.Exists(fileName))
                throw new Exception($"File {fileName} does not exists");

            try
            {

                List<T> items = new List<T>();
                var data = File.ReadAllLines(fileName);                
                foreach (string jsonString in data)
                {
                    T item = JsonSerializer.Deserialize<T>(jsonString)!;
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

        public void SaveItems<T>(IEnumerable<T> items, string fileName)
        {
            List<string> text = new List<string>();
            foreach (T item in items)
            {
                string jsonString = JsonSerializer.Serialize<T>(item);
                text.Add(jsonString);
            }
            File.WriteAllLines(fileName, text);            
        }
    }
}
