using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;

namespace Views.Infrastructure
{
    public class SimpleExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            foreach (string location in viewLocations) yield return location.Replace("Shared", "Common");
            yield return "/Views/Legacy/{1}/{0}/View.cshtml";
        }

        // Ничего не делать - метод не требуется
        public void PopulateValues(ViewLocationExpanderContext context) { }
    }
}
