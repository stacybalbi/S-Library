using System;
using Base.Core.Base;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using System.Net;
using FluentValidation;

using Base.DataModel.Context.Extensions;

namespace Base.BusinessLayers.Services.Base
{
    public class BaseService<TModel> :
        IBaseService<TModel>
        where TModel : class, IEntityBase, new()
    {

        private readonly DbSet<TModel> _dbSet;
        private readonly DbContext _context;
        private IValidator<TModel> _validator;


        public BaseService(DbContext context, IValidator<TModel> validator, IMapper mapper)
        {
            _context = context;
            _dbSet = context.Set<TModel>();
            _validator = validator;
        }



        protected IQueryable<TModel> PrepareQuery(
            IQueryable<TModel> query,
            Expression<Func<TModel, bool>> predicate = null,
            Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
            int? take = null
        )
        {
            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = orderBy(query);

            if (take.HasValue)
                query = query.Take(Convert.ToInt32(take));

            return query;
        }

        public async Task AddAsync(TModel entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task<TModel> GeTModelByIdAsync(int id)
            => await _dbSet.FindAsync(id);

        public async Task<bool> AnyAsync(Expression<Func<TModel, bool>> predicate)
            => await _dbSet.AnyAsync(predicate);

        public bool Any(Expression<Func<TModel, bool>> predicate)
            => _dbSet.Any(predicate);

        public async Task<IEnumerable<TModel>> GetList(Expression<Func<TModel, bool>> predicate)
            => await _dbSet.Where(predicate).ToListAsync();

        public virtual async Task<IEnumerable<TModel>> GetAllAsync() => await _dbSet.ToListAsync();
        public IQueryable<TModel> FindBy(Expression<Func<TModel, bool>> predicate)
        {
            IQueryable<TModel> query = _dbSet.Where(predicate);
            return query;
        }

        public async Task<TModel> GetAsync(Expression<Func<TModel, bool>> predicate)
            => await _dbSet.Where(predicate).FirstOrDefaultAsync();

        public IQueryable<TModel> GetQueryable(Expression<Func<TModel, bool>> predicate) =>
             _dbSet.Where(predicate).AsQueryable();

        public IQueryable<TModel> GetQueryable() => _dbSet.AsQueryable();

        public TModel UpdateEntity(TModel entity)
        {
            return _context.Update(entity).Entity;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            var type = entity.GetType();
            var prop = type.GetProperty("Borrado");
            prop?.SetValue(entity, true);
            return await CommitAsync();
        }

        public void DeleteByEntity(TModel entity)
        {
            var type = entity.GetType();
            var prop = type.GetProperty("Borrado");
            prop?.SetValue(entity, true);
        }


        public void RemoveRange(IEnumerable<TModel> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public bool Commit()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                Console.Write(e);
                throw;
            }
        }


        public async Task<bool> CommitAsync()
        {

            try
            {
                var savedRegistries = await _context.SaveChangesAsync();
                bool succeeded = savedRegistries > 0;
                return succeeded;
            }
            catch (Exception e)
            {
                Console.Write(e);
                return false;
            }
        }

        public virtual async Task<OperationResult> Add(TModel entity)
        {
            var results = _validator.Validate(entity);
            if (results.IsValid)
            {
                var entry = await _dbSet.AddAsync(entity);
                return new OperationResult() { Success = true, StatusCode = HttpStatusCode.Created };
            }
            var errosMsg = results.Errors.ToMessage();
            return new OperationResult() { StatusCode = HttpStatusCode.BadRequest, Message = errosMsg };
        }

        public virtual IEnumerable<OperationResult> AddRange(IEnumerable<TModel> entityEnumerable)
        {
            foreach (var ent in entityEnumerable)
            {
                var results = _validator.Validate(ent);
                if (!results.IsValid)
                {
                    var errosMsg = results.Errors.ToMessage();
                    yield return new OperationResult() { Success = false, StatusCode = HttpStatusCode.BadRequest, Message = errosMsg };
                }
            }
            _dbSet.AddRange(entityEnumerable);
            yield return new OperationResult() { StatusCode = HttpStatusCode.Created, Success = true };
        }

        public virtual async Task<TModel> Find(int id, params Expression<Func<TModel, object>>[] includeProperties)
        {
            IQueryable<TModel> query = _dbSet.AsQueryable();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual IQueryable<TModel> FindBy(Expression<Func<TModel, bool>> predicate, params Expression<Func<TModel, object>>[] includeProperties)
        {
            IQueryable<TModel> query = _dbSet.Where(predicate);
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsNoTracking();
        }

        public virtual IQueryable<TModel> GetAll(params Expression<Func<TModel, object>>[] includeProperties)
        {
            IQueryable<TModel> query = _dbSet.AsQueryable();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public virtual OperationResult Remove(TModel entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            entity.Deleted = true;
            dbEntityEntry.State = EntityState.Modified;
            return new OperationResult() { StatusCode = HttpStatusCode.OK, Success = true };
        }

        public virtual OperationResult Update(TModel entity)
        {
            var results = _validator.Validate(entity);
            if (results.IsValid)
            {
                this.ModifyInnerEntities(entity);

                _context.Entry(entity).State = EntityState.Modified;

                return new OperationResult() { StatusCode = HttpStatusCode.OK, Success = true };
            }
            return new OperationResult() { Success = false, StatusCode = HttpStatusCode.BadRequest, Message = results.Errors.ToMessage() };
        }

        public virtual IEnumerable<OperationResult> UpdateRange(IEnumerable<TModel> value)
        {
            foreach (var entity in value)
            {
                yield return this.Update(entity);
            }
        }

        private void ModifyInnerEntities(IEntityBase entity)
        {
            Type entityType = entity.GetType();

            foreach (var prop in entityType.GetProperties())
            {
                var value = prop.GetValue(entity);
                if (value != null)
                {
                    if (value is IEnumerable<IEntityBase>)
                    {
                        foreach (IEntityBase v in value as System.Collections.IEnumerable)
                        {
                            this.AssignEntityStateUpdate(v);
                        }
                    }
                    else if (value is IEntityBase)
                    {
                        this.AssignEntityStateUpdate(value as IEntityBase);
                    }
                }
            }
        }

        private void AssignEntityStateUpdate(IEntityBase obj)
        {
            try
            {
                if (_context.ChangeTracker.Entries().Any(e => e.Entity == obj)) return;
                _context.Entry(obj).State = obj.Id > 0 ? EntityState.Modified : EntityState.Added;
                this.ModifyInnerEntities(obj);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public virtual async Task<OperationResult> SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return new OperationResult() { Success = true, StatusCode = HttpStatusCode.InternalServerError };
            }
            catch (DbUpdateException ex)
            {
                return new OperationResult() { Message = ex.Message, StatusCode = HttpStatusCode.InternalServerError };
                //Log the error (uncomment ex variable name and write a log.)
                //ModelState.AddModelError("", "Unable to save changes. " +
                //"Try again, and if the problem persists, " +
                // "see your system administrator.");
            }
        }

        public virtual async Task<decimal?> SumAsync(
            Expression<Func<TModel, bool>> predicate = null
        )
        {
            var query = _context.Set<TModel>().AsQueryable();

            query = PrepareQuery(query, predicate);

            return await ((IQueryable<decimal?>)query).SumAsync();
        }

        public virtual decimal? Sum(
            Expression<Func<TModel, bool>> predicate = null
        )
        {
            var query = _context.Set<TModel>().AsQueryable();

            query = PrepareQuery(query, predicate);

            return ((IQueryable<decimal?>)query).Sum();
        }

        public virtual async Task<int> CountAsync(
            Expression<Func<TModel, bool>> predicate = null
        )
        {
            var query = _context.Set<TModel>().AsQueryable();

            query = PrepareQuery(query, predicate);

            return await query.CountAsync();
        }

        public virtual int Count(
            Expression<Func<TModel, bool>> predicate = null
        )
        {
            var query = _context.Set<TModel>().AsQueryable();

            query = PrepareQuery(query, predicate);

            return query.Count();
        }



        public virtual TModel First(
            Expression<Func<TModel, bool>> predicate,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
            Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null
        )
        {
            var query = _context.Set<TModel>().AsQueryable();

            query = PrepareQuery(query, predicate, include, orderBy);

            return query.First();
        }

        public virtual async Task<TModel> FirstAsync(
            Expression<Func<TModel, bool>> predicate,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
            Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null
        )
        {
            var query = _context.Set<TModel>().AsQueryable();

            query = PrepareQuery(query, predicate, include, orderBy);

            return await query.FirstAsync();
        }

        public virtual TModel FirstOrDefault(
            Expression<Func<TModel, bool>> predicate,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
            Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null
        )
        {
            var query = _context.Set<TModel>().AsQueryable();

            query = PrepareQuery(query, predicate, include, orderBy);

            return query.FirstOrDefault();
        }

        public virtual async Task<TModel> FirstOrDefaultAsync(
            Expression<Func<TModel, bool>> predicate,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
            Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null
        )
        {
            var query = _context.Set<TModel>().AsQueryable();

            query = PrepareQuery(query, predicate, include, orderBy);

            return await query.FirstOrDefaultAsync();
        }


        public virtual TModel Single(
            Expression<Func<TModel, bool>> predicate,
            Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null
        )
        {
            var query = _context.Set<TModel>().AsQueryable();

            query = PrepareQuery(query, predicate, include);

            return query.Single();
        }

        public virtual async Task<TModel> SingleAsync(
            Expression<Func<TModel, bool>> predicate,
            Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null
        )
        {
            var query = _context.Set<TModel>().AsQueryable();

            query = PrepareQuery(query, predicate, include);

            return await query.SingleAsync();
        }

        public virtual TModel SingleOrDefault(
            Expression<Func<TModel, bool>> predicate,
            Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null
        )
        {
            var query = _context.Set<TModel>().AsQueryable();

            query = PrepareQuery(query, predicate, include);

            return query.SingleOrDefault();
        }

        public virtual async Task<TModel> SingleOrDefaultAsync(
            Expression<Func<TModel, bool>> predicate,
            Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null
        )
        {
            var query = _context.Set<TModel>().AsQueryable();

            query = PrepareQuery(query, predicate, include);

            return await query.SingleOrDefaultAsync();
        }

    }
}

