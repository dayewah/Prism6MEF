using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Data;
using Models.DDD.TimeSheets.Entries;

namespace TimeKeep.TimeSheets.Entries
{
    public class IEntryRepository: IRepository<Entry>
    {
        public void Delete(Entry aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Entry> GetAll()
        {
            throw new NotImplementedException();
        }

        public Entry GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(Entry aggregateRoot)
        {
            throw new NotImplementedException();
        }
    }
}
