using NancyApp.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NancyApp.Common.Contracts {
    public interface IGenericRepository<TKey, TEntity>
        where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey> {

        IQueryable<TEntity> GetAll(IEnumerable<Expression<Func<TEntity, object>>> includeProperties = null);
        void Add(TEntity entity);
        void Update(TEntity entity);
        TEntity AddOrUpdate(TEntity entity);
        void Delete(TEntity entity);
        void Delete(TKey id);
        void DeleteRange(IEnumerable<TKey> ids);
        TEntity GetById(TKey id, IEnumerable<Expression<Func<TEntity, object>>> includeProperties = null);
        void Load(Expression<Func<TEntity, bool>> predicate = null);
    }
}
