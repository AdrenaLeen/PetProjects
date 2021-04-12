using System;
using Xunit;
using ControllersAndActions.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ControllersAndActions.Tests
{
    public class ActionTests
    {
        [Fact]
        public void Redirection()
        {
            // Организация
            ExampleController controller = new ExampleController();

            // Действие
            RedirectToActionResult result = controller.Redirect();

            // Утверждение
            Assert.False(result.Permanent);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void JsonActionMethod()
        {
            // Организация
            ExampleController controller = new ExampleController();

            // Действие
            JsonResult result = controller.GetJson();

            // Утверждение
            Assert.Equal(new[] { "Элис", "Боб", "Джо" }, result.Value);
        }

        [Fact]
        public void NotFoundActionMethod()
        {
            // Организация
            ExampleController controller = new ExampleController();

            // Действие
            StatusCodeResult result = controller.Index();

            // Утверждение
            Assert.Equal(404, result.StatusCode);
        }
    }
}
