using System.Threading.Tasks;
using Airelax.Application.Houses.Dtos.Request;

namespace Airelax.Application.Houses
{
    public interface INewHouseService
    {
        Task<string> CreateAsync(CreateHouseInput input);
        Task<bool> UpdateHouseCustomerInput(string id, UpdateCustomerInput input);
        Task<bool> UpdateHousePriceInput(string id, UpdateHousePriceInput input);
        Task<bool> UpdateHouseType(string id, UpdateHouseTypeInput input);
        Task<bool> UpdateRoomCategory(string id, UpdateRoomCategoryInput input);
        Task<bool> UpdateHouseTitle(string id, UpdateHouseTitleInput input);
        Task<bool> UpdateHouseDescription(string id, UpdateHouseDescriptionInput input);
        Task<bool> UpdateHouseFacilities(string id, UpdateHouseFacilitiesInput input);
        Task<bool> DeleteHouseAsync(string id);
        Task<bool> UpdateLocation(string id, CreateLocationInput input);
    }
}