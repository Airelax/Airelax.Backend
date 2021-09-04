using Airelax.Domain.Houses;
using System.Collections.Generic;

namespace Airelax
{
    public interface IMyHousesRepository
    {
        List<House> GetHousesByOwnerId(string ownerId);
    }
}