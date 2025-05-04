using HelloWorld.Data;
using HelloWorld.Models;
using System.Collections.Generic;

namespace HelloWorld.Services
{
    public class PaymentStatusService : IPaymentStatusService
    {
        private readonly DataDapper _dataDapper;

        public PaymentStatusService(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        public IEnumerable<PaymentStatus> GetAllStatuses()
        {
            string sql = "SELECT PaymentStatusID, StatusName FROM PaymentStatus";
            return _dataDapper.LoadData<PaymentStatus>(sql);
        }

        public PaymentStatus? GetStatusById(int id)
        {
            string sql = "SELECT PaymentStatusID, StatusName FROM PaymentStatus WHERE PaymentStatusID = @Id";
            return _dataDapper.LoadDataSingle<PaymentStatus>(sql, new { Id = id });
        }

        public bool AddStatus(PaymentStatus status)
        {
            string sql = "INSERT INTO PaymentStatus (StatusName) VALUES (@StatusName)";
            return _dataDapper.ExecuteSqlOpen(sql, status);
        }

        public bool UpdateStatus(PaymentStatus status)
        {
            string sql = "UPDATE PaymentStatus SET StatusName = @StatusName WHERE PaymentStatusID = @PaymentStatusID";
            return _dataDapper.ExecuteSqlOpen(sql, status);
        }

        public bool DeleteStatus(int id)
        {
            string sql = "DELETE FROM PaymentStatus WHERE PaymentStatusID = @Id";
            return _dataDapper.ExecuteSqlOpen(sql, new { Id = id });
        }
    }
}
