using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Repository
{
    public class Repository<T, TKey> : IRepository<T, TKey> where T : BaseEntity<TKey>
    {
        protected DbSet<T> table = null;
        DbContext _context;
        public Repository(DbContext _context)
        {
            table = _context.Set<T>();
            this._context = _context;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public virtual IEnumerable<T> GetAll(IPaginationFilter filter, out int countPages)
        {
            var validFilter = filter.GetValidValues(filter.PageNumber, filter.PageSize);
            var pagedData = table
               .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
               .Take(validFilter.PageSize)
               .ToList();

            countPages = table.Count();

            return pagedData;
        }
        public virtual T GetById(TKey id)
        {
            return table.Find(id);
        }
        public virtual T Insert(T obj)
        {
            obj.CreateAt = DateTime.UtcNow;
            table.Add(obj);
            _context.SaveChanges();
            return obj;

        }
        public virtual T Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;

            return obj;
        }
        public virtual void Delete(TKey id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public virtual void Save()
        {
            _context.SaveChanges();
        }
        public virtual IEnumerable<T> GetByCriteria(Expression<Func<T, bool>> predicate)
        {
            return table.Where(predicate);
        }
        public virtual IEnumerable<T> GetByCriteria(Expression<Func<T, bool>> predicate, IPaginationFilter filter, out int countPages)
        {
            var tableResult = table.Where(predicate);
            var validFilter = filter.GetValidValues(filter.PageNumber, filter.PageSize);

            var pagedData = tableResult
               .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
               .Take(validFilter.PageSize)
               .ToList();

            countPages = tableResult.Count();

            return pagedData;
        }
    }
}