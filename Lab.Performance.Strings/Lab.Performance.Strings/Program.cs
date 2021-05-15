using BenchmarkDotNet.Running;

namespace Lab.Performance.Strings
{
    static class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<StringsBenchmark>();
        }
    }
}
