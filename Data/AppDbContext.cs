using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; } // Add this line!

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Ensure decimal precision for the Price column
    modelBuilder.Entity<Product>()
        .Property(p => p.Price)
        .HasColumnType("decimal(18,2)");

    // 1. Seed Categories
    modelBuilder.Entity<Category>().HasData(
        new Category { Id = 1, Name = "Electronics" },
        new Category { Id = 2, Name = "Furniture" },
        new Category { Id = 3, Name = "Accessories" }
    );

    // 2. Seed Products with specific prices
    modelBuilder.Entity<Product>().HasData(
        new Product { Id = 1, Name = "iPhone 15", Price = 50m, CategoryId = 1 },
        new Product { Id = 2, Name = "Gaming Laptop", Price = 1450.50m, CategoryId = 1 },
        new Product { Id = 3, Name = "Bluetooth Speaker", Price = 45.00m, CategoryId = 1 },
        new Product { Id = 4, Name = "Office Chair", Price = 299.00m, CategoryId = 2 },
        new Product { Id = 5, Name = "Standing Desk", Price = 450.75m, CategoryId = 2 },
        new Product { Id = 6, Name = "Coffee Table", Price = 120.00m, CategoryId = 2 },
        new Product { Id = 7, Name = "Leather Wallet", Price = 35.99m, CategoryId = 3 },
        new Product { Id = 8, Name = "Backpack", Price = 75.50m, CategoryId = 3 },
        new Product { Id = 9, Name = "Sunglasses", Price = 150.00m, CategoryId = 3 }
        // Add as many as you need here...
    );
}
}