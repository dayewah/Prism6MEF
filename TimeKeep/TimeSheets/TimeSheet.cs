using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.DDD;
using Models.DDD.TimeSheets.Entries;

namespace TimeKeep.TimeSheets
{
    public class TimeSheet : AggregateRoot
    {
        private List<Entry> _entries;

        //private TimeSheet(){ }

        public TimeSheet()
            :this(TimePeriod.Today)
        {
            // Default Time Period is Today
        }

        public TimeSheet(TimePeriod period)
            : base(Guid.NewGuid())
        {
            _entries = new List<Entry>();
            this.TimePeriod = period;
        }

        public string Name { get; set; }
        public double TotalHours { get { return this.Entries.Sum(x => x.Time.Duration.TotalHours);} }
        public IEnumerable<Entry> Entries { get { return this.Entries; } }

        private TimePeriod LastTime
        {
            get
            {
                return _entries
                    .Count == 0
                    ? TimePeriod.Null.Offset(-(TimePeriod.Null.Start - this.TimePeriod.Start).TotalHours)//returns null time with start and end of timeperiod
                    : _entries.Last().Time;
            }
        }


        private TimePeriod _timePeriod;

        public TimePeriod TimePeriod
        {
            get { return _timePeriod; }
            set
            {
                if (value != _timePeriod)
                {
                    _timePeriod = value;
                    //this.AddDomainEvent(new TimeSheetPeriodChangedEvent(this));
                }
            }
        }
        
        
        public string LoadEntries(IEnumerable<Entry> entries)
        {
            Guard.AssertArgumentTrue(entries.All(x => x.Time.Within(this.TimePeriod)),"all entries should be within current period");
            _entries = new List<Entry>(entries);
            return string.Empty;
        }

        public Entry AddEntry(int projectNumber, double hoursDuration, double offset = 0, string comment = "")
        {
            var msg = this.CanAddEntry(projectNumber,hoursDuration,offset,comment);
            Guard.AssertStateTrue(msg == string.Empty, msg);
            var entry = new Entry(projectNumber, this.LastTime.Next(hoursDuration).Offset(offset), comment);
            _entries.Add(entry);
            return entry;
        }

        public string CanAddEntry(int projectNumber, double hoursDuration, double offset,string comment)
        {
            var entry = new Entry(projectNumber, this.LastTime.Next(hoursDuration).Offset(offset), comment);

            if (this.Entries.Any(x => entry.Time.Intersect(x.Time)))
                return "entry intersects another";
            if (entry.Time.Within(this.TimePeriod) == false)
                return "entry is outside the current time period";

            return string.Empty;
        }        

        
        public void RemoveEntry(Entry entry)
        {
            var msg = this.CanRemoveEntry(entry);
            Guard.AssertStateTrue(msg == string.Empty, msg);
            _entries.Remove(entry);
        }

        public string CanRemoveEntry(Entry entry)
        {
            if (this.Entries.Contains(entry)==false)
                return "no such entry within this period";

            return string.Empty;
        }        
        
    }
}
