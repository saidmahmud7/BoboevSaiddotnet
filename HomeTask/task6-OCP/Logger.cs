using IlogDestination;

namespace log;
public class Logger
{
    private readonly ILogDestination _logDestination;
    public Logger(ILogDestination logDestination)
    {
        _logDestination = logDestination;
    }

    public void LogError(string message)
    {
        if (string.IsNullOrEmpty(message)) throw new Exception("Message cannot be null or empty");
        
        _logDestination.Log(message);
    }
}