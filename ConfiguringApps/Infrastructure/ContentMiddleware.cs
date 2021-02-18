﻿using Microsoft.AspNetCore.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    public class ContentMiddleware
    {
        readonly RequestDelegate nextDelegate;
        readonly UptimeService uptime;

        public ContentMiddleware(RequestDelegate next, UptimeService up)
        {
            nextDelegate = next;
            uptime = up;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().ToLower() == "/middleware") await httpContext.Response.WriteAsync($"This is from the content middleware (uptime: {uptime.Uptime} ms)", Encoding.UTF8);
            else await nextDelegate.Invoke(httpContext);
        }
    }
}
