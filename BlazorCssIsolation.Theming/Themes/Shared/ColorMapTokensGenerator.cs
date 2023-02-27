using BlazorCssIsolation.Theming.Tokens;

namespace BlazorCssIsolation.Themes.Shared;

// TODO: Consider making each of these generation algorithm as an option
internal static class ColorMapTokensGenerator
{
    public static ColorMapToken Genereate(SeedToken seed, ColorPalettesGenerationOptions options)
    {
        var colorSuccessBase = seed.ColorSuccess;
        var colorWarningBase = seed.ColorWarning;
        var colorErrorBase = seed.ColorError;
        var colorInfoBase = seed.ColorInfo;
        var colorPrimaryBase = seed.ColorPrimary;
        var colorBgBase = seed.ColorBgBase;
        var colorTextBase = seed.ColorTextBase;

        var primaryColors = options.PatternColorPallettesGenerator(colorPrimaryBase);
        var successColors = options.PatternColorPallettesGenerator(colorSuccessBase);
        var warningColors = options.PatternColorPallettesGenerator(colorWarningBase);
        var errorColors = options.PatternColorPallettesGenerator(colorErrorBase);
        var infoColors = options.PatternColorPallettesGenerator(colorInfoBase);

        var neutralColors = options.ColorNeutralPallettesGenerator((colorBgBase, colorTextBase));

        return new ColorMapToken(
            colorBgContainer: neutralColors.ColorBgContainer,
            colorBgElevated: neutralColors.ColorBgElevated,
            colorBgLayout: neutralColors.ColorBgLayout,
            colorBgMask: "rgba(0, 0, 0, 0.45)",
            colorBgSpotlight: neutralColors.ColorBgSpotlight,

            colorBorder: neutralColors.ColorBorder,
            colorBorderSecondary: neutralColors.ColorBorderSecondary,

            colorFill: neutralColors.ColorFill,
            colorFillQuaternary: neutralColors.ColorFillQuaternary,
            colorFillSecondary: neutralColors.ColorFillSecondary,
            colorFillTertiary: neutralColors.ColorFillTertiary,

            colorText: neutralColors.ColorText,
            colorTextQuaternary: neutralColors.ColorTextQuaternary,
            colorTextSecondary: neutralColors.ColorTextSecondary,
            colorTextTertiary: neutralColors.ColorTextTertiary,

            colorPrimaryBg: primaryColors[0],
            colorPrimaryBgHover: primaryColors[1],
            colorPrimaryBorder: primaryColors[2],
            colorPrimaryBorderHover: primaryColors[3],
            colorPrimaryHover: primaryColors[4],
            colorPrimary: primaryColors[5],
            colorPrimaryActive: primaryColors[6],
            colorPrimaryTextHover: primaryColors[7],
            colorPrimaryText: primaryColors[8],
            colorPrimaryTextActive: primaryColors[9],

            colorSuccessBg: successColors[0],
            colorSuccessBgHover: successColors[1],
            colorSuccessBorder: successColors[2],
            colorSuccessBorderHover: successColors[3],
            colorSuccessHover: successColors[3],
            colorSuccess: successColors[5],
            colorSuccessActive: successColors[6],
            colorSuccessTextHover: successColors[7],
            colorSuccessText: successColors[8],
            colorSuccessTextActive: successColors[9],

            colorErrorBg: errorColors[0],
            colorErrorBgHover: errorColors[1],
            colorErrorBorder: errorColors[2],
            colorErrorBorderHover: errorColors[3],
            colorErrorHover: errorColors[4],
            colorError: errorColors[5],
            colorErrorActive: errorColors[6],
            colorErrorTextHover: errorColors[7],
            colorErrorText: errorColors[8],
            colorErrorTextActive: errorColors[9],

            colorWarningBg: warningColors[0],
            colorWarningBgHover: warningColors[1],
            colorWarningBorder: warningColors[2],
            colorWarningBorderHover: warningColors[3],
            colorWarningHover: warningColors[3],
            colorWarning: warningColors[5],
            colorWarningActive: warningColors[6],
            colorWarningTextHover: warningColors[7],
            colorWarningText: warningColors[8],
            colorWarningTextActive: warningColors[9],

            colorInfoBg: infoColors[0],
            colorInfoBgHover: infoColors[1],
            colorInfoBorder: infoColors[2],
            colorInfoBorderHover: infoColors[3],
            colorInfoHover: infoColors[3],
            colorInfo: infoColors[5],
            colorInfoActive: infoColors[6],
            colorInfoTextHover: infoColors[7],
            colorInfoText: infoColors[8],
            colorInfoTextActive: infoColors[9],

            colorWhite: "#fff");
    }
}

public record ColorPalettesGenerationOptions(
    Func<string, string[]> PatternColorPallettesGenerator,
    Func<(string bgBaseColor, string textBaseColor), ColorNeutralMapToken> ColorNeutralPallettesGenerator);