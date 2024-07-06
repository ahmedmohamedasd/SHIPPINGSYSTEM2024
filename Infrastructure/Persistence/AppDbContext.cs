using Application.Interface;
using Core.Entities;
using Infrastructure.Persistence.model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Constants.SystemConstants.AuthorizationConstants.Claims;

namespace Infrastructure.Persistence
{
    public class AppDbContext :IdentityDbContext<AppUser ,Role ,string> ,IAppDbContext
    {
        public DbSet<AppUser> AppUser { get; set; }

        public DbSet<Province> Province { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<BranchLevel> BranchLevels { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<ReceiverAddress> ReceiverAddress { get; set; }
        public DbSet<SenderAddress> SenderAddress { get; set; }
        public DbSet<Client> Clients { get; set; }
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

            builder.Entity<BranchLevel>()
         .HasOne(e => e.BranchSuper)
         .WithMany(e => e.BranchLevels)
         .HasForeignKey(e => e.SuperId)
         .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Order>()
            .Property(e => e.TotalFees)
            .HasComputedColumnSql("[DeliveryFees] + [AdditionalFees]");

            builder.Entity<Order>()
              .HasOne(e => e.RecieverCity)
              .WithMany()
              .HasForeignKey(e => e.RecieverCityId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Order>()
                .HasOne(e => e.SenderCity)
                .WithMany()
                .HasForeignKey(e => e.SenderCityId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<Order>()
                .HasOne(e => e.DeliveryBranchLevel)
                .WithMany()
                .HasForeignKey(e => e.DeliveryBRId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<Order>()
                .HasOne(e => e.SigningBranchLevel)
                .WithMany()
                .HasForeignKey(e => e.SigningBRId)
                .OnDelete(DeleteBehavior.Restrict);


        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

    }
}
