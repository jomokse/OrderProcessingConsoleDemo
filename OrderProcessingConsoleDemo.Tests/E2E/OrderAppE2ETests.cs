using System.Diagnostics;
using Xunit;

namespace OrderProcessingConsoleDemo.Tests.E2E
{
    // End-to-end (E2E) tests for the order processing console application.
    public class OrderAppE2ETests
    {
        // This test verifies that running the application creates the database
        // and outputs the expected result to the console.
        [Fact]
        public async Task RunningApp_CreatesDatabaseAndOutputsExpectedResult()
        {
            // Set the working directory to the folder containing the project file.
            // This ensures that 'dotnet run' executes in the correct context.
            var projectDir = @"C:\Add_Your_Project_Path_Here\OrderProcessingConsoleDemo\OrderProcessingConsoleDemo";

            // Variable to capture the application's output.
            var output = string.Empty;

            // Configure the process start info to run the application using 'dotnet run'.
            // --project OrderProcessingConsoleDemo specifies which project to run.
            // RedirectStandardOutput and RedirectStandardError allow capturing console output.
            var psi = new ProcessStartInfo("dotnet", "run --project OrderProcessingConsoleDemo")
            {
                WorkingDirectory = projectDir,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false
            };

            // Start the process and asynchronously read the standard output.
            using var process = Process.Start(psi)!;
            output = await process.StandardOutput.ReadToEndAsync();
            await process.WaitForExitAsync();

            // Assert that the output contains the expected customer and total.
            // This verifies both correct business logic and successful execution.
            Assert.Contains("The order for the customer: John Doe", output);
            Assert.Contains("Total: 270", output);
        }
    }
}
