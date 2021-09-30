using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Airelax.Application.Account;
using Airelax.Application.Houses.Dtos.Request;
using Airelax.Domain.Houses;
using Airelax.Domain.Houses.Defines;
using Airelax.Domain.Houses.Price;
using Airelax.Domain.Members;
using Airelax.Domain.RepositoryInterface;
using Airelax.Infrastructure.Map.Abstractions;
using Lazcat.Infrastructure.DependencyInjection;
using Lazcat.Infrastructure.ExceptionHandlers;

namespace Airelax.Application.Houses
{
    [DependencyInjection(typeof(INewHouseService))]
    public class NewHouseService : INewHouseService
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IAccountService _accountService;
        private readonly IGeocodingService _geocodingService;

        public NewHouseService(IHouseRepository houseRepository, IAccountService accountService, IGeocodingService geocodingService)
        {
            _houseRepository = houseRepository;
            _accountService = accountService;
            _geocodingService = geocodingService;
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
            house.CreateState = CreateState.Completed;
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

        public async Task<bool> UpdateLocation(string id, CreateLocationInput input)
        {
            var house = await GetHouse(id);
            var geocodingInfo = await _geocodingService.GetGeocodingInfo(input.FullAddress);

            if (string.IsNullOrEmpty(input.AddressDetail))
            {
                input.City = geocodingInfo.AddressComponent.FirstOrDefault(x => x.types.Contains("administrative_area_level_2")).long_name;
                input.ZipCode = geocodingInfo.AddressComponent.FirstOrDefault(x => x.types.Contains("postal_code")).long_name;
                input.Town = geocodingInfo.AddressComponent.FirstOrDefault(x => x.types.Contains("administrative_area_level_3")).long_name;
                geocodingInfo.AddressComponent.Reverse();
                input.AddressDetail = string.Concat(geocodingInfo.AddressComponent.Select(x => x.long_name))
                    .Replace(input.City, "")
                    .Replace(input.ZipCode, "")
                    .Replace("台灣", "")
                    .Replace(input.Town, "");
            }

            house.HouseLocation = new HouseLocation(house.Id)
            {
                AddressDetail = input.AddressDetail ?? string.Empty,
                City = input.City ?? string.Empty,
                Country = "台灣",
                Town = input.Town,
                Longitude = geocodingInfo.Location.Longitude,
                Latitude = geocodingInfo.Location.Latitude
            };

            await _houseRepository.UpdateAsync(house);
            await _houseRepository.SaveChangesAsync();
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