using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DDD;


namespace Models.DDD.TimeSheets.Entries
{
    public class EntryCreatedEvent: IDomainEvent
    {
        public EntryCreatedEvent(Entry entry)
        {
            this.Entry = entry;
        }

        public Entry Entry { get; set; }
    }
}
