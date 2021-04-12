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
            // �����������
            ExampleController controller = new ExampleController();

            // ��������
            RedirectToActionResult result = controller.Redirect();

            // �����������
            Assert.False(result.Permanent);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void JsonActionMethod()
        {
            // �����������
            ExampleController controller = new ExampleController();

            // ��������
            JsonResult result = controller.GetJson();

            // �����������
            Assert.Equal(new[] { "����", "���", "���" }, result.Value);
        }

        [Fact]
        public void NotFoundActionMethod()
        {
            // �����������
            ExampleController controller = new ExampleController();

            // ��������
            StatusCodeResult result = controller.Index();

            // �����������
            Assert.Equal(404, result.StatusCode);
        }
    }
}
