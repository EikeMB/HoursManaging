using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoursManaging
{
    internal class Database
    {
        public static SQLiteConnection dbConnection;

        internal static void openExistingDatabase(string fullPathName)
        {
            string text = Files.VerifyWriteToFileName(fullPathName);
            SQLiteConnection sQLiteConnection = new SQLiteConnection("Data Source=" + text + "; Foreign Keys=1");
            sQLiteConnection.Open();
            dbConnection = sQLiteConnection;
        }

        internal static void newDatabase(string fullPathName)
        {
            string text = Files.VerifyWriteToFileName(fullPathName);
            if (File.Exists(text))
            {
                File.Delete(text);
            }

            SQLiteConnection sQLiteConnection = new SQLiteConnection("Data Source=" + text + "; Foreign Keys=1");
            sQLiteConnection.Open();
            dbConnection = sQLiteConnection;
            CreateNewDatabase();
        }

        private static void CreateNewDatabase()
        {
            SQLiteCommand sQLiteCommand = new SQLiteCommand(dbConnection);
            sQLiteCommand.CommandText = "DROP TABLE IF EXISTS days";
            sQLiteCommand.ExecuteNonQuery();
            sQLiteCommand.CommandText = "CREATE TABLE days(start DATETIME, end DATETIME, hours REAL, minutes REAL, breakTime REAL)";
            sQLiteCommand.ExecuteNonQuery();
        }

        internal static void CloseDatabaseAndReleaseFile()
        {
            dbConnection.Close();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
