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
    public class ProductRepository : IProductRepository
    {
        private readonly WebDbContext _webDbContext;

        public ProductRepository(WebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
        }

        public async Task<bool> Create(Product entity)
        {
            await _webDbContext.Products.AddAsync(entity);
            await _webDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Product entity)
        { 
            _webDbContext.Products.Remove(entity);
            await _webDbContext.SaveChangesAsync();
            return true;
        }
        
        public async Task<Product> Get(int id) => await _webDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        

        public async Task <Product> GetByName(string name)=>await _webDbContext.Products.FirstOrDefaultAsync(x => x.Name == name);


        public async Task<List<Product>> Select()
        {
           return await _webDbContext.Products.ToListAsync();
        }
    }
}
