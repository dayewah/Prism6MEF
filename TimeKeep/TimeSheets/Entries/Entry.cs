using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.DDD;
using TimeKeep.TimeSheets;


namespace Models.DDD.TimeSheets.Entries
{
    public class Entry: AggregateRoot
    {
        public Entry(int projectNumber, TimePeriod time, string comment="")
            :base(Guid.NewGuid())
        {
            this.ProjectNumber = projectNumber;
            this.Comment = comment;
            this.Time = time;

            this.AddDomainEvent(new EntryCreatedEvent(this));
        }
        public int ProjectNumber { get; private set; }

        public string Comment { get; private set; }

        public TimePeriod Time { get; private set; }
    }
}
