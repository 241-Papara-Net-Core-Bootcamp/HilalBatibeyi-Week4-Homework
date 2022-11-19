using Microsoft.EntityFrameworkCore;
using Owner.DataAccess.Abstract;
using Owner.DataAccess.Context;
using Owner.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Owner.DataAccess.Concrete
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public OwnerDbContext _context { get; }

        public Repository(OwnerDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>().Where(x => x.IsDeleted).AsQueryable();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).AsQueryable();
        }

        // deletes directly from the database
        public void HardDelete(T entity)
        {
            T existData = _context.Set<T>().Find(entity.Id);
            if (existData != null)
            {
                _context.Set<T>().Remove(existData);
                _context.SaveChanges();
            }
        }

        // don't delete the data, hide it
        public void Delete(T entity)
        {
            T existData = _context.Set<T>().Find(entity.Id);
            if (existData != null)
            {
                existData.IsDeleted = true;
                _context.Entry(existData).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Where(x => x.Id == id).SingleOrDefault();
        }

    }
}
