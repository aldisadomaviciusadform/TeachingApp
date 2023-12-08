using ShopAPI.Models;

namespace ShopAPI.Interfaces
{
    public interface IWeatherRepository
    {
        public int WriteData(WeatherData weatherData);
    }
}
