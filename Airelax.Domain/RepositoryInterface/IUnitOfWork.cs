using System.Threading.Tasks;
using Airelax.Domain.DomainObject;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Airelax.Domain.RepositoryInterface
{
    public interface IUnitOfWork
    {
        Task SaveAsync();

        IRepository<TId, TEntity> GetRepository<TId, TEntity>() where TEntity : Entity<TId>;
    }
}