using System;
using System.Collections.Generic;
using AutoMapper;
using Products.Domain.Models;
using Products.Domain.Services;
using Products.Models.PostModels;
using Products.Models.ViewModels;

namespace Products
{
    public class ProductController
    {
        private readonly ProductService _productService;
        private readonly IMapper _mapper;
        public ProductController()
        {
            _productService = new ProductService();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateProductPostModel, ProductModel>();
                cfg.CreateMap<GetProductViewModel, ProductModel>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
        }

        public GetProductViewModel CreateProductRequest(CreateProductPostModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                throw new Exception("Invalid Name");
            }
            if(model.Price <= 0)
            {
                throw new Exception("Invalid price");
            }

            var productModel = _mapper.Map<ProductModel>(model);
            var createdProductModel = _productService.CreateProductRequest(productModel);
            var result = _mapper.Map<GetProductViewModel>(createdProductModel);

            return result;
        }

        public GetProductViewModel GetProductById(int id)
        {
            if(id <= 0)
            {
                throw new Exception("Invalid id");
            }

            var product = _productService.GetProductByIdRequest(id);
            var result = _mapper.Map<GetProductViewModel>(product);
            return result;
        }

        public IEnumerable<GetProductViewModel> GetAllProducts()
        {
            var allProducts = _productService.GetAllProductsRequest();
            var result = _mapper.Map<IEnumerable<GetProductViewModel>>(allProducts);

            return result;
        }
    }
}
