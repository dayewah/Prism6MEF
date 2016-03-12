using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DDD;
using TimeKeep.TimeSheets.Entries;

namespace TimeKeep.TimeSheets
{
    public class TimeSheetPeriodChangedEventHandler : IHandler<TimeSheetPeriodChangedEvent>
    {
        private ITimeSheetRepository _timeSheetRepository;
        private IEntryRepository _entryRepository;

        public TimeSheetPeriodChangedEventHandler(ITimeSheetRepository timeSheetRepository, IEntryRepository entryRepository)
        {
            _timeSheetRepository = timeSheetRepository;
            _entryRepository = entryRepository;
        }

        public void Handle(TimeSheetPeriodChangedEvent domainEvent)
        {
            //var timesheet = domainEvent.TimeSheet;
            //var entries = _entryRepository.GetByTimePeriod(timesheet.TimePeriod);
            //timesheet.LoadEntries(entries);
            //_timeSheetRepository.Save(timesheet);
        }
    }
}
