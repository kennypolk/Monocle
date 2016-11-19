using System.Web.Http;

namespace Monocle.Api.Interfaces
{
    public interface IRestController<in T>
    {
        IHttpActionResult Get();
        IHttpActionResult Get(int id);
        IHttpActionResult Post(T item);
        IHttpActionResult Put(int id, [FromBody]T item);
        IHttpActionResult Delete(int id);
    }
}
