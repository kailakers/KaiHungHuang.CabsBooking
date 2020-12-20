using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaiHungHuang.CabsBooking.Core.Entity;
using KaiHungHuang.CabsBooking.Core.RepositoryInterface;
using KaiHungHuang.CabsBooking.Core.ServiceInterface;
using CabsBooking.Infrastructure.Data;
using CabsBooking.Infrastructure.Repositories;
using CabsBooking.Infrastructure.Services;
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

namespace KaiHungHuang.CabsBooking.API
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
            services.AddControllers().AddNewtonsoftJson(option=>
                option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "KaiHungHuang.CabsBooking.API", Version = "v1"});
            });
            // Add ConnectionString
            services.AddDbContext<CabsBookingDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CabsBookingDbConnection")));
            
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IAsyncRepository<BookingHistory>, EfRepository<BookingHistory>>();
            services.AddScoped<IBookingHistoryService, BookingHistoryService>();
            services.AddScoped<IAsyncRepository<CabType>, EfRepository<CabType>>();
            services.AddScoped<IAsyncRepository<Place>, EfRepository<Place>>();
            services.AddScoped<IPlaceService, PlaceService>();
            services.AddScoped<ICabTypeService, CabTypeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KaiHungHuang.CabsBooking.API v1"));
            }

            app.UseCors(builder =>
            {
                builder.WithOrigins(Configuration.GetValue<string>("clientSPAUrl"))
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}