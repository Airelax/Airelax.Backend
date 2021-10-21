using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Airelax.Application.Account;
using Airelax.Application.Houses.Dtos.Response;
using Airelax.Domain.RepositoryInterface;
using Lazcat.Infrastructure.DependencyInjection;
using Lazcat.Infrastructure.ExceptionHandlers;

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

        public async Task<TripViewModels> GetTrips()
        {
            var memberId = _accountService.GetAuthMemberId();
            var trips = await _orderRepository.GetTrips(x => x.CustomerId == memberId);

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


        public async Task<TripDetail> GetTripDetail(string id)
        {
            var order = (await _orderRepository.GetTrips(x => x.Id == id)).FirstOrDefault();
            if(order == null) throw ExceptionBuilder.Build(HttpStatusCode.BadRequest, "order not found");
            var trip = new TripDetail
            {
                Id = order.Id,
                Title = order.House.Title,
                Image = order.House.Photos.Select(y => y.Image).FirstOrDefault(),
                Checkin = order.OrderDetail.StartDate.ToString("yyyy年MM月dd日"),
                Checkout = order.OrderDetail.EndDate.ToString("yyyy年MM月dd日"),
                CheckinTime = order.House.Policy.CheckinTime.ToString("HH:mm"),
                CheckoutTime = order.House.Policy.CheckoutTime.ToString("HH:mm"),
                Price = order.OrderPriceDetail.Total,
                Customer = order.OrderDetail.Adult,
                Children = order.OrderDetail.Child,
                Baby = order.OrderDetail.Baby,
                Address = $"{order.House.HouseLocation.Country??""}{order.House.HouseLocation.City??""}{order.House.HouseLocation.Town??""}{order.House.HouseLocation.AddressDetail??""}",
                Lat = order.House.HouseLocation.Latitude,
                Lng = order.House.HouseLocation.Longitude,
            };
            
            return trip;
        }
    }
}