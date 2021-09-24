using System.Collections.Generic;
using System.Threading.Tasks;
using Airelax.Application.Houses.Dtos.Request.ManageHouse;
using Airelax.Application.Houses.Dtos.Response;
using Airelax.Application.ManageHouses.Request;
using Airelax.Application.ManageHouses.Response;
using Airelax.Domain.Houses;

namespace Airelax.Application.Houses
{
    public interface IManageHouseService
    {
        Task<ManageHouseDto> GetManageHouseInfo(string id);
        HouseAddressInput UpdateAddress(string id, HouseAddressInput input);
        HouseTitleInput UpdateTitle(string id, HouseTitleInput input);
        CancelPolicyInput UpdateCancel(string id, CancelPolicyInput input);
        HouseCategoryInput UpdateCategory(string id, HouseCategoryInput input);
        CheckTimeInput UpdateCheckTime(string id, CheckTimeInput input);
        CustomerNumberInput UpdateCustomerNumber(string id, CustomerNumberInput input);
        HouseDescriptionInput UpdateDescription(string id, HouseDescriptionInput input);
        HouseFacilityInput UpdateFacility(string id, HouseFacilityInput input);
        HouseLocationInupt UpdateLocation(string id, HouseLocationInupt input);
        HouseOtherInput UpdateOthers(string id, HouseOtherInput input);
        HousePriceInput UpdatePrice(string id, HousePriceInput input);
        RealTimeInput UpdateRealTime(string id, RealTimeInput input);
        HouseRuleInput UpdateRules(string id, HouseRuleInput input);
        HouseStatusInput UpdateStatus(string id, HouseStatusInput input);
        List<SpaceBed> CreateSpace(string id, HouseSpaceInput input);
        HouseSpaceInput DeleteSpace(string id, HouseSpaceInput input);
        BedroomDetailInput CreateBedroomDetail(string id, BedroomDetailInput input);
        BedroomDetailInput UpdateBedroomDetail(string id, BedroomDetailInput input);
        Task<UploadHouseImagesViewModel> UploadHouseImages(string id, UploadHouseImagesInput input);
        IEnumerable<MyHouseViewModel> GetMyHouseViewModel();
    }
}