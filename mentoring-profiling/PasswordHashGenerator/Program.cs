using System;
using System.Diagnostics;

namespace PasswordHashGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            ProfileUsingStopWatch();

            //ProfileUsingPerformanceAnalyzer();

            //RegularRun();
        }

        private static void ProfileUsingPerformanceAnalyzer()
        {
            var password = "Dmitry12345";
            byte[] salt = new byte[16];
            var watch = new Stopwatch();
            watch.Start();
            var hash = PasswordHashGenerator.GeneratePasswordHashUsingSalt(password, salt);
            watch.Stop();
            Console.WriteLine(watch.ElapsedTicks);
        }

        private static void RegularRun()
        {
            do
            {
                Console.Write("Enter password: ");
                var password = Console.ReadLine();

                byte[] salt = new byte[16];
                var hash = PasswordHashGenerator.GeneratePasswordHashUsingSalt(password, salt);
                Console.WriteLine($"Hash: {hash}");
                Console.WriteLine("Press any key to continue, Escape to exit.");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static void ProfileUsingStopWatch()
        {
            int iterations = 10;

            long minTime = long.MaxValue;
            for (int i = 0; i < iterations; i++)
            {
                var password = "Dmitry12345";
                byte[] salt = new byte[16];

                var watch = new Stopwatch();
                watch.Start();
                var hash = PasswordHashGenerator.GeneratePasswordHashUsingSalt(password, salt);
                watch.Stop();
                if (minTime > watch.ElapsedTicks) minTime = watch.ElapsedTicks;
            }

            Console.WriteLine(minTime);
        }
    }
}
