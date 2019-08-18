using NancyApp.Common.Contracts;
using NancyApp.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace NancyApp.DAL.Repos
{
    public class GenericRepository<TKey, TEntity> : IGenericRepository<TKey, TEntity>
        where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey> {
        protected NancyDbContext DbContext { get; private set; }
        protected DbSet<TEntity> DbSet { get; set; }

        public GenericRepository(NancyDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException("dbContext");
            DbSet = DbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll(IEnumerable<Expression<Func<TEntity, object>>> includeProperties = null)
        {
            IQueryable<TEntity> query = DbSet;

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return query;
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }
        public void Update(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
        }
        public TEntity AddOrUpdate(TEntity entity)
        {
            if (entity.Id.Equals(default(TKey)))
            {
                entity.Id = default(TKey);
                Add(entity);
            }
            else
            {
                Update(entity);
            }

            return entity;
        }

        public void Delete(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Deleted;
        }

        public void Delete(TKey id)
        {
            TEntity entity = GetById(id);
            if (entity != null)
            {
                Delete(entity);
            }
        }

        public void DeleteRange(IEnumerable<TKey> ids)
        {
            if (ids == null || ids.Count() == 0)
            {
                return;
            }

            foreach (TKey id in ids)
            {
                Delete(id);
            }
        }

        //public IQueryable<TEntity> Get(out int total, string orderBy, int skip, int take = 0, bool descOrder = true, IEnumerable<Expression<Func<TEntity, bool>>> conditions = null, IEnumerable<Expression<Func<TEntity, object>>> includeProperties = null)
        //{
        //    IQueryable<TEntity> query = GetAll(includeProperties);

        //    if (conditions != null)
        //    {
        //        foreach (var condition in conditions)
        //        {
        //            query = query.Where(condition);
        //        }
        //    }

        //    query = query.OrderByField(orderBy, descOrder);
        //    total = query.Count();
        //    query = query.Skip(skip);
        //    if (take > 0)
        //    {
        //        query = query.Take(take);
        //    }

        //    return query;
        //}

        public TEntity GetById(TKey id, IEnumerable<Expression<Func<TEntity, object>>> includeProperties = null)
        {
            Expression<Func<TEntity, bool>> predicate =
                x => x.Id.Equals(id);

            return GetByExpression(predicate, includeProperties);
        }

        protected TEntity GetByExpression(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includeProperties = null, bool localOnly = false)
        {
            TEntity entity = FirstOrDefault(LocalSet, predicate, includeProperties);
            if (entity != null && localOnly)
            {
                return entity;
            }

            return FirstOrDefault(DbSet, predicate, includeProperties);
        }

        protected TEntity FirstOrDefault(IQueryable<TEntity> source, Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includeProperties = null)
        {
            IQueryable<TEntity> query = source.AsQueryable();

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault(predicate);
        }

        protected IQueryable<TEntity> LocalSet
        {
            get { return DbSet.Local.AsQueryable(); }
        }

        public void Load(Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> query = DbSet.AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            query.Load();
        }
    }
}
