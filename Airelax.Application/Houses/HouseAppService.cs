using Airelax.Application.Houses.Dtos.Response;
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
            await _houseRepository.CreateAsync(house);
            await _houseRepository.SaveChangesAsync();
            return house.Id;
        }

        public async Task<bool> UpdateHouseCategory(string id, UpdateHouseCategoryInput input)
        {
           var house = await _houseRepository.GetAsync(x => x.Id == id); 
           if (house == null) throw ExceptionBuilder.Build(System.Net.HttpStatusCode.BadRequest, $"house id: {id} is not exist");
            house.HouseCategory.HouseType = input.HouseType;
            await _houseRepository.UpdateAsync(house);
            await _houseRepository.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateHouseCategoryRoomStyle(string id, UpdateHouseCategoryRoomStyleInput input)
        {
            var house = await _houseRepository.GetAsync(x => x.Id == id);
            if(house == null) throw ExceptionBuilder.Build(System.Net.HttpStatusCode.BadRequest, $"house id: {id} is not exist");
            house.HouseCategory.RoomCategory = input.RoomCategory;
            await _houseRepository.UpdateAsync(house);
            await _houseRepository.SaveChangesAsync();
            return true;

        }
        public async Task<bool> UpdateHouseTitle(string id, UpdateHouseTitle input)
        {
            var house = await _houseRepository.GetAsync(x => x.Id == id);
            if(house == null) throw ExceptionBuilder.Build(System.Net.HttpStatusCode.BadRequest, $"house id: {id} is not exist");
            house.Title = input.Title;
            await _houseRepository.UpdateAsync(house);
            await _houseRepository.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateHouseDescription(string id, UpdateHouseDescription input)
        {
            var house = await _houseRepository.GetAsync(x => x.Id == id);
            if (house == null) throw ExceptionBuilder.Build(System.Net.HttpStatusCode.BadRequest, $"house id: {id} is not exist");
            house.HouseDescription.Description = input.Description;
            await _houseRepository.UpdateAsync(house);
            await _houseRepository.SaveChangesAsync();
            return true;
        }



        public async Task<HouseDto> GetHouse(string id)
        {
            //using (var context = new AirelaxContext()) 
            //{

            //   return context.Houses.FisrtORDefalut(x => x.id == id);
            //}

            return default;
        }
    }
}