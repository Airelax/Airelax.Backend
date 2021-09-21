using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Airelax.Application.Account;
using Airelax.Application.Houses.Dtos.Request.ManageHouse;
using Airelax.Application.Houses.Dtos.Response;
using Airelax.Application.ManageHouses.Request;
using Airelax.Application.ManageHouses.Response;
using Airelax.Domain.Houses;
using Airelax.Domain.Houses.Defines;
using Airelax.Domain.Houses.Defines.Spaces;
using Airelax.Domain.RepositoryInterface;
using Lazcat.Infrastructure.DependencyInjection;
using Lazcat.Infrastructure.ExceptionHandlers;
using Lazcat.Infrastructure.Extensions;

namespace Airelax.Application.Houses
{
    [DependencyInjection(typeof(IManageHouseService))]
    public class ManageHouseService : IManageHouseService
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IAccountService _accountService;
        private readonly IManageHouseRepository _manageHouseRepository;

        public ManageHouseService(IManageHouseRepository manageHouseRepository, IHouseRepository houseRepository, IAccountService accountService)
        {
            _manageHouseRepository = manageHouseRepository;
            _houseRepository = houseRepository;
            _accountService = accountService;
        }

        public IEnumerable<MyHouseViewModel> GetMyHouseViewModel()
        {
            var memberId = _accountService.GetAuthMemberId();
            var houses = _houseRepository.GetAll().Where(x => x.OwnerId == memberId && !x.IsDeleted);

            if (houses.IsNullOrEmpty())
                return new List<MyHouseViewModel>();

            var list = houses.ToList();
            var myHouseViewModel = list.Select(x => new MyHouseViewModel
            {
                HouseId = x.Id,
                Title = x.Title,
                HouseStatus = x.Status,
                CreateState = x.CreateState,
                CanRealTime = x.Policy.CanRealTime,
                Location = $"{x.HouseLocation.City},{x.HouseLocation.Country}",
                LastReservationTime = x.ReservationRule.LastReservationTime.ToString("yyyy-MM-dd")
            });

            return myHouseViewModel;
        }

        public async Task<ManageHouseDto> GetManageHouseInfo(string id)
        {
            var house = await _houseRepository.GetAsync(x => x.Id == id);
            if (house == null) return null;
            CheckAuthorization(house.OwnerId);
            var space = _manageHouseRepository.GetSpace(id);

            var manage = new ManageHouseDto
            {
                Id = id,
                Title = house.Title,
                Description =
                    new DescriptionDto
                    {
                        HouseDescription = house.HouseDescription?.Description,
                        SpaceDescription = house.HouseDescription?.SpaceDescription,
                        GuestPermission = house.HouseDescription?.GuestPermission,
                        Others = house.HouseDescription?.Others
                    },
                Status = (int) house.Status,
                ProvideFacilities = house.ProvideFacilities.Select(s => (int) s).ToList(),
                NotProvideFacilities = house.NotProvideFacilities.Select(s => (int) s).ToList(),
                Address = new AddressDto
                {
                    City = house.HouseLocation?.City,
                    Country = house.HouseLocation?.Country,
                    Town = house.HouseLocation?.Town,
                    Address = house.HouseLocation?.AddressDetail,
                    ZipCode = house.HouseLocation?.ZipCode,
                    LocationDescription = house.HouseLocation?.LocationDescription,
                    TrafficDescription = house.HouseLocation?.TrafficDescription
                },
                HouseCategory = new HouseCategoryVM
                {
                    Category = (int) (house.HouseCategory?.Category ?? 0), HouseType = (int) (house.HouseCategory?.HouseType ?? 0), RoomCategory = (int) (house.HouseCategory?.RoomCategory ?? 0)
                },
                SpaceBed = space.IsNullOrEmpty()
                    ? null
                    : JsonSerializer.Serialize(
                        space.Select(s =>
                        {
                            var spaceBedVm = new SpaceBedVM();
                            if (s.Space != null)
                                spaceBedVm.SpaceVM = new SpaceVM {Id = s.Space.Id, HouseId = s.Space.HouseId, IsShared = s.Space.IsShared, SpaceType = (int) s.Space.SpaceType};
                            if (s.BedroomDetail != null)
                                spaceBedVm.BedroomDetailVM = new BedroomDetailVM
                                {
                                    BedCount = s.BedroomDetail.BedCount,
                                    BedType = (int?) s.BedroomDetail?.BedType,
                                    HasIndependentBath = s.BedroomDetail.HasIndependentBath,
                                    SpaceId = s.BedroomDetail.SpaceId
                                };
                            return spaceBedVm;
                        })),
                CustomerNumber = house.CustomerNumber,
                Origin = Convert.ToString((int) (house.HousePrice?.PerNight ?? 0)),
                SweetPrice = Convert.ToString((int) (house.HousePrice?.PerWeekNight ?? 0)),
                WeekDiscount = Convert.ToString((int)(house.HousePrice?.Discount?.Week ?? 0)),
                MonthDiscount = Convert.ToString((int)(house.HousePrice?.Discount?.Month ?? 0)),
                Fee = Convert.ToString((int)(house.HousePrice?.Fee?.CleanFee ?? 0)),
                Cancel = (int) (house.Policy?.CancelPolicy ?? CancelPolicy.StrictOrNotRefund),
                InstanceBooking = house.Policy?.CanRealTime ?? false,
                CheckinTime = house.Policy?.CheckinTime.ToString("t", DateTimeFormatInfo.InvariantInfo),
                CheckoutTime = house.Policy?.CheckoutTime.ToString("t", DateTimeFormatInfo.InvariantInfo),
                CashPledge = Convert.ToString((int) (house.Policy?.CashPledge ?? 0)),
                HouseRule = new HouseRuleDto
                {
                    AllowChild = house.HouseRule.AllowChild,
                    AllowBaby = house.HouseRule.AllowBaby,
                    AllowPet = house.HouseRule.AllowPet,
                    AllowSmoke = house.HouseRule.AllowSmoke,
                    AllowParty = house.HouseRule.AllowParty,
                    Other = house.HouseRule.Other
                },
                Pictures = house.Photos?.Select(x => x.Image) ?? new List<string>()
            };
            return manage;
        }

