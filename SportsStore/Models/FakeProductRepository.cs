using System.Collections.Generic;

namespace SportsStore.Models
{
    public class FakeProductRepository
    {
        public IEnumerable<Product> Products => new List<Product> {
            new Product { Name = "Футбольный мяч", Price = 25 },
            new Product { Name = "Доска для сёрфа", Price = 179 },
            new Product { Name = "Беговые кроссовки", Price = 95 }
        };
    }
}
