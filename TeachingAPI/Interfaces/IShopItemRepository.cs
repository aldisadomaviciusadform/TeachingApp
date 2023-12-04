using TeachingAPI.Models;

namespace ShopAPI.Interfaces
{
    public interface IShopItemRepository
    {
        public bool AddItem(ShopItem item);

        public bool RemoveItem(int itemId);

        public ShopItem GetItem(int itemId);

        public List<ShopItem> ShowItems();

        public bool UpdateItem(ShopItem item);
    }
}