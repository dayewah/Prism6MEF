using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Data;

namespace TimeKeep.TimeSheets
{
    public class ITimeSheetRepository: IRepository<TimeSheet>
    {
        public void Delete(TimeSheet aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TimeSheet> GetAll()
        {
            throw new NotImplementedException();
        }

        public TimeSheet GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(TimeSheet aggregateRoot)
        {
            throw new NotImplementedException();
        }
    }
}
