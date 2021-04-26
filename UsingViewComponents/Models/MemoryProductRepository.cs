using System.Collections.Generic;

namespace UsingViewComponents.Models
{
    public class MemoryProductRepository : IProductRepository
    {
        List<Product> products = new List<Product>
        {
            new Product { Name = "Каяк", Price = 275M },
            new Product { Name = "Спасательный жилет", Price = 48.95M },
            new Product { Name = "Футбольный мяч", Price = 19.5M }
        };

        public IEnumerable<Product> Products => products;

        public void AddProduct(Product newProduct) => products.Add(newProduct);
    }
}
