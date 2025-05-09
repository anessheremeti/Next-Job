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
                var sql = "SELECT * FROM Payments";
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
                var sql = "SELECT * FROM Payments WHERE Id = @Id";
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

                string validationMessage;
                if (!payment.IsValid(out validationMessage))
                {
                    throw new ArgumentException($"Invalid payment data: {validationMessage}");
                }

                var sql = @"INSERT INTO Payments (Contract_Id, Amount, Payment_Date, Payment_Status_Id) 
                            VALUES (@ContractId, @Amount, @PaymentDate, @PaymentStatusId)";

                return await _dataDapper.ExecuteSqlAsync(sql, payment);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while creating payment: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdatePaymentStatusAsync(int id, int paymentStatusId)
        {
            try
            {
                if (paymentStatusId <= 0)
                {
                    throw new ArgumentException("Invalid PaymentStatusId.");
                }

                var sql = @"UPDATE Payments SET Payment_Status_Id = @PaymentStatusId WHERE Id = @Id";
                var parameters = new { PaymentStatusId = paymentStatusId, Id = id };

                return await _dataDapper.ExecuteSqlAsync(sql, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while updating payment status: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeletePaymentAsync(int id)
        {
            try
            {
                var sql = "DELETE FROM Payments WHERE Id = @Id";
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
