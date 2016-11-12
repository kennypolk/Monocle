using System.Collections.Generic;
using Monocle.Repository;
using Monocle.Services.Interfaces;

namespace Monocle.Services.Services
{
    public class Service<T> : IService<T>
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public T Get(int id)
        {
            return _repository.Get(id);
        }

        public List<T> Get()
        {
            return _repository.Get();
        }

        public List<T> Get(object whereConditions)
        {
            return _repository.Get(whereConditions);
        }

        public List<T> Get(string conditions, object parameters = null)
        {
            return _repository.Get(conditions, parameters);
        }

        public int? Insert(T item)
        {
            return _repository.Insert(item);
        }

        public int Update(T item)
        {
            return _repository.Update(item);
        }

        public int Delete(T item)
        {
            return _repository.Delete(item);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }

        public int DeleteList(object whereConditions)
        {
            return _repository.DeleteList(whereConditions);
        }

        public int DeleteList(string conditions, object parameters = null)
        {
            return _repository.DeleteList(conditions, parameters);
        }

        public int RecordCount(string conditions = "", object paramerters = null)
        {
            return _repository.RecordCount(conditions, paramerters);
        }
    }
}
