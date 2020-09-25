using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IRepository<T, TKey> where T : BaseEntity<TKey>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(IPaginationFilter filter, out int countPages);
        IEnumerable<T> GetByCriteria(Expression<Func<T, bool>> predicate, IPaginationFilter filter, out int countPages);
        IEnumerable<T> GetByCriteria(Expression<Func<T, bool>> predicate);
        T GetById(TKey id);
        T Insert(T obj);
        T Update(T obj);
        void Delete(TKey id);
    }
}
