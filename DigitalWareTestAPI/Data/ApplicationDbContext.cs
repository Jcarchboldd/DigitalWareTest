using DigitalWareTestAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalWareTestAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext() : base()
        {
        }

        public ApplicationDbContext(DbContextOptions options)
         : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Set EntityTypeConfiguration classes

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
           
        }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Order_Detail> Order_Details => Set<Order_Detail>();
    }
}
