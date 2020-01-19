﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EventWorld.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        List<T> GetAll();
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
        T GetById(long id);

        IEnumerable<T> Get(Expression<Func<T, bool>> where);

        IQueryable<T> Query();
    }
}
