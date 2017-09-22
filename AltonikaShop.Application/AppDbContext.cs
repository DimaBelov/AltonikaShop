﻿using AltonikaShop.Domain.Entities;
using CoreLib.Data;
using CoreLib.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace AltonikaShop.Application
{
    public class AppDbContext : EfDbContext
    {
        const string WEBAPI_ASSEMBLY_NAME = "AltonikaShop.WebApi";

        readonly DataConnection _connection;

        public AppDbContext(DataConnection connection) : base(connection)
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
