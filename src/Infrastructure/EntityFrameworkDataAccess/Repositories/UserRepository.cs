namespace Infrastructure.EntityFrameworkDataAccess.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Security;
    using Domain.Security.ValueObjects;
    using Microsoft.EntityFrameworkCore;
    using User = EntityFrameworkDataAccess.User;

    public sealed class UserRepository : IUserRepository
    {
        private readonly MangaContext _context;

        public UserRepository(MangaContext context)
        {
            this._context = context ??
                            throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(IUser user)
        {
            await this._context.Users.AddAsync((User)user);
            await this._context.SaveChangesAsync();
        }

        public async Task<IUser> GetUser(ExternalUserId externalUserId)
        {
            var user = await this._context
                .Users
                .Where(a => a.ExternalUserId.Equals(externalUserId))
                .SingleOrDefaultAsync();

            if (user is null)
            {
                throw new UserNotFoundException($"The user {externalUserId} does not exist or is not processed yet.");
            }

            return user;
        }
    }
}
