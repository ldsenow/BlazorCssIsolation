using BlazorCssIsolation.Theming.Tokens;

namespace BlazorCssIsolation.Themes.Shared;

// TODO: Consider making each of these generation algorithm as an option
internal static class ControlHeightsGenerator
{
    public static HeightMapToken Genereate(double baseUnit)
    {
        return new HeightMapToken(
            controlHeightSM: baseUnit * 0.75,
            controlHeightXS: baseUnit * 0.5,
            controlHeightLG: baseUnit * 1.25);
    }
}
