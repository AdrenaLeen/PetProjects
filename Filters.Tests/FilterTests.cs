using Filters.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Moq;
using System.Linq;
using Xunit;

namespace Filters.Tests
{
    public class FilterTests
    {
        [Fact]
        public void TestHttpsFilter()
        {
            // Организация
            Mock<HttpRequest> httpRequest = new Mock<HttpRequest>();
            httpRequest.SetupSequence(m => m.IsHttps).Returns(true).Returns(false);
            Mock<HttpContext> httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(m => m.Request).Returns(httpRequest.Object);
            ActionContext actionContext = new ActionContext(httpContext.Object, new RouteData(), new ActionDescriptor());
            AuthorizationFilterContext authContext = new AuthorizationFilterContext(actionContext, Enumerable.Empty<IFilterMetadata>().ToList());
            HttpsOnlyAttribute filter = new HttpsOnlyAttribute();

            // Действие и утверждение.
            filter.OnAuthorization(authContext);
            Assert.Null(authContext.Result);
            filter.OnAuthorization(authContext);
            Assert.IsType<StatusCodeResult>(authContext.Result);
            Assert.Equal(StatusCodes.Status403Forbidden, (authContext.Result as StatusCodeResult).StatusCode);
        }
    }
}
