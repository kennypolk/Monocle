using Monocle.Repository.Entities;
using Monocle.Repository.Interfaces;
using Monocle.Services.Interfaces;

namespace Monocle.Services.Services
{
    public class StoryService : Service<Story>, IStoryService
    {
        public StoryService(IStoryRepository repository) : base(repository)
        {
        }
    }
}
