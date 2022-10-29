using Armida.Notery.Data.EF.Data;
using Microsoft.EntityFrameworkCore;

namespace Armida.Notery.Data.EF
{
    public abstract class ApplicationDataContext<T> : DbContext, IApplicationDataContext where T : ApplicationDataContext<T>
    {
        public DbSet<Notebook> Notebooks { get; set; }
        public ApplicationDataContext(DbContextOptions<T> options) : base(options) { }
    }
}
