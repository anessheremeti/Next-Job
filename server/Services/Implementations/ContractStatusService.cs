using HelloWorld.Data;
using HelloWorld.Models;
using System.Collections.Generic;

namespace HelloWorld.Services
{
    public class ContractStatusService : IContractStatusService
    {
        private readonly DataDapper _dataDapper;

        public ContractStatusService(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        public IEnumerable<ContractStatus> GetAllStatuses()
        {
            string sql = "SELECT ContractStatusID, StatusName FROM ContractStatus";
            return _dataDapper.LoadData<ContractStatus>(sql);
        }

        public ContractStatus? GetStatusById(int id)
        {
            string sql = "SELECT ContractStatusID, StatusName FROM ContractStatus WHERE ContractStatusID = @Id";
            return _dataDapper.LoadDataSingle<ContractStatus>(sql, new { Id = id });
        }

        public bool AddStatus(ContractStatus status)
        {
            string sql = "INSERT INTO ContractStatus (StatusName) VALUES (@StatusName)";
            return _dataDapper.ExecuteSqlOpen(sql, status);
        }

        public bool UpdateStatus(ContractStatus status)
        {
            string sql = "UPDATE ContractStatus SET StatusName = @StatusName WHERE ContractStatusID = @ContractStatusID";
            return _dataDapper.ExecuteSqlOpen(sql, status);
        }

        public bool DeleteStatus(int id)
        {
            string sql = "DELETE FROM ContractStatus WHERE ContractStatusID = @Id";
            return _dataDapper.ExecuteSqlOpen(sql, new { Id = id });
        }
    }
}
