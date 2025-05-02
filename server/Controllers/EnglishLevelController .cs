using Microsoft.AspNetCore.Mvc;
using HelloWorld.Services;
using System.Threading.Tasks;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnglishLevelController : ControllerBase
    {
        private readonly IEnglishLevelService _service;

        public EnglishLevelController(IEnglishLevelService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var levels = await _service.GetAllAsync();
            return Ok(levels);
        }
    }
}
