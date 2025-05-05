using Microsoft.AspNetCore.Mvc;
using HelloWorld.Models;
using HelloWorld.Services;
using System.Collections.Generic;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractStatusController : ControllerBase
    {
        private readonly IContractStatusService _contractStatusService;

        public ContractStatusController(IContractStatusService contractStatusService)
        {
            _contractStatusService = contractStatusService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ContractStatus>> GetAll()
        {
            var statuses = _contractStatusService.GetAllStatuses();
            return Ok(statuses);
        }

        [HttpGet("{id}")]
        public ActionResult<ContractStatus> GetById(int id)
        {
            var status = _contractStatusService.GetStatusById(id);
            if (status == null)
                return NotFound($"Contract status with ID {id} not found.");
            return Ok(status);
        }

        [HttpPost]
        public ActionResult Create([FromBody] ContractStatus status)
        {
            if (status == null || string.IsNullOrWhiteSpace(status.StatusName))
                return BadRequest("StatusName is required.");

            var created = _contractStatusService.AddStatus(status);
            if (!created)
                return StatusCode(500, "Failed to create contract status.");

            return CreatedAtAction(nameof(GetById), new { id = status.ContractStatusID }, status);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] ContractStatus status)
        {
            if (status == null || id != status.ContractStatusID)
                return BadRequest("ID mismatch or invalid data.");

            var updated = _contractStatusService.UpdateStatus(status);
            if (!updated)
                return StatusCode(500, "Failed to update contract status.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deleted = _contractStatusService.DeleteStatus(id);
            if (!deleted)
                return NotFound($"Contract status with ID {id} not found.");

            return NoContent();
        }
    }
}
