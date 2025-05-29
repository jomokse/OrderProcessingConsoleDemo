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
            // Ensure the project path is correct relative to the test assembly.
            var projectPath = Path.GetFullPath(
                Path.Combine(AppContext.BaseDirectory, "../../../../OrderProcessingConsoleDemo/OrderProcessingConsoleDemo.csproj"));

            Assert.True(File.Exists(projectPath), $"Project file not found: {projectPath}");            

            // Variable to capture the application's output.
            var output = string.Empty;

            // Configure the process start info to run the application using 'dotnet run'.
            // --project OrderProcessingConsoleDemo specifies which project to run.
            // RedirectStandardOutput and RedirectStandardError allow capturing console output.
            var psi = new ProcessStartInfo("dotnet", $"run --project \"{projectPath}\"")            
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false
            };

            // Start the process and asynchronously read the standard output.
            using var process = Process.Start(psi)!;
            output = await process.StandardOutput.ReadToEndAsync();
            await process.WaitForExitAsync();

            // Check if the process exited successfully. 
            var errorOutput = await process.StandardError.ReadToEndAsync();
            if (process.ExitCode != 0)
            {
                throw new Exception($"dotnet run failed: {errorOutput}");
            }            

            // Assert that the output contains the expected customer and total.
            // This verifies both correct business logic and successful execution.
            Assert.Contains("The order for the customer: John Doe", output);
            Assert.Contains("Total: 270", output);
        }
    }
}
