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

        public void processGetDays(DateTime? start, DateTime? end, bool weekFilter)
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

        public void processAdd(DateTime start, DateTime end)
        {
            try
            {
                model.Days.Add(start, end);
            }
            catch (Exception e)
            {

                view.DisplayError(e.Message);
            }

        
        }

        public void processDelete(Day day)
        {
            model.Days.Delete(day.StartTime);
        }

        public void processUpdate(Day day, DateTime st, DateTime en)
        {
            

            model.Days.UpdateProperties(day.StartTime, st, en);



        }

        public List<Day> secondWindowGetDays(DateTime? start, DateTime? end)
        {
            return model.GetDaysByWeek(start, end)[0].Days;
        }
        
    }
}
