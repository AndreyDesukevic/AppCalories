using AppCalories.DAL.Interfaces;
using AppCalories.DAL.Repositories;
using AppCalories.Domain.EFStuff.Models;
using AppCalories.Service.Implementations;
using AppCalories.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AppCalories
{
    public static class StartupInit
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Product>, ProductRepository>();
        }
        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
