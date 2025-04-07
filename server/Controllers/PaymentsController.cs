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
            try
            {
                var payments = await _paymentService.GetPaymentsAsync();

                if (payments == null || !payments.Any())
                {
                    return NotFound("No payments found.");
                }

                return Ok(payments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/payment/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentById(int id)
        {
            try
            {
                var payment = await _paymentService.GetPaymentByIdAsync(id);

                if (payment == null)
                {
                    return NotFound($"Payment with ID {id} not found.");
                }

                return Ok(payment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/payment
        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] Payment payment)
        {
            try
            {
                if (payment == null)
                {
                    return BadRequest("Payment data is required.");
                }

                // Validate payment data
                string validationMessage;
                if (!payment.IsValid(out validationMessage))
                {
                    return BadRequest(validationMessage);
                }

                var isCreated = await _paymentService.CreatePaymentAsync(payment);

                if (!isCreated)
                {
                    return StatusCode(500, "Failed to create payment.");
                }

                return CreatedAtAction(nameof(GetPaymentById), new { id = payment.Id }, payment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/payment/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePaymentStatus(int id, [FromBody] string status)
        {
            try
            {
                var isUpdated = await _paymentService.UpdatePaymentStatusAsync(id, status);

                if (!isUpdated)
                {
                    return NotFound($"Payment with ID {id} not found.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/payment/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            try
            {
                var isDeleted = await _paymentService.DeletePaymentAsync(id);

                if (!isDeleted)
                {
                    return NotFound($"Payment with ID {id} not found.");
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
