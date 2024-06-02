using Application.Interface;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

//using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services , IConfiguration configuration) 
        {
            services.AddDbContext<AppDbContext>(

                options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), o =>
                    {
                        o.EnableRetryOnFailure();
                        o.CommandTimeout(30);
                    });
                    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

                });
            services.AddScoped<IAppDbContext, AppDbContext>();

            //services.InjectIdentity()

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder//.WithOrigins(Configuration["ApplicationSettings:Client_URL"].ToString())
            //        .AllowAnyOrigin()
            //        .AllowAnyMethod()
            //        .AllowAnyHeader());
            //});

            return services;

        }
    }
}
