﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Airelax.Application.Houses.Dtos.Request.ManageHouse;
using Airelax.Application.Houses.Dtos.Response;
using Airelax.Domain.Houses;
using Airelax.Domain.Houses.Defines;
using Airelax.Domain.Houses.Defines.Spaces;
using Lazcat.Infrastructure.DependencyInjection;
using Lazcat.Infrastructure.ExceptionHandlers;
using Lazcat.Infrastructure.Extensions;

namespace Airelax
{
    [DependencyInjection(typeof(IManageHouseService))]
    public class ManageHouseService : IManageHouseService
    {
        private readonly IManageHouseRepository _manageHouseRepository;

        public ManageHouseService(IManageHouseRepository manageHouseRepository)
        {
            _manageHouseRepository = manageHouseRepository;
        }

        public ManageHouseDto GetManageHouseInfo(string id)
        {
            var house = _manageHouseRepository.Get(id);
            var space = _manageHouseRepository.GetSpace(id);
            ManageHouseDto manage = new ManageHouseDto()
            {
                Id = id,
                Title = house.Title,
                //Pictures
                Description = new DescriptionDto()
                {
                    HouseDescription = house.HouseDescription?.Description,
                    SpaceDescription = house.HouseDescription?.SpaceDescription,
                    GuestPermission = house.HouseDescription?.GuestPermission,
                    Others = house.HouseDescription?.Others
                },
                Status = (int) house.Status,
                ProvideFacilities = house.ProvideFacilities?.Select(s => (int) s).ToList(),
                NotProvideFacilities = house.NotProvideFacilities?.Select(s => (int) s).ToList(),
                Address = new AddressDto()
                {
                    City = house.HouseLocation?.City,
                    Country = house.HouseLocation?.Country,
                    Town = house.HouseLocation?.Town,
                    Address = house.HouseLocation?.AddressDetail,
                    ZipCode = house.HouseLocation?.ZipCode,
                    LocationDescription = house.HouseLocation?.LocationDescription,
                    TrafficDescription = house.HouseLocation?.TrafficDescription
                },
                HouseCategory = new HouseCategoryVM()
                {
                    Category = (int) (house.HouseCategory?.Category ?? Category.Apartment),
                    HouseType = (int?) house.HouseCategory?.HouseType,
                    RoomCategory = (int?) house.HouseCategory?.RoomCategory
                },
                SpaceBed = space.IsNullOrEmpty()
                    ? null
                    : JsonSerializer.Serialize(
                        space.Select(s => new SpaceBedVM
                        {
                            Space = new SpaceVM
                            {
                                Id = s.Space.Id,
                                HouseId = s.Space.HouseId,
                                IsShared = s.Space.IsShared,
                                SpaceType = (int) s.Space.SpaceType
                            },
                            BedroomDetail = new BedroomDetailVM
                            {
                                BedCount = s.BedroomDetail.BedCount,
                                BedType = (int) s.BedroomDetail.BedType,
                                HasIndependentBath = s.BedroomDetail.HasIndependentBath,
                                SpaceId = s.BedroomDetail.SpaceId
                            }
                        })),
                CustomerNumber = house.CustomerNumber,
                Origin = Convert.ToString(house.HousePrice.PerNight),
                SweetPrice = Convert.ToString(house.HousePrice.PerWeekNight ?? house.HousePrice.PerNight),
                ////Discount
                ////Fee = price.Fee,
                Cancel = (int) house.Policy?.CancelPolicy,
                InstanceBooking = house.Policy?.CanRealTime ?? false,
                CheckinTime = house.Policy?.CheckinTime.ToString("t", DateTimeFormatInfo.InvariantInfo),
                CheckoutTime = house.Policy?.CheckoutTime.ToString("t", DateTimeFormatInfo.InvariantInfo),
                CashPledge = (house.Policy?.CashPledge ?? 0).ToString(),
                HouseRule = new HouseRuleDto()
                {
                    AllowChild = house.HouseRule?.AllowChild,
                    AllowBaby = house.HouseRule?.AllowBaby,
                    AllowPet = house.HouseRule?.AllowPet,
                    AllowSmoke = house.HouseRule?.AllowSmoke,
                    AllowParty = house.HouseRule?.AllowParty,
                    Other = house.HouseRule?.Other
                }
            };
            return manage;
        }

        public HouseDescriptionInput UpdateDescription(string id, HouseDescriptionInput input)
        {
            var house = _manageHouseRepository.Get(id);
            if (house == null) throw ExceptionBuilder.Build(HttpStatusCode.BadRequest, $"house id: {id} cannot match any house");
            var houseDescription = new HouseDescription(house.Id)
            {
                Description = input.Description,
                SpaceDescription = input.SpaceDescription,
                GuestPermission = input.GuestPermission,
                Others = input.Others
            };

            house.HouseDescription = houseDescription;
            _manageHouseRepository.Update(house);
            _manageHouseRepository.SaveChange();
            return input;
        }

        public HouseTitleInput UpdateTitle(string id, HouseTitleInput input)
        {
            var house = _manageHouseRepository.Get(id);
            house.Title = input.Title;
            _manageHouseRepository.Update(house);
            _manageHouseRepository.SaveChange();
            return input;
        }

        public CustomerNumberInput UpdateCustomerNumber(string id, CustomerNumberInput input)
        {
            var house = _manageHouseRepository.Get(id);
            house.CustomerNumber = input.CustomerNumber;
            _manageHouseRepository.Update(house);
            _manageHouseRepository.SaveChange();
            return input;
        }

        public HouseStatusInput UpdateStatus(string id, HouseStatusInput input)
        {
            var house = _manageHouseRepository.Get(id);
            house.Status = input.Status;
            _manageHouseRepository.Update(house);
            _manageHouseRepository.SaveChange();
            return input;
        }

