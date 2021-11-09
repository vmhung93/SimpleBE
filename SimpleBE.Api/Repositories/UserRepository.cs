using SimpleBE.Api.Infrastructure;

using SimpleBE.Api.Entities;
using System.Linq;

public interface IUserRepository : IRepository<User>
{
    User FindByUserName(string username);
}

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationContext context) : base(context)
    {
    }

    public User FindByUserName(string userName)
    {
        return _context.Users.FirstOrDefault(u => u.UserName == userName);
    }
}