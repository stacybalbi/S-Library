using System;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using SLibrary.Core.Base;

namespace SLibrary.DataModel.Context.Extensions
{
	public static class EntityFrameworkExtensions
	{
        public static void SetSoftDeleteFilter(this ModelBuilder modelBuilder, Type entityType)
        {
            SetSoftDeleteFilterMethod.MakeGenericMethod(entityType)
                .Invoke(null, new object[] { modelBuilder });
        }

        static readonly MethodInfo SetSoftDeleteFilterMethod = typeof(EntityFrameworkExtensions)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Single(t => t.IsGenericMethod && t.Name == "SetSoftDeleteFilter");

        public static void SetSoftDeleteFilter<TEntity>(this ModelBuilder modelBuilder) where TEntity : EntityBase
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(e => !e.Deleted);
        }
    }
}

