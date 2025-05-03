using HelloWorld.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace HelloWorld.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly DataDapper _dataDapper;

        public PaymentService(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        public async Task<IEnumerable<Payment>> GetPaymentsAsync()
        {
            try
            {
                var sql = "SELECT * FROM Payment";
                return await _dataDapper.LoadDataAsync<Payment>(sql);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving payments: {ex.Message}", ex);
            }
        }

        public async Task<Payment?> GetPaymentByIdAsync(int id)
        {
            try
            {
                var sql = "SELECT * FROM Payment WHERE Id = @Id";
                var parameters = new { Id = id };
                return await _dataDapper.LoadDataSingleAsync<Payment>(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving payment with ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<bool> CreatePaymentAsync(Payment payment)
        {
            try
            {
                if (payment == null)
                {
                    throw new ArgumentException("Payment data is required.");
                }

                var sql = "INSERT INTO Payment (ContractId, Amount, PaymentDate, Status) " +
                          "VALUES (@ContractId, @Amount, @PaymentDate, @Status)";
                
                return await _dataDapper.ExecuteSqlAsync(sql, payment);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while creating payment: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdatePaymentStatusAsync(int id, string status)
        {
            try
            {
                var validStatuses = new[] { "Pending", "Completed", "Failed" };
                if (!Array.Exists(validStatuses, s => s.Equals(status, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new ArgumentException("Invalid status.");
                }

                var sql = "UPDATE Payment SET Status = @Status WHERE Id = @Id";
                var parameters = new { Status = status, Id = id };
                return await _dataDapper.ExecuteSqlAsync(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while updating payment status for ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeletePaymentAsync(int id)
        {
            try
            {
                var sql = "DELETE FROM Payment WHERE Id = @Id";
                var parameters = new { Id = id };
                return await _dataDapper.ExecuteSqlAsync(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting payment with ID {id}: {ex.Message}", ex);
            }
        }
    }
}
