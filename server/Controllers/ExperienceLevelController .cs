using Microsoft.AspNetCore.Mvc;
using HelloWorld.Services;
using System.Threading.Tasks;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceLevelController : ControllerBase
    {
        private readonly IExperienceLevelService _service;

        public ExperienceLevelController(IExperienceLevelService service)
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
