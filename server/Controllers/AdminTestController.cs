using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminTestController : ControllerBase
    {
        
        [HttpGet("secure")]
        [Authorize]
        public IActionResult SecureArea()
        {
            return Ok("✅ Ky endpoint është i qasshëm për çdo përdorues të autentifikuar.");
        }

        [HttpGet("admin-only")]
        [Authorize(Roles = "admin")]
        public IActionResult AdminOnly()
        {
            return Ok("🔐 Ky endpoint është i qasshëm vetëm për ADMIN.");
        }
    }
}
