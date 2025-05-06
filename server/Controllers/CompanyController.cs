using Microsoft.AspNetCore.Mvc;
using HelloWorld.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        // GET: api/company
        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                var companies = await _companyService.GetCompaniesAsync();

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

        // GET: api/company/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            try
            {
                var company = await _companyService.GetCompanyByIdAsync(id);

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

        // POST: api/company
        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] Company company)
        {
            try
            {
                string validationMessage = string.Empty;

                if (company == null || !company.IsValid(out validationMessage))
                {
                    return BadRequest($"Invalid company data: {validationMessage}");
                }

                var isCreated = await _companyService.CreateCompanyAsync(company);

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

        // PUT: api/company/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, [FromBody] Company company)
        {
            try
            {
                string validationMessage = string.Empty;

                if (company == null || id != company.Id || !company.IsValid(out validationMessage))
                {
                    return BadRequest($"Invalid company data: {validationMessage}");
                }

                var isUpdated = await _companyService.UpdateCompanyAsync(id, company);

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

        // DELETE: api/company/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            try
            {
                var isDeleted = await _companyService.DeleteCompanyAsync(id);

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
