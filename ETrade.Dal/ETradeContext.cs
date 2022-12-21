using ETrade.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dal
{
    public class ETradeContext : DbContext
    {
        public ETradeContext(DbContextOptions<ETradeContext> db) : base(db)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Composite Key
            modelBuilder.Entity<BasketDetail>()
                .HasKey(basket => new { basket.Id, basket.ProductId });

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vat> Vat { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BasketDetail> BasketDetail { get; set; }
        public DbSet<BasketMaster> BasketMaster { get; set; }

    }
}
