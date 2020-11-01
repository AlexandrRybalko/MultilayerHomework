using Products.Data.Interfaces;
using Products.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseProducts.Data.Repositories
{
    public class ProductRepositoryDapper : IProductRepository
    {
        private readonly string _connectionString;
        private int Capacity;
        public ProductRepositoryDapper()
        {
            _connectionString = "Data Source=DESKTOP-CVLKMS0\\MSSQLSERVER01;Initial Catalog=test;Integrated Security=true";
            Capacity = 0;
        }
        public Product Create(Product model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool HasSpace()
        {
            if (Capacity == 10)
            {
                return false;
            }
            return true;
        }
    }
}
