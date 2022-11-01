using Microsoft.EntityFrameworkCore;

namespace Amrida.Notery.Identity.Data.EF.PostgreSQL
{
    public class IdentityDataContextPostgreSQL : IdentityDataContext<IdentityDataContextPostgreSQL>
    {
        public IdentityDataContextPostgreSQL(DbContextOptions<IdentityDataContextPostgreSQL> options) : base(options) { }
    }
}
