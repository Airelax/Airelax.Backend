using System.Threading.Tasks;
using Airelax.Application.Houses.Dtos.Response;

namespace Airelax.Application.Trips
{
    public interface ITripService
    {
        Task<TripViewModels> GetTripViewModel();
    }
}