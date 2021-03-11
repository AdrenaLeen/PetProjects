using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;

namespace UrlsAndRoutes.Infrastructure
{
    public class WeekDayConstraint : IRouteConstraint
    {
        static string[] Days = new[] { "mon", "tue", "wed", "thu", "fri", "sat", "sun" };

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values,
            RouteDirection routeDirection) => Days.Contains(values[routeKey]?.ToString().ToLowerInvariant());
    }
}
