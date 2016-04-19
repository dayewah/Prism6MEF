using Common.Data;
using Models.DDD.TimeSheets.Entries;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeKeep.Data;
using TimeKeep.TimeSheets;

namespace TimeKeep.Services
{
    [Export]
    public class TimeSheetService
    {
        private UnitOfWorkFactory _unitOfWorkFactory;

        [ImportingConstructor]
        public TimeSheetService(UnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public TimeSheetDTO GetTimeSheet()
        {
            using (var uow = _unitOfWorkFactory.Create<TimeSheetContext>())
            {
                var ts = GetTimeSheet(uow);
                var entries = this.GetEntries(uow, ts.Period);
                ts.LoadEntries(entries);
                uow.SaveChanges();
                return new TimeSheetDTO(ts);
            }
        }


        public TimeSheetDTO UpdateName(string name)
        {
            using (var uow = _unitOfWorkFactory.Create<TimeSheetContext>())
            {
                var ts = GetTimeSheet(uow);

                ts.Name = name;
                uow.Repository<TimeSheetState>().Save(ts.State);

                //to update TotalHours Property
                var entries = this.GetEntries(uow, ts.Period);
                ts.LoadEntries(entries);

                uow.SaveChanges();
                return new TimeSheetDTO(ts);
                //afterwards call UpdateEntries on an EntriesCollectionViewModel with Timesheet id
            }
        }

        public TimeSheetDTO UpdatePeriod(TimePeriod newPeriod)
        {
            using (var uow = _unitOfWorkFactory.Create<TimeSheetContext>())
            {
                var ts = GetTimeSheet(uow);

                ts.Period = newPeriod;
                uow.Repository<TimeSheetState>().Save(ts.State);

                //to update TotalHours Property
                var entries = this.GetEntries(uow, ts.Period);
                ts.LoadEntries(entries);

                uow.SaveChanges();
                return new TimeSheetDTO(ts);
                //afterwards call UpdateEntries on an EntriesCollectionViewModel with Timesheet id
            }
        }

        private TimeSheet GetTimeSheet(UnitOfWork uow)
        {
            var timeSheetRepository = uow.Repository<TimeSheetState>();
            var state = timeSheetRepository.GetAll().FirstOrDefault();
            TimeSheet ts;

            if (state == null)
            {
                ts = new TimeSheet();
                uow.Repository<TimeSheetState>().Save(ts.State);
                uow.SaveChanges();
            }
            else
            {
                ts = new TimeSheet(state);
            }

            return ts;
        }

        private IEnumerable<Entry> GetEntries(UnitOfWork uow,TimePeriod period)
        {
            var entryRepository = uow.Repository<EntryState>();
            var entries = entryRepository.GetAll().ToList();
            var result=entries.Select(x => new Entry(x)).Where(x => x.Period.Within(period));
            return result;
        }


        
    }
}
