using System;
using System.Threading.Tasks;

namespace SimpleBE.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}