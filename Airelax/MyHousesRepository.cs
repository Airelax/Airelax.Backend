using Airelax.Domain.Houses;
using Airelax.EntityFramework.DbContexts;
using Lazcat.Infrastructure.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax
{
    [DependencyInjection(typeof(IMyHousesRepository))]
    public class MyHousesRepository : IMyHousesRepository
    {
        private readonly AirelaxContext _context;
        public MyHousesRepository(AirelaxContext context)
        {
            _context = context;
        }

        public List<House> GetHousesByOwnerId(string ownerId)
        {
            return _context.Houses.Include(x => x.HouseLocation)
                           .Include(x => x.Policy)
                           .Include(x => x.ReservationRule)
                           .Include(x => x.Photos)
                           .Where(x => x.OwnerId == ownerId)// && !x.IsDeleted)
                           .ToList();

        }

    }
}
