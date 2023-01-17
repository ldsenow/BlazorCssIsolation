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
            colorBgMask: "#0000002d", //rgba(0, 0, 0, 0.45) => hex
            colorBgSpotlight: neutralColors.ColorBgSpotlight,
            colorBorder: neutralColors.ColorBorder,
            colorBorderSecondary: neutralColors.ColorBorderSecondary,
            colorError: errorColors.Default,
            colorErrorActive: errorColors.Active,
            colorErrorBg: errorColors.Bg,
            colorErrorBgHover: errorColors.BgHover,
            colorErrorBorder: errorColors.Border,
            colorErrorBorderHover: errorColors.BorderHover,
            colorErrorHover: errorColors.Hover,
            colorErrorText: errorColors.Text,
            colorErrorTextActive: errorColors.TextActive,
            colorErrorTextHover: errorColors.TextHover,
            colorFill: neutralColors.ColorFill,
            colorFillQuaternary: neutralColors.ColorFillQuaternary,
            colorFillSecondary: neutralColors.ColorFillSecondary,
            colorFillTertiary: neutralColors.ColorFillTertiary,
            colorInfo: infoColors.Default,
            colorInfoActive: infoColors.Active,
            colorInfoBg: infoColors.Bg,
            colorInfoBgHover: infoColors.BgHover,
            colorInfoBorder: infoColors.Border,
            colorInfoBorderHover: infoColors.BorderHover,
            colorInfoHover: infoColors.Hover,
            colorInfoText: infoColors.Text,
            colorInfoTextActive: infoColors.TextActive,
            colorInfoTextHover: infoColors.TextHover,
            colorPrimary: primaryColors.Default,
            colorPrimaryActive: primaryColors.Active,
            colorPrimaryBg: primaryColors.Bg,
            colorPrimaryBgHover: primaryColors.BgHover,
            colorPrimaryBorder: primaryColors.Border,
            colorPrimaryBorderHover: primaryColors.BorderHover,
            colorPrimaryHover: primaryColors.Hover,
            colorPrimaryText: primaryColors.Text,
            colorPrimaryTextActive: primaryColors.TextActive,
            colorPrimaryTextHover: primaryColors.TextHover,
            colorSuccess: successColors.Default,
            colorSuccessActive: successColors.Active,
            colorSuccessBg: successColors.Bg,
            colorSuccessBgHover: successColors.BgHover,
            colorSuccessBorder: successColors.Border,
            colorSuccessBorderHover: successColors.BorderHover,
            colorSuccessHover: successColors.Hover,
            colorSuccessText: successColors.Text,
            colorSuccessTextActive: successColors.TextActive,
            colorSuccessTextHover: successColors.TextHover,
            colorText: neutralColors.ColorText,
            colorTextQuaternary: neutralColors.ColorTextQuaternary,
            colorTextSecondary: neutralColors.ColorTextSecondary,
            colorTextTertiary: neutralColors.ColorTextTertiary,
            colorWarning: warningColors.Default,
            colorWarningActive: warningColors.Active,
            colorWarningBg: warningColors.Bg,
            colorWarningBgHover: warningColors.BgHover,
            colorWarningBorder: warningColors.Border,
            colorWarningBorderHover: warningColors.BorderHover,
            colorWarningHover: warningColors.Hover,
            colorWarningText: warningColors.Text,
            colorWarningTextActive: warningColors.TextActive,
            colorWarningTextHover: warningColors.TextHover,
            colorWhite: "#ffffff");
    }
}

public record ColorPalettesGenerationOptions(
    Func<string, PatternColorPallettes> PatternColorPallettesGenerator,
    Func<(string bgBaseColor, string textBaseColor), ColorNeutralMapToken> ColorNeutralPallettesGenerator);

public record PatternColorPallettes(
    string Bg,
    string BgHover,
    string Border,
    string BorderHover,
    string Hover,
    string Default,
    string Active,
    string TextHover,
    string Text,
    string TextActive);
