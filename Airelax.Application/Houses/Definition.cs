using System.Collections.Generic;
using Airelax.Domain.Houses.Defines;

namespace Airelax.Application.Houses
{
    public static class Definition
    {
        public static IEnumerable<Facility> SimpleFacilities { get; }
            = new List<Facility> {Facility.Kitchen, Facility.AirConditioner, Facility.Wifi, Facility.WashMachine};
        
        
        public struct ChtMapping
        {
            public static readonly Dictionary<Category, string> HouseCategory = new()
            {
                {Category.Apartment, "公寓"},
                {Category.House, "獨棟房屋"},
                {Category.SecondaryUnit, "附屬建築"},
                {Category.UniqueSpace, "獨特房源"},
                {Category.BreakAndBreakfast, "家庭式旅館"},
                {Category.BoutiqueHotel, "精品旅館"}
            };
        }
    }
}