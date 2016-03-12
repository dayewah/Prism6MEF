using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.DDD;


namespace TimeKeep.TimeSheets
{
    public class TimePeriod: ValueObject<TimePeriod>
    {
        public static readonly TimePeriod Null = new TimePeriod(DateTime.Today,0);

        private static readonly int _year = DateTime.Now.Year;
        private static readonly int _month = DateTime.Now.Month;
        public static readonly TimePeriod Today = new TimePeriod(DateTime.Today, 24);

        public static readonly TimePeriod ThisMonth = new TimePeriod(new DateTime(_year,_month,1), DateTime.DaysInMonth(_year,_month)*24);

        private TimePeriod(DateTime start, DateTime end)
        {
            this.Start = start;
            this.End = end;
            this.Duration = end - start;
        }

        public TimePeriod(DateTime start, TimeSpan duration)
            :this(start,start+duration){}

        public TimePeriod(DateTime start, double hourDuration)
            :this(start,TimeSpan.FromHours(hourDuration)){}

        public DateTime Start { get; private set; }

        public DateTime End { get; private set; }

        public TimeSpan Duration { get; private set; }


        protected override bool EqualsCore(TimePeriod other)
        {
            var result = Start == other.Start && Duration == other.Duration;
            return result;
        }

        protected override int GetHashCodeCore()
        {
            var result = Start.GetHashCode() * End.GetHashCode() * Duration.GetHashCode() * 397;
            return result;
        }

        public bool Intersect(TimePeriod other)
        {
            if (this.Start == other.Start || this.End == other.End)
                return true; // If any set is the same time, then by default there must be some overlap. 

            if (this.Start < other.Start)
            {
                if (this.End > other.Start && this.End < other.End)
                    return true; // Condition 1

                if (this.End > other.End)
                    return true; // Condition 3
            }
            else
            {
                if (other.End > this.Start && other.End < this.End)
                    return true; // Condition 2

                if (other.End > this.End)
                    return true; // Condition 4
            }

            return false;
        }

        public bool Within(TimePeriod other)
        {
            if (this.Start >= other.Start)
                if (this.Duration.TotalHours > 0)
                    return this.End <= other.End;
                else
                    return this.End >= other.Start;

            return false;
        }

        #region Add Subtract

        public static double operator +(TimePeriod a, TimePeriod b)
        {
            return (a.Duration + b.Duration).TotalHours;
        }

        public static TimePeriod operator +(TimePeriod a, double b)
        {
            return new TimePeriod(a.Start, TimeSpan.FromHours(a.Duration.TotalHours+b));
        }

        public static double operator -(TimePeriod a, TimePeriod b)
        {
            return (a.Duration - b.Duration).TotalHours;
        }

        public static TimePeriod operator -(TimePeriod a, double b)
        {
            return new TimePeriod(a.Start, TimeSpan.FromHours(a.Duration.TotalHours - b));
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0} - {1:0.0} - {2}", this.Start.ToString(), this.Duration.TotalHours, this.End.ToString());
        }

        public TimePeriod Offset(double value)
        {
            return new TimePeriod(this.Start + TimeSpan.FromHours(value), this.Duration);
        }

        public TimePeriod Next(double hours)
        {
            return new TimePeriod(this.End, hours);
        }

        /*ToDO: Change Duration to a double rather than a timespan
         *      Change name from Duration to Hours
         * 
         */

    }
}
