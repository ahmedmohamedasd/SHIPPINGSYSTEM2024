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
using Infrastructure.Services;
using Infrastructure.Persistence.model;
using static Application.Constants.SystemConstants;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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
            services.AddScoped<IRoleManagerService, RoleManagerService>();
            services.InjectIdentity(configuration);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder//.WithOrigins(Configuration["ApplicationSettings:Client_URL"].ToString())
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            return services;

        }

        private static IServiceCollection InjectIdentity(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services.AddIdentity<AppUser, Role>(option =>
            {
                option.Password.RequireDigit = false;
                option.Password.RequiredLength = 5;
                option.Password.RequireUppercase = false;

                option.Lockout.MaxFailedAccessAttempts = 10;
                option.Lockout.AllowedForNewUsers = true;

                option.SignIn.RequireConfirmedEmail = false;
                option.SignIn.RequireConfirmedPhoneNumber = false;

                option.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            services.AddIdentityCore<AppUser>();
            services.AddAuthorization(options =>
            {
                var claims = AuthorizationConstants.Claims.GetClaims().SelectMany(c => c.Value);
                foreach (var claimName in claims)
                {
                    options.AddPolicy(claimName, policy => policy.RequireClaim(ClaimTypes.Authentication, claimName));
                }

            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        // ValidAudience = configuration["JWTSetting:ValidAudience"],
                        // ValidIssuer = configuration["JWTSetting:ValidIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSetting:Secret"])),
                    };
                })
                ;

            return services;
        }
    }
}
