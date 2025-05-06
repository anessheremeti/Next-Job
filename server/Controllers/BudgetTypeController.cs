using Microsoft.AspNetCore.Mvc;
using HelloWorld.Models;
using HelloWorld.Services;

namespace HelloWorld.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BudgetTypeController : ControllerBase
    {
        private readonly IBudgetTypeService _budgetTypeService;

        public BudgetTypeController(IBudgetTypeService budgetTypeService)
        {
            _budgetTypeService = budgetTypeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var types = _budgetTypeService.GetAllBudgetTypes();
            return Ok(types);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var type = _budgetTypeService.GetBudgetTypeById(id);
            if (type == null)
                return NotFound("Budget type not found.");
            return Ok(type);
        }

        [HttpPost]
        public IActionResult Create([FromBody] BudgetType budgetType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = _budgetTypeService.AddBudgetType(budgetType);
            if (!success)
                return StatusCode(500, "Failed to create budget type.");

            return Ok("Budget type created successfully.");
        }

        [HttpPut]
        public IActionResult Update([FromBody] BudgetType budgetType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = _budgetTypeService.UpdateBudgetType(budgetType);
            if (!success)
                return NotFound("Budget type not found or not updated.");

            return Ok("Budget type updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _budgetTypeService.DeleteBudgetType(id);
            if (!success)
                return NotFound("Budget type not found or not deleted.");

            return Ok("Budget type deleted successfully.");
        }
    }
}
