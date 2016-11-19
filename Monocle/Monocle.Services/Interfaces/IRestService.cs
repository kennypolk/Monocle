using System.Collections.Generic;

namespace Monocle.Services.Interfaces
{
    public interface IRestService<T>
    {
        T Get(int id);
        List<T> Get();
        int? Insert(T item);
        int Update(T item);
        int Delete(int id);
    }
}
