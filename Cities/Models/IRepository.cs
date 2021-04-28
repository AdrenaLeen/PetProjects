using System.Collections.Generic;

namespace Cities.Models
{
    public interface IRepository
    {
        IEnumerable<City> Cities { get; }
        void AddCity(City newCity);
    }
}
