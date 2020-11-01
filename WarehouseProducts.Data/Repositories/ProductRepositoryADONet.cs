using Products.Data.Interfaces;
using Products.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Products.Data.Repositories
{
    public class ProductRepositoryADONet : IProductRepository
    {
        private readonly string _connectionString;
        private int Capacity;
        public ProductRepositoryADONet()
        {
            _connectionString = "Data Source=DESKTOP-CVLKMS0\\MSSQLSERVER01;Initial Catalog=test;Integrated Security=true";
            Capacity = 0;
        }

        public bool HasSpace()
        {
            if (Capacity == 10)
            {
                return false;
            }
            return true;
        }
        public Product Create(Product model)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = $"INSERT INTO Products(Name, DeliveryDate, Price) OUTPUT Inserted.Id VALUES('{model.Name}', \'{model.DeliveryDate.ToString("s")}\', {model.Price})";

                var id = command.ExecuteScalar();
                model.Id = (int)id;

                return model;
            }
        }

        public IEnumerable<Product> GetAll()
        {
            var result = new List<Product>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = $"SELECT * FROM Products";

                SqlDataReader reader = command.ExecuteReader();
                Product product = new Product();

                while (reader.Read())
                {
                    product.Id = product.Id = reader.GetInt32(0);
                    product.Name = reader.GetString(1);
                    product.DeliveryDate = (DateTime)reader["DeliveryDate"];
                    product.Price = reader.GetInt32(3);
                    result.Add(product);
                }
            }

            return result;
        }

        public Product GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = $"SELECT * FROM Products WHERE Id={id}";

                SqlDataReader reader = command.ExecuteReader();
                Product result = new Product();
                reader.Read();

                result.Id = reader.GetInt32(0);
                result.Name = reader.GetString(1);
                result.DeliveryDate = (DateTime)reader["DeliveryDate"];
                result.Price = reader.GetInt32(3);

                return result;
            }
        }
    }
}
