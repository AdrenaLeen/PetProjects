using System.Collections.Generic;

namespace UsingViewComponents.Models
{
    public class MemoryCityRepository : ICityRepository
    {
        List<City> cities = new List<City>
        {
            new City { Name = "Лондон", Country = "UK", Population = 8539000 },
            new City { Name = "Нью Йорк", Country = "USA", Population = 8406000 },
            new City { Name = "Сан-Хосе", Country = "USA", Population = 998537 },
            new City { Name = "Париж", Country = "France", Population = 2244000 }
        };

        public IEnumerable<City> Cities => cities;

        public void AddCity(City newCity) => cities.Add(newCity);
    }
}