        public HouseDescriptionInput UpdateDescription(string id, HouseDescriptionInput input)
        {
            var house = GetHouse(id);
            CheckAuthorization(house.OwnerId);
            house.HouseDescription = new HouseDescription(house.Id)
            {
                Description = input.Description,
                SpaceDescription = input.SpaceDescription,
                GuestPermission = input.GuestPermission,
                Others = input.Others
            };

            UpdateHouse(house);
            return input;
        }

        public HouseTitleInput UpdateTitle(string id, HouseTitleInput input)
        {
            var house = GetHouse(id);
            CheckAuthorization(house.OwnerId);
            house.Title = input.Title;
            UpdateHouse(house);
            return input;
        }

        public CustomerNumberInput UpdateCustomerNumber(string id, CustomerNumberInput input)
        {
            var house = GetHouse(id);
            CheckAuthorization(house.OwnerId);
            house.CustomerNumber = input.CustomerNumber;
            UpdateHouse(house);
            return input;
        }

        public HouseStatusInput UpdateStatus(string id, HouseStatusInput input)
        {
            var house = GetHouse(id);
            CheckAuthorization(house.OwnerId);
            house.Status = input.Status;
            UpdateHouse(house);
            return input;
        }

        public HouseAddressInput UpdateAddress(string id, HouseAddressInput input)
        {
            var house = GetHouse(id);
            CheckAuthorization(house.OwnerId);
            house.HouseLocation.Country = input.Country;
            house.HouseLocation.City = input.City;
            house.HouseLocation.Town = input.Town;
            house.HouseLocation.ZipCode = input.ZipCode;
            house.HouseLocation.AddressDetail = input.Address;
            UpdateHouse(house);
            return input;
        }

        public HouseLocationInupt UpdateLocation(string id, HouseLocationInupt input)
        {
            var house = GetHouse(id);
            CheckAuthorization(house.OwnerId);
            house.HouseLocation.LocationDescription = input.LocationDescription;
            house.HouseLocation.TrafficDescription = input.TrafficDescription;
            UpdateHouse(house);
            return input;
        }

        public HouseCategoryInput UpdateCategory(string id, HouseCategoryInput input)
        {
            var house = GetHouse(id);
            CheckAuthorization(house.OwnerId);
            house.HouseCategory.Category = input.Category;
            house.HouseCategory.HouseType = input.HouseType;
            house.HouseCategory.RoomCategory = input.RoomCategory;
            UpdateHouse(house);
            return input;
        }

        public HousePriceInput UpdatePrice(string id, HousePriceInput input)
        {
            var house = GetHouse(id);
            CheckAuthorization(house.OwnerId);
            house.HousePrice.PerNight = input.Origin;
            house.HousePrice.PerWeekNight = input.SweetPrice;
            house.Policy.CashPledge = input.CashPledge;
            house.HousePrice.Fee = new Domain.Houses.Price.Fee()
            {
                CleanFee = input.CleanFee
            };
            house.HousePrice.Discount = new Domain.Houses.Price.Discount()
            {
                Week = (int)input.WeekDiscount,
                Month = (int)input.MonthDiscount
            };
            UpdateHouse(house);
            return input;
        }

        public CancelPolicyInput UpdateCancel(string id, CancelPolicyInput input)
        {
            var house = GetHouse(id);
            CheckAuthorization(house.OwnerId);
            house.Policy.CancelPolicy = input.CancelPolicy;
            UpdateHouse(house);
            return input;
        }

        public RealTimeInput UpdateRealTime(string id, RealTimeInput input)
        {
            var house = GetHouse(id);
            CheckAuthorization(house.OwnerId);
            house.Policy.CanRealTime = input.CanRealTime;
            UpdateHouse(house);
            return input;
        }

