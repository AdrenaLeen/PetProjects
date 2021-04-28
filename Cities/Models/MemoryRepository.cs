using System.Collections.Generic;

namespace Cities.Models
{
    public class MemoryRepository : IRepository
    {
        readonly List<City> cities = new List<City>
        {
            new City { Name = "Лондон", Country = "Великобритания", Population = 8539000 },
            new City { Name = "Нью Йорк", Country = "США", Population = 8406000 },
            new City { Name = "Сан-Хосе", Country = "США", Population = 998537 },
            new City { Name = "Париж", Country = "Франция", Population = 2244000 }
        };

        public IEnumerable<City> Cities => cities;

        public void AddCity(City newCity) => cities.Add(newCity);
    }
}
