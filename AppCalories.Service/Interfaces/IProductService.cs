using AppCalories.Domain.EFStuff.Models;
using AppCalories.Domain.Response;
using AppCalories.Domain.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCalories.Service.Interfaces
{
    public interface IProductService
    {
        Task<IBaseResponse<IEnumerable<Product>>> GetProducts();
        Task<IBaseResponse<Product>> GetProduct(int id);
        Task<IBaseResponse<Product>> GetProductByName(string name);
        Task<IBaseResponse<bool>> DeleteProduct(int id);
        Task<IBaseResponse<ProductViewModel>> CreateProduct(ProductViewModel productViewModel);


    }
}
