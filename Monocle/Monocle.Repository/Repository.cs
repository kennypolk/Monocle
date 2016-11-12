using System.Collections.Generic;
using System.Linq;
using Dapper;

namespace Monocle.Repository
{
    public class Repository<T> : RepositoryBase, IRepository<T>
    {
        public Repository(IRepositoryConfiguration repositoryConfiguration) : base(repositoryConfiguration)
        {
        }

        public List<T> Get()
        {
            return Get(connection => connection.GetList<T>().ToList());
        }

        public T Get(int id)
        {
            return Get(connection => connection.Get<T>(id));
        }

        public int? Delete(T item)
        {
            return Execute(connection => connection.Delete(item));
        }

        public int? Update(T item)
        {
            return Execute(connection => connection.Update(item));
        }

        public int? Insert(T item)
        {
            return Execute(connection => connection.Insert(item));
        }
    }
}
