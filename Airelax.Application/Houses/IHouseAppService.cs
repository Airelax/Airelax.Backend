using Airelax.Application.Houses.Dtos.Request;
using Airelax.Application.Houses.Dtos.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Airelax.Application.Houses
{
    public interface IHouseAppService
    {


        Task<IEnumerable<SimpleHouseDto>> Search(SearchInput input);

        //Task<HouseDto> GetHouse(string id);
        Task<string> CreateAsync(CreateHouseInput input);
        Task<bool> UpdateHouseCategory(string id, UpdateHouseCategoryInput input);
        Task<bool> UpdateRoomCategory(string id, UpdateRoomCategoryInput input);
        Task<bool> UpdateHouseTitle(string id, UpdateHouseTitleInput input);
        Task<bool> UpdateHouseDescription(string id, UpdateHouseDescriptionInput input);
        Task<bool> UpdateHouseFacilities(string id, UpdateHouseFacilitiesInput input);
        Task<bool> UpdateHouseCustomerInput(string id, UpdateCustomerInput input);
        Task<bool> UpdateHousePriceInput(string id, UpdateHousePriceInput input);
        
    }
}
