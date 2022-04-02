using Microsoft.EntityFrameworkCore;

namespace ProductsApi.Entities
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString =
          "Server=(localdb)\\mssqllocaldb;Database=Products;Trusted_Connection=True;";
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);

        }
    }
}
