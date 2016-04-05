using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DDD;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.ChangeTracking;
using Models.DDD.TimeSheets.Entries;
using TimeKeep.TimeSheets;

namespace TimeKeep.Data
{
    public class TimeSheetContext : DbContext
    {
        private string _path;
        public TimeSheetContext(string path)
            : base()
        {
            _path = path;
        }

        public DbSet<TimeSheet> TimeSheets { get; set; }
        public DbSet<Entry> Entries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=" + _path);
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<TimeSheet>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Entry>()
                .Property(p => p.ProjectNumber).HasColumnName("ProjectNumber");
            modelBuilder.Entity<Entry>()
                            .Property(p => p.Time.Start).HasColumnName("StartTime");

            modelBuilder.Entity<Entry>() // http://ef.readthedocs.org/en/latest/modeling/relationships.html#fluent-api
                .HasOne(e => e.Time);

        }

        public override int SaveChanges()
        {
            ////https://lostechies.com/jimmybogard/2014/05/13/a-better-domain-events-pattern/
            //var domainEventEntities = ChangeTracker.Entries<AggregateRoot>()
            //    .Select(po => po.Entity)
            //    .Where(po => po.DomainEvents.Any())
            //    .ToArray();

            //foreach (var aggregateRoot in domainEventEntities)
            //{
            //    var events = aggregateRoot.DomainEvents.ToArray();
            //    aggregateRoot.ClearEvents();
            //    foreach (var domainEvent in events)
            //    {
            //        DomainEvents.Dispatch(domainEvent);
            //    }
            //}

            return base.SaveChanges();
        }

    }
}
