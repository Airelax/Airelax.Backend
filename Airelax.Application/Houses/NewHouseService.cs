using System.Net;
using System.Threading.Tasks;
using Airelax.Application.Account;
using Airelax.Application.Houses.Dtos.Request;
using Airelax.Domain.Houses;
using Airelax.Domain.Houses.Price;
using Airelax.Domain.Members;
using Airelax.Domain.RepositoryInterface;
using Lazcat.Infrastructure.DependencyInjection;
using Lazcat.Infrastructure.ExceptionHandlers;

namespace Airelax.Application.Houses
{
    [DependencyInjection(typeof(INewHouseService))]
    public class NewHouseService : INewHouseService
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IAccountService _accountService;

        public NewHouseService(IHouseRepository houseRepository, IAccountService accountService)
        {
            _houseRepository = houseRepository;
            _accountService = accountService;
        }

        public async Task<string> CreateAsync(CreateHouseInput input)
        {
            var ownerId = _accountService.GetAuthMemberId();
            var house = new House(ownerId);
            house.HouseCategory = new HouseCategory(house.Id) {Category = input.Category};
            await _houseRepository.CreateAsync(house);
            await _houseRepository.SaveChangesAsync();
            return house.Id;
        }

        public async Task<bool> UpdateHouseCustomerInput(string id, UpdateCustomerInput input)
        {
            var house = await GetHouse(id);
            house.CustomerNumber = input.CustomerNumber;
            await UpdateHouse(house);
            return true;
        }

        public async Task<bool> UpdateHousePriceInput(string id, UpdateHousePriceInput input)
        {
            var house = await GetHouse(id);
            house.HousePrice = new HousePrice(house.Id) {PerNight = input.Price};
            await UpdateHouse(house);
            return true;
        }

        public async Task<bool> UpdateHouseType(string id, UpdateHouseTypeInput input)
        {
            var house = await GetHouse(id);
            house.HouseCategory.HouseType = input.HouseType;
            await UpdateHouse(house);
            return true;
        }

        public async Task<bool> UpdateRoomCategory(string id, UpdateRoomCategoryInput input)
        {
            var house = await GetHouse(id);
            house.HouseCategory.RoomCategory = input.RoomCategory;
            await UpdateHouse(house);
            return true;
        }

        public async Task<bool> UpdateHouseTitle(string id, UpdateHouseTitleInput input)
        {
            var house = await GetHouse(id);
            house.Title = input.Title;
            await UpdateHouse(house);
            return true;
        }

        public async Task<bool> UpdateHouseDescription(string id, UpdateHouseDescriptionInput input)
        {
            var house = await GetHouse(id);
            house.HouseDescription = new HouseDescription(house.Id) {Description = input.Description};
            await UpdateHouse(house);
            return true;
        }

        public async Task<bool> UpdateHouseFacilities(string id, UpdateHouseFacilitiesInput input)
        {
            var house = await GetHouse(id);
            house.ProvideFacilities = input.ProvideFacilities;
            await UpdateHouse(house);
            return true;
        }

        public async Task<bool> DeleteHouseAsync(string id)
        {
            var house = await GetHouse(id);
            await _houseRepository.DeleteAsync(house);
            await _houseRepository.SaveChangesAsync();
            return true;
        }


        private async Task<House> GetHouse(string id)
        {
            var house = await _houseRepository.GetAsync(x => x.Id == id);
            if (house == null) throw ExceptionBuilder.Build(HttpStatusCode.BadRequest, $"house id: {id} is not exist");
            return house;
        }

        private async Task UpdateHouse(House house)
        {
            await _houseRepository.UpdateAsync(house);
            await _houseRepository.SaveChangesAsync();
        }
    }
}