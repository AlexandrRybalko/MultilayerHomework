using Products;
using Products.Models.PostModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultilayerHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new ProductController();

            var model = new CreateProductPostModel()
            {
                Name = "Brick",
                DeliveryDate = DateTime.Now,
                Price = 1200
            };

            var product = controller.GetProductById(3);
        }
    }
}
