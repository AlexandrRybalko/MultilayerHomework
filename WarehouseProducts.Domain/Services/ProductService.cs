using AutoMapper;
using Products.Data.Interfaces;
using Products.Data.Models;
using Products.Data.Repositories;
using Products.Domain.Models;
using System;
using System.Collections.Generic;

namespace Products.Domain.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService()
        {
            _productRepository = new ProductRepositoryDapper();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductModel, Product>();
                cfg.CreateMap<ProductModel, Product>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
        }
        public ProductModel CreateProductRequest(ProductModel model)
        {
            if(!_productRepository.HasSpace())
            {
                throw new Exception("Max capacity reached");
            }

            var product = _mapper.Map<Product>(model);
            var createdProduct = _productRepository.Create(product);
            var result = _mapper.Map<ProductModel>(createdProduct);

            return result;
        }

        public ProductModel GetProductByIdRequest(int id)
        {
            var result = _mapper.Map<ProductModel>(_productRepository.GetById(id));

            return result;
        }

        public IEnumerable<ProductModel> GetAllProductsRequest()
        {
            var result = _mapper.Map<IEnumerable<ProductModel>>(_productRepository.GetAll());

            return result;
        }
    }
}
