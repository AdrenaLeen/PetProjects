using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConventionsAndConstraints.Infrastructure
{
    public class UserAgentAttribute : Attribute, IActionConstraintFactory
    {
        readonly string substring;

        public UserAgentAttribute(string sub) => substring = sub.ToLower();

        public IActionConstraint CreateInstance(IServiceProvider services) => new UserAgentConstraint(services.GetService<UserAgentComparer>(), substring);

        public bool IsReusable => false;

        class UserAgentConstraint : IActionConstraint
        {
            readonly UserAgentComparer comparer;
            readonly string substring;

            public UserAgentConstraint(UserAgentComparer comp, string sub)
            {
                comparer = comp;
                substring = sub;
            }

            public int Order { get; set; } = 0;

            public bool Accept(ActionConstraintContext context) => comparer.ContainsString(context.RouteContext.HttpContext.Request, substring) || context.Candidates.Count == 1;
        }
    }
}
