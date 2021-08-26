using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airelax.EntityFramework.DbContexts;
using Airelax.Domain.Houses;
using Microsoft.EntityFrameworkCore;
using Lazcat.Infrastructure.DependencyInjection;
using Airelax.Application.Houses.Dtos.Response;
using Lazcat.Infrastructure.Extensions;
using Newtonsoft.Json;

namespace Airelax
{
    [DependencyInjection(typeof(IManageHouseRepository))]
    public class ManageHouseRepository : IManageHouseRepository
    {
        private readonly AirelaxContext _context;

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

        public List<SpaceBed> GetSpace(string id)
        {
            var spaceBeds = from h in _context.Houses
                from s in _context.Spaces.Where(x => x.HouseId == h.Id)
                from b in _context.BedroomDetails.Where(x => x.SpaceId == s.Id).DefaultIfEmpty()
                where h.Id == id
                select new SpaceBed
                {
                    Space = s,
                    BedroomDetail = b
                };
            
            var space = spaceBeds?.ToList();
            return space;
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

        public void CreateBedroom(BedroomDetail bedroom)
        {
            _context.Add(bedroom);
        }

        public DbSet<BedroomDetail> GetBedroom()
        {
            return _context.BedroomDetails;
        }
    }
}