using System.Threading.Tasks;
using Airelax.Application.Houses.Dtos.Request;
using Airelax.Application.Houses.Dtos.Response;

namespace Airelax.Application.Houses
{
    public interface IHouseAppService
    {
        Task<SearchHousesResponse> Search(SearchInput input);
        Task<HouseDto> GetHouse(string id);
    }
}