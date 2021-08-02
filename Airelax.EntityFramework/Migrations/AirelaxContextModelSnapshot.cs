﻿// <auto-generated />
using System;
using Airelax.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Airelax.EntityFramework.Migrations
{
    [DbContext(typeof(AirelaxContext))]
    partial class AirelaxContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Airelax.Domain.Comments.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CommentTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Content")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.Property<int?>("HouseId1")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifyTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId1")
                        .HasColumnType("int");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("HouseId");

                    b.HasIndex("HouseId1");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.HasIndex("OrderId1");

                    b.HasIndex("ReceiverId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Airelax.Domain.Comments.Star", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("AccuracyScore")
                        .HasColumnType("int");

                    b.Property<int>("CheapScore")
                        .HasColumnType("int");

                    b.Property<int>("CleanScore")
                        .HasColumnType("int");

                    b.Property<int>("CommunicationScore")
                        .HasColumnType("int");

                    b.Property<int>("ExperienceScore")
                        .HasColumnType("int");

                    b.Property<int>("LocationScore")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Stars");
                });

            modelBuilder.Entity("Airelax.Domain.Houses.BedroomDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BedCount")
                        .HasColumnType("int");

                    b.Property<int>("BedType")
                        .HasColumnType("int");

                    b.Property<bool>("HasIndependentBath")
                        .HasColumnType("bit");

                    b.Property<int?>("SpaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpaceId");

                    b.ToTable("BedroomDetails");
                });

            modelBuilder.Entity("Airelax.Domain.Houses.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreateState")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerNumber")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifyTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("Airelax.Domain.Houses.HouseCategory", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<int>("HouseType")
                        .HasColumnType("int");

                    b.Property<int>("RoomCategory")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("HouseCategories");
                });

            modelBuilder.Entity("Airelax.Domain.Houses.HouseDescription", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("GuestPermission")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("HouseHighlight")
                        .HasColumnType("int");

                    b.Property<string>("Others")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("SpaceDescription")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.ToTable("HouseDescriptions");
                });

            modelBuilder.Entity("Airelax.Domain.Houses.HouseLocation", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("AddressDetail")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<string>("LocationDescription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Town")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TrafficDescription")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("HouseLocations");
                });

            modelBuilder.Entity("Airelax.Domain.Houses.HouseRule", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("AllowBaby")
                        .HasColumnType("bit");

                    b.Property<bool>("AllowChild")
                        .HasColumnType("bit");

                    b.Property<bool>("AllowParty")
                        .HasColumnType("bit");

                    b.Property<bool>("AllowPet")
                        .HasColumnType("bit");

                    b.Property<bool>("AllowSmoke")
                        .HasColumnType("bit");

                    b.Property<string>("Other")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("HouseRules");
                });

            modelBuilder.Entity("Airelax.Domain.Houses.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("image");

                    b.Property<int>("SpaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.HasIndex("SpaceId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Airelax.Domain.Houses.Policy", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("CanRealTime")
                        .HasColumnType("bit");

                    b.Property<int>("CancelPolicy")
                        .HasColumnType("int");

                    b.Property<decimal>("CashPledge")
                        .HasColumnType("Money");

                    b.Property<DateTime>("CheckinTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckoutTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Policies");
                });

            modelBuilder.Entity("Airelax.Domain.Houses.ReservationRule", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("AvailableTime")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastReservationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaxNight")
                        .HasColumnType("int");

                    b.Property<int>("MinNight")
                        .HasColumnType("int");

                    b.Property<int>("PrepareTime")
                        .HasColumnType("int");

                    b.Property<int>("RejectDate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ReservationRules");
                });

            modelBuilder.Entity("Airelax.Domain.Houses.Space", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.Property<bool>("IsShared")
                        .HasColumnType("bit");

                    b.Property<int>("SpaceType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.ToTable("Spaces");
                });

            modelBuilder.Entity("Airelax.Domain.Members.EmergencyContact", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("EmergencyContact");
                });

            modelBuilder.Entity("Airelax.Domain.Members.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressDetail")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Country")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Email")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEmailVerified")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPhoneVerified")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Town")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Airelax.Domain.Members.MemberInfo", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("About")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Location")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("MemberInfos");
                });

            modelBuilder.Entity("Airelax.Domain.Members.MemberLoginInfo", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("LoginType")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("RefreshToken")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("ThirdPartyRefreshToken")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("ThirdPartyToken")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Token")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("MemberLoginInfos");
                });

            modelBuilder.Entity("Airelax.Domain.Orders.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifyTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("HouseId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Airelax.Domain.Orders.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Adult")
                        .HasColumnType("int");

                    b.Property<int>("Baby")
                        .HasColumnType("int");

                    b.Property<int>("Child")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Airelax.Domain.Orders.Payment", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("PayState")
                        .HasColumnType("int");

                    b.Property<int>("PayType")
                        .HasColumnType("int");

                    b.Property<decimal?>("Refund")
                        .HasColumnType("Money");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Airelax.Domain.Comments.Comment", b =>
                {
                    b.HasOne("Airelax.Domain.Members.Member", "Author")
                        .WithMany("Comments")
                        .HasForeignKey("AuthorId")
                        .IsRequired();

                    b.HasOne("Airelax.Domain.Houses.House", null)
                        .WithMany("Comments")
                        .HasForeignKey("HouseId")
                        .IsRequired();

                    b.HasOne("Airelax.Domain.Houses.House", "House")
                        .WithMany()
                        .HasForeignKey("HouseId1");

                    b.HasOne("Airelax.Domain.Orders.Order", null)
                        .WithOne("Comment")
                        .HasForeignKey("Airelax.Domain.Comments.Comment", "OrderId")
                        .IsRequired();

                    b.HasOne("Airelax.Domain.Orders.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId1");

                    b.HasOne("Airelax.Domain.Members.Member", "Receiver")
                        .WithMany("ReceiveComments")
                        .HasForeignKey("ReceiverId")
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("House");

                    b.Navigation("Order");

                    b.Navigation("Receiver");
                });

            modelBuilder.Entity("Airelax.Domain.Comments.Star", b =>
                {
                    b.HasOne("Airelax.Domain.Comments.Comment", null)
                        .WithOne("Star")
                        .HasForeignKey("Airelax.Domain.Comments.Star", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Airelax.Domain.Houses.BedroomDetail", b =>
                {
                    b.HasOne("Airelax.Domain.Houses.Space", null)
                        .WithMany("BedroomDetail")
                        .HasForeignKey("SpaceId");
                });

            modelBuilder.Entity("Airelax.Domain.Houses.House", b =>
                {
                    b.HasOne("Airelax.Domain.Members.Member", null)
                        .WithMany("Houses")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Airelax.Domain.Houses.HouseCategory", b =>
                {
                    b.HasOne("Airelax.Domain.Houses.House", null)
                        .WithOne("HouseCategory")
                        .HasForeignKey("Airelax.Domain.Houses.HouseCategory", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Airelax.Domain.Houses.HouseDescription", b =>
                {
                    b.HasOne("Airelax.Domain.Houses.House", null)
                        .WithOne("HouseDescription")
                        .HasForeignKey("Airelax.Domain.Houses.HouseDescription", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Airelax.Domain.Houses.HouseLocation", b =>
                {
                    b.HasOne("Airelax.Domain.Houses.House", null)
                        .WithOne("HouseLocation")
                        .HasForeignKey("Airelax.Domain.Houses.HouseLocation", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Airelax.Domain.Houses.HouseRule", b =>
                {
                    b.HasOne("Airelax.Domain.Houses.House", null)
                        .WithOne("HouseRule")
                        .HasForeignKey("Airelax.Domain.Houses.HouseRule", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Airelax.Domain.Houses.Photo", b =>
                {
                    b.HasOne("Airelax.Domain.Houses.House", null)
                        .WithMany("Photos")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Airelax.Domain.Houses.Space", null)
                        .WithMany("Photos")
                        .HasForeignKey("SpaceId")
                        .IsRequired();
                });

            modelBuilder.Entity("Airelax.Domain.Houses.Policy", b =>
                {
                    b.HasOne("Airelax.Domain.Houses.House", null)
                        .WithOne("Policy")
                        .HasForeignKey("Airelax.Domain.Houses.Policy", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Airelax.Domain.Houses.ReservationRule", b =>
                {
                    b.HasOne("Airelax.Domain.Houses.House", null)
                        .WithOne("ReservationRule")
                        .HasForeignKey("Airelax.Domain.Houses.ReservationRule", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Airelax.Domain.Houses.Space", b =>
                {
                    b.HasOne("Airelax.Domain.Houses.House", null)
                        .WithMany("Spaces")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Airelax.Domain.Members.EmergencyContact", b =>
                {
                    b.HasOne("Airelax.Domain.Members.Member", null)
                        .WithOne("EmergencyContact")
                        .HasForeignKey("Airelax.Domain.Members.EmergencyContact", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Airelax.Domain.Members.MemberInfo", b =>
                {
                    b.HasOne("Airelax.Domain.Members.Member", null)
                        .WithOne("MemberInfo")
                        .HasForeignKey("Airelax.Domain.Members.MemberInfo", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Airelax.Domain.Members.MemberLoginInfo", b =>
                {
                    b.HasOne("Airelax.Domain.Members.Member", null)
                        .WithOne("MemberLoginInfo")
                        .HasForeignKey("Airelax.Domain.Members.MemberLoginInfo", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Airelax.Domain.Orders.Order", b =>
                {
                    b.HasOne("Airelax.Domain.Members.Member", null)
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Airelax.Domain.Houses.House", null)
                        .WithMany("Orders")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Airelax.Domain.Orders.OrderDetail", b =>
                {
                    b.HasOne("Airelax.Domain.Orders.Order", null)
                        .WithOne("OrderDetail")
                        .HasForeignKey("Airelax.Domain.Orders.OrderDetail", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Airelax.Domain.Orders.Payment", b =>
                {
                    b.HasOne("Airelax.Domain.Orders.Order", null)
                        .WithOne("Payment")
                        .HasForeignKey("Airelax.Domain.Orders.Payment", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Airelax.Domain.Comments.Comment", b =>
                {
                    b.Navigation("Star");
                });

            modelBuilder.Entity("Airelax.Domain.Houses.House", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("HouseCategory");

                    b.Navigation("HouseDescription");

                    b.Navigation("HouseLocation");

                    b.Navigation("HouseRule");

                    b.Navigation("Orders");

                    b.Navigation("Photos");

                    b.Navigation("Policy");

                    b.Navigation("ReservationRule");

                    b.Navigation("Spaces");
                });

            modelBuilder.Entity("Airelax.Domain.Houses.Space", b =>
                {
                    b.Navigation("BedroomDetail");

                    b.Navigation("Photos");
                });

            modelBuilder.Entity("Airelax.Domain.Members.Member", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("EmergencyContact");

                    b.Navigation("Houses");

                    b.Navigation("MemberInfo");

                    b.Navigation("MemberLoginInfo");

                    b.Navigation("Orders");

                    b.Navigation("ReceiveComments");
                });

            modelBuilder.Entity("Airelax.Domain.Orders.Order", b =>
                {
                    b.Navigation("Comment");

                    b.Navigation("OrderDetail");

                    b.Navigation("Payment");
                });
#pragma warning restore 612, 618
        }
    }
}
