using System;
using System.Linq;
using System.Threading.Tasks;
using Airelax.Domain.Houses;
using Airelax.Domain.Houses.Defines;
using Airelax.Domain.Members;
using Airelax.EntityFramework.Repositories;
using Shouldly;
using Xunit;

namespace Airelax.Test.EntityFramework
{
    public class EFRepositoryTest : IClassFixture<AirelaxDatabaseFixture>
    {
        public AirelaxDatabaseFixture Fixture { get; }
        private readonly EFRepository<int, House> _houseRepository;
        private readonly EFRepository<int, HouseLocation> _houseLocationRepository;
        private readonly EFRepository<int, Member> _memberRepository;

        public EFRepositoryTest(AirelaxDatabaseFixture fixture)
        {
            Fixture = fixture;
            _houseRepository = new EFRepository<int, House>(fixture.CreateContext());
            _houseLocationRepository = new EFRepository<int, HouseLocation>(fixture.CreateContext());
            _memberRepository = new EFRepository<int, Member>(fixture.CreateContext());
        }

        [Fact]
        public async Task EFRepository_Get_Test()
        {
            var house = await _houseRepository.GetAsync(1);
            house.Title.ShouldBe("台灣的農舍");
            house.Status.ShouldBe(HouseStatus.Publish);
            house.IsDeleted.ShouldBe(false);

            var houseLocation = await _houseLocationRepository.GetAsync(1);
            houseLocation.Latitude.Value.ShouldBeGreaterThanOrEqualTo(120);
        }

        [Fact]
        public async Task EFRepository_FOD_Test()
        {
            var t1 = await _houseRepository.FirstOrDefaultAsync(x => x.Title.Contains("台"));
            t1.ShouldNotBeNull();
            t1.Title.ShouldBe("台灣的農舍");
            t1.Status.ShouldBe(HouseStatus.Publish);
        }


        [Fact]
        public async Task CreateTest()
        {
            await _memberRepository.CreateAsync(new Member()
            {
                Name = "Tony"
            });
            await _memberRepository.SaveChangesAsync();
            var airelaxContext = Fixture.CreateContext();
            airelaxContext.Members.Count().ShouldBeGreaterThanOrEqualTo(2);
        }


        // [Fact]
        // public async Task DeleteTest()
        // {
        //     var member = await _memberRepository.GetAsync(1);
        //     await _memberRepository.DeleteAsync(member);
        //     await _memberRepository.SaveChangesAsync();
        //     var airelaxContext = Fixture.CreateContext();
        //     (await airelaxContext.Members.FindAsync()).ShouldBeNull();
        // }
    }
}