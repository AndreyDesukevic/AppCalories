using AppCalories.DAL.Interfaces;
using AppCalories.Domain.EFStuff.Models;
using AppCalories.Domain.Enum;
using AppCalories.Domain.Response;
using AppCalories.Domain.ViewModels.Product;
using AppCalories.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AppCalories.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IBaseRepository<Product> _productRepository;

        public ProductService(IBaseRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IBaseResponse<Product>> GetProduct(int id)
        {
            var baseResponse = new BaseResponse<Product>();
            try
            {
                var product = await _productRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (product == null)
                {
                    baseResponse.Description = "Product not found";
                    baseResponse.StatusCode = StatusCode.ProductNotFound;
                    return baseResponse;
                }
                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Data = product;
                return baseResponse;
            }
            catch (Exception ex)

            {
                return new BaseResponse<Product>()
                {
                    Description = $"[GetProducts]:{ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };

            }
        }
        public async Task<IBaseResponse<Product>> GetProductByName(string name)
        {
            var baseResponse = new BaseResponse<Product>();
            try
            {
                var product = await _productRepository.GetAll().FirstOrDefaultAsync(x => x.Name == name);
                if (product == null)
                {
                    baseResponse.Description = "Product not found";
                    baseResponse.StatusCode = StatusCode.ProductNotFound;
                    return baseResponse;
                }
                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Data = product;
                return baseResponse;
            }
            catch (Exception ex)

            {
                return new BaseResponse<Product>()
                {
                    Description = $"[GetProducts]:{ex.Message}",
                     StatusCode = StatusCode.InternalServerError
                };

            }
        }
        public async Task<IBaseResponse<IEnumerable<Product>>> GetProducts()
        {
            var baseResponse = new BaseResponse<IEnumerable<Product>>();

            try
            {
                var products = _productRepository.GetAll();
                if (!products.Any())
                {
                    baseResponse.Description = "Found 0 items";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = products;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Product>>()
                {
                    Description = $"[GetProducts]:{ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };

            }
        }
        public async Task<IBaseResponse<bool>> DeleteProduct(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var product = await _productRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (product==null)
                {
                    baseResponse.Description = "Product not found";
                    baseResponse.StatusCode = StatusCode.ProductNotFound;
                    return baseResponse;
                }
                await _productRepository.Delete(product);
                
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteProduct]:{ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                   
                };
            }
        }
        public async Task<IBaseResponse<ProductViewModel>> CreateProduct(ProductViewModel productViewModel, byte[] imageData)
        {
            var baseResponse = new BaseResponse<ProductViewModel>();
            try
            {
                var product = new Product()
                {
                    Name = productViewModel.Name,
                    Calories = productViewModel.Calories,
                    Proteins = productViewModel.Proteins,
                    Carbohydrates = productViewModel.Carbohydrates,
                    Fats = productViewModel.Fats,
                    Picture = imageData
                };

                await _productRepository.Create(product);
              
            }
            catch (Exception ex)
            {
                return new BaseResponse<ProductViewModel>()
                {
                    Description = $"[CreateProduct]:{ex.Message}",
                    StatusCode = StatusCode.InternalServerError

                };
            }
            return baseResponse;
        }
        public async Task<IBaseResponse<Product>> Edit(int id, ProductViewModel productViewModel)
        {
            var baseResponse = new BaseResponse<Product>();
            try
            {
                var product = await _productRepository.GetAll().FirstOrDefaultAsync(x=>x.Id==id);
                if (product == null)
                {
                    baseResponse.StatusCode = StatusCode.ProductNotFound;
                    baseResponse.Description = "Car not found";
                    return baseResponse;
                }
                product.Name = productViewModel.Name;
                product.Carbohydrates = productViewModel.Carbohydrates;
                product.Fats = productViewModel.Fats;
                product.Calories = productViewModel.Calories;
                product.Proteins = productViewModel.Proteins;

                await _productRepository.Update(product);

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Product>()
                {
                    Description = $"[Edit]:{ex.Message}",
                    StatusCode = StatusCode.InternalServerError

                };
            }
        }
    }
}
