using Microsoft.Extensions.Logging;

namespace LogBestPractices
{
    public class LoggerAdapter<T> : ILoggerAdapter<T>
    {
        private readonly ILogger<T> logger;

        public LoggerAdapter(ILogger<T> logger)
        {
            this.logger = logger;
        }

        public void LogDebug(string message)
        {
            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.LogDebug(message);
            }
        }

        public void LogDebug<T0>(string messageTemplate, T0 t0)
        {
            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.LogDebug(messageTemplate, t0);
            }
        }

        public void LogDebug<T0, T1>(string messageTemplate, T0 t0, T1 t1)
        {
            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.LogDebug(messageTemplate, t0, t1);
            }
        }

        public void LogDebug<T0, T1, T2>(string messageTemplate, T0 t0, T1 t1, T2 t2)
        {
            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.LogDebug(messageTemplate, t0, t1, t2);
            }
        }

        public void LogDebugWithData<T0, T1, T2, TData>(string messageTemplate, T0 t0, T1 t1, T2 t2, TData data)
        {
            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.LogDebug(messageTemplate, t0, t1, t2, data);
            }
        }
    }

    public interface ILoggerAdapter<T>
    {
        void LogDebug(string message);
        void LogDebug<T0>(string messageTemplate, T0 t0);
        void LogDebug<T0, T1>(string messageTemplate, T0 t0, T1 t1);
        void LogDebug<T0, T1, T2>(string messageTemplate, T0 t0, T1 t1, T2 t2);
        void LogDebugWithData<T0, T1, T2, TData>(string messageTemplate, T0 t0, T1 t1, T2 t2, TData data);
    }
}

