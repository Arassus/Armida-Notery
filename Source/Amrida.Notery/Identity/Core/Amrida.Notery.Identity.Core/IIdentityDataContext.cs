using Amrida.Notery.Identity.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Amrida.Notery.Identity.Core
{
    public interface IIdentityDataContext : IDisposable
    {
        DbSet<User> Users { get; set; }
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
