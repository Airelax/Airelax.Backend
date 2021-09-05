using System.Collections.Generic;
using Airelax.Domain.Houses;

namespace Airelax.Domain.RepositoryInterface
{
    public interface IMyHousesRepository
    {
        List<House> GetHousesByOwnerId(string ownerId);
    }
}