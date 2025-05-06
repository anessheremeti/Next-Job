<<<<<<< HEAD
public interface IGenderService
{
    Task<IEnumerable<Gender>> GetAllAsync();
=======
using HelloWorld.Models;
using System.Collections.Generic;

namespace HelloWorld.Services
{
    public interface IGenderService
    {
        IEnumerable<Gender> GetAllGenders();
        Gender? GetGenderById(int id);
        bool AddGender(Gender gender);
        bool UpdateGender(Gender gender);
        bool DeleteGender(int id);
    }
>>>>>>> 0f29022aeaf03c092a16ca8baead4826b969538e
}
