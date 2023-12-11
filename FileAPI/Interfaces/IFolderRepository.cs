using FileAPI.Dtos;
using FileAPI.Entity;

namespace FileAPI.Interfaces
{
    public interface IFolderRepository
    {
        public Guid WriteFolder(FolderDto folder);

        public void ClearDB();
    }
}
