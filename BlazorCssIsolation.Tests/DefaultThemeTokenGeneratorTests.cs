using BlazorCssIsolation.Theming.Themes;
using BlazorCssIsolation.Theming.Themes.Algorithms;
using BlazorCssIsolation.Theming.Tokens;
using System.Text.Json;

namespace BlazorCssIsolation.Tests
{
    [TestClass]
    public class DefaultThemeTokenGeneratorTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var collection = new DefaultThemeAlgorithm(new ColorDerivative()).Derive(SeedToken.Default);
            var pairs = JsonSerializer.Deserialize<Dictionary<string, object?>>(JsonSerializer.Serialize(collection))!;

            var json = File.ReadAllText("./defaultTheme.json");
            var pairsToCompare = JsonSerializer.Deserialize<Dictionary<string, object?>>(json)!;

            var allKeys = pairs.Keys.Concat(pairsToCompare.Keys).Distinct().ToList();

            var merged = allKeys.OrderBy(x => x).ToDictionary(x => x, x => new
            {
                A = pairs.ContainsKey(x) ? pairs[x] : "NULL",
                B = pairsToCompare.ContainsKey(x) ? pairsToCompare[x] : "NULL",
            }).ToDictionary(x => x.Key, x => new
            {
                A = x.Value.A,
                B = x.Value.B,
                Same = x.Value.A?.ToString() == x.Value.B?.ToString()
            }).Where(x => !x.Value.Same);

            File.WriteAllText("./compare.json", JsonSerializer.Serialize(merged, new JsonSerializerOptions
            {
                WriteIndented = true,
            }));
        }
    }
}