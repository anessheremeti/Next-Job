using HelloWorld.Models;
using System.Collections.Generic;

namespace HelloWorld.Services
{
    public interface IBudgetTypeService
    {
        IEnumerable<BudgetType> GetAllBudgetTypes();
        BudgetType? GetBudgetTypeById(int id);
        bool AddBudgetType(BudgetType budgetType);
        bool UpdateBudgetType(BudgetType budgetType);
        bool DeleteBudgetType(int id);
    }
}
