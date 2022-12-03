using BlazorCssIsolation.Themes.Default;
using BlazorCssIsolation.Tokens;

namespace BlazorCssIsolation.Tests
{
    [TestClass]
    public class DefaultThemeTokenGeneratorTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var gen = new DefaultThemeTokenGenerator(null);

            gen.Generate(SeedToken.Default);
        }
    }
}