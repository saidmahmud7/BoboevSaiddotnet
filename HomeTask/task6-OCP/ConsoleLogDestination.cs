using IlogDestination;

public class ConsoleLogDestination : ILogDestination
{
    public void Log(string message)
    {
        Console.WriteLine($"[ERROR] [{DateTime.Now}] - {message}");
    }
}