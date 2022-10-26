using Amrida.Notery.Presentation.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Armida.Notery.Data.EF.PostgreSQL
{
    public sealed class NoteryDataContextPostreSQL : ApplicationDataContext<NoteryDataContextPostreSQL>
    {
        public NoteryDataContextPostreSQL(DbContextOptions<NoteryDataContextPostreSQL> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //modelBuilder.Entity<Notebook>(entity =>
            //{
            //    // One to Many relationship
            //    entity.HasOne(d => d.Team)
            //        .WithMany(p => p.Drivers)
            //        .HasForeignKey(d => d.TeamId)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        .HasConstraintName("FK_Driver_Team");

            //    // One to One
            //    entity.HasOne(d => d.DriverMedia)
            //.WithOne(i => i.Driver)
            //.HasForeignKey<DriverMedia>(b => b.DriverId);
            //});


        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.
        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //}
    }
}
