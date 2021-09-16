using Airelax.Application.Houses.Dtos.Response;
using System.Threading.Tasks;

namespace Airelax
{
    public interface ITripService
    {
        Task<TripViewModels> GetTripViewModel();
    }
}