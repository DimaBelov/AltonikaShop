using System;
using AltonikaShop.Application.Services;
using AltonikaShop.Application.Services.Interfaces;
using CoreLib.Data;
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

            services
                .AddScoped<IGenericRepository>(provider => new GenericRepository(DB_CONNECTION_NAME))
                .AddScoped<IUserService, UserService>()
                .AddScoped<IProductService, ProductService>();

            services.AddSwagger();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            app.UseSwaggerWithUi(serviceProvider.GetService<Info>())
                .UseMetrics(configuration => configuration.MemStatInterval = TimeSpan.FromSeconds(5))
                .UseMvc();
        }
    }
}
