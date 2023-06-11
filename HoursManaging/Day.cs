using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoursManaging
{
    internal class Day
    {
        private DateTime startTime;
        private DateTime endTime;
        private double totalHours;
        private double totalMinutes;
        private double breakTime;


        public Day(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
            
        }
        #region properties

        public DateTime StartTime
        {
            get
            {
                return this.startTime;
            }
            set
            {
                if(value <= DateTime.Now)
                {
                    this.startTime = value;
                }
                else
                {
                    throw new ArgumentException("Cannot set a startTime that has not happened yet.");
                }
            }
        }

        public DateTime EndTime
        {
            get
            {
                return this.endTime;
            }
            set
            {
                if (value <= DateTime.Now)
                {
                    this.endTime = value;
                }
                else
                {
                    throw new ArgumentException("Cannot set a endTime that has not happened yet.");
                }
            }
        }

        public double TotalHours
        {
            get
            {
                double hours = ((EndTime - StartTime).TotalHours - breakTime);
                return Math.Floor(hours);
            }
            
        }

        public double TotalMinutes
        {
            get
            {
                double hours = ((EndTime - StartTime).TotalHours - breakTime);
                return (hours - TotalHours) * 60;
            }
        }

        public double BreakTime
        {
            get
            {
                double hours = (EndTime - StartTime).TotalHours;
                if (hours > 7)
                {
                    return 1;
                }
                else
                {
                    return 0.5;
                }
            }
        }
        #endregion
    }
}
