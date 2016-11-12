using System.Collections.Generic;

namespace Monocle.Repository
{
    public interface IRepository<T>
    {
        List<T> Get();
        T Get(int id);
        int? Delete(T item);
        int? Update(T item);
        int? Insert(T item);
    }
}
