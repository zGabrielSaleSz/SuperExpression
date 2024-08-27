using System.Collections.Concurrent;
using BenchmarkDotNet.Attributes;
using SuperExpression.Domain;
using Newtonsoft.Json;

namespace SuperExpression.Benchmark.BenchmarkClass
{
    public class SwitchVsDictionary
    {
        private Random _random = new Random();
        private ConcurrentDictionary<string, string> _countriesByCityConcurrentDictionary;
        private Dictionary<string, string> _countriesByCityDictionary;
        private Func<string, string> _switchCaseCountriesByCity;
        private string[] _randomKeys;

        [GlobalSetup]
        public void Setup()
        {
            // 189 cases + default: null = 190 cases
            string currentPath = Path.GetFullPath(Path.Combine("config", "citiesandcountries.json"));
             _countriesByCityDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(currentPath));
            _countriesByCityConcurrentDictionary = new ConcurrentDictionary<string, string>(_countriesByCityDictionary);
            _switchCaseCountriesByCity = ExpressionBuilder.BuildSwitch<string, string>(_countriesByCityConcurrentDictionary);
            _randomKeys = _countriesByCityDictionary.Keys.OrderBy(a => _random.Next(99999)).ToArray();
        }

        [Benchmark]
        public void DiscoveryByDictionary()
        {
            foreach (var key in _randomKeys)
            {
                if (!_countriesByCityDictionary.TryGetValue(key, out var value))
                {
                    throw new Exception("shouldn't happen");
                }
            }
        }

        [Benchmark]
        public void DiscoveryByConcurrentDictionary()
        {
            foreach (var key in _randomKeys)
            {
                if (!_countriesByCityConcurrentDictionary.TryGetValue(key, out var value))
                {
                    throw new Exception("shouldn't happen");
                }
            }
        }

        [Benchmark]
        public void DiscoveryBySwitchCaseExpressionTree()
        {
            foreach (var key in _randomKeys)
            {
                var foundedValue = _switchCaseCountriesByCity.Invoke(key);
                if (foundedValue == null)
                {
                    throw new Exception("shouldn't happen");
                }
            }
        }

        [Benchmark]
        public void DiscoveryBySwitchCaseHardCoded()
        {
            foreach (var key in _randomKeys)
            {
                var foundedValue = GetCountry(key);
                if (foundedValue == null)
                {
                    throw new Exception("shouldn't happen");
                }
            }
        }

