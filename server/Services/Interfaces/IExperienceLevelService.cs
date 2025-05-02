public interface IExperienceLevelService
{
    Task<IEnumerable<ExperienceLevel>> GetAllAsync();
}
