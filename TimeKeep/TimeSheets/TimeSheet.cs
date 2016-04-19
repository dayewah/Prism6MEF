using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.DDD;
using Models.DDD.TimeSheets.Entries;
using CodeGen.State;

namespace TimeKeep.TimeSheets
{
    [GenerateState]
    public class TimeSheet : AggregateRoot
    {
        private List<Entry> _entries;
        private TimeSheetState _state;

        public TimeSheet()
            :this(Guid.NewGuid(),"New TimeSheet",TimePeriod.Today)
        {
            // Default Time Period is Today
        }
        
        public TimeSheet(TimeSheetState state)
            :this(state.Id,state.Name,new TimePeriod(state.TimePeriod_Start,state.TimePeriod_Duration))
        {
            _state = state;
        }

        public TimeSheet(Guid id, string name, TimePeriod timePeriod) : base(id)
        {
            this.Name = name;
            this.Period = timePeriod;
            _entries = new List<Entry>();
            _state = new TimeSheetState();
        }

        public string Name { get; set; }
        public double TotalHours { get { return this.Entries.Sum(x => x.Period.Duration.TotalHours);} }
        public IEnumerable<Entry> Entries { get { return _entries; } }

        private TimePeriod LastTime
        {
            get
            {
                return _entries
                    .Count == 0
                    ? TimePeriod.Null.Offset(-(TimePeriod.Null.Start - this.Period.Start).TotalHours)//returns null time with start and end of timeperiod
                    : _entries.Last().Period;
            }
        }

        private TimePeriod _period;

        public TimePeriod Period
        {
            get { return _period; }
            set
            {
                if (value != _period)
                {
                    _period = value;
                    //this.AddDomainEvent(new TimeSheetPeriodChangedEvent(this));
                }
            }
        }

        public TimeSheetState State
        {
            get
            {
                _state.Id = this.Id;
                _state.Name = this.Name;
                _state.TimePeriod_Start = this.Period.Start;
                _state.TimePeriod_End = this.Period.End;
                _state.TimePeriod_Duration = this.Period.Duration;
                return _state;
            }
        }

        public string LoadEntries(IEnumerable<Entry> entries)
        {
            Guard.AssertArgumentTrue(entries.All(x => x.Period.Within(this.Period)),"all entries should be within current period");
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

            if (this.Entries.Any(x => entry.Period.Intersect(x.Period)))
                return "entry intersects another";
            if (entry.Period.Within(this.Period) == false)
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

    //public class TimeSheetState : Entity
    //{
    //    public String Name { get; set; }
    //    public Double TotalHours { get; set; }
    //    public DateTime TimePeriod_Start { get; set; }
    //    public DateTime TimePeriod_End { get; set; }
    //    public TimeSpan TimePeriod_Duration { get; set; }
    //}
}
