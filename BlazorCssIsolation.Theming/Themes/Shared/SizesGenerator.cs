using BlazorCssIsolation.Theming.Tokens;

namespace BlazorCssIsolation.Themes.Shared;

// TODO: Consider making each of these generation algorithm as an option
internal static class SizesGenerator
{
    public static SizeMapToken Genereate(double baseUnit, double baseStep)
    {
        return new SizeMapToken(
            sizeXXL: baseUnit * (baseStep + 8), // 48
            sizeXL: baseUnit * (baseStep + 4), // 32
            sizeLG: baseUnit * (baseStep + 2), // 24
            sizeMD: baseUnit * (baseStep + 1), // 20
            sizeMS: baseUnit * baseStep, // 16
            size: baseUnit * baseStep, // 16
            sizeSM: baseUnit * (baseStep - 1), // 12
            sizeXS: baseUnit * (baseStep - 2), // 8
            sizeXXS: baseUnit * (baseStep - 3) // 4
        );
    }
}
