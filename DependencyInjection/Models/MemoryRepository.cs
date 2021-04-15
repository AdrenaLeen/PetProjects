using System;
using System.Collections.Generic;

namespace DependencyInjection.Models
{
    public class MemoryRepository : IRepository
    {
        readonly IModelStorage storage;
        readonly string guid = Guid.NewGuid().ToString();

        public MemoryRepository(IModelStorage modelStorage)
        {
            storage = modelStorage;
            new List<Product> {
                new Product { Name = "Каяк", Price = 275M },
                new Product { Name = "Спасательный жилет", Price = 48.95M },
                new Product { Name = "Футбольный мяч", Price = 19.5M }
            }.ForEach(p => AddProduct(p));
        }

        public IEnumerable<Product> Products => storage.Items;

        public Product this[string name] => storage[name];

        public void AddProduct(Product product) => storage[product.Name] = product;

        public void DeleteProduct(Product product) => storage.RemoveItem(product.Name);

        public override string ToString() => guid;
    }
}
