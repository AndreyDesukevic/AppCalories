using AppCalories.DAL.Interfaces;
using AppCalories.Domain.EFStuff.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCalories.DAL.Repositories
{
    public class ProductRepository : IBaseRepository<Product>
    {
        private readonly WebDbContext _webDbContext;

        public ProductRepository(WebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
        }

        public async Task Create(Product entity)
        {
            await _webDbContext.Products.AddAsync(entity);
            await _webDbContext.SaveChangesAsync();
        }

        public async Task Delete(Product entity)
        { 
            _webDbContext.Products.Remove(entity);
            await _webDbContext.SaveChangesAsync();
        }

        public IQueryable<Product> GetAll()
        {
            return _webDbContext.Products;
        }

        public async Task<Product> Update(Product entity)
        {
            _webDbContext.Products.Update(entity);
            await _webDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
