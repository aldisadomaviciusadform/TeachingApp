using Dapper;
using Npgsql;
using ShopAPI.Interfaces;
using System.Data;
using System.Data.Common;
using TeachingAPI.Models;
using TeachingAPI.Services;

namespace ShopAPI.Respositories
{
    public class ShopItemRepository : IShopItemRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _iDbConnection;
        private readonly ILogger<ShopItemRepository> _logger;

        public ShopItemRepository(IConfiguration configuration, IDbConnection dbConnection,ILogger<ShopItemRepository> logger )
        {
            _iDbConnection = dbConnection;
            _configuration = configuration;
            _logger = logger;
        }

        public bool AddItem(ShopItem item)
        {
            try
            {
                string sql = $"INSERT INTO _shopitems (id, name, description, price, createddate) VALUES (@Id, @Name, @Description, @Price, @CreatedDate)";

                int result = _iDbConnection.Execute(sql, item);
                return result == 1;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
            
        }

        public bool RemoveItem(int itemId)
        {
            try
            {
                string sql = $"Delete from _shopitems where id = @id";
                var queryArguments = new
                {
                    id = itemId
                };
                int result = _iDbConnection.Execute(sql, queryArguments);
                return result == 1;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public ShopItem GetItem(int itemId)
        {
            try
            {
                var queryArguments = new
                {
                    id = itemId
                };
                return _iDbConnection.Query<ShopItem>("Select * from _shopitems where id = @id", queryArguments).First();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
            
        }

        public List<ShopItem> ShowItems()
        {
            try
            {
                return _iDbConnection.Query<ShopItem>("Select * from _shopitems").ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public bool UpdateItem(ShopItem item)
        {
            try
            {
                string sql = $"UPDATE _shopitems SET name = @Name, description = @Description, price = @Price, createddate = @CreatedDate where id = @id";

                int result = _iDbConnection.Execute(sql, item);
                return result == 1;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
            
        }
    }
}