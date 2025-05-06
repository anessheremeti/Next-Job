public interface IGenderService
{
    Task<IEnumerable<Gender>> GetAllAsync();
}
