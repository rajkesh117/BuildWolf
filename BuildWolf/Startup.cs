using BuildWolf.BAT.Interfaces;
using BuildWolf.BAT.Services;
using BuildWolf.DAT.DBContext;
using BuildWolf.DAT.RepoInterfaces;
using BuildWolf.DAT.RepoServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BuildWolf
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
            services.AddSingleton<DapperDBContext>();
            services.AddScoped<IMasterDataService, MasterDataService>();
            //var _connectionString = "Server=localhost;uid=root;pwd=Info@123;Database=buildwolf;"; //jdbc: mysql://localhost:3306/?user=root
            //services.AddTransient(x =>new SqlConnection(Configuration.GetConnectionString(_connectionString)));

            services.AddScoped<IMasterService, MasterService>();
            services.AddScoped<IUserDataService, UserDataService>();
            services.AddScoped<IServiceProviderSurveyData, ServiceProviderSurveyData>();
            services.AddScoped<IUserLocationData, UserLocationData>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISearchedUserPage, SearchedUserPage>();
            //services.Configure(options => services.);
            services.AddControllers();
            services.AddSwaggerGen();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularDev",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200") // Change this to your Angular app URL
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // This middleware serves generated Swagger document as a JSON endpoint
            app.UseSwagger();

            // This middleware serves the Swagger documentation UI
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowAngularDev");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
