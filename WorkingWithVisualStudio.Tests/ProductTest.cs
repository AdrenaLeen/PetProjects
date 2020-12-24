using WorkingWithVisualStudio.Models;
using Xunit;

namespace WorkingWithVisualStudio.Tests
{
    public class ProductTest
    {
        [Fact]
        public void CanChangeProductName()
        {
            // Организация
            Product p = new Product { Name = "Тест", Price = 100M };

            // Действие
            p.Name = "Новое наименование";

            // Утверждение
            Assert.Equal("Новое наименование", p.Name);
        }

        [Fact]
        public void CanChangeProductPrice()
        {
            // Организация
            Product p = new Product { Name = "Тест", Price = 100M };

            // Действие
            p.Price = 200M;

            // Утверждение
            Assert.Equal(200M, p.Price);
        }
    }
}
