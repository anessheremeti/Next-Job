using Microsoft.AspNetCore.Mvc;
using HelloWorld.Services;
using System.Threading.Tasks;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTypeController : ControllerBase
    {
        private readonly IJobTypeService _service;

        public JobTypeController(IJobTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobTypes = await _service.GetAllAsync();
            return Ok(jobTypes);
        }
    }
}
