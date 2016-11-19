using Monocle.Repository.Entities;
using Monocle.Repository.Interfaces;
using Monocle.Services.Interfaces;

namespace Monocle.Services.Services
{
    public class AccountService : RestService<Account>, IAccountService
    {
        public AccountService(IAccountRepository repository) : base(repository)
        {
        }
    }
}
