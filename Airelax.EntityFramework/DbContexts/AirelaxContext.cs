using System;
using System.Linq.Expressions;
using System.Xml.Schema;
using Airelax.Domain.Comments;
using Airelax.Domain.Houses;
using Airelax.Domain.Houses.Defines;
using Airelax.Domain.Houses.Price;
using Airelax.Domain.Members;
using Airelax.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Airelax.EntityFramework.DbContexts
{
    public class AirelaxContext : DbContext
    {
        public DbSet<House> Houses { get; set; }

        public DbSet<HouseCategory> HouseCategories { get; set; }
        // public DbSet<HouseDescription> HouseDescriptions { get; set; }
        // public DbSet<HouseRule> HouseRules { get; set; }
        // public DbSet<Photo> Photos { get; set; }
        // public DbSet<Policy> Policies { get; set; }
        // public DbSet<ReservationRule> ReservationRules { get; set; }
        // public DbSet<Space> Spaces { get; set; }
        // public DbSet<HousePrice> HousePrices { get; set; }
        // public DbSet<Member> Members { get; set; }
        // public DbSet<MemberInfo> MemberInfos { get; set; }
        // public DbSet<MemberLoginInfo> MemberLoginInfos { get; set; }
        // public DbSet<WishList> WishLists { get; set; }
        // public DbSet<Order> Orders { get; set; }
        // public DbSet<OrderDetail> OrderDetails { get; set; }
        // public DbSet<OrderPriceDetail> OrderPriceDetails { get; set; }
        // public DbSet<Payment> Payments { get; set; }
        // public DbSet<Comment> Comments { get; set; }
        // public DbSet<Star> Stars { get; set; }

        public AirelaxContext(DbContextOptions<AirelaxContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<House>(
                builder =>
                {
                    builder.HasKey(x => x.Id);
                    builder.Property(x => x.Id).UseIdentityColumn();
                    builder.SetPropMaxLength(x => x.Title, 30).IsRequired();
                    builder.SetEnumDbMapping(x => x.Status).IsRequired();
                    builder.SetEnumDbMapping(x => x.CreateState).IsRequired();
                });

            modelBuilder.Entity<HouseCategory>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id).ValueGeneratedNever();
                builder.SetEnumDbMapping(x => x.Category);
                builder.SetEnumDbMapping(x => x.HouseType);
                builder.SetEnumDbMapping(x => x.RoomCategory);
                builder.HasOne<House>().WithOne(x => x.HouseCategory).HasForeignKey<HouseCategory>(x => x.Id);
            });

            modelBuilder.Entity<HouseLocation>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id).ValueGeneratedNever().IsRequired();
                builder.SetPropMaxLength(x => x.Country, 50);
                builder.SetPropMaxLength(x => x.City, 50);
                builder.SetPropMaxLength(x => x.Town, 50);
                builder.SetPropMaxLength(x => x.ZipCode, 10);
                builder.SetPropMaxLength(x => x.AddressDetail, 100);
                builder.SetPropMaxLength(x => x.LocationDescription, 500);
                builder.SetPropMaxLength(x => x.TrafficDescription, 250);
                builder.HasOne<House>().WithOne(x => x.HouseLocation).HasForeignKey<HouseLocation>(x => x.Id);
            });

            modelBuilder.Entity<HouseRule>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id).ValueGeneratedNever().IsRequired();
                builder.SetPropMaxLength(x => x.Other, 500);
                builder.HasOne<House>().WithOne(x => x.HouseRule).HasForeignKey<HouseRule>(x => x.Id);
            });

            modelBuilder.Entity<Policy>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id).ValueGeneratedNever().IsRequired();
                builder.SetEnumDbMapping(x => x.CancelPolicy);
                builder.Property(x => x.CancelPolicy).HasColumnType(Define.SQL_MONEY_TYPE);
                builder.HasOne<House>().WithOne(x => x.Policy).HasForeignKey<Policy>(x => x.Id);
            });

            // houseEntity.HasOne<HouseDescription>().WithOne().HasForeignKey<HouseDescription>(x=>x.Id);
            // houseEntity.HasOne<HouseLocation>().WithOne().HasForeignKey<HouseLocation>(x=>x.Id);
            // houseEntity.HasOne<HouseRule>().WithOne().HasForeignKey<HouseRule>(x=>x.Id);
            // houseEntity.HasOne<Policy>().WithOne().HasForeignKey<Policy>(x=>x.Id);
            // houseEntity.HasOne<ReservationRule>().WithOne().HasForeignKey<ReservationRule>(x=>x.Id);
            // houseEntity.HasOne<HousePrice>().WithOne().HasForeignKey<HousePrice>(x=>x.Id);
        }
    }
}