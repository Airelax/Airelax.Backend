using Airelax.Domain.Houses;
using Airelax.Domain.RepositoryInterface;
using Airelax.EntityFramework.DbContexts;
using Lazcat.Infrastructure.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Airelax.EntityFramework.Repositories 
{
    [DependencyInjection(typeof(IHouseRepository), Lifetime = ServiceLifetime.Scoped)]
    
    public class HouseRepository : IHouseRepository
    {
        private readonly AirelaxContext _context;
        public HouseRepository(AirelaxContext context)
        {
            _context = context;
        }
        public Task CreateAsync(House item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<House> FirstOrDefaultAsync(Expression<Func<House, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public IQueryable<House> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<House>  GetAsync(int id)
        {
            return await _context.Houses.FindAsync(id);

        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(House item)
        {
            throw new NotImplementedException();
        }
    }
}
