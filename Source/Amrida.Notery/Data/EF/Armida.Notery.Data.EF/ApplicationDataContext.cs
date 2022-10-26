using Armida.Notery.Data.EF.Data;
using Microsoft.EntityFrameworkCore;

namespace Armida.Notery.Data.EF
{
    public abstract class ApplicationDataContext<T> : DbContext, IApplicationDataContext where T : ApplicationDataContext<T>
    {
        public DbSet<Notebook> Notebooks { get; set; }

        //private static volatile bool _dbIsInitialized = false;
        //private static readonly object _dbLock = new object();

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ApplicationDataContext(DbContextOptions<T> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            //if (!_dbIsInitialized)
            //{
            //    lock (_dbLock)
            //    {
            //        SeedDatabase();
            //        _dbIsInitialized = true;
            //    }
            //}
        }

        //private void SeedDatabase()
        //{
        //    if (!Notebooks.Any())
        //    {
        //        Notebooks.Add(new Notebook
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "Default Name",
        //            Description = "Default Description"
        //        });
        //    }

        //    SaveChanges();
        //}
    }
}
