using Dapper;
using FileAPI.Dtos;
using FileAPI.Interfaces;
using System.Data;

namespace FileAPI.Repositorities
{
    public class FileRepository:IFileRepository
    {
        private readonly IDbConnection _dbConnection;

        public FileRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public int WriteFilesToDB(List<FileDto> files)
        {
            string sql = $"INSERT INTO files " +
                    $"(name,size, \"fullPath\") " +
                    $"VALUES (@Name,@Size, @fullPath)";

            var result = _dbConnection.Execute(sql, files);
            return result;
        }

        public Guid WriteFileToDB(FileDto file)
        {
            string sql = $"INSERT INTO files " +
                    $"(name,size, \"fullPath\") " +
                    $"VALUES (@Name,@Size, @fullPath) Returning id";

            var result = _dbConnection.ExecuteScalar<Guid>(sql, file);
            return result;
        }

        public FileDto GetFileData(string fileName)
        {
            var queryArguments = new
            {
                fileName = fileName
            };
            return _dbConnection.Query<FileDto>("Select * from files where name = @fileName", queryArguments).First();

        }

        public void ClearDB()
        {
            string sql = $"DELETE FROM files";

            _dbConnection.Execute(sql);
        }
    }
}
