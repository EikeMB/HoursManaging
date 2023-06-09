namespace HoursManaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime start = new DateTime(2023, 6, 7, 9, 15, 0);
            DateTime end = new DateTime(2023, 6, 7, 21, 0, 0);
            Day day = new Day(start, end);

            Console.WriteLine(day.TotalHours);
            Console.WriteLine(day.TotalMinutes);
            Console.WriteLine(day.BreakTime);
        }
    }
}