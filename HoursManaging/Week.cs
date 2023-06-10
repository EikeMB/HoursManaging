using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoursManaging
{
    internal class Week
    {
        private DateTime startDate;
        private DateTime endDate;

        
        public Week(DateTime startDate)
        {
            StartDate = startDate;
            WeeklyHours = 35;
            Days = new List<Day>(7);
        }
        #region properties
        public double WeeklyHours { get; set; }
        public List<Day> Days { get; set; }

        public double Hours
        {
            get
            {
                double totalHours = 0;
                double minutes = 0;
                foreach (Day day in Days)
                {
                    totalHours += day.TotalHours;
                    minutes += day.TotalMinutes;
                }
                totalHours += Math.Floor(minutes / 60);
                return totalHours;
            }
        }
        public double Minutes
        {
            get
            {
                double totalMinutes = 0;
                foreach (Day day in Days)
                {
                    totalMinutes += day.TotalMinutes;
                }
                totalMinutes = totalMinutes - (Math.Floor(totalMinutes / 60) * 60);
                return totalMinutes;
            }
        }

        public double MissingHours
        {
            get
            {
                if (WeeklyHours - Hours > 1)
                {
                    if (MissingMinutes > 0)
                    {
                        return WeeklyHours - Hours - 1;
                    }
                    return WeeklyHours - Hours;
                }
                return 0;

            }
        }

        public double MissingMinutes
        {
            get
            {
                if (WeeklyHours - Hours > 0)
                {
                    return 60 - Minutes;
                }
                else
                {
                    return 0;
                }
            }
        }

        #endregion
        public DateTime StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                if(value.DayOfWeek == DayOfWeek.Monday)
                {
                    startDate = value;
                    endDate = startDate.AddDays(6);
                }
                else
                {
                    throw new ArgumentException("StartDate of the week must be a monday");
                }
            }
        }

        public void AddDay(Day day)
        {
            if(day.StartTime >= startDate && day.EndTime <= endDate)
            {
                if(Days.Count >= 7)
                {
                    throw new Exception("This week has already been filled");
                }
                int dayIndex = (int)(day.StartTime.DayOfWeek+6)%7;
                Days.Insert(dayIndex, day);


                
            }
            else
            {
                throw new ArgumentOutOfRangeException("Added day must be in the week you are trying to add it to.");
            }

        }


    }
}
