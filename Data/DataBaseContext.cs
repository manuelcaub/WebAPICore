namespace WebAPICore.Data
{
    using Microsoft.EntityFrameworkCore;
    
    public class DataBaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=MyDatabase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>().HasOne<Product>(sale => sale.Product);
            modelBuilder.Entity<Purchase>().HasOne<Product>(purchase => purchase.Product);
            modelBuilder.Entity<Product>().HasOne<ProductType>(product => product.Type);
        }
    }
}
