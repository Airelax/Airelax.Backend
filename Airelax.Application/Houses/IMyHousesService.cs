using System.Collections.Generic;
using Airelax.Application.Houses.Dtos.Response;

namespace Airelax.Application.Houses
{
    public interface IMyHousesService
    {
        IEnumerable<MyHouseViewModel> GetMyHouseViewModel(string ownerId);
    }
}