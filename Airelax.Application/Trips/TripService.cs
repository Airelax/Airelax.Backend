using System;
using System.Linq;
using System.Threading.Tasks;
using Airelax.Application.Account;
using Airelax.Application.Houses.Dtos.Response;
using Airelax.Domain.RepositoryInterface;
using Lazcat.Infrastructure.DependencyInjection;

namespace Airelax.Application.Trips
{
    [DependencyInjection(typeof(ITripService))]
    public class TripService : ITripService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IAccountService _accountService;

        public TripService(IOrderRepository orderRepository, IAccountService accountService)
        {
            _orderRepository = orderRepository;
            _accountService = accountService;
        }
        public async Task<TripViewModels> GetTripViewModel()
        {
            var memberId = _accountService.GetAuthMemberId();
            var trips = await _orderRepository.GetTrips(memberId);

            var t = trips.Select(x => new TripViewModel
            {
                OrderId = x.Id,
                StartDate = x.OrderDetail.StartDate,
                EndDate = x.OrderDetail.EndDate,
                Image = x.House.Photos.Select(y => y.Image).FirstOrDefault(),                
                Town = x.House.HouseLocation.Town,
                Title = x.House.Title
            });


            return new TripViewModels()
            {
                FinishedTrips = t.Where(x => x.EndDate > DateTime.Now),
                UpcomingTrips = t.Where(x => x.EndDate <= DateTime.Now)
            };
        }



    }
}
