using Monocle.Repository.Entities;
using Monocle.Repository.Interfaces;

namespace Monocle.Repository.Repository
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(IRepositoryConfiguration repositoryConfiguration) : base(repositoryConfiguration)
        {
        }
    }
}
