using AppCalories.DAL.Interfaces;
using AppCalories.Domain.EFStuff.Models;
using AppCalories.Domain.Enum;
using AppCalories.Domain.Response;
using AppCalories.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCalories.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IBaseResponse<IEnumerable<Product>>> GetProducts()
        {
           var baseResponse= new BaseResponse<IEnumerable<Product>>();

            try
            {
                var products = await _productRepository.Select();
                if(products.Count()==0)
                {
                    baseResponse.Description = "Found 0 items";
                    baseResponse.StatusCode=StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = products;
                baseResponse.StatusCode= StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Product>>()
                {
                    Description =$"[GetProducts]:{ex.Message}"
                };
               
            }
        }
    }
}
