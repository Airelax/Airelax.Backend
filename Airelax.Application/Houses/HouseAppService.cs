﻿using Airelax.Application.Houses.Dtos.Response;
using Lazcat.Infrastructure.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Airelax.Domain.RepositoryInterface;
using Lazcat.Infrastructure.ExceptionHandlers;
using Airelax.Application.Houses.Dtos.Request;
using Airelax.Domain.Houses;
using Airelax.Domain.Members;
using Airelax.Domain.Houses.Price;

namespace Airelax.Application.Houses
{
    [DependencyInjection(typeof(IHouseAppService), Lifetime = ServiceLifetime.Scoped)]
    public class HouseAppService : IHouseAppService
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IRepository _repository;

      
        public HouseAppService (IHouseRepository houseRepository, IRepository repository)
        {
            _houseRepository = houseRepository;
            _repository = repository;
        }

        public async Task<string> CreateAsync(CreateHouseInput input)
        {
            var owner = await _repository.GetAsync<string, Member>(x => x.Id == input.MemberId);
            if (owner == null) throw ExceptionBuilder.Build(System.Net.HttpStatusCode.BadRequest, $"member id: {input.MemberId} is not exist");
            var house = new House(input.MemberId);
            house.HouseCategory = new HouseCategory(house.Id) { Category=input.Category};
            await UpdateHouse(house);
            return house.Id;
        }

        public async Task<bool> UpdateHouseCategory(string id, UpdateHouseCategoryInput input)
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
            house.HouseDescription = new HouseDescription(house.Id) { Description = input.Description };
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
            house.HousePrice = new HousePrice(house.Id) { PerNight = input.Price };
            await UpdateHouse(house);
            return true;
        }

        private async Task<House> GetHouse(string id)
        {
            var house = await _houseRepository.GetAsync(x => x.Id == id);
            if (house == null) throw ExceptionBuilder.Build(System.Net.HttpStatusCode.BadRequest, $"house id: {id} is not exist");
            return house;
        }
        private async Task UpdateHouse(House house)
        {
            await _houseRepository.UpdateAsync(house);
            await _houseRepository.SaveChangesAsync();
        }



        //public async Task<HouseDto> GetHouse(string id)
        //{
        //    //using (var context = new AirelaxContext()) 
        //    //{

        //    //   return context.Houses.FisrtORDefalut(x => x.id == id);
        //    //}

        //    return default;
        //}
    }
}