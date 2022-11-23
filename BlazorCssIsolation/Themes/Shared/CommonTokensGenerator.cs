using BlazorCssIsolation.Tokens;

namespace BlazorCssIsolation.Themes.Shared;

// TODO: Consider making each of these generation algorithm as an option
internal static class CommonTokensGenerator
{
    public static CommonMapToken Genereate(SeedToken seed)
    {
        double motionUnit = seed.MotionUnit,
            motionBase = seed.MotionBase,
            fontSize = seed.FontSize,
            borderRadius = seed.BorderRadius,
            lineWidth = seed.LineWidth;

        var fontSizes = FontSizesGenerator.Genereate(fontSize);
        var radii = RadiiGenerator.Genereate(borderRadius);

        return new CommonMapToken(
           borderRadiusLG: radii.BorderRadiusLG,
           borderRadiusOuter: radii.BorderRadiusOuter,
           borderRadiusSM: radii.BorderRadiusSM,
           borderRadiusXS: radii.BorderRadiusXS,
           fontSizes: fontSizes.Select(x => x.Size).ToArray(),
           lineHeights: fontSizes.Select(x => x.LineHeight).ToArray(),
           lineWidthBold: lineWidth + 1,
           motionDurationFast: $"{(motionBase + motionUnit * 1):N1}s",
           motionDurationMid: $"{(motionBase + motionUnit * 2):N1}s",
           motionDurationSlow: $"{(motionBase + motionUnit * 3):N1}s");
    }
}
