using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseProducts.Domain.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Price { get; set; }
    }
}
