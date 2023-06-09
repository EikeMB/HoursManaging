using System.Reflection.PortableExecutable;

namespace HoursManaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime startMonday = new DateTime(2023, 6, 5, 9, 15, 0);
            DateTime endMonday = new DateTime(2023, 6, 5, 17, 15, 0);
            Day monday = new Day(startMonday, endMonday);
            DateTime startTuesday = new DateTime(2023, 6, 6, 9, 15, 0);
            DateTime endTuesday = new DateTime(2023, 6, 6, 16, 15, 0);
            Day tuesday = new Day(startTuesday, endTuesday);
            DateTime startWed = new DateTime(2023, 6, 7, 9, 15, 0);
            DateTime endWed = new DateTime(2023, 6, 7, 20, 30, 0);
            Day wed = new Day(startWed, endWed);
            DateTime startThur = new DateTime(2023, 6, 8, 9, 15, 0);
            DateTime endThur = new DateTime(2023, 6, 8, 15, 30, 0);
            Day thur = new Day(startThur, endThur);

            Week weekJune5 = new Week(new DateTime(2023, 6, 5));

            weekJune5.AddDay(monday);
            weekJune5.AddDay(tuesday);
            weekJune5.AddDay(wed);
            weekJune5.AddDay(thur);

            Console.WriteLine("start: " + weekJune5.StartDate);
            Console.WriteLine("Hours: " + weekJune5.Hours);
            Console.WriteLine("Minutes: " + weekJune5.Minutes);
            Console.WriteLine("Missing hours: " + weekJune5.MissingHours);
            Console.WriteLine("Missing minutes: " + weekJune5.MissingMinutes);
            

        }
    }
}