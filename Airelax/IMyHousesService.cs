using System.Collections.Generic;

namespace Airelax
{
    public interface IMyHousesService
    {
        IEnumerable<MyHouseViewModel> GetMyHouseViewModel(string OwnerId);
    }
}