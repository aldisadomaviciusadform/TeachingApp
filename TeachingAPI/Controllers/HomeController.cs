using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Npgsql;
using System.Xml.Linq;
using TeachingAPI.Interfaces;
using TeachingAPI.NewFolder;
using TeachingAPI.Respositories;

namespace TeachingAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        /*
            Sukurkite API ir prijunkite savo lokalią postgre duomenų bazę prie šio projekto.
            Sukurkite endpointą įdėti naujam darbuotojui.
            Sukurkite endpointą gauti visiems darbuotojams. 
        */

        private readonly IDarbuotojasService _darbuotojasService;

        public HomeController(IDarbuotojasService darbuotojasService)
        {
             _darbuotojasService = darbuotojasService;
        }

        [HttpGet]
        public async Task<IActionResult> Getas(string name)
        {
            var returnas = _darbuotojasService.GetDarbuotojas();
            return Ok(returnas);
        }

        [HttpPost]
        public async Task<IActionResult>Posts([FromBody] Darbuotojas darbuotojas)
        {
            return Ok(_darbuotojasService.InsertDarbuotojas(darbuotojas));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Darbuotojas darbuotojas)
        {
            if (_darbuotojasService.ModifyDarbuotojas(darbuotojas) == 0)
                return BadRequest();
            else
                return Ok();
        }
    }
}
