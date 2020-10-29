﻿using AutoMapper;
using Products.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService()
        {
            _productRepository = new ProductRepository();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductModel, Product>();
                cfg.CreateMap<ProductModel, Product>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
        }
        public void CreateProductRequest(ProductModel model)
        {

            var product = _mapper.Map<Product>(model);
            _productRepository.Create(product);
        }

        public ProductModel GetProductByIdRequest(int id)
        {
            var result = _mapper.Map<ProductModel>(_productRepository.GetById(id));

            return result;
        }
    }
}