        public HouseAddressInput UpdateAddress(string id, HouseAddressInput input)
        {
            var house = _manageHouseRepository.Get(id);
            house.HouseLocation.Country = input.Country;
            house.HouseLocation.City = input.City;
            house.HouseLocation.Town = input.Town;
            house.HouseLocation.ZipCode = input.ZipCode;
            house.HouseLocation.AddressDetail = input.Address;
            _manageHouseRepository.Update(house);
            _manageHouseRepository.SaveChange();
            return input;
        }

        public HouseLocationInupt UpdateLocation(string id, HouseLocationInupt input)
        {
            var house = _manageHouseRepository.Get(id);
            house.HouseLocation.LocationDescription = input.LocationDescription;
            house.HouseLocation.TrafficDescription = input.TrafficDescription;
            _manageHouseRepository.Update(house);
            _manageHouseRepository.SaveChange();
            return input;
        }

        public HouseCategoryInput UpdateCategory(string id, HouseCategoryInput input)
        {
            var house = _manageHouseRepository.Get(id);
            house.HouseCategory.Category = input.Category;
            house.HouseCategory.HouseType = input.HouseType;
            house.HouseCategory.RoomCategory = input.RoomCategory;
            _manageHouseRepository.Update(house);
            _manageHouseRepository.SaveChange();
            return input;
        }

        public HousePriceInput UpdatePrice(string id, HousePriceInput input)
        {
            var house = _manageHouseRepository.Get(id);
            house.HousePrice.PerNight = input.Origin;
            house.HousePrice.PerWeekNight = input.SweetPrice;
            house.Policy.CashPledge = input.CashPledge;
            _manageHouseRepository.Update(house);
            _manageHouseRepository.SaveChange();
            return input;
        }

        public CancelPolicyInput UpdateCancel(string id, CancelPolicyInput input)
        {
            var house = _manageHouseRepository.Get(id);
            house.Policy.CancelPolicy = input.CancelPolicy;
            _manageHouseRepository.Update(house);
            _manageHouseRepository.SaveChange();
            return input;
        }

        public RealTimeInput UpdateRealTime(string id, RealTimeInput input)
        {
            var house = _manageHouseRepository.Get(id);
            house.Policy.CanRealTime = input.CanRealTime;
            _manageHouseRepository.Update(house);
            _manageHouseRepository.SaveChange();
            return input;
        }

        public CheckTimeInput UpdateCheckTime(string id, CheckTimeInput input)
        {
            var house = _manageHouseRepository.Get(id);
            house.Policy.CheckinTime = Convert.ToDateTime(input.CheckinTime);
            house.Policy.CheckoutTime = Convert.ToDateTime(input.CheckoutTime);
            _manageHouseRepository.Update(house);
            _manageHouseRepository.SaveChange();
            return input;
        }

        public HouseOtherInput UpdateOthers(string id, HouseOtherInput input)
        {
            var house = _manageHouseRepository.Get(id);
            house.HouseRule.Other = input.Other;
            _manageHouseRepository.Update(house);
            _manageHouseRepository.SaveChange();
            return input;
        }

        public HouseRuleInput UpdateRules(string id, HouseRuleInput input)
        {
            var house = _manageHouseRepository.Get(id);
            house.HouseRule.AllowChild = input.AllowChild;
            house.HouseRule.AllowBaby = input.AllowBaby;
            house.HouseRule.AllowPet = input.AllowPet;
            house.HouseRule.AllowSmoke = input.AllowSmoke;
            house.HouseRule.AllowParty = input.AllowParty;
            _manageHouseRepository.Update(house);
            _manageHouseRepository.SaveChange();
            return input;
        }

        public HouseFacilityInput UpdateFacility(string id, HouseFacilityInput input)
        {
            var house = _manageHouseRepository.Get(id);
            house.ProvideFacilities = input.ProvideFacilities;
            house.NotProvideFacilities = input.NotProvideFacilities;
            _manageHouseRepository.Update(house);
            _manageHouseRepository.SaveChange();
            return input;
        }

        public HouseSpaceInput CreateSpace(string id, HouseSpaceInput input)
        {
            var house = _manageHouseRepository.Get(id);
            var space = new Space(house.Id)
            {
                HouseId = input.HouseId,
                SpaceType = (SpaceType) input.SpaceType,
                IsShared = input.IsShared
            };
            house.Spaces.Add(space);
            _manageHouseRepository.Update(house);
            _manageHouseRepository.SaveChange();
            return input;
        }

        public HouseSpaceInput DeleteSpace(string id, HouseSpaceInput input)
        {
            var house = _manageHouseRepository.Get(id);
            var deleteObj = house.Spaces.LastOrDefault(x => (int) x.SpaceType == input.SpaceType);
            house.Spaces.Remove(deleteObj);
            _manageHouseRepository.Update(house);
            _manageHouseRepository.SaveChange();
            return input;
        }

        public BedroomDetailInput CreateBedroomDetail(string id, BedroomDetailInput input)
        {
            var house = _manageHouseRepository.Get(id);
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
            _manageHouseRepository.Update(house);
            _manageHouseRepository.SaveChange();
            return input;
        }

        public BedroomDetailInput UpdateBedroomDetail(string id, BedroomDetailInput input)
        {
            var house = _manageHouseRepository.Get(id);
            var updateObj = _manageHouseRepository.GetBedroom().FirstOrDefault(y => y.SpaceId == input.SpaceId && (int) y.BedType == input.BedType);
            updateObj.BedCount = (int) input.BedCount;
            updateObj.HasIndependentBath = (bool) input.HasIndependentBath;
            _manageHouseRepository.Update(house);
            _manageHouseRepository.SaveChange();
            return input;
        }
    }
}