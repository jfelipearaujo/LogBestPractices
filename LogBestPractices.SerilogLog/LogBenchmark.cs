using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

using LogBestPractices.SerilogLog;

using Serilog;
using Serilog.Events;

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

        private readonly ILogger logger;
        private readonly ILoggerAdapter loggerAdapter;

        public LogBenchmark()
        {
            logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .CreateLogger();

            loggerAdapter = new LoggerAdapter(logger);
        }

        [Benchmark(Description = "SP")]
        public void SimpleProcess()
        {
            logger.Debug(LogMessageTemplate);
        }

        [Benchmark(Description = "SPwPar")]
        public void SimpleProcessWithParams()
        {
            logger.Debug(LogMessageTemplate, timestamp, processId, 1.12334234m);
        }

        [Benchmark(Description = "SPwStrInt")]
        public void SimpleProcessWithStringInterpolation()
        {
            logger.Debug($"{timestamp} {processId} This is a log message with a decimal parameter '{1.12334234m}'");
        }

        [Benchmark(Description = "SPwIf")]
        public void SimpleProcessWithIf()
        {
            if (logger.IsEnabled(LogEventLevel.Debug))
            {
                logger.Debug(LogMessageTemplate);
            }
        }

        [Benchmark(Description = "SPwParIf")]
        public void SimpleProcessWithParamsWithIf()
        {
            if (logger.IsEnabled(LogEventLevel.Debug))
            {
                logger.Debug(LogMessageTemplate, timestamp, processId, 1.12334234m);
            }
        }

        [Benchmark(Description = "SPwStrIntIf")]
        public void SimpleProcessWithStringInterpolationWithIf()
        {
            if (logger.IsEnabled(LogEventLevel.Debug))
            {
                logger.Debug($"{timestamp} {processId} This is a log message with a decimal parameter '{1.12334234m}'");
            }
        }

        [Benchmark(Description = "HPwPar")]
        public void HeavyProcessWithParams()
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                logger.Debug(LogMessageTemplate, timestamp, processId, 1.12334234m);
            }
        }

        [Benchmark(Description = "HPwAdpPar")]
        public void HeavyProcessAdapterWithParams()
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                loggerAdapter.Debug(LogMessageTemplate, timestamp, processId, 1.12334234m);
            }
        }

        [Benchmark(Description = "HPwAdpParAnoObj")]
        public void HeavyProcessAdapterWithParamsAndAnonymousObjData()
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                loggerAdapter.DebugWithData(LogMessageTemplate, timestamp, processId, 1.12334234m, new
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
                loggerAdapter.DebugWithIfWithData(LogMessageTemplate, timestamp, processId, 1.12334234m, user);
            }
        }

        [Benchmark(Description = "HPwAdpParAnoObjWithIf")]
        public void HeavyProcessAdapterWithParamsAndAnonymousObjDataWithIf()
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                loggerAdapter.DebugWithIfWithData(LogMessageTemplate, timestamp, processId, 1.12334234m, new
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
                loggerAdapter.DebugWithData(LogMessageTemplate, timestamp, processId, 1.12334234m, user);
            }
        }

        [Benchmark(Description = "HPwParIf")]
        public void HeavyProcessWithParamsWithIf()
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                if (logger.IsEnabled(LogEventLevel.Debug))
                {
                    logger.Debug(LogMessageTemplate, timestamp, processId, 1.12334234m);
                }
            }
        }

        [Benchmark(Description = "HPwStrInt")]
        public void HeavyProcessWithStringInterpolation()
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                logger.Debug($"{timestamp} {processId} This is a log message with a decimal parameter '{1.12334234m}'");
            }
        }

        [Benchmark(Description = "HPwStrIntIf")]
        public void HeavyProcessWithStringInterpolationWithIf()
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                if (logger.IsEnabled(LogEventLevel.Debug))
                {
                    logger.Debug($"{timestamp} {processId} This is a log message with a decimal parameter '{1.12334234m}'");
                }
            }
        }
    }
}
