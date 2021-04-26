using System.Collections.Generic;

namespace UsingViewComponents.Models
{
    public interface ICityRepository
    {
        IEnumerable<City> Cities { get; }
        void AddCity(City newCity);
    }
}
