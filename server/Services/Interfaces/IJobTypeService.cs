public interface IJobTypeService
{
    Task<IEnumerable<JobType>> GetAllAsync();
}
