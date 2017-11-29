using System;
using System.Collections.Generic;
using System.Linq;
using AltonikaShop.Data;
using AltonikaShop.Data.Repositories;
using AltonikaShop.Data.Repositories.Interfaces;
using AltonikaShop.Domain.Entities;
using CoreLib.Data;
using CoreLib.Web.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace AltonikaShop.Web
{
    public class Startup
    {
        const string DATA_CONNECTIONS_SECTION_MAME = "DataConnections";
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

            services.AddMvc()
                .AddExceptionFilter();

            var connection = Configuration.GetSection(DATA_CONNECTIONS_SECTION_MAME)
                .Get<List<DataConnection>>().First();

           //const string webapiAssemblyName = "AltonikaShop.Web";

            services
                
                .AddSingleton(connection)
                .AddDbContext<AppDbContext>()

                .AddSingleton<DbContext>(new AppDbContext(connection))
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IOrderRepository, OrderRepository>();

            services.AddSwagger();

#if DEBUG
            Test(services);
#endif
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

        void Test(IServiceCollection services)
        {
            services
                .AddScoped<IGenericRepository>(p => new GenericRepository(ConnectionManager.Get("Draft")))
                .AddScoped<TestService>();
            var provider = services.GetProvider();
            var testService = provider.GetService<TestService>();
            var logger = provider.GetService<ILogger<TestService>>();
            var products = testService.ProductGetAll().ToList();
            products.ForEach(p => logger.LogInformation($"Product: {p.Id} {p.Name}"));
            testService.Update(new[] { new Product { Name = "gfhdf" }, new Product { Name = "cbvngh" }, new Product { Name = "fhdfh" } });
            products = testService.ProductGetAll().ToList();
            products.ForEach(p => logger.LogInformation($"Product: {p.Id} {p.Name}"));
        }
    }
}
