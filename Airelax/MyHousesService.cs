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
                return new List<MyHouseViewModel>();
            
            var myhouseViewModel = myhouses.Select(x => new MyHouseViewModel()
            {
                Title = x.Title,
                HouseStatus = x.Status,
                CreateState = x.CreateState,
                CanRealTime = x.Policy.CanRealTime,
                Location = $"{x.HouseLocation.City},{ x.HouseLocation.Country }",
                LastReservationTime = x.ReservationRule.LastReservationTime
            });

            return myhouseViewModel;
        }

    }
}
