using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoursManaging
{
    public class HoursManager
    {
        private Days _days;
        public Days Days => _days;
        public HoursManager(string hoursFileName, bool isNewDatabase = false)
        {
            if (File.Exists(hoursFileName) && !isNewDatabase)
            {
                Database.openExistingDatabase(hoursFileName);
            }
            else
            {
                Database.newDatabase(hoursFileName);
            }

            _days = new Days(Database.dbConnection);
        }

        public void CloseDB()
        {
            if (Database.dbConnection != null)
            {
                Database.CloseDatabaseAndReleaseFile();
            }
        }

        public void SaveToFile(string toFile)
        {
            string sourceFileName = Files.VerifyReadFromFileName(Database.dbConnection.FileName);
            toFile = Files.VerifyWriteToFileName(toFile);
            Database.dbConnection.Close();
            File.Copy(sourceFileName, toFile, overwrite: true);
            Database.openExistingDatabase(toFile);
            _days = new Days(Database.dbConnection);
        }

        public List<Day> GetDays(DateTime? start, DateTime? end)
        {
            DateTime dateTime = start ?? new DateTime(1900, 1, 1, 0,0,0);
            DateTime dateTime2 = end ?? new DateTime(2500, 1, 1, 0, 0, 0);

            string text = "select start, end, hours, minutes, breakTime from days where datetime(start) >= @dateTime and datetime(end) <= @dateTime2 order by start";

            SQLiteCommand cmd = new SQLiteCommand(Database.dbConnection);
            cmd.CommandText = text;
            cmd.Parameters.AddWithValue("@dateTime", dateTime.ToString("yyyy-MM-dd HH:mm"));
            cmd.Parameters.AddWithValue("@dateTime2", dateTime2.ToString("yyyy-MM-dd HH:mm"));
            SQLiteDataReader reader = cmd.ExecuteReader();
            List<Day> days = new List<Day>();

            while (reader.Read())
            {
                string startTime = reader.GetString(0);
                string endTime = reader.GetString(1);
                Day day = new Day(DateTime.ParseExact(startTime, "yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture), DateTime.ParseExact(endTime, "yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture));
                days.Add(day);
            }
            return days;
        }

        public List<DaysByWeek> GetDaysByWeek(DateTime? start, DateTime? end)
        {
            DateTime dateTime = start ?? new DateTime(1900, 1, 1);
            DateTime dateTime2 = end ?? new DateTime(2500, 1, 1);

            string text = "select start, sum(hours), sum(minutes) from days where datetime(start) >= @dateTime and datetime(end) <= @dateTime2 group by strftime('%W',start) order by start";
            SQLiteCommand cmd = new SQLiteCommand(Database.dbConnection);
            cmd.CommandText = text;
            cmd.Parameters.AddWithValue("@dateTime", dateTime.ToString("yyyy-MM-dd HH:mm"));
            cmd.Parameters.AddWithValue("@dateTime2", dateTime2.ToString("yyyy-MM-dd HH:mm"));
            SQLiteDataReader reader = cmd.ExecuteReader();
            List<DaysByWeek> daysByWeeks = new List<DaysByWeek>();
            while(reader.Read())
            {
                string startTime = reader.GetString(0);
                double hours = reader.GetDouble(1);
                double minutes = reader.GetDouble(2);

                if(minutes >= 60)
                {
                    hours += Math.Floor(minutes / 60);
                    minutes = minutes % 60;
                }

                DaysByWeek week = new DaysByWeek();
                week.TotalHours = hours;
                week.TotalMinutes = minutes;
                week.Week = DateTime.ParseExact(startTime, "yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture);

                DateTime startDate = DateTime.ParseExact(startTime, "yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture);
                DayOfWeek dayOfWeek = startDate.DayOfWeek;

                DateTime endDate = startDate.AddDays(7-(int)dayOfWeek);

                week.Days = GetDays(startDate, endDate);

                daysByWeeks.Add(week);

            }

            return daysByWeeks;

        }

    }
}
