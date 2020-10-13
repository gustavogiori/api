using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using System.Runtime.Loader;
using Domain;

namespace Service.Services
{
    public abstract class Service<T, TKey> : IService<T, TKey> where T : BaseEntity<TKey>
    {
        /// <summary>
        /// _repository
        /// </summary>
        protected readonly IRepository<T, TKey> _repository;
        /// <summary>
        /// construtor
        /// </summary>
        /// <param name="repository"></param>
        public Service(IRepository<T, TKey> repository)
        {
            this._repository = repository;
        }

        public virtual void Delete(TKey id)
        {
            this._repository.Delete(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual IEnumerable<T> GetAll(IPaginationFilter filter, out int countPages)
        {
            return _repository.GetAll(filter, out countPages);
        }

        public virtual IEnumerable<T> GetByCriteria(Expression<Func<T, bool>> predicate, IPaginationFilter filter, out int countPages)
        {
            return _repository.GetByCriteria(predicate, filter, out countPages);
        }

        public virtual IEnumerable<T> GetByCriteria(Expression<Func<T, bool>> predicate)
        {
            return _repository.GetByCriteria(predicate);
        }

        public virtual T GetById(TKey id)
        {
            return _repository.GetById(id);
        }

        public virtual IValidationModel Insert(ref T obj)
        {
            var statusModel = IsValid(obj);

            if (statusModel.IsValid)
            {
                obj = _repository.Insert(obj);
            }
            return statusModel;
        }

        public virtual IValidationModel IsValid(T obj)
        {
            ValidationContext vc = new ValidationContext(obj);
            ICollection<ValidationResult> results = new List<ValidationResult>(); // Will contain the results of the validation
            bool isValid = Validator.TryValidateObject(obj, vc, results, true);
            return GetValidationModel(results, isValid);
        }

        private IValidationModel GetValidationModel(ICollection<ValidationResult> validationResults, bool IsValid)
        {
            var validationModel = AppDependencyResolver.Current.GetService<IValidationModel>();
            validationModel.IsValid = IsValid;
            validationModel.ErrorMessage = new List<string>();

            foreach (var result in validationResults)
            {
                validationModel.ErrorMessage.Add(result.ErrorMessage);
            }
            return validationModel;
        }
        public virtual IValidationModel Update(ref T obj)
        {
            var statusModel = IsValid(obj);

            if (statusModel.IsValid)
            {
                obj = _repository.Update(obj);
            }

            return statusModel;
        }
    }
}
