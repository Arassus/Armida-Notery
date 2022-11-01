using Microsoft.EntityFrameworkCore;

namespace Armida.Notery.Data.EF.PostgreSQL
{
    public sealed class NoteryDataContextPostgreSQL : ApplicationDataContext<NoteryDataContextPostgreSQL>
    {
        public NoteryDataContextPostgreSQL(DbContextOptions<NoteryDataContextPostgreSQL> options) : base(options) { }
    }
}
