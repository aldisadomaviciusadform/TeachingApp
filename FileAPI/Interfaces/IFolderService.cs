using FileAPI.Dtos;

namespace FileAPI.Interfaces
{
    public interface IFolderService
    {
        public Task<List<FileDto>> WriteFilesInFolder(string folderName);
        public Task<List<FileDto>> WriteAllFilesinSubFolders(string folderName, Guid? parentId); 
    }
}
