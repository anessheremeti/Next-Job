<<<<<<< HEAD
public interface IPaymentStatusService
{
    Task<IEnumerable<PaymentStatus>> GetAllAsync();
=======
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
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
}
