using System.Linq;

using SimpleBE.Domain;
using SimpleBE.Domain.Entities;

namespace SimpleBE.Infrastructure.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByUserName(string username);
    }

    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public User FindByUserName(string userName)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == userName);
        }
    }
}