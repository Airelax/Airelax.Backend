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

namespace Airelax.Application.Houses
{
    [DependencyInjection(typeof(IHouseAppService), Lifetime = ServiceLifetime.Scoped)]
    public class HouseAppService : IHouseAppService
    {

        private readonly IHouseRepository _houseRepository;
        public HouseAppService(IHouseRepository houseRepository)
        {
            _houseRepository = houseRepository;
        }
        public async Task<HouseDto> GetHouse(int id)
        {
            //using (var context = new AirelaxContext()) 
            //{

            //   return context.Houses.FisrtORDefalut(x => x.id == id);
            //}





                var house = await _houseRepository.GetAsync(id);
            if (house == null)        
                throw ExceptionBuilder.Build(System.Net.HttpStatusCode.BadRequest, $"ID:{id}不存在");

            var houseDto = new HouseDto();
            houseDto.Id = house.Id;
            houseDto.Title = house.Title;

            return houseDto;

        }

    }
}
