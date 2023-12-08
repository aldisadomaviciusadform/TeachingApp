using ShopAPI.Interfaces;
using ShopAPI.Models;
using System.Data;
using Dapper;
using System.Xml.Linq;

namespace ShopAPI.Respositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly IDbConnection _dbConnection;

        public WeatherRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public int WriteData(WeatherData weatherData)
        {
            var queryArguments = new
            {
                city = weatherData.location.name,
                temperature = weatherData.current.temperature,
            };
            string sql = $"INSERT INTO \"weatherData\" " +
                $"(city, temperature) " +
                $"VALUES (@city, @temperature) RETURNING id";
            int result = _dbConnection.ExecuteScalar<int>(sql, queryArguments);
            return result;
        }
    }
}
