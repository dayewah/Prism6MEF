using Models.DDD.TimeSheets.Entries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeKeep.TimeSheets;

namespace TimeKeep.Services
{
    public class TimeSheetDTO
    {
        public TimeSheetDTO(TimeSheet ts)
        {
            this.Id = ts.Id;
            this.Name = ts.Name;
            this.TotalHours = ts.TotalHours;
            this.Period = ts.Period;
            this.Entries = ts.Entries;
        }
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public double TotalHours { get; private set; }
        public TimePeriod Period { get; private set; }
        public IEnumerable<Entry> Entries { get; private set; }
    }
}
