using System;
using System.Linq.Expressions;
using Base.Core.Base;
using Microsoft.EntityFrameworkCore.Query;

namespace Base.BusinessLayers.Services.Base
{
    public interface IBaseService<TModel> where TModel : class, IEntityBase, new()
    {
        IQueryable<TModel> GetAll(params Expression<Func<TModel, object>>[] includeProperties);
        IQueryable<TModel> FindBy(Expression<Func<TModel, bool>> predicate, params Expression<Func<TModel, object>>[] includeProperties);
        Task<TModel> Find(int id, params Expression<Func<TModel, object>>[] includeProperties);
        Task<OperationResult> Add(TModel value);
        Task<OperationResult> SaveAsync();
        IEnumerable<OperationResult> AddRange(IEnumerable<TModel> values);
        OperationResult Update(TModel value);
        IEnumerable<OperationResult> UpdateRange(IEnumerable<TModel> value);
        OperationResult Remove(TModel value);
        Task AddAsync(TModel entity);
        Task<TModel> GeTModelByIdAsync(int id);
        Task<bool> AnyAsync(Expression<Func<TModel, bool>> predicate);
        bool Any(Expression<Func<TModel, bool>> predicate);
        Task<IEnumerable<TModel>> GetList(Expression<Func<TModel, bool>> predicate);
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<TModel> GetAsync(Expression<Func<TModel, bool>> predicate);
        IQueryable<TModel> GetQueryable(Expression<Func<TModel, bool>> predicate);
        IQueryable<TModel> GetQueryable();
        TModel UpdateEntity(TModel entity);
        Task<bool> DeleteByIdAsync(int id);
        void DeleteByEntity(TModel entity);
        void RemoveRange(IEnumerable<TModel> entities);
        bool Commit();
        Task<bool> CommitAsync();
        Task<decimal?> SumAsync(
            Expression<Func<TModel, bool>> predicate = null
        );
        decimal? Sum(
            Expression<Func<TModel, bool>> predicate = null
        );
        Task<int> CountAsync(
            Expression<Func<TModel, bool>> predicate = null
        );
        int Count(
            Expression<Func<TModel, bool>> predicate = null
        );
        TModel First(
            Expression<Func<TModel, bool>> predicate,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
            Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null
        );
        Task<TModel> FirstAsync(
            Expression<Func<TModel, bool>> predicate,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
            Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null
        );
        TModel FirstOrDefault(
            Expression<Func<TModel, bool>> predicate,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
            Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null
        );
        Task<TModel> FirstOrDefaultAsync(
            Expression<Func<TModel, bool>> predicate,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
            Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null
        );
        TModel Single(
            Expression<Func<TModel, bool>> predicate,
            Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null
        );
        Task<TModel> SingleAsync(
            Expression<Func<TModel, bool>> predicate,
            Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null
        );
        TModel SingleOrDefault(
            Expression<Func<TModel, bool>> predicate,
            Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null
        );
        Task<TModel> SingleOrDefaultAsync(
            Expression<Func<TModel, bool>> predicate,
            Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null
        );
    }
}

