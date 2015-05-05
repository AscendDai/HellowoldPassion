using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwPassion.Model
{
    public class Repository<TEntity> : IRepository<TEntity, int>, IDisposable where TEntity : class
    {
        private readonly IDbSet<TEntity> _dbSet;
        private HwPassionDbEntities _dbContext;
        public Repository()
        {
            _dbContext = new HwPassionDbEntities();
            _dbSet = _dbContext.Set<TEntity>();
        }

        protected IDbSet<TEntity> DbSet
        {
            get { return _dbSet; }
        }

        protected HwPassionDbEntities DbContext
        {
            get { return _dbContext; }
        }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
            DbContext.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            var entry = DbContext.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            DbContext.SaveChanges();
        }

        public virtual void Delete(int primaryKey)
        {
            var entity = Get(primaryKey);
            Delete(entity);
        }

        public virtual TEntity Get(int primaryKey)
        {
            return DbSet.Find(primaryKey);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (DbContext == null) return;
            DbContext.Dispose();
        }
    }
}
