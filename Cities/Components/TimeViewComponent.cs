using Microsoft.AspNetCore.Mvc;
using System;

namespace Cities.Components
{
    public class TimeViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View(DateTime.Now);
    }
}
