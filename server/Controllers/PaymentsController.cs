using Microsoft.AspNetCore.Mvc;
using HelloWorld.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // GET api/payment
        [HttpGet]
        public async Task<IActionResult> GetPayments()
        {
            var payments = await _paymentService.GetPaymentsAsync();
            if (payments == null || !payments.Any())
                return NotFound("No payments found.");

            return Ok(payments);
        }

        // GET api/payment/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentById(int id)
        {
            var payment = await _paymentService.GetPaymentByIdAsync(id);
            if (payment == null)
                return NotFound($"Payment with ID {id} not found.");

            return Ok(payment);
        }

        // POST api/payment
        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] Payment payment)
        {
            if (payment == null)
                return BadRequest("Payment data is required.");

            if (!payment.IsValid(out string validationMessage))
                return BadRequest(validationMessage);

            var isCreated = await _paymentService.CreatePaymentAsync(payment);
            if (!isCreated)
                return StatusCode(500, "Failed to create payment.");

            return CreatedAtAction(nameof(GetPaymentById), new { id = payment.Id }, payment);
        }

        // PUT api/payment/updatestatus/{id}
        [HttpPut("updatestatus/{id}")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] int paymentStatusId)
        {
            if (paymentStatusId <= 0)
                return BadRequest("Invalid status ID.");

            var updated = await _paymentService.UpdatePaymentStatusAsync(id, paymentStatusId);
            if (!updated)
                return NotFound($"Payment with ID {id} not found.");

            return NoContent();
        }

        // DELETE api/payment/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var deleted = await _paymentService.DeletePaymentAsync(id);
            if (!deleted)
                return NotFound($"Payment with ID {id} not found.");

            return NoContent();
        }
    }
}
