using System;
using System.Linq.Expressions;
using System.Xml.Schema;
using Airelax.Domain.Comments;
using Airelax.Domain.DomainObject;
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
        public DbSet<HouseLocation> HouseLocations { get; set; }
        public DbSet<HouseDescription> HouseDescriptions { get; set; }
        public DbSet<HouseRule> HouseRules { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<ReservationRule> ReservationRules { get; set; }
        public DbSet<Space> Spaces { get; set; }

        public DbSet<BedroomDetail> BedroomDetails { get; set; }

        //todo
        //public DbSet<HousePrice> HousePrices { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberInfo> MemberInfos { get; set; }
        public DbSet<MemberLoginInfo> MemberLoginInfos { get; set; }
        //todo
        //public DbSet<WishList> WishLists { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        //todo
        //public DbSet<OrderPriceDetail> OrderPriceDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Star> Stars { get; set; }


        public AirelaxContext(DbContextOptions<AirelaxContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigHouse(modelBuilder);

            ConfigHouseCategory(modelBuilder);

            ConfigHouseLocation(modelBuilder);

            ConfigHouseDescription(modelBuilder);

            ConfigHouseRule(modelBuilder);

            ConfigPolicy(modelBuilder);

            ConfigReservationRule(modelBuilder);

            ConfigPhoto(modelBuilder);

            ConfigSpace(modelBuilder);

            ConfigBedroomDetail(modelBuilder);

            ConfigMember(modelBuilder);

            ConfigMemberLogInfo(modelBuilder);

            ConfigMemberInfo(modelBuilder);

            ConfigEmergencyContact(modelBuilder);

            ConfigOrder(modelBuilder);
            
            ConfigOrderDetail(modelBuilder);
            
            ConfigPayment(modelBuilder);

            ConfigConfigComment(modelBuilder);
            
            ConfigStar(modelBuilder);
        }

        #region HouseConfig

        private static void ConfigHouse(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<House>(
                builder =>
                {
                    builder.SetEntityKey<House, int>();
                    builder.SetPropMaxLength(x => x.Title, 30).IsRequired();
                    builder.SetEnumDbMapping(x => x.Status).IsRequired();
                    builder.SetEnumDbMapping(x => x.CreateState).IsRequired();

                    builder.HasOne<Member>().WithMany(x => x.Houses).HasForeignKey(x => x.OwnerId);
                });
        }

        private static void ConfigBedroomDetail(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BedroomDetail>(builder =>
            {
                builder.SetEntityKey<BedroomDetail, int>();
                builder.SetEnumDbMapping(x => x.BedType).IsRequired();
                builder.HasOne<Space>().WithMany(x => x.BedroomDetail);
            });
        }

        private static void ConfigSpace(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Space>(builder =>
            {
                builder.SetEntityKey<Space, int>();
                builder.SetEnumDbMapping(x => x.SpaceType).IsRequired();
                builder.HasOne<House>().WithMany(x => x.Spaces).HasForeignKey(x => x.HouseId);
            });
        }

        private static void ConfigPhoto(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Photo>(builder =>
            {
                builder.SetEntityKey<Photo, int>();
                builder.Property(x => x.Image).HasColumnType(Define.SqlServer.IMAGE_TYPE).IsRequired();
                builder.HasOne<House>().WithMany(x => x.Photos).HasForeignKey(x => x.HouseId).IsRequired();
                builder.HasOne<Space>().WithMany(x => x.Photos).OnDelete(DeleteBehavior.ClientSetNull).HasForeignKey(x => x.SpaceId);
            });
        }

        private static void ConfigReservationRule(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReservationRule>(builder =>
            {
                builder.SetZeroEntityKey<ReservationRule, int>();
                builder.SetEnumDbMapping(x => x.RejectDate);
                builder.HasOne<House>().WithOne(x => x.ReservationRule).HasForeignKey<ReservationRule>(x => x.Id);
            });
        }

        private static void ConfigPolicy(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Policy>(builder =>
            {
                builder.SetZeroEntityKey<Policy, int>();
                builder.SetEnumDbMapping(x => x.CancelPolicy);
                builder.Property(x => x.CashPledge).HasColumnType(Define.SqlServer.MONEY_TYPE);
                builder.HasOne<House>().WithOne(x => x.Policy).HasForeignKey<Policy>(x => x.Id);
            });
        }

        private static void ConfigHouseRule(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HouseRule>(builder =>
            {
                builder.SetZeroEntityKey<HouseRule, int>();
                builder.SetPropMaxLength(x => x.Other, 500);
                builder.HasOne<House>().WithOne(x => x.HouseRule).HasForeignKey<HouseRule>(x => x.Id);
            });
        }

        private static void ConfigHouseDescription(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HouseDescription>(builder =>
            {
                builder.SetZeroEntityKey<HouseDescription, int>();
                builder.SetPropMaxLength(x => x.Description, 1000);
                builder.SetPropMaxLength(x => x.SpaceDescription, 1000);
                builder.SetPropMaxLength(x => x.GuestPermission, 1000);
                builder.SetPropMaxLength(x => x.Others, 1000);
                builder.SetEnumDbMapping(x => x.HouseHighlight);
                builder.HasOne<House>().WithOne(x => x.HouseDescription).HasForeignKey<HouseDescription>(x => x.Id);
            });
        }

        private static void ConfigHouseLocation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HouseLocation>(builder =>
            {
                builder.SetZeroEntityKey<HouseLocation, int>();
                builder.SetPropMaxLength(x => x.Country, 50);
                builder.SetPropMaxLength(x => x.City, 50);
                builder.SetPropMaxLength(x => x.Town, 50);
                builder.SetPropMaxLength(x => x.ZipCode, 10);
                builder.SetPropMaxLength(x => x.AddressDetail, 100);
                builder.SetPropMaxLength(x => x.LocationDescription, 500);
                builder.SetPropMaxLength(x => x.TrafficDescription, 250);
                builder.HasOne<House>().WithOne(x => x.HouseLocation).HasForeignKey<HouseLocation>(x => x.Id);
            });
        }

        private static void ConfigHouseCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HouseCategory>(builder =>
            {
                builder.SetZeroEntityKey<HouseCategory, int>();
                builder.SetEnumDbMapping(x => x.Category);
                builder.SetEnumDbMapping(x => x.HouseType);
                builder.SetEnumDbMapping(x => x.RoomCategory);
                builder.HasOne<House>().WithOne(x => x.HouseCategory).HasForeignKey<HouseCategory>(x => x.Id);
            });
        }

        #endregion

        #region MemberConfig
        private static void ConfigMember(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>(builder =>
            {
                builder.SetEntityKey<Member, int>();
                builder.SetPropMaxLength(x => x.Name, 50);
                builder.SetEnumDbMapping(x => x.Gender);
                builder.SetPropMaxLength(x => x.Email, 30);
                builder.SetPropMaxLength(x => x.Country, 30);
                builder.SetPropMaxLength(x => x.City, 30);
                builder.SetPropMaxLength(x => x.Town, 30);
                builder.SetPropMaxLength(x => x.AddressDetail, 50);
                builder.SetPropMaxLength(x => x.Phone, 30);
            });
        }

        private static void ConfigMemberLogInfo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberLoginInfo>(builder =>
            {
                builder.SetZeroEntityKey<MemberLoginInfo, int>();
                builder.SetEnumDbMapping(x => x.LoginType).IsRequired();
                builder.SetPropMaxLength(x => x.Account, 50).IsRequired();
                builder.SetPropMaxLength(x => x.Token, 300);
                builder.SetPropMaxLength(x => x.Password, 300);
                builder.SetPropMaxLength(x => x.RefreshToken, 300);
                builder.SetPropMaxLength(x => x.ThirdPartyToken, 300);
                builder.SetPropMaxLength(x => x.ThirdPartyRefreshToken, 300);

                builder.HasOne<Member>().WithOne(x => x.MemberLoginInfo).HasForeignKey<MemberLoginInfo>(x => x.Id);
            });
        }

        private static void ConfigMemberInfo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberInfo>(builder =>
            {
                builder.SetZeroEntityKey<MemberInfo, int>();
                builder.SetPropMaxLength(x => x.About, 1000);
                builder.SetPropMaxLength(x => x.Location, 100);

                builder.HasOne<Member>().WithOne(x => x.MemberInfo).HasForeignKey<MemberInfo>(x => x.Id);
            });
        }

        private static void ConfigEmergencyContact(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmergencyContact>(builder =>
            {
                builder.SetZeroEntityKey<EmergencyContact, int>();
                builder.SetPropMaxLength(x => x.Name, 50);
                builder.SetPropMaxLength(x => x.Phone, 30);

                builder.HasOne<Member>().WithOne(x => x.EmergencyContact).HasForeignKey<EmergencyContact>(x => x.Id);
            });
        }

        // todo
        // private static void ConfigWishList(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<WishList>(builder =>
        //     {
        //         builder.SetZeroEntityKey<WishList,int>();
        //     });
        // }
        
        #endregion
        
        #region OrdersConfig

        private static void ConfigOrder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(builder =>
            {
                builder.SetEntityKey<Order, int>();
                builder.SetEnumDbMapping(x => x.State);

                builder.HasOne<Member>().WithMany(x => x.Orders).HasForeignKey(x => x.CustomerId).IsRequired();
                builder.HasOne<House>().WithMany(x => x.Orders).OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.HouseId).IsRequired();
            });
        }
        
        private static void ConfigOrderDetail(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>(builder =>
            {
                builder.SetZeroEntityKey<OrderDetail, int>();
                builder.Property(x => x.StartDate).IsRequired();
                builder.Property(x => x.EndDate).IsRequired();
                builder.Property(x => x.Adult).IsRequired();
                builder.Property(x => x.Child).IsRequired();
                builder.Property(x => x.Baby).IsRequired();

                builder.HasOne<Order>().WithOne(x => x.OrderDetail).HasForeignKey<OrderDetail>(x => x.Id);
            });
        }
        
        private static void ConfigPayment(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>(builder =>
            {
                builder.SetZeroEntityKey<Payment, int>();
                builder.SetEnumDbMapping(x => x.PayState).IsRequired();
                builder.SetEnumDbMapping(x => x.PayType).IsRequired();
                builder.Property(x => x.Refund).HasColumnType(Define.SqlServer.MONEY_TYPE);

                builder.HasOne<Order>().WithOne(x => x.Payment).HasForeignKey<Payment>(x => x.Id);
            });
        }

        #endregion
        
        #region CommentsConfig

        private static void ConfigConfigComment(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(builder =>
            {
                builder.SetEntityKey<Comment,int>();
                builder.SetPropMaxLength(x => x.Content, 500);
                builder.Property(x => x.CommentTime).IsRequired();

                builder.HasOne<House>().WithMany(x => x.Comments).OnDelete(DeleteBehavior.ClientSetNull).HasForeignKey(x => x.HouseId);
                builder.HasOne(x=>x.Author).WithMany(x => x.Comments).OnDelete(DeleteBehavior.ClientSetNull).HasForeignKey(x => x.AuthorId);
                builder.HasOne(x=>x.Receiver).WithMany(x => x.ReceiveComments).OnDelete(DeleteBehavior.ClientSetNull).HasForeignKey(x => x.ReceiverId);
                builder.HasOne<Order>().WithOne(x => x.Comment).OnDelete(DeleteBehavior.ClientSetNull).HasForeignKey<Comment>(x => x.OrderId);
            });
        }

        private static void ConfigStar(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Star>(builder =>
            {
                builder.SetZeroEntityKey<Star,int>();
                builder.Property(x => x.AccuracyScore).IsRequired();
                builder.Property(x => x.CheapScore).IsRequired();
                builder.Property(x => x.CleanScore).IsRequired();
                builder.Property(x => x.CommunicationScore).IsRequired();
                builder.Property(x => x.ExperienceScore).IsRequired();
                builder.Property(x => x.LocationScore).IsRequired();
                builder.HasOne<Comment>().WithOne(x => x.Star).HasForeignKey<Star>(x => x.Id);
            });
        }
        #endregion
        
    }
}