using Microsoft.AspNetCore.Mvc;
using HelloWorld.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _contractService;

        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }

        // GET api/contract
        [HttpGet]
        public async Task<IActionResult> GetContracts()
        {
            try
            {
                var contracts = await _contractService.GetContractsAsync();

                if (contracts == null || !contracts.Any())
                {
                    return NotFound("No contracts found.");
                }

                return Ok(contracts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/contract/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContractById(int id)
        {
            try
            {
                var contract = await _contractService.GetContractByIdAsync(id);

                if (contract == null)
                {
                    return NotFound($"Contract with ID {id} not found.");
                }

                return Ok(contract);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/contract
        [HttpPost]
        public async Task<IActionResult> CreateContract([FromBody] Contract contract)
        {
            try
            {
                if (contract == null)
                {
                    return BadRequest("Contract data is required.");
                }

                var isCreated = await _contractService.CreateContractAsync(contract);

                if (!isCreated)
                {
                    return StatusCode(500, "Failed to create contract.");
                }

                return CreatedAtAction(nameof(GetContractById), new { id = contract.Id }, contract);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/contract/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContract(int id, [FromBody] Contract contract)
        {
            try
            {
                if (contract == null || id != contract.Id)
                {
                    return BadRequest("Invalid contract data.");
                }

                var isUpdated = await _contractService.UpdateContractAsync(id, contract);

                if (!isUpdated)
                {
                    return StatusCode(500, "Failed to update contract.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/contract/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContract(int id)
        {
            try
            {
                var isDeleted = await _contractService.DeleteContractAsync(id);

                if (!isDeleted)
                {
                    return NotFound($"Contract with ID {id} not found.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
