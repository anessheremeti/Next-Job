using HelloWorld.Data;
using HelloWorld.Models;
using System.Collections.Generic;

namespace HelloWorld.Services
{
    public class BudgetTypeService : IBudgetTypeService
    {
        private readonly DataDapper _dataDapper;

        public BudgetTypeService(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }

        public IEnumerable<BudgetType> GetAllBudgetTypes()
        {
            string sql = "SELECT BudgetTypeID, BudgetTypeName FROM BudgetType";
            return _dataDapper.LoadData<BudgetType>(sql);
        }

        public BudgetType? GetBudgetTypeById(int id)
        {
            string sql = "SELECT BudgetTypeID, BudgetTypeName FROM BudgetType WHERE BudgetTypeID = @Id";
            return _dataDapper.LoadDataSingle<BudgetType>(sql, new { Id = id });
        }

        public bool AddBudgetType(BudgetType budgetType)
        {
            string sql = "INSERT INTO BudgetType (BudgetTypeName) VALUES (@BudgetTypeName)";
            return _dataDapper.ExecuteSqlOpen(sql, budgetType);
        }

        public bool UpdateBudgetType(BudgetType budgetType)
        {
            string sql = "UPDATE BudgetType SET BudgetTypeName = @BudgetTypeName WHERE BudgetTypeID = @BudgetTypeID";
            return _dataDapper.ExecuteSqlOpen(sql, budgetType);
        }

        public bool DeleteBudgetType(int id)
        {
            string sql = "DELETE FROM BudgetType WHERE BudgetTypeID = @Id";
            return _dataDapper.ExecuteSqlOpen(sql, new { Id = id });
        }
    }
}
