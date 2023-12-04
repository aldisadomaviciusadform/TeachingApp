using ShopAPI.Interfaces;
using TeachingAPI.Interfaces;
using TeachingAPI.Models;

namespace TeachingAPI.Services
{
    internal class ShopItemService : IShopItemService
    {
        private readonly IShopItemRepository _shopItemRepository;

        public ShopItemService(IShopItemRepository shopItemRepository)
        {
            _shopItemRepository = shopItemRepository;
        }

        public bool AddItem(ShopItem item)
        {
            item.CreatedDate = DateTime.Now;
            return _shopItemRepository.AddItem(item);
        }

        public ShopItem GetItem(int itemId)
        {
            return _shopItemRepository.GetItem(itemId);
        }

        public bool RemoveItem(int itemId)
        {
            return _shopItemRepository.RemoveItem(itemId);
        }

        public List<ShopItem> ShowItems()
        {
            return _shopItemRepository.ShowItems();
        }

        public bool UpdateItem(ShopItem item)
        {
            return _shopItemRepository.UpdateItem(item);
        }
    }
}