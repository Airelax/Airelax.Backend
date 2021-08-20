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
        public string Title { get; set; }
        public IEnumerable<string> Pictures { get; set; }
        public DescriptionDto Description { get; set; }
        public HouseStatus Status { get; set; }
        public List<Facility> ProvideFacilities { get; set; }
        public List<Facility> NotProvideFacilities { get; set; }
        public AddressDto Address { get; set; }
        public HouseCategoryVM HouseCategory { get; set; }
        public SpaceDto Space { get; set; }
        public PriceDto Price { get; set; }
        public string Fee { get; set; }
        public CancelPolicy Cancel { get; set; }
        public bool InstanceBooking { get; set; }
        public HouseRuleDto HouseRule { get; set; }
    }
}
