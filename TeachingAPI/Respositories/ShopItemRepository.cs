using Dapper;
using Npgsql;
using ShopAPI.Interfaces;
using System.Data;
using System.Data.Common;
using TeachingAPI.Models;

namespace ShopAPI.Respositories
{
    public class ShopItemRepository : IShopItemRepository
    {
        private readonly IConfiguration _configuration;

        private readonly IDbConnection _iDbConnection;

        public ShopItemRepository(IConfiguration configuration, IDbConnection dbConnection )
        {
            _iDbConnection = dbConnection;
            _configuration = configuration;
        }

        public bool AddItem(ShopItem item)
        {
            string sql = $"INSERT INTO shopitems (id, name, description, price, createddate) VALUES (@Id, @Name, @Description, @Price, @CreatedDate)";

            int result = _iDbConnection.Execute(sql, item);
            return result == 1;
        }

        public bool RemoveItem(int itemId)
        {
            string sql = $"Delete from shopitems where id = @id";
            var queryArguments = new
            {
                id = itemId
            };
            int result = _iDbConnection.Execute(sql, queryArguments);
            return result == 1;

        }

        public ShopItem GetItem(int itemId)
        {
            var queryArguments = new
            {
                id = itemId
            };
            return _iDbConnection.Query<ShopItem>("Select * from shopitems where id = @id", queryArguments).First();
        }

        public List<ShopItem> ShowItems()
        {
            return _iDbConnection.Query<ShopItem>("Select * from shopitems").ToList();
        }

        public bool UpdateItem(ShopItem item)
        {
            string sql = $"UPDATE shopitems SET name = @Name, description = @Description, price = @Price, createddate = @CreatedDate where id = @id";

            int result = _iDbConnection.Execute(sql, item);
            return result == 1;
        }
    }
}