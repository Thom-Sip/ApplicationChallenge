using BenchmarkDotNet.Running;

namespace HouseNumbers.Benchmark
{
    public class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<HouseNumberBenchmarking>();
        }
    }
}
