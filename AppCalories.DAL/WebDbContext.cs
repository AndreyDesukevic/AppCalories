using AppCalories.Domain.EFStuff.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCalories.DAL
{
    public class WebDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public WebDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(x=>x.Proteins)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Product>()
                .Property(x => x.Carbohydrates)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Product>()
                .Property(x => x.Fats)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Product>()
                .Property(x => x.Calories)
                .HasColumnType("decimal(10,2)");
        }
    }
}
