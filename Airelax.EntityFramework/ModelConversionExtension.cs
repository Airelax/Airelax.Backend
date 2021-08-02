using System;
using System.Linq.Expressions;
using Airelax.Domain.DomainObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace Airelax.EntityFramework
{
    public static class ModelConversionExtension
    {
        public static PropertyBuilder<T> HasJsonConversion<T>(this PropertyBuilder<T> propertyBuilder)
        {
            var converter = new ValueConverter<T, string>
            (
                value => JsonConvert.SerializeObject(value),
                value => JsonConvert.DeserializeObject<T>(value)
            );

            var comparer = new ValueComparer<T>
            (
                (l, r) => JsonConvert.SerializeObject(l) == JsonConvert.SerializeObject(r),
                v => v == null ? 0 : JsonConvert.SerializeObject(v).GetHashCode(),
                v => JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(v))
            );

            propertyBuilder.HasConversion(converter);
            propertyBuilder.Metadata.SetValueConverter(converter);
            propertyBuilder.Metadata.SetValueComparer(comparer);
            propertyBuilder.HasColumnType("jsonb");

            return propertyBuilder;
        }

        public static PropertyBuilder<TProp> SetEnumDbMapping<T, TProp>(this EntityTypeBuilder<T> builder,
            Expression<Func<T, TProp>> propSelector) where T : class where TProp : Enum
        {
            return builder.Property(propSelector).HasConversion(
                v => Convert.ToInt32(v), v => (TProp) (object) v);
        }

        public static PropertyBuilder<TProp> SetPropMaxLength<T, TProp>(this EntityTypeBuilder<T> builder, Expression<Func<T, TProp>> propSelector, 
            int maxLength) where T : class
        {
            return builder.Property(propSelector).HasMaxLength(maxLength);
        }

        public static void SetZeroEntityKey<TEntity,TId>(this EntityTypeBuilder<TEntity> builder) where TEntity : Entity<TId>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever().IsRequired();
        }
        
        public static void SetEntityKey<TEntity,TId>(this EntityTypeBuilder<TEntity> builder) where TEntity : Entity<TId>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().UseIdentityColumn();
        }
        
        // public static ReferenceReferenceBuilder SetZeroToOneRelation<TZero, TOne, TRelationEntity>(this EntityTypeBuilder<TZero> entityTypeBuilder,
        //     Expression<Func<TOne, TRelationEntity>> navigationExpression, Expression<Func<TOne, object>> foreignKeyExpression)
        //     where TZero : class where TOne : class
        // {
        //     entityTypeBuilder.HasOne<TOne>().WithOne(navigationExpression).HasForeignKey<TZero>(foreignKeyExpression);
        // }
    }
}