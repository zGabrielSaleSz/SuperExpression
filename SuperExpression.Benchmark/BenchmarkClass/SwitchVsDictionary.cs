using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using SuperExpression.Domain;
using System.Collections.Concurrent;

namespace SuperExpression.Benchmark.BenchmarkClass
{
    public class SwitchVsDictionary
    {
        private Random _random = new Random();
        private ConcurrentDictionary<string, string> _countriesByCity;
        private Func<string, string> _switchCaseCountriesByCity;
        private string[] _randomKeys;

        [GlobalSetup]
        public void Setup()
        {
            string currentPath = Path.GetFullPath(Path.Combine("config", "citiesandcountries.json"));
            _countriesByCity = new ConcurrentDictionary<string,string>(JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(currentPath)));
            _switchCaseCountriesByCity = ExpressionBuilder.BuildSwitch<string, string>(_countriesByCity);
            _randomKeys = _countriesByCity.Keys.OrderBy(a => _random.Next(99999)).ToArray();
        }


        [Benchmark]
        public void DiscoveryByDictionary()
        {
            foreach (var key in _randomKeys)
            {
                if (!_countriesByCity.TryGetValue(key, out var value))
                {
                    throw new Exception("Not suppose to not found");
                }
            }
        }

        [Benchmark]
        public void DiscoveryBySwitchCase()
        {
            foreach (var key in _randomKeys)
            {
                var foundedValue = _switchCaseCountriesByCity.Invoke(key);
                if (foundedValue == null)
                {
                    throw new Exception("not suppose to not found");
                }
            }
        }


        /*
         * Current benchmark results
         // * Summary *
            BenchmarkDotNet v0.14.0, Windows 10 (10.0.18363.1556/1909/November2019Update/19H2)
            AMD Ryzen 7 1800X, 1 CPU, 16 logical and 8 physical cores
            .NET SDK 7.0.100
              [Host]     : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2 [AttachedDebugger]
              DefaultJob : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2


            | Method                | Mean     | Error     | StdDev    |
            |---------------------- |---------:|----------:|----------:|
            | DiscoveryByDictionary | 4.945 us | 0.0089 us | 0.0079 us |
            | DiscoveryBySwitchCase | 7.817 us | 0.0135 us | 0.0113 us |
         
         */
    }
}
