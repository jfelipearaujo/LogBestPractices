using Serilog;
using Serilog.Context;
using Serilog.Events;

namespace LogBestPractices
{
    public class LoggerAdapter : ILoggerAdapter
    {
        private readonly ILogger logger;

        public LoggerAdapter(ILogger logger)
        {
            this.logger = logger;
        }

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Debug<T0>(string messageTemplate, T0 t0)
        {
            logger.Debug(messageTemplate, t0);
        }

        public void Debug<T0, T1>(string messageTemplate, T0 t0, T1 t1)
        {
            logger.Debug(messageTemplate, t0, t1);
        }

        public void Debug<T0, T1, T2>(string messageTemplate, T0 t0, T1 t1, T2 t2)
        {
            logger.Debug(messageTemplate, t0, t1, t2);
        }

        public void DebugWithData<T0, T1, T2, TData>(string messageTemplate, T0 t0, T1 t1, T2 t2, TData data)
        {
            using (var context = LogContext.PushProperty("data", data, true))
            {
                logger.Debug(messageTemplate, t0, t1, t2);
            }
        }

        public void DebugWithIfWithData<T0, T1, T2, TData>(string messageTemplate, T0 t0, T1 t1, T2 t2, TData data)
        {
            if (logger.IsEnabled(LogEventLevel.Debug))
            {
                using (var context = LogContext.PushProperty("data", data, true))
                {
                    logger.Debug(messageTemplate, t0, t1, t2);
                }
            }
        }
    }

    public interface ILoggerAdapter
    {
        void Debug(string message);
        void Debug<T0>(string messageTemplate, T0 t0);
        void Debug<T0, T1>(string messageTemplate, T0 t0, T1 t1);
        void Debug<T0, T1, T2>(string messageTemplate, T0 t0, T1 t1, T2 t2);
        void DebugWithData<T0, T1, T2, TData>(string messageTemplate, T0 t0, T1 t1, T2 t2, TData data);
        void DebugWithIfWithData<T0, T1, T2, TData>(string messageTemplate, T0 t0, T1 t1, T2 t2, TData data);
    }
}

