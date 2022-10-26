using Armida.Notery.Data.EF.Data;
using Microsoft.EntityFrameworkCore;

namespace Armida.Notery.Data.EF
{
    public interface IApplicationDataContext : IDisposable
    {
        DbSet<Notebook> Notebooks { get; set; }
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
