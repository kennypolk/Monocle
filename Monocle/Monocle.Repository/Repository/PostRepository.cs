using Monocle.Repository.Entities;
using Monocle.Repository.Interfaces;

namespace Monocle.Repository.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(IRepositoryConfiguration repositoryConfiguration) : base(repositoryConfiguration)
        {
        }
    }
}
