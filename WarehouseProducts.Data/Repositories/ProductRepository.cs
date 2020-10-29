using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products.Domain.Models;

namespace Products.Domain
{
    public class ProductRepository
    {
        private List<Product> Products { get; set; }
        private int _idCount;

        public ProductRepository()
        {
            Products = new List<Product>();
            _idCount = 1;
        }

        public void Create(Product model)
        {
            model.Id = _idCount;
            Products.Add(model);
            _idCount++;
        }

        public Product GetById(int id)
        {
            var result = Products.FirstOrDefault(x => x.Id == id);
            return result;
        }
    }
}
