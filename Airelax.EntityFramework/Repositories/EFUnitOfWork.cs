using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Airelax.Domain.DomainObject;
using Airelax.Domain.RepositoryInterface;
using Airelax.EntityFramework.DbContexts;
using Lazcat.Infrastructure.Common.Abstractions;

namespace Airelax.EntityFramework.Repositories
{
    public class EFUnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AirelaxContext _context;
        private ConcurrentDictionary<string, object> _repositories;
        private readonly IActivator _activator;
        private bool _disposed;

        public EFUnitOfWork(AirelaxContext context, IActivator activator)
        {
            _context = context;
            _activator = activator;
            _repositories = new ConcurrentDictionary<string, object>();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IRepository<TId, TEntity> GetRepository<TId, TEntity>() where TEntity : Entity<TId>
        {
            _repositories ??= new ConcurrentDictionary<string, object>();
            var type = typeof(TEntity).Name;

            if (_repositories.ContainsKey(type)) return (EFRepository<TId, TEntity>) _repositories[type];

            var repository = _activator.CreateInstanceByContainer(typeof(EFRepository<,>).MakeGenericType(typeof(TId), typeof(TEntity)));
            _repositories.TryAdd(type, repository);

            return (EFRepository<TId, TEntity>) _repositories[type];
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }
    }
}