using System;
namespace OlympusLogFileWriter
{
    public class LogFileWriter
    {
        private static readonly LogFileWriter instance = new();
        private readonly object lockObject = new object();
        private readonly int linesPerThread = 10;
        private int lineCount = 0;
        private readonly string filePath = "/log/out.txt";

        public LogFileWriter()
        {
            InitializeFile();
        }

        public static LogFileWriter Instance => instance;


        // Initialize the log file with the initial line
        private void InitializeFile()
        {
            // Use StreamWriter to write the initial line to the file
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.WriteLine($"0, 0, {DateTime.Now:HH:mm:ss.fff}");
            }
        }

        // Method responsible for writing lines to the log file
        public void WriteToFile()
        {
            for (int i = 0; i < linesPerThread; i++)
            {
                // Use a lock to ensure synchronized access to shared resources
                lock (lockObject)
                {
                    try
                    {
                        // Increment line count
                        lineCount++;

                        // Use StreamWriter to append a new line to the file
                        using (StreamWriter sw = new StreamWriter(filePath, true))
                        {
                            sw.WriteLine($"{lineCount}, {Environment.CurrentManagedThreadId}, {DateTime.Now:HH:mm:ss.fff}");
                        }
                    }
                    // Handle specific exceptions
                    catch (IOException ex)
                    {
                        Console.WriteLine($"An I/O error occurred: {ex.Message}");
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        Console.WriteLine($"Access error: {ex.Message}");
                    }
                    // Catch any other unexpected exceptions
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    }
                }
            }
        }
    }
}