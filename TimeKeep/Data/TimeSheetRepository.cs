using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Data;
using Microsoft.Data.Entity;
using TimeKeep.TimeSheets;

namespace TimeKeep.Data
{
    [Export(typeof(ITimeSheetRepository))]
    public class TimeSheetRepository : Repository<TimeSheet>, ITimeSheetRepository
    {
        public TimeSheetRepository(DbContext context)
            :base(context)
        {
        }
        
    }
}
