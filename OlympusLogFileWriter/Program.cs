using System.Diagnostics;

namespace OlympusLogFileWriter
{
    class Program
    {
        static void Main()
        {
            
            int threadsCount = 10;

            try
            {
                // Start stopwatch before running the program
                var stopwatch = Stopwatch.StartNew();

                // Create and start multiple threads
                Thread[] threads = new Thread[threadsCount];
                for (int i = 0; i < threads.Length; i++)
                {
                    threads[i] = new Thread(() => LogFileWriter.Instance.WriteToFile());
                    threads[i].Start();
                }

                // Wait for all threads to complete
                foreach (Thread thread in threads)
                {
                    thread.Join();
                }

                // Stop stopwatch and calculate total execution time
                stopwatch.Stop();
                var elapsedTime = stopwatch.ElapsedMilliseconds;
                Console.WriteLine($"Total execution time: {elapsedTime} milliseconds");

                // Check if there is a console available before attempting to read a key
                if (Environment.UserInteractive)
                {
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadLine();
                }
            }
            // Handle exceptions that might occur during program execution
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}