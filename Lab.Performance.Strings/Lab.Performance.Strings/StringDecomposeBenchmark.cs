using BenchmarkDotNet.Attributes;

namespace Lab.Performance.Strings
{

    [SimpleJob(targetCount: 100)]
    [MemoryDiagnoser]
    public class StringDecomposeBenchmark
    {
        private const string urlPath = "/span/some-action/1234567890";

        [Benchmark]
        public string IndexOf() =>
            urlPath.Substring(urlPath.IndexOf('/'), urlPath.IndexOf('/', 1) - 1);

        [Benchmark]
        public string Split() =>
            urlPath.Split('/')[0];
    }
}
