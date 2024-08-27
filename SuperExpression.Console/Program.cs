using SuperExpression.Benchmark.BenchmarkClass;

namespace SuperExpression.Console2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SwitchVsDictionary svd = new SwitchVsDictionary();
            svd.Setup();
            svd.DiscoveryBySwitchCaseExpressionTree();
        }
    }
}