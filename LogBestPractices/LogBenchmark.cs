using BenchmarkDotNet.Attributes;

using Microsoft.Extensions.Logging;

using System;

namespace LogBestPractices
{
    [MemoryDiagnoser]
    public class LogBenchmark
    {
        private static readonly DateTime timestamp = DateTime.Now;
        private static readonly Guid processId = Guid.NewGuid();

        private static readonly string LogMessageTemplate = "{Timestamp} {ProcessId} This is a log message with a decimal parameter '{Value}'";

        private readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFakeLogger().SetMinimumLevel(LogLevel.Warning);
        });

        private readonly ILogger<LogBenchmark> logger;
        private readonly ILoggerAdapter<LogBenchmark> loggerAdapter;

        public LogBenchmark()
        {
            logger = new Logger<LogBenchmark>(loggerFactory);
            loggerAdapter = new LoggerAdapter<LogBenchmark>(logger);
        }

        [Benchmark]
        public void SimpleProcess()
        {
            logger.LogInformation(LogMessageTemplate);
        }

        [Benchmark]
        public void SimpleProcessWithParams()
        {
            logger.LogInformation(LogMessageTemplate, timestamp, processId, 1.12334234m);
        }

        [Benchmark]
        public void SimpleProcessWithStringInterpolation()
        {
            logger.LogInformation($"{timestamp} {processId} This is a log message with a decimal parameter '{1.12334234m}'");
        }

        [Benchmark]
        public void SimpleProcessWithIf()
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation(LogMessageTemplate);
            }
        }

        [Benchmark]
        public void SimpleProcessWithParamsWithIf()
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation(LogMessageTemplate, timestamp, processId, 1.12334234m);
            }
        }

        [Benchmark]
        public void SimpleProcessWithStringInterpolationWithIf()
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation($"{timestamp} {processId} This is a log message with a decimal parameter '{1.12334234m}'");
            }
        }

        [Benchmark]
        public void HeavyProccessWithParams()
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                logger.LogInformation(LogMessageTemplate, timestamp, processId, 1.12334234m);
            }
        }

        [Benchmark]
        public void HeavyProccessWithParamsWithIf()
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                if (logger.IsEnabled(LogLevel.Information))
                {
                    logger.LogInformation(LogMessageTemplate, timestamp, processId, 1.12334234m);
                }
            }
        }

        [Benchmark]
        public void HeavyProccessAdapterWithParams()
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                loggerAdapter.LogInformation(LogMessageTemplate, timestamp, processId, 1.12334234m);
            }
        }

        [Benchmark]
        public void HeavyProccessWithStringInterpolation()
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                logger.LogInformation($"{timestamp} {processId} This is a log message with a decimal parameter '{1.12334234m}'");
            }
        }

        [Benchmark]
        public void HeavyProccessWithStringInterpolationWithIf()
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                if (logger.IsEnabled(LogLevel.Information))
                {
                    logger.LogInformation($"{timestamp} {processId} This is a log message with a decimal parameter '{1.12334234m}'");
                }
            }
        }
    }
}
