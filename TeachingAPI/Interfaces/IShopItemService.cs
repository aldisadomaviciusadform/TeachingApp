using TeachingAPI.Models;

namespace TeachingAPI.Interfaces
{
    public interface IShopItemService
    {
        public bool AddItem(ShopItem item);

        public bool RemoveItem(int itemId);

        public ShopItem GetItem(int itemId);

        public List<ShopItem> ShowItems();

        public bool UpdateItem(ShopItem item);
    }
}