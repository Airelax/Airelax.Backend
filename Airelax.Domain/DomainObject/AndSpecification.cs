﻿namespace Airelax.Domain.DomainObject
{
    public class AndSpecification<T>: Specification<T>
    {
        private readonly ISpecification<T> _leftSpecification;
        private readonly ISpecification<T> _rightSpecification;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)  {
            _leftSpecification = left;
            _rightSpecification = right;
        }

        public override bool IsSatisfy(T o)   {
            return _leftSpecification.IsSatisfy(o) 
                   && _rightSpecification.IsSatisfy(o);
        }
    }
}