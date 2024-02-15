**Olympus Log File Writer**

**Overview:**

The Olympus Log File Writer is a multithreaded .NET 6 console application designed to demonstrate synchronized file writing. The application initializes a log file, launches multiple threads, and each thread appends a predefined number of lines to the file in a synchronized manner. The resulting log file contains line information with thread IDs and timestamps.

**Classes:**

**LogFileWriter Class:-**

Singleton Pattern: The class follows the singleton pattern to ensure only one instance exists throughout the application. The instance is created and initialized upon the first reference.

**Thread Safety:** The lock keyword is used to ensure synchronized access to shared resources during file writing. Each thread increments the line count and appends lines to the log file.

**Error Handling:** Specific exceptions such as IOException, UnauthorizedAccessException, and general Exception are caught during file writing to provide meaningful error messages.

**Initialization:** The log file is initialized with an initial line containing timestamp information.

**Program Class:-**

**Multithreading:** The application launches multiple threads to simulate concurrent writing to the log file. Each thread invokes the WriteToFile method of the LogFileWriter singleton instance.

**Execution Time Measurement:** The program uses Stopwatch to measure the total execution time of the multithreaded operation.

**User Interaction:** If running in an interactive mode (checked with Environment.UserInteractive), the application prompts the user to press any key before exiting.


**Special Considerations:**

**Thread Safety:** The application uses a locking mechanism to ensure thread safety during file writing. This helps prevent race conditions and ensures synchronized access to shared resources.

**Error Logging:** Specific exceptions during file writing are logged to the console for immediate debugging. In a production environment, consider enhancing error logging with a more robust logging framework.

**File Path:** The file path is currently hardcoded as "/log/out.txt". Adjust the path based on the desired location on your file system.

**Initialization:** The log file is initialized with an initial line containing timestamp information to establish a baseline.

**User Interaction:** The application checks for user interactivity before prompting for key input. This is important for scenarios where the application might run in a non-interactive environment.

**Usage:**

**Build and Run:** Ensure you have the .NET 6 runtime installed. Clone the repository, navigate to the project directory, and run dotnet run.

**Docker Containerization:** The application can be containerized using the provided Dockerfile. Build the Docker image and run the container, ensuring proper volume mounting for the log file.


**To Build Docker image:-**

docker build -t olympuslogfilewriter .

**To Run Docker image:-**

docker run -i -v /path/on/host:/log olympuslogfilewriter

(Replace /path/on/host with the absolute path on your host machine where you want to store the output file.)
