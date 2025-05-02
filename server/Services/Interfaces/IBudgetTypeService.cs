public interface IBudgetTypeService
{
    Task<IEnumerable<BudgetType>> GetAllAsync();
}
