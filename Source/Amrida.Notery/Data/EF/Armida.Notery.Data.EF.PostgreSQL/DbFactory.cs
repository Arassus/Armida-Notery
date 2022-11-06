using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Armida.Notery.Data.EF.PostgreSQL
{
    public class DbFactory : IDesignTimeDbContextFactory<NoteryDataContextPostgreSQL>
    {
        /// <summary>
        /// Creates a new db context.
        /// </summary>
        /// <param name="args">The arguments</param>
        /// <returns>The db context</returns>
        public NoteryDataContextPostgreSQL CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<NoteryDataContextPostgreSQL>();
            builder.UseNpgsql("PostgresConnectionString");
            return new NoteryDataContextPostgreSQL(builder.Options);
        }
    }
}
