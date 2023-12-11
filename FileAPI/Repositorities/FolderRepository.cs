using FileAPI.Interfaces;
using System.Data;
using Dapper;
using FileAPI.Entity;
using FileAPI.Dtos;

namespace FileAPI.Repositorities
{
    public class FolderRepository: IFolderRepository
    {
        private readonly IDbConnection _dbConnection;

        public FolderRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void ClearDB()
        {
            string sql = $"DELETE FROM folders";

            _dbConnection.Execute(sql);
        }

        public Guid WriteFolder(FolderDto folder)
        {
            string sql = $"INSERT INTO folders " +
                    $"(name, \"parentId\") " +
                    $"VALUES (@Name, @ParentId) RETURNING id";

            return _dbConnection.ExecuteScalar<Guid>(sql, folder);
        }
    }
}
