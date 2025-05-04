using HelloWorld.Models;
using System.Collections.Generic;

namespace HelloWorld.Services
{
    public interface IPaymentStatusService
    {
        IEnumerable<PaymentStatus> GetAllStatuses();
        PaymentStatus? GetStatusById(int id);
        bool AddStatus(PaymentStatus status);
        bool UpdateStatus(PaymentStatus status);
        bool DeleteStatus(int id);
    }
}
