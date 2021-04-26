using System.Linq;
using UsingViewComponents.Models;

namespace UsingViewComponents.Components
{
    public class PocoViewComponent
    {
        readonly ICityRepository repository;

        public PocoViewComponent(ICityRepository repo) => repository = repo;

        public string Invoke() => $"Городов: {repository.Cities.Count()}, человек: {repository.Cities.Sum(c => c.Population)}";
    }
}
