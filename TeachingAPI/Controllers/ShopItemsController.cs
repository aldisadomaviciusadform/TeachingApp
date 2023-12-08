using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopAPI.Data;
using ShopAPI.Interfaces;
using ShopAPI.Services;
using TeachingAPI.Models;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopItemsController : ControllerBase
    {
        private readonly ShopAPIContext _context;
        private readonly IShopItmesService _shopItemService;

        public ShopItemsController(ShopAPIContext context, IShopItmesService shopItmesService)
        {
            _context = context;
            _shopItemService = shopItmesService;
        }

        // GET: api/ShopItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopItem>>> GetShopItem()
        {
            return _shopItemService.ShowItems();
        }

        // GET: api/ShopItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShopItem>> GetShopItem(int id)
        {
            var shopItem = await _context.ShopItem.FindAsync(id);

            if (shopItem == null)
            {
                return NotFound();
            }

            return shopItem;
        }

        // PUT: api/ShopItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShopItem(int id, ShopItem shopItem)
        {
            if (id != shopItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(shopItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ShopItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShopItem>> PostShopItem(ShopItem shopItem)
        {
            _context.ShopItem.Add(shopItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShopItem", new { id = shopItem.Id }, shopItem);
        }

        // DELETE: api/ShopItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShopItem(int id)
        {
            var shopItem = await _context.ShopItem.FindAsync(id);
            if (shopItem == null)
            {
                return NotFound();
            }

            _context.ShopItem.Remove(shopItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShopItemExists(int id)
        {
            return _context.ShopItem.Any(e => e.Id == id);
        }
    }
}
