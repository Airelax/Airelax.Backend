using System;
using System.Data.Common;
using System.Linq;
using Airelax.Domain.Houses;
using Airelax.Domain.Houses.Defines;
using Airelax.Domain.Members;
using Airelax.Domain.Members.Defines;
using Airelax.EntityFramework.DbContexts;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Airelax.Test.EntityFramework
{
    public class AirelaxDatabaseFixture : IDisposable
    {
        private static readonly object _lock = new();
        private static bool _databaseInitialized;
        private readonly DbConnection _connection;

        public AirelaxDatabaseFixture()
        {
            _connection = CreateDbConnection();
            Seed();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }

        public AirelaxContext CreateContext(DbTransaction transaction = null)
        {
            var dbContextOptions = new DbContextOptionsBuilder<AirelaxContext>().UseSqlite(_connection).Options;
            var context = new AirelaxContext(dbContextOptions);
            if (transaction != null) context.Database.UseTransaction(transaction);
            return context;
        }


        private DbConnection CreateDbConnection()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            return connection;
        }

        private void Seed()
        {
            lock (_lock)
            {
                if (_databaseInitialized) return;
                using (var context = CreateContext())
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();

                    var member = new Member
                    {
                        Name = "Eric", Birthday = new DateTime(2003, 9, 4), City = "Chiayi", Country = "Taiwan", Email = "aa123456@gamil.com", Gender = Gender.Man,
                        Phone = "0912345678", Town = "布袋", AddressDetail = "海港一路87號", RegisterTime = DateTime.Now, IsEmailVerified = true, IsDeleted = false
                    };
                    context.Members.Add(member);
                    context.SaveChanges();

                    var eric = context.Members.First(x => x.Name == "Eric");
                    var house = new House(eric.Id)
                    {
                        Title = "台灣的農舍", Status = HouseStatus.Publish, CustomerNumber = 4, OwnerId = eric.Id, LastModifyTime = DateTime.Now
                    };

                    context.Houses.Add(house);
                    context.SaveChanges();

                    var firstHouseId = context.Houses.First().Id;
                    var houseCategory = new HouseCategory(firstHouseId) {HouseType = HouseType.Castle};
                    context.HouseCategories.Add(houseCategory);

                    context.HouseDescriptions.Add(new HouseDescription(firstHouseId)
                    {
                        Description = "我的房子跟傑哥的一樣大",
                        GuestPermission = "可以使用房間的所有物品，包括但不限於1.用過的衛生紙\n2.充滿空氣的洋芋片"
                    });
                    context.HouseLocations.Add(new HouseLocation(firstHouseId)
                    {
                        Latitude = 120.4215, Longitude = 23.42587
                    });

                    context.HouseRules.Add(new HouseRule(firstHouseId)
                    {
                        AllowChild = true,
                        AllowSmoke = false
                    });

                    context.Policies.Add(new Policy(firstHouseId)
                    {
                        CanRealTime = true, CashPledge = 500
                    });

                    context.SaveChanges();
                }

                _databaseInitialized = true;
            }
        }
    }
}