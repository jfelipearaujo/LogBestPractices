using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

using Microsoft.Extensions.Logging;

using System;

namespace LogBestPractices
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [MemoryDiagnoser]
    public class LogBenchmark
    {
        private static readonly DateTime timestamp = DateTime.Now;
        private static readonly Guid processId = Guid.NewGuid();
        private static readonly User user = new(Guid.NewGuid(), "John Doe");

        private static readonly string LogMessageTemplate = "{Timestamp} {ProcessId} This is a log message with a decimal parameter '{Value}'";

        private readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFakeLogger().SetMinimumLevel(LogLevel.Debug);
        });

        private readonly ILogger<LogBenchmark> logger;
        private readonly ILoggerAdapter<LogBenchmark> loggerAdapter;

        public LogBenchmark()
        {
            logger = new Logger<LogBenchmark>(loggerFactory);
            loggerAdapter = new LoggerAdapter<LogBenchmark>(logger);
        }

        [Benchmark(Description = "SP")]
        public void SimpleProcess()
        {
            logger.LogDebug(LogMessageTemplate);
        }

        [Benchmark(Description = "SPwPar")]
        public void SimpleProcessWithParams()
        {
            logger.LogDebug(LogMessageTemplate, timestamp, processId, 1.12334234m);
        }

        [Benchmark(Description = "SPwStrInt")]
        public void SimpleProcessWithStringInterpolation()
        {
            logger.LogDebug($"{timestamp} {processId} This is a log message with a decimal parameter '{1.12334234m}'");
        }

        [Benchmark(Description = "SPwIf")]
        public void SimpleProcessWithIf()
        {
            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.LogDebug(LogMessageTemplate);
            }
        }

        [Benchmark(Description = "SPwParIf")]
        public void SimpleProcessWithParamsWithIf()
        {
            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.LogDebug(LogMessageTemplate, timestamp, processId, 1.12334234m);
            }
        }

        [Benchmark(Description = "SPwStrIntIf")]
        public void SimpleProcessWithStringInterpolationWithIf()
        {
            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.LogDebug($"{timestamp} {processId} This is a log message with a decimal parameter '{1.12334234m}'");
            }
        }

        [Benchmark(Description = "HPwPar")]
        public void HeavyProccessWithParams()
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                logger.LogDebug(LogMessageTemplate, timestamp, processId, 1.12334234m);
            }
        }

        [Benchmark(Description = "HPwAdpPar")]
        public void HeavyProcessAdapterWithParams()
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                loggerAdapter.LogDebug(LogMessageTemplate, timestamp, processId, 1.12334234m);
            }
        }

        [Benchmark(Description = "HPwAdpParAnoObj")]
        public void HeavyProcessAdapterWithParamsAndAnonymousObjData()
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                loggerAdapter.LogDebugWithData(LogMessageTemplate, timestamp, processId, 1.12334234m, new
                {
                    id = 1,
                    name = "test"
                });
            }
        }

        [Benchmark(Description = "HPwAdpParKnoObjWithIf")]
        public void HeavyProcessAdapterWithParamsAndKnownObjDataWithIf()
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                loggerAdapter.LogDebugWithData(LogMessageTemplate, timestamp, processId, 1.12334234m, user);
            }
        }

        [Benchmark(Description = "HPwAdpParAnoObjWithIf")]
        public void HeavyProcessAdapterWithParamsAndAnonymousObjDataWithIf()
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                loggerAdapter.LogDebugWithData(LogMessageTemplate, timestamp, processId, 1.12334234m, new
                {
                    id = 1,
                    name = "test"
                });
            }
        }

        [Benchmark(Description = "HPwAdpParKnoObj")]
        public void HeavyProcessAdapterWithParamsAndKnownObjData()
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                loggerAdapter.LogDebugWithData(LogMessageTemplate, timestamp, processId, 1.12334234m, user);
            }
        }

        [Benchmark(Description = "HPwParIf")]
        public void HeavyProccessWithParamsWithIf()
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                if (logger.IsEnabled(LogLevel.Debug))
                {
                    logger.LogDebug(LogMessageTemplate, timestamp, processId, 1.12334234m);
                }
            }
        }

        [Benchmark(Description = "HPwStrInt")]
        public void HeavyProcessWithStringInterpolation()
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                logger.LogDebug($"{timestamp} {processId} This is a log message with a decimal parameter '{1.12334234m}'");
            }
        }

        [Benchmark(Description = "HPwStrIntIf")]
        public void HeavyProcessWithStringInterpolationWithIf()
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                if (logger.IsEnabled(LogLevel.Debug))
                {
                    logger.LogDebug($"{timestamp} {processId} This is a log message with a decimal parameter '{1.12334234m}'");
                }
            }
        }
    }
}
