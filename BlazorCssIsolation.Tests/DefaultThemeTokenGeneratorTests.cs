using BlazorCssIsolation.Themes.Default;
using BlazorCssIsolation.Theming.Themes;
using BlazorCssIsolation.Theming.Tokens;

namespace BlazorCssIsolation.Tests
{
    [TestClass]
    public class DefaultThemeTokenGeneratorTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var gen = new DefaultThemeTokenGenerator(new ColorDerivative())
                .Generate(SeedToken.Default);

            foreach (var token in gen)
            {
                Console.WriteLine(token);
            }
        }
    }
}