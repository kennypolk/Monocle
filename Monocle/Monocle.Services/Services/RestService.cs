using System.Collections.Generic;
using Monocle.Repository;
using Monocle.Services.Interfaces;

namespace Monocle.Services.Services
{
    public class RestService<T> : IRestService<T>
    {
        private readonly IRepository<T> _repository;

        public RestService(IRepository<T> repository)
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

        public int? Insert(T item)
        {
            return _repository.Insert(item);
        }

        public int Update(T item)
        {
            return _repository.Update(item);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}
