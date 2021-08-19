using Airelax.Domain.Houses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airelax.Domain.DomainObject;

namespace Airelax.Domain.RepositoryInterface
{
    public interface IHouseRepository: IGenericRepository<string , House>
    {
        IQueryable<House> GetSatisfyFromAsync(Specification<House> specification);
    }
}
