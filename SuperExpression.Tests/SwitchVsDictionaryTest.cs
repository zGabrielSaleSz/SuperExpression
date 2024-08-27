using SuperExpression.Benchmark.BenchmarkClass;

namespace SuperExpression.Tests
{
    public class SwitchVsDictionaryTest
    {
        [Fact]
        public void FSwitchVsDictionary()
        {
            var a = new SwitchVsDictionary();
            a.Setup();
            a.DiscoveryByDictionary();
            a.DiscoveryByConcurrentDictionary();
            a.DiscoveryBySwitchCaseExpressionTree();
            a.DiscoveryBySwitchCaseHardCoded();
        }
    }
}