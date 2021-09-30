using System.Threading.Tasks;
using Airelax.Application.Houses;
using Airelax.Application.Houses.Dtos.Request;
using Airelax.Application.ManageHouses.Request;
using Airelax.Application.ManageHouses.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airelax.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/new-house")]
    public class NewHouseController : Controller
    {
        private readonly INewHouseService _houseAppService;
        private readonly IManageHouseService _manageHouseService;

        public NewHouseController(INewHouseService houseAppService, IManageHouseService manageHouseService)
        {
            _houseAppService = houseAppService;
            _manageHouseService = manageHouseService;
        }

        [HttpPost]
        public async Task<string> CreateHouse(CreateHouseInput input)
        {
            return await _houseAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}/type")]
        public async Task<bool> UpdateHouseType(string id, UpdateHouseTypeInput input)
        {
            return await _houseAppService.UpdateHouseType(id, input);
        }

        [HttpPut]
        [Route("{id}/RoomCategory")]
        public async Task<bool> UpdateRoomCategory(string id, UpdateRoomCategoryInput input)
        {
            return await _houseAppService.UpdateRoomCategory(id, input);
        }

        [HttpPut]
        [Route("{id}/title")]
        public async Task<bool> UpdateHouseTitle(string id, UpdateHouseTitleInput input)
        {
            return await _houseAppService.UpdateHouseTitle(id, input);
        }

        [HttpPut]
        [Route("{id}/Description")]
        public async Task<bool> UpdateHouseDescription(string id, UpdateHouseDescriptionInput input)
        {
            return await _houseAppService.UpdateHouseDescription(id, input);
        }

        [HttpPut]
        [Route("{id}/facilities")]
        public async Task<bool> UpdateHouseFacilities(string id, UpdateHouseFacilitiesInput input)
        {
            return await _houseAppService.UpdateHouseFacilities(id, input);
        }

        [HttpPut]
        [Route("{id}/customer")]
        public async Task<bool> UpdateCustomerInput(string id, UpdateCustomerInput input)
        {
            return await _houseAppService.UpdateHouseCustomerInput(id, input);
        }

        [HttpPut]
        [Route("{id}/price")]
        public async Task<bool> UpdateHousePrice(string id, UpdateHousePriceInput input)
        {
            return await _houseAppService.UpdateHousePriceInput(id, input);
        }

        [HttpPut]
        [Route("{id}/location")]
        public async Task<bool> SetHouseLocation(string id, CreateLocationInput input)
        {
            return await _houseAppService.UpdateLocation(id, input);
        }

        [HttpPut]
        [Route("{id}/pictures")]
        public async Task<UploadHouseImagesViewModel> UploadHouseImages(string id, [FromBody] UploadHouseImagesInput input)
        {
            return await _manageHouseService.UploadHouseImages(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<bool> Delete(string id)
        {
            return await _houseAppService.DeleteHouseAsync(id);
        }
    }
}