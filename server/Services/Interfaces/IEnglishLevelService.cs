<<<<<<< HEAD
public interface IEnglishLevelService
{
    Task<IEnumerable<EnglishLevel>> GetAllAsync();
=======
using HelloWorld.Models;
using System.Collections.Generic;

namespace HelloWorld.Services
{
    public interface IEnglishLevelService
    {
        IEnumerable<EnglishLevel> GetAllLevels();
        EnglishLevel? GetLevelById(int id);
        bool AddLevel(EnglishLevel level);
        bool UpdateLevel(EnglishLevel level);
        bool DeleteLevel(int id);
    }
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
}
