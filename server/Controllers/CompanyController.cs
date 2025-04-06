using Microsoft.AspNetCore.Mvc;
using HelloWorld.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly DataDapper _dataDapper;

        public CompanyController(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        // GET api/company
        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                var sql = "SELECT * FROM Companies";

                var companies = await Task.Run(() => _dataDapper.LoadData<Company>(sql));

                if (companies == null || !companies.Any())
                {
                    return NotFound("No companies found.");
                }

                return Ok(companies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/company/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            try
            {
                var sql = $"SELECT * FROM Companies WHERE Id = {id}";

                var company = await Task.Run(() => _dataDapper.LoadDataSingle<Company>(sql));

                if (company == null)
                {
                    return NotFound($"Company with ID {id} not found.");
                }

                return Ok(company);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/company
        [HttpPost]
        public IActionResult CreateCompany([FromBody] Company company)
        {
            try
            {
                if (company == null)
                {
                    return BadRequest("Company data is required.");
                }

                string validationMessage;
                if (!company.IsValid(out validationMessage))
                {
                    return BadRequest(validationMessage);
                }

                var sql = $"INSERT INTO Companies (OwnerId, Name, Description, Website, CreatedAt) " +
                          $"VALUES ({company.OwnerId}, '{company.Name}', '{company.Description}', '{company.Website}', '{company.CreatedAt}')";

                bool isCreated = _dataDapper.ExecuteSql(sql);

                if (!isCreated)
                {
                    return StatusCode(500, "Failed to create company.");
                }

                return CreatedAtAction(nameof(GetCompanyById), new { id = company.Id }, company);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/company/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCompany(int id, [FromBody] Company company)
        {
            try
            {
                if (company == null || id != company.Id)
                {
                    return BadRequest("Invalid company data.");
                }

                string validationMessage;
                if (!company.IsValid(out validationMessage))
                {
                    return BadRequest(validationMessage);
                }

                var sql = $"UPDATE Companies SET OwnerId = {company.OwnerId}, Name = '{company.Name}', " +
                          $"Description = '{company.Description}', Website = '{company.Website}', " +
                          $"CreatedAt = '{company.CreatedAt}' WHERE Id = {id}";

                bool isUpdated = _dataDapper.ExecuteSql(sql);

                if (!isUpdated)
                {
                    return StatusCode(500, "Failed to update company.");
                }

                return NoContent();  
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/company/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(int id)
        {
            try
            {
                var sql = $"DELETE FROM Companies WHERE Id = {id}";

                bool isDeleted = _dataDapper.ExecuteSql(sql);

                if (!isDeleted)
                {
                    return NotFound($"Company with ID {id} not found.");
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
