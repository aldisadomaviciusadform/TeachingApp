using FileAPI.Dtos;
using FileAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FileAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class HomeController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IFolderService _folderService;

        public HomeController(IFileService fileService, IFolderService folderService)
        {
            _fileService = fileService;
            _folderService = folderService;
        }

        /*
        Sukurkite programą, kuri kaip input’ą ims direktorijos path’ą kompiuteryje
Pasiėmusi path’ą ji praskenuos visus failus išskyrus folderius.
Surinks informaciją apie failus - Id, pavadinimas, dydis, pilnas path.
Tuos duomenis sudės į duomenų bazę(Viena lentelė su paminėtais stulpeliais: Id, pavadinimas, dydis, pilnas path).

 
Patobulinkite programą, kad ši dabar skenuotų ir folderius.
Radus folderį, ji eis į jo vidų skenuoti failų toliau(radus folderyje kitą folderį eis į jo vidų).
Kaskartą radus folderį išsaugos jo pavadinimą ir sukurtą Id.
Kiekvienas rastas failas turi turėti folderio ID, kuriam jis priklauso.

Bonus point jeigu turėsite duombazės struktūra, kurioje bus galima sukurti sbufolderių subfolderius ir atsekti visą kelią nuo root aplanko iki failo.
         */

        [HttpGet]
        public async Task<IActionResult> GetFilesInFolder(string path)
        {
            var items = _folderService.WriteFilesInFolder(path);
            if (items == null)
                return NoContent();
            else
                return Ok(items);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFilesinSubFolders(string path)
        {
            var items = await _folderService.WriteAllFilesinSubFolders(path, null);
            if (items == null)
                return NoContent();
            else
                return Ok(items);
        }

        [HttpPut]
        public async Task<IActionResult> UploadImage([FromBody] FileUploadDownloadDto file)
        {
            var items = _fileService.UploadFile(file);
            if (items == null)
                return NoContent();
            else
                return Ok(items);
        }

        [HttpGet]
        public async Task<IActionResult> DownloadImage(string imageName)
        {
            var items = _fileService.Download(imageName);
            if (items == null)
                return NoContent();
            else
                return Ok(items);
        }
    }
}
