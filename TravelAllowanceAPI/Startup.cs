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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAllowance.Data;
using TravelAllowance.Services.Interface;
using TravelAllowance.Services.Services;

namespace TravelAllowanceAPI
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TravelAllowanceAPI", Version = "v1" });
            });
            services.AddDbContext<TravelAllowanceDbContext>(opts => { opts.EnableDetailedErrors(); opts.UseSqlServer(Configuration.GetConnectionString("sqlConnection")); });
            services.AddHttpClient();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<ITravelAllowanceService, TravelAllowanceService>();
            services.AddTransient<ICsvService, CsvService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TravelAllowanceAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(builder => builder.WithOrigins(
               "http://localhost:8080",
               "http://localhost:8081")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials()
               );

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
