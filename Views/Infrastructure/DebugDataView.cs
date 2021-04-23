using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Views.Infrastructure
{
    public class DebugDataView : IView
    {
        public string Path => string.Empty;

        public async Task RenderAsync(ViewContext context)
        {
            context.HttpContext.Response.ContentType = "text/plain";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("---Routing Data---");
            foreach (KeyValuePair<string, object> kvp in context.RouteData.Values)
                sb.AppendLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            sb.AppendLine("---View Data---");
            foreach (KeyValuePair<string, object> kvp in context.ViewData)
                sb.AppendLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            await context.Writer.WriteAsync(sb.ToString());
        }
    }
}
