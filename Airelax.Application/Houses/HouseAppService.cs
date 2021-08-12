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