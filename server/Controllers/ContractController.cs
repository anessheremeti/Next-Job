using Microsoft.AspNetCore.Mvc;
using HelloWorld.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly DataDapper _dataDapper;

        public ContractController(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        // GET api/contract
        [HttpGet]
        public async Task<IActionResult> GetContracts()
        {
            try
            {
                var sql = "SELECT * FROM Contracts";

                var contracts = await Task.Run(() => _dataDapper.LoadData<Contract>(sql));

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
                var sql = $"SELECT * FROM Contracts WHERE Id = {id}";

                var contract = await Task.Run(() => _dataDapper.LoadDataSingle<Contract>(sql));

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
        public IActionResult CreateContract([FromBody] Contract contract)
        {
            try
            {
                if (contract == null)
                {
                    return BadRequest("Contract data is required.");
                }

                string validationMessage;
                if (!contract.IsValid(out validationMessage))
                {
                    return BadRequest(validationMessage);
                }

                var sql = $"INSERT INTO Contracts (FreelancerId, ClientId, JobId, StartDate, EndDate, Status) " +
                          $"VALUES ({contract.FreelancerId}, {contract.ClientId}, {contract.JobId}, '{contract.StartDate}', '{contract.EndDate}', '{contract.Status}')";

                bool isCreated = _dataDapper.ExecuteSql(sql);

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
        public IActionResult UpdateContract(int id, [FromBody] Contract contract)
        {
            try
            {
                if (contract == null || id != contract.Id)
                {
                    return BadRequest("Invalid contract data.");
                }

                string validationMessage;
                if (!contract.IsValid(out validationMessage))
                {
                    return BadRequest(validationMessage);
                }

                var sql = $"UPDATE Contracts SET FreelancerId = {contract.FreelancerId}, ClientId = {contract.ClientId}, JobId = {contract.JobId}, " +
                          $"StartDate = '{contract.StartDate}', EndDate = '{contract.EndDate}', Status = '{contract.Status}' WHERE Id = {id}";

                bool isUpdated = _dataDapper.ExecuteSql(sql);

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
        public IActionResult DeleteContract(int id)
        {
            try
            {
                var sql = $"DELETE FROM Contracts WHERE Id = {id}";

                bool isDeleted = _dataDapper.ExecuteSql(sql);

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
