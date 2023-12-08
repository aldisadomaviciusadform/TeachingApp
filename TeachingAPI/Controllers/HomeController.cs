using Microsoft.AspNetCore.Mvc;
using ShopAPI.Interfaces;
using ShopAPI.Models;
using TeachingAPI.Interfaces;
using TeachingAPI.Models;

namespace TeachingAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class HomeController : ControllerBase
    {
        private readonly IShopItemService _shopItemService;
        private readonly IWeatherService _weatherService;

        public HomeController(IShopItemService shopItemService, IWeatherService weatherService)
        {
            _shopItemService = shopItemService;
            _weatherService = weatherService;
        }

        /*
Create new API for Shop ITem (Similar to console application)
ShopItem should have Name, Price (use decimal type), CreatedDate (should be populate by default)
 
Create ShopItem table inside new or existing database
 
Please allow the following actions:
Create (HttpPost)
GetAll (HttpGet)
GetById (HttpGet)
Delete (HttpDelete)
Update (HttpPut)
 
The data must be written into database trough repository layer
https://codewithmukesh.com/blog/repository-pattern-in-aspnet-core/
Controller -> Service -> Repository
 
API should include Error Handling
 
Actions should return correct StatusCodes.
https://developer.mozilla.org/en-US/docs/Web/HTTP/Status
 
 
Price should be validated (no less then 0) (using data validations)
https://code-maze.com/aspnetcore-modelstate-validation-web-api/
 
Extra Hard***
Use DBUP to automatically create table
         */

        private IActionResult ExceptionResponceHandlers(Exception exception)
        {
            return BadRequest(exception.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetWeather(string city)
        {
            try
            {
                return Ok(await _weatherService.GetWeatherResponseAsync(city));
            }
            catch (Exception e)
            {
                string message = e.Message;
                return ExceptionResponceHandlers(e);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var items = _shopItemService.ShowItems();
                if (items == null)
                    return NoContent();
                else
                    return Ok(items);
            }
            catch (Exception e)
            {
                string message = e.Message;
                return ExceptionResponceHandlers(e);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                ShopItem item = _shopItemService.GetItem(id);
                if (item == null)
                    return NoContent();
                else
                    return Ok(item);
            }
            catch (Exception e)
            {
                string message = e.Message; 
                return ExceptionResponceHandlers(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ShopItem shopitem)
        {
            try
            {
                bool success = true;//_shopItemService.AddItem(shopitem);
                if (!success)
                    return BadRequest();
                else
                    return Created();
            }
            catch (Exception e)
            {
                string message = e.Message;
                return ExceptionResponceHandlers(e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ShopItem shopitem)
        {
            try
            {
                bool success = _shopItemService.UpdateItem(shopitem);
                if (!success)
                    return BadRequest();
                else
                    return Ok();
            }
            catch (Exception e)
            {
                string message = e.Message;
                return ExceptionResponceHandlers(e);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool success = _shopItemService.RemoveItem(id);
                if (!success)
                    return BadRequest();
                else
                    return Ok();
            }
            catch (Exception e)
            {
                string message = e.Message;
                return ExceptionResponceHandlers(e);
            }
        }
    }
}