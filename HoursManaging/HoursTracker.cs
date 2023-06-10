using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoursManaging
{
    internal class HoursTracker
    {

        private double wage;
        private DateTime startDate;
        private DateTime endDate;

        public HoursTracker(double wage, DateTime start, DateTime end)
        {
            ContractHours = 350;
            Wage = wage;
            StartDate = start;
            EndDate = end;
            double amountOfWeeks = Math.Floor((double)((EndDate - StartDate).Days)/7);
            Weeks = new List<Week>((int)amountOfWeeks);
        }

        public void AddWeek(Week week)
        {
            if(week.StartDate >= startDate && week.StartDate <= endDate)
            {
                Weeks.Add(week);
            }
        }




        public double Hours
        {
            get
            {
                double totalHours = 0;
                double minutes = 0;
                foreach (Week week in Weeks)
                {
                    totalHours += week.Hours;
                    minutes += week.Hours;
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
                foreach (Week week in Weeks)
                {
                    totalMinutes += week.Minutes;
                }
                totalMinutes = totalMinutes - (Math.Floor(totalMinutes / 60) * 60);
                return totalMinutes;
            }
        }

        public double MissingHours
        {
            get
            {
                if(ContractHours - Hours > 1)
                {
                    if(MissingMinutes > 0)
                    {
                        return ContractHours - Hours - 1;
                    }
                    return ContractHours - Hours;
                }
                return 0;
            }
        }

        public double MissingMinutes
        {
            get
            {
                if(ContractHours - Hours > 0)
                {
                    return 60 - Minutes;
                }
                return 0;
            }
        }

        public double ContractHours { get; set; }
        public List<Week> Weeks { get; set; }

        public double Wage
        {
            get { return wage; }
            set
            {
                if(value >= 15.25)
                {
                    wage = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Wage must be atleast minimum wage");
                }
            }
        }

        public DateTime StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
            }
        }
        public DateTime EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                if(value > StartDate)
                {
                    endDate = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Contract end date cannot be before the start date");
                }
            }
        }
    }
}
