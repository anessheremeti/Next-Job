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
}
