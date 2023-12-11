using FileAPI.Dtos;
using FileAPI.Repositorities;

namespace FileAPI.Interfaces
{
    public interface IFileService
    {        

        public FileDto GetFileData(string fileName);

        public int WriteFilesToDB(List<FileDto> files);

        public Guid UploadFile(FileUploadDownloadDto file);

        public FileUploadDownloadDto Download(string filePath);
    }
}
