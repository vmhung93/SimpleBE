
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SimpleBE.Models;

namespace SimpleBE.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationContext _context { get; set; }

        public Repository(ApplicationContext context)
        {
            this._context = context;
        }

        public T FindById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> FindAll()
        {
            return this._context.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._context.Set<T>().Where(expression);
        }

        public void Add(T entity)
        {
            this._context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this._context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this._context.Set<T>().Remove(entity);
        }
    }
}
