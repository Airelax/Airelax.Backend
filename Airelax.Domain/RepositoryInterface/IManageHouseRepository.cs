using System.Collections.Generic;
using Airelax.Domain.Houses;
using Microsoft.EntityFrameworkCore;

namespace Airelax.Domain.RepositoryInterface
{
    public interface IManageHouseRepository
    {
        void Delete(House house);
        House Get(string id);
        List<SpaceBed> GetSpace(string id);
        void SaveChange();
        void Update(House house);
        void CreateBedroom(BedroomDetail bedroom);
        DbSet<BedroomDetail> GetBedroom();
    }
}