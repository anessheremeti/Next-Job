using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminTestController : ControllerBase
    {
        // Endpoint i mbrojtur për çfarëdo përdoruesi të loguar
        [HttpGet("secure")]
        [Authorize]
        public IActionResult SecureArea()
        {
            return Ok("✅ Ky endpoint është i qasshëm për çdo përdorues të autentifikuar.");
        }

        // Endpoint i mbrojtur vetëm për përdorues me rol "admin"
        [HttpGet("admin-only")]
        [Authorize(Roles = "admin")]
        public IActionResult AdminOnly()
        {
            return Ok("🔐 Ky endpoint është i qasshëm vetëm për ADMIN.");
        }
    }
}
