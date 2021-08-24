using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airelax.Domain.Houses.Defines;

namespace Airelax.Application.Houses.Dtos.Response
{
    public class ManageDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<string> Pictures { get; set; }
        public DescriptionDto Description { get; set; }
        public int Status { get; set; }
        public List<int> ProvideFacilities { get; set; }
        public List<int> NotProvideFacilities { get; set; }
        public AddressDto Address { get; set; }
        public HouseCategoryVM HouseCategory { get; set; }
        public SpaceDto Space { get; set; }
        public string Origin { get; set; }
        public string SweetPrice { get; set; }
        public string Fee { get; set; }
        public int Cancel { get; set; }
        public bool InstanceBooking { get; set; }
        public string CheckinTime { get; set; }
        public string CheckoutTime { get; set; }
        public string CashPledge { get; set; }
        public HouseRuleDto HouseRule { get; set; }
        public ManageSpace ManageSpaces { get; set; }
    }

    public class ManageSpace
    {
        public string HouseId { get; set; }
        public int SpaceType { get; set; }
        public bool IsShared { get; set; }
    }
}
