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
    internal class HoursManager
    {
        private Days _days;
        public Days Days => _days;
        public HoursManager(string hoursFileName, bool isNewDatabase = false)
        {
            if(File.Exists(hoursFileName) && !isNewDatabase)
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
            DateTime dateTime = start ?? new DateTime(1900, 1, 1);
            DateTime dateTime2 = end ?? new DateTime(2500, 1, 1);

            string text = "select start, end, hours, minutes, breakTime from days where start >= @dateTime and end <= @dateTime2";

            SQLiteCommand cmd = new SQLiteCommand(Database.dbConnection);
            cmd.CommandText = text;
            cmd.Parameters.AddWithValue("@dateTime", dateTime.ToString("dd/MM/yyyy h:mm tt"));
            cmd.Parameters.AddWithValue("@dateTime2", dateTime2.ToString("dd/MM/yyyy h:mm tt"));
            SQLiteDataReader reader = cmd.ExecuteReader();
            List<Day> days = new List<Day>();

            while (reader.Read())
            {
                while (reader.Read())
                {
                    Day day = new Day(DateTime.ParseExact(reader.GetString(0), "f", CultureInfo.InvariantCulture), DateTime.ParseExact(reader.GetString(1), "f", CultureInfo.InvariantCulture));
                    days.Add(day);
                }
            }
            return days;
        }

    }
}
