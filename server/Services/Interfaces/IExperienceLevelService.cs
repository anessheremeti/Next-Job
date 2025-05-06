<<<<<<< HEAD
public interface IExperienceLevelService
{
    Task<IEnumerable<ExperienceLevel>> GetAllAsync();
=======
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
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
}
