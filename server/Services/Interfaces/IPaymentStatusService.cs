public interface IPaymentStatusService
{
    Task<IEnumerable<PaymentStatus>> GetAllAsync();
}
