﻿using System;
using System.Linq.Expressions;

namespace Airelax.Domain.DomainObject
{
    public abstract class Specification<T> : ISpecification<T>
    {
        public abstract bool IsSatisfy(T obj);

        public ISpecification<T> And(ISpecification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }

        public ISpecification<T> Or(ISpecification<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }

        public ISpecification<T> Not(ISpecification<T> specification)
        {
            return new NotSpecification<T>(specification);
        }
        

    }
}