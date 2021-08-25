﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airelax.EntityFramework.DbContexts;
using Airelax.Domain.Houses;
using Microsoft.EntityFrameworkCore;
using Lazcat.Infrastructure.DependencyInjection;
using Airelax.Application.Houses.Dtos.Response;
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

        public string GetSpace(string id)
        {
            var x = from h in _context.Houses
                    from s in _context.Spaces.Where(x => x.HouseId == h.Id).DefaultIfEmpty()
                    from b in _context.BedroomDetails.Where(x => x.SpaceId == s.Id).DefaultIfEmpty()
                    where h.Id == id
                    select new SpaceBed
                    {
                        SpaceVM = new SpaceVM
                        {
                            Id = s.Id,
                            HouseId = s.HouseId,
                            SpaceType = (int)s.SpaceType,
                            IsShared = s.IsShared
                        },
                        BedroomDetailVM = new BedroomDetailVM
                        {
                            BedCount = b.BedCount,
                            BedType = (int)b.BedType,
                            SpaceId = b.SpaceId,
                            HasIndependentBath = b.HasIndependentBath
                        }
                    };
            var space = x.ToList();
            string jsonString = JsonConvert.SerializeObject(space);
            return jsonString;
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
