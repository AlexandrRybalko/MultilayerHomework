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
        private int Capacity;
        public ProductRepository()
        {
            Products = new List<Product>();
            _idCount = 1;
            Capacity = 0;
        }
        public bool HasSpace()
        {
            if(Capacity == 10)
            {
                return false;
            }
            return true;
        }

        public void Create(Product model)
        {
            model.Id = _idCount;
            Products.Add(model);
            _idCount++;
            Capacity++;
        }

        public Product GetById(int id)
        {
            var result = Products.FirstOrDefault(x => x.Id == id);
            return result;
        }
    }
}
