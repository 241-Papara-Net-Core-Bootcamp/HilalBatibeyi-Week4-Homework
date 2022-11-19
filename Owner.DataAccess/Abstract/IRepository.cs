using System;
using System.Linq;
using System.Linq.Expressions;

namespace Owner.DataAccess.Abstract
{
    public interface IRepository<T> where T:class
    {
        IQueryable<T> Get();

        IQueryable<T> GetAll(Expression<Func<T, bool>> expression);

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void HardDelete(T entity);
    }
}
