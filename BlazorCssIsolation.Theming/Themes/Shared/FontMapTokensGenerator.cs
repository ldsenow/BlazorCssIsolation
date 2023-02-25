using BlazorCssIsolation.Theming.Tokens;

namespace BlazorCssIsolation.Themes.Shared;

// TODO: Consider making each of these generation algorithm as an option
internal static class FontMapTokensGenerator
{
    public static FontMapToken Genereate(double fontSize)
    {
        var fontSizePairs = FontSizesGenerator.Genereate(fontSize);
        var fontSizes = fontSizePairs.Select((pair) => pair.Size).ToArray();
        var lineHeights = fontSizePairs.Select((pair) => pair.LineHeight).ToArray();

        return new FontMapToken(
            fontSizeSM: fontSizes[0],
            fontSize: fontSizes[1],
            fontSizeLG: fontSizes[2],
            fontSizeXL: fontSizes[3],

            fontSizeHeading1: fontSizes[6],
            fontSizeHeading2: fontSizes[5],
            fontSizeHeading3: fontSizes[4],
            fontSizeHeading4: fontSizes[3],
            fontSizeHeading5: fontSizes[2],

            lineHeight: lineHeights[1],
            lineHeightLG: lineHeights[2],
            lineHeightSM: lineHeights[0],

            lineHeightHeading1: lineHeights[6],
            lineHeightHeading2: lineHeights[5],
            lineHeightHeading3: lineHeights[4],
            lineHeightHeading4: lineHeights[3],
            lineHeightHeading5: lineHeights[2]);
    }
}
