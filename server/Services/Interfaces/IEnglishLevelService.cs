public interface IEnglishLevelService
{
    Task<IEnumerable<EnglishLevel>> GetAllAsync();
}
