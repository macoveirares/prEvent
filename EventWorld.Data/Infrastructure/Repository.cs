﻿using EventWorld.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EventWorld.Data.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext context;
        private readonly DbSet<T> dbset;

        public Repository(EventWorldDataContext context)
        {
            this.context = context;
            dbset = context.Set<T>();
        }

        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public void Update(T entity)
        {
            dbset.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public List<T> GetAll()
        {
            return dbset.ToList();
        }

        public T GetById(long id)
        {
            return dbset.Find(id);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).ToList();
        }

        public IQueryable<T> Query()
        {
            return dbset.AsQueryable();
        }
    }
}
