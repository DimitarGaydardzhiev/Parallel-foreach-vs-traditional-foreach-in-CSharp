using System.Diagnostics;

namespace Program
{
    internal class Program
    {
        private const int FakeJobTimeInMs = 100;

        static void Main()
        {
            var cities = new List<string>();
            cities.Add("London");
            cities.Add("New York");
            cities.Add("Tokyo");
            cities.Add("Sidney");
            cities.Add("Cairo");
            cities.Add("Lima");

            // Execute Parallel.ForEach
            var stopwatch = Stopwatch.StartNew();
            // pass new ParallelOptions() { MaxDegreeOfParallelism = 2 } to controll the number of threads allowed to execute in parallel
            Parallel.ForEach(cities, (s) =>
            {
                DoSomeJob(FakeJobTimeInMs);
            });
            Console.WriteLine($"Parallel foreach time elapsed: {stopwatch.Elapsed.TotalSeconds}");
            stopwatch.Stop();

            // Execute traditional foreach
            stopwatch = Stopwatch.StartNew();
            foreach (var city in cities)
            {
                DoSomeJob(FakeJobTimeInMs);
            }
            Console.WriteLine($"Traditional foreach time elapsed: {stopwatch.Elapsed.TotalSeconds}");
            stopwatch.Stop();
        }

        private static void DoSomeJob(int timeInMs)
        {
            Thread.Sleep(timeInMs);
        }
    }
}
