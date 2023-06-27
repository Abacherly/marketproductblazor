using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MarketProductBlazor.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Offer>().HasData
            (
                new Offer { Id = 1, Name = "Sim" },
                new Offer { Id = 2, Name = "Não" }
            );

            modelBuilder.Entity<MarketProduct>().HasData(
              new MarketProduct
              {
                  Id = 1,
                  Name = "Maçã",
                  Description = "Fruta",
                  OfferId = 1
              },

             new MarketProduct
             {
                 Id = 2,
                 Name = "Batata",
                 Description = "Legume",
                 OfferId = 2
             }
             );

        }

        public DbSet<MarketProduct> MarketProducts { get; set; }
        public DbSet<Offer> Offers { get; set; }
    }
}        
        
        


