
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimpleBE.Api.Infrastructure
{
    public interface IRepository<T>
    {
        T FindById(Guid id);

        IEnumerable<T> FindAll();

        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