        public CheckTimeInput UpdateCheckTime(string id, CheckTimeInput input)
        {
            var house = GetHouse(id);
            CheckAuthorization(house.OwnerId);
            house.Policy.CheckinTime = Convert.ToDateTime(input.CheckinTime);
            house.Policy.CheckoutTime = Convert.ToDateTime(input.CheckoutTime);
            UpdateHouse(house);
            return input;
        }

        public HouseOtherInput UpdateOthers(string id, HouseOtherInput input)
        {
            var house = GetHouse(id);
            CheckAuthorization(house.OwnerId);
            house.HouseRule.Other = input.Other;
            UpdateHouse(house);
            return input;
        }

        public HouseRuleInput UpdateRules(string id, HouseRuleInput input)
        {
            var house = GetHouse(id);
            CheckAuthorization(house.OwnerId);
            house.HouseRule.AllowChild = input.AllowChild;
            house.HouseRule.AllowBaby = input.AllowBaby;
            house.HouseRule.AllowPet = input.AllowPet;
            house.HouseRule.AllowSmoke = input.AllowSmoke;
            house.HouseRule.AllowParty = input.AllowParty;
            UpdateHouse(house);
            return input;
        }

        public HouseFacilityInput UpdateFacility(string id, HouseFacilityInput input)
        {
            var house = GetHouse(id);
            CheckAuthorization(house.OwnerId);
            house.ProvideFacilities = input.ProvideFacilities;
            house.NotProvideFacilities = input.NotProvideFacilities;
            UpdateHouse(house);
            return input;
        }

        public List<SpaceBed> CreateSpace(string id, HouseSpaceInput input)
        {
            var house = GetHouse(id);
            CheckAuthorization(house.OwnerId);
            var space = new Space(house.Id)
            {
                HouseId = input.HouseId,
                SpaceType = (SpaceType) input.SpaceType,
                IsShared = input.IsShared,
            };
            house.Spaces.Add(space);
            UpdateHouse(house);
            var SpaceId = _manageHouseRepository.GetSpace(id);
            return SpaceId;
        }

        public HouseSpaceInput DeleteSpace(string id, HouseSpaceInput input)
        {
            var house = GetHouse(id);
            CheckAuthorization(house.OwnerId);
            var deleteObj = house.Spaces.LastOrDefault(x => (int) x.SpaceType == input.SpaceType);
            house.Spaces.Remove(deleteObj);
            UpdateHouse(house);
            return input;
        }

        public BedroomDetailInput CreateBedroomDetail(string id, BedroomDetailInput input)
        {
            var house = GetHouse(id);
            CheckAuthorization(house.OwnerId);
            var updateObj = _manageHouseRepository.GetBedroom().FirstOrDefault(y => y.SpaceId == input.SpaceId && (int) y.BedType == input.BedType);
            if (updateObj != null)
            {
                UpdateBedroomDetail(id, input);
                return input;
            }

            var bedroomDetail = new BedroomDetail(input.SpaceId)
            {
                SpaceId = input.SpaceId,
                BedType = (BedType) input.BedType,
                BedCount = (int) input.BedCount,
                HasIndependentBath = (bool) input.HasIndependentBath
            };
            _manageHouseRepository.CreateBedroom(bedroomDetail);
            UpdateHouse(house);
            return input;
        }

        public BedroomDetailInput UpdateBedroomDetail(string id, BedroomDetailInput input)
        {
            var house = GetHouse(id);
            CheckAuthorization(house.OwnerId);
            var updateObj = _manageHouseRepository.GetBedroom().FirstOrDefault(y => y.SpaceId == input.SpaceId && (int) y.BedType == input.BedType);
            updateObj.BedCount = (int) input.BedCount;
            updateObj.HasIndependentBath = (bool) input.HasIndependentBath;
            UpdateHouse(house);
            return input;
        }

        public async Task<UploadHouseImagesViewModel> UploadHouseImages(string id, UploadHouseImagesInput input)
        {
            var house = await _houseRepository.GetAsync(x => x.Id == id);
            CheckAuthorization(house.OwnerId);
            if (house == null) throw ExceptionBuilder.Build(HttpStatusCode.BadRequest, $"houseId: {id} not match any house");
            house.Photos = input.Images?.Select(x => new Photo(house.Id)
            {
                Image = x
            }).ToList();
            await _houseRepository.UpdateAsync(house);
            await _houseRepository.SaveChangesAsync();
            return new UploadHouseImagesViewModel {Images = input.Images};
        }

        private void UpdateHouse(House house)
        {
            _manageHouseRepository.Update(house);
            _manageHouseRepository.SaveChange();
        }

        private void CheckAuthorization(string ownerId)
        {
            var memberId = _accountService.GetAuthMemberId();
            if (ownerId != memberId) throw ExceptionBuilder.Build(HttpStatusCode.Forbidden, "");
        }

        private House GetHouse(string id)
        {
            var house = _houseRepository.GetAsync(x => x.Id == id).Result;
            if (house == null) throw ExceptionBuilder.Build(HttpStatusCode.BadRequest, $"house: {id} not match any house");
            return house;
        }
    }
}