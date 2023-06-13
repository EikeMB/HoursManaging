using System.Reflection.PortableExecutable;

namespace HoursManaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HoursManager manager = new HoursManager("./AQVA2023.db", true);
            DateTime startMonday = new DateTime(2023, 6, 5, 9, 0, 0);
            DateTime endMonday = new DateTime(2023, 6, 5, 17, 15, 0);
            DateTime startTuesday = new DateTime(2023, 6, 6, 9, 15, 0);
            DateTime endTuesday = new DateTime(2023, 6, 6, 16, 15, 0);
            DateTime startWed = new DateTime(2023, 6, 7, 9, 15, 0);
            DateTime endWed = new DateTime(2023, 6, 7, 20, 30, 0);
            DateTime startThur = new DateTime(2023, 6, 8, 9, 15, 0);
            DateTime endThur = new DateTime(2023, 6, 8, 15, 30, 0);
            DateTime startSat = new DateTime(2023, 6, 10, 9, 15, 0);
            DateTime endSat = new DateTime(2023, 6, 10, 19, 45, 0);

            manager.Days.Add(startMonday, endMonday);
            manager.Days.Add(startTuesday, endTuesday);
            manager.Days.Add(startWed, endWed);
            manager.Days.Add(startThur, endThur);
            manager.Days.Add(startSat, endSat);

            List<Day> days = manager.GetDays(startMonday, startMonday.AddDays(6));

            foreach(Day day in days)
            {
                Console.WriteLine("start: {0}\tend: {1}\ttotal hours: {2}\ttotal minutes: {3}\t total break time: {4}", day.StartTime.ToString("F"), day.EndTime.ToString("F"), day.TotalHours, day.TotalMinutes, day.BreakTime);
            }
        }
    }
}