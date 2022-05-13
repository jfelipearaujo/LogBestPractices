using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.Console;

using System;

namespace LogBestPractices
{
    public class FakeLogProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new FakeLogger();
        }

        public void Dispose()
        {
        }
    }

    public class FakeLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return new FakeDisposable();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.None;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            // Do nothing
        }
    }

    public class FakeDisposable : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public static class FakeLoggerExtensions
    {
        public static ILoggingBuilder AddFakeLogger(this ILoggingBuilder builder)
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, FakeLogProvider>());
            LoggerProviderOptions.RegisterProviderOptions<ConsoleLoggerOptions, FakeLogProvider>(builder.Services);
            return builder;
        }
    }
}
