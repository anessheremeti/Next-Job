using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.Services
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> GetPaymentsAsync();
        Task<Payment?> GetPaymentByIdAsync(int id);
        Task<bool> CreatePaymentAsync(Payment payment);
        Task<bool> UpdatePaymentStatusAsync(int id, int paymentStatusId);
        Task<bool> DeletePaymentAsync(int id);
    }
}
