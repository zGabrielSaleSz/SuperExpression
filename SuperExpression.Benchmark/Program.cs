using BenchmarkDotNet.Running;
using SuperExpression.Benchmark.BenchmarkClass;

namespace SuperExpression.Benchmark
{
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<SwitchVsDictionary>();
        }
    }
}