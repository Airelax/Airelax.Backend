using Airelax.Application.Houses.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airelax.Application.Houses
{
    public interface IHouseAppService
    {
        Task<HouseDto> GetHouse(string id);

    }
}
