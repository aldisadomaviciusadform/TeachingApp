using FileAPI.Dtos;
using FileAPI.Interfaces;

namespace FileAPI.Services
{
    public class FolderService: IFolderService
    {
        private readonly IFileService _fileService;
        private readonly IFileRepository _fileRepository;
        private readonly IFolderRepository _folderRepository;
        public FolderService(IFileService fileService, IFolderRepository folderRepository, IFileRepository fileRepository)
        {
            _fileService = fileService;
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;
        }

        public async Task<List<FileDto>> WriteFilesInFolder(string folderName)
        {
            string[] files = Directory.GetFiles(folderName);
            List<FileDto> filesList = new List<FileDto>();

            foreach (string file in files)
                filesList.Add(_fileService.GetFileData(file));

            _fileService.WriteFilesToDB(filesList);

            return filesList;
        }

        public async Task<List<FileDto>> WriteAllFilesinSubFolders(string folderName, Guid? parentId)
        {
            if (parentId == null)
            {
                _folderRepository.ClearDB();
                if (!Directory.Exists(folderName))
                    throw new NullReferenceException(nameof(parentId));
            }

            FolderDto myFolder = new FolderDto(parentId, folderName);
            Guid myId = _folderRepository.WriteFolder(myFolder);

            string[] directories = Directory.GetDirectories(folderName);
            List<Task> tasks = new List<Task>();
            List<FileDto> filesList = await WriteFilesInFolder(folderName);

            foreach (string directory in directories)
                filesList.AddRange(await WriteAllFilesinSubFolders(directory,myId));

            return filesList;
        }
    }
}
