using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Airelax.Domain.DomainObject;
using Airelax.Domain.RepositoryInterface;
using Airelax.EntityFramework.DbContexts;
using Lazcat.Infrastructure.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Airelax.EntityFramework.Repositories
{
    [DependencyInjection(typeof(IRepository<,>))]
    public class EFRepository<TId, TEntity>: IRepository<TId, TEntity> where TEntity : Entity<TId>
    {
        private readonly AirelaxContext _context;

        public EFRepository(AirelaxContext context)
        {
            _context = context;
        }
        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(TId id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> exp)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(exp);
        }

        public async Task CreateAsync(TEntity item)
        {
            await _context.Set<TEntity>().AddAsync(item);
        }

        public async Task UpdateAsync(TEntity item)
        {
            _context.Set<TEntity>().Update(item);
        }

        public async Task DeleteAsync(TEntity item)
        {
            _context.Set<TEntity>().Remove(item);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}