using HwPassion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwPassion.ApplicaitonService
{
    public class BaseServiceImpl<TEntity> : IService<TEntity, int> where TEntity : class
    {
        private IRepository<TEntity, int> m_Repository;

        protected IRepository<TEntity, int> Repository
        {
            get { return m_Repository; }
            set { m_Repository = value; }
        }

        public BaseServiceImpl(IRepository<TEntity, int> repository)
        {
            this.m_Repository = repository;
        }
        public void Add(TEntity entity)
        {
            this.m_Repository.Add(entity);
        }

        public void Update(TEntity entity)
        {
            this.m_Repository.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            this.m_Repository.Delete(entity);
        }

        public void Delete(int primaryKey)
        {
            this.m_Repository.Delete(primaryKey);
        }

        public TEntity Get(int primaryKey)
        {
            return this.m_Repository.Get(primaryKey);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.m_Repository.GetAll();
        }

        public IEnumerable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return this.m_Repository.Find(predicate);
        }
    }
}
