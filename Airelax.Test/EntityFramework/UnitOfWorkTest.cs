using Airelax.Domain.DomainObject;
using Airelax.Domain.RepositoryInterface;
using Airelax.EntityFramework.DbContexts;
using Airelax.EntityFramework.Repositories;
using Lazcat.Infrastructure.Common.Abstractions;
using NSubstitute;
using Shouldly;
using Xunit;

namespace Airelax.Test.EntityFramework
{
    public class UnitOfWorkTest
    {
        private readonly IActivator _activator;
        private readonly AirelaxContext _context = null;
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkTest()
        {
            //_context = Substitute.For<AirelaxContext>(Substitute.For<DbContextOptions<AirelaxContext>>());
            _activator = Substitute.For<IActivator>();
            _unitOfWork = new EFUnitOfWork(_context, _activator);
        }

        [Fact]
        public void GetRepository_Test()
        {
            _activator.CreateInstanceByContainer(typeof(EFGenericRepository<,>).MakeGenericType(typeof(int), typeof(TestEntity))).Returns(new EFGenericRepository<int, TestEntity>(_context));
            var repository = _unitOfWork.GetRepository<int, TestEntity>();
            var repositoryType = repository.GetType();
            var types = repositoryType.GetGenericArguments();
            Assert.True(repository is EFGenericRepository<int, TestEntity>);
            types.ShouldContain(typeof(int));
            types.ShouldContain(typeof(TestEntity));
            repositoryType.IsGenericType.ShouldBe(true);
        }

        private class TestEntity : Entity<int>
        {
        }
    }
}