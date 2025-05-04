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
}
