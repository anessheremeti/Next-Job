using HelloWorld.Data;
using HelloWorld.Models;
using System;
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
            string sql = "SELECT OldBudgetTypeID AS BudgetTypeID, BudgetTypeName FROM BudgetType";
            return _dataDapper.LoadData<BudgetType>(sql);
        }

        public BudgetType? GetBudgetTypeById(int id)
        {
            string sql = "SELECT OldBudgetTypeID AS BudgetTypeID, BudgetTypeName FROM BudgetType WHERE OldBudgetTypeID = @Id";
            return _dataDapper.LoadDataSingle<BudgetType>(sql, new { Id = id });
        }

        public bool AddBudgetType(BudgetType budgetType)
        {
            try
            {
                string sql = "INSERT INTO BudgetType (BudgetTypeName) VALUES (@BudgetTypeName)";
                return _dataDapper.ExecuteSqlOpen(sql, budgetType);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" INSERT ERROR: " + ex.Message);
                throw;
            }
        }

        public bool UpdateBudgetType(BudgetType budgetType)
        {
            try
            {
                string sql = "UPDATE BudgetType SET BudgetTypeName = @BudgetTypeName WHERE OldBudgetTypeID = @BudgetTypeID";
                return _dataDapper.ExecuteSqlOpen(sql, budgetType);
            }
            catch (Exception ex)
            {
                Console.WriteLine("UPDATE ERROR: " + ex.Message);
                throw;
            }
        }

        public bool DeleteBudgetType(int id)
        {
            try
            {
                string sql = "DELETE FROM BudgetType WHERE OldBudgetTypeID = @Id";
                return _dataDapper.ExecuteSqlOpen(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                Console.WriteLine(" DELETE ERROR: " + ex.Message);
                throw;
            }
        }

        public Task<IEnumerable<BudgetType>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
