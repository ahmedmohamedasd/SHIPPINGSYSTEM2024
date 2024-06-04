using Application.Interface;
using Core.Entities;
using Infrastructure.Persistence.model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class AppDbContext :IdentityDbContext<AppUser ,Role ,string> ,IAppDbContext
    {
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Employee>  Employees { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.Properties<string>()
                //.AreUnicode(false)
                //.AreFixedLength()
                .HaveMaxLength(500);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>().ToTable("Users", "Security").Property(e => e.Id).HasColumnName("UserId");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "Security").HasKey(s => new { s.RoleId, s.UserId });
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "Security").HasKey(t => new { t.LoginProvider, t.UserId, t.Name, t.Value });
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "Security").HasKey(r => r.Id);
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "Security").HasKey(r => r.Id);
            builder.Entity<Role>().ToTable("Roles", "Security").Property(e => e.Id).HasColumnName("RoleId"); ;
            builder.Ignore<IdentityUserLogin<string>>();

            //builder.Entity<RoleClaims>().HasKey(i => new { i.ClaimID, i.RoleID });
            //builder.Entity<UserRoles>().HasKey(i =>new { i.RoleID, i.UserID });



        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

    }
}
