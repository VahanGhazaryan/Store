using Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Concrete
{
    public class BaseRepository
    {
        protected readonly EFDbContext db;
        public BaseRepository()
        {
            db = new EFDbContext();
        }

        public virtual IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            IQueryable<TEntity> query = db.Set<TEntity>();
            return query;
        }

        public TEntity Find<TEntity>(params object[] keyValues) where TEntity : class
        {
            return db.Set<TEntity>().Find(keyValues);
        }
        public TEntity Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : ModelBase
        {
            IQueryable<TEntity> query = db.Set<TEntity>();
            return query.FirstOrDefault(predicate);
        }
        public void SetValues(object entity, object dbEntity)
        {
            db.Entry(dbEntity).CurrentValues.SetValues(entity);
        }
        public void Add<TEntity>(TEntity entity) where TEntity : ModelBase
        {
            db.Set<TEntity>().Add(entity);
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : ModelBase
        {
            db.Set<TEntity>().Remove(entity);
        }
    }
}
