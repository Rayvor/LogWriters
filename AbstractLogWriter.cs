using System;

namespace Homework14
{
    public abstract class AbstractLogWriter : ILogWriter, IDisposable
    {
        public enum LogLevel { Info, Error, Warning }

        private const string _logMessageTemplate = "{0:yyyy-MM-ddThh:mm:ss:ffff}\t{1}\t{2}";
        public void LogError(string message)
        {
            LogWriting(String.Format(_logMessageTemplate, DateTime.Now, LogLevel.Error, message));
        }
        public void LogInfo(string message)
        {
            LogWriting(String.Format(_logMessageTemplate, DateTime.Now, LogLevel.Info, message));
        }
        public void LogWarning(string message)
        {
            LogWriting(String.Format(_logMessageTemplate, DateTime.Now, LogLevel.Warning, message));
        }
        public abstract void LogWriting(string message);

        public virtual void Dispose()
        {

        }
    }
}
