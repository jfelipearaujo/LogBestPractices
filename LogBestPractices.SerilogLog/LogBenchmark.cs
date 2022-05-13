using BenchmarkDotNet.Attributes;

using Serilog;
using Serilog.Events;

using System;

namespace LogBestPractices
{
    [MemoryDiagnoser]
    public class LogBenchmark
    {
        private static readonly DateTime timestamp = DateTime.Now;
        private static readonly Guid processId = Guid.NewGuid();

        private static readonly string LogMessageTemplate = "{Timestamp} {ProcessId} This is a log message with a decimal parameter '{Value}'";

        private readonly ILogger logger;
        private readonly ILoggerAdapter loggerAdapter;

        public LogBenchmark()
        {
            logger = new LoggerConfiguration()
                .MinimumLevel.Warning()
                .WriteTo.Console()
                .CreateLogger();

            loggerAdapter = new LoggerAdapter(logger);
        }

        [Benchmark]
        public void SimpleProcess()
        {
            logger.Information(LogMessageTemplate);
        }

        [Benchmark]
        public void SimpleProcessWithParams()
        {
            logger.Information(LogMessageTemplate, timestamp, processId, 1.12334234m);
        }

        [Benchmark]
        public void SimpleProcessWithStringInterpolation()
        {
            logger.Information($"{timestamp} {processId} This is a log message with a decimal parameter '{1.12334234m}'");
        }

        [Benchmark]
        public void SimpleProcessWithIf()
        {
            if (logger.IsEnabled(LogEventLevel.Information))
            {
                logger.Information(LogMessageTemplate);
            }
        }

        [Benchmark]
        public void SimpleProcessWithParamsWithIf()
        {
            if (logger.IsEnabled(LogEventLevel.Information))
            {
                logger.Information(LogMessageTemplate, timestamp, processId, 1.12334234m);
            }
        }

        [Benchmark]
        public void SimpleProcessWithStringInterpolationWithIf()
        {
            if (logger.IsEnabled(LogEventLevel.Information))
            {
                logger.Information($"{timestamp} {processId} This is a log message with a decimal parameter '{1.12334234m}'");
            }
        }

        [Benchmark]
        public void HeavyProccessWithParams()
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                logger.Information(LogMessageTemplate, timestamp, processId, 1.12334234m);
            }
        }

        [Benchmark]
        public void HeavyProccessAdapterWithParams()
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                loggerAdapter.Information(LogMessageTemplate, timestamp, processId, 1.12334234m);
            }
        }

        [Benchmark]
        public void HeavyProccessWithParamsWithIf()
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                if (logger.IsEnabled(LogEventLevel.Information))
                {
                    logger.Information(LogMessageTemplate, timestamp, processId, 1.12334234m);
                }
            }
        }

        [Benchmark]
        public void HeavyProccessWithStringInterpolation()
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                logger.Information($"{timestamp} {processId} This is a log message with a decimal parameter '{1.12334234m}'");
            }
        }

        [Benchmark]
        public void HeavyProccessWithStringInterpolationWithIf()
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                if (logger.IsEnabled(LogEventLevel.Information))
                {
                    logger.Information($"{timestamp} {processId} This is a log message with a decimal parameter '{1.12334234m}'");
                }
            }
        }
    }
}
