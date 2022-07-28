using CORE;
using Microsoft.EntityFrameworkCore;
using REPOSITORY.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY
{
    public class AddDbContext : DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> options) :base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // toplu eklemek için
            //modelBuilder.ApplyConfiguration(new ProductConfiguration()); // tek tek eklemek için

            
            modelBuilder.Entity<ProductFeature>().HasData(
                new ProductFeature() {Id = 1 , Color="Kırmızı" , Height =100 , Width = 200 , ProductId = 1 },
                new ProductFeature() { Id = 2, Color = "Mavi", Height = 300, Width = 100, ProductId = 2 });
            base.OnModelCreating(modelBuilder); 
        }

    }
}
