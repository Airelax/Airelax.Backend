﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Airelax.Domain.Houses;
using Airelax.Domain.RepositoryInterface;
using Airelax.EntityFramework.DbContexts;
using Lazcat.Infrastructure.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Airelax.EntityFramework.Repositories
{
    [DependencyInjection(typeof(IHouseRepository))]
    public class HouseRepository : IHouseRepository
    {
        private readonly AirelaxContext _context;
        private readonly IRepository _repository;

        public HouseRepository(AirelaxContext context, IRepository repository)
        {
            _context = context;
            _repository = repository;
        }


        public IQueryable<House> GetAll()
        {
            return _repository.GetAll<string, House>().Where(x=>x.IsDeleted==false);
        }

        public async Task<House> GetAsync(Expression<Func<House, bool>> exp)
        {
            return await GetHouseIncludeAll()
                .Where(x => x.IsDeleted == false)
                .FirstOrDefaultAsync(exp);
        }

        public async Task CreateAsync(House item)
        {
            await _repository.CreateAsync<string, House>(item);
        }

        public async Task UpdateAsync(House item)
        {
            await _repository.UpdateAsync<string, House>(item);
        }

        public async Task DeleteAsync(House item)
        {
            item.IsDeleted = true;
            await UpdateAsync(item);
        }

        public async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }


        private IIncludableQueryable<House, ReservationRule> GetHouseIncludeAll()
        {
            return _context.Houses.Include(x => x.Comments)
                .Include(x => x.Member)
                .ThenInclude(x => x.WishLists)
                .Include(x => x.Photos)
                .Include(x => x.Policy)
                .Include(x => x.Spaces)
                .Include(x => x.HouseCategory)
                .Include(x => x.HouseDescription)
                .Include(x => x.HousePrice)
                .Include(x => x.HouseLocation)
                .Include(x => x.HouseRule)
                .Include(x => x.ReservationRule);
        }
    }
}