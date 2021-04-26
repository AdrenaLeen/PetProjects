using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UsingViewComponents.Models;

namespace UsingViewComponents.Components
{
    public class CitySummary : ViewComponent
    {
        readonly ICityRepository repository;

        public CitySummary(ICityRepository repo) => repository = repo;

        public IViewComponentResult Invoke(bool showList)
        {
            if (showList) return View("CityList", repository.Cities);
            else return View(new CityViewModel
            {
                Cities = repository.Cities.Count(),
                Population = repository.Cities.Sum(c => c.Population)
            });
        }
    }
}
