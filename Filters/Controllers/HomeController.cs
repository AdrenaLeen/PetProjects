using Filters.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Filters.Controllers
{
    [Message("This is the Controller-Scoped Filter", Order = 10)]
    public class HomeController : Controller
    {
        [Message("This is the First Action-Scoped Filter", Order = 1)]
        [Message("This is the Second Action-Scoped Filter", Order = -1)]
        public ViewResult Index() => View("Message", "Это действие Index в контроллере Home");

        public ViewResult SecondAction() => View("Message", "Это действие SecondAction в контроллере Home");

        public ViewResult GenerateException(int? id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            else if (id > 10) throw new ArgumentOutOfRangeException(nameof(id));
            else return View("Message", $"Значение равно {id}");
        }
    }
}
