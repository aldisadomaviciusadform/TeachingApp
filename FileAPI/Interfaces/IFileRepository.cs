using System.Data;
using Dapper;
using FileAPI.Dtos;

namespace FileAPI.Interfaces
{
    public interface IFileRepository
    {
        public int WriteFilesToDB(List<FileDto> files);
        public Guid WriteFileToDB(FileDto file);
        public FileDto GetFileData(string fileName);
        public void ClearDB();
    }
}
