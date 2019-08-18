using NancyApp.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyApp.Common.Contracts {
    public interface IUnitOfWork {
        IGenericRepository<TKey, TEntity> GetGenericRepository<TKey, TEntity>()
            where TEntity : class, IEntity<TKey>
            where TKey : IEquatable<TKey>;

        void Commit();
    }
}
