using IlogDestination;
using Microsoft.EntityFrameworkCore;

public class DatabaseLogDestination : ILogDestination
{
    private readonly DbContext _context;

    public DatabaseLogDestination(DbContext context)
    {
        _context = context;
    }

    public void Log(string message)
    {
        try
        {
            var errorLog = new ErrorLog
            {
                Message = message,
                Timestamp = DateTime.Now
            };

            _context.Add(errorLog);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to log error to database: {ex.Message}");
        }
    }
}