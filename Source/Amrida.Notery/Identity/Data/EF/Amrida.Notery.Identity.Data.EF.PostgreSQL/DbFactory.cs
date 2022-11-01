using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Amrida.Notery.Identity.Data.EF.PostgreSQL
{
    public class DbFactory : IDesignTimeDbContextFactory<IdentityDataContextPostgreSQL>
    {
        public IdentityDataContextPostgreSQL CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<IdentityDataContextPostgreSQL>();
            builder.UseNpgsql("PostgresConnectionString");
            return new IdentityDataContextPostgreSQL(builder.Options);
        }
    }
}
