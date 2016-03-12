using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DDD;
using TimeKeep.TimeSheets.Entries;

namespace Models.DDD.TimeSheets.Entries
{
    class EntryCreatedEventHandler: IHandler<EntryCreatedEvent>
    {
        private IEntryRepository _entryRepository;

        public EntryCreatedEventHandler(IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
        }

        public void Handle(EntryCreatedEvent domainEvent)
        {
            //_entryRepository.Save(domainEvent.Entry);
        }
    }
}
