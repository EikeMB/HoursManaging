using System;
using HoursManaging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoursManagerApp
{
    public interface ViewInterface
    {
        public void DisplayError(string error);
        public void SetupDataGridDefault(List<Day> days);
        public void SetupDataGridByWeek(List<DaysByWeek> daysByWeeks);

        public void getFilters();
        
    }
}
