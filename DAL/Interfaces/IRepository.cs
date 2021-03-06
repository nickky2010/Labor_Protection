﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T :class
    {
        List<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        void Add(T entity);
        void Add(IEnumerable<T> entities);

        void Update(T entity);

        void Delete(T entity);

        void Delete(Expression<Func<T, bool>> where);

        T GetById(int id);

        ICollection<T> GetAll();
        ICollection<T> GetAllInclude(string entity);

        ICollection<T> GetMany(Expression<Func<T, bool>> where);

        T Get(Expression<Func<T, bool>> where);

        int Count(Expression<Func<T, bool>> where = null);

        bool IsExist(Expression<Func<T, bool>> where = null);
    }
}
