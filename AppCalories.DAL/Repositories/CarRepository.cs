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

        public bool Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> Select()
        {
           return await _webDbContext.Products.ToListAsync();
        }
    }
}
