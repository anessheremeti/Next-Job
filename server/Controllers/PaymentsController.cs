using Microsoft.AspNetCore.Mvc;
using HelloWorld.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly DataDapper _dataDapper;

        public PaymentController(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        // GET api/payment
        [HttpGet]
        public async Task<IActionResult> GetPayments()
        {
            try
            {
                var sql = "SELECT * FROM Payment";

                var payments = await Task.Run(() => _dataDapper.LoadData<Payment>(sql));

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
                var sql = $"SELECT * FROM Payment WHERE Id = {id}";

                var payment = await Task.Run(() => _dataDapper.LoadDataSingle<Payment>(sql));

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
        public IActionResult CreatePayment([FromBody] Payment payment)
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

                var sql = $"INSERT INTO Payment (ContractId, Amount, PaymentDate, Status) " +
                          $"VALUES ({payment.ContractId}, {payment.Amount}, '{payment.PaymentDate}', '{payment.Status}')";

                bool isCreated = _dataDapper.ExecuteSql(sql);

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
        public IActionResult UpdatePaymentStatus(int id, [FromBody] string status)
        {
            try
            {
                var validStatuses = new[] { "Pending", "Completed", "Failed" };
                if (!validStatuses.Contains(status))
                {
                    return BadRequest("Invalid status.");
                }

                var sql = $"UPDATE Payment SET Status = '{status}' WHERE Id = {id}";

                bool isUpdated = _dataDapper.ExecuteSql(sql);

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
        public IActionResult DeletePayment(int id)
        {
            try
            {
                var sql = $"DELETE FROM Payment WHERE Id = {id}";

                bool isDeleted = _dataDapper.ExecuteSql(sql);

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
