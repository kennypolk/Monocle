using Monocle.Repository.Interfaces;

namespace Monocle.Repository.Entities
{
    public class RepositoryConfiguration : IRepositoryConfiguration
    {
        public string ConnectionString { get; set; }
    }
}
