using System.Threading;

namespace DP_Project
{
    public class WatchDog
    {
        public static void Check()
        {
            while (true)
            {
                Visitor.Visit();
                Thread.Sleep(5000);
            }
        }
    }
}