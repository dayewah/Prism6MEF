using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.DDD;


namespace TimeKeep.TimeSheets
{
    public class TimeSheetPeriodChangedEvent:IDomainEvent
    {
        public TimeSheetPeriodChangedEvent(TimeSheet timeSheet)
        {
            this.TimeSheet = timeSheet;
        }

        public TimeSheet TimeSheet { get; set; }
    }
}
