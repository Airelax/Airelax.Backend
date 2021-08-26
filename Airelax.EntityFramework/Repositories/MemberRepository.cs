using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Airelax.Domain.DomainObject;
using Airelax.Domain.Members;
using Airelax.Domain.RepositoryInterface;
using Lazcat.Infrastructure.DependencyInjection;
using Lazcat.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Airelax.EntityFramework.Repositories
{
    [DependencyInjection(typeof(IMemberRepository))]
    public class MemberRepository : IMemberRepository
    {
        private readonly IRepository _repository;

        public MemberRepository(IRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<Member> GetAll()
        {
            return _repository.GetAll<string, Member>().Where(x => !x.IsDeleted);
        }

        public async Task<Member> GetAsync(Expression<Func<Member, bool>> exp)
        {
            var memberIncludeAll = await (from m in _repository.GetAll<string, Member>().Where(exp)
                from memberInfo in _repository.GetAll<string, MemberInfo>().Where(x => x.Id == m.Id).DefaultIfEmpty()
                from memberLogInfo in _repository.GetAll<string, MemberLoginInfo>().Where(x => x.Id == m.Id).DefaultIfEmpty()
                where !m.IsDeleted
                select new {Member = m, MemberInfo = memberInfo, MemberLoginInfo = memberLogInfo}).FirstOrDefaultAsync();

            if (memberIncludeAll?.Member == null) return null;
            
            var member = memberIncludeAll.Member;
            var wishLists = await _repository.GetAll<int, WishList>().Where(x => x.MemberId == member.Id).ToListAsync();
            wishLists ??= new List<WishList>();
            member.WishLists = wishLists;
            member.MemberInfo = memberIncludeAll.MemberInfo;
            member.MemberLoginInfo = memberIncludeAll.MemberLoginInfo;

            return member;
        }

        public async Task CreateAsync(Member item)
        {
            await _repository.CreateAsync<string, Member>(item);
        }

        public async Task UpdateAsync(Member item)
        {
            await _repository.UpdateAsync<string, Member>(item);
        }

        public async Task DeleteAsync(Member item)
        {
            await _repository.DeleteAsync<string, Member>(item);
        }

        public async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }
        
    }
}