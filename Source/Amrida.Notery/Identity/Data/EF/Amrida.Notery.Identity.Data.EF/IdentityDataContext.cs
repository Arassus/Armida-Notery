using Amrida.Notery.Identity.Core;
using Amrida.Notery.Identity.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Amrida.Notery.Identity.Data.EF
{
    public class IdentityDataContext<T> : DbContext, IIdentityDataContext where T : IdentityDataContext<T>
    {
        public DbSet<User> Users { get; set; }
        public IdentityDataContext(DbContextOptions<T> options) : base(options) { }
    }
}
