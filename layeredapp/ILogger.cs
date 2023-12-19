namespace loggerLib
{
    public interface ILogger:IDisposable
    {
        void Log(string message);    
    }
}