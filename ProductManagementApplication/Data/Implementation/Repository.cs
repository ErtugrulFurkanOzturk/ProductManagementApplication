﻿using Data.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Data.DataContracts;
using Data.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementation
{
    public class Repository<T> : IRepository<T> where T: class,new()
    {
        private readonly ProductManagementApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ProductManagementApplicationDbContext db)//injection operation
        {
            _db = db;
            this.dbSet = _db.Set<T>(); 
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if(filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries)) 
                {
                    query = query.Include(item);
                }
            }
            if (orderBy != null)
            {
                return orderBy(query);
            }
            return query;
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }


}
