using AltonikaShop.Domain.Entities;
using CoreLib.Data;
using Microsoft.EntityFrameworkCore;

namespace AltonikaShop.Application
{
    public class AppDbContext : DbContext
    {
        const string WEBAPI_ASSEMBLY_NAME = "AltonikaShop.WebApi";

        readonly DataConnection _connection;

        public AppDbContext(DataConnection connection)
        {
            _connection = connection;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connection.ConnectionString, b => b.MigrationsAssembly(WEBAPI_ASSEMBLY_NAME));
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
