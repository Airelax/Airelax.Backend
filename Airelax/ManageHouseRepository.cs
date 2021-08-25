using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airelax.EntityFramework.DbContexts;
using Airelax.Domain.Houses;
using Microsoft.EntityFrameworkCore;
using Lazcat.Infrastructure.DependencyInjection;

namespace Airelax
{
    [DependencyInjection(typeof(IManageHouseRepository))]
    public class ManageHouseRepository : IManageHouseRepository
    {
        public readonly AirelaxContext _context;

        public ManageHouseRepository(AirelaxContext context)
        {
            _context = context;
        }

        public House Get(string id)
        {
            return _context.Houses.Include(x => x.HouseDescription)
                .Include(x => x.HouseLocation)
                .Include(x => x.HouseCategory)
                .Include(x => x.HousePrice)
                .Include(x => x.HouseRule)
                .Include(x => x.Policy)
                .Include(x => x.Spaces)
                .Where(x => x.IsDeleted == false)
                .FirstOrDefault(x => x.Id == id);
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }

        public void Delete(House house)
        {
            house.IsDeleted = true;
            Update(house);
        }

        public void Update(House house)
        {
            _context.Update(house);
        }
    }
}
