﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ControllersAndActions.Controllers
{
    public class DerivedController : Controller
    {
        public ViewResult Index() => View("Result", "Это производный контроллер");

        public ViewResult Headers() => View("DictionaryResult", Request.Headers.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.First()));
    }
}
