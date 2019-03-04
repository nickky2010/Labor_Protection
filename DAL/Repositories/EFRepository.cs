using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EFRepository<T, C> : IRepository<T>
        where T : class
        where C : DbContext
    {
        protected C _dataContext;
        private DbSet<T> _dbset;

        public EFRepository(C context)
        {
            this._dataContext = context;
            this._dbset = context.Set<T>();
        }

        public virtual List<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _dbset;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual void Add(T entity)
        {
            _dbset.Add(entity);
            _dataContext.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));
            _dataContext.Entry(entity).State = EntityState.Added;
            //_dataContext.SaveChanges();
        }

        public virtual void Add(IEnumerable<T> entities)
        {
            // Отключаем отслеживание и проверку изменений для оптимизации вставки множества полей
            _dataContext.Configuration.AutoDetectChangesEnabled = false;
            _dataContext.Configuration.ValidateOnSaveEnabled = false;

            _dataContext.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));
            foreach (T entity in entities)
                _dataContext.Entry(entity).State = EntityState.Added;
            //_dataContext.SaveChanges();

            _dataContext.Configuration.AutoDetectChangesEnabled = true;
            _dataContext.Configuration.ValidateOnSaveEnabled = true;
        }


        public virtual void Update(T entity)
        {
            _dbset.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                _dbset.Remove(obj);
        }

        public virtual T GetById(int id)
        {
            return _dbset.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbset.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).FirstOrDefault<T>();
        }

        public int Count(Expression<Func<T, bool>> where = null)
        {
            return _dbset.Count(where);
        }

        public bool IsExist(Expression<Func<T, bool>> where = null)
        {
            return _dbset.FirstOrDefault(where) != null ? true : false;
        }
    }
}
