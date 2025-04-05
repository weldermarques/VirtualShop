using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Category
            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Category>()
                .HasMany(g => g.Products)
                .WithOne(c => c.Category)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Clothes"
                },
                new Category
                {
                    Id = 2,
                    Name = "Accessories"
                });

            //Product
            modelBuilder.Entity<Product>()
                .Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(c => c.Description)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(c => c.ImageUrl)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(c => c.Price)
                .HasPrecision(12, 2);
        }
    }
}
