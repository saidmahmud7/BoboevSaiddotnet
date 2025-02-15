using IlogDestination;

public class FileLogDestination : ILogDestination
{
    public void Log(string message)
    {
        try
        {
            var filePath = "error_log.txt"; // Path to your log file
            using (var writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"[{DateTime.Now}] - {message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to log error to file: {ex.Message}");
        }
    }
}