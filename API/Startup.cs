using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Repository;
using Repository.Context;
using Repository.Interfaces;
using Services;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ExampleAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddMvc().AddXmlSerializerFormatters(); //To accept xml answer

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            #region Context
            services.AddDbContext<ProductContext>(option =>
            {
#if DEBUG
                option.UseInMemoryDatabase("InMemoryDb");
#else
                option.UseSqlServer(Configuration.GetConnectionString("db"));
#endif
            });
            #endregion

            #region DI
            #region Services
            services.AddScoped<IFileService, FileService>();

            #endregion

            #region Repositories
            services.AddScoped<IProductRepository, ProductRepository>();

            #endregion
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env, 
            ProductContext productContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExampleAPI v1"));
            }

            productContext.Database.EnsureCreated();//Codefirst

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
