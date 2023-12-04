using Dapper;
using Npgsql;
using System.Collections.Generic;
using TeachingAPI.Interfaces;
using TeachingAPI.NewFolder;

namespace TeachingAPI.Respositories
{
    public class DarbuotojasRepository : IDarbuotojasRepository
    {
        public IEnumerable<Darbuotojas> GetDarbuotojai()
        {
            using (var connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=Kaunas123;Database=TeachingDB"))
            {
                return connection.Query<Darbuotojas>("Select * from darbuotojas");
                //connection.Query<MyTable>("SELECT * FROM MyTable");

            }
        }

        public int InsertDarbuotojas(string name, string id, string lastName)
        {
            using (var connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=Kaunas123;Database=TeachingDB"))
            {
                string sql = $"INSERT INTO Darbuotojas (asmenskodas, Vardas, Pavarde) VALUES (@id, @name, @lastName)";
                var queryArguments = new
                {
                    name = name,
                    id = id,
                    lastName = lastName
                };

                return connection.Execute(sql, queryArguments);
            }
        }

        public int ModifyDarbuotojas(string name, string id, string lastName)
        {
            using (var connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=Kaunas123;Database=TeachingDB"))
            {
                string sql = $"UPDATE Darbuotojas SET vardas = @name, pavarde = @lastName WHERE asmenskodas = @id";
                var queryArguments = new
                {
                    name = name,
                    id = id,
                    lastName = lastName
                };

                return connection.Execute(sql, queryArguments);
            }
        }
    }
}
