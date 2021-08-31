using Airelax.Application.Houses.Dtos.Request;
using Airelax.Application.Houses.Dtos.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Airelax.Application.Houses
{
    public interface IHouseAppService
    {
        Task<IEnumerable<SimpleHouseDto>> Search(SearchInput input);
        Task<HouseDto> GetHouse(string id);
    }
}