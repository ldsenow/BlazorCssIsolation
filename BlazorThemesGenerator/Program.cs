using BlazorCssIsolation.Theming;
using BlazorCssIsolation.Theming.Themes;
using BlazorCssIsolation.Theming.Themes.Algorithms;
using BlazorCssIsolation.Theming.Tokens;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.AddBlazorCssIsolationTheming();
            });

        var host = builder.Build();


        var outputFile = "../../../../BlazorCssIsolation/ConfigProvider.razor.css";
        var themeGenerator = host.Services.GetRequiredService<IThemeGenerator>();
        var defaultAlgorithm = host.Services.GetRequiredService<DefaultThemeAlgorithm>();

        var sb = new StringBuilder();
        sb.AppendLine("/******************************/");
        sb.AppendLine("/*** WOW! Generated Content! ***/");
        sb.AppendLine("/******************************/");
        BuildCssVars(sb, themeGenerator, defaultAlgorithm);

        await File.WriteAllTextAsync(outputFile, sb.ToString());

        await host.StartAsync();
    }

    private static void BuildCssVars(StringBuilder sb, IThemeGenerator themeGenerator, IThemeAlgorithm algorithm)
    {
        Console.WriteLine($"****** Building theme {algorithm.Name} ******");

        var themeToken = themeGenerator.Generate(SeedToken.Default, algorithm);
        var designTokens = themeToken.GetDesignTokens();
        var cssVars = designTokens.ToCssVars(themeToken.VarPrefix);

        sb.AppendLine($"/* Theme: {algorithm.Name} */");
        sb.AppendLine($"::deep.{themeToken.VarPrefix}.{themeToken.VarPrefix}-{algorithm.Name} {{");
        sb.AppendLine(cssVars);
        sb.AppendLine("}");
    }
}