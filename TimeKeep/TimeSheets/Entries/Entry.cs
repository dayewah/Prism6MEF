using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.DDD;
using TimeKeep.TimeSheets;
using CodeGen.State;

namespace Models.DDD.TimeSheets.Entries
{
    [GenerateState]
    public class Entry: AggregateRoot
    {
        private EntryState _state;

        public Entry(int projectNumber, TimePeriod time, string comment="")
            :this(Guid.NewGuid(),projectNumber,time,comment)
        {
        }

        public Entry(EntryState state)
            :this(state.Id,state.ProjectNumber, new TimePeriod(state.TimePeriod_Start, state.TimePeriod_Duration), state.Comment)
        {
            _state = state;
        }

        public Entry(Guid id, int projectNumber, TimePeriod timePeriod, string comment) 
            : base(id)
        {
            this.ProjectNumber = projectNumber;
            this.Period = timePeriod;
            this.Comment = comment;

            _state = new EntryState();
        }

        public int ProjectNumber { get; private set; }

        public string Comment { get; private set; }

        public TimePeriod Period { get; private set; }

        public EntryState State
        {
            get
            {
                _state.Id = this.Id;
                _state.ProjectNumber = this.ProjectNumber;
                _state.Comment = this.Comment;
                _state.TimePeriod_Start = this.Period.Start;
                _state.TimePeriod_End = this.Period.End;
                _state.TimePeriod_Duration = this.Period.Duration;
                return _state;
            }
        }
    }

    //public class EntryState : Entity
    //{
    //    public Int32 ProjectNumber { get; set; }
    //    public String Comment { get; set; }
    //    public DateTime TimePeriod_Start { get; set; }
    //    public DateTime TimePeriod_End { get; set; }
    //    public TimeSpan TimePeriod_Duration { get; set; }
    //}
}
