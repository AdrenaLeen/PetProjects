using WorkingWithVisualStudio.Models;
using Xunit;

namespace WorkingWithVisualStudio.Tests
{
    public class ProductTest
    {
        [Fact]
        public void CanChangeProductName()
        {
            // �����������
            Product p = new Product { Name = "����", Price = 100M };

            // ��������
            p.Name = "����� ������������";

            // �����������
            Assert.Equal("����� ������������", p.Name);
        }

        [Fact]
        public void CanChangeProductPrice()
        {
            // �����������
            Product p = new Product { Name = "����", Price = 100M };

            // ��������
            p.Price = 200M;

            // �����������
            Assert.Equal(200M, p.Price);
        }
    }
}
