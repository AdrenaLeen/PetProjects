﻿using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace Filters.Infrastructure
{
    public class MessageAttribute : ResultFilterAttribute
    {
        readonly string message;

        public MessageAttribute(string msg) => message = msg;

        public override void OnResultExecuting(ResultExecutingContext context) => WriteMessage(context, $"<div>Before Result:{message}</div>");

        public override void OnResultExecuted(ResultExecutedContext context) => WriteMessage(context, $"<div>After Result:{message}</div>");

        private void WriteMessage(FilterContext context, string msg)
        {
            byte[] bytes = Encoding.ASCII.GetBytes($"<div>{msg}</div>");
            context.HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
        }
    }
}
