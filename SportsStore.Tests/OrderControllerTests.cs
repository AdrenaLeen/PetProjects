using Microsoft.AspNetCore.Mvc;
using Moq;
using SportsStore.Controllers;
using SportsStore.Models;
using Xunit;

namespace SportsStore.Tests
{
    public class OrderControllerTests
    {
        [Fact]
        public void CannotCheckoutEmptyCart()
        {
            // Организация - создание имитированного хранилища заказов
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();

            // Организация - создание пустой корзины
            Cart cart = new Cart();

            // Организация - создание заказа
            Order order = new Order();

            // Организация - создание экземпляра котроллера
            OrderController target = new OrderController(mock.Object, cart);

            // Действие
            ViewResult result = target.Checkout(order) as ViewResult;

            // Утверждение - проверка, что заказ не был сохранён
            mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Never);

            // Утверждение - проверка, что метод возвращает стандартное представление
            Assert.True(string.IsNullOrEmpty(result.ViewName));

            // Утверждение - проверка, что представлению передана недопустимая модель
            Assert.False(result.ViewData.ModelState.IsValid);
        }

        [Fact]
        public void CannotCheckoutInvalidShippingDetails()
        {
            // Организация - создание имитированного хранилища
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();

            // Организация - создание корзины с одним элементом
            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);

            // Организация - создание экземпляра контроллера
            OrderController target = new OrderController(mock.Object, cart);

            // Организация - добавление ошибки в модель
            target.ModelState.AddModelError("error", "error");

            // Действие - попытка перехода к оплате
            ViewResult result = target.Checkout(new Order()) as ViewResult;

            // Утверждение - проверка, что заказ не был сохранён
            mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Never);

            // Утверждение - проверка, что метод возвращает стандартное представление
            Assert.True(string.IsNullOrEmpty(result.ViewName));

            // Утверждение - проверка, что представлению передаётся недопустимая модель
            Assert.False(result.ViewData.ModelState.IsValid);
        }

        [Fact]
        public void CanCheckoutAndSubmitOrder()
        {
            // Организация - создание имитированного хранилища заказов
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();

            // Организация - создание корзины с одним элементом
            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);

            // Организация - создание экземпляра контроллера
            OrderController target = new OrderController(mock.Object, cart);

            // Действие - попытка перехода к оплате
            RedirectToActionResult result = target.Checkout(new Order()) as RedirectToActionResult;

            // Утверждение - проверка, что заказ был сохранён
            mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Once);

            // Утверждение - проверка, что метод перенаправляется на действие Completed
            Assert.Equal("Completed", result.ActionName);
        }
    }
}
