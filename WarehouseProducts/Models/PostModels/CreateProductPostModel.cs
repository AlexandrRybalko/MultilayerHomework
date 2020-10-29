using System;

namespace Products.Models.PostModels
{
    public class CreateProductPostModel
    {
        public string Name { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Price { get; set; }
    }
}
