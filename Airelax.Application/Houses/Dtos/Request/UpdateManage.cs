using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airelax.Application.Houses.Dtos.Response;
using Airelax.Domain.Houses.Defines;

namespace Airelax.Application.Houses.Dtos.Request
{
    public class UpdateManage
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public List<string> Pictures { get; set; }
        public DescriptionDto Description { get; set; }
        public int? CustomerNumber { get; set; }
        public int? Status { get; set; }
        public List<int> ProvideFacilities { get; set; }
        public List<int> NotProvideFacilities { get; set; }
        public AddressDto Address { get; set; }
        public HouseCategoryVM HouseCategory { get; set; }
        public SpaceDto Space { get; set; }
        public string Origin { get; set; }
        public string SweetPrice { get; set; }
        public string Fee { get; set; }
        public int? Cancel { get; set; }
        public bool? InstanceBooking { get; set; }
        public string CheckinTime { get; set; }
        public string CheckoutTime { get; set; }
        public string CashPledge { get; set; }
        public HouseRuleDto HouseRule { get; set; }
    }

    public class UpdateTime
    {
        public string CheckinTime { get; set; }
        public string CheckoutTime { get; set; }
    }

    public class UpdatePrice
    {
        public decimal Origin { get; set; }
        public decimal? SweetPrice { get; set; }
        public decimal? CashPledge { get; set; }
    }

    public class UpdateAllow
    {
        public bool? AllowChild { get; set; }
        public bool? AllowBaby { get; set; }
        public bool? AllowPet { get; set; }
        public bool? AllowSmoke { get; set; }
        public bool? AllowParty { get; set; }
    }

    public class UpdateFacility
    {
        public List<Facility> ProvideFacilities { get; set; }
        public List<Facility> NotProvideFacilities { get; set; }
    }
}
