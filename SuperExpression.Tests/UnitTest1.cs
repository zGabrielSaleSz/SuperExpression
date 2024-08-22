using SuperExpression.Benchmark.BenchmarkClass;

namespace SuperExpression.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void FSwitchVsDictionary()
        {
            var a = new SwitchVsDictionary();
            a.Setup();
            a.DiscoveryByDictionary();
            a.DiscoveryBySwitchCase();
        }
    }
}