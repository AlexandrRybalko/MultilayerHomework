﻿using System;

namespace Products.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Price { get; set; }
    }
}
