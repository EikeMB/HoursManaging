using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoursManaging
{
    public class DaysByWeek
    {
        public DateTime Week { get; set; }
        public List<Day> Days { get; set; }

        public double TotalHours { get; set; }
        public double TotalMinutes { get; set; }

    }
}
