using System.Threading.Tasks;

namespace GraphQLDotNet.Src.Data.Repositories
{
    public class Repository : IRepository
    {
        private readonly IAccountRepository accountRepository;
        private readonly StorageContext context;
        private readonly IOwnerRepository ownerRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IUserRepository userRepository;

        public Repository(
            StorageContext context,
            IAccountRepository accountRepository,
            IOwnerRepository ownerRepository,
            IRoleRepository roleRepository,
            IUserRepository userRepository
        )
        {
            this.context = context;
            this.accountRepository = accountRepository;
            this.ownerRepository = ownerRepository;
            this.roleRepository = roleRepository;
            this.userRepository = userRepository;
        }

        public IAccountRepository Accounts => this.accountRepository;
        public IOwnerRepository Owners => this.ownerRepository;
        public IRoleRepository Roles => this.roleRepository;
        public IUserRepository Users => this.userRepository;

        public void Dispose()
        {
            this.context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this.context.SaveChangesAsync();
        }
    }
}
