using TeachingApp.Interfaces;
using TeachingApp.Services;

namespace TeachingApp.Models
{
    internal class ItemBasket: IShopItemService
    {
        private List<ShopItem> _items;
        public IEnumerable<ShopItem> Items { get { return _items; } }

        public IShopItemFileService fileService = new ShopItemFileService();

        string BasketName;

        public ItemBasket(string basketName) 
        {
            _items = new List<ShopItem>();
            BasketName = basketName;
        }

        public void AddItem(string itemName, double price)
        {
            _items.Add(new ShopItem(itemName,price));
        }
        public void RemoveItem(string removeItemName)
        {
            foreach (ShopItem item in _items) 
            {
                if (item.Name == removeItemName)
                {
                    _items.Remove(item);
                    return;
                }
            }
            throw new Exception($"Item {removeItemName} not found");
        }

        public void ShowItems()
        {
            foreach (ShopItem item in _items)
                Console.WriteLine($"{item.Name}: {item.Price}");
        }

        public ShopItem GetItem(string itemName)
        {
            foreach (ShopItem item in _items)
            {
                if (item.Name == itemName)
                    return item;
            }
            throw new Exception($"Item {itemName} not found");
        }

        public void MatchingTags()
        {
            List<ItemTag> matchingList = _items[0].Tags.ToList();

            IEnumerable <ItemTag> ma = matchingList.Where(p => p.ID > 2);

            foreach (ShopItem item in _items)
                matchingList = item.MatchedTagList(matchingList);

            foreach (ItemTag item in matchingList)
                Console.WriteLine(item.Name);

        }

        public void SaveItems()
        {
            fileService.SaveItems<ShopItem>(_items, BasketName+".txt");
        }

        public void LoadItems()
        {
            _items=fileService.LoadItems<ShopItem>(BasketName + ".txt");
        }
    }
}
