using Amrida.Notery.Identity.Data.EF.Data;
using Microsoft.EntityFrameworkCore;

namespace Amrida.Notery.Identity.Data.EF
{
    public class IdentityDataContext<T> : DbContext where T : IdentityDataContext<T>
    {
        public DbSet<User> Users { get; set; }
        public IdentityDataContext(DbContextOptions<T> options) : base(options) { }
    }
}
