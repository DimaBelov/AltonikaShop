using System;
using System.Collections.Generic;
using System.Linq;
using AltonikaShop.Application;
using AltonikaShop.Application.Services;
using AltonikaShop.Application.Services.Interfaces;
using AltonikaShop.Domain.Entities;
using CoreLib.Data;
using CoreLib.Data.Entity;
using CoreLib.Web.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace AltonikaShop.WebApi
{
    public class Startup
    {
        const string DB_CONNECTION_NAME = "Default";
        const string ALLOWED_ORIGINS_CONFIG_NAME = "AllowedOrigins";
        
        public Startup(IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables()
                .AddHostingEnvironment(env)
                .Build();

            loggerFactory.Default(Configuration);
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            ConnectionManager.Register(Configuration);

            services.AddMvc(options => options.AddExceptionFilter());

            //services
            //    .AddScoped<IGenericRepository>(provider => new GenericRepository(DB_CONNECTION_NAME))
            //    .AddScoped<IUserService, UserService>()
            //    .AddScoped<IProductService, ProductService>()
            //    .AddScoped<IOrderService, OrderService>();

            var defaultConnection = Configuration.GetSection("DataConnections").Get<List<DataConnection>>().First();
            services

                .AddSingleton<EfDbContext>(provider => new AppDbContext(defaultConnection))

                .AddScoped<IEntityRepository<User>, EntityRepository<User>>()
                .AddScoped<IUserService, UserService>()

                .AddScoped<IEntityRepository<Product>, EntityRepository<Product>>()
                .AddScoped<IProductService, ProductService>()

                .AddScoped<IEntityRepository<Order>, EntityRepository<Order>>()
                .AddScoped<IOrderService, OrderService>()
                ;

            services.AddSwagger();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            app.UseCors(builder =>
                builder
                    .WithOrigins(Configuration.GetSection(ALLOWED_ORIGINS_CONFIG_NAME).Get<IEnumerable<string>>().ToArray())
                    .AllowAnyHeader()
                    .AllowAnyMethod());

            app.UseSwaggerWithUi(serviceProvider.GetService<Info>())
                .UseMetrics(configuration => configuration.MemStatInterval = TimeSpan.FromSeconds(5))
                .UseMvc();
        }
    }
}
