using System.Reflection.PortableExecutable;

namespace HoursManaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime startMonday = new DateTime(2023, 6, 5, 9, 0, 0);
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

            

        }
    }
}