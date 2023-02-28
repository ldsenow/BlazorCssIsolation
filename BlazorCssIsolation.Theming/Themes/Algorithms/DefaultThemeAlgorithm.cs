using BlazorCssIsolation.Themes.Shared;
using BlazorCssIsolation.Theming.Tokens;
using System.Reflection;

namespace BlazorCssIsolation.Theming.Themes.Algorithms;

public class DefaultThemeAlgorithm : IThemeAlgorithm
{
    private readonly IColorDerivative colorDerivative;
    public DefaultThemeAlgorithm(IColorDerivative colorDerivative)
    {
        this.colorDerivative = colorDerivative;
    }

    public IThemeAlgorithm? DerivedFrom { get; set; }

    public ThemeToken Derive(SeedToken seedToken)
    {
        var colorPalettes = BuildColorPalettes(seedToken);
        var colorMapToken = BuildColorMapTokens(seedToken);
        var sizeMapToken = BuildSizeMapTokens(seedToken);
        var heightMapToken = BuildHeightMapTokens(seedToken);
        var fontMapToken = BuildFontMapTokens(seedToken);
        var commonMapToken = BuildCommonMapTokens(seedToken);

        var aliasToken = new AliasToken(
            seedToken: seedToken,
            colorPalettes: colorPalettes,
            colorMapToken: colorMapToken,
            commonMapToken: commonMapToken,
            sizeMapToken: sizeMapToken,
            fontMapToken: fontMapToken,
            heightMapToken: heightMapToken);

        var collection = new ThemeToken(aliasToken);
        
        return collection;
    }

    private static FontMapToken BuildFontMapTokens(SeedToken seedToken)
    {
        return FontMapTokensGenerator.Genereate(seedToken.FontSize);
    }

    private static CommonMapToken BuildCommonMapTokens(SeedToken seedToken)
    {
        var tokens = CommonTokensGenerator.Genereate(seedToken);
        return tokens;
    }

    private static HeightMapToken BuildHeightMapTokens(SeedToken seedToken)
    {
        var tokens = ControlHeightsGenerator.Genereate(seedToken.ControlHeight);
        return tokens;
    }

    private static SizeMapToken BuildSizeMapTokens(SeedToken seedToken)
    {
        var tokens = SizesGenerator.Genereate(seedToken.SizeUnit, seedToken.SizeStep);
        return tokens;
    }

    private ColorMapToken BuildColorMapTokens(SeedToken seedToken)
    {
        //TODO: Dont need to follow how antd react does
        var tokens = ColorMapTokensGenerator.Genereate(seedToken, new ColorPalettesGenerationOptions(
            (baseColor) =>
            {
                var colors = colorDerivative.Derive(new HEX(baseColor));
                var hexColors = colors.Select(x => x.AsString()).ToArray();

                return new[]
                {
                    hexColors[0],
                    hexColors[1],
                    hexColors[2],
                    hexColors[3],
                    hexColors[4],
                    hexColors[5],
                    hexColors[6],
                    hexColors[4],
                    hexColors[5],
                    hexColors[6]
                };
            },
            (x) =>
            {
                //TODO: Color.Parse
                var colorBgBase = new HEX(string.IsNullOrEmpty(x.bgBaseColor) ? "#fff" : x.bgBaseColor);
                var colorTextBase = new HEX(string.IsNullOrEmpty(x.textBaseColor) ? "#000" : x.textBaseColor);

                return new ColorNeutralMapToken(
                    colorText: colorTextBase.ApplyAlpha(0.88).ToRGB().AsString(),
                    colorTextSecondary: colorTextBase.ApplyAlpha(0.65).ToRGB().AsString(),
                    colorTextTertiary: colorTextBase.ApplyAlpha(0.45).ToRGB().AsString(),
                    colorTextQuaternary: colorTextBase.ApplyAlpha(0.25).ToRGB().AsString(),

                    colorFill: colorTextBase.ApplyAlpha(0.15).ToRGB().ToRGB().AsString(),
                    colorFillSecondary: colorTextBase.ApplyAlpha(0.06).ToRGB().AsString(),
                    colorFillTertiary: colorTextBase.ApplyAlpha(0.04).ToRGB().AsString(),
                    colorFillQuaternary: colorTextBase.ApplyAlpha(0.02).ToRGB().AsString(),

                    colorBgLayout: colorBgBase.Darken(4).AsString(),
                    colorBgContainer: colorBgBase.Darken(0).AsString(),
                    colorBgElevated: colorBgBase.Darken(0).AsString(),
                    colorBgSpotlight: colorTextBase.ApplyAlpha(0.85).ToRGB().AsString(),

                    colorBorder: colorBgBase.Darken(15).AsString(),
                    colorBorderSecondary: colorBgBase.Darken(6).AsString());
            }));

        return tokens;
    }

    private ColorPalettes BuildColorPalettes(SeedToken seedToken)
    {
        var map = new Dictionary<string, string>();
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
                map.Add($"{name}{i + 1}", derivedColors[i]);
            }
        }

        return new ColorPalettes(map);
    }

    private static string[] GetSortedPropertyNames<T>()
    {
        return typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .Select(x => x.Name)
            .OrderBy(x => x)
            .ToArray();
    }
}
