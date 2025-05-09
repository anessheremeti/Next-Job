
using HelloWorld.Models;
using System.Collections.Generic;

namespace HelloWorld.Services
{
    public interface IExperienceLevelService
    {
        IEnumerable<ExperienceLevel> GetAllExperienceLevels();
        ExperienceLevel? GetExperienceLevelById(int id);
        bool AddExperienceLevel(ExperienceLevel level);
        bool UpdateExperienceLevel(ExperienceLevel level);
        bool DeleteExperienceLevel(int id);
    }
}
