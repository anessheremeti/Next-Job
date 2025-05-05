using HelloWorld.Services;
using HelloWorld.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;

// namespace HelloWorld.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class ClientProfileController : ControllerBase
//     {
//         private readonly IClientService _clientService;

//         public ClientProfileController(IClientService clientService)
//         {
//             _clientService = clientService;
//         }

//         // GET api/clientprofile
//         [HttpGet]
//         public async Task<IActionResult> GetClientProfiles()
//         {
//             try
//             {
//                 var clientProfiles = await _clientService.GetClientProfilesAsync();

//                 if (clientProfiles == null || !clientProfiles.Any())
//                 {
//                     return NotFound("No client profiles found.");
//                 }

//                 return Ok(clientProfiles);
//             }
//             catch (Exception ex)
//             {
//                 return StatusCode(500, $"Internal server error: {ex.Message}");
//             }
//         }

//         // GET api/clientprofile/{id}
//         [HttpGet("{id}")]
//         public async Task<IActionResult> GetClientProfileById(int id)
//         {
//             try
//             {
//                 var clientProfile = await _clientService.GetClientProfileByIdAsync(id);

//                 if (clientProfile == null)
//                 {
//                     return NotFound($"Client profile with ID {id} not found.");
//                 }

//                 return Ok(clientProfile);
//             }
//             catch (Exception ex)
//             {
//                 return StatusCode(500, $"Internal server error: {ex.Message}");
//             }
//         }

//         // POST api/clientprofile
//         [HttpPost]
//         public async Task<IActionResult> CreateClientProfile([FromBody] ClientProfile clientProfile)
//         {
//             try
//             {
//                 if (clientProfile == null || !clientProfile.isValid())
//                 {
//                     return BadRequest("Invalid client profile data.");
//                 }

//                 var isCreated = await _clientService.CreateClientProfileAsync(clientProfile);

//                 if (!isCreated)
//                 {
//                     return StatusCode(500, "Failed to create client profile.");
//                 }

//                 return CreatedAtAction(nameof(GetClientProfileById), new { id = clientProfile.Id }, clientProfile);
//             }
//             catch (Exception ex)
//             {
//                 return StatusCode(500, $"Internal server error: {ex.Message}");
//             }
//         }

//         // PUT api/clientprofile/{id}
//         [HttpPut("{id}")]
//         public async Task<IActionResult> UpdateClientProfile(int id, [FromBody] ClientProfile clientProfile)
//         {
//             try
//             {
//                 if (clientProfile == null || id != clientProfile.Id || !clientProfile.isValid())
//                 {
//                     return BadRequest("Invalid client profile data.");
//                 }

//                 var isUpdated = await _clientService.UpdateClientProfileAsync(id, clientProfile);

//                 if (!isUpdated)
//                 {
//                     return StatusCode(500, "Failed to update client profile.");
//                 }

//                 return NoContent();
//             }
//             catch (Exception ex)
//             {
//                 return StatusCode(500, $"Internal server error: {ex.Message}");
//             }
//         }

//         // DELETE api/clientprofile/{id}
//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteClientProfile(int id)
//         {
//             try
//             {
//                 var isDeleted = await _clientService.DeleteClientProfileAsync(id);

//                 if (!isDeleted)
//                 {
//                     return NotFound($"Client profile with ID {id} not found.");
//                 }

//                 return NoContent();
//             }
//             catch (Exception ex)
//             {
//                 return StatusCode(500, $"Internal server error: {ex.Message}");
//             }
//         }
//     }
// }

// Controller
[ApiController]
[Route("api/[controller]")]
public class ClientProfileController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientProfileController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _clientService.GetClientProfilesAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _clientService.GetClientProfileByIdAsync(id);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ClientProfile profile)
    {
        var created = await _clientService.CreateClientProfileAsync(profile);
        return created ? Ok("Client profile created.") : StatusCode(500, "Failed to create.");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ClientProfile profile)
    {
        var updated = await _clientService.UpdateClientProfileAsync(id, profile);
        return updated ? NoContent() : StatusCode(500, "Failed to update.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _clientService.DeleteClientProfileAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
