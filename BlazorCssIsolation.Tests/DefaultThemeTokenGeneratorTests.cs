using BlazorCssIsolation.Theming.Themes;
using BlazorCssIsolation.Theming.Themes.Algorithms;
using BlazorCssIsolation.Theming.Tokens;
using System.Text.Json;

namespace BlazorCssIsolation.Tests
{
    [TestClass]
    public class DefaultThemeTokenGeneratorTests
    {
        /*
***5*** Blue
{ ok: true, format: 'hex', r: 22, g: 119, b: 255, a: 1 }
{ h: 215.02145922746783, s: 0.9137254901960784, v: 1 }
{ h: 205, s: 0.1, v: 1 }
{ ok: true, format: 'hsv', r: 229.5, g: 244.375, b: 255, a: 1 }
#e6f4ff

***8*** Blue
{ ok: true, format: 'hex', r: 22, g: 119, b: 255, a: 1 }
{ h: 215.02145922746783, s: 0.9137254901960784, v: 1 }
{ h: 219, s: 1, v: 0.7 }
{
  ok: true,
  format: 'hsv',
  r: 0,
  g: 62.475000000000094,
  b: 178.5,
  a: 1
}
#003eb3

***5*** Yellow
{ ok: true, format: 'hex', r: 250, g: 219, b: 20, a: 1 }
{ h: 51.91304347826087, s: 0.9199999999999999, v: 0.9803921568627451 }
{ h: 62, s: 0.1, v: 1 }
{ ok: true, format: 'hsv', r: 254.15, g: 255, b: 229.5, a: 1 }
#feffe6
         */

        [TestMethod]
        public void TestMethod1()
        {
            var collection = new DefaultThemeAlgorithm(new ColorDerivative()).Derive(SeedToken.Default);
            var pairs = JsonSerializer.Deserialize<Dictionary<string, object?>>(JsonSerializer.Serialize(collection))!;

            var json = File.ReadAllText("./themes/defaultTheme.json");
            var pairsToCompare = JsonSerializer.Deserialize<Dictionary<string, object?>>(json)!;

            var allKeys = pairs.Keys.Concat(pairsToCompare.Keys).Distinct().ToList();

            var merged = allKeys.OrderBy(x => x).ToDictionary(x => x, x => new
            {
                A = pairs.ContainsKey(x) ? pairs[x] : "NULL",
                B = pairsToCompare.ContainsKey(x) ? pairsToCompare[x] : "NULL",
            }).Where(x => x.Value.B?.ToString() != "NULL").ToDictionary(x => x.Key, x => new
            {
                A = x.Value.A,
                B = x.Value.B,
                Same = x.Value.A?.ToString() == x.Value.B?.ToString()
            }).Where(x => !x.Value.Same);

            File.WriteAllText("./diff.json", JsonSerializer.Serialize(merged, new JsonSerializerOptions
            {
                WriteIndented = true,
            }));
        }

        [TestMethod]
        public void TestMethod2()
        {
            var collectionA = new DefaultThemeAlgorithm(new ColorDerivative()).Derive(SeedToken.Default);

            var collectionB = new DefaultThemeAlgorithm(new ColorDerivative()).Derive(SeedToken.Default);

            collectionB = collectionB with { Blue10 = "#f00" };

            var diff = collectionA.CompareChanges(collectionB);

            var prefix = SeedToken.Default.VarPrefix;

            var cssVars = diff.Where(x => x.Status == ChangeStatus.Modified || x.Status == ChangeStatus.Added)
                  .Select(x => (x.TargetValue ?? new DesignToken(x.Key, null)).ToCssVar(prefix))
                  .ToList();

            var cssVars2 = collectionB.GetDesignTokens().Select(x=>x.Value.ToCssVar(prefix)).ToList();
        }
    }
}