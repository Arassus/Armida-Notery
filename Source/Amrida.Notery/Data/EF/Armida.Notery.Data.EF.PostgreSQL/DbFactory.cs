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
            builder.UseNpgsql("User ID =noterydev;Password=12345678;Server=localhost;Port=5432;Database=sampledb; Integrated Security=true;Pooling=true;");
            return new NoteryDataContextPostgreSQL(builder.Options);
        }
    }
}
