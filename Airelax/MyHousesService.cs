using Airelax.Domain.Houses.Defines;
using Lazcat.Infrastructure.DependencyInjection;
using Lazcat.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax
{
    [DependencyInjection(typeof(IMyHousesService))]
    public class MyHousesService : IMyHousesService
    {
        private readonly IMyHousesRepository _myHousesRepository;
        public MyHousesService(IMyHousesRepository myHousesRepository)
        {
            _myHousesRepository = myHousesRepository;
        }
        public IEnumerable<MyHouseViewModel> GetMyHouseViewModel(string OwnerId)
        {
            var myhouses = _myHousesRepository.GetHousesByOwnerId(OwnerId);

            if (myhouses.IsNullOrEmpty())
                return new List<MyHouseViewModel>() {
                    new MyHouseViewModel
                    {
                        Title = "傑哥的房子",
                        HouseStatus = HouseStatus.Publish,
                        CreateState = CreateState.Building,
                        CanRealTime = false,
                        Location = "竹北，新竹",
                        LastReservationTime = DateTime.Now.ToString("yyyy-MM-dd")
                    },
                     new MyHouseViewModel
                    {
                        Title = "傑哥的房子",
                        HouseStatus = HouseStatus.Publish,
                        CreateState = CreateState.Building,
                        CanRealTime = false,
                        Location = "竹北，新竹",
                        LastReservationTime = DateTime.Now.ToString("yyyy-MM-dd")
                     },
                      new MyHouseViewModel
                    {
                        Title = "我房間的標題超級無敵超窩窩窩窩窩窩喔窩窩窩窩窩窩窩窩窩窩窩窩窩窩窩窩窩窩窩窩窩窩窩窩窩窩窩窩窩窩窩窩窩",
                        HouseStatus = HouseStatus.Publish,
                        CreateState = CreateState.Completed,
                        CanRealTime = false,
                        Location = "竹北，新竹",
                        LastReservationTime =DateTime.Now.ToString("yyyy-MM-dd")
                    },
                       new MyHouseViewModel
                    {
                        
                        Title = "傑哥的房子",
                        HouseStatus = HouseStatus.Publish,
                        CreateState = CreateState.Building,
                        CanRealTime = false,
                        Location = "竹北，新竹",
                        LastReservationTime =DateTime.Now.ToString("yyyy-MM-dd")
                    }

                };

            var myhouseViewModel = myhouses.Select(x => new MyHouseViewModel()
            {
                HouseId = x.Id,
                Title = x.Title,
                HouseStatus = x.Status,
                CreateState = x.CreateState,
                CanRealTime = x.Policy.CanRealTime,
                Location = $"{x.HouseLocation.City},{ x.HouseLocation.Country }",
                LastReservationTime = x.ReservationRule.LastReservationTime.ToString("yyyy-MM-dd")
            });

            return null;
        }

    }
}
