using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using VendingMachine.Domain;

namespace VendingMachine.DataAccess
{
    public class VendingMachineDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }

        public VendingMachineDbContext(DbContextOptions<VendingMachineDbContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .Property(p => p.Id)
            .ValueGeneratedNever();
        }
    }
}
