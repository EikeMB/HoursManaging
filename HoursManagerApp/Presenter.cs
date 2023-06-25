using HoursManaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoursManagerApp
{
    public class Presenter
    {
        private readonly ViewInterface view;
        private readonly HoursManager model;

        public Presenter(ViewInterface v, string fileName, bool newDB)
        {
            view = v;
            model = new HoursManager(fileName, newDB);
        }

        public void processGetDays(DateTime start, DateTime end, bool weekFilter)
        {
            if (weekFilter)
            {
                List<DaysByWeek> weeks = model.GetDaysByWeek(start, end);
                view.SetupDataGridByWeek(weeks);
            }
            else
            {
                List<Day> days = model.GetDays(start, end);
                view.SetupDataGridDefault(days);
            }
        }

        
    }
}
