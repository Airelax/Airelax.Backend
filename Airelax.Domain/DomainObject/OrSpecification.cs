﻿namespace Airelax.Domain.DomainObject
{
    public class OrSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> _leftSpecification;
        private readonly ISpecification<T> _rightSpecification;

        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _leftSpecification = left;
            _rightSpecification = right;
        }

        public override bool IsSatisfy(T o)
        {
            return _leftSpecification.IsSatisfy(o)
                   || _rightSpecification.IsSatisfy(o);
        }
    }
}