using System.Linq;
using Airelax.Domain.Houses;
using Airelax.Domain.Members;
using Airelax.Domain.RepositoryInterface;
using Airelax.EntityFramework.DbContexts;
using Lazcat.Infrastructure.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Airelax.EntityFramework.Repositories
{
    [DependencyInjection(typeof(IWishListRepository))]
    public class WishListRepository : IWishListRepository
    {
        private readonly AirelaxContext _context;

        public WishListRepository(AirelaxContext context)
        {
            _context = context;
        }

        public Member GetMember(string memberId)
        {
            return _context.Members.Include(m => m.WishLists)
                .FirstOrDefault(m => m.Id == memberId && !m.IsDeleted);
        }

        public House GetHouses(string houseId)
        {
            return _context.Houses.Include(w => w.Photos)
                .FirstOrDefault(w => w.Id == houseId);
        }

        public WishList GetWishList(int wishId)
        {
            return _context.WishLists.FirstOrDefault(x => x.Id == wishId);
        }

        public void Add(WishList wishList)
        {
            _context.WishLists.Add(wishList);
        }

        public void Remove(WishList wishList)
        {
            _context.WishLists.Remove(wishList);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}