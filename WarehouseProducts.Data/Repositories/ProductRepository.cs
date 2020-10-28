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

        public ProductRepository()
        {
            Products = new List<Product>();
        }

        public void Create(Product model)
        {
            Products.Add(model);
        }

        public Product GetById(int id)
        {
            foreach(var p in Products)
            {
                if(p.Id == id)
                {
                    return p;
                }
            }
            throw new Exception("No product whith this Id");
        }
    }
}
