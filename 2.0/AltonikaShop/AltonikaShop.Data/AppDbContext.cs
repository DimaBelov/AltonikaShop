using AltonikaShop.Domain.Entities;
using CoreLib.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace AltonikaShop.Data
{
    public class AppDbContext : DbContext
    {
        const string WEBAPI_ASSEMBLY_NAME = "AltonikaShop.Web";

        readonly DataConnection _connection;

        public AppDbContext(DataConnection connection)
        {
            _connection = connection;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql(_connection.ConnectionString, b => b.MigrationsAssembly(WEBAPI_ASSEMBLY_NAME))
                .ConfigureWarnings(warnings => warnings.Throw(CoreEventId.IncludeIgnoredWarning));
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<OrderDetail>(entity =>
        //    {
        //        entity.Ignore(e => e.Product);
        //    });
        //}

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
