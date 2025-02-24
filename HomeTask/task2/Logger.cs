class Logger
{
    public string Log { get; set; }
    public int LogCode { get; set; }
    
    public void LogError(string? Message,int LogCode)
    {
        Console.WriteLine(LogCode + " : " + Message);
    }
}