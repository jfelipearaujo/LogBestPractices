using Serilog;

namespace LogBestPractices
{
    public class LoggerAdapter : ILoggerAdapter
    {
        private readonly ILogger logger;

        public LoggerAdapter(ILogger logger)
        {
            this.logger = logger;
        }

        public void Information(string message)
        {
            logger.Information(message);
        }

        public void Information<T0>(string messageTemplate, T0 t0)
        {
            logger.Information(messageTemplate, t0);
        }

        public void Information<T0, T1>(string messageTemplate, T0 t0, T1 t1)
        {
            logger.Information(messageTemplate, t0, t1);
        }

        public void Information<T0, T1, T2>(string messageTemplate, T0 t0, T1 t1, T2 t2)
        {
            logger.Information(messageTemplate, t0, t1, t2);
        }
    }

    public interface ILoggerAdapter
    {
        void Information(string message);
        void Information<T0>(string messageTemplate, T0 t0);
        void Information<T0, T1>(string messageTemplate, T0 t0, T1 t1);
        void Information<T0, T1, T2>(string messageTemplate, T0 t0, T1 t1, T2 t2);
    }
}

