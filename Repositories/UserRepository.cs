using SimpleBE.Infrastructure;
using SimpleBE.Models;

public interface IUserRepository : IRepository<User>
{
}

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationContext context) : base(context)
    {
    }
}