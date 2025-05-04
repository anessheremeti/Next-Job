using Microsoft.AspNetCore.Mvc;
using HelloWorld.Models;
using HelloWorld.Services;

namespace HelloWorld.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentStatusController : ControllerBase
    {
        private readonly IPaymentStatusService _paymentStatusService;

        public PaymentStatusController(IPaymentStatusService paymentStatusService)
        {
            _paymentStatusService = paymentStatusService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var statuses = _paymentStatusService.GetAllStatuses();
            return Ok(statuses);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var status = _paymentStatusService.GetStatusById(id);
            if (status == null)
                return NotFound("Payment status not found.");
            return Ok(status);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PaymentStatus status)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = _paymentStatusService.AddStatus(status);
            if (!success)
                return StatusCode(500, "Failed to create payment status.");

            return Ok("Payment status created successfully.");
        }

        [HttpPut]
        public IActionResult Update([FromBody] PaymentStatus status)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = _paymentStatusService.UpdateStatus(status);
            if (!success)
                return NotFound("Payment status not found or not updated.");

            return Ok("Payment status updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _paymentStatusService.DeleteStatus(id);
            if (!success)
                return NotFound("Payment status not found or not deleted.");

            return Ok("Payment status deleted successfully.");
        }
    }
}
