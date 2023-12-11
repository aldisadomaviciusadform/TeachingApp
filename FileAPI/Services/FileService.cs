using FileAPI.Dtos;
using FileAPI.Interfaces;
using FileAPI.Repositorities;
using Microsoft.OpenApi.Extensions;
using System.Data;
using System.IO;

namespace FileAPI.Services
{
    public class FileService: IFileService
    {
        private readonly IFileRepository _fileRepository;
        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public FileDto GetFileData(string fileName)
        {
            FileDto file = new FileDto();
            FileInfo fileInfo = new FileInfo(fileName);
            file.Size = fileInfo.Length;
            file.FullPath = fileName;
            file.Name = fileInfo.Name;
            return file;
        }

        public int WriteFilesToDB(List<FileDto> files)
        {
            return _fileRepository.WriteFilesToDB(files);
        }

        public Guid UploadFile(FileUploadDownloadDto file)
        {
            string path = Directory.GetCurrentDirectory() + "\\" + file.FileName;
            File.WriteAllText(path, file.Content);

            FileDto fileDto = GetFileData(path);
            return _fileRepository.WriteFileToDB(fileDto);
        }

        public FileUploadDownloadDto Download(string filePath)
        {
            FileUploadDownloadDto fileData = new FileUploadDownloadDto();
            FileDto fileDto = _fileRepository.GetFileData(filePath);

            fileData.Content =  File.ReadAllText(fileDto.FullPath);
            fileData.FileName = fileDto.Name;
            return fileData;
        }
    }
}
