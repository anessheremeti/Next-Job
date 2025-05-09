using Microsoft.AspNetCore.Mvc;
using HelloWorld.Services;
using HelloWorld.Models;
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

        [HttpGet]
        public async Task<IActionResult> GetContracts()
        {
            try
            {
                var contracts = await _contractService.GetContractsAsync();
                if (contracts == null || !contracts.Any())
                    return NotFound("No contracts found.");

                return Ok(contracts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContractById(int id)
        {
            try
            {
                var contract = await _contractService.GetContractByIdAsync(id);
                if (contract == null)
                    return NotFound($"Contract with ID {id} not found.");

                return Ok(contract);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateContract([FromBody] ContractCreateDto dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest("Contract data is required.");

                var isCreated = await _contractService.CreateContractAsync(dto);
                if (!isCreated)
                    return StatusCode(500, "Failed to create contract.");

                return Ok("Contract created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContract(int id, [FromBody] Contract contract)
        {
            try
            {
                if (contract == null || id != contract.Id)
                    return BadRequest("Invalid contract data.");

                var isUpdated = await _contractService.UpdateContractAsync(id, contract);
                if (!isUpdated)
                    return StatusCode(500, "Failed to update contract.");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContract(int id)
        {
            try
            {
                var isDeleted = await _contractService.DeleteContractAsync(id);
                if (!isDeleted)
                    return NotFound($"Contract with ID {id} not found.");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}