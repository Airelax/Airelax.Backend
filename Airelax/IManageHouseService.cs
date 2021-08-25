using Airelax.Application.Houses.Dtos.Request.ManageHouse;
using Airelax.Application.Houses.Dtos.Response;

namespace Airelax
{
    public interface IManageHouseService
    {
        ManageHouseDto GetManageHouseInfo(string id);
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
    }
}