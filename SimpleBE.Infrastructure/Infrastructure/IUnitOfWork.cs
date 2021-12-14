using System;
using System.Threading.Tasks;

using SimpleBE.Infrastructure.Repositories;

namespace SimpleBE.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}