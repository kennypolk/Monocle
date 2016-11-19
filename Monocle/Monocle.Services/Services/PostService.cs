using Monocle.Repository;
using Monocle.Repository.Entities;
using Monocle.Services.Interfaces;

namespace Monocle.Services.Services
{
    public class PostService : RestService<Post>, IPostService
    {
        public PostService(IRepository<Post> repository) : base(repository)
        {
        }
    }
}
