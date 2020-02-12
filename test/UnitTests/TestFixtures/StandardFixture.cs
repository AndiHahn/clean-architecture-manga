namespace UnitTests.TestFixtures
{
    using Domain.Accounts;
    using Domain.Customers;
    using Domain.Security;
    using Infrastructure.InMemoryDataAccess;
    using Infrastructure.InMemoryDataAccess.Repositories;
    using Infrastructure.InMemoryDataAccess.Services;

    public sealed class StandardFixture
    {
        public StandardFixture()
        {
            this.Context = new MangaContext();
            this.AccountRepository = new AccountRepository(this.Context);
            this.CustomerRepository = new CustomerRepository(this.Context);
            this.UserRepository = new UserRepository(this.Context);
            this.UnitOfWork = new UnitOfWork(this.Context);
            this.EntityFactory = new EntityFactory();
            this.UserService = new UserService();
            this.CustomerService = new CustomerService(this.EntityFactory, this.CustomerRepository);
            this.SecurityService = new SecurityService(this.EntityFactory, this.UserRepository);
            this.AccountService = new AccountService(this.EntityFactory, this.AccountRepository);
        }

        public EntityFactory EntityFactory { get; }

        public MangaContext Context { get; }

        public AccountRepository AccountRepository { get; }

        public CustomerRepository CustomerRepository { get; }

        public UserRepository UserRepository { get; }

        public UnitOfWork UnitOfWork { get; }

        public UserService UserService { get; }

        public CustomerService CustomerService { get; }

        public SecurityService SecurityService { get; }

        public AccountService AccountService { get; }
    }
}
