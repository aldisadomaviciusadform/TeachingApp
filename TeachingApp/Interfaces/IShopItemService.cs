using TeachingApp.Models;

namespace TeachingApp.Interfaces
{
    internal interface IShopItemService
    {
        public void AddItem(string itemName, double price);

        public void RemoveItem(string itemName);

        public ShopItem GetItem(string itemName);

        public void ShowItems();
    }
}
