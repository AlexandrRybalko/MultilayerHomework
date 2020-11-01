using Products.Data.Models;
using System.Collections.Generic;

namespace Products.Data.Interfaces
{
    public interface IProductRepository
    {
        Product Create(Product model);
        Product GetById(int id);
        IEnumerable<Product> GetAll();
        bool HasSpace();
    }
}
