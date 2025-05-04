using Microsoft.AspNetCore.Mvc;
using HelloWorld.Models;
using HelloWorld.Services;

namespace HelloWorld.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractStatusController : ControllerBase
    {
        private readonly IContractStatusService _contractStatusService;

        public ContractStatusController(IContractStatusService contractStatusService)
        {
            _contractStatusService = contractStatusService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var statuses = _contractStatusService.GetAllStatuses();
            return Ok(statuses);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var status = _contractStatusService.GetStatusById(id);
            if (status == null)
                return NotFound("Contract status not found.");
            return Ok(status);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ContractStatus status)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = _contractStatusService.AddStatus(status);
            if (!success)
                return StatusCode(500, "Failed to create contract status.");

            return Ok("Contract status created successfully.");
        }

        [HttpPut]
        public IActionResult Update([FromBody] ContractStatus status)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = _contractStatusService.UpdateStatus(status);
            if (!success)
                return NotFound("Contract status not found or not updated.");

            return Ok("Contract status updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _contractStatusService.DeleteStatus(id);
            if (!success)
                return NotFound("Contract status not found or not deleted.");

            return Ok("Contract status deleted successfully.");
        }
    }
}
