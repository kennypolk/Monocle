using Monocle.Repository.Entities;
using Monocle.Repository.Interfaces;

namespace Monocle.Repository.Repository
{
    public class StoryRepository : Repository<Story>, IStoryRepository
    {
        public StoryRepository(IRepositoryConfiguration repositoryConfiguration) : base(repositoryConfiguration)
        {
        }
    }
}
