using Microsoft.EntityFrameworkCore;
using ShopAPI.Data;
using ShopAPI.Interfaces;
using TeachingAPI.Interfaces;
using TeachingAPI.Models;

namespace ShopAPI.Services
{
    public class ShopItemsService: IShopItmesService
    {
        private readonly ShopAPIContext _context;

        public ShopItemsService(ShopAPIContext context)
        {
            _context = context;
        }

        public List<ShopItem> ShowItems()
        {
            return _context.ShopItem.ToList();
        }
    }
}
