using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MySqlConnector;
using Repository;
using Service;

namespace contractor
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
            //ADD TRANSIENT AND IDBCONNECTION
            services.AddScoped<IDbConnection>(x => CreateDbConnection());

            services.AddTransient<JobsService>();
            services.AddTransient<JobsRepo>();
            services.AddTransient<ContractorsService>();
            services.AddTransient<ContractorRepo>();
            services.AddTransient<ContractorJobsService>();
            services.AddTransient<ContractorJobsRepo>();


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "contractor", Version = "v1" });
            });
        }
        //ADD THIS TOP
        private IDbConnection CreateDbConnection()
        {
            var connectionString = Configuration["db:gearhost"];
            return new MySqlConnection(connectionString);
        }

        //BOTTOM

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "contractor v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //USE AUTHENTICATION TO ADD AUTH

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
