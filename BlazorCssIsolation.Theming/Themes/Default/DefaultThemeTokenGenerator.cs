using BlazorCssIsolation.Themes.Shared;
using BlazorCssIsolation.Theming;
using BlazorCssIsolation.Theming.Themes;
using BlazorCssIsolation.Theming.Tokens;
using System.Reflection;

namespace BlazorCssIsolation.Themes.Default;

public class DefaultThemeTokenGenerator : IThemeTokenGenerator
{
    private readonly IColorDerivative colorDerivative;

    public string Name => "default";

    public DefaultThemeTokenGenerator(IColorDerivative colorDerivative)
    {
        this.colorDerivative = colorDerivative;
    }

    public DesignTokenCollection Generate(SeedToken seedToken)
    {
        var tokenCollection = new DesignTokenCollection();

        PopulateSeedTokens(seedToken, tokenCollection);
        PopulateColorPalettes(seedToken, tokenCollection);
        PopulateColorMapTokens(seedToken, tokenCollection);
        PopulateSizeMapTokens(seedToken, tokenCollection);
        PopulateHeightMapTokens(seedToken, tokenCollection);
        PopulateCommonMapTokens(seedToken, tokenCollection);

        return tokenCollection;
    }

    private static void PopulateCommonMapTokens(SeedToken seedToken, DesignTokenCollection tokenCollection)
    {
        var tokens = CommonTokensGenerator.Genereate(seedToken);
        var tokenNames = GetSortedPropertyNames<CommonMapToken>();
        foreach (var n in tokenNames)
        {
            tokenCollection.Set(n, tokens[n]);
        }
    }

    private static void PopulateHeightMapTokens(SeedToken seedToken, DesignTokenCollection tokenCollection)
    {
        var tokens = ControlHeightsGenerator.Genereate(seedToken.ControlHeight);
        var tokenNames = GetSortedPropertyNames<HeightMapToken>();
        foreach (var n in tokenNames)
        {
            tokenCollection.Set(n, tokens[n]);
        }
    }

    private static void PopulateSizeMapTokens(SeedToken seedToken, DesignTokenCollection tokenCollection)
    {
        var tokens = SizesGenerator.Genereate(seedToken.SizeUnit, seedToken.SizeStep);

        var tokenNames = GetSortedPropertyNames<SizeMapToken>();
        foreach (var n in tokenNames)
        {
            tokenCollection.Set(n, tokens[n]);
        }
    }

    private void PopulateColorMapTokens(SeedToken seedToken, DesignTokenCollection tokenCollection)
    {
        //TODO: Dont need to follow how antd react does
        var tokens = ColorMapTokensGenerator.Genereate(seedToken, new ColorPalettesGenerationOptions(
            (baseColor) =>
            {
                var colors = colorDerivative.Derive(new HEX(baseColor));

                return new PatternColorPallettes(
                    Bg: colors[0].AsString(),
                    BgHover: colors[1].AsString(),
                    Border: colors[2].AsString(),
                    BorderHover: colors[3].AsString(),
                    Hover: colors[4].AsString(),
                    Default: colors[5].AsString(),
                    Active: colors[6].AsString(),
                    TextHover: colors[4].AsString(),
                    Text: colors[5].AsString(),
                    TextActive: colors[6].AsString());
            },
            (x) =>
            {
                var colorBgBase = new HEX(string.IsNullOrEmpty(x.bgBaseColor) ? "#fff" : x.bgBaseColor);
                var colorTextBase = new HEX(string.IsNullOrEmpty(x.textBaseColor) ? "#000" : x.textBaseColor);

                return new ColorNeutralMapToken(
                    colorText: colorTextBase.ApplyAlpha(0.88).AsString(),
                    colorTextSecondary: colorTextBase.ApplyAlpha(0.65).AsString(),
                    colorTextTertiary: colorTextBase.ApplyAlpha(0.45).AsString(),
                    colorTextQuaternary: colorTextBase.ApplyAlpha(0.25).AsString(),

                    colorFill: colorTextBase.ApplyAlpha(0.15).AsString(),
                    colorFillSecondary: colorTextBase.ApplyAlpha(0.06).AsString(),
                    colorFillTertiary: colorTextBase.ApplyAlpha(0.04).AsString(),
                    colorFillQuaternary: colorTextBase.ApplyAlpha(0.02).AsString(),

                    colorBgLayout: colorBgBase.Darken(4).AsString(),
                    colorBgContainer: colorBgBase.Darken(0).AsString(),
                    colorBgElevated: colorBgBase.Darken(0).AsString(),
                    colorBgSpotlight: colorTextBase.ApplyAlpha(0.85).AsString(),

                    colorBorder: colorBgBase.Darken(15).AsString(),
                    colorBorderSecondary: colorBgBase.Darken(6).AsString());
            }));

        var tokenNames = GetSortedPropertyNames<ColorMapToken>();
        foreach (var n in tokenNames)
        {
            tokenCollection.Set(n, tokens[n]);
        }
    }

    private static void PopulateSeedTokens(SeedToken seedToken, DesignTokenCollection tokenCollection)
    {
        var tokenNames = GetSortedPropertyNames<SeedToken>();
        foreach (var n in tokenNames)
        {
            Console.WriteLine($"{n}: '{seedToken[n]}'");
            tokenCollection.Set(n, seedToken[n]);
        }
    }

    private void PopulateColorPalettes(SeedToken seedToken, DesignTokenCollection tokenCollection)
    {
        var presetColorNames = GetSortedPropertyNames<PresetColorType>();

        foreach (var name in presetColorNames)
        {
            var value = seedToken[name] as string;

            if (string.IsNullOrEmpty(value))
                throw new InvalidOperationException($"{name} is required to set in {nameof(SeedToken)}");

            //TODO: Color.Parse(string). Just assume it will be hex value for now
            var derivedColors = colorDerivative.Derive(new HEX(value))
                .Select(x => x.ToHEX().AsString())
                .ToArray();

            if (derivedColors.Length != 10)
                throw new InvalidOperationException("Derived colors must contain 10 items.");

            for (int i = 0; i < derivedColors.Length; i++)
            {
                tokenCollection.Set($"{name}{i + 1}", derivedColors[i]);
            }
        }
    }

    private static string[] GetSortedPropertyNames<T>()
    {
        return typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .Select(x => x.Name)
            .OrderBy(x => x)
            .ToArray();
    }
}