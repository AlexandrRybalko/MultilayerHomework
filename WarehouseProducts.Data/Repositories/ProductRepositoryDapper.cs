using Dapper;
using Products.Data.Interfaces;
using Products.Data.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Products.Data.Repositories
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
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                var sqlQuery = $"INSERT INTO Products(Name, DeliveryDate, Price) VALUES('{model.Name}'," 
                    + $"\'{model.DeliveryDate.ToString("s")}\', {model.Price});" 
                    + $"SELECT CAST(SCOPE_IDENTITY() AS INT)";

                int id = connection.Query<int>(sqlQuery, model).FirstOrDefault();
                model.Id = id;
            }

            return model;
        }

        public IEnumerable<Product> GetAll()
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return connection.Query<Product>("SELECT * FROM Products");
            }
        }

        public Product GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                
                return connection.QueryFirst<Product>($"SELECT * FROM Products WHERE Id={id}");
            }
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
