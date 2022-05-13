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

        public void LogInformation(string message)
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation(message);
            }
        }

        public void LogInformation<T0>(string messageTemplate, T0 t0)
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation(messageTemplate, t0);
            }
        }

        public void LogInformation<T0, T1>(string messageTemplate, T0 t0, T1 t1)
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation(messageTemplate, t0, t1);
            }
        }

        public void LogInformation<T0, T1, T2>(string messageTemplate, T0 t0, T1 t1, T2 t2)
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation(messageTemplate, t0, t1, t2);
            }
        }
    }

    public interface ILoggerAdapter<T>
    {
        void LogInformation(string message);
        void LogInformation<T0>(string messageTemplate, T0 t0);
        void LogInformation<T0, T1>(string messageTemplate, T0 t0, T1 t1);
        void LogInformation<T0, T1, T2>(string messageTemplate, T0 t0, T1 t1, T2 t2);
    }
}

