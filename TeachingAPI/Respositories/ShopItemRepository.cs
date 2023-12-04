using Dapper;
using Npgsql;
using ShopAPI.Interfaces;
using TeachingAPI.Models;

namespace ShopAPI.Respositories
{
    public class ShopItemRepository : IShopItemRepository
    {
        public bool AddItem(ShopItem item)
        {
            using (var connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=Kaunas123;Database=TeachingDB"))
            {
                string sql = $"INSERT INTO shopitems (id, name, description, price, createddate) VALUES (@Id, @Name, @Description, @Price, @CreatedDate)";

                int result = connection.Execute(sql, item);
                return result == 1;
            }
        }

        public bool RemoveItem(int itemId)
        {
            using (var connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=Kaunas123;Database=TeachingDB"))
            {
                string sql = $"Delete from shopitems where id = @id";
                var queryArguments = new
                {
                    id = itemId
                };
                int result = connection.Execute(sql, queryArguments);
                return result == 1;
            }
        }

        public ShopItem GetItem(int itemId)
        {
            using (var connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=Kaunas123;Database=TeachingDB"))
            {
                var queryArguments = new
                {
                    id = itemId
                };
                return connection.Query<ShopItem>("Select * from shopitems where id = @id", queryArguments).First();
            }
        }

        public List<ShopItem> ShowItems()
        {
            using (var connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=Kaunas123;Database=TeachingDB"))
            {
                return connection.Query<ShopItem>("Select * from shopitems").ToList();
            }
        }

        public bool UpdateItem(ShopItem item)
        {
            using (var connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=Kaunas123;Database=TeachingDB"))
            {
                string sql = $"UPDATE shopitems SET name = @Name, description = @Description, price = @Price, createddate = @CreatedDate where id = @id";

                int result = connection.Execute(sql, item);
                return result == 1;
            }
        }
    }
}