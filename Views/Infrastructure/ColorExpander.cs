using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;

namespace Views.Infrastructure
{
    public class ColorExpander : IViewLocationExpander
    {
        static readonly Dictionary<string, string> Colors = new Dictionary<string, string>
        {
            ["red"] = "Red",
            ["green"] = "Green",
            ["blue"] = "Blue"
        };

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            RouteValueDictionary routeValues = context.ActionContext.RouteData.Values;
            if (routeValues.ContainsKey("id") && Colors.TryGetValue(routeValues["id"] as string, out string color) && !string.IsNullOrEmpty(color)) context.Values["color"] = color;
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            context.Values.TryGetValue("color", out string color);
            foreach (string location in viewLocations)
            {
                if (!string.IsNullOrEmpty(color)) yield return location.Replace("{0}", color);
                else yield return location;
            }
        }
    }
}