        public string GetCountry(string city)
        {
            switch (city)
            {
                case "Stockholm":
                    return "Sweden";
                case "Nantes":
                    return "France";
                case "Edinburgh":
                    return "United Kingdom";
                case "Porto Alegre":
                    return "Brazil";
                case "Belém":
                    return "Brazil";
                case "Dublin":
                    return "Ireland";
                case "Linz":
                    return "Austria";
                case "Rotterdam":
                    return "Netherlands";
                case "Helsinki":
                    return "Finland";
                case "Genoa":
                    return "Italy";
                case "Bern":
                    return "Switzerland";
                case "Zurich":
                    return "Switzerland";
                case "Vienna":
                    return "Austria";
                case "Luxembourg City":
                    return "Luxembourg";
                case "Rennes":
                    return "France";
                case "Wrocław":
                    return "Poland";
                case "Orléans":
                    return "France";
                case "Melbourne":
                    return "Australia";
                case "Lausanne":
                    return "Switzerland";
                case "Tokyo":
                    return "Japan";
                case "Utrecht":
                    return "Netherlands";
                case "Oslo":
                    return "Norway";
                case "Andorra la Vella":
                    return "Andorra";
                case "Kraków":
                    return "Poland";
                case "Bratislava":
                    return "Slovakia";
                case "Campo Grande":
                    return "Brazil";
                case "Metz":
                    return "France";
                case "Jakarta":
                    return "Indonesia";
                case "Vigo":
                    return "Spain";
                case "Odessa":
                    return "Ukraine";
                case "Avignon":
                    return "France";
                case "Nancy":
                    return "France";
                case "João Pessoa":
                    return "Brazil";
                case "Florence":
                    return "Italy";
                case "Palermo":
                    return "Italy";
                case "Antwerp":
                    return "Belgium";
                case "Vilnius":
                    return "Lithuania";
                case "Athens":
                    return "Greece";
                case "Dijon":
                    return "France";
                case "Bordeaux":
                    return "France";
                case "Turin":
                    return "Italy";
                case "Tours":
                    return "France";
                case "Skopje":
                    return "North Macedonia";
                case "Florianópolis":
                    return "Brazil";
                case "Glasgow":
                    return "United Kingdom";
                case "Bruges":
                    return "Belgium";
                case "Birmingham":
                    return "United Kingdom";
                case "Brasília":
                    return "Brazil";
                case "Kyiv":
                    return "Ukraine";
                case "Málaga":
                    return "Spain";
                case "Hamburg":
                    return "Germany";
                case "Cairo":
                    return "Egypt";
                case "Zürich":
                    return "Switzerland";
                case "Chicago":
                    return "United States";
                case "Riga":
                    return "Latvia";
                case "Iași":
                    return "Romania";
                case "Rouen":
                    return "France";
                case "Toronto":
                    return "Canada";
                case "Basel":
                    return "Switzerland";
                case "Limoges":
                    return "France";
                case "Reims":
                    return "France";
                case "Cluj-Napoca":
                    return "Romania";
                case "Vaduz":
                    return "Liechtenstein";
                case "Thessaloniki":
                    return "Greece";
                case "Houston":
                    return "United States";
                case "The Hague":
                    return "Netherlands";
                case "Brussels":
                    return "Belgium";
                case "Moscow":
                    return "Russia";
                case "Lille":
                    return "France";
                case "Madrid":
                    return "Spain";
                case "Milan":
                    return "Italy";
                case "Caen":
                    return "France";
                case "Ljubljana":
                    return "Slovenia";
                case "Graz":
                    return "Austria";
                case "Mexico City":
                    return "Mexico";
                case "Poitiers":
                    return "France";
                case "Gdańsk":
                    return "Poland";
                case "Perpignan":
                    return "France";
                case "Dubai":
                    return "United Arab Emirates";
                case "Amiens":
                    return "France";
                case "Seoul":
                    return "South Korea";
                case "Teresina":
                    return "Brazil";
                case "San Marino":
                    return "San Marino";
                case "Caracas":
                    return "Venezuela";
                case "Lucerne":
                    return "Switzerland";
                case "Curitiba":
                    return "Brazil";
                case "Tirana":
                    return "Albania";
                case "Vitória":
                    return "Brazil";
                case "Volos":
                    return "Greece";
                case "Recife":
                    return "Brazil";
                case "Strasbourg":
                    return "France";
                case "Ghent":
                    return "Belgium";
                case "Lima":
                    return "Peru";
                case "Salvador":
                    return "Brazil";
                case "Grenoble":
                    return "France";
                case "Barcelona":
                    return "Spain";
                case "Goiânia":
                    return "Brazil";
                case "Mulhouse":
                    return "France";
                case "Lyon":
                    return "France";
                case "Besançon":
                    return "France";
                case "Beijing":
                    return "China";
                case "Poznań":
                    return "Poland";
                case "Angers":
                    return "France";
                case "Stuttgart":
                    return "Germany";
                case "Nîmes":
                    return "France";
                case "Maceió":
                    return "Brazil";
                case "Istanbul":
                    return "Turkey";
                case "Natal":
                    return "Brazil";
                case "Eindhoven":
                    return "Netherlands";
                case "Salzburg":
                    return "Austria";
                case "Fortaleza":
                    return "Brazil";
                case "Saint-Étienne":
                    return "France";
                case "Marseille":
                    return "France";
                case "Manchester":
                    return "United Kingdom";
                case "Versailles":
                    return "France";
                case "Funchal":
                    return "Portugal";
                case "Düsseldorf":
                    return "Germany";
                case "Sofia":
                    return "Bulgaria";
                case "Naples":
                    return "Italy";
                case "Belo Horizonte":
                    return "Brazil";
                case "Sydney":
                    return "Australia";
                case "Palmas":
                    return "Brazil";
                case "São Luís":
                    return "Brazil";
                case "Valencia":
                    return "Spain";
                case "Geneva":
                    return "Switzerland";
                case "Valletta":
                    return "Malta";
                case "Saint-Denis":
                    return "France";
                case "Copenhagen":
                    return "Denmark";
                case "Zagreb":
                    return "Croatia";
                case "Rio de Janeiro":
                    return "Brazil";
                case "Warsaw":
                    return "Poland";
                case "Minsk":
                    return "Belarus";
                case "Manaus":
                    return "Brazil";
                case "Cape Town":
                    return "South Africa";
                case "Porto Velho":
                    return "Brazil";
                case "Toulon":
                    return "France";
                case "Munich":
                    return "Germany";
                case "Venice":
                    return "Italy";
                case "Brest":
                    return "France";
                case "Heraklion":
                    return "Greece";
                case "Quito":
                    return "Ecuador";
                case "Timișoara":
                    return "Romania";
                case "Brno":
                    return "Czech Republic";
                case "Belgrade":
                    return "Serbia";
                case "New York":
                    return "United States";
                case "Chisinau":
                    return "Moldova";
                case "Montevideo":
                    return "Uruguay";
                case "Santiago":
                    return "Chile";
                case "Zaragoza":
                    return "Spain";
                case "Tallinn":
                    return "Estonia";
                case "Buenos Aires":
                    return "Argentina";
                case "Seville":
                    return "Spain";
                case "Montpellier":
                    return "France";
                case "Porto":
                    return "Portugal";
                case "Innsbruck":
                    return "Austria";
                case "Los Angeles":
                    return "United States";
                case "Leuven":
                    return "Belgium";
                case "Cologne":
                    return "Germany";
                case "Le Havre":
                    return "France";
                case "Frankfurt":
                    return "Germany";
                case "Reykjavik":
                    return "Iceland";
                case "Amsterdam":
                    return "Netherlands";
                case "Bilbao":
                    return "Spain";
                case "Bogotá":
                    return "Colombia";
                case "Paris":
                    return "France";
                case "Prague":
                    return "Czech Republic";
                case "Aix-en-Provence":
                    return "France";
                case "Aracaju":
                    return "Brazil";
                case "Toulouse":
                    return "France";
                case "Clermont-Ferrand":
                    return "France";
                case "Rome":
                    return "Italy";
                case "Podgorica":
                    return "Montenegro";
                case "Berlin":
                    return "Germany";
                case "São Paulo":
                    return "Brazil";
                case "Mumbai":
                    return "India";
                case "Boa Vista":
                    return "Brazil";
                case "Haarlem":
                    return "Netherlands";
                case "Granada":
                    return "Spain";
                case "London":
                    return "United Kingdom";
                case "Łódź":
                    return "Poland";
                case "Lisbon":
                    return "Portugal";
                case "Budapest":
                    return "Hungary";
                case "Bucharest":
                    return "Romania";
                case "Bangkok":
                    return "Thailand";
                case "Macapá":
                    return "Brazil";
                case "Nice":
                    return "France";
                case "Patras":
                    return "Greece";
                case "Sarajevo":
                    return "Bosnia and Herzegovina";
                case "Monaco":
                    return "Monaco";
                default:
                    return null;
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
           | Method                              | Mean     | Error     | StdDev    |
           |------------------------------------ |---------:|----------:|----------:|
           | DiscoveryByDictionary               | 4.691 us | 0.0101 us | 0.0089 us |
           | DiscoveryByConcurrentDictionary     | 4.798 us | 0.0060 us | 0.0050 us |
           | DiscoveryBySwitchCaseExpressionTree | 7.741 us | 0.0174 us | 0.0163 us |
           | DiscoveryBySwitchCaseHardCoded      | 3.745 us | 0.0107 us | 0.0100 us |
        */
    }
}
