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
    public class EntryService
    {
        private UnitOfWorkFactory _unitOfWorkFactory;

        [ImportingConstructor]
        public EntryService(UnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public Entry EnterHours(int projectNumber, double hoursDuration, double offset, string comment)
        {
            using (var uow = _unitOfWorkFactory.Create<TimeSheetContext>())
            {
                var ts = GetTimeSheet(uow);

                var result = ts.CanAddEntry(projectNumber, hoursDuration, offset, comment);
                if (result == "")
                {
                    var entry = ts.AddEntry(projectNumber, hoursDuration, offset, comment);
                    uow.Repository<EntryState>().Save(entry.State);
                    uow.SaveChanges();
                    return entry;
                }
                else
                {
                    throw new InvalidOperationException(result);
                }
            }
        }

        public Entry UpdateHours(Guid entryId,int projectNumber, double hoursDuration, double offset, string comment)
        {
            using (var uow = _unitOfWorkFactory.Create<TimeSheetContext>())
            {
                var ts = GetTimeSheet(uow);

                var entries = this.GetEntries(uow, ts.Period)
                    .Where(x => x.Id != entryId);

                ts.LoadEntries(entries);

                var result = ts.CanAddEntry(projectNumber, hoursDuration, offset, comment);

                if (result == "")
                {
                    //overwrite old entry
                    var oldEntry=uow.Repository<EntryState>().GetById(entryId);
                    uow.Repository<EntryState>().Delete(oldEntry);

                    var newEntry = ts.AddEntry(projectNumber, hoursDuration, offset, comment);
                    uow.Repository<EntryState>().Save(newEntry.State);

                    uow.SaveChanges();
                    return newEntry;
                }
                else
                {
                    throw new InvalidOperationException(result);
                }
            }
        }

        public void RemoveHours(Guid entryId)
        {
            using (var uow = _unitOfWorkFactory.Create<TimeSheetContext>())
            {
                var entryRepository = uow.Repository<EntryState>();
                var oldEntryState = entryRepository.GetById(entryId);
                entryRepository.Delete(oldEntryState);
                uow.SaveChanges();
            }
        }

        private TimeSheet GetTimeSheet(UnitOfWork uow)
        {
            var timeSheetRepository = uow.Repository<TimeSheetState>();
            var state = timeSheetRepository.GetAll().FirstOrDefault();
            var ts = new TimeSheet(state);
            return ts;
        }

        private IEnumerable<Entry> GetEntries(UnitOfWork uow, TimePeriod period)
        {
            var entryRepository = uow.Repository<EntryState>();
            var entries = entryRepository.GetAll().Select(x => new Entry(x)).Where(x => x.Period.Within(period));
            return entries;
        }
    }
}
