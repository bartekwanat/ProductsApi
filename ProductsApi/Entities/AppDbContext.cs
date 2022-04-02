using Microsoft.EntityFrameworkCore;

namespace ProductsApi.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
      
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(100);

            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(200);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

        }
    }
}
