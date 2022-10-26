using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armida.Notery.Data.EF.PostgreSQL
{
    public class DbFactory : IDesignTimeDbContextFactory<NoteryDataContextPostreSQL>
    {
        /// <summary>
        /// Creates a new db context.
        /// </summary>
        /// <param name="args">The arguments</param>
        /// <returns>The db context</returns>
        public NoteryDataContextPostreSQL CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<NoteryDataContextPostreSQL>();
            builder.UseNpgsql("PostgresConnectionString");
            return new NoteryDataContextPostreSQL(builder.Options);
        }
    }
}
