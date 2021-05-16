using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using System;
using System.Text;

namespace Lab.Performance.Strings
{
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    [SimpleJob(RunStrategy.ColdStart, launchCount: 5, targetCount: 100)]
    public class StringsBenchmark
    {
        private readonly StringBuilder _stringBuilder = new StringBuilder();

        private readonly string scheme;
        private readonly string host;
        private readonly string path;
        private readonly string queryString;

        public StringsBenchmark()
        {
            scheme = Guid.NewGuid().ToString();
            host = Guid.NewGuid().ToString();
            path = Guid.NewGuid().ToString();
            queryString = Guid.NewGuid().ToString();
        }

        [Benchmark]
        public string PlusConcat() =>
            scheme + "://" + host + path + queryString;

        [Benchmark]
        public string StringConcat() =>
            string.Concat(scheme, "://", host, path, queryString);

        [Benchmark]
        public string Interpolation() =>
            $"{scheme}://{host}{path}{queryString}";

        [Benchmark]
        public string StringBuilder()
        {
            _stringBuilder.Clear();
            return _stringBuilder.Append(scheme)
                                 .Append("://")
                                 .Append(host)
                                 .Append(path)
                                 .Append(queryString)
                                 .ToString();
        }
    }
}
