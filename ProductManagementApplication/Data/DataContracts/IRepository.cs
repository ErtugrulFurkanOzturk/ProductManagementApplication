using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.DataContracts
{
    public interface IRepository<T> where T : class,new() // Used for only classes which can be new 
    {
        //IQueryable<T> Include<T1>(Expression<Func<T, T1>> selector);

        // to return more than one data 
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null);
        T Get(int id);

        void Add(T entity); // adding operation 

        void Remove(T entity); // deleting operation

        void Update(T entity); // edit opeation
    }
}
