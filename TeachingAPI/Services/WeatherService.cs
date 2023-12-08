using Microsoft.DotNet.MSIdentity.Shared;
using Newtonsoft.Json;
using ShopAPI.Interfaces;
using ShopAPI.Models;
using ShopAPI.Respositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ShopAPI.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IWeatherRepository _weatherRepository;

        public WeatherService(IHttpClientFactory httpClientFactory, IWeatherRepository weatherRepository, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _weatherRepository = weatherRepository;
        }

        public async Task<int> GetWeatherResponseAsync(string city)
        {
            // Create a named client or use the default client
            HttpClient client = _httpClientFactory.CreateClient();

            string weatherAPIKey = _configuration.GetValue<string>("WeatherAPIKey");


            var request = new HttpRequestMessage(HttpMethod.Get, new Uri("http://api.weatherstack.com/current?access_key=" + weatherAPIKey + "&query=" + city));
            var response = client.Send(request);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(responseBody);
                return _weatherRepository.WriteData(weatherData);
            }
            else
            {
                // Handle error
                return -1;
            }
        }
    }
}
