using ShopAPI.Models;

namespace ShopAPI.Interfaces
{
    public interface IWeatherService
    {
        public Task<int> GetWeatherResponseAsync(string city);
    }
}
