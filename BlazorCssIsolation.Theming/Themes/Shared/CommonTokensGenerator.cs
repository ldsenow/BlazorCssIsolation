using BlazorCssIsolation.Theming.Tokens;

namespace BlazorCssIsolation.Themes.Shared;

// TODO: Consider making each of these generation algorithm as an option
internal static class CommonTokensGenerator
{
    public static CommonMapToken Genereate(SeedToken seed)
    {
        double motionUnit = seed.MotionUnit,
            motionBase = 0,
            fontSize = seed.FontSize,
            borderRadius = seed.BorderRadius,
            lineWidth = seed.LineWidth;

        var fontSizes = FontSizesGenerator.Genereate(fontSize);
        var radii = RadiiGenerator.Genereate(borderRadius);

        return new CommonMapToken(
           borderRadiusLG: radii.BorderRadiusLG,
           borderRadiusSM: radii.BorderRadiusSM,
           borderRadiusXS: radii.BorderRadiusXS,
           borderRadiusOuter: radii.BorderRadiusOuter,
           lineWidthBold: lineWidth + 1,
           motionDurationFast: $"{(motionBase + motionUnit * 1):N1}s",
           motionDurationMid: $"{(motionBase + motionUnit * 2):N1}s",
           motionDurationSlow: $"{(motionBase + motionUnit * 3):N1}s");
    }
}
