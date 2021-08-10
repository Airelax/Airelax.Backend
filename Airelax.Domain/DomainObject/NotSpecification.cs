namespace Airelax.Domain.DomainObject
{
    public class NotSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> _specification;

        public NotSpecification(ISpecification<T> specification)
        {
            _specification = specification;
        }

        public override bool IsSatisfy(T o)
        {
            return !_specification.IsSatisfy(o);
        }
    }
}