using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoursManaging
{
    public class Days
    {
        private SQLiteConnection conn;

        internal Days(SQLiteConnection conn)
        {
            this.conn = conn;
        }

        private void Add(Day day)
        {
            SQLiteCommand cmd = new SQLiteCommand(conn);
            cmd.CommandText = "insert into days (start, end, hours, minutes, breakTime) values(@start, @end, @hours, @minutes, @breakTime)";
            cmd.Parameters.AddWithValue("@start", day.StartTime.ToString("yyyy-MM-dd HH:mm"));
            cmd.Parameters.AddWithValue("@end", day.EndTime.ToString("yyyy-MM-dd HH:mm"));
            cmd.Parameters.AddWithValue("@hours", day.TotalHours);
            cmd.Parameters.AddWithValue("@minutes", day.TotalMinutes);
            cmd.Parameters.AddWithValue("@breakTime", day.BreakTime*60);
            cmd.ExecuteNonQuery();
        }

        public void Add(DateTime start, DateTime end)
        {
            Day day = new Day(start, end);
            Add(day);
        }

        public void UpdateProperties(DateTime ostart, DateTime start, DateTime end)
        {
            Day day = new Day(start, end);
            SQLiteCommand cmd = new SQLiteCommand(conn);

            cmd.CommandText = "update days set start = @start, end = @end, hours = @hours, minute = @minutes, breakTime = @breakTime where start = @ostart";
            cmd.Parameters.AddWithValue("@start", day.StartTime.ToString("yyyy-MM-dd HH:mm"));
            cmd.Parameters.AddWithValue("@end", day.EndTime.ToString("yyyy-MM-dd HH:mm"));
            cmd.Parameters.AddWithValue("@hours", day.TotalHours);
            cmd.Parameters.AddWithValue("@minutes", day.TotalMinutes);
            cmd.Parameters.AddWithValue("@breakTime", day.BreakTime * 60);
            cmd.Parameters.AddWithValue("@ostart", ostart.ToString("yyyy-MM-dd HH:mm"));
            cmd.ExecuteNonQuery();
        }

        public void Delete(DateTime start)
        {
            SQLiteCommand cmd = new SQLiteCommand(conn);
            cmd.CommandText = "delete from days where start = @start";
            cmd.Parameters.AddWithValue("@start", start.ToString("yyyy-MM-dd HH:mm"));
            cmd.ExecuteNonQuery();
        }

        public List<Day> List()
        {
            List<Day> days = new List<Day>();
            SQLiteDataReader reader = new SQLiteCommand(conn)
            {
                CommandText = "select start,end,hours,minutes,breakTime from days order by start"
            }.ExecuteReader();

            while(reader.Read())
            {
                Day day = new Day(DateTime.ParseExact(reader.GetString(0), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), DateTime.ParseExact(reader.GetString(1), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture));
                days.Add(day);
            }

            return days;

        }
    }
}
