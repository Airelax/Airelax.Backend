using System.Collections.Generic;
using Airelax.Application.Houses.Dtos.Response;
using Airelax.Domain.Houses;
using Microsoft.EntityFrameworkCore;

namespace Airelax
{
    public interface IManageHouseRepository
    {
        void Delete(House house);
        House Get(string id);
        string GetSpace(string id);
        void SaveChange();
        void Update(House house);
        void CreateBedroom(BedroomDetail bedroom);
        DbSet<BedroomDetail> GetBedroom();
    }
}