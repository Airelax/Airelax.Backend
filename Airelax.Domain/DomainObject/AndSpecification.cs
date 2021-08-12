﻿using System;
using System.Linq.Expressions;

namespace Airelax.Domain.DomainObject
{
    public class AndSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _leftSpecification;
        private readonly Specification<T> _rightSpecification;

        public AndSpecification(Specification<T> left, Specification<T> right)
        {
            _leftSpecification = left;
            _rightSpecification = right;
        }

        public override bool IsSatisfy(T o)
        {
            return _leftSpecification.IsSatisfy(o)
                   && _rightSpecification.IsSatisfy(o);
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var left = _leftSpecification.ToExpression();
            var body = Expression.AndAlso(left.Body, _rightSpecification.ToExpression().Body);
            return Expression.Lambda<Func<T, bool>>(body, left.Parameters[0]);
        }
    }
}