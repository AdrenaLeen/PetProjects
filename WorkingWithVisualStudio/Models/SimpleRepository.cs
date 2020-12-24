using System.Collections.Generic;

namespace WorkingWithVisualStudio.Models
{
    public class SimpleRepository : IRepository
    {
        private readonly Dictionary<string, Product> products = new Dictionary<string, Product>();

        public static SimpleRepository SharedRepository { get; } = new SimpleRepository();

        public SimpleRepository()
        {
            Product[] initialItems = new[] {
                new Product { Name = "Каяк", Price = 275M },
                new Product { Name = "Спасательный жилет", Price = 48.95M },
                new Product { Name = "Футбольный мяч", Price = 19.5M },
                new Product { Name = "Флаг, отмечающий угол поля", Price = 34.95M }
            };
            foreach (Product p in initialItems) AddProduct(p);
        }

        public IEnumerable<Product> Products => products.Values;

        public void AddProduct(Product p) => products.Add(p.Name, p);
    }
}
