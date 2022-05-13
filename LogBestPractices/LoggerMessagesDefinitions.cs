using Microsoft.Extensions.Logging;

using System;

namespace LogBestPractices
{
    public static class LoggerMessagesDefinitions
    {
        private static readonly Action<ILogger, DateTime, Guid, decimal, Exception?> MyLogMessageDefinition =
            LoggerMessage.Define<DateTime, Guid, decimal>(
                LogLevel.Information,
                new EventId(1, "MyLogMessage"),
                "{Timestamp} {ProcessId} This is a log message with a decimal parameter '{value}'");

        public static void MyLogMessage(this ILogger logger, DateTime timestamp, Guid processId, decimal value)
        {
            MyLogMessageDefinition(logger, timestamp, processId, value, null);
        }
    }

    public static partial class LoggerMessagesDefinitionsGen
    {
        [LoggerMessage(EventId = 0, Level = LogLevel.Information, Message = "{Timestamp} {ProcessId} This is a log message with a decimal parameter '{Value}'")]
        public static partial void MyLogMessageGen(this ILogger logger, DateTime timestamp, Guid processId, decimal value);
    }
}
