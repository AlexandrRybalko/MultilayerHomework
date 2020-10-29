using System;
using AutoMapper;
using Products.Domain.Models;
using Products.Domain.Services;
using Products.Models.PostModels;
using WarehouseProducts.Models.ViewModels;

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
                cfg.CreateMap<CreateProductPostModel, ProductModel>().ReverseMap();

                cfg.CreateMap<GetProductViewModel, ProductModel>();
                cfg.CreateMap<GetProductViewModel, ProductModel>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
        }

        public void CreateProductRequest(CreateProductPostModel model)
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

            _productService.CreateProductRequest(productModel);
        }

        public GetProductViewModel GetProductById(int id)
        {
            if(id <= 0)
            {
                throw new Exception("Invalid id");
            }

            var result = _mapper.Map<GetProductViewModel>(_productService.GetProductByIdRequest(id));
            return result;
        }
    }
}
