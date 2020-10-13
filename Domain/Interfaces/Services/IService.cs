using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IService<T, TKey> where T : BaseEntity<TKey>
    {
        IValidationModel IsValid(T obj);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(IPaginationFilter filter, out int countPages);
        IEnumerable<T> GetByCriteria(Expression<Func<T, bool>> predicate, IPaginationFilter filter, out int countPages);
        IEnumerable<T> GetByCriteria(Expression<Func<T, bool>> predicate);
        T GetById(TKey id);
        IValidationModel Insert(ref T obj);
        IValidationModel Update(ref T obj);
        void Delete(TKey id);
    }
}
