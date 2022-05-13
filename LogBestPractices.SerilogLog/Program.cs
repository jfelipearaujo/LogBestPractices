using BenchmarkDotNet.Running;

namespace LogBestPractices.SerilogLog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<LogBenchmark>();
        }
    }
}
