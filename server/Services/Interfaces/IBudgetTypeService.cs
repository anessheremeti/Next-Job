<<<<<<< HEAD
public interface IBudgetTypeService
{
    Task<IEnumerable<BudgetType>> GetAllAsync();
=======
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
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
}
