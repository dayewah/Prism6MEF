using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Data;
using Models.DDD.TimeSheets.Entries;

namespace TimeKeep.TimeSheets.Entries
{
    public interface IEntryRepository: IRepository<Entry>
    {
        
    }
}
