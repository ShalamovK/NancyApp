using NancyApp.Common.Contracts;
using NancyApp.Common.Entities;
using NancyApp.DAL.Repos;
using System;

namespace NancyApp.DAL {
    public class UnitOfWork : IUnitOfWork {
        private NancyDbContext _dbContext;
        public UnitOfWork() {
            _dbContext = new NancyDbContext();
        }

        public IGenericRepository<TKey, TEntity> GetGenericRepository<TKey, TEntity>()
            where TEntity : class, IEntity<TKey>
            where TKey : IEquatable<TKey> {
            return new GenericRepository<TKey, TEntity>(_dbContext);
        }

        public void Commit() {
            _dbContext.ChangeTracker.DetectChanges();
            _dbContext.SaveChanges();
        }
    }
}
