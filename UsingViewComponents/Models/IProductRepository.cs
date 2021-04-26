using System.Collections.Generic;

namespace UsingViewComponents.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        void AddProduct(Product newProduct);
    }
}
