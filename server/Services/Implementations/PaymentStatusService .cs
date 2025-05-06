using HelloWorld.Data;

public class PaymentStatusService : IPaymentStatusService
{
    private readonly DataDapper _dataDapper;

    public PaymentStatusService(DataDapper dataDapper)
    {
        _dataDapper = dataDapper;
    }

    public async Task<IEnumerable<PaymentStatus>> GetAllAsync()
    {
        var sql = "SELECT * FROM PaymentStatus";
        return await _dataDapper.LoadDataAsync<PaymentStatus>(sql);
    }
}
