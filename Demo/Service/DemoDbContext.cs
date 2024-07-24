using Microsoft.EntityFrameworkCore;
using Demo.Model;

namespace Demo.Service;

public class DemoDbContext:DbContext{

    public DemoDbContext(DbContextOptions<DemoDbContext> options) 
            : base(options) { }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Maillist> Maillists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "William",
                Description = "Shakespeare",
                IsRelease = true,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            },
            new Product
            {
                Id = 2,
                Name = "Apple",
                Description = "Royal Gala",
                IsRelease = true,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            },
            new Product
            {
                Id = 3,
                Name = "Orange",
                Description = "Australian",
                IsRelease = true,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            },
            new Product
            {
                Id = 4,
                Name = "Banana",
                Description = "Philippine",
                IsRelease = true,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            }
        );
    }
}